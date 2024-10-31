using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static krate_business_Layer.clsMemberInstructor;

using System.Runtime.Remoting.Lifetime;
using System.Data;

namespace krate_business_Layer
{
    public class clsBeltRank
    {
        public enum enBeltRankMode { AddNew = 0, Update = 1 }
        public enBeltRankMode BeltRankMode { get; set; }

        public int RankID { get; set; }
        public string RankName { get; set; }
        public decimal TestFees { get; set; }

        public clsBeltRank()
        {
            this.RankID = -1;
            this.RankName = string.Empty;
            this.TestFees = -1M;

            
            this.BeltRankMode = enBeltRankMode.AddNew;
        }

        public clsBeltRank(int RankID, string RankName, decimal TestFees)
        {
            this.RankID = RankID;
            this.RankName = RankName;
            this.TestFees = TestFees;
            this.BeltRankMode = enBeltRankMode.AddNew;
        }

        private bool AddNewBeltRank()
        {
            this.RankID = clsBeltRankDateAccessLayer.AddNewBeltRank(
                this.RankName, this.TestFees);

            return this.RankID > -1;
        }

        private bool UpdateBeltRank()
        {
            return clsBeltRankDateAccessLayer.UpdateBeltRank(
                this.RankID, this.RankName, this.TestFees);
        }

        public bool Save()
        {
            switch (this.BeltRankMode)
            {
                case enBeltRankMode.AddNew:
                    return AddNewBeltRank();
                case enBeltRankMode.Update:
                    return UpdateBeltRank();
            }
            return false;
        }

        public static clsBeltRank FindBeltRank(int rankID)
        {
            string rankName = string.Empty;
            decimal testFees = -1M;
           

            if (clsBeltRankDateAccessLayer.GetBeltRankInfo(rankID, ref rankName, ref testFees))
            {
                return new clsBeltRank
                {
                    RankID = rankID,
                    RankName = rankName,
                    TestFees = testFees,
                    BeltRankMode = enBeltRankMode.AddNew
                };
            }

            return null;
        }
        public static clsBeltRank FindBeltRank(string rankName)
        {
            int RankID = -1;
            decimal testFees = -1M;


            if (clsBeltRankDateAccessLayer.GetBeltRankInfoByName(rankName, ref RankID, ref testFees))
            {
                return new clsBeltRank
                {
                    RankID = RankID,
                    RankName = rankName,
                    TestFees = testFees,
                    
                };
            }

            return null;
        }

        public static bool IsBeltRankExists(int rankID)
        {
            return clsBeltRankDateAccessLayer.IsBeltRankExists(rankID);
        }

        public static bool DeleteBeltRank(int rankID)
        {
            return clsBeltRankDateAccessLayer.DeleteBeltRank(rankID);
        }
        public static List<string> GetAllRankName()
        {
            return clsBeltRankDateAccessLayer.GetAllRankNames();
        }
        public static string GetRankNameByRankID(int rankID)
        {
            return clsBeltRankDateAccessLayer.GetRankNameByRankID(rankID);
        }

        public static int GetNextBeltRankID( int lastRankID)
        {
            return clsBeltRankDateAccessLayer.GetNextBeltRankID(lastRankID);
        }

        public static  DataView GetAllBeltRank()
        {
            return clsBeltRankDateAccessLayer.GetAllBeltRank();
        }

       

        //static void Main(string[] args)
        //{





        //    Console.ReadLine();
        //}






    }
}
