namespace POCO
{
    using System.Collections.Generic;

    public class StudentTakenCourse
    {
        public string StudentId { get; set; }

        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public string Grade { get; set; }

        public int Year { get; set; }

        public string Quarter { get; set; }

        public override string ToString()
        {
            return this.StudentId + "-"
                + this.CourseId + "-"
                + this.CourseTitle + "-"
                + this.Grade + "-"
                + this.Year + "-"
                + this.Quarter;
        }
    }
}
