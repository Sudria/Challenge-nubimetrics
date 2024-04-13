using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class PagingModel
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("primary_results")]
        public string Primary_results { get; set; }

        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set;}
    }
}
