using System;
using System.Threading;

namespace Mvvm.Bindings
{
    public abstract class RichBindingBase : BindingBase, IDisposable
    {
        private bool _isDisposed;

        public Action<bool> OnBusy { get; set; }
        public Action<Action> OnDispatcher { get; set; }
        
        protected virtual void ExecuteOnThreadPool(Action tryAction, Action<Exception> catchAction = null, Action finallyAction = null)
        {
            OnBusy?.Invoke(true);

            ThreadPool.QueueUserWorkItem(obj =>
            {
                try
                {
                    tryAction.Invoke();
                }
                catch(Exception e)
                {
                    catchAction?.Invoke(e);
                }
                finally
                {
                    OnBusy?.Invoke(false);
                    finallyAction?.Invoke();
                }
            });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            if (!disposing)
                return;

            Terminate();
        }

        protected virtual void Terminate() { }
    }
}