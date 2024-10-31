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
    public partial class ucMemberDetailsWithFilter : UserControl
    {

        public ucMemberDetailsWithFilter()
        {
            InitializeComponent();
            ucFilter1.GetTheMode(ucFilter.enMode.Member);
            ucFilter1.SearchDone += UcFilter1_SearchDone;
            FillUserControl();
        }

        public int MemberiIDDone;

        public void FillMemberDetails(int memberID)
        {
            clsMember member = clsMember.FindMember(memberID);
            ucMemberDatails1._FillMemberDetails(memberID);
            ucPersoneDetails1._FillPersoneDetails(member.PersoneID);
            ucFilter1.UpdateFilltertext(member.Name);
        }

        private void UcFilter1_SearchDone(object sender, EventArgs e)
        {
            FillUserControl();
        }

        private void FillUserControl()
        {
            if (ucFilter1.MemberIDFromFilter != -1)
            {
                int memberID = ucFilter1.MemberIDFromFilter;
                clsMember member = clsMember.FindMember(memberID);
                MemberiIDDone = memberID;

                if (member != null)
                {
                    ucMemberDatails1._FillMemberDetails(memberID);
                    ucPersoneDetails1._FillPersoneDetails(member.PersoneID);
                }
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
