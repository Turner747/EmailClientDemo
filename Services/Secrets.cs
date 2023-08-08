using Microsoft.Extensions.Configuration;
using System.IO;

namespace WpfNavigationDemo.Services
{
    public interface ISecrets
    {
        string ApiKey { get; set; }
    }

    public class Secrets : ISecrets
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
