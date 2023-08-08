using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace WpfNavigationDemo.MVVM.Model
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Email
    {
        public string? ApiKey { get; set; }
        public string? Sender { get; set; }
        public List<string>? To { get; set; }
        public List<string>? Cc { get; set; }
        public List<string>? Bcc { get; set; }
        public string? Subject { get; set; }
        public string? HtmlBody { get; set; }
        public string? TextBody { get; set; }
        public string? TemplateId { get; set; }
        public List<KeyValuePair<string, string>>? CustomHeaders { get; set; }
        public List<Attachment>? Attachments { get; set; }
        public List<Attachment>? Inlines { get; set; }
        public int Version { get; set; }
    }
}
