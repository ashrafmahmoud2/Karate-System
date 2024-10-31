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

namespace NewProject.Members
{
    public partial class frmMembers : Form
    {
        // enter to search  , ctra + A to Add , ctra+ d to Delete , CTRA+U To Update;
        // make the Header of Data Grid View OPern
        // make btn To Refrech
        // Add Image To Every Screen;
        //is Active and Asct to Test But In The Last
        public frmMembers()
        {
            InitializeComponent();
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            ucMainView newContro = new ucMainView();
            ucMainView1.PerformDataViewerAction(ucMainView.EnMode.Member);

        }

        private void ucMainView1_Load(object sender, EventArgs e)
        {

        }
    }
}
