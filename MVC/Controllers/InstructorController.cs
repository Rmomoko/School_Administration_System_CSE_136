namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
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

        public ActionResult AssignGrade(int id)
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

        public ActionResult ViewGradeChangeRequest()
        {
            return this.View();
        }

        public ActionResult GradeChangeForm()
        {
            return this.View();
        }

        public ActionResult GetTeachingCourse(int id)
        {
            ViewBag.id = id;
            return this.View();
        }
    }
}