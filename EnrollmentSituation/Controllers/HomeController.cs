using EnrollmentSituation.Data;
using EnrollmentSituation.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace EnrollmentSituation.Controllers
{
    public class HomeController : Controller
    {
        private EnrollmentDbContext db = new EnrollmentDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.ProgId = new SelectList(db.Programs.ToList(), "ProgId", "ProgName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    TempData["Success"] = "Registration successful. Please log in.";
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred: " + ex.Message);
                }
            }

            ViewBag.ProgId = new SelectList(db.Programs.ToList(), "ProgId", "ProgName", student.ProgId);
            return View(student);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(int StudIDNumber, DateTime? studDob)
        {
            if (!studDob.HasValue)
            {
                ViewBag.Message = "Please enter a valid birthdate.";
                return View();
            }

            var dateOnly = studDob.Value.Date;
            var student = db.Students.FirstOrDefault(s => s.StudIDNumber == StudIDNumber &&
                                                          DbFunctions.TruncateTime(s.StudDob) == dateOnly);

            if (student != null)
            {
                Session["StudentId"] = student.StudId;
                return RedirectToAction("StudentDashboard");
            }

            ViewBag.Message = "Invalid ID number or birthdate.";
            System.Diagnostics.Debug.WriteLine($"Login attempt - ID: {StudIDNumber}, DOB: {studDob}");
            return View();
        }

        public ActionResult StudentDashboard()
        {
            if (Session["StudentId"] == null)
                return RedirectToAction("Login");

            int studId = (int)Session["StudentId"];

            var student = db.Students
                .Include(s => s.Program) // Important!
                .FirstOrDefault(s => s.StudId == studId);

            return View(student);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
