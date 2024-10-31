using krate_business_layer;
using krate_business_Layer;
using NewProject.GlobalClass;
using NewProject.Home;
using NewProject.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Globalization;
using System.Windows.Forms;

namespace NewProject.DashBoerd
{
    public partial class frmDashBoard : Form
    {
        //fix logout ;
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            FillLabels();
        }
        private void FillLabels()
        {
            LabInstractor.Text = clsInstrector.GetTotalInstructors().ToString();
            labMembers.Text = clsMember.GetToterLMember().ToString();
            labSubscription.Text = clsSubscriptionPeriod.GetTotelSubscractionPerrod().ToString();
            LabPayment.Text = clsPayment.GetTotlPaymetn().ToString();
            labUsers.Text = clsUser.GetTotelUsers().ToString();
            clsUser user = clsUser.FindUser(10);
           //// LabUserName.Text = user.Username;
           // try
           // {
           // //    UserImage.Image = Image.FromFile(user.ImagePath);
           // }
           // catch (Exception ex)
           // {

               

           // }
            UserImage.Image = Properties.Resources.USE;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            guna2ContextMenuStrip1.Show(guna2CirclePictureBox1, new Point(0, guna2CirclePictureBox1.Height));
        }


    

        private void بيناتيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frm = new frmShowUserDetails(clsGlobal.CurrentUser.UserID);
            frm.Show();

        }

        private void LogOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Delete the current user and don't remember
            clsGlobal.DelteCurrentUserUserAndDontremember();

            // Close all open forms
            foreach (Form openForm in Application.OpenForms)
            {
                openForm.Close();
            }

            // Open the login form
            frmLogin frm = new frmLogin();
            frm.Show();
        }



    }
}

