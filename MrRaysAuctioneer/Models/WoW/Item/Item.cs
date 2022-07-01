using MrRaysAuctioneer.Models.WoW.Common;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    [DataContract]
    public class Item
    {       

        /// <summary>
        ///   Gets or sets the Item id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the Item Level
        /// </summary>
        [JsonPropertyName("level")]
        public long Level
        {
            get;
            set;
        }


        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [JsonPropertyName("item_subclass")]
        public SubClass ItemSubclass
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [JsonPropertyName("item_class")]
        public SubClass ItemClass
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [JsonPropertyName("quality")]
        public SubClass Quality
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [JsonPropertyName("name")]
        public LocalizationValue Name
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the Item Level
        /// </summary>
        [JsonPropertyName("required_level")]
        public long RequiredLevel
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the Kaufpreis
        /// </summary>
        [JsonPropertyName("sell_price")]
        public long SellPrice
        {
            get;
            set;
        }


        /// <summary>
        ///   Gets or sets the Verkauspreis
        /// </summary>
        [JsonPropertyName("purchase_price")]
        public long PurchasePrice
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the Stapelbar    
        /// </summary>
        [JsonPropertyName("is_stackable")]
        public bool IsStackable
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the anlegbar    
        /// </summary>
        [JsonPropertyName("is_equippable")]
        public bool IsEquippable
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the Einkaufsmenge
        /// </summary>
        [JsonPropertyName("purchase_quantity")]
        public int PurchaseQuantity
        {
            get;
            set;
        }

    }
}
