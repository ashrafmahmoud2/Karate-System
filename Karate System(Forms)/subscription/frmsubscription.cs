using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_System_Forms_.subscription
{
    public partial class frmsubscription : Form
    {
        public frmsubscription()
        {
            InitializeComponent();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void frmsubscription_Load(object sender, EventArgs e)
        {
            UserControl1 control1 = new UserControl1();
            userControl11.PerformDataViewerAction(UserControl1.EnMode.Subscriptions);
        }
    }
}
