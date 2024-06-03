using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class AppliedJobsController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: AppliedJobs
        public ActionResult AppliedJobs_Pageload()
        {
			return View (Getdata());
        }

		public AppliedJobs Getdata()
		{
			using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand("sp_appliedjob", con))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Session["uid"]));
					con.Open();
					SqlDataReader dr = cmd.ExecuteReader();
					var jobs = new AppliedJobs();
					while (dr.Read())
					{
						var job = new Applied();
						job.Job_Title = dr["Job_Title"].ToString();
						job.Job_Description = dr["Job_Description"].ToString();
						job.Date = DateTime.Parse(dr["Date"].ToString());
						job.Job_Type = dr["Job_Type"].ToString();
						job.Status = dr["Status"].ToString();
						jobs.selectjob.Add(job);
					}
					con.Close();
					return jobs;
				}
			}
		}
	}
}