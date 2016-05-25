namespace POCO
{
    public class CourseSchedule
    {
        public int ScheduleId { get; set; }

        public int CourseId { get; set; }

        public int Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public string CourseTitle { get; set; }

        public string CourseDescription { get; set; }

        public override string ToString()
        {
            return this.ScheduleId + "-" + this.CourseId + "-" + this.Year + "-" + this.Quarter + "-" + this.Session + "-" + this.CourseTitle + "-" + this.CourseDescription;
        }
    }
}
