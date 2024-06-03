using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
    public class StClass
    {
        public int S_Id { set; get; }
        public string S_Name { set; get; }
    }
    public class QualClass
    {
        public int Q_Id { set; get; }
        public string Q_Text { set; get; }
        public bool Ischecked { set; get; }
    }
    public class UserReg
    {
        public int S_Id { set; get; }
        public string S_Name { set; get; }
        public List<QualClass> MyQual { set; get; }
        public string[] selQual { set; get; }
        [Required(ErrorMessage ="Mandatory field")]
        public string name { set; get; }
        [Range(18,45,ErrorMessage ="Age Exceeded")]
        public int age { set; get; }
        [Required(ErrorMessage = "Mandatory field")]
        public string gender { set; get; }
        [Required(ErrorMessage = "Mandatory field")]
        public string email { set; get; }
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Invalid Entry")]
        public long phone { set; get; }
        [Required(ErrorMessage = "Mandatory field")]
        public string address { set; get; }
        public string qualification { set; get; }
        [Required(ErrorMessage = "Mandatory field")]
        public string skills { set; get; }
        [Required(ErrorMessage = "Describe your previous experience here")]
        public string experience { set; get; }
        public string resume { set; get; }
        [Required(ErrorMessage = "Mandatory field")]
        public string username { set; get; }
        public string password { set; get; }
        [Compare("password",ErrorMessage ="Password Mismatch")]
        public string confirmPassword { set; get; }
        public string message { set; get; }
    }
}