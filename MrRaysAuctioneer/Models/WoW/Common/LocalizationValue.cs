using MrRaysAuctioneer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW.Common
{
    public class LocalizationValue : Dictionary<string, string>
    {

        public string Current
        {
            get
            {
                if (this != null)
                    return this[LocalizationHelper.GetWoWCultureInfo()];
                else
                    return "OhOh";
            }
        }
        
    }
}
