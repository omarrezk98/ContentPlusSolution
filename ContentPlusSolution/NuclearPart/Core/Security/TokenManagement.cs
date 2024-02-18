using Newtonsoft.Json;

namespace Core.Security
{
    [JsonObject("tokenManagement")]
    public class TokenManagement
    {
        [JsonProperty("secret")]
        public string Secret { get; set; } = default!;

        [JsonProperty("issuer")]
        public string Issuer { get; set; } = default!;

        [JsonProperty("audience")]
        public string Audience { get; set; } = default!;

        [JsonProperty("accessExpiration")]
        public float AccessExpiration { get; set; }

        [JsonProperty("refreshExpiration")]
        public float RefreshExpiration { get; set; }
    }

}

