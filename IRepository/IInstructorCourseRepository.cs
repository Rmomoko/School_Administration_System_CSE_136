namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IInstructorCourseRepository
    {
        List<InstructorCourse> GetInstructorCourseList(int instructorId, ref List<string> errors);
    }
}
