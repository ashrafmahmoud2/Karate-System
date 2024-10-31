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
    public partial class frmInstructors : Form
    {
        public frmInstructors()
        {
            InitializeComponent();
        }

        private void frmInstructors_Load(object sender, EventArgs e)
        {
            ucMainView newContro = new ucMainView();
            ucMainView1.PerformDataViewerAction(ucMainView.EnMode.Instructor);
        }
    }
}
