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
using System.Web.Configuration;
using System.Windows.Forms;
namespace Karate_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.KeyDown += Form_KeyDown;
            txtUserName.KeyPress += TextBox_KeyPress;
            txtPassWord.KeyPress += TextBox_KeyPress;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Suppress the key press event
                btnLogin_Click(sender, e);
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void PerformLogin()
        {
            string userName = txtUserName.Text;
            string password = txtPassWord.Text;

            if (clsUser.IsUserExists(userName, password) || clsMember.IsMemberExists(userName, password) || clsInstrector.IsInstructorExists(userName, password))
            {
                Home frm = new Home();
              frm.ShowDialog();
            }
            else
            {
                labInvalid.Visible = true;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}