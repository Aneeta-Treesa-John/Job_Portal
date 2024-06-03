using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
	public class CandidatesApplied
	{
		public CandidatesApplied()
		{
			selectjob = new List<Candidates>();
		}
		public Candidates JobInsert { set; get; }
		public List<Candidates> selectjob { set; get; }
	}
	public class Candidates
	{
		public Candidates JobInsert { set; get; }
		public List<Candidates> selectjob { set; get; }
		public int Company_Id { set; get; }
		public int Job_Id { set; get; }
		public string Job_Title { set; get; }
		public string Job_Type { set; get; }
		public int Job_Vacancy { set; get; }
		public string Job_Description { set; get; }
		public int User_Id { set; get; }
		public string Resume { set; get; }
		public DateTime Date { set; get; }
		public string Job_Status { set; get; }
	}
}