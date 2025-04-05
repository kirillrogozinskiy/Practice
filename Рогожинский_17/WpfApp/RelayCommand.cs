using System.Windows.Input;

namespace WpfApp
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute; // Allow null parameter
        private readonly Func<object?, bool>? _canExecute; // Allow null parameter and make Func nullable

        // Match ICommand's nullability for the event
        public event EventHandler? CanExecuteChanged;

        // Constructor accepting nullable canExecute
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Match ICommand's nullability for the parameter
        public bool CanExecute(object? parameter)
        {
            // If _canExecute is null, the command can always execute.
            // Otherwise, invoke _canExecute.
            return _canExecute == null || _canExecute(parameter);
        }

        // Match ICommand's nullability for the parameter
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        // Method to manually trigger the CanExecuteChanged event
        public void RaiseCanExecuteChanged()
        {
            // Use the null-conditional operator ?. to safely invoke the event
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            /* Alternatively, more explicit WPF way (often preferred):
            App.Current.Dispatcher.Invoke(() => // Ensure execution on UI thread
            {
                 CommandManager.InvalidateRequerySuggested();
            });
            // If using this, you might not need the CanExecuteChanged?.Invoke line,
            // but having both doesn't usually hurt. InvalidateRequerySuggested is broader.
            // Let's keep the direct invoke for now as it's what the original intent seemed to be.
            */
        }
    }
}
