using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW
{
    [DataContract]
    public class Auction
    {
        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [JsonPropertyName("id")]
        public long AuctionId
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [JsonPropertyName("item")]
        public AuctionItem Item
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the bid value in copper
        /// </summary>
        [JsonPropertyName("bid")]
        public long CurrentBidValue
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the buyout value in copper
        /// </summary>
        [JsonPropertyName("buyout")]
        public long? BuyoutValue
        {
            get;
            set;
        }


        /// <summary>
        ///   gets or sets the unit price value in copper
        /// </summary>
        [JsonPropertyName("unit_price")]
        public long? UnitPrice
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the time left for the auction to expire
        /// </summary>
        [JsonPropertyName("time_Left")]
        public string TimeLeft
        {
            get;
            set;
        }
    }

}
