namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IInstructorRepository
    {
        void UpdateInstructorInfo(Instructor instructor, ref List<string> errors);

        Instructor GetInstructorInfo(int instructorId, ref List<string> errors);
    }
}
