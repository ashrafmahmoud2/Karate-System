using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Layer
{
    public class clsPaymentDateAccessLayer
    {

        public static int AddNewPayment(decimal amount, DateTime payTime, int memberID, string PayFor)
        {
            int paymentID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            INSERT INTO [dbo].[Payments]
            ([Amount]
            ,[PayTime]
            ,[MemberID]
            ,[PayFor])
            VALUES
            (@Amount, @PayTime, @MemberID, @PayFor);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@PayTime", payTime);
                        cmd.Parameters.AddWithValue("@MemberID", memberID);
                        cmd.Parameters.AddWithValue("@PayFor", PayFor);

                        // Use ExecuteScalar to get the identity value of the newly inserted row
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            paymentID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        // Handle the exception or log it as needed
                    }
                }
            }

            return paymentID;
        }


        public static bool DeletePayment(int paymentID)
            {
                bool success = false;

                using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
                {
                    string query = @"
                    DELETE FROM Payments WHERE PaymentID = @PaymentID;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if any rows were affected (Payment record was deleted)
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

        public static bool UpdatePayment(int paymentID, decimal amount, DateTime payTime, int memberID, string PayFor)
        {
            bool isUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            UPDATE [dbo].[Payments]
            SET [Amount] = @Amount,
                [PayTime] = @PayTime,
                [MemberID] = @MemberID,
                [PayFor] = @PayFor
            WHERE [PaymentID] = @PaymentID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@PayTime", payTime);
                        cmd.Parameters.AddWithValue("@MemberID", memberID);
                        cmd.Parameters.AddWithValue("@PayFor", PayFor);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            isUpdate = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        // Handle the exception or log it as needed
                    }
                }
            }

            return isUpdate;
        }

        public static bool GetPaymentInfo(int paymentID, ref decimal amount, ref DateTime payTime, ref int memberID,ref string PayFor)
            {
                bool isFound = false;

                using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
                {
                    string query = @"SELECT * FROM Payments WHERE PaymentID = @PaymentID;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                isFound = true;
                                amount = Convert.ToDecimal(reader["Amount"]);
                                payTime = Convert.ToDateTime(reader["PayTime"]);
                                memberID = Convert.ToInt32(reader["MemberID"]);
                            PayFor =reader ["PayFor"].ToString();
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

      public static bool IsPaymentExists(int paymentID)
            {
                bool isExists = false;

                using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
                {
                    string query = @"SELECT COUNT(*) FROM Payments WHERE PaymentID = @PaymentID;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PaymentID", paymentID);

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
      public static int GetTotalPayment()
        {
            int totalPayment = 0;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM Payments;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        totalPayment = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while getting the total payment count: " + ex.Message);
                    }
                }
            }

            return totalPayment;
        }

  

        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();
            string query = @"
 select *From PaymetnDetailsView;";



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

        public static DataView GetPaymentByID(int ID)
        {
            DataView paymentDataView = new DataView();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = " select *From PaymetnDetailsView WHERE PaymentID = @ID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@ID", ID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Payment");

                        paymentDataView = dataSet.Tables["Payment"].DefaultView;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while getting payment by ID: " + ex.Message);
                    }
                }
            }

            return paymentDataView;
        }

        public static DataView GetPaymentByMemberName(string memberName)
        {
            DataView paymentDataView = new DataView();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "select *From PaymetnDetailsView WHERE  MameberName= = @MemberName;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberName", memberName);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Payment");

                        paymentDataView = dataSet.Tables["Payment"].DefaultView;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while getting payment by member name: " + ex.Message);
                    }
                }
            }

            return paymentDataView;
        }

        public static DataView GetPaymentByDateTime(DateTime payTime)
        {
            DataView paymentsDataView = new DataView();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "	select *From PaymetnDetailsView WHERE  PayTime= @PayTime;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@PayTime", payTime);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Payments");

                        paymentsDataView = dataSet.Tables["Payments"].DefaultView;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while getting payments by date: " + ex.Message);
                    }
                }
            }

            return paymentsDataView;
        }

        public static DataView GetAllPaymentsForMember(int memberID)
        {
            DataView paymentsDataView = new DataView();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "\t\tselect *From PaymetnDetailsView WHERE  MemberID= @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberID", memberID); // Corrected parameter name

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Payments");

                        paymentsDataView = dataSet.Tables["Payments"].DefaultView;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while getting payments by date: " + ex.Message);
                    }
                }
            }

            return paymentsDataView;
        }



    }
}

