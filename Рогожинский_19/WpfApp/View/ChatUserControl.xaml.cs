using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.ViewModel;

namespace WpfApp
{
    public partial class ChatUserControl : UserControl
    {
        public ChatUserControl()
        {
            InitializeComponent();
            DataContext = new ChatViewModel();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && DataContext is ChatViewModel vm)
            {
                vm.SendCommand.Execute(null);
            }
        }
    }
}