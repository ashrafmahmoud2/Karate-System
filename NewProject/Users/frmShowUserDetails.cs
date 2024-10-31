using krate_business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.Users
{
    public partial class frmShowUserDetails : Form
    {

        // Add User Permission if need;
        int _UserID = -1;
        clsUser _User;

        public frmShowUserDetails(int ID)
        {
            _UserID = ID;
            _User = clsUser.FindUser(_UserID);  
            InitializeComponent();
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ucUserDetails1.FillUserDetails(_UserID);
            ucPersoneDetails1._FillPersoneDetails(_User.PersoneID);

        }

        private void ucPersoneDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
