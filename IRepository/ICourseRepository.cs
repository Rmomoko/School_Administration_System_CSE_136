namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICourseRepository
    {
        List<Course> GetCourseList(ref List<string> errors);

        void UpdateCoursePrereq(Course course, ref List<string> errors);
    }
}
