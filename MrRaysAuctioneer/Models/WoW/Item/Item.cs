using MrRaysAuctioneer.Models.WoW.Common;
using System.Runtime.Serialization;

namespace MrRaysAuctioneer.Models.WoW.Item
{
    [DataContract]
    public class Item
    {       

        /// <summary>
        ///   Gets or sets the Item id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public long Id
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the Item Level
        /// </summary>
        [DataMember(Name = "level", IsRequired = false)]
        public long Level
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "item_subclass", IsRequired = false)]
        public SubClass ItemSubclass
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "item_class", IsRequired = false)]
        public SubClass ItemClass
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "quality", IsRequired = false)]
        public SubClass Quality
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the auction id
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public LocalizationValue Name
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the Item Level
        /// </summary>
        [DataMember(Name = "required_level", IsRequired = false)]
        public long RequiredLevel
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the Kaufpreis
        /// </summary>
        [DataMember(Name = "sell_price", IsRequired = false)]
        public long SellPrice
        {
            get;
            internal set;
        }


        /// <summary>
        ///   Gets or sets the Verkauspreis
        /// </summary>
        [DataMember(Name = "purchase_price", IsRequired = false)]
        public long PurchasePrice
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the Stapelbar    
        /// </summary>
        [DataMember(Name = "is_stackable", IsRequired = false)]
        public bool IsStackable
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the anlegbar    
        /// </summary>
        [DataMember(Name = "is_equippable", IsRequired = false)]
        public bool IsEquippable
        {
            get;
            internal set;
        }

        /// <summary>
        ///   Gets or sets the Einkaufsmenge
        /// </summary>
        [DataMember(Name = "purchase_quantity", IsRequired = false)]
        public bool PurchaseQuantity
        {
            get;
            internal set;
        }

    }
}
