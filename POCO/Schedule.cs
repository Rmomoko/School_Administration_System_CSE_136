namespace POCO
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public int CourseId { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public int ScheduleDayId { get; set; }

        public int ScheduleTimeId { get; set; }

        public int InstructorId { get; set; }

        public Course Course { get; set; }

        public override string ToString()
        {
            return this.ScheduleId + "-" + this.CourseId + "-" + this.Year + "-" + this.Quarter + "-" + this.Session + "-" + this.ScheduleDayId + this.ScheduleTimeId + "-" + this.InstructorId + "-" + this.Course;
        }
    }
}
