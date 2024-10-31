using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karate_Data_Layer;
using static krate_business_Layer.clsPersone;

namespace krate_business_Layer
{
    public class clsMember : clsPersone
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private clsPersone _persone = new clsPersone();

        public int MemberID { get; set; }
        public string EmergenceContect { get; set; }
        public int  LastRenkID { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public bool AskToTest { get; set; }

        public clsBeltRank LastBeltRankInfo { get; set; }
        public clsBeltRank clsBeltRank => clsBeltRank.FindBeltRank(clsBeltRank.GetNextBeltRankID(this.LastRenkID));

        public clsMember()  
        {
            this.MemberID = -1;
            this.PersoneID = -1;
            this.EmergenceContect = string.Empty;
            this.LastRenkID = -1;
            this.Password = string.Empty;
            this.AskToTest = false;
            this.IsActive = false;
            Mode = enMode.AddNew;
        
        }

        private clsMember(int memberID, string emergenceContect, int lastRenkID, bool isActive, string password,
            bool askToTest, int PersoneID, string Name, string Address, string Phone, DateTime DateOFBirth, string ImagePath)
          : base(PersoneID, Name, Address, Phone, DateOFBirth, ImagePath)

        {



            this.MemberID = memberID;
            this.EmergenceContect = emergenceContect;
            this.LastRenkID = lastRenkID;
            this.IsActive = isActive;
            this.Password = password;
            this.AskToTest = askToTest;
            Mode = enMode.Update;

            this.LastBeltRankInfo = clsBeltRank.FindBeltRank(LastRenkID);
        }

        private bool AddNewMember()
        {
            
  this.MemberID = clsMemberDateAccessLayer.AddNewMember(this.PersoneID, this.EmergenceContect, this.LastRenkID,
         this.IsActive, this.Password, this.AskToTest);
                
            

            return this.MemberID != -1;
        }

        private bool UpdateMember()
        {
            return clsMemberDateAccessLayer.UpdateMember(this.MemberID, this.PersoneID, 
              this.EmergenceContect, this.LastRenkID,this.IsActive, this.Password, this.AskToTest);

        }

        public bool Save()
        {
            base.Mode = (clsPersone.enMode)Mode;

            
            if (!base.Save())
            {
                return false;
            }

            if (UpdateMember())
            {
                return true;
            }
            else
                return AddNewMember();
            //switch (Mode)
            //{
            //    case enMode.AddNew:
            //        if (AddNewMember())
            //        {
            //            Mode = enMode.AddNew;
            //            return true;
            //        }
            //        else
            //            return false;
                   

            //    case enMode.Update:
            //        return UpdateMember();

            //}
            return false;
        }


        public static bool IsMemberExists(int memberID)
        {
            return clsMemberDateAccessLayer.IsMemberExists(memberID);
        }

        public static bool DeleteMember(int memberID)
        {
            return clsMemberDateAccessLayer.DeleteMember(memberID);
        }

        public static DataView GetAllMember()
        {
            return clsMemberDateAccessLayer.GetAllMembers();
        }
        public static DataTable GetAllMember1()
        {
            return clsMemberDateAccessLayer.GetAllMembers1();
        }

        public static int GetToterLMember()
        {
            return clsMemberDateAccessLayer.GetTotalMembers();
        }

        public static DataView GetMemberbyName(string name)
        {
            return clsMemberDateAccessLayer.GetMembersByName(name);
        }
      

        public static DataView GetMemberActive()
        {
            return clsMemberDateAccessLayer.GetActiveMembers();
        }

        public static DataView GetMemberbymemberID(int memberID)
        {
            return clsMemberDateAccessLayer.GetMemberByMemberID(memberID);
        }

        public static clsMember FindMember(int memberID)
        {
            int personeID = -1, lastRenkID = -1;
            string emergenceContect = string.Empty, password = string.Empty;
            bool isActive = false, askToTest = false;

            if (clsMemberDateAccessLayer.GetMemberInfo(memberID, ref personeID, ref emergenceContect, ref lastRenkID,
                ref isActive, ref password, ref askToTest))
            {
                clsPersone _persone = clsPersone.FindPersoen(personeID);

                if (_persone != null && _persone.Mode != null)
                {
                    return new clsMember(memberID, emergenceContect, lastRenkID, isActive, password,
                        askToTest, _persone.PersoneID,
                        _persone.Name, _persone.Address, _persone.Phone, _persone.DateOFBirth, _persone.ImagePath);
                }
            }

            return null;
        }
       

        public static bool IsMemberExists(string UserName, string Password)
        {
            return clsMemberDateAccessLayer.IsMemberExists(UserName, Password);
        }

        public static bool IsMemberExistswhiteGetMemberID(string UserName, string Password, ref int ID)
        {
            return clsMemberDateAccessLayer.IsMemberExistswhiteGetMemberID(UserName, Password, ref ID);
        }

        public bool SetActivety(bool IsActive)
        {
return SatActive(this.MemberID, IsActive);
        }
     
        public static bool SatActive(int MemberID, bool IsActive)
        {
            return clsMemberDateAccessLayer.SetActive(MemberID, IsActive);
        }

        public static void TestUpdateFunction()
        {
            try
            {
                
                int existingMemberID = 1;

                // Create an instance of clsMember
                clsMember member = new clsMember
                {
                    //propem to conact with persoen;
                    MemberID = 1,
                    PersoneID=2,
                    EmergenceContect = "new",
                    Name = "new2",
                    Address = "new",
                    Phone = "new",
                  ImagePath = "new",
                    DateOFBirth = DateTime.Parse("2003-08-16"),
                    LastRenkID = 3, // Replace with the desired value
                    IsActive = false, // Replace with the desired value
                    Password = "new",
                    AskToTest = false,
                    Mode = enMode.Update,

                };

                bool updateResult = member.Save();

                if (updateResult)
                {
                    Console.WriteLine("Member Update Successfully");
                }
                else
                {
                    Console.WriteLine("Member Update Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public int GetLastActivePeriodID()
        {
            return clsSubscriptionPeriod.GetLastActivePeriodIDForMember(this.MemberID);
        }

        public bool DoesHaveAnActivePeriod()
        {
            return (GetLastActivePeriodID() != -1);
        }

        public DataView GetAllBeltTest()
        {
            return clsBeltTest.GetAllBeltTestsForMember(this.MemberID);
        }
        public DataView GetAllPayment()
        {
            return clsPayment.GetAllPaymentsForMember(this.MemberID);
        }

        public static int GetMemberIDByMemberName(string name)
        {
            return clsMemberDateAccessLayer.GetMemberIDByMemberName(name);
        }

        public static DataTable GetAllMembersNames()
        {
            return clsMemberDateAccessLayer.GetAllMembersNames();
        }

        //public static void Main(string[] args)
        //{

        //    TestUpdateFunction();

        //    Console.ReadLine();
        //}


    }
}