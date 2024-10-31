using Guna.UI2.WinForms;
using krate_business_layer;
using krate_business_Layer;
using NewProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;


namespace NewProject.Users
{
    public partial class frmAdd_EditUsers : Form
    {
        // Saying the vido of BitWise Again,and Ask My Brother About Bool;
        // Chage Permission From 1 to Permission Name or
        // How Many Permissoin or the number of scress he has accsess;

        public delegate void DataBackEventHander(object sender, int UserID);
        public event DataBackEventHander UserIDBack;

        private int _UserID;
        private clsUser _User;

        public enum enMode { AddNew = 1, Update = 2 }
        public enMode UserMode = enMode.AddNew;

        private string _ImagePath = "";

        public frmAdd_EditUsers()
        {
            InitializeComponent();

            UserMode = enMode.AddNew;
        }

        public frmAdd_EditUsers(int ID)
        {
            InitializeComponent();
            this._UserID = ID;
            this.UserMode = enMode.Update;

            _User = new clsUser();
        }

        public frmAdd_EditUsers(int UserID, bool ShowPermissions)
        {
            InitializeComponent();
            this._UserID = UserID;
            UserMode = enMode.AddNew;

            gbPermissions.Enabled = ShowPermissions;
            // chkIsActive.Enabled = ShowPermissions;
        }

        private void frmAdd_EditUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            if (UserMode == enMode.AddNew)
            {
                _User = new clsUser();
                lblTitle.Text = "اضافة";
                this.Text = "اضافة مستخدم";
                txtUseID2.Text = "???";
                txtPersoneID.Text = "???";
                UserImage2.Image = Resources.add_new
                    ;
                return;
            }
            else if (UserMode == enMode.Update)
            {
                _User = clsUser.FindUser(_UserID);
                lblTitle.Text = "تعديل";
                this.Text = "تعديل";

                _LoadDataInUpdateForm();
            }
        }

        private void _LoadDataInUpdateForm()
        {
            txtUseID2.Text = _User.UserID.ToString();
            txtUserName2.Text = _User.Username;
            txtPassWord2.Text = _User.Password.ToString();
            txtName2.Text = _User.Name;
            txtPersoneID2.Text = _User.PersoneID.ToString();
            txtAddress2.Text = _User.Address;
            txtPhone2.Text = _User.Phone;
            DateTimePicker1.Value = _User.DateOFBirth;
            UserImage2.ImageLocation = _User.ImagePath;

            _FillCheckBoxPermissions();
        }

        private void PopulateMemberFromForm()
        {
            //  _User.UserID = Convert.ToInt32(txtUseID.Text);
            _User.Username = txtUserName2.Text.Trim();
            _User.Password = txtPassWord2.Text.Trim();
            _User.Permissions = _CountPermissions();
            _User.Name = txtName2.Text.Trim();
            _User.Address = txtAddress2.Text.Trim();
            _User.Phone = txtPhone2.Text.Trim();
            _User.DateOFBirth = DateTimePicker1.Value;
            _User.ImagePath = _ImagePath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_DoesNotSelectAnyPermission())
            {
                MessageBox.Show("You have to select permissions for the user!",
                       "Permissions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopulateMemberFromForm();

            if (UserMode == enMode.AddNew || UserMode == enMode.Update)
            {
                if (_User.Save())
                {
                    MessageBox.Show($"User {(UserMode == enMode.AddNew ? "Added" : "Updated")} Successfully",
                        UserMode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UserIDBack?.Invoke(this, _User.UserID);
                    txtUseID2.Text = _User.UserID.ToString();

                    this.Invalidate();
                    lblTitle.Text = "تحديث";
                }
                else
                {
                    MessageBox.Show($"User {(UserMode == enMode.AddNew ? "Add" : "Update")} Failed",
                        UserMode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        UserImage2.Image = new Bitmap(openFileDialog.FileName);
                        _User.ImagePath = openFileDialog.FileName;
                        _ImagePath = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }








        //Permissions
        private bool _IsAllItemIsChecked()
        {
            foreach (CheckBox Item in gbPermissions.Controls)
            {
                if (Item.Tag.ToString() != "-1")
                {
                    if (!Item.Checked)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool _DoesNotSelectAnyPermission()
        {
            foreach (CheckBox Item in gbPermissions.Controls)
            {
                if (Item.Checked)
                {
                    return false;
                }
            }
            return true;
        }

        private void chkAllPermissions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllPermissions.Checked)
            {
                foreach (CheckBox Item in gbPermissions.Controls)
                {
                    Item.Checked = true;
                }
            }
        }

        private void _FillCheckBoxPermissions()
        {
            if (_User.Permissions == -1)
            {
                chkAllPermissions.Checked = true;
            }
            foreach (CheckBox Item in gbPermissions.Controls)
            {
                if (Item.Tag.ToString() != "-1")
                {
                    if (((Convert.ToInt32(Item.Tag)) & _User.Permissions)
                        == (Convert.ToInt32(Item.Tag)))
                    {
                        Item.Checked = true;
                    }
                }
            }
        }

        private int _CountPermissions()
        {
            int Permissions = 0;
            if (chkAllPermissions.Checked)
                return -1;

            if (chkManageMembers.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageMembers;

            if (chkManageInstructors.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageInstructors;

            if (chkManageSubscriptionPeriods.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageSubscriptionPeriods;

            if (chkManageBeltTests.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageBeltTests;

            if (chkManagePayments.Checked)
                Permissions += (byte)clsUser.enPermissions.ManagePayments;

            if (chkManageUsers.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageUsers;

            return Permissions;
        }

       

        //Validating
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(UserMode==enMode.Update)
            {
              
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserName2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "UserName cannot be empty.");
            }

            if (clsUser.IsUserExists(txtUserName2.Text))
            {
                e.Cancel = true;
                txtUserName2.Focus();
                errorProvider1.SetError(txtUserName2, "username is used by another user");
            }
            else
            {
                errorProvider1.SetError(txtUserName2, null);
            }
        }
        private void ValidateStringInput(object sender, CancelEventArgs e)
        {
            Guna2TextBox guna2TextBox = GetGuna2TextBox(sender);
            errorProvider1.SetError(guna2TextBox, "");

            string[] words = guna2TextBox.Text.Split(' ');

            // Check if the text is empty or has less than three words or starts with a non-letter character
            if (string.IsNullOrWhiteSpace(guna2TextBox.Text) || words.Length < 3)
            {
                errorProvider1.SetError(guna2TextBox, "الرجاء إدخال قيمة نصية صالحة مكونة من ثلاث كلمات بالضبط وبدون أرقام أو مسافات.");
                e.Cancel = true;
            }
        }
        private Guna2TextBox GetGuna2TextBox(object sender)
        {
            return sender as Guna2TextBox;
        }
        private void ValidateNumberInput(object sender, CancelEventArgs e)
        {
            Guna2TextBox guna2TextBox = GetGuna2TextBox(sender);
            errorProvider1.SetError(guna2TextBox, "");

            if (!int.TryParse(guna2TextBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture,
                out _) || guna2TextBox.Text.Length < 4)
            {
                errorProvider1.SetError(guna2TextBox, "الرجاء إدخال قيمة رقمية صالحة مكونة من أكثر من 4 أرقام");
            }
        }
    }
}

