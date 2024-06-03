using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
	public class ApplyJob
	{
		public ApplyJob()
		{
			selectjob = new List<Apply>();
		}
		[Required(ErrorMessage = "Mandatory field")]
		public string Resume { set; get; }
		public string message { set; get; }
		//public Apply JobInsert { set; get; }
		public List<Apply> selectjob { set; get; }
	}
	public class Apply
	{
		//public Apply JobInsert { set; get; }
		public List<Apply> selectjob { set; get; }
		public int cid { set; get; }
		public int jobid { set; get; }
		public int userid { set; get; }
		public string Title { set; get; }
		public string Type { set; get; }
		public string Description { set; get; }
		public DateTime Date { set; get; }
		//public string Resume { set; get; }
		public string Status { set; get; }
		//public string message { set; get; }
	}
}