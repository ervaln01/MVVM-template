using System.Threading;
using Mvvm.Bindings.Commands;

namespace Mvvm.Ui.ViewModels.Indicators
{
    public class ProgressIndicator : SimpleIndicator
    {
        private CancellationTokenSource _tokenSource;
        public ProgressViewModel ProgressExport { get; }

        public ProgressIndicator()
        {
            ProgressExport = new ProgressViewModel(new MvvmCommand(() => _tokenSource?.Cancel()));
        }

        protected override void AnyAction()
        {
            _tokenSource = new CancellationTokenSource();
            ProgressExport.Progress = 0;
            ProgressExport.Maximum = Timeout;

            for (var i = 0; i < Timeout; i++)
            {
                if (_tokenSource.IsCancellationRequested)
                    return;

                Thread.Sleep(1000);
                ProgressExport.Report(1);
            }
        }
    }
}
