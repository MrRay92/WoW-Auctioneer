﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    public enum ItemQuality
    {
        /// <summary>
        ///   Poor (Grey)
        /// </summary>
        Poor = 0,

        /// <summary>
        ///   Common (White)
        /// </summary>
        Common = 1,

        /// <summary>
        ///   Uncommon (Green)
        /// </summary>
        Uncommon = 2,

        /// <summary>
        ///   Rare (Blue)
        /// </summary>
        Rare = 3,

        /// <summary>
        ///   Epic (Purple)
        /// </summary>
        Epic = 4,

        /// <summary>
        ///   Legendary (Orange)
        /// </summary>
        Legendary = 5,

        /// <summary>
        ///   Artifact (Golden)
        /// </summary>
        Artifact = 6,

        /// <summary>
        ///   Heirloom (Golden)
        /// </summary>
        Heirloom = 7
    }
}
