using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class ProductInfoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
