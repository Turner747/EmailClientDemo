using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Response
    {
        public ResponseData? Data { get; set; }
        public string? RequestId { get; set; }
    }
}
