using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Portal.Controllers
{
    public class ViewJobListController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: ViewJobList
        public ActionResult ViewJobList_Pageload()
        {
			return View(dbobj.sp_check().ToList());
        }
		public void Grid(string qry)
		{
			dbobj.sp_search(string.Join("@SQL", qry));
		}
		public ActionResult ViewJobList_Click(sp_check_Result clsobj)
		{
            string qry = "";
			if (!string.IsNullOrWhiteSpace(clsobj.Job_Title))
			{
				qry += " and Job_Title like '%" + clsobj.Job_Title + "%'";
			}
			if (!string.IsNullOrWhiteSpace(clsobj.Job_Type))
			{
				qry += " and Job_Type like '%" + clsobj.Job_Type + "%'";
			}
			if (!string.IsNullOrWhiteSpace(clsobj.Job_Status))
			{
				qry += " and Job_Status like '%" + clsobj.Job_Status + "%'";
			}
			Grid(qry);
			return View("ViewJobList_Pageload", dbobj.sp_search(qry));
		}
	}
}