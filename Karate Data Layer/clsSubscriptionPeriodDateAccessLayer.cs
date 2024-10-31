using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Karate_Data_Layer
{
    public class clsSubscriptionPeriodDateAccessLayer
    {
        public static int AddNewSubscriptionPeriod(int InstrctorID, decimal Fees, DateTime StartDate, DateTime EndDate,
            int MemberID, int PaymentID, bool IsPaid, byte IssueReason, bool IsActive)
        {
            int periodID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
INSERT INTO [dbo].[subscription period]
    ([StartDate], [EndDate], [Fees], [MemberID], [InstrctorID], [PaymentID], [IsPaid], [IssueReason], [IsActive])
VALUES
    (@StartDate, @EndDate, @Fees, @MemberID, @InstrctorID, NULL, @IsPaid, @IssueReason, @IsActive);

SELECT SCOPE_IDENTITY();";

                

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@InstrctorID", InstrctorID);
                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        cmd.Parameters.AddWithValue("@Fees", Fees);
                        cmd.Parameters.AddWithValue("@MemberID", MemberID);
                        cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
                        cmd.Parameters.AddWithValue("@IsPaid", IsPaid);
                        cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);

                        periodID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return periodID;
        }

        public static bool DeleteSubscriptionPeriod(int periodID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    DELETE FROM [subscription period] WHERE PeriodID = @PeriodID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@PeriodID", periodID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (SubscriptionPeriod record was deleted)
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

        public static bool UpdateSubscriptionPeriod(int periodID, int InstrctorID, decimal Fees, DateTime StartDate, DateTime EndDate,
            int MemberID, int PaymentID, bool IsPaid, byte IssueReason, bool IsActive)
        {
            bool isUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
UPDATE [dbo].[subscription period] 
                              SET [StartDate] = @StartDate, 
                              [EndDate] = @EndDate, 
                              [Fees] = @Fees, 
                              [MemberID] = @MemberID, 
                              [InstrctorID] = @InstrctorID, 
                              [PaymentID] = @PaymentID, 
                              [IsPaid] = @IsPaid, 
                              [IssueReason] = @IssueReason, 
                              [IsActive] = @IsActive 
                              WHERE [periodID] = @PeriodID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@StartDate", StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                        cmd.Parameters.AddWithValue("@Fees", Fees);
                        cmd.Parameters.AddWithValue("@MemberID", MemberID);
                        cmd.Parameters.AddWithValue("@InstrctorID", InstrctorID);
                        cmd.Parameters.AddWithValue("@PaymentID", PaymentID);
                        cmd.Parameters.AddWithValue("@IsPaid", IsPaid);
                        cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@PeriodID", periodID);

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

        public static bool GetSubscriptionPeriodInfo(int periodID, ref int InstructorID, ref decimal fees, ref DateTime startDate, ref DateTime
            endDate, ref int memberID, ref int paymentID, ref bool isPaid, ref byte issueReason, ref bool isActive)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM [subscription period] WHERE PeriodID = @PeriodID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PeriodID", periodID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;
                            InstructorID = Convert.ToInt32(reader["InstrctorID"]);
                            fees = Convert.ToDecimal(reader["Fees"]);
                            startDate = Convert.ToDateTime(reader["StartDate"]);
                            endDate = Convert.ToDateTime(reader["EndDate"]);
                            memberID = Convert.ToInt32(reader["MemberID"]);
                            paymentID = Convert.ToInt32(reader["PaymentID"]);
                            isPaid = Convert.ToBoolean(reader["IsPaid"]);
                            issueReason = (byte)(reader["IssueReason"]);
                            isActive = Convert.ToBoolean(reader["IsActive"]);

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


        public static bool IsSubscriptionPeriodExists(int periodID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT 1 FROM [subscription period] WHERE PeriodID = @PeriodID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PeriodID", periodID);

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

        public static DataTable GetAllscriptionPeriod()
        {
            DataTable dt = new DataTable();
            string query = @"
select *from SuscriptionPeruodeView;";



            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return dt;
        }

        public static DataView GetSubscriptionPeriodByMemberID(int memberID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT Persones.Name, [subscription period].*
            FROM [subscription period]
            INNER JOIN Members ON [subscription period].MemberID = Members.MemberID
            INNER JOIN Persones ON Members.PersoneID = Persones.PersoneID
            WHERE [subscription period].MemberID = @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberID", memberID);

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

        public static DataView GetSubscriptionPeriodByMemberName(string name)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT Persones.Name, [subscription period].*
            FROM [subscription period]
            INNER JOIN Members ON [subscription period].MemberID = Members.MemberID
            INNER JOIN Persones ON Members.PersoneID = Persones.PersoneID
            WHERE Persones.Name = @Name;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@Name", name);

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

        public static DataView GetPayedSubscriptionPeriods()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT Persones.Name, [subscription period].*
            FROM [subscription period]
            INNER JOIN Members ON [subscription period].MemberID = Members.MemberID
            INNER JOIN Persones ON Members.PersoneID = Persones.PersoneID
            WHERE IsPaid = 1;";

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

        public static int GetTotalSubscriptionPeriodCount()
        {
            int count = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM [subscription period];";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return count;
        }

        public static int GetPeriodIDByPaymentID(int paymentID)
        {
            int periodID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT [subscription period].periodID FROM [subscription period] WHERE PaymentID = @paymentID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@paymentID", paymentID);

                        // Execute the command and retrieve the result
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if there are rows in the result
                            if (reader.Read())
                            {
                                // Retrieve the periodID from the result
                                periodID = Convert.ToInt32(reader["periodID"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return periodID;
        }

        public static DataView GetAllSubscriptionForMembers(int memberID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM SuscriptionPeruodeView WHERE MemberID = @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberID", memberID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return dataTable.DefaultView;
        }

        public static int GetLastActivePeriodIDForMember(int MemberID)
        {
            int LastActiveperiodID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT TOP 1 periodID
            FROM [subscription period]
            WHERE EndDate IS NOT NULL
                AND MemberID = @MemberID
            ORDER BY EndDate DESC;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberID", MemberID);

                        // Execute the command and retrieve the result
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if there are rows in the result
                            if (reader.Read())
                            {
                                // Retrieve the periodID from the result
                                LastActiveperiodID = Convert.ToInt32(reader["periodID"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return LastActiveperiodID;
        }

        public static bool UpdateActivityAndIsPaid(int PeriodID, bool IsPaid, bool IsActive)
        {
            bool IsUpdated = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            UPDATE [subscription period]
            SET IsActive = @IsActive, IsPaid = @IsPaid
            WHERE periodID = @PeriodID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@PeriodID", PeriodID);
                        cmd.Parameters.AddWithValue("@IsPaid", IsPaid);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);

                        // Execute the update command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (updated)
                        if (rowsAffected > 0)
                        {
                            IsUpdated = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return IsUpdated;
        }

        public static void UpdateSubscriptionsStatusAndMembers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
                {
                    connection.Open();
                    

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // SQL query to update subscriptions and member details
                            string query = @"
                        
UPDATE SuscriptionPeruodeView
SET IsPaid = 0, IsActive = 0
WHERE EndDate <=  CAST(GETDATE() AS Date);
UPDATE MemberDetailsview
SET IsActive = 0
WHERE MemberID IN (SELECT MemberID FROM SuscriptionPeruodeView WHERE EndDate = CAST(GETDATE() AS Date));


UPDATE SuscriptionPeruodeView
SET IsActive = CASE WHEN IsPaid = 1 AND StartDate >= CAST(GETDATE() AS Date) THEN 1 ELSE IsActive END;

-- Activate Members based on Subscription Period
UPDATE MemberDetailsview
SET IsActive = 1
WHERE MemberID IN (SELECT MemberID FROM SuscriptionPeruodeView WHERE StartDate >= CAST(GETDATE() AS Date) AND IsPaid = 1);
                    ";

                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                int rowsAffected = command.ExecuteNonQuery();

                                // Optionally, you can check the number of rows affected and handle accordingly
                                Console.WriteLine($"Total rows affected: {rowsAffected}");

                                transaction.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            // An error occurred, log the exception
                          
                            transaction.Rollback();

                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Outer exception: {ex.Message}");
            }
        }



    }
}