namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class AdminRepository : BaseRepository, IAdminRepository
    {
        private const string UpdateAdminInfoProcedure = "spUpdateAdminInfo";
        private const string GetAdminInfoProcedure = "spGetAdminInfo";

        public Admin GetAdminInfo(int adminId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Admin admin = null;

            try
            {
                var adapter = new SqlDataAdapter(GetAdminInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@admin_id"].Value = adminId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                admin = new Admin
                {
                    Id = (int)dataSet.Tables[0].Rows[0]["admin_id"],
                    FirstName = dataSet.Tables[0].Rows[0]["firstName"].ToString(),
                    LastName = dataSet.Tables[0].Rows[0]["lastName"].ToString(),
                    Email = dataSet.Tables[0].Rows[0]["email"].ToString(),
                    Password = dataSet.Tables[0].Rows[0]["password"].ToString()
                };
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return admin;
        }

        public void UpdateAdminInfo(Admin admin, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(UpdateAdminInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin.Id;
                adapter.SelectCommand.Parameters["@firstName"].Value = admin.FirstName;
                adapter.SelectCommand.Parameters["@lastName"].Value = admin.LastName;

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
