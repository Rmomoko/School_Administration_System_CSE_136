namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class CourseScheduleController : ApiController
    {
        [HttpGet]
        public List<CourseSchedule> GetCourseScheduleList()
        {
            var service = new CourseScheduleService(new CourseScheduleRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetCourseScheduleList(ref errors);
        }
    }
}