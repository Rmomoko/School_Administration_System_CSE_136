namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class CourseService
    {
        private readonly ICourseRepository repository;

        public CourseService(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public List<Course> GetCourseList(ref List<string> errors)
        {
            return this.repository.GetCourseList(ref errors);
        }

        public void UpdateCoursePrereq(Course course, ref List<string> errors)
        {
            if (course == null)
            {
                errors.Add("Course cannot be null");
                throw new ArgumentException();
            }

            if (course.CourseId <= 0)
            {
                errors.Add("Invalid course id");
                throw new ArgumentException();
            }

            this.repository.UpdateCoursePrereq(course, ref errors);
        }
    }
}
