using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
	public class AppliedJobs
	{
		public AppliedJobs()
		{
			selectjob = new List<Applied>();
		}
		public Applied JobInsert { set; get; }
		public List<Applied> selectjob { set; get; }
	}
	public class Applied
	{
		public Applied JobInsert { set; get; }
		public List<Applied> selectjob { set; get; }
		public string Job_Title { set; get; }
		public string Job_Type { set; get; }
		public string Job_Description { set; get; }
		public DateTime Date { set; get; }
		public string Status { set; get; }
	}
}