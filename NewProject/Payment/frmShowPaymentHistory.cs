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

namespace NewProject.Payment
{
    public partial class frmShowPaymentHistory : Form
    {
        private int _ID = -1;
        private clsMember member;

        public frmShowPaymentHistory(int ID)
        {
            InitializeComponent();
            _ID = ID;
            member = clsMember.FindMember(_ID);

            // Subscribe to the Load event after initializing the component
            this.Load += frmShowPaymentHistory_Load;
        }

        private void frmShowPaymentHistory_Load(object sender, EventArgs e)
        {
 
            member = clsMember.FindMember(_ID);

            guna2DataGridView1.DataSource = clsPayment.GetAllPaymentsForMember(_ID);
            ucMemberDatails1._FillMemberDetails(_ID);
           ucPersoneDetails2._FillPersoneDetails(member.PersoneID);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }
    }
}
