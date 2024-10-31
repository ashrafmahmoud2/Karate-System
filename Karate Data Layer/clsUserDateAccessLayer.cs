using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Karate_Data_Layer
{
    public class clsUserDateAccessLayer
    {
        public static int AddNewUser(string username, string password, int permissions, int personeID)
        {
            int userID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    INSERT INTO [dbo].[Users]
                    ([Username], [Password], [Permissions], [PersoneID])
                    VALUES
                    (@Username, @Password, @Permissions, @PersoneID);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Permissions", permissions);
                        cmd.Parameters.AddWithValue("@PersoneID", personeID);

                        userID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return userID;
        }
        public static bool DeleteUser(int userID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"DELETE FROM Users WHERE UserID = @UserID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        int rowsAffected = cmd.ExecuteNonQuery();
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

        public static bool UpdateUser(int userID, string username, string password, int permissions, int personeID)
        {
            bool isUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
                    UPDATE [dbo].[Users]
                    SET [Username] = @Username
                       ,[Password] = @Password
                       ,[Permissions] = @Permissions
                       ,[PersoneID] = @PersoneID
                    WHERE [UserID] = @UserID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Permissions", permissions);
                        cmd.Parameters.AddWithValue("@PersoneID", personeID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        isUpdate = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isUpdate;
        }

      
        public static bool GetUserInfo(int userID, ref string username, ref string password, ref int permissions, ref int personeID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM Users WHERE UserID = @UserID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;
                            personeID = Convert.ToInt32(reader["PersoneID"]);
                            permissions = Convert.ToInt32(reader["Permissions"]);
                            username = reader["Username"].ToString();
                            password = reader["Password"].ToString();
                        }
                        else
                        {
                            isFound = false;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return isFound;
                }
            }
        }

        public static bool GetUserInfo(string userName, string password, ref int userID, ref int permissions, ref int personeID)
        {
            bool isFound = false;

            // Validate input parameters
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                // Handle invalid input
                return false;
            }

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT * FROM Users WHERE Username = @Username AND Password = @Password;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", userName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();

                        // Use using statement for SqlDataReader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                userID = Convert.ToInt32(reader["UserID"]);
                                personeID = Convert.ToInt32(reader["PersoneID"]);
                                permissions = Convert.ToInt32(reader["Permissions"]);
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception details for better tracking
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return isFound;
                }
            }
        }


        public static bool IsUserExists(int userID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT found=1 FROM Users WHERE UserID = @UserID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        isExists = count > 0;
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

            return isExists;
        }

        public static bool IsUserExists(string userName)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT 1 FROM UserDetailsView WHERE Username = @Username;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", userName);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        isExists = count > 0;
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

            return isExists;
        }

        public static int GetPersoneIDByUserID(int userID)
        {
            int personeID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT PersoneID FROM Users WHERE UserID = @UserID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            personeID = Convert.ToInt32(result);
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

            return personeID;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            string query = @"
select  * From UserDetailsView";

             SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
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



        public static int GetTotalUsers()
        {
            int totalUsers = 0;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM Users";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        totalUsers = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return totalUsers;
        }

        public static DataView GetUsersByName(string name)
        {
            string query = @"
        SELECT Persones.Name, Persones.PersoneID, Users.UserID, Users.Username, Users.PassWord, Users.permissions, Users.PersoneID AS Expr1, Persones.Address, Persones.Phone, Persones.DateOFBirth
        FROM Persones
        INNER JOIN Users ON Persones.PersoneID = Users.PersoneID
        WHERE Username = @Name
    ";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "UsersData");
                        return dataSet.Tables["UsersData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetUsersByUserID(int userID)
        {
            string query = @"
        SELECT Persones.Name, Persones.PersoneID, Users.UserID, Users.Username, Users.PassWord, Users.permissions, Users.PersoneID AS Expr1, Persones.Address, Persones.Phone, Persones.DateOFBirth
        FROM Persones
        INNER JOIN Users ON Persones.PersoneID = Users.PersoneID
        WHERE UserID = @UserID
    ";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "UsersData");
                        return dataSet.Tables["UsersData"].DefaultView;
                    }
                }
            }
        }

        public static bool IsUserExists(string UserName, string Password)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT  *FROM Users WHERE Username = @UserName AND PassWord = @Password;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        isExists = count > 0;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isExists;
        }

        public static bool IsUserExistswhiteGetUserID(string userName, string password, ref int userID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "SELECT found=1 FROM Users WHERE Username = @UserName AND PassWord = @Password;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            isExists = true;

                            // Retrieve userID
                            string getUserIdQuery = "SELECT UserID FROM Users WHERE Username = @UserName AND PassWord = @Password;";
                            using (SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery, connection))
                            {
                                getUserIdCmd.Parameters.AddWithValue("@UserName", userName);
                                getUserIdCmd.Parameters.AddWithValue("@Password", password);

                                userID = Convert.ToInt32(getUserIdCmd.ExecuteScalar());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isExists;
        }

        //static void Main(string[] args)
        //{




        //    Console.ReadLine();
        //}


    }
}