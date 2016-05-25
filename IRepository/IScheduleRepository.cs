namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IScheduleRepository
    {
        List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors);

        void InsertScheduleList(Schedule schedule, ref List<string> errors);

        void UpdateScheduleList(Schedule schedule, ref List<string> errors);

        void DeleteScheduleList(string scheduleId, ref List<string> errors);
    }
}
