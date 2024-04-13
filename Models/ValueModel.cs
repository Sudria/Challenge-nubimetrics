using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class ValueModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path_from_root")]
        public List<PathFromRootModel>? PathFromRoot { get; set; }

        [JsonProperty("restuls")]
        public int? results;
    }
}
