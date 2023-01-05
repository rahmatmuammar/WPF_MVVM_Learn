using WPF_MVVM_Learn.MVVM.ViewModels;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn.Commands.Page1
{
    internal class ToSelectedPageCommand : CommandBase
    {
        private readonly Page1ViewModel _viewModel;
        private readonly NavigationService<Page2ViewModel> _navigationServiceP2;
        private readonly NavigationService<Page3ViewModel> _navigationServiceP3;
        public ToSelectedPageCommand(Page1ViewModel viewModel, 
            NavigationService<Page2ViewModel> navigationServiceP2,
            NavigationService<Page3ViewModel> navigationServiceP3)
        {
            _viewModel = viewModel;
            _navigationServiceP2 = navigationServiceP2;
            _navigationServiceP3 = navigationServiceP3;
        }
        public override void Execute(object parameter)
        {
            switch (_viewModel.SelectedPages)
            {
                case PageNumber.Page_2:
                    _navigationServiceP2.Navigate();
                    break;
                case PageNumber.Page_3:
                    _navigationServiceP3.Navigate();
                    break;
            }
        }
    }
}
