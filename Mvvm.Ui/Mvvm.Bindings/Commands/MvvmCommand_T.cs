using System;

namespace Mvvm.Bindings.Commands
{
    public class MvvmCommand<T> : MvvmCommandBase
    {
        public MvvmCommand(Action<T> action, Func<T, bool> canExecute) : base(o => action((T)o), o => canExecute((T)o)) { }

        public MvvmCommand(Action<T> action) : base(o => action((T)o)) { }
    }
}
