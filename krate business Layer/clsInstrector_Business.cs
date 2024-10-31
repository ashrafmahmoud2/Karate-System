using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karate_Data_Layer;
using static krate_business_Layer.clsPersone;
namespace krate_business_Layer
{
    public class clsInstrector : clsPersone
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private clsPersone _persone = new clsPersone();

        public int InstructorID { get; set; }
        public string Qualafation { get; set; }
        public string Password { get; set; }

        public clsInstrector()
        {
            this.InstructorID = -1;
            this.Qualafation = String.Empty;
            this.Password = String.Empty;
            this.PersoneID = -1;
            Mode = enMode.AddNew;
        }

        private clsInstrector(int instructorID, string qualafation, string password,
            int personeID, string name, string address, string phone, DateTime dateOfBirth, string ImagePath)
            : base(personeID, name, address, phone, dateOfBirth, ImagePath)
        {
            InstructorID = instructorID;
            Qualafation = qualafation;
            Password = password;
            PersoneID = personeID;
            Mode = enMode.Update;
        }

        private bool AddNewInstructor()
        {
            this.InstructorID = clsInstrectorDateAccessLayer.AddNewInstructor(this.PersoneID, this.Qualafation,
                this.Password);
            return (this.InstructorID != -1);
        }

        private bool UpdateInstructor()
        {
            return clsInstrectorDateAccessLayer.UpdateInstructor(this.InstructorID, this.PersoneID, this.Qualafation,
                this.Password);
        }

        public bool Save()
        {
            base.Mode = (clsPersone.enMode)Mode;

            if (!base.Save())
            {
                return false;
            }

            if (UpdateInstructor())
            {
                return true;
            }
            else
                return AddNewInstructor();

            return false;
        }

        public static bool IsInstructorExists(int instructorID)
        {
            return clsInstrectorDateAccessLayer.IsInstructorExists(instructorID);
        }

        public static bool IsInstructorExists(string instructornName, string Pasword)
        {
            return clsInstrectorDateAccessLayer.IsInstructorExists(instructornName, Pasword);
        }

        public static bool DeleteInstructor(int instructorID)
        {
            return clsInstrectorDateAccessLayer.DeleteInstructor(instructorID);
        }

        public static  DataTable GetAllInstructors()
        {
            return clsInstrectorDateAccessLayer.GetAllInstructors();
        }

        public static int GetTotalInstructors()
        {
            return clsInstrectorDateAccessLayer.GetTotalInstructors();
        }

        public static DataView GetInstructorByName(string name)
        {
            return clsInstrectorDateAccessLayer.GetInstructorsByName(name);
        }

        public static DataView GetActiveInstructors()
        {
            return clsInstrectorDateAccessLayer.GetActiveInstructors();
        }

        public static DataView GetInstructorByInstructorID(int instructorID)
        {
            return clsInstrectorDateAccessLayer.GetInstructorByInstructorID(instructorID);
        }
      

        public static clsInstrector FindInstructor(int instructorID)
        {
            int personeID = -1;
            string qualafation = string.Empty, password = string.Empty;

            if (clsInstrectorDateAccessLayer.GetInstructorInfo(instructorID, ref personeID, ref qualafation,
                ref password))
            {
                clsPersone _persone = clsPersone.FindPersoen(personeID);

                if (_persone != null && _persone.Mode != null)
                {
                    return new clsInstrector
                    {
                        InstructorID = instructorID,
                        Qualafation = qualafation,
                        Password = password,
                        PersoneID = _persone.PersoneID,
                        Name = _persone.Name,
                        Address = _persone.Address,
                        Phone = _persone.Phone,
                        DateOFBirth = _persone.DateOFBirth
                    };
                }
            }

            return null;
        }

        public static bool IsInstractorExistswhiteGetInstractroID(string UserName, string Password, ref int ID)
        {
            return clsInstrectorDateAccessLayer.IsInstractorExistswhiteGetInstructorID(UserName, Password, ref ID);
        }

        public bool IsTraningthisMember(int MemberID)
        {
            return clsMemberInstructor.IsInstructorTraningthisMember(this.InstructorID, MemberID);
        }
        public static int GetInstractorIDByInstractorName(string Name)
        {
            return clsInstrectorDateAccessLayer.GetInstractorIDByInstractorName(Name);
        }
        public static DataTable GetAllInstructorsNames()
        {
            return clsInstrectorDateAccessLayer.GetAllInstructorsNames();
        }
        public static DataView GetTranedMembersByInstructro(int InstructorID)
        {
            return clsInstrectorDateAccessLayer.GetTrainedMembersByInstructor(InstructorID);
        }


        public static void TestUpdateFunction()
        {
            try
            {
                int existingMemberID = 1;

                // Create an instance of clsMember
                clsInstrector instrector = new clsInstrector
                {
                    InstructorID = 18,
                    PersoneID = 2148,
                    Name = "Update2",
                    Address = "new2",
                    Phone = "new2",
                    ImagePath = "new2",
                    DateOFBirth = DateTime.Parse("2003-08-16"),
                    Qualafation = "new2",
                    Password = "new2",
                    Mode = enMode.AddNew,
                };

                bool updateResult = instrector.Save();

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

        //static void Main(string[] args)
        //{

        //    TestUpdateFunction();

        //    Console.ReadLine();
        //}


    }
}