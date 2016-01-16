using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uniManageSys.Models;
using WebMatrix.WebData;

namespace uniManageSys.Controllers
{
    public class AdminController : Controller
    {
        DbcsContext db = new DbcsContext();

        public ActionResult Login()
        {
            if (Session["admin"] == null)
                return View();
            else
            {
                return View("_LoginPartial");
            }
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var data = db.Admins.Single(x => x.Id == 1);
            if (string.Equals(data.UserName, admin.UserName) && string.Equals(data.Password, admin.Password))
            {
                Session["admin"] = admin.UserName;
                return View("_LoginPartial");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Login");
        }

        
        public ActionResult Changepassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Changepassword(String newPassword,string oldPassword)
        {
            var data= db.Admins.Single(x => x.Id == 1);
            if (string.Equals(oldPassword, data.Password))
            {
                data.Password = newPassword;
                UpdateModel(data);
                db.SaveChanges();
                Session["admin"] = null;
                return RedirectToAction("Login");
            }
            else 
            return View();
        }

    }
}
