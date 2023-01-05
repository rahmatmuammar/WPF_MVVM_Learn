using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Learn.MVVM.ViewModels;

namespace WPF_MVVM_Learn.Commands.Page2
{
    internal class BrowseDirectoryCommand : CommandBase
    {
        private readonly Page2ViewModel _viewModel;
        public BrowseDirectoryCommand(Page2ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            string bufDir = string.Empty;
            ClassGlobal.BrowseFolderDirectory(ref bufDir);
            _viewModel.MediaFileDirectory = bufDir;
        }
    }
}
