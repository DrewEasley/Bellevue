using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Web.Security;

namespace EasleyInventorySystem.Models
{
    public class DemoDB : DropCreateDatabaseAlways<InventoryDB>
    {


        protected override void Seed(InventoryDB context)
        {
            //Define how many random assets you want to create
            int numPurchasesToCreate = 10;

            for (int i = 1; i <= numPurchasesToCreate; i++)
            {
                context.Assets.Add(CreateRandomizedAsset(i));
            }

            //CreateUsersAndRoles();

            base.Seed(context);
        }


        private void CreateUsersAndRoles()
        {
            
            
            //Create base roles
            Roles.CreateRole("Administrator");
            

            //Create three test users
            MembershipUser userAdmin = Membership.CreateUser("Administrator", "password");
            userAdmin.IsApproved = true;


            Membership.CreateUser("HomeOwner", "password");
            Membership.CreateUser("Friend", "password");


            //Add test users to test roles
            Roles.AddUsersToRole(new string[]{"Administrator"}, "Administrator");
            Roles.AddUsersToRole(new string[] { "Administrator", "HomeOwner" }, "AssetAdmin");
            Roles.AddUsersToRole(new string[] { "Administrator", "HomeOwner", "Friend" }, "AssetViewer");

            
            
        }

        private static readonly Random rndgen = new Random();


        private Asset CreateRandomizedAsset(int i)
        {
            Asset mAsset = new Asset();
            mAsset.AssetID = Guid.NewGuid(); //Auto generated key value

            
            mAsset.AssetName = "Asset #" + i.ToString(); // Name in form of Asset #105
            mAsset.ImageUrl = "http://lorempixel.com/300/300/technics/" + i.ToString() ; // URL to our image creation service! Using the ?A parameter, we can keep the browswers cache happy.
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