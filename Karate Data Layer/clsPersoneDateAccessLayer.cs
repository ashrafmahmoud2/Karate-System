using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Layer
{
    public class clsPersoneDateAccessLayer
    {
        public static int AddNewPerson(string name, string address, string phone, DateTime dateOfBirth, string ImagePath)
        {
            int personID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"INSERT INTO [dbo].[Persones]
                                   ([Name]
                                   ,[Address]
                                   ,[Phone]
                                   ,[DateOFBirth]
                                   ,[ImagePath])
                             VALUES
                                   (@Name
                                   ,@Address
                                   ,@Phone
                                   ,@DateOfBirth
                                   ,@ImagePath);

                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

                        personID = Convert.ToInt32(cmd.ExecuteScalar());
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

            return personID;
        }

        

        public static bool DeletePerson(int PersoneID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"DELETE FROM Persones WHERE [PersoneID] = @PersoneID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@PersoneID", PersoneID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (person was deleted)
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

        public static bool UpdatePerson(int PersoneID, string Name, string Address, string Phone,
            DateTime DateOFBirth, string ImagePath)
        {
            bool isUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"UPDATE [dbo].[Persones]
                        SET [Name] = @Name
                            ,Address = @Address
                            ,[Phone] = @Phone
                            ,[DateOFBirth] = @DateOFBirth
                            ,[ImagePath] = @ImagePath
                        WHERE [PersoneID] = @PersoneID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@PersoneID", PersoneID);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Phone", Phone);
                        cmd.Parameters.AddWithValue("@DateOFBirth", DateOFBirth);
                        cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        isUpdate = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return isUpdate;
        }

        public static bool GetPersoneInfo(int PersonID, ref string name, ref string address, ref string phone, ref DateTime dateOfBirth, ref string ImagePath)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT Persones.*
                         FROM Persones 
                         WHERE PersoneID = @PersonID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                name = reader["Name"].ToString();
                                address = reader["Address"].ToString();
                                phone = reader["Phone"].ToString();
                                dateOfBirth = Convert.ToDateTime(reader["DateOFBirth"]);
                                ImagePath = reader["ImagePath"].ToString(); // Added line for ImagePath
                                isFound = true;
                            }
                        }
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

            return isFound;
        }

        public static bool IsPersonExists(int PersoneID)
        {
            bool IsExists = false;

            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"SELECT found=2 FROM Persones WHERE PersoneID = @PersoneID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersoneID", PersoneID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    IsExists = true;
                else
                    IsExists = false;


            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                connection.Close();
            }
            return IsExists;
        }

        public static DataView GetAllPersones()
        {
            DataView data = new DataView();
            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"SELECT * FROM Persones;";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Assuming data is a DataTable or DataSet where you want to store the results
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                data = new DataView(dataTable);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                connection.Close();
            }

            return data;
        }




    }

}

