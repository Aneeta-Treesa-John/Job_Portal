using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
	public class JobList
	{
        public int company_id { set; get; }
        public string title { set; get; }
        public int vacancy { set; get; }
        public string description { set; get; }
        public DateTime date { set; get; }
        public string type { set; get; }
        public string status { set; get; }
    }
}