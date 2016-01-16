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
                return RedirectToAction("AdminDashboard", "Dashboard"); ;
            }
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var data = db.Admins.Single(x => x.Id == 1);
            if (string.Equals(data.UserName, admin.UserName) && string.Equals(data.Password, admin.Password))
            {
                Session["admin"] = admin.UserName;
                return RedirectToAction("AdminDashboard", "Dashboard");
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

        public ActionResult addStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addStudent(Student student)
        {
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return RedirectToAction("AdminDashboard", "Dashboard");
        }

        public ActionResult addTeacher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addTeacher(Teacher teacher)
        {
            db.Teachers.AddOrUpdate(teacher);
            db.SaveChanges();
            return RedirectToAction("AdminDashboard", "Dashboard");
        }

        public ActionResult AllRegisterStudents()
        {
            IEnumerable<Student> allStudents = db.Students;
            return View(allStudents);
        }

        public ActionResult AllRegisterTeachers()
        {
            IEnumerable<Teacher> allTeachers = db.Teachers;
            return View(allTeachers);
        }

    }
}
