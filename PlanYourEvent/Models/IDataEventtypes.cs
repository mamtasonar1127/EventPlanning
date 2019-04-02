using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanYourEvent.Models
{
    public class IDataEventtypes : IMockEventtypes
    {
        //db Connection
        private DbModel db = new DbModel();

        public IQueryable<Eventtype> eventtypes { get { return db.Eventtypes; } }

        public void Delete(Eventtype eventtype)
        {
            db.Eventtypes.Remove(eventtype);
            db.SaveChanges();
        }

        public Eventtype Save(Eventtype eventtype)
        {
            if(eventtype.Event_Id == 0)
            {
                db.Eventtypes.Add(eventtype);
            }
            else
            {
                db.Entry(eventtype).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return eventtype;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}