namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class InstructorCourseRepository : BaseRepository, IInstructorCourseRepository
    {
        private const string GetInstructorCourseProcedure = "spGetInstructorCourse";

        public List<InstructorCourse> GetInstructorCourseList(int instructorId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var instructorCourseList = new List<InstructorCourse>();

            try
            {
                var adapter = new SqlDataAdapter(GetInstructorCourseProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructorId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var instructorCourse = new InstructorCourse
                    {
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                        Year = (int)dataSet.Tables[0].Rows[i]["year"],
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(),
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(),
                        ScheduleDayId = (int)dataSet.Tables[0].Rows[i]["schedule_day_id"],
                        ScheduleTimeId = (int)dataSet.Tables[0].Rows[i]["schedule_time_id"],
                        InstructorId = (int)dataSet.Tables[0].Rows[i]["instructor_id"],
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString()
                    };

                    instructorCourseList.Add(instructorCourse);
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

            return instructorCourseList;
        }
    }
}
