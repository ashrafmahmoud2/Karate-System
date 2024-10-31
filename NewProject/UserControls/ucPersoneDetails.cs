using krate_business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.UserControls
{
    public partial class ucPersoneDetails : UserControl
    {
       
        public ucPersoneDetails()
        {
            InitializeComponent();
            
        }


        public void _FillPersoneDetails(int PersoneID)
        {
            
            clsPersone persone = clsPersone.FindPersoen(PersoneID);
            if (persone != null)
            {
                labName.Text = persone.Name;
                labAddress.Text = persone.Address;
                labPhone.Text = persone.Phone;
                labPersoenID.Text = (persone.PersoneID.ToString());
                guna2DateTimePicker1.Value = persone.DateOFBirth;
                PersoneImagge.ImageLocation = persone.ImagePath;


            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPersoneID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYearOld_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PersoneImagge_Click(object sender, EventArgs e)
        {

        }

        private void labAddress_Click(object sender, EventArgs e)
        {

        }
    }
}
