namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class InstructorController : ApiController
    {
        [HttpGet]
        public Instructor GetInstructorInfo(int instructorId)
        {
            var service = new InstructorService(new InstructorRepository());
            var errors = new List<string>();

            return service.GetInstructorInfo(instructorId, ref errors);
        }

        [HttpPost]
        public string UpdateInstructorInfo(Instructor instructor)
        {
            var errors = new List<string>();
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            service.UpdateInstructorInfo(new Instructor() { Id = instructor.Id, FirstName = instructor.FirstName, LastName = instructor.LastName }, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}