using Guna.UI2.WinForms;
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

namespace NewProject.Instructors
{
    public partial class frmAdd_EditInstractors : Form
    {
        private int _InstructoID = -1;
        private clsInstrector _Instructo;
        private string _ImagePath = "";

        public enum enMode { AddNew = 1, Update = 2 }
        public enMode InstructorMode = enMode.AddNew;

        public frmAdd_EditInstractors(int ID)
        {
            _InstructoID = ID;
            InstructorMode = (ID == -1) ? enMode.AddNew : enMode.Update;
            _Instructo = new clsInstrector();
            InitializeComponent();
        }

        public frmAdd_EditInstractors()
        {
            InitializeComponent();
            InstructorMode = enMode.AddNew;
        }

        private void frmAdd_EditInstractors_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            txtInstructorID.Enabled = false;

            if (InstructorMode == enMode.AddNew)
            {
                _Instructo = new clsInstrector();
                lblTitle.Text = "اضافة مدرب";
                this.Text = "اضافة مدرب";
                txtInstructorID.Text = "???";
                txtPersoneID.Text = "???";
                PersoneImagge.Image = Resources.instructor;
                return;
            }
            else if (InstructorMode == enMode.Update)
            {
                _Instructo = clsInstrector.FindInstructor(_InstructoID);
                lblTitle.Text = "تعديل المدرب";
                this.Text = "تعديل المدرب";
                _LoadDataInUpdateForm();
            }
        }

        private void _LoadDataInUpdateForm()
        {
            txtName.Text = _Instructo.Name;
            txtPersoneID.Text = _Instructo.PersoneID.ToString();
            txtAddress.Text = _Instructo.Address;
            txtPhone.Text = _Instructo.Phone;
            dtpDateOfBirth.Value = _Instructo.DateOFBirth;
            PersoneImagge.ImageLocation = _Instructo.ImagePath;
            txtInstructorID.Text = _Instructo.InstructorID.ToString();
            txtQlufaction.Text = _Instructo.Qualafation;
        }

        private void PopulateMemberFromForm()
        {
            _Instructo.Name = txtName.Text.Trim();
            _Instructo.Address = txtAddress.Text.Trim();
            _Instructo.Phone = txtPhone.Text.Trim();
            _Instructo.DateOFBirth = dtpDateOfBirth.Value;
            _Instructo.Qualafation = txtQlufaction.Text;
            _Instructo.ImagePath = _ImagePath;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            PopulateMemberFromForm();

            if (InstructorMode == enMode.AddNew || InstructorMode == enMode.Update)
            {
                if (_Instructo.Save())
                {
                    MessageBox.Show($"Instructor {(InstructorMode == enMode.AddNew ? "Added" : "Updated")} Successfully",
                        InstructorMode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtInstructorID.Text = _Instructo.InstructorID.ToString();
                    this.Invalidate();
                    lblTitle.Text = "تحديث";
                }
                else
                {
                    MessageBox.Show($"Instructor {(InstructorMode == enMode.AddNew ? "Add" : "Update")} Failed",
                        InstructorMode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidateNumberInput(object sender, EventArgs e)
        {
            Guna2TextBox guna2TextBox = GetGuna2TextBox(sender);
            errorProvider1.SetError(guna2TextBox, "");

            if (!int.TryParse(guna2TextBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out _) || guna2TextBox.Text.Length < 5)
            {
                errorProvider1.SetError(guna2TextBox, "الرجاء إدخال قيمة رقمية صالحة مكونة من أكثر من 5 أرقام");
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
                        _Instructo.ImagePath = openFileDialog.FileName;
                        _ImagePath = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
