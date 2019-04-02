using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//new references
using System.Web.Mvc;
using PlanYourEvent.Controllers;
using Moq;
using PlanYourEvent.Models;
using System.Linq;
using System.Collections.Generic;

namespace PlanYourEvent.Tests.Controllers
{
    [TestClass]
    public class EventtypeControllerTest
    {
        //moq data
        EventtypesController controller;
        List<Eventtype> eventtype;

        [TestInitialize]

        public void TestInitialize()
        {
            eventtype = new List<Eventtype>
            {
                new Eventtype { Event_Id = 100, Event_Name = "Event type one",Description="fake Description",Photo="fake photo path" },
                new Eventtype { Event_Id = 101, Event_Name = "Event type two",Description="fake Description",Photo="fake photo path" },
                new Eventtype { Event_Id = 102, Event_Name = "Event type three",Description="fake Description",Photo="fake photo path"}

                };
        }


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
