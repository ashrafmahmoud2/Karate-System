using Karate_Data_Layer;
using krate_business_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static krate_business_Layer.clsPersone;
using static krate_business_Layer.clsSubscriptionPeriod;

namespace krate_business_layer
{
    public class clsUser : clsPersone
    {

        public enum UserMode { Addnew = 0, Update }
        public UserMode CurrentUserMode = UserMode.Addnew;

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }

        public enum enPermissions
        {
            All = -1,
            ManageMembers = 1,
            ManageInstructors = 2,
            ManageUsers = 4,
            ManageMembersInstructors = 8,
            ManageBeltRanks = 16,
            ManageSubscriptionPeriods = 32,
            ManageBeltTests = 64,
            ManagePayments = 128
        }

        private clsUser(int userID, string username, string password, int permissions, int personeID,
            string name, string address, string phone, DateTime dateOfBirth, string ImagePath)
            : base(personeID, name, address, phone, dateOfBirth, ImagePath)
        {
            this.UserID = userID;
            this.Username = username;
            this.Password = password;
            this.Permissions = permissions;
            this.CurrentUserMode = UserMode.Addnew;
            base.Mode = enMode.AddNew;
        }

        public clsUser()
        {
            this.PersoneID = -1;
            this.UserID = -1;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Permissions = -1;
            this.CurrentUserMode = UserMode.Addnew;
            base.Mode = enMode.Update;
        }

        private bool AddNewUser()
        {
            this.UserID = clsUserDateAccessLayer.AddNewUser(this.Username, this.Password,
                this.Permissions, this.PersoneID);




            return this.UserID != -1;
        }

        private bool UpdateUser()
        {
            return clsUserDateAccessLayer.UpdateUser(this.UserID,
                this.Username, this.Password, this.Permissions, this.PersoneID);
        }

        public bool Save()
        {

            base.Mode = (clsPersone.enMode)CurrentUserMode;

            if (!base.Save())
            {
                return false;
            }

            if (UpdateUser())
            {
                return true;
            }
            else
            {
                return AddNewUser();
            }

        }

        public static bool IsUserExists(int userID)
        {
            return clsUserDateAccessLayer.IsUserExists(userID);
        }
        public static bool IsUserExists(string userName)
        {
            return clsUserDateAccessLayer.IsUserExists(userName);
        }
        public static bool IsUserExists(string userName, string Password)
        {
            return clsUserDateAccessLayer.IsUserExists(userName, Password);
        }
        public static bool IsUserExistswhiteGetUserID(string userName, string password, ref int userID)
        {
            return clsUserDateAccessLayer.IsUserExistswhiteGetUserID(userName, password, ref userID);
        }


        public static bool DeleteUser(int userID)
        {
            return clsUserDateAccessLayer.DeleteUser(userID);
        }

        public static int GetTotelUsers()
        {
            return clsUserDateAccessLayer.GetTotalUsers();
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDateAccessLayer.GetAllUsers();
        }

        public static DataView GetUserbyUserName(string username)
        {
            return clsUserDateAccessLayer.GetUsersByName(username);
        }

        public static DataView GetUserbyUserID(int userID)
        {
            return clsUserDateAccessLayer.GetUsersByUserID(userID);
        }

        public static clsUser FindUser(int userID)
        {
            int personeID = -1;
            string password = string.Empty, UserName = string.Empty;
            int permissions = 0; 

            if (clsUserDateAccessLayer.GetUserInfo(userID, ref UserName, ref password,
               ref permissions, ref personeID))
            {
                clsPersone _persone = clsPersone.FindPersoen(personeID);

                if (_persone != null && _persone.Mode != null)
                {
                    return new clsUser(userID, UserName, password, permissions, _persone.PersoneID, _persone.Name,
                        _persone.Address, _persone.Phone, _persone.DateOFBirth, _persone.ImagePath);
                }
            }

            return null;
        }


        public static clsUser FindUser(string userName, string password)
        {
            int personeID = -1;
            int permissions = 0;
            int userID = -1; // consistent naming

            // Validate input parameters
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                // Handle invalid input
                return null;
            }

            try
            {
                if (clsUserDateAccessLayer.GetUserInfo(userName, password, ref userID, ref permissions, ref personeID))
                {
                    clsPersone _persone = clsPersone.FindPersoen(personeID);

                    if (_persone != null && _persone.Mode != null)
                    {
                        return new clsUser(userID, userName, password, permissions, _persone.PersoneID, _persone.Name,
                            _persone.Address, _persone.Phone, _persone.DateOFBirth, _persone.ImagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }





        //static void Main(string[] args)
        //{
        //    // Add Test
        //    //Console.WriteLine("Add Test:");
        //    //clsUser userToAdd = new clsUser
        //    //{
        //    //    Username = "testUser",
        //    //    Password = "testPassword",
        //    //    Permissions = (int)clsUser.enPermissions.ManageMembers,
        //    //    // PersoneID = 2132,
        //    //    Name = "John Doe",
        //    //    Address = "123 Main St",
        //    //    Phone = "555-1234",
        //    //    DateOFBirth = DateTime.Parse("1990-01-01"),
        //    //    ImagePath = "path/to/image.jpg",
        //    //  // CurrentUserMode = UserMode.Addnew,


        //    //};

        //    //userToAdd.Save();
        //    //console.writeline($"user added with id: {usertoadd.userid}");

        //    //// update test
        //    //console.writeline("\nupdate test:");
        //    //clsUser usertoupdate = clsUser.FindUser(9);

        //    //if (usertoupdate != null)
        //    //{
        //    //    Console.WriteLine($"updating user with id: {usertoupdate.UserID}");
        //    //    usertoupdate.Username = "u";
        //    //    usertoupdate.Password = "updated";
        //    //    usertoupdate.Permissions = (int)clsUser.enPermissions.ManageSubscriptionPeriods;
        //    //    usertoupdate.Address = "updated";

        //    //    usertoupdate.Save();
        //    //    Console.WriteLine("user updated successfully");
        //    //}

        //    ////// Info Test
        //    //Console.WriteLine("\nInfo Test:");
        //    //clsUser userToGetInfo = clsUser.FindUser(userToAdd.UserID);

        //    //if (userToGetInfo != null)
        //    //{
        //    //    Console.WriteLine($"User Info:");
        //    //    Console.WriteLine($"UserID: {userToGetInfo.UserID}");
        //    //    Console.WriteLine($"Username: {userToGetInfo.Username}");
        //    //    Console.WriteLine($"Password: {userToGetInfo.Password}");
        //    //    Console.WriteLine($"Permissions: {userToGetInfo.Permissions}");
        //    //    Console.WriteLine($"PersoneID: {userToGetInfo.PersoneID}");
        //    //    Console.WriteLine($"Name: {userToGetInfo.Name}");
        //    //    Console.WriteLine($"Address: {userToGetInfo.Address}");
        //    //    Console.WriteLine($"Phone: {userToGetInfo.Phone}");
        //    //    Console.WriteLine($"Date of Birth: {userToGetInfo.DateOFBirth}");
        //    //    Console.WriteLine($"ImagePath: {userToGetInfo.ImagePath}");
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("User not found.");
        //    //}

        //    Console.ReadLine();
        //}





    }
}


