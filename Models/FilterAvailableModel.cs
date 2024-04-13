using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class FilterAvailableModel
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("values")]
        public List<FilterAvailableValueModel> Values { get; set; }

        
    }
}
