﻿using PlanYourEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanYourEvent.Controllers
{

    public class HomeController : Controller
    {
        //connect db

        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Events()
        { 
            //use the eventtype model to retrieve the entire event list
            var events = db.Eventtypes.ToList();
            return View(events);
        }
    }
}