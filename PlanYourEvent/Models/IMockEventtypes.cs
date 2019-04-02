using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanYourEvent.Models
{
    public interface IMockEventtypes
    { 
        IQueryable<Eventtype> eventtypes { get; }
    }
}
