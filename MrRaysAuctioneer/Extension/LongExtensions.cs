using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Extension
{
    public static class LongExtensions
    {
        public static string AsWoWPrice(this long priceInCopper)
        {
            var copper = priceInCopper % 100;
            priceInCopper -= copper;
            var silver = priceInCopper % 10000;
            priceInCopper -= silver;
            silver /= 100;
            var gold = priceInCopper / 10000;

            string StringPrice = $"{gold}g {silver}s {copper}k";
            return StringPrice;
        }
    }
}
