namespace NewProject.Members
{
    partial class frmShowMemberDetails
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ucPersoneDetails2 = new NewProject.UserControls.ucPersoneDetails();
            this.ucMemberDatails1 = new NewProject.UserControls.ucMemberDatails();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.lblTitle.Location = new System.Drawing.Point(75, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 48);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Member Details";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPersoneDetails2
            // 
            this.ucPersoneDetails2.Location = new System.Drawing.Point(14, 80);
            this.ucPersoneDetails2.Name = "ucPersoneDetails2";
            this.ucPersoneDetails2.Size = new System.Drawing.Size(791, 217);
            this.ucPersoneDetails2.TabIndex = 1;
            // 
            // ucMemberDatails1
            // 
            this.ucMemberDatails1.Location = new System.Drawing.Point(14, 322);
            this.ucMemberDatails1.Name = "ucMemberDatails1";
            this.ucMemberDatails1.Size = new System.Drawing.Size(793, 175);
            this.ucMemberDatails1.TabIndex = 0;
            // 
            // frmShowMemberDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(819, 530);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ucPersoneDetails2);
            this.Controls.Add(this.ucMemberDatails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowMemberDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowMemberDetails";
            this.Load += new System.EventHandler(this.frmShowMemberDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucMemberDatails ucMemberDatails1;
        private UserControls.ucPersoneDetails ucPersoneDetails1;
        private UserControls.ucPersoneDetails ucPersoneDetails2;
        private System.Windows.Forms.Label lblTitle;
    }
}