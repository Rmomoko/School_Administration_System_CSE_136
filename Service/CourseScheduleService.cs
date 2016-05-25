namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class CourseScheduleService
    {
        private readonly ICourseScheduleRepository repository;

        public CourseScheduleService(ICourseScheduleRepository repository)
        {
            this.repository = repository;
        }

        public List<CourseSchedule> GetCourseScheduleList(ref List<string> errors)
        {
            return this.repository.GetCourseScheduleList(ref errors);
        }
    }
}
