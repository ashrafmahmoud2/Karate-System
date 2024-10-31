using Guna.UI2.WinForms;
using krate_business_Layer;
using NewProject.Members;
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

namespace NewProject.UserControls
{
    public partial class ucMemberDatails : UserControl
    {
        public ucMemberDatails()
        {
            InitializeComponent();
        }
        private int _ID = -1;

        public void _FillMemberDetails(int MemberID)
        {
            _ID=MemberID;
            clsMember member = clsMember.FindMember(MemberID);
            if (member != null)
            {
                LabMemberID.Text=member.MemberID.ToString();
                LabContact2.Text = member.EmergenceContect;
                labRankName.Text =clsBeltRank.GetRankNameByRankID(member.LastRenkID);
                sbIsActive.Checked= member.IsActive;

            }
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmAdd_EditMember frm = new frmAdd_EditMember(_ID);
            frm.ShowDialog();
        }
    }
}
