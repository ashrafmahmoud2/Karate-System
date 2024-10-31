using krate_business_layer;
using krate_business_Layer;
using Styling_Toggle_Button;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Karate_System_Forms_.DashBoard
{
    public partial class frmdashboard : Form
    {
        public frmdashboard()
        {
            InitializeComponent();
        }
        public int BorderRadius { get; set; } = 10;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);

            this.Region = new System.Drawing.Region(path);

            using (Pen pen = new Pen(this.BackColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
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
        }

        private void btnMaximize_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
