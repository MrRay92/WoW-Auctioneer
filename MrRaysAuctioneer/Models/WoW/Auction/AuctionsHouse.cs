using MrRaysAuctioneer.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW
{
    [DataContract]
    public class AuctionsHouse
    {

        [DataMember(IsRequired = false)]
        public DateTime LastUpdate
        {
            get;set;
        }

        /// <summary>
        ///   Gets or sets the auctions
        /// </summary>
        [DataMember(Name = "auctions", IsRequired = true)]
        public IList<Auction> Auctions
        {
            get;
            internal set;
        }

        #region Functions
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(FileHelper.GetTempPath("AuctionsHouse.json"), json);
        }

        public AuctionsHouse Load()
        {
            if (!File.Exists(FileHelper.GetTempPath("AuctionsHouse.json")))
                return null;

            var json = File.ReadAllText(FileHelper.GetTempPath("AuctionsHouse.json"));
            return JsonConvert.DeserializeObject<AuctionsHouse>(json);
        }
        #endregion
    }
}
