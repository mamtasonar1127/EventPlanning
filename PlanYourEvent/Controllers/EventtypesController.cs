using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlanYourEvent.Models;

namespace PlanYourEvent.Controllers
{
    [Authorize]
    public class EventtypesController : Controller
    {
        IMockEventtypes db;
        // private DbModel db = new DbModel();
        //Constructor

        public EventtypesController()
        {
            this.db = new IDataEventtypes();
        }

        public EventtypesController(IDataEventtypes mockDb)
        {
            this.db = mockDb;
        }


        [AllowAnonymous]
        // GET: Eventtypes
        public ActionResult Index()
        {
            return View(db.Eventtypes.OrderBy(c => c.Event_Name).ToList());
        }

        [AllowAnonymous]
        // GET: Eventtypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Eventtype eventtype = db.Eventtypes.Find(id);
            Eventtype eventtype = db.eventtypes.SingleOrDefault(c => c.Event_Id == id);
            
            if (eventtype == null)
            {
                return HttpNotFound();
            }
            return View(eventtype);
        }

        
        // GET: Eventtypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventtypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_Id,Event_Name,Description,Photo")] Eventtype eventtype)
        {
            if (ModelState.IsValid)
            {
                //db.Eventtypes.Add(eventtype);
                //db.SaveChanges();
                db.Save(eventtype);
                return RedirectToAction("Index");
            }

            return View(eventtype);
        }

        // GET: Eventtypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Eventtype eventtype = db.Eventtypes.Find(id);
            Eventtype eventtype = db.eventtypes.SingleOrDefault(c => c.Event_Id == id);
            if (eventtype == null)
            {
                return HttpNotFound();
            }
            return View(eventtype);
        }

        // POST: Eventtypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_Id,Event_Name,Description,Photo")] Eventtype eventtype)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(eventtype).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(eventtype);
                return RedirectToAction("Index");
            }
            return View(eventtype);
        }

        // GET: Eventtypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Eventtype eventtype = db.Eventtypes.Find(id);
            Eventtype eventtype = db.eventtypes.SingleOrDefault(c => c.Event_Id == id);
            if (eventtype == null)
            {
                return HttpNotFound();
            }
            return View(eventtype);
        }

        // POST: Eventtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Eventtype eventtype = db.Eventtypes.Find(id);
            // Eventtype eventtype = db.Eventtypes.Find(id);
            Eventtype eventtype = db.eventtypes.SingleOrDefault(c => c.Event_Id == id);
            //db.Eventtypes.Remove(eventtype);
            //db.SaveChanges();
            db.Delete(eventtype);
            db.Delete(eventtype);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
