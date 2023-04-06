using System;

namespace Mvvm.Bindings.Commands
{
    public class MvvmCommand : MvvmCommandBase
    {
        public MvvmCommand(Action action, Func<bool> canExecute) : base(o => action(), o => canExecute()) { }

        public MvvmCommand(Action action) : base(o => action()) { }
    }
}
