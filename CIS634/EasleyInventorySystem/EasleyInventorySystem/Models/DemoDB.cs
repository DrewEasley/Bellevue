using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;


namespace EasleyInventorySystem.Models
{
    public class DemoDB : DropCreateDatabaseAlways<InventoryDB>
    {


        protected override void Seed(InventoryDB context)
        {
            //Define how many random assets you want to create
            int numPurchasesToCreate = 50;

            for (int i = 1; i <= numPurchasesToCreate; i++)
            {
                context.Assets.Add(CreateRandomizedAsset(i));
            }
            

            base.Seed(context);
        }


        private static readonly Random rndgen = new Random();


        private Asset CreateRandomizedAsset(int i)
        {
            Asset mAsset = new Asset();
            mAsset.AssestID = Guid.NewGuid(); //Auto generated key value

            //Thanks to the Adjective - Noun dataset
            //http://ilexir.co.uk/applications/adjective%E2%80%93noun-dataset/
            mAsset.AssetName = "Asset #" + i.ToString(); // Name in form of Asset #105
            mAsset.ImageUrl = "images/FakeAsset" + i.ToString() + ".png"; //URL in form of images/FakeAsset1.png
            mAsset.Purchase = CreateRandomizedPurchase();
            return mAsset;
        }

        private Purchase CreateRandomizedPurchase()
        {

            Double randomNumberOfDays = rndgen.NextDouble()*1000; // Random number between 0.0 and 1000.0
            randomNumberOfDays = randomNumberOfDays % 365;   // MOD 365 to get a number of days between 0.0 and 365.0
            
            //A few places we buy things
            List<String> placesList = new List<string>();
            placesList.Add("Sears");
            placesList.Add("Best Buy");
            placesList.Add("Target");
            placesList.Add("Amazon");
            placesList.Add("Eclectic Garden");

            //Sometime between right now, and one year ago...
            DateTime purchaseTime = DateTime.UtcNow.AddDays(randomNumberOfDays * -1.0);

            //Add it all to the Purchase class
            Purchase mPurchase = new Purchase();
            mPurchase.PurchaseDate = purchaseTime;
            mPurchase.PurchaseLocation = placesList[rndgen.Next(0, placesList.Count)];
            mPurchase.PurchasePrice = rndgen.NextDouble() * 1000;
            mPurchase.TransactionID = Guid.NewGuid();

            return mPurchase;
        }
    }
}