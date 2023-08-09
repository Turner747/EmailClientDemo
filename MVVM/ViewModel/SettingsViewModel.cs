using System.Windows.Media;
using WpfNavigationDemo.Clients;
using WpfNavigationDemo.Core;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.MVVM.ViewModel
{
    public class SettingsViewModel : Core.ViewModel
    {
        public string? ApiKey { get; set; }
        public string? EmailAddress 
        { 
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged();
            }
        }

        public string? OutputMessage 
        {
            get => outputMessage;
            set
            {
                outputMessage = value;
                OnPropertyChanged();
            }
        }
        private string outputMessage;

        public Brush OutputColour
        {
            get => outputColour;
            set
            {
                outputColour = value;
                OnPropertyChanged();
            }
        }
        private Brush outputColour;

        private INavigationService _navigation;
        private string? _emailAddress;
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

            SaveSettingsCommand = new RelayCommand(SaveSettings, CanSaveSettings);
        }

        private bool CanSaveSettings(object obj)
        {
            return true;
        }

        private async void SaveSettings(object obj)
        {
            if (EmailAddress == null || EmailAddress.Equals(""))
            {
                // todo: add regex validation
                OutputMessage = $"Please enter an email address";
                OutputColour = Brushes.Red;
                return;
            }

            if (ApiKey != null && !ApiKey.Equals(""))
                _emailClient.ApiKey = ApiKey;

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
                OutputMessage = $"Email saved as sender.";
                OutputColour = Brushes.Green;
                return;
            }
            
            var response = await _emailClient.AddSenderEmail(EmailAddress);

            if (response?.Data == null)
            {
                _emailClient.SenderEmail = EmailAddress;
                OutputMessage = $"Email added successfully. ID: {response?.RequestId}";
                OutputColour = Brushes.Green;
            }
            else
            {
                OutputMessage = $"Email failed to add. Error: {response?.Data?.Error}";
                OutputColour = Brushes.Red;
            }
        }
    }
}
