using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class JobSearchController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();

		// GET: JobSearch
		public ActionResult JobSearch_Pageload()
        {
            return View(Getdata());
        }
		private Searchjob Getdata()
		{
			var jobs = new Searchjob();
			var jobse = dbobj.sp_check().ToList();
			foreach (var j in jobse)
			{
				var job = new joblist();
				job.job_id = j.Job_Id;
				job.Title = j.Job_Title;
				job.Vacancy = j.Job_Vacancy;
				job.Description = j.Job_Description;
				job.Salary = j.Job_Salary;
				job.Date = j.Job_Posted;
				job.Website = j.Job_Website;
				job.Type = j.Job_Type;
				job.Status = j.Job_Status;
				jobs.selectjob.Add(job);
			}
			return jobs;
		}
		public Searchjob Search(string qry,joblist clsobj)
		{
			using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand("sp_search", con))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@qry", qry);
					con.Open();
					SqlDataReader dr = cmd.ExecuteReader();
					var jobs = new Searchjob();
					while (dr.Read())
					{
						var job = new joblist();
						job.job_id = Convert.ToInt32(dr["Job_Id"]);
						job.Title = dr["Job_Title"].ToString();
						job.Vacancy = Convert.ToInt32(dr["Job_Vacancy"]);
						job.Description = dr["Job_Description"].ToString();
						job.Salary = dr["Job_Salary"].ToString();
						job.Date = DateTime.Parse(dr["Job_Posted"].ToString());
						job.Website = dr["Job_Website"].ToString();
						job.Type = dr["Job_Type"].ToString();
						job.Status = dr["Job_Status"].ToString();
						jobs.selectjob.Add(job);
					}
					con.Close();
					return jobs;
					
				}
			}
		}
		public ActionResult JobSearch_Click(Searchjob clsobj)
		{
			string qry = "";
			if (!string.IsNullOrWhiteSpace(clsobj.jsearch.Title))
			{
				qry += " and Job_Title like '%" + clsobj.jsearch.Title + "%'";
			}
			if (!string.IsNullOrWhiteSpace(clsobj.jsearch.Description))
			{
				qry += " and Job_Description like '%" + clsobj.jsearch.Description + "%'";
			}
			if (!string.IsNullOrWhiteSpace(clsobj.jsearch.Type))
			{
				qry += " and Job_Type like '%" + clsobj.jsearch.Type + "%'";
			}
			return View("JobSearch_Pageload", Search(qry,clsobj.jsearch));
		}
	}
}