using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karate_Data_Layer;
using System.Runtime.ConstrainedExecution;
using System.Data;

namespace krate_business_Layer
{
    public class clsPersone
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersoneID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOFBirth { get; set; }

        public string ImagePath {  get; set; }

        public clsPersone()
        {
            this.PersoneID = -1;
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.DateOFBirth = DateTime.MinValue;
            this.ImagePath = string.Empty;
            Mode = enMode.AddNew;

        }

        protected clsPersone(int PersoneID, string Name, string Address, string Phone, DateTime DateOFBirth, string ImagePath)
        {
            this.PersoneID = PersoneID;
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            this.DateOFBirth = DateOFBirth;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;

        }

        private bool _AddNewPersone()
        {
            this.PersoneID = clsPersoneDateAccessLayer.AddNewPerson(this.Name, this.Address, 
                this.Phone, this.DateOFBirth,this.ImagePath);
            return (this.PersoneID > -1);
        }

        public bool _UpdatePersone()
        {
            return clsPersoneDateAccessLayer.UpdatePerson(this.PersoneID, this.Name, this.Address,
                this.Phone, this.DateOFBirth, this.ImagePath);
        }

        public  bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if( _AddNewPersone())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdatePersone();
            }
            return false;
        }

        public static bool DeletePersone(int PersonID)
        {
            return clsPersoneDateAccessLayer.DeletePerson(PersonID);
        }

        public static clsPersone FindPersoen(int PersonID)
        {
            string Name = "", Phone = "", Address = "",ImagePath="";
            DateTime DateOfBirth = DateTime.MinValue;

            if (clsPersoneDateAccessLayer.GetPersoneInfo(PersonID, ref Name, ref Phone, 
                ref Address, ref DateOfBirth,ref ImagePath))
            {
                return new clsPersone(PersonID, Name, Phone, Address, DateOfBirth, ImagePath);
            }
            else
                return null;
        }

        public static bool IsPersonExists(int PersonID)
        {
            return clsPersoneDateAccessLayer.IsPersonExists(PersonID);
        }

        public static DataView GetAllPersone()
        {

            return clsPersoneDateAccessLayer.GetAllPersones();
        }



       

    }
}
