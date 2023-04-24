using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Mvvm.Bindings;
using Mvvm.Bindings.Commands;

namespace Mvvm.Ui.ViewModels.Indicators
{
    public class SimpleIndicator : RichBindingBase
    {
        private int _timeout;
        public int Timeout
        {
            get => _timeout;
            set => SetProperty(ref _timeout, value);
        }

        public ICommand StartCommand { get; }

        public SimpleIndicator()
        {
            StartCommand = new MvvmCommand(Start);
            Timeout = 5;
        }

        private void Start()
        {
            if (_timeout < 0)
            {
                MessageBox.Show("Timeout < 0");
                return;
            }

            ExecuteOnThreadPool(() => AnyAction());
        }

        protected virtual void AnyAction()
        {
            Thread.Sleep(Timeout * 1000);
        }
    }
}
