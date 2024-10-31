using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static krate_business_Layer.clsPersone;

namespace krate_business_Layer
{
    public class clsMemberInstructor
    {

        public enum enMemberInstructorMode { AddNew = 0, Update = 1 }
        public enMemberInstructorMode MemberInstructorMode = enMemberInstructorMode.AddNew;

        private clsPersone _persone = new clsPersone();

        public int MemberInstructorID { get; set; }
        public DateTime AssignDate { get; set; }
        public int InstructorID { get; set; }
        public int MemberID { get; set; }

        public clsMember MemberInfo { get; set; }
        public clsInstrector InstractorInfo { get; set; }

        public clsMemberInstructor()
        {
            this.MemberInstructorID = -1;
            this.AssignDate = DateTime.MinValue;
            this.MemberID = -1;
            this.InstructorID = -1;
            this.MemberInstructorMode = enMemberInstructorMode.AddNew;
        }

        private clsMemberInstructor(int memberInstructorID, int instructorID, int memberID, DateTime assignDate)
        {
            this.MemberInstructorID = memberInstructorID;
            this.InstructorID = instructorID;
            this.MemberID = memberID;
            this.AssignDate = assignDate;

            this.MemberInfo = clsMember.FindMember(MemberID);
            this.InstractorInfo=clsInstrector.FindInstructor(instructorID);
            this.MemberInstructorMode = enMemberInstructorMode.Update;
        }

        private bool AddNewMemberInstructor()
        {
            if (clsMember.IsMemberExists(this.MemberID) && clsInstrector.IsInstructorExists(this.InstructorID))
            {
                this.MemberInstructorID = clsMemberInstructorDateAccessLayer.AddNewMemberInstructor(
                    this.InstructorID, this.MemberID, this.AssignDate
                );
            }

            return this.MemberInstructorID != -1;
        }

        private bool UpdateMemberInstructor(int memberInstructorID)
        {
            return clsMemberInstructorDateAccessLayer.UpdateMemberInstructor(
                memberInstructorID, this.InstructorID, this.MemberID, this.AssignDate
            );
        }

        public bool Save()
        {
            switch (this.MemberInstructorMode)
            {
                case enMemberInstructorMode.AddNew:
                    return AddNewMemberInstructor();
                case enMemberInstructorMode.Update:
                    return UpdateMemberInstructor(MemberInstructorID);
            }
            return false;
        }

        public static clsMemberInstructor FindMemberInstructor(int memberInstructorID)
        {
            int instructorID = -1, memberID = -1;
            DateTime assignDate = DateTime.MinValue;

            if (clsMemberInstructorDateAccessLayer.GetMemberInstructorInfo(memberInstructorID, ref instructorID, ref memberID, ref assignDate))
            {
                return new clsMemberInstructor
                {
                    MemberInstructorID = memberInstructorID,
                    InstructorID = instructorID,
                    MemberID = memberID,
                    AssignDate = assignDate,
                    MemberInstructorMode = enMemberInstructorMode.AddNew
                };
            }

            return null;
        }

        public static bool IsMemberInstructorExists(int MemberInstructID)
        {
            return clsMemberInstructorDateAccessLayer.IsMemberInstructorExists(MemberInstructID);
        }

        public static bool DeleteMemberInstructor(int instructorID)
        {
            return clsMemberInstructorDateAccessLayer.DeleteMemberInstructor(instructorID);
        }

        public static int GetTotalMemberInstructors()
        {
            return clsMemberInstructorDateAccessLayer.GetTotalMemberInstructors();
        }

        public static DataView GetAllMemberInstructors()
        {
            return clsMemberInstructorDateAccessLayer.GetAllMemberInstructors();
        }

        public static DataView GetMemberInstructorByMemberID(int memberID)
        {
            return clsMemberInstructorDateAccessLayer.GetMemberMemberInstructorsByMemberID(memberID);
        }

        public static DataView GetMemberInstructorByAssineData(DateTime assignDate)
        {
            return clsMemberInstructorDateAccessLayer.GetMemberInstructorByAssineData(assignDate);
        }

        public static DataView GetMemberInstructorByInstructorID(int instructorID)
        {
            return clsMemberInstructorDateAccessLayer.GetMemberInstructorsByInstractorID(instructorID);
        }

        public static bool  IsInstructorTraningthisMember(int InstructorID,int MemberID)
        {
            return clsMemberInstructorDateAccessLayer.IsInstructorTraningthisMember(InstructorID, MemberID);
        }

        public static DataView GetTranedMembersByInstructro(int InstructorID)
        {
            return clsMemberInstructorDateAccessLayer.GetTrainedMembersByInstructor(InstructorID);
        }

        //static void Main(string[] args)
        //{




        //    Console.ReadLine();
        //}







    }
}

