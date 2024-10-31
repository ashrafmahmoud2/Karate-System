using krate_business_Layer;
using NewProject.Members;
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
using System.Xml.Linq;


namespace NewProject.Suscription
{
    public partial class frmAddEditSuscription : Form 
    {
        // fix  proplem whene moneyback and pay again;
        //Cose in pay ,search about issou reesone ,fix is Ective

       
        //3- fix make Period Start Whene the the data start and stop when it end end stop is active
        //6-make the valdation

        private int _MemberID;
        private int _InstructorID;
        private int _PeriodID=-1;
        private clsSubscriptionPeriod _Subscription;
        public enum enMode { AddNew = 1, Update = 2 ,Renew=3}
        public enMode SubscriptionMode = enMode.AddNew;

        public frmAddEditSuscription()
        {
            InitializeComponent();
            tabPage4.Text = "المدربين";
            SubscriptionMode = enMode.AddNew ;
        }

        public frmAddEditSuscription(int ID)
        {
            _PeriodID = ID;
            SubscriptionMode = enMode.Update;
            _Subscription = new clsSubscriptionPeriod();
            InitializeComponent();
            tabPage4.Text = "المدربين";
        }
        public frmAddEditSuscription(int ID, enMode SubscriptionMode)
        {
            _MemberID = ID;
            SubscriptionMode = enMode.Renew;
            _Subscription = new clsSubscriptionPeriod();
            InitializeComponent();
            tabPage4.Text = "المدربين";
        }

        // but combbox in the fillter
        //private void _FillComboBoxNames()
        //{
        //    DataTable _MemberNames = clsMember.GetAllMembersNames();
        //    DataTable _InstructorNames = clsInstrector.GetAllInstructorsNames();

        //    _FillComboBoxFromDataTable(cmMemberssNames, _MemberNames);
        //    _FillComboBoxFromDataTable(cmInstructorsNames, _InstructorNames);

        //    _MemberID = GetSelectedMemberID();
        //    _InstructorID = GetSelectedInstructorID();
        //}

        //private void _FillComboBoxFromDataTable(ComboBox comboBox, DataTable dataTable)
        //{
        //    comboBox.Items.Clear();
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        comboBox.Items.Add(row["Name"].ToString());
        //    }
        //}

        //private int GetSelectedMemberID()
        //{
        //    return (cmMemberssNames.SelectedItem != null) ?
        //        clsMember.GetMemberIDByMemberName((string)cmMemberssNames.SelectedItem) : -1;
            
        //}

        //private int GetSelectedInstructorID()
        //{
        //    return (cmInstructorsNames.SelectedItem != null) ?
        //        clsInstrector.GetInstractorIDByInstractorName((string)cmInstructorsNames.SelectedItem) : -1;
        //}

        private void frmAddEditSuscription_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

      



        private void _LoadData()
        {
            

            if (SubscriptionMode == enMode.AddNew)
            {
                InitializeAddNewSubscription();
            }
            else if (SubscriptionMode == enMode.Update)
            {
                InitializeUpdateSubscription();
            }
            else if (SubscriptionMode == enMode.Renew)
            {
                InitializeRenewSubscription();
            }
        }

        private void InitializeAddNewSubscription()
        {

            _Subscription = new clsSubscriptionPeriod();
            lblTitle.Text = "اضافة";
            txtPeriodeID.Text = "???";
           txtMemberID_.Text = ucMemberDetailsWithFilter1.MemberiIDDone.ToString();
            txtPaymentID.Visible=false;

            txtInstructorID.Text = _InstructorID.ToString();
            return;
        }

        private void InitializeUpdateSubscription()
        {
            _Subscription = clsSubscriptionPeriod.FindSubscriptionPeriod(_PeriodID);
            lblTitle.Text = "تعديل";
            txtPeriodeID.Text = _PeriodID.ToString();
            txtMemberID_.Text = _Subscription.MemberID.ToString();
            txtInstructorID.Text = _Subscription.InstructorId.ToString();
         


            _LoadDataInUpdateForm();
        }

        private void InitializeRenewSubscription()
        {
            _Subscription = new clsSubscriptionPeriod();
            lblTitle.Text = "renew";
            txtPeriodeID.Text = "???";
            txtMemberID_.Text = _MemberID.ToString();
         
        }

        private void _LoadDataInUpdateForm()
        {
            ucMemberDetailsWithFilter1.FillMemberDetails(_Subscription.MemberID);
            ucInstructorDetailsWithFiler1.FillInstructorDetails(_Subscription.InstructorId);
            txtPeriodeID.Text = _Subscription.periodID.ToString();
            txtMemberID_.Text = _Subscription.MemberID.ToString();
            txtInstructorID.Text = _Subscription.InstructorId.ToString();
            dtpStartDate.Value = _Subscription.StartDate;
            dtpEndTime.Value = _Subscription.EndDate;
            txtFees.Text = _Subscription.Fees.ToString();
            txtPaymentID.Text = _Subscription.PaymentID.ToString();
            txtIssouResone.Text = _Subscription.IssueReason.ToString();
            sbIsActive.Checked = _Subscription.IsActive;
            sBIsPay.Checked = _Subscription.IsPaid;
        }

        private void UpdateSubscriptionFromForm()
        {
            // I Make Payment ID in Date base = null after pay;
            _Subscription.periodID = Convert.ToInt32(_Subscription.periodID);
             _Subscription.MemberID = ucMemberDetailsWithFilter1.MemberiIDDone;
            _Subscription.InstructorId = ucInstructorDetailsWithFiler1.InstructorIsDone;
            _Subscription.StartDate = dtpStartDate.Value;

            if (UpDownMonthNumber.Value != 0)
            {
                if (SubscriptionMode == enMode.AddNew)
                {
                    _Subscription.EndDate = dtpStartDate.Value.AddMonths((int)UpDownMonthNumber.Value);
                }
                else
                {
                    
                    _Subscription.EndDate = _Subscription.EndDate.AddMonths((int)UpDownMonthNumber.Value);
                  
                }
            }
            else
            {
                _Subscription.EndDate = dtpEndTime.Value;
            }
            dtpEndTime.Value = _Subscription.EndDate;





            _Subscription.Fees = Convert.ToDecimal(txtFees.Text);
            _Subscription.IsActive = sbIsActive.Checked;
            _Subscription.IsPaid = sBIsPay.Checked;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            UpdateSubscriptionFromForm();

            if (SubscriptionMode == enMode.AddNew || SubscriptionMode == enMode.Update)
            {
                if (_Subscription.Save())
                {
                    MessageBox.Show($"Subscription {(SubscriptionMode == enMode.AddNew ? "Added" : "Updated")} Successfully",
                        SubscriptionMode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPeriodeID.Text = _Subscription.periodID.ToString();

                    this.Invalidate();
                    SubscriptionMode = enMode.Update;
                    // _LoadData();
                }
                else
                {
                    MessageBox.Show($"Subscription {(SubscriptionMode == enMode.AddNew ? "Add" : "Update")} Failed",
                        SubscriptionMode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           txtMemberID_.Text = ucMemberDetailsWithFilter1.MemberiIDDone.ToString();
           txtInstructorID.Text = ucInstructorDetailsWithFiler1.InstructorIsDone.ToString();
        }


        

    }
}

