using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



namespace EasleyInventorySystem.Models
{
    public class Asset : IValidatableObject
    {
        // Define our Asset table

        [Key]
        public  virtual Guid AssestID { get; set; }  //GUID, Auto generated

        [Display(Name="Item Name")]
        public virtual String AssetName { get; set; } // Short Name: Downstairs Television
        public virtual Purchase Purchase { get; set; } // Link to the actual purchase

        [Display(Name="Picture")]
        public virtual String ImageUrl { get; set; } // URL to a picture of this asset

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Purchase == null)
            {
                yield return new ValidationResult("A Purchase class was not instantiated.", new[] {"Purchase"});
            }

            if (Purchase.PurchaseDate == null)
            {
                yield return new ValidationResult("The purchase date/time is incorrect.", new[] { "Purchase.PurchaseDate" });
            }
        }
        

    }

}