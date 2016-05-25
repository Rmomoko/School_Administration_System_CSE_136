namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class InstructorCourseService
    {
        private readonly IInstructorCourseRepository repository;

        public InstructorCourseService(IInstructorCourseRepository repository)
        {
            this.repository = repository;
        }

        public List<InstructorCourse> GetInstructorCourseList(int instructorId, ref List<string> errors)
        {
            if (instructorId < 0)
            {
                errors.Add("Invalid instructor id");
                ////throw new ArgumentException();
                return null;
            }

            return this.repository.GetInstructorCourseList(instructorId, ref errors);
        }
    }
}