using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
    public class JobInsert
    {
        public int company_id { set; get; }
        [Required(ErrorMessage ="Enter the name of post")]
        public string title { set; get; }
        [Required(ErrorMessage = "Enter the no of vacancy")]
        public int vacancy { set; get; }
        [Required(ErrorMessage = "Describe the post")]
        public string description { set; get; }
        [Required(ErrorMessage = "Approximate salary for the post")]
        public string salary { set; get; }
        public DateTime date { set; get; }
        [Required(ErrorMessage = "Enter the website to apply")]
        public string website { set; get; }
        [Required(ErrorMessage = "Specify the type of job")]
        public string type { set; get; }
        public string status { set; get; }
        public string message { set; get; }
    }
}