using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Response<T>
    {
        public T? Data { get; set; }
        public string? RequestId { get; set; }
        [JsonIgnore]
        public string? ErrorMessage { get; set; }
    }
}
