using Guna.UI2.WinForms;
using Karate_System_Forms_.Payment;
using Karate_System_Forms_.Properties;
using krate_business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static krate_business_Layer.clsSubscriptionPeriod;

namespace Karate_System_Forms_.subscription
{
    public partial class frmAdd_EditSubscriptions : Form
    {
        private int _PaymentIDFromPaymentForm;

        private int _SubscriptionID = -1;
        private int _MemberID;
        private clsSubscriptionPeriod _Subscription;
        private clsInstrector _instrector; 
        private Color borderColor = Color.Red;
        public enum enMode { AddNew, Update };
        private enMode Mode = enMode.AddNew;
        public frmAdd_EditSubscriptions(int ID)
        {
            InitializeComponent();

            _SubscriptionID = ID;
            Mode = (ID == -1) ? enMode.AddNew : enMode.Update;
            this.Text = "Add/Edit Subscriptions";
            this.FormBorderStyle = FormBorderStyle.None;

            // Subscribe to the Paint event
            this.Paint += FrmAdd_EditSubscriptions_Paint;
        }
        public frmAdd_EditSubscriptions(int ID,int MemberID)
        {
            InitializeComponent();

            _SubscriptionID = ID;
            Mode = (ID == -1) ? enMode.AddNew : enMode.Update;
            _MemberID= MemberID;
            this.Text = "Add/Edit Subscriptions";
            this.FormBorderStyle = FormBorderStyle.None;

            // Subscribe to the Paint event
            this.Paint += FrmAdd_EditSubscriptions_Paint;
        }

        private void FrmAdd_EditSubscriptions_Paint(object sender, PaintEventArgs e)
        {
            // Draw a border using the Graphics object
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdd_EditSubscriptions_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            txtSubscriptionID.Enabled = false;

            if (Mode == enMode.AddNew)
            {
                _Subscription = new clsSubscriptionPeriod();
                labTitel.Text = "اضافة";
                txtSubscriptionID.Text = "???";

                return;
            }
            else if (Mode == enMode.Update)
            {
                _Subscription = clsSubscriptionPeriod.FindSubscriptionPeriod(_SubscriptionID);
                txtSubscriptionID.Text = _Subscription.periodID.ToString();
                labTitel.Text = "تعديل";
                _LoadDataInUpdateForm();


            }
        }

        private void _LoadDataInUpdateForm()
        {

             _instrector = clsInstrector.FindInstructor(_Subscription.InstructorId);
            upDown_InstructorID.Value = upDown_InstructorID.Value;
            txtName.Text = _instrector.Name;
            txtQualafation.Text = _instrector.Qualafation;
            if (!string.IsNullOrEmpty(_instrector.ImagePath) && File.Exists(_instrector.ImagePath))
            {
                InstructorImage.Image = Image.FromFile(_instrector.ImagePath);
            }
            else
                InstructorImage.Image = Resources.breaking;



           if( _MemberID != -1)
            {
               txtMemberID.Text=_Subscription.MemberID.ToString();
            }
           else
            {
                txtMemberID.Text = _MemberID.ToString();
            }

           txtSubscriptionID.Text = _SubscriptionID.ToString(); 
            dtpStartDate.Value = _Subscription.StartDate;
            dtpEndDate.Value = _Subscription.EndDate;
            txtAmount.Text = _Subscription.Fees.ToString();
            txtIssueReason.Text = _Subscription.IssueReasonText;//fix IssueReasonText
            txtPaymetnID.Text = _Subscription.PaymentID.ToString();
            sbtnIsActive.Checked = _Subscription.IsActive;
            sbtnIsPay.Checked = _Subscription.IsPaid;



        }

        private void PopulateInstructorFromForm()
        {
            //Convert.ToInt32(upDown_InstructorID.Value)
            _Subscription.InstructorId = 1013;//fix istructor and update in delete//Same proplem whith pay
            _Subscription.MemberID = _MemberID;
            _Subscription.StartDate = dtpStartDate.Value;
            _Subscription.EndDate = dtpEndDate.Value;
            _Subscription.Fees = Convert.ToDecimal(txtAmount.Text);
           // _Subscription.IssueReason = txtIssueReason.Text;
            _Subscription.PaymentID = _PaymentIDFromPaymentForm;//take tht number from payment the is paid =true
            _Subscription.IsPaid = (_Subscription.PaymentID != null);
            _Subscription.IsActive = sbtnIsActive.Checked;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            PopulateInstructorFromForm();

            // see the vido of delget

            if (Mode == enMode.AddNew || Mode == enMode.Update)
            {
                if (_Subscription.Save())
                {
                    _LoadDataInUpdateForm();
                    MessageBox.Show("Subscription " + (Mode == enMode.AddNew ? "Added" : "Updated") + " Successfully",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtSubscriptionID.Text =_Subscription.periodID.ToString();
                    borderColor = Color.Green;
                    this.Invalidate();
                    btnPay.Visible = true;

                }
                else
                {
                    MessageBox.Show("Subscription " + (Mode == enMode.AddNew ? "Add" : "Update") + " Failed",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    borderColor = Color.DarkRed;
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            frmAdd_EditPayment FRM=new frmAdd_EditPayment(-1,_Subscription.MemberID);
            FRM.PaymentIDEvent += HandlePaymentIDEvent;
            FRM.ShowDialog(this);
            FRM.PaymentIDEvent -= HandlePaymentIDEvent;
        }
        private void HandlePaymentIDEvent(int paymentID)
        {
            _PaymentIDFromPaymentForm = paymentID;
         
            txtPaymetnID.Text = _PaymentIDFromPaymentForm.ToString();
        }
    }
}

