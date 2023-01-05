using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_MVVM_Learn.Commands.Page1;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn.MVVM.ViewModels
{
    public class Page1ViewModel : ViewModelBase
    {
        public ICommand ToSelectedPageCommand { get;}
        public ObservableCollection<RadioButton> RadioButtonChoices { get; set; } = new ObservableCollection<RadioButton>();

        List<string> Pages = new List<string> (){ "Page 2", "Page 3" };

        public PageNumber SelectedPages { get; set; } = PageNumber.Unknown;

        private string _nextPage;
        public string NextPage
        {
            get { return _nextPage; }
            set 
            { 
                _nextPage = value; 
                OnPropertyChanged(nameof(NextPage)); 
            }
        }


        public bool IsChecked { get; set; }

        public Page1ViewModel(NavigationStore navigationStore)
        {
            ToSelectedPageCommand = new ToSelectedPageCommand(this, 
                new NavigationService<Page2ViewModel>(navigationStore, () => new Page2ViewModel(navigationStore)),
                new NavigationService<Page3ViewModel>(navigationStore, () => new Page3ViewModel(navigationStore)));

            foreach (var page in Pages)
            {
                RadioButton radioButton = new RadioButton { Content = page, 
                    GroupName = "Pages", 
                    Style = (System.Windows.Style)System.Windows.Application.Current.Resources["ChoiceRadioButton"]};
                radioButton.Checked += RadioButtonPageChoices_Checked;
                RadioButtonChoices.Add(radioButton);
            }
        }


        private void RadioButtonPageChoices_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SelectedPages = ClassGlobal.ToEnum<PageNumber>((sender as RadioButton).Content.ToString().Replace(" ", "_"));
            NextPage = $"To {SelectedPages.ToString().Replace("_"," ")}";
        }
    }
}
