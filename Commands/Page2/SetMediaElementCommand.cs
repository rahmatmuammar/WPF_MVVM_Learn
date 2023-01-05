using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Learn.MVVM.ViewModels;

namespace WPF_MVVM_Learn.Commands.Page2
{
    internal class SetMediaElementCommand : CommandBase
    {
        private readonly Page2ViewModel _viewModel;
        public SetMediaElementCommand(Page2ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            switch (_viewModel.SelectedMedia)
            {
                case MediaType.Unknown:
                    break;
                case MediaType.Video:
                    {
                        switch (_viewModel.MediaStatus)
                        {
                            case MediaStatus.Stopped:
                                {
                                    _viewModel.MediaDirList = ClassGlobal.GetAllMediaFileNames(MediaType.Video, _viewModel.MediaFileDirectory);
                                    if (_viewModel.MediaDirList.Count != 0)
                                    {
                                        ClassGlobal.PlayVideos(_viewModel.Player, _viewModel.MediaDirList.First());
                                        _viewModel.mediaListNumber = 0;
                                        _viewModel.MediaStatus = MediaStatus.Playing;
                                        _viewModel.ButtonText = "Stop";
                                    }
                                    break;
                                }
                            case MediaStatus.Playing:
                                {
                                    ClassGlobal.StopVideos(_viewModel.Player);
                                    _viewModel.mediaListNumber = 0;
                                    _viewModel.MediaStatus = MediaStatus.Stopped;
                                    _viewModel.ButtonText = "Play";
                                    break;
                                }
                        }
                        break;
                    }
                case MediaType.Image:
                    break;
                default:
                    break;
            }
        }
    }
}
