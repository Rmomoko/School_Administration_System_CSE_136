namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class PrereqOverrideService
    {
        private readonly IPrereqOverrideRepository repository;

        public PrereqOverrideService(IPrereqOverrideRepository repository)
        {
            this.repository = repository;
        }

        public bool CheckStudentId(string sid)
        {
            string strRegex = @"^[a-zA-Z]{1}[0-9]+$";
            Regex re = new Regex(strRegex);
            var flag = re.IsMatch(sid);
            Console.WriteLine(flag);
            if (re.IsMatch(sid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertPrereqOverride(PrereqOverride prereqOverride, ref List<string> errors)
        {
            if (prereqOverride == null)
            {
                errors.Add("Prereq Override Application cannot be null");
                //// throw new ArgumentException();
                return;
            }

            if (this.CheckStudentId(prereqOverride.StudentId) == false)
            {
                errors.Add("Invalid Student Id");
                //// throw new ArgumentException();
                return;
            }

            if (prereqOverride.ScheduleId <= 0)
            {
                errors.Add("Prereq Override Schedule cannot be null");
                //// throw new ArgumentException();
                return;
            }

            if (string.IsNullOrEmpty(prereqOverride.StudentId))
            {
                errors.Add("Student Id cannot be null");
                //// throw new ArgumentException();
                return;
            }

            this.repository.InsertPrereqOverride(prereqOverride, ref errors);
        }

        public void UpdatePrereqOverride(PrereqOverride prereqOverride, ref List<string> errors)
        {
            if (prereqOverride == null)
            {
                errors.Add("Prereq Override Application cannot be null");
                //// throw new ArgumentException();
                return;
            }

            if (this.CheckStudentId(prereqOverride.StudentId) == false)
            {
                errors.Add("Invalid Student Id");
                //// throw new ArgumentException();
                return;
            }

            if (prereqOverride.ScheduleId <= 0)
            {
                errors.Add("Prereq Override Schedule cannot be null");
                //// throw new ArgumentException();
                return;
            }

            if (string.IsNullOrEmpty(prereqOverride.StudentId))
            {
                errors.Add("Student Id cannot be null");
                //// throw new ArgumentException();
                return;
            }

            this.repository.UpdatePrereqOverride(prereqOverride, ref errors);
        }

        public List<PrereqOverride> GetPrereqOverride(int scheduleId, ref List<string> errors)
        {
            if (scheduleId < 0)
            {
                errors.Add("Invalid schedule id");
                ////throw new ArgumentException();
            }

            return this.repository.GetPrereqOverride(scheduleId, ref errors);
        }

        public List<PrereqOverride> GetAllPrereqOverride(ref List<string> errors)
        {
            return this.repository.GetAllPrereqOverride(ref errors);
        }
    }
}