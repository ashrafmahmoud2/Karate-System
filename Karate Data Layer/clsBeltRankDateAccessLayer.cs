using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Layer
{
    public class clsBeltRankDateAccessLayer
    {
        public static int AddNewBeltRank(string rankName, decimal testFees)
        {
            int rankID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    INSERT INTO [dbo].[Beltranks]
                        ([RankName], [TestFees])
                    VALUES
                        (@RankName, @TestFees);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@RankName", rankName);
                        cmd.Parameters.AddWithValue("@TestFees", testFees);

                        rankID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return rankID;
        }

        public static bool DeleteBeltRank(int rankID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    DELETE FROM Beltranks WHERE RankID = @RankID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@RankID", rankID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (BeltRank record was deleted)
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

        public static bool UpdateBeltRank(int rankID, string rankName, decimal testFees)
        {
            bool isUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    UPDATE [dbo].[Beltranks]
                    SET [RankName] = @RankName
                        ,[TestFees] = @TestFees
                    WHERE [RankID] = @RankID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@RankID", rankID);
                        cmd.Parameters.AddWithValue("@RankName", rankName);
                        cmd.Parameters.AddWithValue("@TestFees", testFees);

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

        public static bool GetBeltRankInfo(int rankID, ref string rankName, ref decimal testFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM Beltranks WHERE RankID = @RankID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@RankID", rankID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;
                            rankName = Convert.ToString(reader["RankName"]);
                            testFees = Convert.ToDecimal(reader["TestFees"]);
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

        public static bool GetBeltRankInfoByName(string rankName, ref int rankID, ref decimal testFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "SELECT * FROM Beltranks WHERE RankName = @RankName;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@RankName", rankName);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                rankID = Convert.ToInt32(reader["RankID"]);
                                testFees = Convert.ToDecimal(reader["TestFees"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return isFound;
        }


        public static bool IsBeltRankExists(int rankID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM Beltranks WHERE RankID = @RankID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@RankID", rankID);

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

        public static List<string> GetAllRankNames()
        {
            List<string> rankNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "SELECT RankName FROM Beltranks;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string rankName = reader["RankName"].ToString();
                            rankNames.Add(rankName);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while retrieving rank names: " + ex.Message);
                    }
                }
            }

            return rankNames;
        }

        public static string GetRankNameByRankID(int RankID)
        {
            string rankName = "";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "SELECT RankName FROM beltranks WHERE RankID = @RankID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@RankID", RankID);
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read()) // Check if there are rows to read
                        {
                            rankName = reader["RankName"].ToString();
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while retrieving rank names: " + ex.Message);
                    }
                }
            }

            return rankName;
        }

        public static DataView GetAllBeltRank()
        {
            DataTable dataTable = new DataTable(); // Assuming you have a DataTable to store the result

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM beltranks;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dataTable.DefaultView;
        }



        public static int GetNextBeltRankID(int rankID)
        {
            int nextRankID = 0;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT TOP 1 RankID FROM Beltranks WHERE RankID > @RankID ORDER BY RankID;
        ";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@RankID", rankID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                nextRankID = reader.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return nextRankID;
        }

    }

}
