using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_Learn.Assets.Popups.Views;

namespace WPF_MVVM_Learn.Assets.Popups
{
    public static class CustomPopupSingleButton
    {
        public static MessageBoxResult ShowOK(string title, string messageBoxText, string okButtonText)
        {
            PopupSingleChoice msg = new PopupSingleChoice(title, messageBoxText, okButtonText);

            msg.ShowDialog();
            return msg.Result;
        }
    }

    public static class CustomPopupMultiButton
    {
        public static MessageBoxResult ShowYesNo(string title, string messageBoxText, string yesButtonText, string noButtonText)
        {
            PopupMultiChoice msg = new PopupMultiChoice(title, messageBoxText, yesButtonText, noButtonText);

            msg.ShowDialog();
            return msg.Result;
        }

        public static MessageBoxResult ShowYesNoWithTimeout(string title, string messageBoxText, string yesButtonText, string noButtonText, MessageBoxResult decisionWhenTimeout, int timeout)
        {
            PopupMultiChoice msg = new PopupMultiChoice(title, messageBoxText, yesButtonText, noButtonText,
                decisionWhenTimeout, timeout);

            msg.ShowDialog();
            return msg.Result;
        }
    }
}
