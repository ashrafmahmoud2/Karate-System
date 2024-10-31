using krate_business_Layer;
using NewProject.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace NewProject.UserControls
{
    public partial class ucFilter : UserControl
    {
        public enum enMode { Member = 0, Instructor = 1 }
        enMode mode = enMode.Member;

        public ucFilter()
        {
            InitializeComponent();
        }

       

        public void GetTheMode(enMode mode)
        {
            this.mode = mode;

        }

        public int MemberIDFromFilter { get; private set; } = -1;
        public int InstructorIDFromFilter { get; private set; } = -1;

        public void UpdateFilltertext(string Text)
        {
            txtMemberName.Text = Text;  
        }

        private void txtMemberName_TextChanged(object sender, EventArgs e)
        {
            if (mode == enMode.Member)
            {
                DataTable _dtMemberColumn = clsMember.GetAllMember1();
                _dtMemberColumn.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", "Name", txtMemberName.Text.Trim());

                if (_dtMemberColumn.DefaultView.Count > 0)
                {
                    int memberId = Convert.ToInt32(_dtMemberColumn.DefaultView[0]["MemberID"]);
                    clsMember me = clsMember.FindMember(memberId);

                    if (me.Name == txtMemberName.Text)
                    {
                        MemberIDFromFilter = memberId;
                        SearchDone?.Invoke(this, EventArgs.Empty);
                        MessageBox.Show(me.Name);
                    }
                }
            }
             else if (mode == enMode.Instructor)
            {
                DataTable _dtInstructorColumn = clsInstrector.GetAllInstructors();
                _dtInstructorColumn.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", "Name", txtMemberName.Text.Trim());

                if (_dtInstructorColumn.DefaultView.Count > 0)
                {
                    int InstructorID = Convert.ToInt32(_dtInstructorColumn.DefaultView[0]["InstructorID"]);
                    clsInstrector me = clsInstrector.FindInstructor(InstructorID);

                    if (me.Name == txtMemberName.Text)
                    {
                        InstructorIDFromFilter = InstructorID;
                        SearchDone?.Invoke(this, EventArgs.Empty);
                        MessageBox.Show(me.Name);
                    }
                }
            }
        }

        public event EventHandler SearchDone;
    }
}