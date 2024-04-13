using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class FilterModel
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("values")]
        public List<ValueModel> values { get; set; }

        
    }
}
