using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_MVVM_Learn.Commands.Page3;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn.MVVM.ViewModels
{
    public class Page3ViewModel : ViewModelBase
    {
        #region ICommands
        public ICommand PreviousPageCommand { get; }
        public ICommand NextPageCommand { get; }

        public ICommand OpenPopupAlertCommand { get; }
        #endregion

        #region Bindings
        private string _title = "Title";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _content = "Content";
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private string _option1 = "Yes";
        public string Option1
        {
            get { return _option1; }
            set { _option1 = value; }
        }

        private string _option2 = "No";
        public string Option2
        {
            get { return _option2; }
            set { _option2 = value; }
        }

        private string _timeoutInterval = "10";
        public string TimeoutInterval
        {
            get { return _timeoutInterval; }
            set { _timeoutInterval = value; }
        }


        #endregion

        public ObservableCollection<RadioButton> ButtonTypeChoices { get; set; } = new ObservableCollection<RadioButton>();
        List<string> ButtonTypes = new List<string>()
        {
            "Single Button",
            "Multi Button",
            "Multi Button With Timeout"
        };
        public MessageBoxType selectedMessageBoxType;

        public ObservableCollection<RadioButton> DecisionTypeChoices { get; set; } = new ObservableCollection<RadioButton>();
        List<string> DecisionTypes = new List<string>()
        {
            "No",
            "Yes"
        };
        public Decisions selectedDecision;

        public Page3ViewModel(NavigationStore navigationStore)
        {
            #region ICommands
            PreviousPageCommand = new ToPage2Command(this,
                new NavigationService<Page2ViewModel>(navigationStore, () => new Page2ViewModel(navigationStore)));

            OpenPopupAlertCommand = new OpenPopupAlertCommand(this);
            #endregion

            foreach (var mediaTypes in ButtonTypes)
            {
                RadioButton radioButton = new RadioButton
                {
                    Content = mediaTypes,
                    GroupName = "MessageBoxType",
                    Margin = new System.Windows.Thickness(5)
                };
                radioButton.Checked += RadioButtonTypes_Checked;
                ButtonTypeChoices.Add(radioButton);
            }

            foreach (var decisionTypes in DecisionTypes)
            {
                RadioButton radioButton = new RadioButton
                {
                    Content = decisionTypes,
                    GroupName = "DecisionType",
                    Margin = new System.Windows.Thickness(5)
                };
                radioButton.Checked += RadioButtonDecisionTypes_Checked;
                DecisionTypeChoices.Add(radioButton);
            }
        }

        #region Events
        private void RadioButtonDecisionTypes_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            selectedDecision = ClassGlobal.ToEnum<Decisions>((sender as RadioButton).Content.ToString().Replace(" ", "_"));
        }
        private void RadioButtonTypes_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            selectedMessageBoxType = ClassGlobal.ToEnum<MessageBoxType>((sender as RadioButton).Content.ToString().Replace(" ", "_"));
        }
        #endregion
    }
}
