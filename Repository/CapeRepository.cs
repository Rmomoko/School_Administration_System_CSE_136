namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class CapeRepository : BaseRepository, ICapeRepository
    {
        private const string InsertCapeDataProcedure = "spInsertCapeData";
        private const string UpdateCapeProcedure = "spUpdateCape";
        private const string GetCapeListProcedure = "spGetCape";

        public void InsertCapeData(Cape cape, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertCapeDataProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@easiness", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@helpfulness", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@clarity", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@hours_spend", SqlDbType.Float));

                adapter.SelectCommand.Parameters["@course_title"].Value = cape.CourseTitle;
                adapter.SelectCommand.Parameters["@easiness"].Value = cape.Easiness;
                adapter.SelectCommand.Parameters["@helpfulness"].Value = cape.Helpfulness;
                adapter.SelectCommand.Parameters["@clarity"].Value = cape.Clarity;
                adapter.SelectCommand.Parameters["@hours_spend"].Value = cape.Hours_spend;

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

        public void UpdateCape(Cape cape, int courseId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateCapeProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@avg_easiness", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@avg_helpfulness", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@avg_clarity", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@avg_hours_spend", SqlDbType.Float));

                adapter.SelectCommand.Parameters["@course_title"].Value = cape.CourseTitle;
                adapter.SelectCommand.Parameters["@avg_easiness"].Value = cape.AvgEasiness;
                adapter.SelectCommand.Parameters["@avg_helpfulness"].Value = cape.AvgHelpfulness;
                adapter.SelectCommand.Parameters["@avg_clarity"].Value = cape.AvgClarity;
                adapter.SelectCommand.Parameters["@avg_hours_spend"].Value = cape.AvgHours_spend;

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

        public List<Cape> GetCape(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var capeList = new List<Cape>();

            try
            {
                var adapter = new SqlDataAdapter(GetCapeListProcedure, conn)
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
                    var cape = new Cape
                    {
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        AvgEasiness = (float)Convert.ToDouble(dataSet.Tables[0].Rows[i]["avg_easiness"]),
                        AvgHelpfulness = (float)Convert.ToDouble(dataSet.Tables[0].Rows[i]["avg_helpfulness"]),
                        AvgClarity = (float)Convert.ToDouble(dataSet.Tables[0].Rows[i]["avg_clarity"]),
                        AvgHours_spend = (float)Convert.ToDouble(dataSet.Tables[0].Rows[i]["avg_hours_spend"])
                    };
                    capeList.Add(cape);
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

            return capeList;
        }
    }
}
