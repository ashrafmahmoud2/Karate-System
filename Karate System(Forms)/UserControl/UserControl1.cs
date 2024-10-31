using Karate_System_Forms_.Instractor;
using Karate_System_Forms_.Member;
using Karate_System_Forms_.Payment;
using Karate_System_Forms_.subscription;
using Karate_System_Forms_.Users;
using krate_business_layer;
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
using static Karate_System_Forms_.UserControl1;

namespace Karate_System_Forms_
{
    public partial class UserControl1 : UserControl
    {

        //add memberinstractor 
        //member face
        public enum EnMode { Member = 1, Instructor = 2, Subscriptions = 3, Payments = 4, User = 5 ,
        MemberInstructor=6};
        public EnMode _mode;
 


        public UserControl1()
        {
            InitializeComponent();
           
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            PerformDataViewerAction(_mode);
        }

        //RefreshDataGridView
        public void PerformDataViewerAction(EnMode en)
        {
            _mode = en;
            _RefreshDataGridView();
            _FillComboSerch();
        }

        private void _RefreshDataGridView()
        {
            try
            {
                switch (_mode)
                {
                    case EnMode.Member:
                        DataGridView1.DataSource = clsMember.GetAllMember();
                        break;
                    case EnMode.Instructor:
                        DataGridView1.DataSource = clsInstrector.GetAllInstructors();
                        break;
                    case EnMode.Subscriptions:
                        DataGridView1.DataSource = clsSubscriptionPeriod.GetAllSubscrabtionPeriod();
                        break;
                    case EnMode.Payments:
                        DataGridView1.DataSource = clsPayment.GetAllPayments();
                        break;
                    case EnMode.User:
                        DataGridView1.DataSource = clsUser.GetAllUsers();
                        break;
                    default:
                        // Handle default case appropriately
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // search operations
        private void btnSerach_Click(object sender, EventArgs e)
        {
            string searchText = txtText.Text;
            string selectedChoice = ComboSerch.SelectedItem as string;

            //  if (!string.IsNullOrEmpty(searchText) && selectedChoice != null)
            //  {
            switch (_mode)
            {
                case EnMode.Member:
                    DataGridView1.DataSource = GetMemberChoiceInDataGridView(searchText, selectedChoice);
                    break;
                case EnMode.Instructor:
                    DataGridView1.DataSource = GetInstructorChoiceInDataGridView(searchText, selectedChoice);
                    break;
                case EnMode.Subscriptions:
                    DataGridView1.DataSource = GetSubscriptionsChoiceInDataGridView(searchText, selectedChoice);
                    break;
                case EnMode.Payments:
                    DataGridView1.DataSource = GetPaymentsChoiceInDataGridView(searchText, selectedChoice);
                    break;
                case EnMode.User:
                    DataGridView1.DataSource = GetUserChoiceInDataGridView(searchText, selectedChoice);
                    break;
            }
        }

        private void _FillComboSerch()
        {
            string[] arr = null;

            switch (_mode)
            {
                case EnMode.Member:
                    labTitel.Text = " المشتركين";
                    arr = new string[] { "الاشتراكات السارية", "رقم المشترك", "اسم المشترك" };
                    break;
                case EnMode.Instructor:
                    labTitel.Text = " المدربين";
                    arr = new string[] { "رقم المدرب", "اسم المدرب" };
                    break;
                case EnMode.Subscriptions:
                    labTitel.Text = " الاشتراكات";
                    arr = new string[] { "الاشتراكات المدفوعه", "رقم المشترك", "اسم المشترك" };
                    break;
                case EnMode.Payments:
                    labTitel.Text = " الدفع";
                    arr = new string[] { "رقم المشترك", "تاريخ الدفع", "اسم المشترك" };
                    break;
                case EnMode.User:
                    labTitel.Text = " المستخدمين";
                    arr = new string[] { "رقم المستخدم", "اسم المستخدم" };
                    break;
            }

            if (arr != null)
            {
                ComboSerch.Items.Clear();
                ComboSerch.Items.AddRange(arr);
            }
        }

        private DataView GetMemberChoiceInDataGridView(string searchText, string selectedChoice)
        {
            switch (selectedChoice)
            {
                case "اسم المشترك":
                    return clsMember.GetMemberbyName(searchText);
                case "رقم المشترك":
                    return clsMember.GetMemberbymemberID(int.Parse(searchText));
                case "الاشتراكات السارية":
                    return clsMember.GetMemberActive();
                    
            }
            return null;
        }

        private DataView GetInstructorChoiceInDataGridView(string searchText, string selectedChoice)
        {
            switch (selectedChoice)
            {
                case "اسم المدرب":
                    return clsInstrector.GetInstructorByName(searchText);
                case "رقم المدرب":
                    return clsInstrector.GetInstructorByInstructorID(int.Parse(searchText));
            }
            return null;
        }

        private DataView GetSubscriptionsChoiceInDataGridView(string searchText, string selectedChoice)
        {
            switch (selectedChoice)
            {

                case "الاشتراكات المدفوعه":
                    return clsSubscriptionPeriod.GetAllIsPaySubscractionPerrod();
                case "اسم المشترك":
                    return clsSubscriptionPeriod.GetSubscractionPerrodByMemberName(searchText);
                 case "رقم المشترك":
                    return clsSubscriptionPeriod.GetSubscractionPerrodByMemberID(int.Parse(searchText));
                   
            }

            return null;
        }

        private DataView GetPaymentsChoiceInDataGridView(string searchText, string selectedChoice)
        {
            switch (selectedChoice)
            {
                case "اسم المشترك":
                    return clsPayment.GetPaymentByMeberName(searchText);
                case "تاريخ الدفع":
                    if (DateTime.TryParse(searchText, out DateTime parsedDate))
                    {
                        return clsPayment.GetPaymentByDateTime(parsedDate);
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format. Please enter a valid date.");
                        return null;
                    }
                case "رقم المشترك":
                    return clsPayment.GetPaymentByID(int.Parse(searchText));

            }
            return null;
        }

        private DataView GetUserChoiceInDataGridView(string searchText, string selectedChoice)
        {
            switch (selectedChoice)
            {
                case "اسم المستخدم":
                    return clsUser.GetUserbyUserName(searchText);
                case "رقم المستخدم":
                    return clsUser.GetUserbyUserID(int.Parse(searchText));
            }
            return null;
        }



        // Delete operations
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePerformense(GetIDByGridView());
            _RefreshDataGridView();
        }

        private int GetIDByGridView()
        {
            int ID = -1;
            switch (_mode)
            {
                case EnMode.Member:
                    ID = (int)DataGridView1.CurrentRow.Cells["MemberID"].Value;
                    break;
                case EnMode.Instructor:
                    ID = (int)DataGridView1.CurrentRow.Cells["InstructorID"].Value;
                    break;
                case EnMode.Subscriptions:
                    ID = (int)DataGridView1.CurrentRow.Cells["PeriodID"].Value;
                    break;
                case EnMode.Payments:
                    ID = (int)DataGridView1.CurrentRow.Cells["PaymentID"].Value;
                    break;
                case EnMode.User:
                    ID = (int)DataGridView1.CurrentRow.Cells["UserID"].Value;
                    break;
                default:
                    // Handle default case appropriately
                    break;

            }
            return ID;
        }
        private void DeletePerformense(int ID)
        {
            switch (_mode)
            {
                case EnMode.Member:
                    DeleteEntity<int>(_DeleteMember, ID, "Member");
                    break;
                case EnMode.Instructor:
                    DeleteEntity<int>(_DeleteInstructor, ID, "Instructor");
                    break;
                case EnMode.Subscriptions:
                    DeleteEntity<int>(_DeleteSubscriptionPeriod, ID, "Subscription Period");
                    break;
                case EnMode.Payments:
                    DeleteEntity<int>(_DeletePayment, ID, "Payment");
                    break;
                case EnMode.User:
                    DeleteEntity<int>(_DeleteUser, ID, "User");
                    break;
                default:
                    // Handle default case appropriately
                    break;
            }
        }

        private void DeleteEntity<T>(Action<T> deleteFunction, T ID, string entityName)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the {entityName} with ID {ID}?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                deleteFunction(ID);
            }
            else
            {
                MessageBox.Show($"Delete operation for {entityName} canceled", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _DeleteMember(int ID)
        {
            if (clsMember.DeleteMember(ID))
            {
                MessageBox.Show($"Delete Member ID {ID} successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Delete Member ID {ID} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DeleteInstructor(int ID)
        {
            if (clsInstrector.DeleteInstructor(ID))
            {
                MessageBox.Show($"Delete Instractor ID {ID} successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Delete Instractor ID {ID} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DeleteSubscriptionPeriod(int ID)
        {
            if (clsSubscriptionPeriod.DeleteSubscriptionPeriod(ID))
            {
                MessageBox.Show($"Delete Subscription ID {ID} successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Delete Subscription ID {ID} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DeletePayment(int ID)
        {
            if (clsPayment.DeletePayment(ID))
            {
                MessageBox.Show($"Delete Payment ID {ID} successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Delete Payment ID {ID} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DeleteUser(int ID)
        {
            if (clsUser.DeleteUser(ID))
            {
                MessageBox.Show($"Delete User ID {ID} successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Delete User ID {ID} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //add operations
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPerformense(-1);
            _RefreshDataGridView();
        }
        private void AddPerformense(int ID)
        {
            
            switch (_mode)
            {
                case EnMode.Member:
                    frmAdd_EditMember frm = new frmAdd_EditMember(ID);
                    frm.ShowDialog();
                    break;
                case EnMode.Instructor:
                    frmAdd_EditInstractor fm = new frmAdd_EditInstractor(ID);
                    fm.ShowDialog();
                    break;
                case EnMode.Subscriptions:
                    frmAdd_EditSubscriptions f = new frmAdd_EditSubscriptions(ID);
                    f.ShowDialog();
                    break;
                case EnMode.Payments:
                    frmAdd_EditPayment fr = new frmAdd_EditPayment(ID);
                    fr.ShowDialog();
                    break;
                case EnMode.User:
                    frmAdd_EditUser frmUser = new frmAdd_EditUser(ID);
                    frmUser.ShowDialog();
                    break;
            }
        }

        //Update operations
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePerformense(GetIDByGridView());
            _RefreshDataGridView();
        }
        private void UpdatePerformense(int ID)
        {
            
            switch (_mode)
            {
                case EnMode.Member:
                    frmAdd_EditMember frm = new frmAdd_EditMember(ID);
                    frm.ShowDialog();
                    break;
                case EnMode.Instructor:
                    frmAdd_EditInstractor fm = new frmAdd_EditInstractor(ID);
                    fm.ShowDialog();
                    break;
                case EnMode.Subscriptions:
                    frmAdd_EditSubscriptions f = new frmAdd_EditSubscriptions(ID);
                    f.ShowDialog();
                    break;
                case EnMode.Payments:
                    frmAdd_EditPayment fr = new frmAdd_EditPayment(ID);
                    fr.ShowDialog();
                    break;
                case EnMode.User:
                    frmAdd_EditUser frmUser = new frmAdd_EditUser(ID);
                    frmUser.ShowDialog();
                    break;
            }
        }


        //private void btnClose_Click_1(object sender, EventArgs e)
        //{
        //    if (this.ParentForm != null)
        //    {
        //        this.ParentForm.Close();
        //    }
        //}

        //private void btnMaximize_Click(object sender, EventArgs e)
        //{
        //    if (this.ParentForm != null)
        //    {
        //        if (this.ParentForm.WindowState == FormWindowState.Normal)
        //        {
        //            this.ParentForm.WindowState = FormWindowState.Maximized;
        //        }
        //        else
        //        {
        //            this.ParentForm.WindowState = FormWindowState.Normal;
        //        }
        //    }

        //}

        //private void btnMinimize_Click_1(object sender, EventArgs e)
        //{

        //    Form parentForm = FindForm();
        //    if (parentForm != null)
        //    {
        //        parentForm.WindowState = FormWindowState.Minimized;
        //    }
        //}

    }
}









