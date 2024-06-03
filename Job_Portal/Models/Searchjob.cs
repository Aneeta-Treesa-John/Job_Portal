using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
	public class Searchjob
	{
		public Searchjob()
		{
			selectjob = new List<joblist>();
			jsearch = new joblist();
		}
		public joblist jsearch { set; get; }
		public List<joblist> selectjob { set; get; }
	}
	public class joblist
	{
		public int job_id { set;get;}
		public int company_id { set; get; }
		public string Title { set; get; }
		public int Vacancy { set; get; }
		public string Description { set; get; }
		public string Salary { set; get; }
		public DateTime Date { set; get; }
		public string Website { set; get; }
		public string Type { set; get; }
		public string Status { set; get; }
		public string message { set; get; }
	}
}