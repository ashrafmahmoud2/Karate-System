using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Karate_Data_Layer
{
    public class clsInstrectorDateAccessLayer
    {
        public static int AddNewInstructor(int PersoneID, string Qualafation, string Password)
        {
            int InstructorID = -1;

            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"
    INSERT INTO [dbo].[Instructors]
    ([PersoneID],[Qualafation],[Password])
    VALUES
    (@PersoneID,@Qualafation,@Password);
    SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@PersoneID", PersoneID);
                cmd.Parameters.AddWithValue("@Qualafation", Qualafation);
                cmd.Parameters.AddWithValue("@Password", Password);

                InstructorID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return InstructorID;
        }

        public static bool DeleteInstructor(int InstructorID)
        {
            bool success = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
DELETE FROM Instructors WHERE InstructorID = @InstructorID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (instructor was deleted)
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

        public static bool UpdateInstructor(int InstructorID, int PersoneID, string Qualafation, string Password)
        {
            bool IsUpdate = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
UPDATE [dbo].[Instructors]
   SET [PersoneID] = @PersoneID
      ,[Qualafation] = @Qualafation
      ,[Password] = @Password
 WHERE [InstructorID] = @InstructorID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                        cmd.Parameters.AddWithValue("@PersoneID", PersoneID);
                        cmd.Parameters.AddWithValue("@Qualafation", Qualafation);
                        cmd.Parameters.AddWithValue("@Password", Password);

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

        public static bool GetInstructorInfo(int InstructorID, ref int PersoneID, ref string Qualafation, ref string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString);

            string query = @"SELECT * FROM Instructors WHERE InstructorID = @InstructorID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@InstructorID", InstructorID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersoneID = Convert.ToInt32(reader["PersoneID"]);
                    Qualafation = (string)reader["Qualafation"];
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
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsInstructorExists(int InstructorID)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
SELECT found=2 FROM Instructors WHERE InstructorID = @InstructorID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@InstructorID", InstructorID);

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

        public static int GetPersoneIDByInstructorID(int InstructorID)
        {
            int PersoneID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
SELECT PersoneID FROM Instructors WHERE InstructorID = @InstructorID;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@InstructorID", InstructorID);

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

 
        public static DataTable GetAllInstructors()
        {
            DataTable dt = new DataTable();
            string query = @"  select *from InstructroDetailsView";

           

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
    
    public static int GetTotalInstructors()
        {
            int totalInstructors = 0;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"SELECT COUNT(*) FROM Instructors";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        totalInstructors = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                    }
                }
            }

            return totalInstructors;
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

        public static DataView GetInstructorsByName(string name)
        {
            string query = @"
    SELECT Persones.Name, Instructors.InstructorID, Instructors.PersoneID, Persones.Address, Persones.Phone, Persones.DateOFBirth, Instructors.Qualafation, Instructors.Password
    FROM Persones
    INNER JOIN Instructors ON Persones.PersoneID = Instructors.PersoneID
    WHERE Persones.Name = @Name";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "InstructorsData");
                        return dataSet.Tables["InstructorsData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetActiveInstructors()
        {
            string query = @"
    SELECT Persones.Name, Instructors.InstructorID, Instructors.PersoneID, Persones.Address, Persones.Phone, Persones.DateOFBirth, Instructors.Qualafation, Instructors.Password
    FROM Persones
    INNER JOIN Instructors ON Persones.PersoneID = Instructors.PersoneID
    WHERE Instructors.IsActive = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "InstructorsData");
                        return dataSet.Tables["InstructorsData"].DefaultView;
                    }
                }
            }
        }

        public static DataView GetInstructorByInstructorID(int instructorID)
        {
            string query = @"
    SELECT Persones.Name, Instructors.InstructorID, Instructors.PersoneID, Persones.Address, Persones.Phone, Persones.DateOFBirth, Instructors.Qualafation, Instructors.Password
    FROM Persones
    INNER JOIN Instructors ON Persones.PersoneID = Instructors.PersoneID
    WHERE Instructors.InstructorID = @InstructorID";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@InstructorID", instructorID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "InstructorsData");
                        return dataSet.Tables["InstructorsData"].DefaultView;
                    }
                }
            }
        }

        public static bool IsInstructorExists(string UserName, string Password)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
           SELECT found=1
FROM Instructors
INNER JOIN Persones ON Instructors.PersoneID = Persones.PersoneID
WHERE Persones.Name = @UserName AND Instructors.Password = @Password;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password); // Assuming Password is the plaintext password

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

        public static bool IsInstractorExistswhiteGetInstructorID(string UserName, string Password, ref int ID)
        {
            bool isExists = false;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            

SELECT found=1 
FROM Instructors
INNER JOIN Persones ON Instructors.PersoneID = Persones.PersoneID
WHERE Persones.Name = @UserName AND Instructors.Password =@Password;";

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
                      

  SELECT Instructors.InstructorID 
  FROM Instructors
  INNER JOIN Persones ON Instructors.PersoneID = Persones.PersoneID
  WHERE Persones.Name = @UserName AND Instructors.Password = @Password;";

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

        public static int GetInstractorIDByInstractorName(string Name)
        {
            int InstructorID = -1;

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = @"
            SELECT InstructorID FROM InstructroDetailsView WHERE Name=@Name;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            InstructorID = Convert.ToInt32(result);
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

            return InstructorID;
        }

        public static DataTable GetAllInstructorsNames()
        {
            DataTable dt= new DataTable();

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                string query = "select  Name from InstructroDetailsView;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Execute the command and retrieve the result
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if there are rows in the result
                            while (reader.HasRows)
                            {
                                // Retrieve the InstructorName from the result and add it to the list
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

        public static DataView GetTrainedMembersByInstructor(int InstructorID)
        {
            string query = "SELECT * FROM SuscriptionPeruodeView WHERE InstrctorID = @InstructorID;";

            using (SqlConnection connection = new SqlConnection(clsConnectionOfDate.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "InstructorsData");
                        return dataSet.Tables["InstructorsData"].DefaultView;
                    }
                }
            }
        }





    }

}
