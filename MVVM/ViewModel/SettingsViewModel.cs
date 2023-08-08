using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfNavigationDemo.Clients;
using WpfNavigationDemo.Core;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.MVVM.ViewModel
{
    public class SettingsViewModel : Core.ViewModel
    {
        public string? EmailAddress { get; set; }

        private INavigationService _navigation;
        private readonly IEmailClient _emailClient;

        public RelayCommand SaveSettingsCommand { get; set; }

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel(INavigationService navigation, IEmailClient email)
        {
            Navigation = navigation;
            _emailClient = email;

            SaveSettingsCommand = new RelayCommand(SaveSetting, o => { return true; });
        }

        private async void SaveSetting(object obj)
        {
            var senderList = await _emailClient.GetSenderEmails();

            bool senderExists = false;
            foreach(var s in senderList.Data.Senders)
            {
                if (s.EmailAddress == EmailAddress)
                {
                    senderExists = true;
                    break;
                }
            }

            if (senderExists)
            {
                _emailClient.SenderEmail = EmailAddress;
                MessageBox.Show($"Email saved as sender.");
                return;
            }
            
            var response = await _emailClient.AddSenderEmail(EmailAddress);

            if (response?.Data == null)
            {
                _emailClient.SenderEmail = EmailAddress;
                MessageBox.Show($"Email added successfully. ID: {response?.RequestId}");
            }
            else
            {
                MessageBox.Show($"Email failed to add. Error: {response?.Data?.Error}");
            }
        }
    }
}
