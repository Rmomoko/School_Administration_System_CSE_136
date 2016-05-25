namespace POCO
{
    using System.Collections.Generic;

    public class InstructorCourse
    {
        public int ScheduleId { get; set; }

        public int CourseId { get; set; }

        public int Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public int ScheduleDayId { get; set; }

        public int ScheduleTimeId { get; set; }

        public int InstructorId { get; set; }

        public string CourseTitle {get; set;}

        public override string ToString()
        {
            return this.ScheduleId + "-"
                + this.CourseId + "-"
                + this.Year + "-"
                + this.Quarter + "-"
                + this.Session + "-"
                + this.ScheduleDayId + "-"
                + this.ScheduleTimeId + "-"
                + this.InstructorId + "-"
                + this.CourseTitle;
        }
    }
}
