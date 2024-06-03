using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class JobApplyController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: JobApply
        public ActionResult JobApply_Pageload(int id)
        {
            return View(Getdata(id));
        }
		private ApplyJob Getdata(int id)
		{
			var jobs = new ApplyJob();
			var jobse = dbobj.sp_applyjob(id).ToList();
			foreach (var j in jobse)
			{
				var job = new Apply();
				Session["cid"] = j.Company_Id;
				Session["jid"] = j.Job_Id;
				job.Title = j.Job_Title;
				job.Description = j.Job_Description;
				job.Type = j.Job_Type;
				job.Date = j.Job_Posted;
				jobs.selectjob.Add(job);
				
			}
			return jobs;
		}

		public ActionResult JobApply_Click(ApplyJob clsobj, HttpPostedFileBase file, FormCollection form)
        {
			if (file.ContentLength > 0)
			{
				string p = Path.GetFileName(file.FileName);
				var s = Server.MapPath("~/Resume");
				string pa = Path.Combine(s, p);
				file.SaveAs(pa);
				var fp = Path.Combine("~/Resume", p);
				clsobj.Resume = fp;
			}
			dbobj.sp_apply(Convert.ToInt32(Session["cid"]), Convert.ToInt32(Session["jid"]), Convert.ToInt32(Session["uid"]), DateTime.Today, clsobj.Resume, "Applied");
            clsobj.message = "Application Submitted Successfully";
            return View("JobApply_Pageload", clsobj);
		}
	}
}