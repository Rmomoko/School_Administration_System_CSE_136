namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class PrereqOverrideRepository : BaseRepository, IPrereqOverrideRepository
    {
        private const string InsertPrereqOverrideProcedure = "spInsertPrereqOverride";
        private const string UpdatePrereqOverrideProcedure = "spUpdatePrereqOverride";
        private const string GetPrereqOverrideProcedure = "spGetPrereqOverride";
        private const string GetAllPrereqOverrideProcedure = "spGetAllPrereqOverride";
        
        public void InsertPrereqOverride(PrereqOverride prereq, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertPrereqOverrideProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prof_pre_req_override_status", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_pre_req_override_status", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = prereq.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = prereq.ScheduleId;
                adapter.SelectCommand.Parameters["@prof_pre_req_override_status"].Value = prereq.ProfPrereqOverrideStatus;
                adapter.SelectCommand.Parameters["@admin_pre_req_override_status"].Value = prereq.AdminPrereqOverrideStatus;

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

        public void UpdatePrereqOverride(PrereqOverride prereq, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdatePrereqOverrideProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prof_pre_req_override_status", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_pre_req_override_status", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = prereq.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = prereq.ScheduleId;
                adapter.SelectCommand.Parameters["@prof_pre_req_override_status"].Value = prereq.ProfPrereqOverrideStatus;
                adapter.SelectCommand.Parameters["@admin_pre_req_override_status"].Value = prereq.AdminPrereqOverrideStatus;

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

        public List<PrereqOverride> GetPrereqOverride(int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var prereqList = new List<PrereqOverride>();

            try
            {
                var adapter = new SqlDataAdapter(GetPrereqOverrideProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
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
                    var prereq = new PrereqOverride
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        ProfPrereqOverrideStatus = (int)dataSet.Tables[0].Rows[i]["prof_pre_req_override_status_flag"],
                        AdminPrereqOverrideStatus = (int)dataSet.Tables[0].Rows[i]["admin_pre_req_override_status_flag"]
                    };
                    prereqList.Add(prereq);
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

            return prereqList;
        }

        public List<PrereqOverride> GetAllPrereqOverride(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var prereqList = new List<PrereqOverride>();

            try
            {
                var adapter = new SqlDataAdapter(GetAllPrereqOverrideProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var prereq = new PrereqOverride
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = (int)dataSet.Tables[0].Rows[i]["schedule_id"],
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        ProfPrereqOverrideStatus = (int)dataSet.Tables[0].Rows[i]["prof_pre_req_override_status_flag"],
                        AdminPrereqOverrideStatus = (int)dataSet.Tables[0].Rows[i]["admin_pre_req_override_status_flag"]
                    };
                    prereqList.Add(prereq);
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

            return prereqList;
        }
    }
}
