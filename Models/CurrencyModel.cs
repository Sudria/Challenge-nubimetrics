using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class CurrencyModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("decimal_places")]
        public int DecimalPlaces { get; set; }

        public CurrencyConverterModel Todolar {  get; set; }
    }
}
