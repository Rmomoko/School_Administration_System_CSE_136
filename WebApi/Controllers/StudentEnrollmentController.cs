namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class StudentEnrollmentController : ApiController
    {
        [HttpGet]
        public List<StudentEnrollment> GetEnrollments(string studentId)
        {
            var service = new StudentEnrollmentService(new EnrollmentRuleRepository(), new StudentEnrollmentRepository());
            var errors = new List<string>();

            return service.GetEnrollments(studentId, ref errors);
        }

        [HttpGet]
        public List<StudentEnrollment> GetStudentEnrollList(int scheduleId)
        {
            var service = new StudentEnrollmentService(new EnrollmentRuleRepository(), new StudentEnrollmentRepository());
            var errors = new List<string>();

            return service.GetStudentEnrollList(scheduleId, ref errors);
        }

        [HttpPost]
        public void DropEnrolledSchedule(string studentId, int scheduleId)
        {
            var errors = new List<string>();
            var service = new StudentEnrollmentService(new EnrollmentRuleRepository(), new StudentEnrollmentRepository());
            service.DropEnrolledSchedule(studentId, scheduleId, ref errors);
        }

        [HttpPost]
        public void EnrollSchedule(string studentId, int scheduleId, string grade_option, int pre_req_status)
        {
            var errors = new List<string>();
            var repository = new StudentEnrollmentRepository();
            var service = new StudentEnrollmentService(new EnrollmentRuleRepository(), repository);
            service.EnrollSchedule(studentId, scheduleId, grade_option, pre_req_status, ref errors);
        }
    }
}