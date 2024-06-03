using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Portal.Controllers
{
    public class JobListController : Controller
    {
		JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
		// GET: JobList
		public ActionResult JobList_Pageload()
        {
			return View(dbobj.sp_joblist(Convert.ToInt32(Session["cid"])).ToList());
		}
    }
}