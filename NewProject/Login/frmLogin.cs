using Guna.UI2.WinForms;
using krate_business_layer;
using NewProject.GlobalClass;
using NewProject.Home;
using NewProject.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NewProject
{
    public partial class frmLogin : Form
    {

       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ValidatingOfTextBoxs(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(((Guna2TextBox)sender), "This field is required!");
            }
            else
            {
                errorProvider1.SetError(((Guna2TextBox)sender), null);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string userName = "", password = "";
            if (clsGlobal.GetStoredCredential(ref userName, ref password))
            {
                txtUserName.Text = userName;
                txtPassWord.Text = password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }
        }


        private void PerformLogin()
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icon(s) to see the error.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userName = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            if (!clsUser.IsUserExists(userName, password))
            {
                txtUserName.Focus();
                DisplayErrorMessage();
                return;
            }

            clsUser user = clsUser.FindUser(userName, password);

            if (user == null)
            {
                txtUserName.Focus();
                DisplayErrorMessage();
                return;
            }

            if (chkRememberMe.Checked)
            {
                clsGlobal.RememberUsernameAndPassword(userName, password);
            }
            else
            {
                clsGlobal.RememberUsernameAndPassword("", "");
            }

            clsGlobal.CurrentUser = user;
            this.Hide();
            frmHome home = new frmHome(this);
            home.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }


        private void DisplayErrorMessage()
        {
            labInvalid.Visible = true;
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            frmIMoreDetails FRM=new frmIMoreDetails();
            FRM.ShowDialog();
        }

        

      

    }
}