using krate_business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.TestBelt
{
    public partial class frmShowBeltTestDetails : Form
    {
        private int _TestID = -1;
        private clsBeltTest Test;
        public frmShowBeltTestDetails(int ID)
        {
            InitializeComponent();
            _TestID = ID;
            Test = clsBeltTest.FindBeltTest(_TestID);

            // Subscribe to the Load event after initializing the component
            this.Load += frmShowBeltTestDetails_Load;
        }

        private void frmShowBeltTestDetails_Load(object sender, EventArgs e)
        {
            clsMember member = clsMember.FindMember(Test.MemberID);
            clsInstrector instrector = clsInstrector.FindInstructor(Test.TestByInstructorID);
            labTestID.Text = Test.TestID.ToString();
            labMemberName.Text = member.Name;
           labInstructorName.Text = Test.TestByInstructorID.ToString();
            labPaymentiD.Text=Test.PaymentID.ToString();
            dtpPaytime.Value = Test.Date;
            sbResutl.Checked = Test.Result;
            labBeltName.Text = clsBeltRank.GetRankNameByRankID(Test.RankID);
           


        }
        private void FillTestDetails()
        {

        }
    }
}
