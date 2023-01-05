using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_MVVM_Learn.Assets.Popups.Views
{
    /// <summary>
    /// Interaction logic for PopupSingleChoice.xaml
    /// </summary>
    public partial class PopupSingleChoice : Window
    {
        public MessageBoxResult Result { get; set; }
        internal string _Title
        {
            get
            {
                return TB_Title.Text;
            }
            set
            {
                TB_Title.Text = value;
            }
        }
        internal string Message
        {
            get
            {
                return TB_Message.Text;
            }
            set
            {
                TB_Message.Text = value;
            }
        }

        internal string OkButtonText
        {
            get
            {
                return BTN_OK.Content.ToString();
            }
            set
            {
                BTN_OK.Content = value;
            }
        }

        internal PopupSingleChoice(string title, string message, string okButtonText)
        {
            InitializeComponent();

            _Title = title;
            Message = message;
            OkButtonText = okButtonText;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            Close();
        }
    }
}
