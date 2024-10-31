using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Karate_System_Forms_.Instractor
{
    public partial class frmInstractor : Form
    {
        public frmInstractor()
        {
            InitializeComponent();
        }

        private void frmInstractor_Load(object sender, EventArgs e)
        {
            UserControl1 control1 = new UserControl1();
            userControl11.PerformDataViewerAction(UserControl1.EnMode.Instructor);
        }
    }
}
