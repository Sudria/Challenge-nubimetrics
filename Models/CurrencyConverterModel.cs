using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class CurrencyConverterModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("currency_quote")]
        public string CurrencyQuote { get; set; }

        [JsonProperty("ratio")]
        public float Ratio { get; set; }

        [JsonProperty("rate")]
        public float Rate { get; set; }
        
        [JsonProperty("creation_date")]
        public string CreationDate { get; set; }

        [JsonProperty("valid_until")]
        public string ValidUntil { get; set; }


    }
}
