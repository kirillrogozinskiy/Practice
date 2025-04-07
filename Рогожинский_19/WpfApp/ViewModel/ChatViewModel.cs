using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Services;

namespace WpfApp.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly ChatClient _client;
        private string _message;
        private string _chatHistory;

        public ChatViewModel()
        {
            SendCommand = new RelayCommand(_ => SendMessage());
            var server = new ChatServer("ChatPipe");
            server.MessageReceived += async (s, e) => await server.BroadcastMessageAsync(e.Message);
            _ = server.StartAsync();

            _client = new ChatClient("ChatPipe");
            _client.MessageReceived += (s, msg) =>
                ChatHistory += $"{DateTime.Now:T} - {msg}{Environment.NewLine}";
            _ = _client.ConnectAsync();
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public string ChatHistory
        {
            get => _chatHistory;
            set
            {
                _chatHistory = value;
                OnPropertyChanged(nameof(ChatHistory));
            }
        }

        public ICommand SendCommand { get; }

        private async void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(Message))
            {
                await _client.SendAsync(Message);
                Message = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
