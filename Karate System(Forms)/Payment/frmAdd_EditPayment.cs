using Karate_System_Forms_.Properties;
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

namespace Karate_System_Forms_.Payment
{
    public delegate void PaymentIDEventHandler(int paymentID);
    public partial class frmAdd_EditPayment : Form
    {

        public event PaymentIDEventHandler PaymentIDEvent;

        private int _PaymentID = -1;
        private int _MemberID;
        private clsPayment _Payment;
        private Color borderColor = Color.Red;
        public enum enMode { AddNew, Update };
        private enMode Mode = enMode.AddNew;

        public frmAdd_EditPayment(int PaymentID, int MemberID)
        {
            InitializeComponent();
            _MemberID = MemberID;
            _PaymentID = PaymentID;
            Mode = (PaymentID == -1) ? enMode.AddNew : enMode.Update;
            InitializeForm();
        }

        public frmAdd_EditPayment(int PaymentID)
        {
            InitializeComponent();
            _PaymentID = PaymentID;
            Mode = (PaymentID == -1) ? enMode.AddNew : enMode.Update;
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = "Add/Edit Payment";
            this.FormBorderStyle = FormBorderStyle.None;

            // Subscribe to the Paint event
            this.Paint += FrmAdd_EditPayment_Paint;
        }

        private void FrmAdd_EditPayment_Paint(object sender, PaintEventArgs e)
        {
            // Draw a border using the Graphics object
            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdd_EditPayment_Load(object sender, EventArgs e)
        {
            _LoadData();
          
        }

        private void _LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                _Payment = new clsPayment();
                labTiel.Text = "اضافة";
                txtPaymentID.Text = "???";
                return;
            }
            else if (Mode == enMode.Update)
            {
                _Payment = clsPayment.FindPayment(_PaymentID);
                txtPaymentID.Text = _Payment.PaymentID.ToString();
                labTiel.Text = "تعديل";
                _LoadDataInUpdateForm();
            }
        }

        private void _LoadDataInUpdateForm()
        {
            txtPaymentID.Text = _Payment.PaymentID.ToString();
            txtAmount.Text = _Payment.Amount.ToString();
            txtMmebID.Text = _Payment.MemberID.ToString();
            dtpDateOFPayment.Value = _Payment.PayTime;
        }

        private void PopulateInstructorFromForm()
        {
            _Payment.PaymentID = _PaymentID;
            _Payment.MemberID = _MemberID;
            _Payment.Amount = int.Parse(txtAmount.Text);
            _Payment.PayTime = dtpDateOFPayment.Value;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            PopulateInstructorFromForm();

            if (Mode == enMode.AddNew || Mode == enMode.Update)
            {
                if (_Payment.Save())
                {
                    _LoadDataInUpdateForm();
                    MessageBox.Show("Payment " + (Mode == enMode.AddNew ? "Added" : "Updated") + " Successfully",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPaymentID.Text = _Payment.PaymentID.ToString();
                    borderColor = Color.Green;
                    this.Invalidate();
                    PaymentIDEvent?.Invoke(_Payment.PaymentID);
                }
                else
                {
                    MessageBox.Show("Payment " + (Mode == enMode.AddNew ? "Add" : "Update") + " Failed",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    borderColor = Color.DarkRed;
                }
            }
        }
    }
}
