using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ResponseData
    {
        // properties for success
        public int Succeeded { get; set; }
        public int failed { get; set; }
        public List<string>? Failures { get; set; }
        public string? EmailId { get; set; }

        // properties for failure
        public string? Error { get; set; }
        public string? ErrorCode { get; set; }
    }
}
