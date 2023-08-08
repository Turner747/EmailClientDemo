using System.Collections.Generic;
using System.Windows;
using WpfNavigationDemo.Clients;
using WpfNavigationDemo.Core;
using WpfNavigationDemo.MVVM.Model;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {
        public string? EmailAddress { get; set; }
        public string? Subject { get; set; }
        public string? EmailBody { get; set; }

        private INavigationService _navigation;
        private IEmailClient _emailClient;

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

        public HomeViewModel(INavigationService navigation, IEmailClient email)
        {
            Navigation = navigation;
            _emailClient = email;

            SendEmailCommand = new RelayCommand(SendEmail, o => { return true; });
        }

        private async void SendEmail(object obj)
        {
            var email = new Email();
            email.To = new List<string>() { EmailAddress };
            email.Subject = Subject;
            email.TextBody = EmailBody;

            var response = await _emailClient.SendEmail(email);

            if (response?.Data?.Succeeded == 1)
            {
                MessageBox.Show($"Email sent successfully. ID: {response?.Data?.EmailId}");
            }
            else
            {
                MessageBox.Show($"Email failed. Error: {response?.Data?.Error}");
            }
        }
    }
}
