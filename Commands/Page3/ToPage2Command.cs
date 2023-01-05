using WPF_MVVM_Learn.MVVM.ViewModels;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn.Commands.Page3
{
    internal class ToPage2Command : CommandBase
    {
        private readonly Page3ViewModel _viewModel;
        private readonly NavigationService<Page2ViewModel> _navigationService;
        public ToPage2Command(Page3ViewModel viewModel, NavigationService<Page2ViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }
        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
