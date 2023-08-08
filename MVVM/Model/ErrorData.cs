using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ErrorData
    {
        public string? Error { get; set; }
        public string? ErrorCode { get; set; }
    }
}
