namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class EnrollmentRuleRepository : BaseRepository, IEnrollmentRuleRepository
    {
        private const string InsertEnrollmentRuleProcedure = "spInsertEnrollmentRule";
        private const string UpdateEnrollmentRuleProcedure = "spUpdateEnrollmentRule";
        private const string DeleteEnrollmentRuleProcedure = "spDeleteEnrollmentRule";
        private const string GetEnrollmentRuleProcedure = "spGetEnrollmentRule";

        public void InsertEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertEnrollmentRuleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@minimum_unit", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@maximum_unit", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@drop_wo_w_deadline", SqlDbType.Time, 7));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@drop_wo_f_deadline", SqlDbType.Time, 7));

                adapter.SelectCommand.Parameters["@minimum_unit"].Value = enrollmentRule.MinimumUnit;
                adapter.SelectCommand.Parameters["@maximum_unit"].Value = enrollmentRule.MaximumUnit;
                adapter.SelectCommand.Parameters["@drop_wo_w_deadline"].Value = enrollmentRule.DropWoWDeadline;
                adapter.SelectCommand.Parameters["@drop_wo_f_deadline"].Value = enrollmentRule.DropWoFDeadline;

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

        public void UpdateEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateEnrollmentRuleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@minimum_unit", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@maximum_unit", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@drop_wo_w_deadline", SqlDbType.Date));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@drop_wo_f_deadline", SqlDbType.Date));

                adapter.SelectCommand.Parameters["@minimum_unit"].Value = enrollmentRule.MinimumUnit;
                adapter.SelectCommand.Parameters["@maximum_unit"].Value = enrollmentRule.MaximumUnit;
                adapter.SelectCommand.Parameters["@drop_wo_w_deadline"].Value = enrollmentRule.DropWoWDeadline;
                adapter.SelectCommand.Parameters["@drop_wo_f_deadline"].Value = enrollmentRule.DropWoFDeadline;

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

        public void DeleteEnrollmentRule(EnrollmentRule enrollmentRule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(DeleteEnrollmentRuleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

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

        public List<EnrollmentRule> GetEnrollmentRuleList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var enrollmentRuleList = new List<EnrollmentRule>();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrollmentRuleProcedure, conn)
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
                    var enrollmentRule = new EnrollmentRule
                    {
                        MinimumUnit = (int)dataSet.Tables[0].Rows[i]["minimum_unit"],
                        MaximumUnit = (int)dataSet.Tables[0].Rows[i]["maximum_unit"],
                        DropWoWDeadline = dataSet.Tables[0].Rows[i]["drop_wo_w_deadline"].ToString(),
                        DropWoFDeadline = dataSet.Tables[0].Rows[i]["drop_wo_f_deadline"].ToString()
                    };
                    enrollmentRuleList.Add(enrollmentRule);
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

            return enrollmentRuleList;
        }
    }
}
