using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    [DataContract]
    public class ItemSearch
    {

        /// <summary>
        ///   Gets or sets the auctions
        /// </summary>
        [DataMember(Name = "results", IsRequired = true)]
        public List<Result> Results
        {
            get;
            internal set;
        }

    }

    [DataContract]
    public class Result
    {
        /// <summary>
        ///   Gets or sets the Items
        /// </summary>
        [DataMember(Name = "data", IsRequired = true)]
        public Item Item
        {
            get;
            internal set;
        }
    }

}
