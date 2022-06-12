using Newtonsoft.Json;

namespace TextFilter.Models
{
    public class PersonalSettings
    {
        [JsonProperty("File")]
        public string File { get; set; }
    }
}