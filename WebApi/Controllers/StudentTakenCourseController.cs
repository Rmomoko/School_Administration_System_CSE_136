namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class StudentTakenCourseController : ApiController
    {
        [HttpGet]
        public List<StudentTakenCourse> GetStudentTakenCourse(string studentId)
        {
            var service = new StudentTakenCourseService(new StudentTakenCourseRepository());
            var errors = new List<string>();

            return service.GetStudentTakenCourse(studentId, ref errors);
        }

        [HttpPost]
        public string InsertStudentTakenCourse(StudentTakenCourse student)
        {
            var errors = new List<string>();
            var repository = new StudentTakenCourseRepository();
            var service = new StudentTakenCourseService(repository);

            service.InsertStudentTakenCourse(student, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdateStudent(StudentTakenCourse student)
        {
            var errors = new List<string>();
            var repository = new StudentTakenCourseRepository();
            var service = new StudentTakenCourseService(repository);
            service.UpdateStudentTakenCourse(student, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteStudentTakenCourse(string studentId, int courseId)
        {
            var errors = new List<string>();
            var repository = new StudentTakenCourseRepository();
            var service = new StudentTakenCourseService(repository);
            service.DeleteStudentTakenCourse(studentId, courseId, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}