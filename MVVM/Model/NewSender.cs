using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class NewSender
    {
        public string? ApiKey { get; set; }
        public string? EmailAddress { get; set; }
    }
}
