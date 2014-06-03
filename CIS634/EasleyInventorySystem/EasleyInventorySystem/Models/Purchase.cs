using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace EasleyInventorySystem.Models
{
    public class Purchase
    {
        //Define our Purchase Table
        [Key]
        [Required]
        public virtual Guid TransactionID { get; set; } // GUID, Auto generated

        [Display(Name="Purchase Date")]
        public virtual DateTime PurchaseDate { get; set; } // Date of purchase

        [Display(Name = "Place of Purchase")]
        [StringLength(100)]
        public virtual String PurchaseLocation { get; set; } // Where was the asset purchased?

        [Display(Name = "Price paid for item")]
        //[Range(100.00,99999.99, ErrorMessage="Assets must cost between $100 and under $1 Million to be tracked.")] // This system is designed to track assets from $100 to just under $1Million. Assets of the +1mil should not be tracked here
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:c}")] // Format as a currency
        public virtual Double PurchasePrice { get; set; } // How much was the item purchased for?
    }
}