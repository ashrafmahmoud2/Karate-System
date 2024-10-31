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

namespace NewProject.Instructors
{
    public partial class frmShowInstructorDetails : Form
    {
        private int _ID = -1;
        private clsInstrector instrector;
        public frmShowInstructorDetails(int ID)
        {
            InitializeComponent();
            _ID = ID;
             instrector = clsInstrector.FindInstructor(ID);
        }

        private void frmShowInstructorDetails_Load(object sender, EventArgs e)
        {
            ucInstructorDetails1.FillInstructorDetails(_ID);
            ucPersoneDetails1._FillPersoneDetails(instrector.PersoneID);

        }
    }
}
