using MrRaysAuctioneer.Extension;
using MrRaysAuctioneer.Models.WoW;
using MrRaysAuctioneer.Models.WoW.Common;
using MrRaysAuctioneer.Models.WoW.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.App
{
    public class WatchListItem : WatchListBaseItem
    {
        public Guid Id
        {
            get;set;
        }

        public WatchListItem()
        {
            Id = Guid.NewGuid();
            SubItems = new List<WatchListSubItem>();
        }
        public WatchListItem(Item item) : base(item)
        {
            Id = Guid.NewGuid();
            SubItems = new List<WatchListSubItem>();
        }

        public List<WatchListSubItem> SubItems
        {
            get;set;
        }

        public long CraftPrice
        {
            get
            {
                if (this.SubItems is null)
                    return 0;
                return this.SubItems.Sum(i => i.Price * i.Quantity);
            }
        }

        [JsonIgnore]
        public string CraftPriceDisplay
        {
            get
            {
                return CraftPrice.AsWoWPrice();
            }
        }

    }
}
