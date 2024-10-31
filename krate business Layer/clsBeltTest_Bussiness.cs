using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static krate_business_Layer.clsBeltRank;
namespace krate_business_Layer
{
    public class clsBeltTest
    {

        public enum enBeltTestMode { AddNew = 0, Update = 1 }
        public enBeltTestMode BeltTestMode { get; set; }

        public int TestID { get; set; }
        public int MemberID { get; set; }
        public int RankID { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public int TestByInstructorID { get; set; }
        public int PaymentID { get; set; }

        public clsMember MemberInfo { get; set; }
        public clsInstrector InstractorInfo { get; set; }
        public clsBeltRank BeltRankInfo { get; set; }
        public clsPayment PaymentInfo { get; set; }

        public clsBeltTest()
        {
            this.RankID = -1;
            this.Result = false;
            this.Date = DateTime.MinValue;
            this.PaymentID = -1;
            this.BeltTestMode = enBeltTestMode.AddNew;
        }

        private clsBeltTest(int TestID, int MemberID, int RankID, bool Result, DateTime Date, int TestByInstructorID, int PaymentID)
        {
            this.TestID = TestID;
            this.MemberID = MemberID;
            this.RankID = RankID;
            this.Result = Result;
            this.Date = Date;
            this.TestByInstructorID = TestByInstructorID;
            this.PaymentID = PaymentID;

            this.MemberInfo=clsMember.FindMember(MemberID);
            this.InstractorInfo = clsInstrector.FindInstructor(TestByInstructorID);
            this.BeltRankInfo = clsBeltRank.FindBeltRank(RankID);
            this.PaymentInfo=clsPayment.FindPayment(PaymentID);   
            this.BeltTestMode = enBeltTestMode.Update;
        }

        public bool AddNewBeltTest()
        {
            this.TestID = clsBeltTestDateAccessLayer.AddNewBeltTest(this.MemberID, this.RankID,
                this.Result, this.Date, this.TestByInstructorID, this.PaymentID);
            return this.TestID != -1;
        }

        private bool UpdateBeltTest()
        {
            return clsBeltTestDateAccessLayer.UpdateBeltTest(this.TestID, this.MemberID, this.RankID, this.Result, this.Date, this.TestByInstructorID, this.PaymentID);
        }

        public bool Save()
        {

            if(UpdateBeltTest())
            {
                return true;
            }
            else
                return AddNewBeltTest();
            //switch (this.BeltTestMode)
            //{
            //    case enBeltTestMode.AddNew:
            //        return AddNewBeltTest();
            //    case enBeltTestMode.Update:
            //        return UpdateBeltTest();
            //}
            //return false;
        }

        public static clsBeltTest FindBeltTest(int testID)
        {
            int memberID = 0, rankID = 0, testByInstructorID = 0, paymentID = 0;
            bool result = false;
            DateTime date = DateTime.MinValue;

            if (clsBeltTestDateAccessLayer.GetBeltTestInfo(testID, ref memberID, ref rankID, ref result, ref date, ref testByInstructorID, ref paymentID))
            {
                return new clsBeltTest
                {
                    TestID = testID,
                    MemberID = memberID,
                    RankID = rankID,
                    Result = result,
                    Date = date,
                    TestByInstructorID = testByInstructorID,
                    PaymentID = paymentID,
                    BeltTestMode = enBeltTestMode.AddNew
                };
            }

            return null;
        }


        public static bool IsBeltTestExists(int testID)
        {
            return clsBeltTestDateAccessLayer.IsBeltTestExists(testID);
        }

        public static bool DeleteBeltTest(int testID)
        {
            return clsBeltTestDateAccessLayer.DeleteBeltTest(testID);
        }

        public int Pay(Decimal Amount)
        {
            clsPayment payment= new clsPayment();
            payment.Amount = Amount;
            payment.MemberID = this.MemberID;
            payment.PayTime = DateTime.Now;
            payment.PayFor = "BeltTest";
            if(payment.AddNewPayment())
            {
                return payment.PaymentID;
               
            }
            else
                return -1;

        }

        public static DataTable GetAllBeltTests()
        {
            return clsBeltTestDateAccessLayer.GetAllBeltTests();

        }

        public static DataView GetAllBeltTestsForMember(int MemberID)
        {
            return clsBeltTestDateAccessLayer.GetAllBeltTestsForMember(MemberID);

        }

        public static int GetBeltTestsByPaymentID(int PaymentID)
        {
            return clsBeltTestDateAccessLayer.GetBeltTestsByPaymentID(PaymentID);

        }


        //static void Main(string[] args)
        //{



        //    Console.ReadLine();
        //}







    }
}
