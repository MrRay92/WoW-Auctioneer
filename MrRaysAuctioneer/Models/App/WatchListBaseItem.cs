using MrRaysAuctioneer.Extension;
using MrRaysAuctioneer.Models.WoW.Common;
using MrRaysAuctioneer.Models.WoW.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.App
{
    public class WatchListBaseItem
    {

        public WatchListBaseItem()
        {
        }
        public WatchListBaseItem(Item item)
        {
            this.ItemId = item.Id;
            this.Name = item.Name;
            this.PurchasePrice = item.PurchasePrice;
            this.SellPrice = item.SellPrice;
        }

        public long ItemId
        {
            get; set;
        }

        public string Image
        {
            get; set;
        }

        public LocalizationValue Name
        {
            get; set;
        }

        public bool SoldByNPC
        {
            get; set;
        }

        public long AuctionPrice
        {
            get; set;
        }

        [JsonIgnore]
        public string AuctionPriceDisplay
        {
            get
            {
                return AuctionPrice.AsWoWPrice();
            }                 
        }

        public long PurchasePrice
        {
            get; set;
        }

        [JsonIgnore]
        public string PurchasePriceDisplay
        {
            get
            {
                return PurchasePrice.AsWoWPrice();
            }

        }

        public long Price
        {
            get
            {
                if (SoldByNPC)
                    return PurchasePrice;
                else
                    return AuctionPrice;
            }
        }

        [JsonIgnore]
        public string PriceDisplay
        {
            get
            {
                return Price.AsWoWPrice();
            }

        }

        public long SellPrice
        {
            get; set;
        }

        [JsonIgnore]
        public string SellPriceDisplay
        {
            get
            {
                return SellPrice.AsWoWPrice();
            }
        }

    }
}
