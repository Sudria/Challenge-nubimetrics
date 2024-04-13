using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class FilterAvailableValueModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("results")]
        public int results { get; set; }
    }
}
