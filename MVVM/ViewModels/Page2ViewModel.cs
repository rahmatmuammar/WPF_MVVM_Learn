using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_MVVM_Learn.Commands.Page2;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn.MVVM.ViewModels
{
    public class Page2ViewModel : ViewModelBase
    {
        #region ICommands
        public ICommand BrowseFileDirCommand { get; }
        public ICommand SetMediaElementCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }
        #endregion

        public ObservableCollection<RadioButton> RadioButtonChoices { get; set; } = new ObservableCollection<RadioButton>();
        public MediaElement Player { get; set; }
        List<string> MediaTypes = new List<string>() { "Video", "Image" };
        public List<string> MediaDirList { get; set; } = new List<string>();
        public MediaType SelectedMedia { get; set; } = MediaType.Unknown;

        private MediaStatus _mediaStatus = MediaStatus.Stopped;
        public MediaStatus MediaStatus 
        {
            get { return _mediaStatus; }
            set 
            { 
                _mediaStatus = value;
                IsGridMenuEnabled = (value == MediaStatus.Stopped ? true : false); 
            } 
        }
        public int mediaListNumber { get; set; } = 0;

        private string _mediaFileDirectory;
        public string MediaFileDirectory
        {
            get { return _mediaFileDirectory; }
            set 
            { 
                _mediaFileDirectory = value;
                OnPropertyChanged(nameof(MediaFileDirectory)); 
            }
        }

        private string _buttonText = "Play";
        public string ButtonText
        {
            get { return _buttonText; }
            set 
            { 
                _buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        private bool _isGridMenuEnabled = true;
        public bool IsGridMenuEnabled
        {
            get { return _isGridMenuEnabled; }
            set 
            {
                _isGridMenuEnabled = value;
                OnPropertyChanged(nameof(IsGridMenuEnabled)); 
            }
        }


        public Page2ViewModel(NavigationStore navigationStore)
        {
            #region ICommands
            PreviousPageCommand = new ToPage1Command(this,
                new NavigationService<Page1ViewModel>(navigationStore, () => new Page1ViewModel(navigationStore)));

            NextPageCommand = new ToPage3Command(this,
                new NavigationService<Page3ViewModel>(navigationStore, () => new Page3ViewModel(navigationStore)));

            BrowseFileDirCommand = new BrowseDirectoryCommand(this);
            SetMediaElementCommand = new SetMediaElementCommand(this);
            #endregion

            #region Media Player
            foreach (var mediaTypes in MediaTypes)
            {
                RadioButton radioButton = new RadioButton
                {
                    Content = mediaTypes,
                    GroupName = "MediaType",
                    Margin = new System.Windows.Thickness(5)
                };
                radioButton.Checked += RadioButton_Checked; ;
                RadioButtonChoices.Add(radioButton);
            }

            Player = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual,
                Stretch = System.Windows.Media.Stretch.Uniform
            };

            Player.MediaEnded += Player_MediaEnded;
            #endregion
        }

        #region Events
        private void Player_MediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            mediaListNumber++;
            if(mediaListNumber >= MediaDirList.Count) mediaListNumber = 0;
            if (MediaDirList.Count != 0)
            {
                ClassGlobal.PlayVideos(Player, MediaDirList[mediaListNumber]);
            }
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SelectedMedia = ClassGlobal.ToEnum<MediaType>((sender as RadioButton).Content.ToString().Replace(" ", "_"));
        }
        #endregion
    }
}
