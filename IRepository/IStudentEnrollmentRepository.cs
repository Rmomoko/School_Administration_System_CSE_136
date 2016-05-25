namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IStudentEnrollmentRepository
    {
        void EnrollSchedule(string studentId, int scheduleId, string grade_option, int pre_req_status, ref List<string> errors);

        void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors);

        List<StudentEnrollment> GetStudentEnrollList(int scheduleId, ref List<string> errors);

        List<StudentEnrollment> GetEnrollments(string studentId, ref List<string> errors);
    }
}
