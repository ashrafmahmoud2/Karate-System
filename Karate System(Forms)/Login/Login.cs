using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Karate_System_Forms_.Home;
using Karate_System_Forms_.Instractor;
using Karate_System_Forms_.Member;
using krate_business_layer;
using krate_business_Layer;

namespace Karate_System_Forms_
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            this.KeyDown += Form_KeyDown;
            txtUserName.KeyPress += TextBox_KeyPress;
            txtPassWord.KeyPress += TextBox_KeyPress;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PerformLogin();
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
            int userID = -1;

            if (clsUser.IsUserExistswhiteGetUserID(userName, password, ref userID))
            {

               frmHome frm = new frmHome(userID);
                OpenAndClearTextBoxes(frm);
            }
            else if (clsMember.IsMemberExistswhiteGetMemberID(userName, password, ref userID))
            {

                frmMeberFace frm = new frmMeberFace(userID);
                OpenAndClearTextBoxes(frm);
            }
            else if (clsInstrector.IsInstractorExistswhiteGetInstractroID(userName, password, ref userID))
            {

                frmInstractorFace frm = new frmInstractorFace(userID);
                OpenAndClearTextBoxes(frm);
            }
            else
            {
                DisplayErrorMessage();
            }
        }

        private void OpenAndClearTextBoxes(Form form)
        {
            // frmLogin.Hide();
            form.ShowDialog();
            ClearTextBoxes();

        }

        private void ClearTextBoxes()
        {
            txtUserName.Clear();
            txtPassWord.Clear();
        }

        private void DisplayErrorMessage()
        {
            labVasible.Visible = true;
        }



       
        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
