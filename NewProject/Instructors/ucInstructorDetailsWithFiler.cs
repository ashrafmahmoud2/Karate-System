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
    public partial class ucInstructorDetailsWithFiler : UserControl
    {
        public ucInstructorDetailsWithFiler()
        {
            InitializeComponent();
            ucFilter1.GetTheMode(ucFilter.enMode.Instructor);
            ucFilter1.SearchDone += UcFilter1_SearchDone;
            FillUserControl();
        }
        public int InstructorIsDone;

        
        public void FillInstructorDetails(int InstructorID)
        {
            clsInstrector instrector = clsInstrector.FindInstructor(InstructorID);
            ucInstructorDetails1.FillInstructorDetails(InstructorID);
            ucPersoneDetails1._FillPersoneDetails(instrector.PersoneID);
            ucFilter1.UpdateFilltertext(instrector.Name);
        }

        private void UcFilter1_SearchDone(object sender, EventArgs e)
        {
            FillUserControl();
        }

        private void FillUserControl()
        {
            if (ucFilter1.InstructorIDFromFilter != -1)
            {
                int InstructorID = ucFilter1.InstructorIDFromFilter;
                clsInstrector Instructor = clsInstrector.FindInstructor(InstructorID);
                InstructorIsDone = InstructorID;

                if (Instructor != null)
                {
                    ucInstructorDetails1.FillInstructorDetails(InstructorID);
                    ucPersoneDetails1._FillPersoneDetails(Instructor.PersoneID);
                }
            }
        }

        private void ucPersoneDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
