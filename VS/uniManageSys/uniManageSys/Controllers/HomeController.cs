using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uniManageSys.Models;

namespace uniManageSys.Controllers
{
    public class HomeController : Controller
    {
        DbcsContext db=new DbcsContext();

        public ActionResult Index(int id)
        {
            Admin admin = db.Admins.Single(x => x.Id == id);
            return View(admin);
        }

    }
}
