using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using EasleyInventorySystem.Models;
using System.Web.Security;

namespace EasleyInventorySystem.Controllers
{
    public class HomeController : Controller
    {

        protected string databaseType = "Demo";

        public ActionResult Index()
        {

            


            ViewBag.Message = "Welcome to the Easley Inventory System!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult CreateDatabase()
        {
            return View();
            
            
        }

        public ActionResult ResetApp()
        {
            System.Web.HttpRuntime.UnloadAppDomain();
            return View();
        }


       

        
    }
}
