using krate_business_Layer;
using NewProject.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NewProject.Members
{
    public partial class frmShowMemberDetails : Form
    {
        private int _MemberID = -1;
        private clsMember member;

        public frmShowMemberDetails(int ID)
        {
            InitializeComponent();
            _MemberID = ID;
            member = clsMember.FindMember(ID);

            // Make sure to subscribe to the Load event after initializing the component
            this.Load += frmShowMemberDetails_Load;
        }

        private void frmShowMemberDetails_Load(object sender, EventArgs e)
        {
            ucPersoneDetails2._FillPersoneDetails(member.PersoneID);
            ucMemberDatails1._FillMemberDetails(_MemberID); // Use _MemberID instead of ID
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmAdd_EditMember FRM=new frmAdd_EditMember(_MemberID); FRM.ShowDialog();
        }
    }
}