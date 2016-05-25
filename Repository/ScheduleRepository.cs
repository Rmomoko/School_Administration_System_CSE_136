namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private const string GetScheduleListProcedure = "spGetScheduleList";
        private const string InsertScheduleListProcedure = "spInsertScheduleList";
        private const string UpdateScheduleListProcedure = "spUpdateScheduleList";
        private const string DeleteScheduleListProcedure = "spDeleteScheduleList";

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var scheduleList = new List<Schedule>();

            try
            {
                var adapter = new SqlDataAdapter(GetScheduleListProcedure, conn);

                if (year.Length > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@year"].Value = year;
                }

                if (quarter.Length > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 25));
                    adapter.SelectCommand.Parameters["@quarter"].Value = quarter;
                }

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var schedule = new Schedule
                    {
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()),
                        Year = dataSet.Tables[0].Rows[i]["year"].ToString(),
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(),
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(),
                        Course = new Course
                        {
                            CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                            Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                            Description = dataSet.Tables[0].Rows[i]["course_description"].ToString(),
                        }
                    };
                    scheduleList.Add(schedule);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return scheduleList;
        }

        public void InsertScheduleList(Schedule schedule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertScheduleListProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@schedule_id"].Value = schedule.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = schedule.CourseId;
                adapter.SelectCommand.Parameters["@year"].Value = schedule.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = schedule.Quarter;
                adapter.SelectCommand.Parameters["@session"].Value = schedule.Session;
                adapter.SelectCommand.Parameters["@schedule_day_id"].Value = schedule.ScheduleDayId;
                adapter.SelectCommand.Parameters["@schedule_time_id"].Value = schedule.ScheduleTimeId;
                adapter.SelectCommand.Parameters["@instructor_id"].Value = schedule.InstructorId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void UpdateScheduleList(Schedule schedule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateScheduleListProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@schedule_id"].Value = schedule.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = schedule.CourseId;
                adapter.SelectCommand.Parameters["@year"].Value = schedule.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = schedule.Quarter;
                adapter.SelectCommand.Parameters["@session"].Value = schedule.Session;
                adapter.SelectCommand.Parameters["@schedule_day_id"].Value = schedule.ScheduleDayId;
                adapter.SelectCommand.Parameters["@schedule_time_id"].Value = schedule.ScheduleTimeId;
                adapter.SelectCommand.Parameters["@instructor_id"].Value = schedule.InstructorId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteScheduleList(string scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteScheduleListProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
