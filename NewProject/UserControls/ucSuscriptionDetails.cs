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

namespace NewProject.UserControls
{
    public partial class ucSuscriptionDetails : UserControl
    {
        public ucSuscriptionDetails()
        {
            InitializeComponent();
        }

        public void FillPeriedDetails(int ID)
        {
            clsSubscriptionPeriod Period=clsSubscriptionPeriod.FindSubscriptionPeriod(ID);
            labPeriodID.Text = Period.periodID.ToString();
            labInstructorID.Text= Period.InstructorId.ToString();
            labMemberID.Text= Period.MemberID.ToString();
            labSTartDate.Text= Period.StartDate.ToString();
            labEndDate.Text= Period.EndDate.ToString(); 
            labFees.Text= Period.Fees.ToString();   
            labPaymentID.Text= Period.PaymentID.ToString();
            sbIsActive.Checked= Period.IsActive;
            sBIsPay.Checked = Period.IsPaid;
            labIssouRessone.Text=Period.IssueReason.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
