namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class StudentTakenCourseRepository : BaseRepository, IStudentTakenCourseRepository
    {
        private const string InsertStudentTakenCourseProcedure = "spInsertStudentTakenCourse";
        private const string UpdateStudentTakenCourseProcedure = "spUpdateStudentTakenCourse";
        private const string DeleteStudentTakenCourseProcedure = "spDeleteStudentTakenCourse";
        private const string GetStudentTakenCourseProcedure = "spGetStudentTakenCourse";

        public void InsertStudentTakenCourse(StudentTakenCourse studentTakenCourse, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertStudentTakenCourseProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@grade", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentTakenCourse.StudentId;
                adapter.SelectCommand.Parameters["@course_id"].Value = studentTakenCourse.CourseId;

                if (studentTakenCourse.Grade == null)
                {
                    adapter.SelectCommand.Parameters["@grade"].Value = "In Progress";
                }

                adapter.SelectCommand.Parameters["@year"].Value = studentTakenCourse.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = studentTakenCourse.Quarter;

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

        public void UpdateStudentTakenCourse(StudentTakenCourse studentTakenCourse, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateStudentTakenCourseProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@grade", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentTakenCourse.StudentId;
                adapter.SelectCommand.Parameters["@course_id"].Value = studentTakenCourse.CourseId;
                adapter.SelectCommand.Parameters["@course_title"].Value = studentTakenCourse.CourseTitle;
                adapter.SelectCommand.Parameters["@grade"].Value = studentTakenCourse.Grade;
                adapter.SelectCommand.Parameters["@year"].Value = studentTakenCourse.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = studentTakenCourse.Quarter;

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

        public void DeleteStudentTakenCourse(string studentId, int courseId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteStudentTakenCourseProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;
                adapter.SelectCommand.Parameters["@course_id"].Value = courseId;

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

        public List<StudentTakenCourse> GetStudentTakenCourse(string studentId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentTakenCourseList = new List<StudentTakenCourse>();

            try
            {
                var adapter = new SqlDataAdapter(GetStudentTakenCourseProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var studentTakenCourse = new StudentTakenCourse
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        Grade = dataSet.Tables[0].Rows[i]["grade"].ToString(),
                        Year = (int)dataSet.Tables[0].Rows[i]["year"],
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString()
                    };
                    studentTakenCourseList.Add(studentTakenCourse);
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

            return studentTakenCourseList;
        }
    }
}
