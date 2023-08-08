using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendersList
    {
        public List<Sender> Senders { get; set; }
    }
}
