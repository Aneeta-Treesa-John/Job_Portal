using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
    public class AdminReg
    {
        [Required(ErrorMessage = "Field Mandatory")]
        public string name { set; get; }
        [EmailAddress(ErrorMessage = "Enter a valid Email Id")]
        public string email { set; get; }
        [Required(ErrorMessage = "Field Mandatory")]
        public string website { set; get; }
        [Required(ErrorMessage = "Field Mandatory")]
        public string address { set; get; }
        //[RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Invalid entry")]
        public string phone { set; get; }
        public string logo { set; get; }
        [Required(ErrorMessage = "Field Mandatory")]
        public string username { set; get; }
        public string password { set; get; }
        [Compare("password", ErrorMessage = "Password Mismatch")]
        public string confirmpassword { set; get; }
        public string message { set; get; }
    }
}