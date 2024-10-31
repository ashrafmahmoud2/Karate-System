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
namespace Karate_System_Forms_.Users
{
    public partial class frmAdd_EditUser : Form
    {
        private int _UserID;
        private clsUser _User;
        private Color borderColor = Color.Red;

        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public frmAdd_EditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            Mode = (UserID == -1) ? enMode.AddNew : enMode.Update;
            this.Text = "Add/Edit User";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Paint += FrmAdd_EditUser_Paint;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Set the selected image to the PictureBox
                    UserImage.Image = new Bitmap(openFileDialog.FileName);
                    // Optionally, display the file path
                    // labelFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void FrmAdd_EditUser_Paint(object sender, PaintEventArgs e)
        {
            // Draw a border using the Graphics object
            using (Pen pen = new Pen(borderColor, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdd_EditUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                _User = new clsUser();
                labTitel.Text = "اضافة";
                txtUserID.Text = "???";
                txtPersoneID.Text = "???";
                return;
            }
            else if (Mode == enMode.Update)
            {
                _User = clsUser.FindUser(_UserID);
                labTitel.Text = "تعديل";
                _LoadDataInUpdateForm();
            }
        }

        private void _LoadDataInUpdateForm()
        {
            txtName.Text = _User.Username;
            txtUserID.Text = _User.UserID.ToString();
            txtPersoneID.Text = _User.PersoneID.ToString();
            txtPassWord.Text = _User.Password;
          //  txtPermission.Text = _User.Permissions.ToString();
            DateTimeUser.Value = _User.DateOFBirth;
            txtPhoen.Text = _User.Phone;
            txtAddress.Text = _User.Address;
          //  UserImage.Image = _User.ImagePath;
        }

        private void PopulateMemberFromForm()
        {
            _User.Name = txtName.Text;
            _User.Username = txtName.Text;
            _User.UserID = _UserID;
            _User.Password = txtPassWord.Text;
          //  _User.Permissions = int.Parse(txtPermission.Text);
            _User.DateOFBirth = DateTimeUser.Value;
            _User.Phone = txtPhoen.Text;
            _User.Address = txtAddress.Text;
          //  _User.ImagePath = Image.UserImage;
        }

        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            PopulateMemberFromForm();
            if (Mode == enMode.AddNew || Mode == enMode.Update)
            {
                
                if (_User.Save())
                {
                    MessageBox.Show("user " + (Mode == enMode.AddNew ? "Added" : "Updated") + " Successfully",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtUserID.Text = _User.UserID.ToString();
                    borderColor = Color.Green;
                    this.Invalidate();
                }
                else
                {
                    MessageBox.Show("user " + (Mode == enMode.AddNew ? "Add" : "Update") + " Failed",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    borderColor = Color.DarkRed;
                }
            }
        }
    }
}
