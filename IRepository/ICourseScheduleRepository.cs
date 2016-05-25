namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICourseScheduleRepository
    {
        List<CourseSchedule> GetCourseScheduleList(ref List<string> errors);
    }
}
