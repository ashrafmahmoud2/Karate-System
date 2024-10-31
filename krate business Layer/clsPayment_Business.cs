using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace krate_business_Layer
{
    public class clsPayment
    {

       // THE _temp explen
        public enum enPaymentMode { AddNew = 0, Update = 1 }
        public enPaymentMode PaymentMode=enPaymentMode.AddNew;

        public enum enPaymentFor { Suscripttion,BeltTest}
        public enPaymentFor PaymentFor=enPaymentFor.Suscripttion;

        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayTime { get; set; }
        public int MemberID { get; set; }

        public string PayFor {  get; set; }

        public clsMember memberInfo { get; set; }

        private  int _TempID=-1;

        public int PaymentForID
        {
            get
            {
                if((_TempID= clsSubscriptionPeriod.GetPeriodIDByPaymentID(PaymentID)) != -1)
                {
                    PaymentFor = enPaymentFor.Suscripttion;
                    return _TempID;
                }
                if((_TempID= clsBeltTest.GetBeltTestsByPaymentID(PaymentID)) != -1)
                {
                    PaymentFor = enPaymentFor.BeltTest;
                    return _TempID;
                }
                return -1;

            }
        }



        public clsPayment()
        {
            this.PaymentID = -1;
            this.Amount = decimal.MinValue;
            this.PayTime = DateTime.MinValue;
            this.MemberID = -1;
            PayFor = string.Empty;
            this.PaymentMode = enPaymentMode.AddNew;
        }

        private clsPayment(int PaymentID, decimal Amount, DateTime PayTime, int MemberID,string PayFor)
        {
            this.PaymentID = PaymentID;
            this.Amount = Amount;
            this.PayTime = PayTime;
            this.MemberID = MemberID;
            this.PayFor = PayFor;
            this.PaymentMode = enPaymentMode.Update;
        }

        public bool AddNewPayment()
        {
            this.PaymentID = clsPaymentDateAccessLayer.AddNewPayment(this.Amount,
                this.PayTime, this.MemberID,this.PayFor);
            return (this.PaymentID != -1);
        }

        private bool UpdatePayment()
        {
            return clsPaymentDateAccessLayer.UpdatePayment(this.PaymentID, this.Amount, 
                this.PayTime, this.MemberID,this.PayFor);
        }

        public bool Save()
        {

            //if(UpdatePayment())
            //{ return true; }

            //else {
            //    AddNewPayment(); 
            //}
            switch (this.PaymentMode)
            {
                case enPaymentMode.AddNew:
                    return AddNewPayment();
                case enPaymentMode.Update:
                    return UpdatePayment();
            }
            return false;
        }

        public static clsPayment FindPayment(int paymentID)
        {
            decimal amount = decimal.MinValue;
            DateTime payTime = DateTime.MinValue;
            int memberID = 0;
            string PayFor = string.Empty;

            if (clsPaymentDateAccessLayer.GetPaymentInfo(paymentID, ref amount,
                ref payTime, ref memberID,ref PayFor))
            {
                return new clsPayment
                {
                    PaymentID = paymentID,
                    Amount = amount,
                    PayTime = payTime,
                    MemberID = memberID,
                    PayFor= PayFor,
                    PaymentMode = enPaymentMode.AddNew
                };
            }

            return null;
        }

        public static bool IsPaymentExists(int paymentID)
        {
            return clsPaymentDateAccessLayer.IsPaymentExists(paymentID);
        }

        public static bool DeletePayment(int paymentID)
        {
            return clsPaymentDateAccessLayer.DeletePayment(paymentID);
        }
        public static int GetTotlPaymetn()
        {
            return clsPaymentDateAccessLayer.GetTotalPayment();
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentDateAccessLayer.GetAllPayments();
        }
        public static DataView GetPaymentByID(int ID)
        {
            return clsPaymentDateAccessLayer.GetPaymentByID(ID);
        }
        public static DataView GetPaymentByDateTime(DateTime date)
        {
            return clsPaymentDateAccessLayer.GetPaymentByDateTime(date);
        }

        public static DataView GetPaymentByMeberName(string meberName)
        {
          return  clsPaymentDateAccessLayer.GetPaymentByMemberName(meberName);
        }

        public static DataView GetAllPaymentsForMember(int memberID) 
        {
           return clsPaymentDateAccessLayer.GetAllPaymentsForMember(memberID);
        }



        //static void Main(string[] args)
        //{
        //     TestPaymentOperations();
        //    Console.ReadLine();
        //}

        private static void TestPaymentOperations()
        {
            // Test AddNewPayment
            //clsPayment paymentToAdd = new clsPayment
            //{
            //    Amount = 100.50m,
            //    PayTime = DateTime.Now,
            //    MemberID = 1004,
            //    PaymentMode = enPaymentMode.AddNew
            //};

            //if (paymentToAdd.Save())
            //{
            //    Console.WriteLine($"Payment added successfully. PaymentID: {paymentToAdd.PaymentID}");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to add payment.");
            //}

            // Test UpdatePayment
            //clsPayment paymenttoupdate = FindPayment(12);

            //if (paymenttoupdate != null)
            //{
            //    paymenttoupdate.Amount = 150.75m;
            //    paymenttoupdate.PayTime = DateTime.Now.AddDays(1);
            //    paymenttoupdate.MemberID = 1005;
            //    paymenttoupdate.PaymentMode = enPaymentMode.Update;

            //    if (paymenttoupdate.Save())
            //    {
            //        Console.WriteLine($"payment updated successfully. paymentid: " +
            //            $"{paymenttoupdate.PaymentID}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("failed to update payment.");
            //    }
            //}

            // Test FindPayment
            //clsPayment foundPayment = FindPayment(12);

            //if (foundPayment != null)
            //{
            //    Console.WriteLine($"Found Payment - PaymentID: {foundPayment.PaymentID}, Amount: {foundPayment.Amount}, PayTime: {foundPayment.PayTime}, MemberID: {foundPayment.MemberID}");
            //}
            //else
            //{
            //    Console.WriteLine("Payment not found.");
            //}
        }
    }
}

