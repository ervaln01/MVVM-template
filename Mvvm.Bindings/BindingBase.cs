using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mvvm.Bindings
{
    public abstract class BindingBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if ((object)storage == (object)value)
                return false;

            if (storage == null || !storage.Equals(value))
            {
                storage = value;
                RaisePropertyChangedEvent(propertyName);
            }

            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => RaisePropertyChangedEvent(propertyName);

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            
            if (propertyChanged == null)
                return;
            
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
