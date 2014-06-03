using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasleyInventorySystem.Models;
using System.Linq;
using System.Collections.Generic;
using EasleyInventorySystem.Controllers;
using System.Web.Mvc;
using System.Web.Providers;


namespace EasleyInventorySystem.Tests.Controllers
{

    [TestClass]
    public class AccountControllerTest
    {

        private EasleyInventorySystem.Controllers.AccountController actController = new AccountController();

        [TestMethod]
        public void ExerciseBasicObjects_AccountController()
        {

            //Some basic tests to make sure the Object properties are tested. 
            //Necessary for 100% code coverage
            bool ObjType = actController.GetType() == typeof(AccountController);
            bool ObjHash = actController.GetHashCode() > 0;
            bool StrLength = actController.ToString().Length > 0;

            Assert.IsTrue(ObjType && ObjHash && StrLength);
        }

        [TestMethod]
        public void LogOnPageExists()
        {
            Assert.IsTrue(actController.LogOn() != null);

        }

    

        [TestMethod]
        public void RegisterPageExists()
        {
            Assert.IsTrue(actController.Register() != null);
        }
    }
}
