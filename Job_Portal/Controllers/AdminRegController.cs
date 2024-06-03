using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class AdminRegController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: AdminReg
        public ActionResult AdminReg_Pageload()
        {
            return View();
        }
        public ActionResult AdminReg_Click(AdminReg clsobj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string p = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Logo");
                    string pa = Path.Combine(s, p);
                    file.SaveAs(pa);
                    var fp = Path.Combine("~/Logo", p);
                    clsobj.logo = fp;
                }
                var getmaxid = dbobj.sp_maxlogid().FirstOrDefault();
                int id = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (id == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = id + 1;
                }
                dbobj.sp_companyreg(regid, clsobj.name,clsobj.email, clsobj.website, clsobj.address, clsobj.phone,clsobj.logo, "Active");
                dbobj.sp_logtab(regid, clsobj.username, clsobj.password, "Admin", "Active");
                clsobj.message = "Successfully Inserted";
                return View("AdminReg_Pageload", clsobj);
            }
            return View("AdminReg_Pageload", clsobj);
        }
    }
}