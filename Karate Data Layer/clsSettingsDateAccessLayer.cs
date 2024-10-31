using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Karate_Data_Layer
{
    public class clsSettingsDateAccessLayer
    {
        public static byte DefaultSubscriptionPeriod()
        {
            byte defaultPeriod = 0;

            string query = "SELECT Settings.DefaultSubscriptionPeriod FROM Settings";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            defaultPeriod = Convert.ToByte(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return defaultPeriod;
        }

        public static byte DefaultTestPeriod()
        {
            byte defaultTestPeriod = 0;

            string query = "SELECT Settings.[Default test Period] FROM Settings";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            defaultTestPeriod = Convert.ToByte(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return defaultTestPeriod;
        }
    }
}
