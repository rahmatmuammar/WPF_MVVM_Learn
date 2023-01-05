using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Learn.Assets.Popups;
using WPF_MVVM_Learn.MVVM.ViewModels;

namespace WPF_MVVM_Learn.Commands.Page3
{    
    internal class OpenPopupAlertCommand :CommandBase
    {
        private readonly Page3ViewModel _viewModel;

        public OpenPopupAlertCommand(Page3ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            switch (_viewModel.selectedMessageBoxType)
            {
                case MessageBoxType.Single_Button:
                    CustomPopupSingleButton.ShowOK(
                        _viewModel.Title, 
                        _viewModel.Content,
                        _viewModel.Option1);
                    break;
                case MessageBoxType.Multi_Button:
                    CustomPopupMultiButton.ShowYesNo(
                        _viewModel.Title,
                        _viewModel.Content,
                        _viewModel.Option1,
                        _viewModel.Option2);
                    break;
                case MessageBoxType.Multi_Button_With_Timeout:
                    CustomPopupMultiButton.ShowYesNoWithTimeout(
                        _viewModel.Title,
                        _viewModel.Content,
                        _viewModel.Option1,
                        _viewModel.Option2,
                        _viewModel.selectedDecision == Decisions.Yes ? System.Windows.MessageBoxResult.Yes : System.Windows.MessageBoxResult.No,
                        int.Parse(_viewModel.TimeoutInterval)*1000
                        );
                    break;
                default:
                    break;
            }
        }
    }
}
