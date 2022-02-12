using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IpAddressApi.Api.Responses
{
    public record IpAddressResponse
    {
        [JsonPropertyName("ip")]
        public string IpAddress { get; init; }
        [JsonPropertyName("city")]
        public string City { get; init; }
       [JsonPropertyName("region")]
        public string Region { get; init; }
        [JsonPropertyName("country")]
        public string Country { get; init; }
        [JsonPropertyName("loc")]
        public string Location { get; init; }
        [JsonPropertyName("org")]
        public string Organisation { get; init; }
        [JsonPropertyName("postal")]
        public string PostalCode { get; init; }
        [JsonPropertyName("timezone")]
        public string Timezone { get; init; }
        [JsonPropertyName("readme")]
        public string Readme { get; init; }
    }
}
