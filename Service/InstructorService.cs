namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using IRepository;
    using POCO;

    public class InstructorService
    {
        private readonly IInstructorRepository repository;

        public InstructorService(IInstructorRepository repository)
        {
            this.repository = repository;
        }

        public Instructor GetInstructorInfo(int instructorId, ref List<string> errors)
        {
            return this.repository.GetInstructorInfo(instructorId, ref errors);
        }

        public void UpdateInstructorInfo(Instructor instructor, ref List<string> errors)
        {
            if (instructor == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            this.repository.UpdateInstructorInfo(instructor, ref errors);
        }
    }
}
