using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.Login
{
    public partial class frmIMoreDetails : Form
    {
        public frmIMoreDetails()
        {
            InitializeComponent();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/ashrafmahmoud2";

            try
            {
                // Open the URL in the default web browser
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error or show a message to the user)
                Console.WriteLine($"Error opening the URL: {ex.Message}");
            }
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
this.Close();
        }
    }
}
