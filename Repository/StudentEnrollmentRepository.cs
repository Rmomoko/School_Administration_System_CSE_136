namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class StudentEnrollmentRepository : BaseRepository, IStudentEnrollmentRepository
    {
        private const string InsertStudentScheduleProcedure = "spInsertStudentSchedule";
        private const string DeleteStudentScheduleProcedure = "spDeleteStudentSchedule";
        private const string GetStudentEnrollmentProcedure = "spGetStudentEnrollment";
        private const string GetStudentEnrollListProcedure = "spGetStudentEnrollList";

        public void EnrollSchedule(string studentId, int scheduleId, string grade_option, int pre_req_status, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(InsertStudentScheduleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@grade_option", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@pre_req_status", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;
                adapter.SelectCommand.Parameters["@grade_option"].Value = grade_option;
                adapter.SelectCommand.Parameters["@pre_req_status"].Value = pre_req_status;

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

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteStudentScheduleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;
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

        public List<StudentEnrollment> GetStudentEnrollList(int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentEnrollmentList = new List<StudentEnrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetStudentEnrollListProcedure, conn);

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

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
                    var studentEnrollList = new StudentEnrollment
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseId = (int)dataSet.Tables[0].Rows[i]["course_id"],
                        GradeOption = dataSet.Tables[0].Rows[i]["grade_option"].ToString(),
                        PrereqStatus = (int)dataSet.Tables[0].Rows[i]["pre_req_status"]
                    };
                    studentEnrollmentList.Add(studentEnrollList);
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

            return studentEnrollmentList;
        }

        public List<StudentEnrollment> GetEnrollments(string studentId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentEnrollmentList = new List<StudentEnrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetStudentEnrollmentProcedure, conn);

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

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
                    var studentEnrollment = new StudentEnrollment
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        GradeOption = dataSet.Tables[0].Rows[i]["grade_option"].ToString(),
                        PrereqStatus = (int)dataSet.Tables[0].Rows[i]["pre_req_status"]
                    };
                    studentEnrollmentList.Add(studentEnrollment);
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

            return studentEnrollmentList;
        }
    }
}
