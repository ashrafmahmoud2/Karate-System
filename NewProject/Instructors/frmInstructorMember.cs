using krate_business_Layer;
using NewProject.UserControls;
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

namespace NewProject.Instructors
{
    public partial class frmInstructorMember : Form
    {
        private int _ID = -1;
        private clsInstrector Instructor;
        public frmInstructorMember(int InstructorID)
        {
            InitializeComponent();
            _ID = InstructorID;
            Instructor = clsInstrector.FindInstructor(_ID);

            // Subscribe to the Load event after initializing the component
            this.Load += frmInstructorMember_Load;
        }

        private void frmInstructorMember_Load(object sender, EventArgs e)
        {
            Instructor = clsInstrector.FindInstructor(_ID);

            DataGridView1.DataSource = clsInstrector.GetTranedMembersByInstructro(_ID);
            ucInstructorDetails1.FillInstructorDetails(_ID);
            ucPersoneDetails2._FillPersoneDetails(Instructor.PersoneID);
        }
    }
}
