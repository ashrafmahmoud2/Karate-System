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

namespace NewProject.TestBelt
{
    public partial class frmTestBelt : Form
    {
        public frmTestBelt()
        {
            InitializeComponent();
        }

        private void frmTestBelt_Load(object sender, EventArgs e)
        {
            ucMainView newContro = new ucMainView();
            ucMainView1.PerformDataViewerAction(ucMainView.EnMode.BeltTest);
        }

        private void ucMainView1_Load(object sender, EventArgs e)
        {

        }
    }
}
