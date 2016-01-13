using System;
using System.Collections.Generic;
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
                return RedirectToAction("yes");
            }
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var data = db.Admins.Single(x => x.Id == 1);
            if (string.Equals(data.UserName, admin.UserName) && string.Equals(data.Password, admin.Password))
            {
                Session["admin"] = admin.UserName;
                return RedirectToAction("yes");
            }
            else
            {
                return View();
            }
        }

        public ActionResult yes()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login");
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
    }
}
