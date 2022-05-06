using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW
{
    [DataContract]
    public class Auction
    {
        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public long AuctionId
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "item", IsRequired = true)]
        public AuctionItem Item
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the bid value in copper
        /// </summary>
        [DataMember(Name = "bid", IsRequired = false)]
        public long CurrentBidValue
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the buyout value in copper
        /// </summary>
        [DataMember(Name = "buyout", IsRequired = false)]
        public long? BuyoutValue
        {
            get;
            internal set;
        }


        /// <summary>
        ///   gets or sets the unit price value in copper
        /// </summary>
        [DataMember(Name = "unit_price", IsRequired = false)]
        public long? UnitPrice
        {
            get;
            internal set;
        }

        /// <summary>
        ///   gets or sets the quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the time left for the auction to expire
        /// </summary>
        [DataMember(Name = "time_Left", IsRequired = false)]
        public string TimeLeft
        {
            get;
            internal set;
        }
    }

}
