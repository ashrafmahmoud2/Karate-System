using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Karate_Data_Layer
{
    public class clsBeltTestDateAccessLayer
    {
        public static int AddNewBeltTest(int MemberID, int RankID, bool Result, DateTime Date,
            int TestByInstrectorID, int PaymetID)
        {
            int testID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            INSERT INTO [dbo].[BeltTests]
                       ([MemberID]
                       ,[RankID]
                       ,[Result]
                       ,[Date]
                       ,[TestByInstrectorID]
                       ,[PaymetID])
                 VALUES
                       (@MemberID,
                        @RankID,
                        @Result,
                        @Date,
                        @TestByInstrectorID,
                        @PaymetID);
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberID", MemberID);
                        cmd.Parameters.AddWithValue("@RankID", RankID);
                        cmd.Parameters.AddWithValue("@Result", Result);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@TestByInstrectorID", TestByInstrectorID);
                        cmd.Parameters.AddWithValue("@PaymetID", PaymetID);

                        testID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message,"Error is in");
                    }
                }
            }

            return testID;
        }


        public static bool DeleteBeltTest(int testID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    DELETE FROM BeltTests WHERE TestID = @TestID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@TestID", testID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (BeltTest record was deleted)
                        success = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return success;
        }

        public static bool UpdateBeltTest(int testID, int memberID, int rankID, bool result, DateTime date, int testByInstructorID, int paymentID)
        {
            bool isUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    UPDATE [dbo].[BeltTests]
                    SET [MemberID] = @MemberID
                        ,[RankID] = @RankID
                        ,[Result] = @Result
                        ,[Date] = @Date
                        ,[TestByInstructorID] = @TestByInstructorID
                        ,[PaymentID] = @PaymentID
                    WHERE [TestID] = @TestID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@TestID", testID);
                        cmd.Parameters.AddWithValue("@MemberID", memberID);
                        cmd.Parameters.AddWithValue("@RankID", rankID);
                        cmd.Parameters.AddWithValue("@Result", result);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@TestByInstructorID", testByInstructorID);
                        cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            isUpdate = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isUpdate;
        }

        public static bool GetBeltTestInfo(int testID, ref int memberID, ref int RankID, 
            ref bool Result, ref DateTime Date, ref int TestByInstructorID, ref int PaymentID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM BeltTests WHERE TestID = @TestID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TestID", testID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;
                            //stop in fix show details;

                            memberID = Convert.ToInt32(reader["MemberID"]);
                            RankID = Convert.ToInt32(reader["RankID"]);

                            Result = Convert.ToBoolean(reader["Result"]);
                            Date = Convert.ToDateTime(reader["Date"]);
                            TestByInstructorID = Convert.ToInt32(reader["TestByInstrectorID"]);

                        PaymentID = Convert.ToInt32(reader["PaymetID"]);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static bool IsBeltTestExists(int testID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM BeltTests WHERE TestID = @TestID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TestID", testID);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        isExists = count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred during existence check: " + ex.Message);
                    }
                }
            }

            return isExists;
        }


        public static DataTable GetAllBeltTests()
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT * FROM BeltTestView;";
            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataTable.Load(reader);
                }


            }
            catch (Exception ex)
            {
                // Handle exceptions (log or throw, depending on your needs)
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static DataView GetAllBeltTestsForMember(int MemberID)
        {
            DataView dataView = new DataView();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM BeltTestView WHERE MemberID = @MemberID;";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@MemberID", MemberID);

                    try
                    {
                        connection.Open();
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataView = new DataView(dataTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while fetching data: " + ex.Message);
                    }
                }
            }

            return dataView;
        }

        public static int GetBeltTestsByPaymentID(int PaymentID)
        {
            int TestID = 0;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT TestID FROM BeltTestView WHERE PaymentID = @PaymentID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", PaymentID);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();

                        // Check if the result is not null before converting to int
                        if (result != null && result != DBNull.Value)
                        {
                            TestID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while fetching data: " + ex.Message);
                    }
                }
            }

            return TestID;
        }


    }
}
