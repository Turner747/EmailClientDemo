using Microsoft.Extensions.Configuration;
using System.IO;

namespace WpfNavigationDemo.Services
{
    public class Secrets
    {
        public string ApiKey { get; set; }

        public Secrets()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<Secrets>().Build();

            ApiKey = builder.GetSection("Smtp2Go:ApiKey").Value;
        }
    }
}
