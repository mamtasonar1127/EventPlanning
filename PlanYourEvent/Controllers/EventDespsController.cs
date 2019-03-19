using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlanYourEvent.Models;

namespace PlanYourEvent.Controllers
{
    [Authorize]
    public class EventDespsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: EventDesps
        public ActionResult Index()
        {
            var eventDesps = db.EventDesps.Include(e => e.Eventtype);
            return View(eventDesps.OrderBy(p => p.Eventtype.Event_Name).ToList());
        }

        // GET: EventDesps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDesp eventDesp = db.EventDesps.Find(id);
            if (eventDesp == null)
            {
                return HttpNotFound();
            }
            return View(eventDesp);
        }

        // GET: EventDesps/Create
        public ActionResult Create()
        {
            ViewBag.Event_Id = new SelectList(db.Eventtypes, "Event_Id", "Event_Name");
            return View();
        }

        // POST: EventDesps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EDId,ED_Name,Description,Price,Photo,Event_Id")] EventDesp eventDesp,String CurrentPhoto)
        {
            if (ModelState.IsValid)
            {
                //check for file upload
                if (Request.Files != null)
                {
                    var file = Request.Files[0];

                    if (file.FileName != null && file.ContentLength > 0)
                    {
                        string fName = Path.GetFileName(file.FileName);

                        string path = Server.MapPath("~/Content/Images/" + fName);
                        file.SaveAs(path);
                        eventDesp.Photo = fName;
                    }
                }
                else
                {
                    //no new upload, keep old photo
                    eventDesp.Photo = CurrentPhoto;
                }

                db.EventDesps.Add(eventDesp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Event_Id = new SelectList(db.Eventtypes, "Event_Id", "Event_Name", eventDesp.Event_Id);
            return View(eventDesp);
        }

        // GET: EventDesps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDesp eventDesp = db.EventDesps.Find(id);
            if (eventDesp == null)
            {
                return HttpNotFound();
            }
            ViewBag.Event_Id = new SelectList(db.Eventtypes, "Event_Id", "Event_Name", eventDesp.Event_Id);
            return View(eventDesp);
        }

        // POST: EventDesps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EDId,ED_Name,Description,Price,Photo,Event_Id")] EventDesp eventDesp,String CurrentPhoto)
        {
            if (ModelState.IsValid)
            {
                //check for file upload
                if (Request.Files != null)
                {
                    var file = Request.Files[0];

                    if (file.FileName != null && file.ContentLength > 0)
                    {
                        string fName = Path.GetFileName(file.FileName);

                        string path = Server.MapPath("~/Content/Images/" + fName);
                        file.SaveAs(path);
                        eventDesp.Photo = fName;
                    }
                }
                else
                {
                    //no new upload, keep old photo
                    eventDesp.Photo = CurrentPhoto;
                }

                db.Entry(eventDesp).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Event_Id = new SelectList(db.Eventtypes, "Event_Id", "Event_Name", eventDesp.Event_Id);
            return View(eventDesp);
        }

        // GET: EventDesps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDesp eventDesp = db.EventDesps.Find(id);
            if (eventDesp == null)
            {
                return HttpNotFound();
            }
            return View(eventDesp);
        }

        // POST: EventDesps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventDesp eventDesp = db.EventDesps.Find(id);
            db.EventDesps.Remove(eventDesp);
            db.SaveChanges();
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
