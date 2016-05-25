namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class CourseRepository : BaseRepository, ICourseRepository
    {
        private const string GetCourseListProcedure = "spGetCourseList";
        private const string UpdateCoursePrereqProcedure = "spUpdateCoursePrereq";

        public List<Course> GetCourseList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetCourseListProcedure, conn)
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
                    var course = new Course
                                     {
                                         CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                                         Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                                         CourseLevel =
                                             (CourseLevel)
                                             Enum.Parse(
                                                 typeof(CourseLevel),
                                                 dataSet.Tables[0].Rows[i]["course_level"].ToString()),
                                         Description = dataSet.Tables[0].Rows[i]["course_description"].ToString()
                                     };
                    courseList.Add(course);
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

            return courseList;
        }

        public void UpdateCoursePrereq(Course course, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateCoursePrereqProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, 8000));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@pre_req", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = course.CourseId;
                adapter.SelectCommand.Parameters["@course_title"].Value = course.Title;
                adapter.SelectCommand.Parameters["@course_level"].Value = course.CourseLevel;
                adapter.SelectCommand.Parameters["@course_description"].Value = course.Description;
                adapter.SelectCommand.Parameters["@pre_req"].Value = course.Prereq;
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
