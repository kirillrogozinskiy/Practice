using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class ChatMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string Sender { get; set; }
    }

    public class ChatServer : IDisposable
    {
        private readonly string _pipeName;
        private readonly ConcurrentDictionary<string, NamedPipeServerStream> _activeConnections = new();
        private bool _isRunning;

        public event EventHandler<ChatMessageEventArgs> MessageReceived;

        public ChatServer(string pipeName)
        {
            _pipeName = pipeName;
        }

        public async Task StartAsync()
        {
            _isRunning = true;
            while (_isRunning)
            {
                var pipe = new NamedPipeServerStream(
                    _pipeName,
                    PipeDirection.InOut,
                    NamedPipeServerStream.MaxAllowedServerInstances,
                    PipeTransmissionMode.Message,
                    PipeOptions.Asynchronous);

                await pipe.WaitForConnectionAsync();
                _ = HandleClientAsync(pipe);
            }
        }

        private async Task HandleClientAsync(NamedPipeServerStream pipe)
        {
            var connectionId = Guid.NewGuid().ToString();
            _activeConnections.TryAdd(connectionId, pipe);

            try
            {
                using var reader = new StreamReader(pipe, Encoding.UTF8);
                while (pipe.IsConnected)
                {
                    var message = await reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(message)) continue;

                    MessageReceived?.Invoke(this, new ChatMessageEventArgs
                    {
                        Message = message,
                        Sender = connectionId
                    });
                }
            }
            finally
            {
                pipe.Dispose();
                _activeConnections.TryRemove(connectionId, out _);
            }
        }

        public async Task BroadcastMessageAsync(string message)
        {
            var data = Encoding.UTF8.GetBytes(message + Environment.NewLine);
            foreach (var pipe in _activeConnections.Values)
            {
                if (pipe.IsConnected)
                {
                    await pipe.WriteAsync(data, 0, data.Length);
                    await pipe.FlushAsync();
                }
            }
        }

        public void Dispose()
        {
            _isRunning = false;
            foreach (var pipe in _activeConnections.Values)
            {
                pipe.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}