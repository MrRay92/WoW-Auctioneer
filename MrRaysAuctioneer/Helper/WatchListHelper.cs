using MrRaysAuctioneer.Models.App;
using MrRaysAuctioneer.Models.WoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Helper
{
    public class WatchListHelper
    {

        /// <summary>
        /// Update the WatchList with Auctions House Data
        /// </summary>
        /// <param name="watchList">the WatchList with will be updated</param>
        /// <param name="auctionsHouse">AuctionsHouse if null new data will be loaded</param>
        public static void UpdateWatchListByActions(WatchList watchList, AuctionsHouse auctionsHouse = null)
        {
            if (auctionsHouse is null) 
            { 
                auctionsHouse = new AuctionsHouse();
                auctionsHouse.Load();
            }

            if (auctionsHouse.Auctions == null)
                return;

            foreach (var watchListItem in watchList.Items)
            {
                UpdateItemActionsData(watchListItem, auctionsHouse);
                foreach (var subItem in watchListItem.SubItems)
                    UpdateItemActionsData(subItem, auctionsHouse);
            }
        }

        /// <summary>
        /// Upodates the Item Images in the WatchList
        /// </summary>
        /// <param name="battelNetConnectionHelper">BattelNetConnectionHelper</param>
        /// <param name="watchList">WatchList</param>
        /// <param name="keepExisting">keep Image when there alray is one</param>
        public static void UpdateWatchListImages(BattelNetConnectionHelper battelNetConnectionHelper, WatchList watchList, bool keepExisting)
        {
            foreach (var watchListItem in watchList.Items)
            {
                UpdateItemImage(watchListItem, battelNetConnectionHelper, keepExisting);
                foreach (var subItem in watchListItem.SubItems)
                    UpdateItemImage(subItem, battelNetConnectionHelper, keepExisting);
            }
        }

        /// <summary>
        /// Update Item Image for one WatchList Item 
        /// </summary>
        /// <param name="Item">WatchListBaseItem</param>
        /// <param name="battelNetConnectionHelper">BattelNetConnectionHelper</param>
        /// <param name="keepExisting">keep Image when there alray is one</param>
        private static void UpdateItemImage(WatchListBaseItem Item, BattelNetConnectionHelper battelNetConnectionHelper, bool keepExisting =true)
        {
            if (!string.IsNullOrEmpty(Item.Image) && keepExisting)
                return;

            Item.Image = battelNetConnectionHelper.GetItemImage(Item.ItemId);
        }

        /// <summary>
        /// Update the AuctionsHouse Date for one WatchList Item 
        /// </summary>
        /// <param name="Item">WatchListBaseItem</param>
        /// <param name="auctionsHouse">AuctionsHouse Data</param>
        private static void UpdateItemActionsData(WatchListBaseItem Item, AuctionsHouse auctionsHouse)
        {
            Item.AuctionPrice = 0;

            if (auctionsHouse.Auctions == null)
                return;

            var Auctions = auctionsHouse.Auctions.Where(a => a.Item.Id == Item.ItemId).OrderBy(a => a.BuyoutValue).ThenBy(a=>a.UnitPrice);
            if (!Auctions.Any())
                return;

            var bestAuction = Auctions.First();

            if (bestAuction == null)
                return;

            Item.AuctionPrice = bestAuction.UnitPrice.GetValueOrDefault(0);
        }
    }
}
