namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class InstructorRepository : BaseRepository, IInstructorRepository
    {
        private const string UpdateInstructorInfoProcedure = "spUpdateInstructorInfo";
        private const string GetInstructorInfoProcedure = "spGetInstructorInfo";

        public Instructor GetInstructorInfo(int instructorId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Instructor instructor = null;

            try
            {
                var adapter = new SqlDataAdapter(GetInstructorInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructorId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                instructor = new Instructor
                {
                    Id = (int)dataSet.Tables[0].Rows[0]["instructor_id"],
                    FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString(),
                    LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString(),
                    Title = dataSet.Tables[0].Rows[0]["title"].ToString(),
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

            return instructor;
        }

        public void UpdateInstructorInfo(Instructor instructor, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(UpdateInstructorInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructor.Id;
                adapter.SelectCommand.Parameters["@first_name"].Value = instructor.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = instructor.LastName;

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
