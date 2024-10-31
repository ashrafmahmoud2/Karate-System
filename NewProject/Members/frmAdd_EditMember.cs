using Guna.UI2.WinForms;
using krate_business_Layer;
using NewProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.Members
{
    public partial class frmAdd_EditMember : Form
    {
       


        private int _MemberID = -1;
        private clsMember _Member;

        private string _ImagePath="";

        public enum EnMode { AddNew = 1, Update = 2 }
        public EnMode MemberMode = EnMode.AddNew;

        public frmAdd_EditMember(int ID)
        {
            InitializeComponent();
            _MemberID = ID;
            MemberMode = (ID == -1) ? EnMode.AddNew : EnMode.Update;

            _Member = new clsMember();
        }

        public frmAdd_EditMember()
        {
            InitializeComponent();
            MemberMode = EnMode.AddNew;
        }

        private void frmAdd_EditMember_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _FillComboBoxRank();

            if (MemberMode == EnMode.AddNew)
            {
                _Member = new clsMember();
                PersoneImagge.Image = Resources.member;
                lblTitle.Text = "اضافة";
                this.Text = "اضافة";
                txtMemberID.Text = "???";
                txtPersoneID.Text = "???";
                comboRank.SelectedIndex = comboRank.FindString("White Belt");
               
                return; 
            }
            else if (MemberMode == EnMode.Update)
            {
                _Member = clsMember.FindMember(_MemberID);
                lblTitle.Text = "تعديل";

                _LoadDataInUpdateForm();
            }
        }

        private void _LoadDataInUpdateForm()
        {
            txtName.Text = _Member.Name;
            txtPersoneID.Text = _Member.PersoneID.ToString();
            txtMemberID.Text = _Member.MemberID.ToString();
            txtEmergenceContect.Text = _Member.EmergenceContect;
            comboRank.SelectedIndex = comboRank.FindString(_Member.LastBeltRankInfo.RankName);
            txtAddress.Text = _Member.Address;
            txtPhone.Text = _Member.Phone;
            dtpDateOfBirth.Value = _Member.DateOFBirth;
            sbIsActive.Checked = _Member.IsActive;
            PersoneImagge.ImageLocation = _Member.ImagePath;
        }

        private void _FillComboBoxRank()
        {
            var RankItems = clsBeltRank.GetAllRankName();

            comboRank.Items.Clear();

            foreach (var rank in RankItems)
            {
                comboRank.Items.Add(rank.ToString());
            }
        }

        private void label10_Click_1(object sender, EventArgs e)
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
                        PersoneImagge.Image = new Bitmap(openFileDialog.FileName);
                        _Member.ImagePath = openFileDialog.FileName;
                        _ImagePath = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PopulateMemberFromForm()
        {
            _Member.Name = txtName.Text.Trim();
            _Member.EmergenceContect = txtEmergenceContect.Text.Trim();
            _Member.LastRenkID = clsBeltRank.FindBeltRank(comboRank.Text).RankID;
            _Member.Address = txtAddress.Text.Trim();
            _Member.Phone = txtPhone.Text.Trim();
            _Member.DateOFBirth = dtpDateOfBirth.Value;
            _Member.IsActive = sbIsActive.Checked;
            _Member.ImagePath = _ImagePath;

           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            PopulateMemberFromForm();
        

            if (MemberMode == EnMode.AddNew || MemberMode == EnMode.Update)
            {
                if (_Member.Save())
                {
                    MessageBox.Show($"Member {(MemberMode == EnMode.AddNew ? "Added" : "Updated")} Successfully",
                        MemberMode == EnMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMemberID.Text = _Member.MemberID.ToString();
                    lblTitle.Text = "تحديث";
                }
                else
                {
                    MessageBox.Show($"Member {(MemberMode == EnMode.AddNew ? "Add" : "Update")} Failed",
                        MemberMode == EnMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ValidateNumberInput(object sender, CancelEventArgs e)
        {
            Guna2TextBox guna2TextBox = GetGuna2TextBox(sender);
            errorProvider1.SetError(guna2TextBox, "");

            if (!int.TryParse(guna2TextBox.Text, out _) || guna2TextBox.Text.Length < 5)
            {
                errorProvider1.SetError(guna2TextBox, "الرجاء إدخال قيمة رقمية صالحة مكونة من أكثر من 5 أرقام");
                e.Cancel = true;
            }
        }

        private void ValidateStringInput(object sender, CancelEventArgs e)
        {
            Guna2TextBox guna2TextBox = GetGuna2TextBox(sender);
            errorProvider1.SetError(guna2TextBox, "");

            string[] words = guna2TextBox.Text.Split(' ');//&& (!char.IsLetter(word[0]) 

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




    }
}