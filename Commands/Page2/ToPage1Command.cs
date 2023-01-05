using WPF_MVVM_Learn.MVVM.ViewModels;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn.Commands.Page2
{
    internal class ToPage1Command : CommandBase
    {
        private readonly Page2ViewModel _viewModel;
        private readonly NavigationService<Page1ViewModel> _navigationService;
        public ToPage1Command(Page2ViewModel viewModel, NavigationService<Page1ViewModel> navigationService)
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
