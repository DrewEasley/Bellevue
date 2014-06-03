using System;
//using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
//using System.Web;
using System.Web.Mvc;
using EasleyInventorySystem.Models;

namespace EasleyInventorySystem.Controllers
{ 
    [Authorize] // Everybody past this point requires some level of authentication.
    public class InventoryManagerController : Controller
    {
        private InventoryDB db = new InventoryDB();
        private int PageSize = 10; //Define PageSize as a variable so we can customize it in web.config later

        //
        // GET: /InventoryManager/

        public ViewResult Index()
        {
            return View(db.Assets.ToList());
        }

        //
        // GET: /InventoryManager/Details/5

        [Authorize(Roles="Administrator,AssetAdmin,AssetViewer")]
        public ViewResult Details(Guid id)
        {
            Asset asset = db.Assets.Find(id);
            return View(asset);
        }

        //
        // GET: /InventoryManager/Create

        [Authorize(Roles="Administrator,AssetAdmin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /InventoryManager/Create


        [Authorize(Roles = "Administrator,AssetAdmin")]
        [HttpPost]
        public ActionResult Create(Asset asset)
        {
            if (ModelState.IsValid)
            {
                asset.AssetID = Guid.NewGuid();
                db.Assets.Add(asset);
                //db.SaveChanges();
                db.SafeSave();
                return RedirectToAction("Index");  
            }

            return View(asset);
        }
        
        //
        // GET: /InventoryManager/Edit/5


        [Authorize(Roles = "Administrator,AssetAdmin")]
        public ActionResult Edit(Guid id)
        {
            Asset asset = db.Assets.Find(id);
            return View(asset);
        }

        //
        // POST: /InventoryManager/Edit/5

        [HttpPost]
        [Authorize(Roles = "Administrator,AssetAdmin")]
        public ActionResult Edit(Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asset);
        }

        // GET: /InventoryManager/Search

        public ActionResult Search(string q)
        {
            var assets = db.Assets.Include("Purchase")
                .Where(a => a.AssetName.Contains(q) || q==null || a.Purchase.PurchaseLocation.Contains(q))
                .Take(PageSize);

            return View(assets); //Call our view with the loaded asset page.
        }

        //
        // GET: /InventoryManager/Delete/5

        [Authorize(Roles = "Administrator,AssetAdmin")]
        public ActionResult Delete(Guid id)
        {
            Asset asset = db.Assets.Find(id);
            return View(asset);
        }

        //
        // POST: /InventoryManager/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator,AssetAdmin")]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}