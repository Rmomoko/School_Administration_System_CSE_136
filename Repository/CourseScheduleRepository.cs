namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class CourseScheduleRepository : BaseRepository, ICourseScheduleRepository
    {
        private const string GetCourseScheduleProcedure = "spGetScheduleList";

        public List<CourseSchedule> GetCourseScheduleList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseScheduleList = new List<CourseSchedule>();

            try
            {
                var adapter = new SqlDataAdapter(GetCourseScheduleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var courseSchedule = new CourseSchedule
                    {
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                        Year = (int)dataSet.Tables[0].Rows[i]["year"],
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(),
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(),
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        CourseDescription = dataSet.Tables[0].Rows[i]["course_description"].ToString(),
                    };
                    courseScheduleList.Add(courseSchedule);
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

            return courseScheduleList;
        }
    }
}
