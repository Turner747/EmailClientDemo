using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using WpfNavigationDemo.MVVM.Model;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.Clients
{
    public interface IEmailClient
    {
        string SenderEmail { get; set; }
        string ApiKey { get; set; }

        Task<Response<EmailResult>> SendEmail(Email email);
        Task<Response<ErrorData>> AddSenderEmail(string email);
        Task<Response<SendersList>> GetSenderEmails();
    }

    public class Smtp2GoClient : IEmailClient
    {
        public string SenderEmail { get; set; }
        public string ApiKey { get; set; }
        
        private readonly RestClient _client;

        public Smtp2GoClient(Secrets secrets)
        {
            ApiKey = secrets.ApiKey;

            var options = new RestClientOptions(@"https://api.smtp2go.com/v3/");

            _client = new RestClient(options);
        }

        public async Task<Response<ErrorData>> AddSenderEmail(string email)
        {
            var sender = new NewSender
            {
                ApiKey = ApiKey,
                EmailAddress = email
            };

            var request = new RestRequest(@"single_sender_emails/add");

            var json = JsonConvert.SerializeObject(sender, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            request.AddJsonBody(json);

            RestResponse response = null;
            try
            {
                response = await _client.PostAsync(request);
            }
            catch (Exception ex)
            {
                return new Response<ErrorData>
                {
                    ErrorMessage = ex.Message
                };
            }

            return JsonConvert.DeserializeObject<Response<ErrorData>>(response.Content, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public async Task<Response<EmailResult>> SendEmail(Email email)
        {
            email.ApiKey = ApiKey;
            email.Sender = SenderEmail;
            email.Version = 1;

            var request = new RestRequest(@"email/send");

            var json = JsonConvert.SerializeObject(email, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            request.AddJsonBody(json);

            RestResponse response = null;
            try
            {
                response = await _client.PostAsync(request);
            }
            catch (Exception ex)
            {
                return new Response<EmailResult>
                {
                    ErrorMessage = ex.Message
                };
            }

            return JsonConvert.DeserializeObject<Response<EmailResult>>(response.Content);
        }

        public async Task<Response<SendersList>> GetSenderEmails()
        {
            var basic = new BasicRequest
            {
                ApiKey = ApiKey
            };
            
            var request = new RestRequest(@"single_sender_emails/view");

            var json = JsonConvert.SerializeObject(basic, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            request.AddJsonBody(json);

            RestResponse response = null;
            try
            {
                response = await _client.PostAsync(request);
            }
            catch (Exception ex)
            {
                return new Response<SendersList>
                {
                    ErrorMessage = ex.Message
                };
            }

            return JsonConvert.DeserializeObject<Response<SendersList>>(response.Content);
        }
    }
}