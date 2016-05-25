namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class GraduateCourseAppRepository : BaseRepository, IGraduateCourseAppRepository
    {
        private const string InsertGraduateCourseAppProcedure = "spInsertGraduateCourseApp";
        private const string UpdateGraduateCourseAppProcedure = "spUpdateGraduateCourseApp";
        private const string GetGraduateCourseAppProcedure = "spGetGraduateCourseApp";
        private const string GetAllGraduateCourseAppProcedure = "spGetAllGraduateCourseApp";
        
        public void InsertGraduateCourseApp(GraduateCourseApp graduateCourse, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertGraduateCourseAppProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prof_graduate_course_approve", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_graduate_course_approve", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = graduateCourse.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = graduateCourse.ScheduleId;
                adapter.SelectCommand.Parameters["@prof_graduate_course_approve"].Value = graduateCourse.ProfGraduateCourseApprove;
                adapter.SelectCommand.Parameters["@admin_graduate_course_approve"].Value = graduateCourse.AdminGraduateCourseApprove;

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

        public void UpdateGraduateCourseApp(GraduateCourseApp graduateCourse, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateGraduateCourseAppProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prof_graduate_course_approve", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_graduate_course_approve", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = graduateCourse.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = graduateCourse.ScheduleId;
                adapter.SelectCommand.Parameters["@prof_graduate_course_approve"].Value = graduateCourse.ProfGraduateCourseApprove;
                adapter.SelectCommand.Parameters["@admin_graduate_course_approve"].Value = graduateCourse.AdminGraduateCourseApprove;

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

        public List<GraduateCourseApp> GetGraduateCourseApp(int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var graduateCourseAppList = new List<GraduateCourseApp>();

            try
            {
                var adapter = new SqlDataAdapter(GetGraduateCourseAppProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var graduateCourse = new GraduateCourseApp
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        ProfGraduateCourseApprove = (int)dataSet.Tables[0].Rows[i]["prof_graduate_course_approve"],
                        AdminGraduateCourseApprove = (int)dataSet.Tables[0].Rows[i]["admin_graduate_course_approve"]
                    };
                    graduateCourseAppList.Add(graduateCourse);
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

            return graduateCourseAppList;
        }

        public List<GraduateCourseApp> GetAllGraduateCourseApp(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var graduateCourseAppList = new List<GraduateCourseApp>();

            try
            {
                var adapter = new SqlDataAdapter(GetAllGraduateCourseAppProcedure, conn)
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
                    var graduateCourse = new GraduateCourseApp
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        ProfGraduateCourseApprove = (int)dataSet.Tables[0].Rows[i]["prof_graduate_course_approve"],
                        AdminGraduateCourseApprove = (int)dataSet.Tables[0].Rows[i]["admin_graduate_course_approve"]
                    };
                    graduateCourseAppList.Add(graduateCourse);
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

            return graduateCourseAppList;
        }
    }
}
