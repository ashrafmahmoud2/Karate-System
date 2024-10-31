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

namespace NewProject.UserControls
{
    public partial class ucUserDetails : UserControl
    {
       

        public ucUserDetails()
        {
        
            InitializeComponent();

          ;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {
            
            
        }
        public void FillUserDetails(int UserID)
        {
            clsUser user=clsUser.FindUser(UserID);
            labUserName.Text = user.Username;
            labUserID.Text=user.UserID.ToString();
            labPassword.Text = user.Password;   
          

        }
    }
}
