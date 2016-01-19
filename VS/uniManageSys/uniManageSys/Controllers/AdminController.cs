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
        public ActionResult Changepassword(upPassword updatePass)
        {
            var data = db.Admins.Single(x => x.Id == 1);
            if (string.Equals(updatePass.oldPassword, data.Password))
            {
                data.Password = updatePass.newPassword;
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

        public ActionResult EditStudent(int Id)
        {
            var data = db.Students.Single(x => x.Id == Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return View("EditStudent");
        }

        public ActionResult EditTeacher(int Id)
        {
            var data = db.Teachers.Single(x => x.Id == Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult EditTeacher(Teacher teacher)
        {
            db.Teachers.AddOrUpdate(teacher);
            db.SaveChanges();
            return View("EditTeacher");
        }

        public ActionResult DeleteStudent(int Id)
        {
            var data = db.Students.Find(Id);
            db.Students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("AllRegisterStudents");
        }

        public ActionResult DeleteTeacher(int Id)
        {
            var data = db.Teachers.Find(Id);
            db.Teachers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("AllRegisterTeachers");
        }

        [HttpPost]
        public ActionResult ShowStudent(string userName)
        {
            var data = db.Students.Single(x => x.userName == userName);
            return View(data);
        }

        [HttpPost]
        public ActionResult ShowTeacher(string userName)
        {
            var data = db.Teachers.Single(x => x.userName == userName);
            return View(data);
        }

    }
}
