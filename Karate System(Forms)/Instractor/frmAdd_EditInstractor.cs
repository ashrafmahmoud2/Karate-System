using krate_business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_System_Forms_.Instractor
{
    public partial class frmAdd_EditInstractor : Form
    {
        private int _InstructorID=-1;
        private clsInstrector _Instructor;
        private Color borderColor = Color.Red;
        public enum enMode { AddNew , Update  };
        private enMode Mode = enMode.AddNew;

        public frmAdd_EditInstractor(int ID)
        {
            InitializeComponent();
            _InstructorID = ID;
            Mode=(ID==-1)? enMode.AddNew:enMode.Update;
            this.Text = "Add/Edit Instructor";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Paint += FrmAdd_EditInstructor_Paint;
          //  _Instructor=new clsInstrector();
          
        }
        private void frmAdd_EditInstractor_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void FrmAdd_EditInstructor_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(borderColor, 2))
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
                    InstructorImage.Image = new Bitmap(openFileDialog.FileName);

                    // Optionally, display the file path
                    labelFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void _LoadData()
        {
            txtInstractorID.Enabled = false;

            if (Mode == enMode.AddNew)
            {
                _Instructor = new clsInstrector();
                labTitel.Text = "اضافة";
                txtInstractorID.Text = "??";
              
                return;
            }
            else if (Mode == enMode.Update)
            {
                _Instructor = clsInstrector.FindInstructor(_InstructorID);
                labTitel.Text = "تعديل";
                _LoadDataInUpdateForm();
               

            }
        }

        private void _LoadDataInUpdateForm()
        {
            txtName.Text = _Instructor.Name;
            txtQualafation.Text = _Instructor.Qualafation;
            dtpDateOfBirth.Value = _Instructor.DateOFBirth;
            txtInstractorID.Text = _Instructor.InstructorID.ToString();
            txtAddress.Text = _Instructor.Address;
            txtPhone.Text = _Instructor.Phone;


            if (!string.IsNullOrEmpty(_Instructor.ImagePath) && File.Exists(_Instructor.ImagePath))
            {
                InstructorImage.Image = Image.FromFile(_Instructor.ImagePath);
            }
        }

        private void PopulateInstructorFromForm()
        {
            _Instructor.PersoneID = _Instructor.PersoneID;
            _Instructor.Name = txtName.Text;
            _Instructor.Qualafation = txtQualafation.Text;  // Assuming there's a property named Qualification in clsInstructor
            _Instructor.Address = txtAddress.Text;
            _Instructor.Phone = txtPhone.Text;
            _Instructor.DateOFBirth = dtpDateOfBirth.Value;
            _Instructor.ImagePath = labelFilePath.Text;
            _Instructor.Password = "1234";
        }



        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            PopulateInstructorFromForm();

            // see the vido of delget
           
            if (Mode == enMode.AddNew || Mode == enMode.Update)
            {
                if (_Instructor.Save())
                {
                    
                    MessageBox.Show("Instructor " + (Mode == enMode.AddNew ? "Added" : "Updated") + " Successfully",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtInstractorID.Text = _Instructor.InstructorID.ToString();
                    borderColor = Color.Green;
                    this.Invalidate();
                }
                else
                {
                    MessageBox.Show("Instructor " + (Mode == enMode.AddNew ? "Add" : "Update") + " Failed",
                        Mode == enMode.AddNew ? "Add" : "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    borderColor = Color.DarkRed;
                }
            }
        }

       
    }
}
