using krate_business_Layer;
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

namespace NewProject.TestBelt
{
    public partial class frmShowTestsHistory : Form
    {
        private int _ID = -1;
        private clsMember member;
        public frmShowTestsHistory(int ID)
        {
            InitializeComponent();
            _ID = ID;
            member = clsMember.FindMember(_ID);

            this.Load += frmShowTestsHistory_Load;
        }

        private void frmShowTestsHistory_Load(object sender, EventArgs e)
        {
            member = clsMember.FindMember(_ID);

            guna2DataGridView1.DataSource = clsBeltTest.GetAllBeltTestsForMember(_ID);
            ucMemberDatails1._FillMemberDetails(_ID);
            ucPersoneDetails2._FillPersoneDetails(member.PersoneID);
        }
    }
}
