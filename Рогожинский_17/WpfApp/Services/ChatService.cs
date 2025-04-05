using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Services
{
    public class ChatService : IDisposable
    {
        private readonly string _department;
        private readonly string _mmfName;
        private readonly string _eventName;
        private readonly string _mutexName;

        private const long MmfSizeBytes = 4096; // Max message size + overhead

        private MemoryMappedFile _mmf;
        private EventWaitHandle _eventWaitHandle;
        private Mutex _mutex;
        private CancellationTokenSource _cts;
        private Task _listeningTask;

        // Event to notify ViewModel of received messages
        public delegate void MessageReceivedEventHandler(string message);
        public event MessageReceivedEventHandler MessageReceived;

        // Flag to prevent processing self-sent messages immediately
        private string _lastSentMessageSignature = null;
        private readonly object _sendLock = new object();


        public ChatService(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentNullException(nameof(department));

            _department = department;
            // Generate unique names based on department
            _mmfName = $"ChatMMF_{_department}";
            _eventName = $"ChatEvent_{_department}";
            _mutexName = $"ChatMutex_{_department}";

            bool createdNew;
            _mutex = new Mutex(false, _mutexName, out createdNew); // Initially not owned
            _eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, _eventName, out createdNew); // Initially non-signaled, auto-resets
            _mmf = MemoryMappedFile.CreateOrOpen(_mmfName, MmfSizeBytes, MemoryMappedFileAccess.ReadWrite);

            Console.WriteLine($"ChatService for '{department}' initialized. MMF: {_mmfName}, Event: {_eventName}, Mutex: {_mutexName}");
        }

        public void StartListening()
        {
            if (_listeningTask != null && !_listeningTask.IsCompleted)
            {
                Console.WriteLine("Listener already running.");
                return; // Already listening
            }

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            _listeningTask = Task.Run(() => ListenLoop(token), token);
            Console.WriteLine($"ChatService for '{_department}': Started listening.");
        }

        private void ListenLoop(CancellationToken token)
        {
            Console.WriteLine($"ChatService for '{_department}': Listener thread started.");
            while (!token.IsCancellationRequested)
            {
                try
                {
                    // Wait for a signal indicating a new message
                    if (_eventWaitHandle.WaitOne(TimeSpan.FromSeconds(5))) // Wait up to 5s, then loop to check cancellation
                    {
                        // Wait for exclusive access to read
                        if (_mutex.WaitOne(TimeSpan.FromSeconds(1))) // Wait max 1s for mutex
                        {
                            string receivedMessage = null;
                            try
                            {
                                using (var accessor = _mmf.CreateViewAccessor(0, MmfSizeBytes, MemoryMappedFileAccess.Read))
                                {
                                    // Read length prefix (first 4 bytes)
                                    int messageLength = accessor.ReadInt32(0);

                                    if (messageLength > 0 && messageLength <= MmfSizeBytes - 4)
                                    {
                                        byte[] buffer = new byte[messageLength];
                                        accessor.ReadArray(4, buffer, 0, messageLength);
                                        receivedMessage = Encoding.UTF8.GetString(buffer);
                                    }
                                }
                            }
                            catch (Exception readEx)
                            {
                                Console.WriteLine($"Error reading from MMF: {readEx.Message}");
                                receivedMessage = null; // Ensure message is null on error
                            }
                            finally
                            {
                                _mutex.ReleaseMutex();
                            }

                            // Process the message if read successfully
                            if (!string.IsNullOrEmpty(receivedMessage))
                            {
                                lock (_sendLock) // Check against last sent signature
                                {
                                    if (receivedMessage == _lastSentMessageSignature)
                                    {
                                        // It's our own message we just sent, clear the signature and ignore
                                        _lastSentMessageSignature = null;
                                        Console.WriteLine($"ChatService for '{_department}': Ignored own message echo.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"ChatService for '{_department}': Received: {receivedMessage}");
                                        // Raise the event for the ViewModel (needs Dispatcher)
                                        MessageReceived?.Invoke(receivedMessage);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ChatService for '{_department}': Timed out waiting for mutex after event signal.");
                        }
                    }
                }
                catch (AbandonedMutexException)
                {
                    Console.WriteLine($"ChatService for '{_department}': Recovered from abandoned mutex.");
                    // Mutex was abandoned (process crashed holding it), we now own it. Release it.
                    try { _mutex.ReleaseMutex(); } catch { /* Ignore release error after abandon */ }
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine($"ChatService for '{_department}': Wait handle disposed, stopping listener.");
                    break; // Exit loop if disposed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ChatService for '{_department}': Error in listen loop: {ex.Message}");
                    // Avoid tight loop on persistent error
                    Task.Delay(1000, token).Wait(); // Use Task.Delay for cancellation support
                }
            }
            Console.WriteLine($"ChatService for '{_department}': Listener thread stopped.");
        }

        public async Task SendMessageAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            await Task.Run(() => // Offload synchronous waits from UI thread
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                // Check size (+4 for length prefix)
                if (buffer.Length > MmfSizeBytes - 4)
                {
                    Console.WriteLine($"Error: Message too large ({buffer.Length} bytes), max is {MmfSizeBytes - 4}");
                    return; // Or throw exception
                }

                // Wait for exclusive access to write
                if (_mutex.WaitOne(TimeSpan.FromSeconds(2))) // Wait max 2s
                {
                    try
                    {
                        // Store signature to potentially ignore echo
                        lock (_sendLock)
                        {
                            _lastSentMessageSignature = message;
                        }

                        using (var accessor = _mmf.CreateViewAccessor(0, MmfSizeBytes, MemoryMappedFileAccess.Write))
                        {
                            // Write length prefix
                            accessor.Write(0, buffer.Length);
                            // Write message data
                            accessor.WriteArray(4, buffer, 0, buffer.Length);
                            // Optional: Clear remaining buffer if needed, but length prefix handles it
                            // accessor.WriteArray(4 + buffer.Length, new byte[MmfSizeBytes - 4 - buffer.Length], 0, MmfSizeBytes - 4 - buffer.Length);
                            accessor.Flush(); // Ensure data is written
                        }

                        // Signal other processes that new data is available
                        _eventWaitHandle.Set();
                        Console.WriteLine($"ChatService for '{_department}': Sent: {message}");
                    }
                    catch (Exception writeEx)
                    {
                        Console.WriteLine($"Error writing to MMF: {writeEx.Message}");
                        lock (_sendLock) { _lastSentMessageSignature = null; } // Clear signature on error
                    }
                    finally
                    {
                        _mutex.ReleaseMutex();
                    }
                }
                else
                {
                    Console.WriteLine($"ChatService for '{_department}': Timed out waiting for mutex to send message.");
                    lock (_sendLock) { _lastSentMessageSignature = null; } // Clear signature on timeout
                }
            });
        }

        public void Dispose()
        {
            Console.WriteLine($"ChatService for '{_department}': Disposing...");
            _cts?.Cancel(); // Signal the listening task to stop

            // Wait briefly for the listener task to finish
            try
            {
                _listeningTask?.Wait(TimeSpan.FromMilliseconds(500));
            }
            catch (OperationCanceledException) { /* Expected */ }
            catch (AggregateException ae) { ae.Handle(ex => ex is OperationCanceledException); }


            _cts?.Dispose();
            // Wake up the event handle one last time in case the listener is stuck waiting
            _eventWaitHandle?.Set();
            _eventWaitHandle?.Dispose();
            _mmf?.Dispose();
            _mutex?.Dispose();

            _listeningTask = null;
            _cts = null;
            _eventWaitHandle = null;
            _mmf = null;
            _mutex = null;
            Console.WriteLine($"ChatService for '{_department}': Disposed.");
        }
    }
}