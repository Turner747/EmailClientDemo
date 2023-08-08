using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Sender
    {
        public string? EmailAddress { get; set; }
        public bool Verified { get; set; }
    }
}
