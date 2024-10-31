using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Layer
{
    public class clsMemberInstructorDateAccessLayer
    {
        public static int AddNewMemberInstructor(int InstractorID, int MemberID, DateTime AssignDate)
        {
            int MemberInstructorID = -1;

            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"
                INSERT INTO [dbo].[MemberInstractor]
                    ([InstractorID], [MemberID], [AssignDate])
                VALUES
                    (@InstractorID, @MemberID, @AssignDate);
                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@InstractorID", InstractorID);
                cmd.Parameters.AddWithValue("@MemberID", MemberID);
                cmd.Parameters.AddWithValue("@AssignDate", AssignDate);

                MemberInstructorID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return MemberInstructorID;
        }

        public static bool DeleteMemberInstructor(int MemberInstrectorID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    DELETE FROM MemberInstractor WHERE MemberInstrectorID = @MemberInstrectorID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberInstrectorID", MemberInstrectorID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (MemberInstructor record was deleted)
                        success = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return success;
        }

        public static bool UpdateMemberInstructor(int MemberInstrectorID, int InstractorID, int MemberID, DateTime AssignDate)
        {
            bool IsUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            UPDATE [dbo].[MemberInstractor]
            SET [InstractorID] = @InstractorID
                ,[MemberID] = @MemberID
                ,[AssignDate] = @AssignDate
            WHERE [MemberInstrectorID] = @MemberInstrectorID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@MemberInstrectorID", MemberInstrectorID);
                        cmd.Parameters.AddWithValue("@InstractorID", InstractorID);
                        cmd.Parameters.AddWithValue("@MemberID", MemberID);
                        cmd.Parameters.AddWithValue("@AssignDate", AssignDate);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            IsUpdate = true;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return IsUpdate;
        }

        public static bool GetMemberInstructorInfo(int MemberInstructorID, ref int InstructorID, ref int MemberID, ref DateTime AssignDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"SELECT * FROM MemberInstractor WHERE MemberInstrectorID = @MemberInstructorID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@MemberInstructorID", MemberInstructorID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    InstructorID = Convert.ToInt32(reader["InstractorID"]);
                    MemberID = Convert.ToInt32(reader["MemberID"]);
                    AssignDate = Convert.ToDateTime(reader["AssignDate"]);
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsMemberInstructorExists(int MemberInstructorID)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    SELECT found=2 FROM MemberInstractor WHERE MemberInstrectorID = 1
;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MemberInstructorID", MemberInstructorID);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        IsExists = count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return IsExists;
        }

        public static int GetTotalMemberInstructors()
        {
            int totalMemberInstructors = 0;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM MemberInstractor";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        totalMemberInstructors = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                }
            }

            return totalMemberInstructors;
        }

        public static bool IsInstructorTraningthisMember(int InstructorID, int MemberID)
        {
            bool IsTraning = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                        SELECT TOP 1 found = 1 
                        FROM MemberInstractor 
                        WHERE InstractorID = @InstructorID AND MemberID = @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                    cmd.Parameters.AddWithValue("@MemberID", MemberID);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        IsTraning = count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return IsTraning;
        }


        public static DataView GetAllMemberInstructors()
        {
            string query = @"
               SELECT *FROM MemberInstractor";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "MemberInstructorsData");
                        return dataSet.Tables["MemberInstructorsData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetMemberMemberInstructorsByMemberID(int memberID)
        {
            string query = @"
       SELECT *FROM MemberInstractor where MemberID= @MemberID";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "MembersData");
                        return dataSet.Tables["MembersData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetMemberInstructorsByInstractorID(int InstractorID)
        {
            string query = @"
        SELECT *FROM MemberInstractor where InstractorID = @InstractorID";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@InstractorID", InstractorID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "InstructorsData");
                        return dataSet.Tables["InstructorsData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetMemberInstructorByAssineData(DateTime assignDate)
        {
            string query = @"
        SELECT *FROM MemberInstractor where AssignDate = @AssignDate";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AssignDate", assignDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "MemberInstructorsData");
                        return dataSet.Tables["MemberInstructorsData"].DefaultView;
                    }
                }
            }
        }
        public static DataView GetTrainedMembersByInstructor(int InstructorID)
        {
            DataView data = new DataView();
            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);
            string query = @"
        SELECT MemberDetailsview.*
        FROM MemberInstructor
        INNER JOIN MemberDetailsview ON MemberDetailsview.MemberID = MemberInstructor.MemberID
        WHERE MemberInstructor.InstructorID = @InstructorID
        ORDER BY MemberDetailsview.MemberID DESC;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@InstructorID", InstructorID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Assuming data is a DataTable, create a DataTable to load the reader data
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Assign the DataTable to the DataView
                data.Table = dataTable;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                Console.WriteLine($"Error in GetTrainedMembersByInstructor: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed, even in case of an exception
                if (data != null)
                {
                    data.Table?.Dispose(); // Dispose of the underlying DataTable if it exists
                    data.Dispose(); // Dispose of the DataView
                }

                // Close the reader and connection in the finally block
                cmd?.Dispose();
                connection?.Close();
                connection?.Dispose();
            }

            return data;
        }









    }
}
