using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WpfNavigationDemo.MVVM.Model
{
    public class Attachment
    {
        [JsonProperty("filename")]
        public string? FileName { get; set; }
        [JsonProperty("fileblob")]
        public string? FileBlob { get; set; }
        [JsonProperty("mimetype")]
        public string? MimeType { get; set; }
    }
}
