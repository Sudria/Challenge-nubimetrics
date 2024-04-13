using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SudriaGonzalo.Models
{


    public class SearchModel
    {

        [JsonProperty("site_id")]
        public string Site_id { get; set; }

        [JsonProperty("country_default_time_zone")]
        public string Country_default_time_zone { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("paging")]
        public PagingModel Paging { get; set; }

        [JsonProperty("results")]
        public List<ResultModel> Results { get; set; }

        [JsonProperty("sort")]
        public SortModel Sort { get; set; }

        [JsonProperty("available_sorts")]
        public List<SortModel> AvailableSorts { get; set; }

        [JsonProperty("filters")]
        public List<FilterModel> Filters { get; set; }

        [JsonProperty("available_filters")]
        public List<FilterAvailableModel> AvailableFilters { get; set; }

        [JsonProperty("pdp_tracking")]
        public PdpTrackingModel PdpTracking { get; set; }



    }
}
