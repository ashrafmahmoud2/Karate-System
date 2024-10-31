using krate_business_layer;
using krate_business_Layer;
using NewProject.Home;
using NewProject.Instructors;
using NewProject.Members;
using NewProject.Payment;
using NewProject.Suscription;
using NewProject.TestBelt;
using NewProject.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace NewProject.UserControls
{
    public partial class ucMainView : UserControl
    {
        // fix the   ComboSerch.SelectedIndex = 0;
        //search about the diffrenss Bettwen DataTabel, dataView 
        //make chatgpt fill the tables by sql in aribic
        //add  Historys User Control open in the specfic form;
        //make the uc of member and instructor same size, and hender ther size;
        // chect if there is no item is the date grid will be found,why there is a time be in db but hider in data grid


        // suscribtion 
        //make in stat date now date
        //hendel sbuton in add suscribtion 


        //pay 
        //make when i make sbuton in add suscribtion=on add pay in lest
        //fix the conectio  buttwen delete member and payment;

        //test 
        // add pay test 


       //tab in add suscribtion
       //fix payment history





        private DataTable _dtAllColumn;
        public enum EnMode
        {
            Member = 1, Instructor = 2, Subscriptions = 3, Payments = 4, User = 5,
            MemberInstructor = 6,BeltTest=7
        };

        public ucMainView()
        {
            InitializeComponent();
           
        }

        public EnMode _mode;

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
                        _dtAllColumn = clsMember.GetAllMember1();
                        break;
                    case EnMode.Instructor:
                        DataGridView1.DataSource = clsInstrector.GetAllInstructors();
                        _dtAllColumn = clsInstrector.GetAllInstructors();
                        break;
                    case EnMode.Subscriptions:
                        DataGridView1.DataSource = clsSubscriptionPeriod.GetAllSubscrabtionPeriod();
                        _dtAllColumn = clsSubscriptionPeriod.GetAllSubscrabtionPeriod();
                        break;
                    case EnMode.Payments:
                        DataGridView1.DataSource = clsPayment.GetAllPayments();
                        _dtAllColumn = clsPayment.GetAllPayments();
                        break;
                    case EnMode.User:
                        DataGridView1.DataSource = clsUser.GetAllUsers();
                        _dtAllColumn = clsUser.GetAllUsers();
                        break;
                    case EnMode.BeltTest:
                        DataGridView1.DataSource = clsBeltTest.GetAllBeltTests();
                        _dtAllColumn = clsBeltTest.GetAllBeltTests();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // search operations
        private void _FillComboSerch()
        {
            string[] arr = null;

            switch (_mode)
            {
                case EnMode.Member:
                    arr = new string[] { "الاشتراكات السارية", "رقم المشترك", "اسم المشترك" };
                    break;
                case EnMode.Instructor:
                    arr = new string[] { "رقم المدرب", "اسم المدرب" };
                    break;
                case EnMode.Subscriptions:
                    arr = new string[] { "اسم المدرب", "الاشتراكات المدفوعه", "رقم المشترك", "اسم المشترك" };
                    break;
                case EnMode.Payments:
                    arr = new string[] { "رقم المشترك", "تاريخ الدفع", "اسم المشترك" };
                    break;
                case EnMode.User:
                    arr = new string[] { "رقم المستخدم", "اسم المستخدم" };
                    break;
                case EnMode.BeltTest:
                    arr = new string[] { "رقم الدفع", "رقم المدرب", "اسم المدرب", "رقم المشترك", "اسم المشترك" };
                    break;
            }

            if (arr != null)
            {
                ComboSerch.Items.Clear();
                ComboSerch.Items.AddRange(arr);
            }
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
           
            _dtAllColumn.DefaultView.RowFilter = "";

            switch (_mode)
            {
                case EnMode.Member:
                    ApplyMemberFilters();
                    break;

                case EnMode.Instructor:
                    ApplyInstructorFilters();
                    break;

                case EnMode.Subscriptions:
                    ApplySubscriptionFilters();
                    break;

                case EnMode.Payments:
                    ApplyPaymentFilters();
                    break;

                case EnMode.User:
                    ApplyUserFilters();
                    break;

                case EnMode.BeltTest:
                    ApplyBeltTestFilters();
                    break;
            }

            DataGridView1.DataSource = _dtAllColumn; 
        }

        private void ApplyMemberFilters()
        {
            if (ComboSerch.Text == "اسم المشترك")
            {
                ApplyTextFilter("Name");
            }

            if (ComboSerch.Text == "رقم المشترك")
            {
                ApplyNumericFilter("MemberID");
            }

            if (ComboSerch.Text == "الاشتراكات السارية")
            {
                _dtAllColumn.DefaultView.RowFilter = "[IsActive] = true";
            }
        }

        private void ApplyInstructorFilters()
        {
            if (ComboSerch.Text == "اسم المدرب")
            {
                ApplyTextFilter("Name");
            }

            if (ComboSerch.Text == "رقم المدرب")
            {
                ApplyNumericFilter("InstructorID");
            }
        }

        private void ApplySubscriptionFilters()
        {
            if (ComboSerch.Text == "اسم المشترك")
            {
                ApplyTextFilter("MemberName");
            }

            if (ComboSerch.Text == "رقم المشترك")
            {
                ApplyNumericFilter("MemberID");
            }

            if (ComboSerch.Text == "اسم المدرب")
            {
                ApplyTextFilter("InstructorName");
            }

            if (ComboSerch.Text == "الاشتراكات السارية")
            {
                _dtAllColumn.DefaultView.RowFilter = "[IsActive] = true";
            }
        }

        private void ApplyPaymentFilters()
        {
            if (ComboSerch.Text == "اسم المشترك")
            {
                ApplyTextFilter("MameberName");
            }

            if (ComboSerch.Text == "رقم المشترك")
            {
                ApplyNumericFilter("MemberID");
            }

            if (ComboSerch.Text == "تاريخ الدفع")
            {
                ApplyDateFilter("PayTime");
            }
        }

        private void ApplyUserFilters()
        {
            if (ComboSerch.Text == "اسم المستخدم")
            {
                ApplyTextFilter("Username");
            }

            if (ComboSerch.Text == "رقم المستخدم")
            {
                ApplyNumericFilter("UserID");
            }
        }

        private void ApplyBeltTestFilters()
        {
            if (ComboSerch.Text == "اسم المشترك")
            {
                ApplyTextFilter("MemberName");
            }

            if (ComboSerch.Text == "رقم المشترك")
            {
                ApplyNumericFilter("MemberID");
            }

            if (ComboSerch.Text == "اسم المدرب")
            {
                ApplyTextFilter("InstructorName");
            }

            if (ComboSerch.Text == "رقم المدرب")
            {
                ApplyNumericFilter("TestByInstrectorID");
            }

            if (ComboSerch.Text == "رقم الدفع")
            {
                ApplyNumericFilter("PaymetID");
            }
        }

        private void ApplyTextFilter(string columnName)
        {
            _dtAllColumn.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", columnName, txtText.Text.Trim());
        }

        private void ApplyNumericFilter(string columnName)
        {
            int numericValue;
            if (int.TryParse(txtText.Text.Trim(), out numericValue))
            {
                _dtAllColumn.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, numericValue);
            }
        }

        private void ApplyDateFilter(string columnName)
        {
            DateTime dateValue;
            if (DateTime.TryParse(txtText.Text.Trim(), out dateValue))
            {
                string formattedDate = dateValue.ToString("yyyy-MM-dd");
                _dtAllColumn.DefaultView.RowFilter = string.Format("[{0}] >= #{1}# AND [{0}] < #{2}#",
                    columnName, formattedDate, dateValue.AddDays(1).ToString("yyyy-MM-dd"));
            }
        }




        ////add operations
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            PerformAdd(-1);
            _RefreshDataGridView();
        }
        private void PerformAdd(int id)
        {

            switch (_mode)
            {
                case EnMode.Member:
                    frmAdd_EditMember frm = new frmAdd_EditMember(id);
                    frm.ShowDialog();
                    break;
                case EnMode.Instructor:
                    frmAdd_EditInstractors fm = new frmAdd_EditInstractors();
                    fm.ShowDialog();
                    break;
                case EnMode.Subscriptions:
                    frmAddEditSuscription f = new frmAddEditSuscription();
                    f.ShowDialog();
                    break;
                //case EnMode.Payments:
                //    frmAdd_EditPayments fr = new frmAdd_EditPayments(id);
                //    fr.ShowDialog();
                //    break;
                case EnMode.User:
                    frmAdd_EditUsers frmuser = new frmAdd_EditUsers();
                    frmuser.ShowDialog();
                    break;
                case EnMode.BeltTest:
                    MessageBox.Show("من الممكن إضافة هذه الإضافة في المستقبل، إن شاء الله تعالى، لأنها تم مسحها بالخطأ.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;


            }
        }





       // Delete operations
        private void Delete()
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
                case EnMode.BeltTest:
                    ID = (int)DataGridView1.CurrentRow.Cells["TestID"].Value;
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
                    case EnMode.BeltTest:
                    DeleteEntity<int>(_DeleteTest, ID, "Test");
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
        private void _DeleteTest(int ID)
        {
            if (clsBeltTest.DeleteBeltTest(ID))
            {
                MessageBox.Show($"Delete Test ID {ID} successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Delete Test ID {ID} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        ////Update operations
        private void Update()
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
                    frmAdd_EditInstractors fm = new frmAdd_EditInstractors(ID);
                    fm.ShowDialog();
                    break;
                case EnMode.Subscriptions:
                    frmAddEditSuscription f = new frmAddEditSuscription(ID);
                    f.ShowDialog();
                    break;
                //case EnMode.Payments:
                //    frmAdd_EditPayments fr = new frmAdd_EditPayments(ID);
                //    fr.ShowDialog();
                //    break;
                case EnMode.User:
                    frmAdd_EditUsers frmUser = new frmAdd_EditUsers(ID);
                    frmUser.ShowDialog();
                    break;
                case EnMode.BeltTest:
                    MessageBox.Show("من الممكن إضافة هذه الإضافة في المستقبل، إن شاء الله تعالى، لأنها تم مسحها بالخطأ.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //    frmAdd_EditBeltTest frmtest = new frmAdd_EditBeltTest(ID);
                    //    frmtest.ShowDialog();
                    break;

            }
        }


        //Show Details
        private void ShowDetails()
        {
            ShowDetailsPerformense(GetIDByGridView());
            _RefreshDataGridView();
        }
        private void ShowDetailsPerformense(int ID)
        {

            switch (_mode)
            {
                case EnMode.Member:
                    frmShowMemberDetails frm = new frmShowMemberDetails(ID);
                    frm.ShowDialog();
                    break;
                case EnMode.Instructor:
                    frmShowInstructorDetails fm = new frmShowInstructorDetails(ID);
                    fm.ShowDialog();
                    break;
                case EnMode.Subscriptions:
                    frmShowSuscriptionDetails f = new frmShowSuscriptionDetails(ID);
                    f.ShowDialog();
                    break;
                case EnMode.Payments:
                    frmShowPaymentDetails fr = new frmShowPaymentDetails(ID);
                    fr.ShowDialog();
                    break;
                case EnMode.User:
                    frmShowUserDetails frmUser = new frmShowUserDetails(ID);
                    frmUser.ShowDialog();
                    break;
                case EnMode.BeltTest:
                    frmShowBeltTestDetails frmtest = new frmShowBeltTestDetails(ID);
                    frmtest.ShowDialog();
                    break;

            }
        }

        


        

        //StripMenuItem
        private void MenuStripoFmember_Opening_1(object sender, CancelEventArgs e)
        {
            //stop in make history and another thing 
            switch (_mode)
            {
                case EnMode.Member:
                    detailsToolStripMenuItem.Text = "Show Member Details";
                    updateToolStripMenuItem.Text = "Update Member";
                    delteToolStripMenuItem.Text = "Delete Member";
                    takeNextBeltTastToolStripMenuItem.Visible = true;
                    takeNextBeltTastToolStripMenuItem.Text = "Take Next Belt Test";
                    PeriodHistoryToolStripMenuItem.Text = "Show Period History";
                    TestsHistoryToolStripMenuItem.Text = "Show Tests History";
                    PaymentHistoryToolStripMenuItem.Text = "Show Payment History";
                    break;
                case EnMode.Instructor:
                    detailsToolStripMenuItem.Text = "Show Instructor Details";
                    updateToolStripMenuItem.Text = "Update Instructor";
                    delteToolStripMenuItem.Text = "Delete Instructor";
                    showHisMemberToolStripMenuItem.Visible = true;
                    PeriodHistoryToolStripMenuItem.Visible=false;
                    TestsHistoryToolStripMenuItem.Visible = false;
                    PaymentHistoryToolStripMenuItem.Visible = false;
                    break;
                case EnMode.Subscriptions:
                    detailsToolStripMenuItem.Text = "Show Period Details";
                    updateToolStripMenuItem.Text = "Update Period";
                    delteToolStripMenuItem.Text = "Delete Period";
                    reNewPeriodToolStripMenuItem.Visible = true;
                    payToolStripMenuItem.Visible=true;
                    PeriodHistoryToolStripMenuItem.Text = "Show Period History";
                    monyBackToolStripMenuItem.Visible = true;

                    TestsHistoryToolStripMenuItem.Visible = false;
                    PaymentHistoryToolStripMenuItem.Visible = false;
                   break;
                case EnMode.Payments:
                    detailsToolStripMenuItem.Text = "Show Payment Details";
                    PaymentHistoryToolStripMenuItem.Text = "Show Payment History";
                    updateToolStripMenuItem.Visible = false;
                    delteToolStripMenuItem.Visible = false;
                    PeriodHistoryToolStripMenuItem.Visible = false;
                    TestsHistoryToolStripMenuItem.Visible = false;
                    break;
                case EnMode.User:
                    detailsToolStripMenuItem.Text = "Show User Details";
                     updateToolStripMenuItem.Text = "Update User";
                    delteToolStripMenuItem.Text = "Delete User";
                     PeriodHistoryToolStripMenuItem.Visible = false;
                    TestsHistoryToolStripMenuItem.Visible = false;
                    PaymentHistoryToolStripMenuItem.Visible = false;
                    break;
                case EnMode.BeltTest:
                    detailsToolStripMenuItem.Text = "Show Test Details";
                    updateToolStripMenuItem.Text = "Update Test";
                    delteToolStripMenuItem.Text = "Delete Test";
                    takeNextBeltTastToolStripMenuItem.Visible=true;
                    takeNextBeltTastToolStripMenuItem.Text = "Take Nex Test";
                    TestsHistoryToolStripMenuItem.Text = "Show Tests History";
                    PeriodHistoryToolStripMenuItem.Visible = false;
                   
                    PaymentHistoryToolStripMenuItem.Visible = false;
                    break;



            }

        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void delteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void PaymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           int ID = (int)DataGridView1.CurrentRow.Cells["MemberID"].Value;
            frmShowPaymentHistory frm = new frmShowPaymentHistory(ID);
            frm.ShowDialog();

        }

        private void DataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            ShowDetails();

        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                clsSubscriptionPeriod period = clsSubscriptionPeriod.FindSubscriptionPeriod(GetIDByGridView());

                if (period == null)
                {
                    MessageBox.Show("Subscription period is null");
                    return;
                }

                int PaymentID = period.Pay(period.Fees);

                if (PaymentID != -1)
                {
                    period.PaymentID = PaymentID;
                    period.IsPaid = true;

                    clsSubscriptionPeriod.UpdateSubscriptionsStatusAndMembers();


                    if (period.UpdateSubscriptionPeriod())
                    {
                        MessageBox.Show("Paid successfully. Member ID: " + period.MemberID);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update subscription period");
                    }
                }
                else
                {
                    MessageBox.Show("Payment failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            _RefreshDataGridView();
        }

        private void monyBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsSubscriptionPeriod period = clsSubscriptionPeriod.FindSubscriptionPeriod(GetIDByGridView());

            if (period == null)
            {
                MessageBox.Show("Subscription period is null");
                return;
            }
            else if(period.PaymentID != -1)
            {
                period.IsPaid = false;
                period.IsActive=false;
                clsMember.SatActive(period.MemberID, false);
                clsPayment.DeletePayment(period.PaymentID);
                if (period.UpdateSubscriptionPeriod()) {
                    _RefreshDataGridView();
                    return;
                }
                else
                {
                    MessageBox.Show("Subscription period Mony back Faild");

                }
            }
            
        }

        private void PeriodHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)DataGridView1.CurrentRow.Cells["MemberID"].Value;
            frmSuscriptionHistory frm = new frmSuscriptionHistory(ID);
            frm.ShowDialog();
        }

        private void TestsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)DataGridView1.CurrentRow.Cells["MemberID"].Value;
            frmShowTestsHistory frm = new frmShowTestsHistory(ID);
            frm.ShowDialog();
        }

        private void takeNextBeltTastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("من الممكن إضافة هذه الإضافة في المستقبل، إن شاء الله تعالى.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    int ID = (int)DataGridView1.CurrentRow.Cells["MemberID"].Value;
            //    frmAdd_EditBeltTest frm = new frmAdd_EditBeltTest(ID);
            //    frm.ShowDialog();
        }

        private void showHisMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInstructorMember frm = new frmInstructorMember(GetIDByGridView());
            frm.ShowDialog();
        }

        private void reNewPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)DataGridView1.CurrentRow.Cells["MemberID"].Value;
            frmAddEditSuscription frm = new
                frmAddEditSuscription(ID, frmAddEditSuscription.enMode.Renew);
            frm.ShowDialog();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowDetails();
        }



        
    }
}
