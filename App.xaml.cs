using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_Learn.MVVM.ViewModels;
using WPF_MVVM_Learn.Navigation;

namespace WPF_MVVM_Learn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new Page1ViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new ViewModelMain(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
