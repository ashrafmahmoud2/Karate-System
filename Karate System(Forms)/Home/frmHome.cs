using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Karate_System_Forms_.DashBoard;
using Karate_System_Forms_.Instractor;
using Karate_System_Forms_.Member;
using Karate_System_Forms_.Payment;
using Karate_System_Forms_.subscription;
using Karate_System_Forms_.Users;
using krate_business_layer;

namespace Karate_System_Forms_.Home
{
    public partial class frmHome : Form
    {
        public frmHome(int ID)
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMaximize_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            frmdashboard frmdashboard = new frmdashboard();
            frmdashboard.Show();

        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            frmMember frmMember = new frmMember();
            frmMember.Show();
        }

        private void btnInstractor_Click(object sender, EventArgs e)
        {
            frmInstractor frmInstractor = new frmInstractor();
            frmInstractor.Show();
        }

        private void btnSubscribtion_Click(object sender, EventArgs e)
        {
            frmsubscription frmsubscription = new frmsubscription();
            frmsubscription.Show();
        }

        private void btnPaymetn_Click(object sender, EventArgs e)
        {
            frmPayment  frmPayment = new frmPayment();  
                frmPayment.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUsers frmUsers = new frmUsers(); 
            frmUsers.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
