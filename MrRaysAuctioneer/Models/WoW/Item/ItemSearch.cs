using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    [DataContract]
    public class ItemSearch
    {

        /// <summary>
        ///   Gets or sets the auctions
        /// </summary>
        [JsonPropertyName("results")]
        public IList<Result> Results
        {
            get;
            set;
        }

        [JsonPropertyName("pageSize")]
        public long PageSize { get; set; }

    }
        
    [DataContract]
    public class Result
    {
        /// <summary>
        ///   Gets or sets the Items
        /// </summary>
        [JsonPropertyName("data")]
        public Item Item
        {
            get;
            set;
        }
    }

}
