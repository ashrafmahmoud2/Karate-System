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

namespace NewProject.UserControls
{
    public partial class ucInstructorDetails : UserControl
    {
        public ucInstructorDetails()
        {
            InitializeComponent();
        }
        public void FillInstructorDetails(int ID)
        {
            
            clsInstrector instrector = clsInstrector.FindInstructor(ID);
            labInstructorID.Text=instrector.InstructorID.ToString();
            labQlufactions.Text = instrector.Qualafation;

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
