using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    public class ItemMedia
    {
        public List<asset> assets
        {
            get;set;
        }

    }

    public class asset
    {
        public string key
        {
            get;set;
        }

        public string value
        {
            get; set;
        }
    }
}
