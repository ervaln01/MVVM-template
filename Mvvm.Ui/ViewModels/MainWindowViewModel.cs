using System.Threading;
using System.Windows.Input;
using Mvvm.Bindings;
using Mvvm.Bindings.Commands;
using Mvvm.Ui.ViewModels.Indicators;

namespace Mvvm.Ui.ViewModels
{
    public class MainWindowViewModel : RichBindingBase
    {
        public ICommand WindowLoadedCommand { get; }

        public SimpleIndicator SimpleIndicator { get; } 
        public CancelIndicator CancelIndicator { get; }
        public ProgressIndicator ProgressIndicator { get; }

        public MainWindowViewModel() 
        {
            SimpleIndicator = new SimpleIndicator();
            CancelIndicator = new CancelIndicator();
            ProgressIndicator = new ProgressIndicator();
            WindowLoadedCommand = new MvvmCommand(WindowLoaded);
        }

        private void WindowLoaded()
        {
            ExecuteOnThreadPool(() => 
            { 
                Thread.Sleep(5000);
            });
        }
    }
}
