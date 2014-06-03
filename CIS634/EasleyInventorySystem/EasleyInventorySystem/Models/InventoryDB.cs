using System;
using System.Data.Entity;


namespace EasleyInventorySystem.Models
{
    public class InventoryDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<EasleyInventorySystem.Models.InventoryDB>());

        public InventoryDB() : base("name=InventoryDB")
        {
        }

        public int SafeSave()
        {
            try{
                return base.SaveChanges();
            }

            catch (Exception ex)
            {
                //This will be replaced with a better error handler in the future.
                //Perhaps using jQuery UI's "Dialog" Window
                throw ex;
            }
            
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
