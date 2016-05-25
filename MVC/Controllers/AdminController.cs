namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult StudentList()
        {
            return this.View();
        }

        public ActionResult ManageStudentCourse(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult EnrollCourse(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult StudentTakenCourse(string id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult PrereqOverrideApplication()
        {
            return this.View();
        }

        public ActionResult GraduateCourseApplication()
        {
            return this.View();
        }
    }
}
