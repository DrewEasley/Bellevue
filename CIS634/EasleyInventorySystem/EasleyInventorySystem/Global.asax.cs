﻿using System;
//using System.Collections.Generic; // Unused
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
// using System.Web; //Unused
using System.Web.Mvc;
using System.Web.Routing;
using EasleyInventorySystem.Models;

namespace EasleyInventorySystem
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "help",
                url: "GettingStarted/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "About",
                    id = UrlParameter.Optional
                }
    );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            //Moved to DemoDatabaseController/Create
            //Initialize our application with some fake data
            //Database.SetInitializer(new DropCreateDatabaseAlways<InventoryDB>());  

            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }


    }
}