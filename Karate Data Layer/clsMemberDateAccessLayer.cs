using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krate_business_Layer
{
    public class clsMemberDateAccessLayer
    {
        public static int AddNewMember(int PersoneID, string EmergenceContect, int LastRenkID, bool IsActive, string Password, bool AskToTest)
        {
            int MemberID = -1;

            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"
    INSERT INTO [dbo].[Members]
    ([PersoneID],[EmergenceContect],[LastRenkID],[IsActive],[Password],[AskToTest])
    VALUES
    (@PersoneID,@EmergenceContect,@LastRenkID,@IsActive,@Password,@AskToTest);
    SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@PersoneID", PersoneID);
                cmd.Parameters.AddWithValue("@EmergenceContect", EmergenceContect);
                cmd.Parameters.AddWithValue("@LastRenkID", LastRenkID);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@AskToTest", AskToTest);

                MemberID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                connection.Close();
            }



            return MemberID;
        }

        public static bool DeleteMember(int MemberID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
DELETE FROM Members WHERE MemberID = @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@MemberID", MemberID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (member was deleted)
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

        public static bool UpdateMember(int MemberID, int PersoneID, string EmergenceContect,
            int LastRenkID, bool IsActive, string Password, bool AskToTest)
        {
            bool IsUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
UPDATE [dbo].[Members]
   SET [PersoneID] = @PersoneID
      ,[EmergenceContect] = @EmergenceContect
      ,[LastRenkID] = @LastRenkID
      ,[IsActive] = @IsActive
      ,[Password] = @Password
      ,[AskToTest] = @AskToTest
 WHERE [MemberID] = @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@MemberID", MemberID);
                        cmd.Parameters.AddWithValue("@PersoneID", PersoneID);
                        cmd.Parameters.AddWithValue("@EmergenceContect", EmergenceContect);
                        cmd.Parameters.AddWithValue("@LastRenkID", LastRenkID);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@AskToTest", AskToTest);

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

        public static bool GetMemberInfo(int MemberID, ref int PersoneID, ref string EmergenceContect, ref int LastRenkID, ref bool IsActive, ref string Password, ref bool AskToTest)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"SELECT * FROM Members WHERE MemberID = @MemberID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersoneID = Convert.ToInt32(reader["PersoneID"]);
                    LastRenkID = Convert.ToInt32(reader["LastRenkID"]);
                    IsActive = (bool)reader["IsActive"];
                    AskToTest = (bool)reader["AskToTest"];

                    EmergenceContect = (string)reader["EmergenceContect"];
                    Password = (string)reader["Password"];

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

        public static bool IsMemberExists(int MemberID)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
SELECT found=2 FROM Members WHERE MemberID = @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static int GetPersoneIDByMemberID(int MemberID)
        {
            int PersoneID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
SELECT PersoneID FROM Members WHERE MemberID = @MemberID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MemberID", MemberID);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            PersoneID = Convert.ToInt32(result);
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

            return PersoneID;
        }

        public static DataView GetAllMembers()
        {
            string query = @"
        select *From MemberDetailsview";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "MembersData");
                        return dataSet.Tables["MembersData"].DefaultView;
                    }
                }
            }
        }

        public  static DataTable GetAllMembers1()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT * FROM MemberDetailsview";
            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return dt;
        }
    




    public static int GetTotalMembers()
        {
            int totalMembers = 0;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM Members";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        totalMembers = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                }
            }

            return totalMembers;
        }

        public static DataView GetMembersByName(string name)
        {
            string query = @"
        SELECT Persones.Name, Members.MemberID, Members.PersoneID, Persones.Address, Persones.Phone, Persones.DateOFBirth, Members.EmergenceContect, Members.LastRenkID, Members.IsActive, Members.Password, 
                Members.AskToTest
        FROM Persones
        INNER JOIN Members ON Persones.PersoneID = Members.PersoneID
        WHERE Persones.Name = @Name";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "MembersData");
                        return dataSet.Tables["MembersData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetActiveMembers()
        {
            string query = @"
        SELECT Persones.Name, Members.MemberID, Members.PersoneID, Persones.Address, Persones.Phone, Persones.DateOFBirth, Members.EmergenceContect, Members.LastRenkID, Members.IsActive, Members.Password, 
                Members.AskToTest
        FROM Persones
        INNER JOIN Members ON Persones.PersoneID = Members.PersoneID
        WHERE Members.IsActive = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "MembersData");
                        return dataSet.Tables["MembersData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetMemberByMemberID(int memberID)
        {
            string query = @"
        SELECT Persones.Name, Members.MemberID, Members.PersoneID, Persones.Address, Persones.Phone, Persones.DateOFBirth, Members.EmergenceContect, Members.LastRenkID, Members.IsActive, Members.Password, 
                Members.AskToTest
        FROM Persones
        INNER JOIN Members ON Persones.PersoneID = Members.PersoneID
        WHERE Members.MemberID = @MemberID";

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

        public static bool IsMemberExists(string UserName, string Password)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            
		 SELECT found=2 
            FROM Members
            INNER JOIN Persones ON Members.PersoneID = Persones.PersoneID
            WHERE Persones.Name = @UserName AND Members.Password = @Password;";

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

        public static bool IsMemberExistswhiteGetMemberID(string UserName, string Password, ref int ID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT found=1 
            FROM Members
            INNER JOIN Persones ON Members.PersoneID = Persones.PersoneID
            WHERE Persones.Name = @UserName AND Members.Password = @Password;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            isExists = true;

                            // Retrieve MemberID
                            string getMemberIdQuery = @"
                        SELECT Members.MemberID 
                        FROM Members
                        INNER JOIN Persones ON Members.PersoneID = Persones.PersoneID
                        WHERE Persones.Name = @UserName AND Members.Password = @Password;";

                            using (SqlCommand getMemberIdCmd = new SqlCommand(getMemberIdQuery, connection))
                            {
                                getMemberIdCmd.Parameters.AddWithValue("@UserName", UserName);
                                getMemberIdCmd.Parameters.AddWithValue("@Password", Password);

                                ID = Convert.ToInt32(getMemberIdCmd.ExecuteScalar());
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


        public static bool SetActive(int MemberID, bool IsActive)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            UPDATE Members SET IsActive = @IsActive WHERE MemberID = @MemberID;
          ;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MemberID", MemberID);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

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


        public static int GetMemberIDByMemberName(string Name)
        {
            int MemberID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT memberID 
            FROM MemberDetailsview 
            WHERE Name = @Name;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            MemberID = Convert.ToInt32(result);
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

            return MemberID;
        }

        public static DataTable GetAllMembersNames()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = " select  Name FROM MemberDetailsview;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }


        static void Main(string[] args)
        {
            // TestPayMethod();

            Console.ReadLine();
        }



    }
}

