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
    public partial class frmShowSuscriptionDetails : Form
    {
        private int _ID;
        public frmShowSuscriptionDetails(int ID)
        {
            InitializeComponent();
            _ID = ID;
            tabPage1.Text = "المشترك";
            tabPage2.Text = "المدرب";
            
        }

        private void frmShowSuscriptionDetails_Load(object sender, EventArgs e)
        {
            clsSubscriptionPeriod period = clsSubscriptionPeriod.FindSubscriptionPeriod(_ID);
            clsMember member=clsMember.FindMember(period.MemberID);
            clsInstrector instrector = clsInstrector.FindInstructor(period.InstructorId);
            ucSuscriptionDetails1.FillPeriedDetails(_ID);
            ucPersoneDetails1._FillPersoneDetails(member.PersoneID);
            ucMemberDatails1._FillMemberDetails(period.MemberID);

            ucPersoneDetails2._FillPersoneDetails(instrector.PersoneID);
            ucInstructorDetails1.FillInstructorDetails(period.InstructorId);


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
