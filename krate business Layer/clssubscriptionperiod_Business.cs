using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static krate_business_Layer.clsSubscriptionPeriod;

namespace krate_business_Layer
{
    public class clsSubscriptionPeriod
    {

        // The issue reason explain, pay, rename
        public enum enSubscriptionPeriodMode { AddNew = 0, Update = 1 }
        public enSubscriptionPeriodMode SubscriptionPeriodMode = enSubscriptionPeriodMode.AddNew;

        public enum enIssueReason { FirstTime = 1, ReName = 2 };

        public int periodID { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Fees { get; set; }
        public int MemberID { get; set; }
        public int PaymentID { get; set; }
        public bool IsPaid { get; set; }
        public enIssueReason IssueReason { get; set; }
        public bool IsActive { get; set; }

        public clsMember MemberInfo { get; set; }
        public clsPayment PaymentInfo { get; set; }
        public string IssueReasonText => _IssueReasonText(this.IssueReason);

        public clsSubscriptionPeriod()
        {
            this.periodID = -1;
            this.InstructorId = -1;
            this.IsActive = false;
            this.PaymentID = -1;
            this.Fees = 0;  // Initialize Fees with a default value
            this.StartDate = DateTime.MinValue;
            this.EndDate = DateTime.MinValue;
            this.MemberID = -1;
            this.IssueReason = enIssueReason.FirstTime;
            this.SubscriptionPeriodMode = enSubscriptionPeriodMode.AddNew;
        }

        private clsSubscriptionPeriod(int periodID, int InstructorID, decimal Fees, DateTime StartDate, DateTime EndDate,
            int MemberID, int PaymentID, bool IsPaid, enIssueReason IssueReason, bool IsActive)
        {
            this.periodID = periodID;
            this.InstructorId = InstructorID;
            this.Fees = Fees;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.MemberID = MemberID;
            this.PaymentID = PaymentID;
            this.IsPaid = IsPaid;
            this.IssueReason = IssueReason;
            this.IsActive = IsActive;
            this.MemberInfo = clsMember.FindMember(MemberID);
            if (PaymentID != -1)
                this.PaymentInfo = clsPayment.FindPayment(PaymentID);
            this.SubscriptionPeriodMode = enSubscriptionPeriodMode.Update;
        }

        private bool AddNewSubscriptionPeriod()
        {
            this.periodID = clsSubscriptionPeriodDateAccessLayer.AddNewSubscriptionPeriod(this.InstructorId,
                this.Fees, this.StartDate, this.EndDate,
                this.MemberID, this.PaymentID, this.IsPaid, (byte)this.IssueReason, this.IsActive);
            return (this.periodID != -1);
        }

        public bool UpdateSubscriptionPeriod()
        {
            return clsSubscriptionPeriodDateAccessLayer.UpdateSubscriptionPeriod(this.periodID,
                this.InstructorId, this.Fees, this.StartDate, this.EndDate,
                this.MemberID, this.PaymentID, this.IsPaid, (byte)this.IssueReason, this.IsActive);
        }

        public bool Save()
        {
            if (UpdateSubscriptionPeriod())
                return true;
            else
                return AddNewSubscriptionPeriod();
        }

        public static clsSubscriptionPeriod FindSubscriptionPeriod(int periodID)
        {
            decimal fees = 0;
            int InstructorID = 0;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            int memberID = 0;
            int paymentID = 0;
            bool isPaid = false;
            byte issueReason = 0;
            bool isActive = false;

            if (clsSubscriptionPeriodDateAccessLayer.GetSubscriptionPeriodInfo(periodID, ref InstructorID, ref fees, ref startDate,
                ref endDate, ref memberID, ref paymentID, ref isPaid, ref issueReason, ref isActive))
            {
                return new clsSubscriptionPeriod(periodID, InstructorID,
                    fees, startDate, endDate, memberID, paymentID, isPaid, (enIssueReason)issueReason, isActive)
                {
                    SubscriptionPeriodMode = enSubscriptionPeriodMode.AddNew
                };
            }

            return null;
        }

        public static bool IsSubscriptionPeriodExists(int periodID)
        {
            return clsSubscriptionPeriodDateAccessLayer.IsSubscriptionPeriodExists(periodID);
        }

        public static bool DeleteSubscriptionPeriod(int periodID)
        {
            return clsSubscriptionPeriodDateAccessLayer.DeleteSubscriptionPeriod(periodID);
        }

        public int Pay(decimal Amount)
        {
            clsPayment payment = new clsPayment();
            payment.MemberID = this.MemberID;
            payment.Amount = Amount;
            payment.PayTime=DateTime.Now;
            payment.PayFor = "Subscription";
            if (!payment.AddNewPayment())
            {
                clsMember.SatActive(this.MemberID, false);
                return -1;
            }
          //  clsMember.SatActive(this.MemberID, true);
            return payment.PaymentID;
        }
       


        public int ReNew(decimal Fees, DateTime StartDate, DateTime EndDate, bool IsPaid, ref int Payment)
        {
            clsSubscriptionPeriod newSubscriptionPeriod = new clsSubscriptionPeriod();
            newSubscriptionPeriod.MemberID = this.MemberID;
            newSubscriptionPeriod.Fees = Fees;
            newSubscriptionPeriod.StartDate = StartDate;
            newSubscriptionPeriod.EndDate = EndDate;
            newSubscriptionPeriod.IsPaid = IsPaid;
            newSubscriptionPeriod.IssueReason = enIssueReason.ReName;
            newSubscriptionPeriod.IsActive = true;
            if (newSubscriptionPeriod.IsPaid)
            {
                newSubscriptionPeriod.PaymentID = newSubscriptionPeriod.Pay(Fees);
                Payment = newSubscriptionPeriod.PaymentID;
            }
            if (!newSubscriptionPeriod.Save())
            {
                return -1;
            }
            return newSubscriptionPeriod.periodID;
        }

        private string _IssueReasonText(enIssueReason enIssue)
        {
            switch (enIssue)
            {
                case enIssueReason.ReName:
                    return "ReNew";
                case enIssueReason.FirstTime:
                    return "First Time";
                default:
                    return "First Time";
            }
        }

        public bool IsPeriodFinish()
        {
            return (this.EndDate < DateTime.Now);
        }

        public static DataTable GetAllSubscrabtionPeriod()
        {
            return clsSubscriptionPeriodDateAccessLayer.GetAllscriptionPeriod();
        }

        public static int GetTotelSubscractionPerrod()
        {
            return clsSubscriptionPeriodDateAccessLayer.GetTotalSubscriptionPeriodCount();
        }

        public static DataView GetAllIsPaySubscractionPerrod()
        {
            return clsSubscriptionPeriodDateAccessLayer.GetPayedSubscriptionPeriods();
        }

        public static DataView GetSubscractionPerrodByMemberID(int memberID)
        {
            return clsSubscriptionPeriodDateAccessLayer.GetSubscriptionPeriodByMemberID(memberID);
        }

        public static DataView GetSubscractionPerrodByMemberName(string Name)
        {
            return clsSubscriptionPeriodDateAccessLayer.GetSubscriptionPeriodByMemberName(Name);
        }

        public static int GetPeriodIDByPaymentID(int paymentID)
        {
            return clsSubscriptionPeriodDateAccessLayer.GetPeriodIDByPaymentID(paymentID);
        }

        public static DataView GetAllSuscriptionForMebers(int MemberID)
        {
            return clsSubscriptionPeriodDateAccessLayer.GetAllSubscriptionForMembers(MemberID);
        }

        public static int GetLastActivePeriodIDForMember(int MembeID)
        {
            return clsSubscriptionPeriodDateAccessLayer.GetLastActivePeriodIDForMember(MembeID);
        }

        public bool UpdateActivetuAndIsPaid(bool IsPaid, bool IsActive)
        {
            return clsSubscriptionPeriodDateAccessLayer.
                UpdateActivityAndIsPaid(this.periodID, IsPaid, IsActive);
        }

        public static void UpdateSubscriptionsStatusAndMembers()
        {
            clsSubscriptionPeriodDateAccessLayer.UpdateSubscriptionsStatusAndMembers();
        }






        //static void TestPayMethod()
        //{

        //    clsSubscriptionPeriod subscriptionPeriod = new clsSubscriptionPeriod
        //    {
        //        periodID = 1052,
        //        InstructorId = 1010,
        //        Fees = 3.00M,
        //        StartDate = DateTime.Now,
        //        EndDate = DateTime.Now.AddMonths(1), 
        //        MemberID = 1005,
        //        IsPaid = true,
        //    };

        //    if(subscriptionPeriod.UpdateSubscriptionPeriod())
        //    {

        //        int paymentID = subscriptionPeriod.Pay(subscriptionPeriod.Fees);


        //        if (paymentID != -1)
        //        {
        //            subscriptionPeriod.PaymentID = paymentID;



        //            if (subscriptionPeriod.UpdateSubscriptionPeriod())
        //            {
        //                Console.WriteLine($"Payment successful. Payment ID:"+subscriptionPeriod.PaymentID
        //                    );
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Payment failed");
        //        }
        //    }


        //}
        static void Main(string[] args)
        {
           // TestPayMethod();

            Console.ReadLine();
        }


    }
}


