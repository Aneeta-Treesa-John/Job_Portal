using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Portal.Models;

namespace Job_Portal.Controllers
{
    public class UserRegController : Controller
    {
        JOB_PORTALEntities dbobj = new JOB_PORTALEntities();
        // GET: UserReg
        public ActionResult UserReg_Pageload()
        {
            List<StClass> StList = new List<StClass>
            {
                new StClass{S_Id=1,S_Name="Kerala"},
                new StClass{S_Id=2,S_Name="Tamil Nadu"},
                new StClass{S_Id=3,S_Name="Karnataka"},
                new StClass{S_Id=4,S_Name="Goa"}
            };
            ViewBag.SelState = new SelectList(StList, "S_Id", "S_Name");
            UserReg user = new UserReg();
            user.MyQual = getQualData();
            return View(user);
        }
        public List<QualClass> getQualData()        //list type aan return kittunnath
        {
            List<QualClass> qual = new List<QualClass>()
            {
                new QualClass{Q_Id=1,Q_Text="SSLC",Ischecked=false},
                new QualClass{Q_Id=2,Q_Text="Plus Two",Ischecked=false},
                new QualClass{Q_Id=3,Q_Text="B Tech",Ischecked=false},
                new QualClass{Q_Id=4,Q_Text="BCA",Ischecked=false},
                new QualClass{Q_Id=5,Q_Text="M Tech",Ischecked=false},
                new QualClass{Q_Id=6,Q_Text="MCA",Ischecked=false}
            };
            return qual;
        }
        public ActionResult UserReg_Click(UserReg clsobj,HttpPostedFileBase file,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string p = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Resume");
                    string pa = Path.Combine(s, p);
                    file.SaveAs(pa);
                    var fp = Path.Combine("~/Resume", p);
                    clsobj.resume = fp;
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
                List<StClass> StList = new List<StClass>
            {
                new StClass{S_Id=1,S_Name="Kerala"},
                new StClass{S_Id=2,S_Name="Tamil Nadu"},
                new StClass{S_Id=3,S_Name="Karnataka"},
                new StClass{S_Id=4,S_Name="Goa"},
                new StClass{S_Id=5,S_Name="Madhya Pradesh"}
            };
                int sel_Id = Convert.ToInt32(form["Selstates"]);
                StClass sel_item = StList.FirstOrDefault(c => c.S_Id == sel_Id);
                clsobj.S_Id = sel_item.S_Id;
                clsobj.S_Name = sel_item.S_Name;
                ViewBag.SelState = new SelectList(StList, "S_Id", "S_Name");
                var quid = string.Join(",", clsobj.selQual);
                clsobj.qualification = quid;
                clsobj.MyQual = getQualData();
                dbobj.sp_userreg(regid, clsobj.name, clsobj.age, clsobj.gender,clsobj.email,clsobj.phone,clsobj.address,clsobj.S_Name,clsobj.qualification,clsobj.skills,clsobj.experience,clsobj.resume, "Active");
                dbobj.sp_logtab(regid, clsobj.username, clsobj.password, "User","Active");
                clsobj.message = "Successfully Inserted";
                return View("UserReg_Pageload", clsobj);
            }
			else
			{
                List<StClass> StList = new List<StClass>
            {
                new StClass{S_Id=1,S_Name="Kerala"},
                new StClass{S_Id=2,S_Name="Tamil Nadu"},
                new StClass{S_Id=3,S_Name="Karnataka"},
                new StClass{S_Id=4,S_Name="Goa"}
            };
                ViewBag.SelState = new SelectList(StList, "S_Id", "S_Name");
                var quid = string.Join(",", clsobj.selQual);
                clsobj.qualification = quid;
                clsobj.MyQual = getQualData();
                return View("UserReg_Pageload", clsobj);
            }
            //return View("UserReg_Pageload", clsobj);
        }
    }
}