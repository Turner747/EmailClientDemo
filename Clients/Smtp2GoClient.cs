using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using WpfNavigationDemo.MVVM.Model;
using WpfNavigationDemo.Services;

namespace WpfNavigationDemo.Clients
{
    public interface IEmailClient
    {
        Task<bool> SendEmail(Email email);
    }

    public class Smtp2GoClient : IEmailClient
    {
        private readonly string _apiKey;
        private readonly RestClient _client;

        public Smtp2GoClient(ISecrets secrets)
        {
            _apiKey = secrets.ApiKey;

            var options = new RestClientOptions(@"https://api.smtp2go.com/v3/");

            _client = new RestClient(options);
        }

        public async Task<bool> SendEmail(Email email)
        {
            email.ApiKey = _apiKey;
            email.Version = 1;

            var request = new RestRequest(@"email/send");

            var json = JsonConvert.SerializeObject(email, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            request.AddJsonBody(json);

            var response = await _client.PostAsync<Response>(request);

            return response?.Data?.Succeeded == 1;
        }
    }
}
