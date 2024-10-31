namespace NewProject.Members
{
    partial class frmFindMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ucFilter1 = new NewProject.UserControls.ucFilter();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.ucPersoneDetails1 = new NewProject.UserControls.ucPersoneDetails();
            this.ucMemberDatails1 = new NewProject.UserControls.ucMemberDatails();
            this.SuspendLayout();
            // 
            // ucFilter1
            // 
            this.ucFilter1.Location = new System.Drawing.Point(84, 12);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(637, 109);
            this.ucFilter1.TabIndex = 2;
            // 
            // ucPersoneDetails1
            // 
            this.ucPersoneDetails1.Location = new System.Drawing.Point(21, 145);
            this.ucPersoneDetails1.Name = "ucPersoneDetails1";
            this.ucPersoneDetails1.Size = new System.Drawing.Size(813, 212);
            this.ucPersoneDetails1.TabIndex = 3;
            // 
            // ucMemberDatails1
            // 
            this.ucMemberDatails1.Location = new System.Drawing.Point(31, 377);
            this.ucMemberDatails1.Name = "ucMemberDatails1";
            this.ucMemberDatails1.Size = new System.Drawing.Size(794, 171);
            this.ucMemberDatails1.TabIndex = 4;
            // 
            // frmFindMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(862, 560);
            this.Controls.Add(this.ucMemberDatails1);
            this.Controls.Add(this.ucPersoneDetails1);
            this.Controls.Add(this.ucFilter1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmFindMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFindMember";
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.ucFilter ucFilter1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private UserControls.ucPersoneDetails ucPersoneDetails1;
        private UserControls.ucMemberDatails ucMemberDatails1;
    }
}