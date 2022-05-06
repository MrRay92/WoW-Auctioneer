using MrRaysAuctioneer.Models.WoW.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.App
{

    public class WatchListSubItem : WatchListBaseItem
    {

        public WatchListSubItem()
        {
            Quantity = 1;
        }
        public WatchListSubItem(Item item) : base(item)
        {
            Quantity = 1;
        }

        public long Quantity
        {
            get; set;
        }

    }
}
