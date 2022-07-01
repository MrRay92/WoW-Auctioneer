using MrRaysAuctioneer.Models.WoW.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.WoW
{
    [DataContract]
    public class AuctionItem
    {
        /// <summary>
        ///   gets or sets the item id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true)]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///   gets or sets the item context
        /// </summary>
        [DataMember(Name = "context", IsRequired = false)]
        public int Context
        {
            get;
            set;
        }

        /// <summary>
        /// Pet species Id (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "pet_species_id", IsRequired = false)]
        public int PetSpeciesId
        {
            get;
            set;
        }

        /// <summary>
        /// Pet breed Id (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "pet_breed_id", IsRequired = false)]
        public int PetBreedId
        {
            get;
            set;
        }

        /// <summary>
        /// Pet level (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "pet_level", IsRequired = false)]
        public int PetLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Pet quality (in case the auctioned item is a battle pet)
        /// </summary>
        [DataMember(Name = "pet_quality_id", IsRequired = false)]
        public ItemQuality PetQuality
        {
            get;
            set;
        }

    }
}
