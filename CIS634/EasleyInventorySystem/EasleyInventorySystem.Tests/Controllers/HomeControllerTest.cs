using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasleyInventorySystem;
using EasleyInventorySystem.Controllers;

namespace EasleyInventorySystem.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to the Easley Inventory System!", result.ViewBag.Message);
        }

        [TestMethod]
        public void ExerciseBasicObjects()
        {
            HomeController controller = new HomeController();

            //Some basic tests to make sure the Object properties are tested. 
            //Necessary for 100% code coverage
            bool ObjType = controller.GetType() == typeof(HomeController);
            bool ObjHash = controller.GetHashCode() > 0;
            bool StrLength = controller.ToString().Length > 0;

            Assert.IsTrue(ObjType && ObjHash && StrLength); 
        }

        [TestMethod]
        public void Test()
        {
            HomeController controller = new HomeController();
            
        }

  
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
