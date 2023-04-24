using System.Threading;

namespace Mvvm.Ui.ViewModels.Indicators
{
    public class CancelIndicator : SimpleIndicator
    {
        private CancellationTokenSource _tokenSource;

        public void Cancel() => _tokenSource?.Cancel();

        protected override void AnyAction()
        {
            _tokenSource = new CancellationTokenSource();

            for (var i = 0; i < Timeout; i++)
            {
                if (_tokenSource.IsCancellationRequested)
                    return;

                Thread.Sleep(1000);
            }
        }
    }
}
