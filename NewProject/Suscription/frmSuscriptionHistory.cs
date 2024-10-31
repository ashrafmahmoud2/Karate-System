using krate_business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.Suscription
{
    public partial class frmSuscriptionHistory : Form
    {
        private int _ID = -1;
        private clsSubscriptionPeriod Period;
        public frmSuscriptionHistory(int ID)
        {
            InitializeComponent();
            _ID = ID;
            Period = clsSubscriptionPeriod.FindSubscriptionPeriod(_ID);

            // Subscribe to the Load event after initializing the component
            this.Load += frmSuscriptionHistory_Load;
        }

        private void frmSuscriptionHistory_Load(object sender, EventArgs e)
        {

            Period = clsSubscriptionPeriod.FindSubscriptionPeriod(_ID);
            clsMember member=clsMember.FindMember(_ID);

            guna2DataGridView1.DataSource = clsSubscriptionPeriod.GetAllSuscriptionForMebers(_ID);
            ucMemberDatails1._FillMemberDetails(_ID);
            ucPersoneDetails2._FillPersoneDetails(member.PersoneID);
        }

        
    }
}
