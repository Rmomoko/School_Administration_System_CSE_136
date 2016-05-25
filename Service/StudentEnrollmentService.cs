namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using IRepository;
    using POCO;

    public class StudentEnrollmentService
    {
        private readonly IStudentEnrollmentRepository repository;
        private readonly IEnrollmentRuleRepository ruleRepository;

        public StudentEnrollmentService(IEnrollmentRuleRepository ruleRepository, IStudentEnrollmentRepository repository)
        {
            this.repository = repository;
            this.ruleRepository = ruleRepository;
        }

        public bool CheckStudentId(string sid)
        {
            string strRegex = @"^[a-zA-Z]{1}[0-9]+$";
            Regex re = new Regex(strRegex);
            var flag = re.IsMatch(sid);
            Console.WriteLine(flag);
            if (re.IsMatch(sid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EnrollSchedule(string studentId, int scheduleId, string grade_option, int pre_req_status, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                ////throw new ArgumentException();
                return;
            }

            if (!this.CheckStudentId(studentId))
            {
                errors.Add("Invalid student ID");
                ////throw new ArgumentException();
                return;
            }

            if (studentId.Length < 5)
            {
                errors.Add("Invalid student ID");
                //// throw new ArgumentException();
                return;
            }

            if (string.IsNullOrEmpty(grade_option) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                //// throw new ArgumentException();
                return;
            }

            this.repository.EnrollSchedule(studentId, scheduleId, grade_option, pre_req_status, ref errors);
        }

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            if (!this.CheckStudentId(studentId))
            {
                errors.Add("Invalid student ID");
                throw new ArgumentException();
            }

            if (studentId.Length < 5)
            {
                errors.Add("Invalid student ID");
                //// throw new ArgumentException();
                return;
            }

            this.repository.DropEnrolledSchedule(studentId, scheduleId, ref errors);
        }

        public List<StudentEnrollment> GetEnrollments(string studentId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            if (!this.CheckStudentId(studentId))
            {
                errors.Add("Invalid student ID");
                throw new ArgumentException();
            }

            if (studentId.Length < 5)
            {
                errors.Add("Invalid student ID");
                throw new ArgumentException();
            }

            return this.repository.GetEnrollments(studentId, ref errors);
        }

        public List<StudentEnrollment> GetStudentEnrollList(int scheduleId, ref List<string> errors)
        {
            if (scheduleId < 0)
            {
                errors.Add("Invalid schedule id");
                throw new ArgumentException();
            }

            return this.repository.GetStudentEnrollList(scheduleId, ref errors);
        }

        public int GetEnrollUnits(List<StudentEnrollment> studentEnrollments, ref List<string> errors)
        {
            var sum = 0;

            foreach (var enrollment in studentEnrollments)
            {
                sum = sum + 4;
            }

            return sum;
        }
    }
}
