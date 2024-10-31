using krate_business_Layer;
using NewProject.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.Suscription
{
    public partial class frmSupscription : Form
    {
        public frmSupscription()
        {
            InitializeComponent();
        }

        private void frmSupscription_Load(object sender, EventArgs e)
        {
            ucMainView newContro = new ucMainView();
            ucMainView1.PerformDataViewerAction(ucMainView.EnMode.Subscriptions);
            UpdateSubscriptionsButton();

        }
        private void UpdateSubscriptionsButton()
        {
            clsSubscriptionPeriod.UpdateSubscriptionsStatusAndMembers();
        }



        private void ucMainView1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            clsSubscriptionPeriod.UpdateSubscriptionsStatusAndMembers();
        }
    }
}
