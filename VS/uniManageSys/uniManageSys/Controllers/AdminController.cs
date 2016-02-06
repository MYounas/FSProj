using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using Newtonsoft.Json.Linq;
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
                ViewBag.Error = "Name or Pass incorent!";
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
            var responce = Request["g-recaptcha-response"];
            string secretKey = "6LdeyhUTAAAAAPm5v2eh-CafSM56oc8dsTHLtWkE";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, responce));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "" : "Failed";
            status = true;
            if (status)
            {
                bool ex_student = db.Students.Any(x => x.Email == student.Email||x.Phone==student.Phone);

                if (ex_student == false)
                {
                    db.Students.AddOrUpdate(student);
                    db.SaveChanges();
                    return RedirectToAction("AdminDashboard", "Dashboard");
                }
                else
                {
                    ViewBag.existMsg = "Student is already Exist!;";
                    return View();
                }
                
            }
            else
            {
                ViewBag.Message = "Check This Box If u r not robot!:P";
                return View();
            }
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
