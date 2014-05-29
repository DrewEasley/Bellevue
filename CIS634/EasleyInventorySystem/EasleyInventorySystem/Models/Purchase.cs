using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace EasleyInventorySystem.Models
{
    public class Purchase
    {
        //Define our Purchase Table
        [Key]
        public virtual Guid TransactionID { get; set; } // GUID, Auto generated
        public virtual DateTime PurchaseDate { get; set; } // Date of purchase
        public virtual String PurchaseLocation { get; set; } // Where was the asset purchased?
        public virtual Double PurchasePrice { get; set; } // How much was the item purchased for?
    }
}