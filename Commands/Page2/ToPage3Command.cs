using WPF_MVVM_Learn.MVVM.ViewModels;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn.Commands.Page2
{
    internal class ToPage3Command : CommandBase
    {
        private readonly Page2ViewModel _viewModel;
        private readonly NavigationService<Page3ViewModel> _navigationService;
        public ToPage3Command(Page2ViewModel viewModel, NavigationService<Page3ViewModel> navigationService)
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
