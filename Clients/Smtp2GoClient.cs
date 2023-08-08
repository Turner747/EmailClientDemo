using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using WpfNavigationDemo.MVVM.Model;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.Clients
{
    public interface IEmailClient
    {
        string SenderEmail { get; set; }

        Task<Response<EmailResult>> SendEmail(Email email);
        Task<Response<ErrorData>> AddSenderEmail(string email);
        Task<Response<SendersList>> GetSenderEmails();
    }

    public class Smtp2GoClient : IEmailClient
    {
        public string SenderEmail { get; set; }
        
        private readonly string _apiKey;
        private readonly RestClient _client;

        public Smtp2GoClient(Secrets secrets)
        {
            _apiKey = secrets.ApiKey;

            var options = new RestClientOptions(@"https://api.smtp2go.com/v3/");

            _client = new RestClient(options);
        }

        public async Task<Response<ErrorData>> AddSenderEmail(string email)
        {
            var sender = new NewSender
            {
                ApiKey = _apiKey,
                EmailAddress = email
            };

            var request = new RestRequest(@"single_sender_emails/add");

            var json = JsonConvert.SerializeObject(sender, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            request.AddJsonBody(json);

            var response =  await _client.PostAsync(request);

            return JsonConvert.DeserializeObject<Response<ErrorData>>(response.Content, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public async Task<Response<EmailResult>> SendEmail(Email email)
        {
            email.ApiKey = _apiKey;
            email.Sender = SenderEmail;
            email.Version = 1;

            var request = new RestRequest(@"email/send");

            var json = JsonConvert.SerializeObject(email, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            request.AddJsonBody(json);

            var response = await _client.PostAsync(request);

            return JsonConvert.DeserializeObject<Response<EmailResult>>(response.Content);
        }

        public async Task<Response<SendersList>> GetSenderEmails()
        {
            var basic = new BasicRequest
            {
                ApiKey = _apiKey
            };
            
            var request = new RestRequest(@"single_sender_emails/view");

            var json = JsonConvert.SerializeObject(basic, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            request.AddJsonBody(json);

            var response = await _client.PostAsync(request);

            return JsonConvert.DeserializeObject<Response<SendersList>>(response.Content);
        }
    }
}
