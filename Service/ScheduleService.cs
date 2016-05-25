namespace Service
{
    using System.Collections.Generic;

    using IRepository;

    using POCO;

    public class ScheduleService
    {
        private readonly IScheduleRepository repository;

        public ScheduleService(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            return this.repository.GetScheduleList(year, quarter, ref errors);
        }

        public void InsertScheduleList(Schedule schedule, ref List<string> errors)
        {
            if (schedule == null)
            {
                errors.Add("Schedule cannot be null");

                //// throw new ArgumentException();
                return;
            }

            this.repository.InsertScheduleList(schedule, ref errors);
        }

        public void UpdateScheduleList(Schedule schedule, ref List<string> errors)
        {
            if (schedule == null)
            {
                errors.Add("Schedule cannot be null");
                ////throw new ArgumentException();
                return;
            }

            this.repository.UpdateScheduleList(schedule, ref errors);
        }

        public void DeleteScheduleList(string scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(scheduleId))
            {
                errors.Add("Invalid schedule id");
                //// throw new ArgumentException();
                return;
            }

            this.repository.DeleteScheduleList(scheduleId, ref errors);
        }
    }
}
