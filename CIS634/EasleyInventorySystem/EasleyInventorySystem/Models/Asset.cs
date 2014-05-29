using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;



namespace EasleyInventorySystem.Models
{
    public class Asset
    {
        // Define our Asset table

        [Key]
        public virtual Guid AssestID { get; set; }  //GUID, Auto generated
        public virtual String AssetName { get; set; } // Short Name: Downstairs Television
        public virtual Purchase Purchase { get; set; } // Link to the actual purchase
        public virtual String ImageUrl { get; set; } // URL to a picture of this asset

    }

}