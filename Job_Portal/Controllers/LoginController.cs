using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class LoginController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: Login
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_Click(Login clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(clsobj.username, clsobj.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var id = dbobj.sp_logid(clsobj.username, clsobj.password).FirstOrDefault();
                    var lt = dbobj.sp_logtype(clsobj.username, clsobj.password).FirstOrDefault();
                    if (lt == "Admin")
                    {
                        Session["cid"] = id;
                        return RedirectToAction("AdminHome");
                    }
                    else if (lt == "User")
                    {
                        Session["uid"] = id;
                        return RedirectToAction("UserHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.message = "Invalid Login";
                    return View("Login_Pageload", clsobj);
                }
            }
            return View("Login_Pageload", clsobj);
        }
    }
}