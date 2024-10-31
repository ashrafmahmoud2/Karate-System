using Guna.UI2.WinForms;
using krate_business_layer;
using NewProject.DashBoerd;
using NewProject.GlobalClass;
using NewProject.Instructors;
using NewProject.Members;
using NewProject.Payment;
using NewProject.Suscription;
using NewProject.TestBelt;
using NewProject.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.Home
{
    public partial class frmHome : Form
    {
        // the glouble class UnderStand   ,  Add Update PassWord to The User
        //Chage the way of BitWays        ,  Add User Details in home like hanan project in DashBoerd




        private Form currentChildForm;
        private Form _frmLoginForm;
        public Form frmAccessDeniedForm = new frmAccessDeniedForm();

        public frmHome(Form LoginForm)
        {
            InitializeComponent();

            this._frmLoginForm = LoginForm;
        }

        //private void MoveImageBox(object Sender)
        //{
        //    Guna2Button b = (Guna2Button)Sender;
        //    pictureBox1.Location = new Point(b.Location.X + 118, b.Location.Y - 30);
        //    pictureBox1.SendToBack();
        //}
        //private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        //{
        //    MoveImageBox(sender);
        //}

        public void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            guna2CustomGradientPanel2.Controls.Add(childForm);
            guna2CustomGradientPanel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                //lblTitleChildForm.Text = childForm.Tag.ToString();
            }
            else
            {
                // lblTitleChildForm.Text = childForm.Text;
            }

          //  RefreshUserInfo(this, clsGlobal.CurrentUser.UserID);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if(!clsGlobal.ChecAccessDenied(clsUser.enPermissions.ManageMembers))
            {
                frmAccessDeniedForm.ShowDialog();
                return;
            }
            OpenChildForm(new frmMembers());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.ChecAccessDenied(clsUser.enPermissions.ManagePayments))
            {
                frmAccessDeniedForm.ShowDialog();
                return;
            }
            OpenChildForm(new frmPayment());

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.ChecAccessDenied(clsUser.enPermissions.ManageInstructors))
            {
                frmAccessDeniedForm.ShowDialog();
                return;
            }
            OpenChildForm(new frmInstructors());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.ChecAccessDenied(clsUser.enPermissions.ManageBeltTests))
            {
                frmAccessDeniedForm.ShowDialog();
                return;
            }
            OpenChildForm(new frmTestBelt());

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.ChecAccessDenied(clsUser.enPermissions.ManageUsers))
            {
                frmAccessDeniedForm.ShowDialog();
                return;
            }
            OpenChildForm(new frmUsers());

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

            OpenChildForm(new frmDashBoard());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.ChecAccessDenied(clsUser.enPermissions.ManageSubscriptionPeriods))
            {
                frmAccessDeniedForm.ShowDialog();
                return;
            }
            OpenChildForm(new frmSupscription());
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashBoard());

        }


    }
}
