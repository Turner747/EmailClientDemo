using System;
using WpfNavigationDemo.Core;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }

        private INavigationService _navigation;

        public RelayCommand SendEmailCommand { get; set; }

        public INavigationService Navigation 
        { 
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel(INavigationService navigation)
        {
            Navigation = navigation;

            SendEmailCommand = new RelayCommand(SendEmail, o => { return true; });
        }

        private void SendEmail(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
