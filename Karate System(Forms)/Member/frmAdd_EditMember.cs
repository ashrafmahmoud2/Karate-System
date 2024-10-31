using Karate_System_Forms_.subscription;
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

namespace Karate_System_Forms_.Member
{
    public partial class frmAdd_EditMember : Form
    {
        private int _MemberID;
        private clsMember _Member;
        private Color borderColor = Color.Red;
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode MemberMode = enMode.AddNew;

        public frmAdd_EditMember(int ID)
        {
            InitializeComponent();
            _MemberID = ID;
            MemberMode = (ID == -1) ? enMode.AddNew : enMode.Update;

            this.Text = "Add/Edit Member";
            this.FormBorderStyle = FormBorderStyle.None;

            // Subscribe to the Paint event if you want to draw a custom border
            this.Paint += FrmAdd_EditMember_Paint;

              _Member = new clsMember();
        }

        private void FrmAdd_EditMember_Paint(object sender, PaintEventArgs e)
        {
            // Draw a border using the Graphics object
            using (Pen pen = new Pen(borderColor, 3))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
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
                    MemberImage.Image = new Bitmap(openFileDialog.FileName);

                    // Optionally, display the file path
                    labelFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdd_EditMember_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadData()
        {
            txtMemberID.Enabled = false;
         
          


            if (MemberMode == enMode.AddNew)
            {
                _Member = new clsMember();
                labTitel.Text = "اضافة";
                txtMemberID.Text = "??";
                txtRank.DefaultText = "1";


                return;
            }
            else if (MemberMode == enMode.Update)
            {
                _Member = clsMember.FindMember(_MemberID);
                labTitel.Text = "تعديل";

                _LoadDataInUpdateForm();
            }
        }

        private void _LoadDataInUpdateForm()
        {
            txtName.Text = _Member.Name;
            txtMemberID.Text = _Member.MemberID.ToString();
            txtEmergenceContect.Text = _Member.EmergenceContect;
            txtRank.Text = _Member.LastRenkID.ToString();
            //txtIsActive.Text = _Member.IsActive.ToString();
            //txtAskTest.Text = _Member.IsActive.ToString();
            sbtn_IsActive.Checked = _Member.IsActive;
            sbtnAskForTest.Checked = _Member.AskToTest;

            txtAdress.Text = _Member.Address;
            txtPhone.Text = _Member.Phone;
            dtpDateOfBirth.Value = _Member.DateOFBirth;

            // Check if the ImagePath is not null or empty before attempting to load the image
            if (!string.IsNullOrEmpty(_Member.ImagePath) && System.IO.File.Exists(_Member.ImagePath))
            {
                MemberImage.Image = Image.FromFile(_Member.ImagePath);
            }
        }


        private void PopulateMemberFromForm()
        {
           // _Member.MemberID = _MemberID;
            _Member.Name = txtName.Text;
            _Member.EmergenceContect = txtEmergenceContect.Text;
            _Member.LastRenkID =int.Parse(txtRank.Text.ToString());
            _Member.IsActive = sbtn_IsActive.Checked;
            _Member.AskToTest = sbtnAskForTest.Checked;
            _Member.Address = txtAdress.Text;
            _Member.Phone = txtPhone.Text;
            _Member.DateOFBirth = dtpDateOfBirth.Value;
            _Member.Password = "1234";
            // _Member.AskToTest = true;
            // _Member.IsActive = Convert.ToBoolean(txtIsActive.Text);
            _Member.ImagePath = labelFilePath.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PopulateMemberFromForm();

            if (MemberMode == enMode.AddNew)
            {
                if (_Member.Save())
                {
                    MessageBox.Show("Member Update Succssfully", "Add",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    txtMemberID.Text = _Member.MemberID.ToString();
                    borderColor = Color.Green;
                    this.Invalidate();
                    btnSubscription.Visible = true;
                }
                else
                {
                    MessageBox.Show("Member Update Failed", "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    borderColor = Color.DarkRed;
                }

            }
            else if (MemberMode == enMode.Update)
            {
               
              
                if (_Member.Save())
                {

                    MessageBox.Show("Member Update Succssfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    borderColor = Color.Green;
                   this.Invalidate();
                    btnSubscription.Visible = true;

                }
                else
                {
                 
                    MessageBox.Show("Member Update Failed", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    borderColor = Color.DarkRed;
                }
            }
        }

        private void btnSubscription_Click(object sender, EventArgs e)
        {
            frmAdd_EditSubscriptions frm = new frmAdd_EditSubscriptions(-1, _Member.MemberID);
            frm.ShowDialog();
        }
    }
}
