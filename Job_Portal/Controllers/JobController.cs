using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class JobController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: Job
        public ActionResult Job_Pageload()
        {
            return View();
        }
		public ActionResult Job_Click(JobInsert clsobj)
        {
			if (ModelState.IsValid)
			{
                dbobj.sp_job(Convert.ToInt32(Session["cid"]), clsobj.title, clsobj.vacancy, clsobj.description, clsobj.salary, DateTime.Today, clsobj.website, clsobj.type,"Apply Now");
                clsobj.message = "Successfully Inserted";
                return View("Job_Pageload", clsobj);
			}
            return View("Job_Pageload", clsobj);
        }
    }
}