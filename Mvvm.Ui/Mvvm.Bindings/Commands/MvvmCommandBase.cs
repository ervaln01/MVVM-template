using System;
using System.Windows.Input;

namespace Mvvm.Bindings.Commands
{
    public abstract class MvvmCommandBase : ICommand
    {
        protected Action<object> Action { get; private set; }

        protected Func<object, bool> CanExecuteAction { get; private set; }

        public event EventHandler CanExecuteChanged;

        protected MvvmCommandBase(Action<object> action, Func<object, bool> canExecuteAction)
        {
            Action = action;
            CanExecuteAction = canExecuteAction;
        }

        protected MvvmCommandBase(Action<object> action) : this(action, p => true) { }

        public bool CanExecute(object parameter) => CanExecuteAction(parameter);

        public void Execute(object parameter) => Action(parameter);

        public void RaiseCanExecuteChanged(object sender)
        {
            EventHandler canExecuteChanged = CanExecuteChanged;

            if (canExecuteChanged == null)
                return;

            canExecuteChanged(sender, null);
        }
    }
}
