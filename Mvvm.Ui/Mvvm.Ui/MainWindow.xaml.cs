using System.Windows;
using Mvvm.Ui.ViewModels;

namespace Mvvm.Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel() { OnBusy = isBusy => Dispatcher?.Invoke(() => MainBusyIndicator.IsBusy = isBusy) };
            _viewModel.SimpleIndicator.OnBusy = isBusy => Dispatcher?.Invoke(() => SimpleBusyIndicator.IsBusy = isBusy);
            _viewModel.CancelIndicator.OnBusy = isBusy => Dispatcher?.Invoke(() => CancelBusyIndicator.IsBusy = isBusy);
            _viewModel.ProgressIndicator.OnBusy = isBusy => Dispatcher?.Invoke(() => ProgressBusyIndicator.IsBusy = isBusy);
            ProgressBusyIndicator.Tag = _viewModel.ProgressIndicator.ProgressExport;
            DataContext = _viewModel;
        }

        private void CancelBusyIndicator_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CancelIndicator.Cancel();
        }
    }
}
