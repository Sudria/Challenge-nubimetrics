using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class SortModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
