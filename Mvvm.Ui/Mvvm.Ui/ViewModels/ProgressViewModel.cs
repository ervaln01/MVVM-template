using System;
using System.Windows.Input;
using Mvvm.Bindings;

namespace Mvvm.Ui.ViewModels
{
    public class ProgressViewModel : BindingBase, IProgress<int>
    {
        private int _progress;
        private int _maximum;
        public ICommand CancelCommand { get; }

        public int Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        public int Maximum
        {
            get => _maximum;
            set => SetProperty(ref _maximum, value);
        }

        public ProgressViewModel(ICommand cancelCommand)
        {
            CancelCommand = cancelCommand;
        }

        public void Report(int value) => Progress += value;

        public void Reset() => Progress = 0;
    }
}