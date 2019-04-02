using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//new references
using System.Web.Mvc;
using PlanYourEvent.Controllers;
namespace PlanYourEvent.Tests.Controllers
{
    [TestClass]
    public class EventtypeControllerTest
    {
        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange

            EventtypesController controller = new EventtypesController();

            //act

            ViewResult result = controller.Index() as ViewResult;

            //assert

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
