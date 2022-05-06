using System.ComponentModel.DataAnnotations;

namespace MrRaysAuctioneer.Models.WoW.Common
{
    public enum Region
    {
        [Display(Name = "North America")]
        US,
        [Display(Name = "Europe")]
        EU,
        [Display(Name = "Korea")]
        KR,
        [Display(Name = "Taiwan")]
        TW,
        [Display(Name = "China")]
        CN
    }
}
