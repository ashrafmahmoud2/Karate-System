using krate_business_Layer;
using NewProject.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.Payment
{
    public partial class frmShowPaymentDetails : Form
    {
        private int _PaymentID = -1;
        private clsPayment Payment;

        public frmShowPaymentDetails(int ID)
        {
            InitializeComponent();
            _PaymentID = ID;
            Payment = clsPayment.FindPayment(_PaymentID);

            // Subscribe to the Load event after initializing the component
            this.Load += frmShowPaymentDetails_Load;
        }

        private void frmShowPaymentDetails_Load(object sender, EventArgs e)
        {
            clsMember member = clsMember.FindMember(Payment.MemberID);
            ucMemberDatails1._FillMemberDetails(Payment.MemberID);
            ucPersoneDetails1._FillPersoneDetails(member.PersoneID);
            FillPaymentDetails();
        }

        private void FillPaymentDetails()
        {
            labPaymentID.Text = Payment.PaymentID.ToString();
            labPayfor.Text = Payment.PayFor.ToString();
            labAmount.Text = Payment.Amount.ToString();
            dtpPaytime.Value = Payment.PayTime;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
