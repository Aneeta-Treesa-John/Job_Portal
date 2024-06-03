using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Portal.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Invalid Username")]
        public string username { set; get; }
        [Required(ErrorMessage = "Invalid Password")]
        public string password { set; get; }
        public string message { set; get; }
    }
}