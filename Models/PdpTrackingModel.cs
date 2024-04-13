using Newtonsoft.Json;

namespace SudriaGonzalo.Models
{
    public class PdpTrackingModel
    {
        [JsonProperty("group")]
        public bool Group { get; set; }

        [JsonProperty("product_info")]
        public List<ProductInfoModel> ProductInfos { get; set; }
    }
}
