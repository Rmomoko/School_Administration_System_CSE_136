namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class InstructorCourseController : ApiController
    {
        [HttpGet]
        public List<InstructorCourse> GetInstructorCourseList(int instructorId)
        {
            var service = new InstructorCourseService(new InstructorCourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetInstructorCourseList(instructorId, ref errors);
        }
    }
}