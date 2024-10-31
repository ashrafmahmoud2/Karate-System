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

namespace Karate_System_Forms_
{
    public partial class usMain : UserControl
    {
        public enum EnMode { Member = 1, Instructor = 2, Subscriptions = 3, Payments = 4, User = 5 };
        public EnMode _mode;
        String FormName;

        public usMain()
        {
            InitializeComponent();
           // _mode = en; EnMode en
        }
        public usMain(string Name)
        {
            switch (Name)
            {
                case "Member":
                    this._mode = EnMode.Member;
                    break;
                case "Instractor":
                    this._mode = EnMode.Member;
                    break;
                case "Payment":
                    this._mode = EnMode.Member;
                    break;
                case "Subscription":
                    this._mode = EnMode.Member;
                    break;

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                if (this.ParentForm.WindowState == FormWindowState.Normal)
                {
                    this.ParentForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.ParentForm.WindowState = FormWindowState.Normal;
                }
            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Form parentForm = FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }



        //RefreshDataGridView
        public void PerformDataViewerAction()
        {
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




        // Delete operations
        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
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

        private void usMain_Load(object sender, EventArgs e)
        {

        }
    }
}
