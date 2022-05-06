using MrRaysAuctioneer.Models.WoW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    [DataContract]
    public class SubClass
    {
        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public long Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public LocalizationValue Name
        {
            get;
            internal set;
        }
    }
}
