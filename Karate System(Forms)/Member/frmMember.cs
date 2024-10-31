using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_System_Forms_.Member
{
    public partial class frmMember : Form
    {
        public frmMember()
        {
            InitializeComponent();
            UserControl1 control1 = new UserControl1();
            userControl11.PerformDataViewerAction(UserControl1.EnMode.Member);
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
         


        }
    }
}
