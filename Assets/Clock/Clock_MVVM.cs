using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WPF_MVVM_Learn.Assets.Clock
{
    internal class Clock_ViewModel : ViewModelBase
    {
        public DispatcherTimer _timer;

        #region Getter & Setter
        private DateTime _currentDate;

        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set {
                if (_currentDate == value)
                    return;
                _currentDate = value;
                OnPropertyChanged("CurrentDate");
            }
        }
        #endregion

        public Clock_ViewModel()
        {
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += (sender, args) =>
            {
                CurrentDate = DateTime.Now;
            };
            _timer.Start();
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
