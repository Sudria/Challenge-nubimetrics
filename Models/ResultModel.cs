using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SudriaGonzalo.Models
{
    public class ResultModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("site_id")]
        public string Site_id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("seller")]
        public SellertModel Seller { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

    }
}
