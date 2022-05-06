using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Helper
{
    public class LanguageHelper
    {
        public static List<CultureInfo> GetAvailableLanguages()
        {
            List<CultureInfo> availableLanguages = new();

            //TODO find better way
            availableLanguages.Add(new CultureInfo("de-DE"));
            availableLanguages.Add(new CultureInfo("en-US"));

            return availableLanguages;
        }

        public static void ChangCurrentLanguage(CultureInfo cultureInfo)
        {
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            CultureInfo.CurrentCulture = cultureInfo;
            Properties.Resources.Culture = cultureInfo;
        }
    }
}
