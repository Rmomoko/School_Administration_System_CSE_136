namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class StudentController : Controller
    {
        public ActionResult Index(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult Cape(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult AcademicHistory(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult ManageCourse(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult WriteCape(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult ViewCape()
        {
            return this.View();
        }

        public ActionResult CapeForm(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult GradeChangeForm(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult EnrollCourse(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult NoPreReq(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult NoGraduateReq(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult GraduateReqForm(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult PreReqForm(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }
    }
}
