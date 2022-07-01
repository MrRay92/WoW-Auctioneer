using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    public class ItemMedia
    {
        [JsonPropertyName("assets")]
        public List<Asset> Assets
        {
            get;set;
        }

    }

    public class Asset
    {
        [JsonPropertyName("key")]
        public string Key
        {
            get;set;
        }

        [JsonPropertyName("value")]
        public string Value
        {
            get; set;
        }
    }
}
