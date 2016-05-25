namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class GraduateCourseAppService
    {
        private readonly IGraduateCourseAppRepository repository;

        public GraduateCourseAppService(IGraduateCourseAppRepository repository)
        {
            this.repository = repository;
        }

        public void InsertGraduateCourseApp(GraduateCourseApp graduatecourseapp, ref List<string> errors)
        {
            if (graduatecourseapp == null)
            {
                errors.Add("GraduateCourseApp cannot be null");
                return;
                ////throw new ArgumentException();
            }

            if (graduatecourseapp.StudentId.Length < 5)
            {
                errors.Add("Invalid student ID length");
                return;
                ////throw new ArgumentException();
            }

            this.repository.InsertGraduateCourseApp(graduatecourseapp, ref errors);
        }

        public void UpdateGraduateCourseApp(GraduateCourseApp graduatecourseapp, ref List<string> errors)
        {
            if (graduatecourseapp == null)
            {
                errors.Add("GraduateCourseApp cannot be null");
                return;
                ////throw new ArgumentException();
            }

            if (graduatecourseapp.StudentId.Length < 5)
            {
                errors.Add("Invalid student id length");
                return;
                ////throw new ArgumentException();
            }

            this.repository.UpdateGraduateCourseApp(graduatecourseapp, ref errors);
        }

        public List<GraduateCourseApp> GetGraduateCourseApp(int scheduleId, ref List<string> errors)
        {
            if (scheduleId <= 0)
            {
                errors.Add("Invalid schedule id");
                ////throw new ArgumentException();
            }

            return this.repository.GetGraduateCourseApp(scheduleId, ref errors);
        }

        public List<GraduateCourseApp> GetAllGraduateCourseApp(ref List<string> errors)
        {
            return this.repository.GetAllGraduateCourseApp(ref errors);
        }
    }
}