using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Helper
{
    class LocalizationHelper
    {
        public static CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentCulture;
        }

        public static string GetWoWCultureInfo(CultureInfo cultureInfo = null)
        {
            if (cultureInfo == null)
                cultureInfo = GetCurrentCultureInfo();

            var CultureName = cultureInfo.Name;
            return CultureName.Replace('-', '_');
        }
    }
}
