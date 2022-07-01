using MrRaysAuctioneer.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW
{
    [DataContract]   
    public class AuctionsHouse
    {
        
        public DateTime LastUpdate
        {
            get;set;
        }

        /// <summary>
        ///   Gets or sets the auctions
        /// </summary>
        [JsonPropertyName("auctions")]
        public IList<Auction> Auctions
        {
            get;
            set;
        }

        #region Functions
        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(FileHelper.GetTempPath("AuctionsHouse.json"), json);
        }

        public AuctionsHouse Load()
        {
            if (!File.Exists(FileHelper.GetTempPath("AuctionsHouse.json")))
                return null;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var json = File.ReadAllText(FileHelper.GetTempPath("AuctionsHouse.json"));
            return JsonSerializer.Deserialize<AuctionsHouse>(json, options);
        }
        #endregion
    }
}
