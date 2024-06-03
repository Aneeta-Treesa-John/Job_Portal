using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Portal.Controllers
{
    public class JobAppliedController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: JobApplied
        public ActionResult JobApplied_Pageload()
        {
            return View(dbobj.Applied_Tab.ToList());
        }
    }
}