namespace POCO
{
    public class GraduateCourseApp
    {
        public string StudentId { get; set; }

        public int ScheduleId { get; set; }

        public string CourseTitle { get; set; }

        public int ProfGraduateCourseApprove { get; set; }

        public int AdminGraduateCourseApprove { get; set; }

        public override string ToString()
        {
            return this.StudentId + "-" + this.ScheduleId + "-" + this.CourseTitle + "-" + this.ProfGraduateCourseApprove + "-" + this.AdminGraduateCourseApprove;
        }
    }
}
