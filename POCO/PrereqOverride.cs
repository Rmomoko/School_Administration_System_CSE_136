namespace POCO
{
    public class PrereqOverride
    {
        public string StudentId { get; set; }

        public int ScheduleId { get; set; }

        public string CourseTitle { get; set; }

        public int ProfPrereqOverrideStatus { get; set; }

        public int AdminPrereqOverrideStatus { get; set; }

        public override string ToString()
        {
            return this.StudentId + "-" + this.ScheduleId + "-" + this.CourseTitle + "-" + this.ProfPrereqOverrideStatus + "-" + this.AdminPrereqOverrideStatus;
        }
    }
}