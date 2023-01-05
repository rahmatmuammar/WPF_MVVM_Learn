using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace WPF_MVVM_Learn.Assets.Popups.Views
{
    /// <summary>
    /// Interaction logic for PopupMultiChoice.xaml
    /// </summary>
    public partial class PopupMultiChoice : Window
    {
        public MessageBoxResult Result { get; set; }
        internal double Timeout { get; set; }
        internal Stopwatch startTimeout { get; set; }
        internal string timeoutText { get; set; }
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

        private string _noButtonText { get; set; }
        internal string NoButtonText
        {
            get
            {
                return _noButtonText.ToString();
            }
            set
            {
                _noButtonText = value;
                if (Result != MessageBoxResult.No) BTN_No.Content = value;
            }
        }

        private string _yesButtonText { get; set; }
        internal string YesButtonText
        {
            get
            {
                return _yesButtonText.ToString();
            }
            set
            {
                _yesButtonText = value;
                if (Result != MessageBoxResult.Yes) BTN_Yes.Content = value;
            }
        }

        internal DispatcherTimer _timer = new DispatcherTimer(DispatcherPriority.Render);

        internal PopupMultiChoice(string title, string message, string yesButtonText, string noButtonText, MessageBoxResult decisionWhenTimeout = MessageBoxResult.No, int timeout = 0)
        {
            InitializeComponent();

            _Title = title;
            Message = message;
            YesButtonText = yesButtonText;
            NoButtonText = noButtonText;

            if (timeout > 0)
            {
                Result = decisionWhenTimeout;
                Timeout = timeout;

                _timer.Interval = TimeSpan.FromMilliseconds(100);
                _timer.Tick += _timer_Tick;
                startTimeout = new Stopwatch();
                startTimeout.Start();
                _timer.Start();
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (startTimeout.ElapsedMilliseconds >= Timeout)
            {
                _timer.Stop();
                Close();
            }
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    BTN_Yes.Content = $"{YesButtonText} ({(Timeout / 1000) - startTimeout.Elapsed.Seconds})";
                    break;
                case MessageBoxResult.No:
                    BTN_No.Content = $"{NoButtonText} ({(Timeout / 1000) - startTimeout.Elapsed.Seconds})";
                    break;
            }
        }

        private void Button_Yes_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            Close();
        }
        private void Button_No_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            Close();
        }
    }
}
