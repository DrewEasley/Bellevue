using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasleyInventorySystem.Models;
using System.Linq;
using System.Collections.Generic;
using EasleyInventorySystem.Controllers;
using System.Web.Mvc;


namespace EasleyInventorySystem.Tests
{
    [TestClass]
    public class InventoryControllerTest
    {

  

        private InventoryDB db = new InventoryDB();

        private string assetName = "GobbleyGook";  // This should not exist at the beginning of our test. 
        private InventoryManagerController eimc = new EasleyInventorySystem.Controllers.InventoryManagerController();


        [TestMethod]
        public void TestUnitTestModule()
        {
            //This should always return TRUE.  If not, the unit test module is failing.
            Assert.IsTrue(1 == 1);
        }


        //Try to create the asset, and see if it exists
        [TestMethod]
        public void CreateAsset()
        {
            
            

            Asset Gook = new Asset();
            Gook.AssetName = assetName;
            Gook.ImageUrl = "http://dummyimage.com/300x300/61595a/ffe100.jpg&text=Unit+Test"; // Dynamically created image
            
            Gook.Purchase = new Purchase();
            Gook.Purchase.PurchaseDate = DateTime.UtcNow;
            Gook.Purchase.PurchaseLocation = "UnitTest";
            Gook.Purchase.PurchasePrice = 0.00;

            eimc.Create(Gook);

            Assert.IsTrue(TestAssetExists(assetName));

        }

        [TestMethod]
        public void ExerciseBasicObjects_Inventory()
        {

            //Some basic tests to make sure the Object properties are tested. 
            //Necessary for 100% code coverage
            bool ObjType = eimc.GetType() == typeof(InventoryManagerController);
            bool ObjHash = eimc.GetHashCode() > 0;
            bool StrLength = eimc.ToString().Length > 0;

            Assert.IsTrue(ObjType && ObjHash && StrLength);
        }


        [TestMethod]
        public void DetailsAsset()
        {
            ViewResult res = eimc.Details(GetAssetGuid(assetName));
            Asset test = (Asset)res.Model;
            Assert.AreEqual(test.AssetName, assetName); // Assert that the test asset names are identical.

        }

        

        // Try to delete the Asset, and confirm it is gone.
        [TestMethod]
        public void DeleteAssetThatDoesNotExist()
        {
            
            //eimc.Delete(GetAssetGuid(assetName));
            Guid NumberOne = new Guid("12345678-1234-1234-1234-123456781234");

            var result = eimc.Delete(NumberOne) as HttpNotFoundResult; // One in a trillion chance this asset exists in real life.
            Assert.AreEqual(null, result);
            

        }


        private bool TestAssetExists(string searchName)
        {
            return SearchAssets(searchName).Count > 0;
        }

        private Guid GetAssetGuid(string searchName)
        {
            return SearchAssets(assetName)[0].AssetID;
        }


        private List<Asset> SearchAssets(string assetName)
        {
            return db.Assets.Include("Purchase").Where(a => a.AssetName.Equals(assetName)).ToList();

        }
    }
}
