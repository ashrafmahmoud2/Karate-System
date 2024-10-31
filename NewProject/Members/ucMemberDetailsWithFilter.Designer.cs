namespace NewProject.Members
{
    partial class ucMemberDetailsWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucFilter1 = new NewProject.UserControls.ucFilter();
            this.ucMemberDatails1 = new NewProject.UserControls.ucMemberDatails();
            this.ucPersoneDetails1 = new NewProject.UserControls.ucPersoneDetails();
            this.SuspendLayout();
            // 
            // ucFilter1
            // 
            this.ucFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ucFilter1.Location = new System.Drawing.Point(0, 0);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(792, 69);
            this.ucFilter1.TabIndex = 2;
            // 
            // ucMemberDatails1
            // 
            this.ucMemberDatails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ucMemberDatails1.Location = new System.Drawing.Point(0, 266);
            this.ucMemberDatails1.Name = "ucMemberDatails1";
            this.ucMemberDatails1.Size = new System.Drawing.Size(791, 152);
            this.ucMemberDatails1.TabIndex = 1;
            // 
            // ucPersoneDetails1
            // 
            this.ucPersoneDetails1.Location = new System.Drawing.Point(-1, 75);
            this.ucPersoneDetails1.Name = "ucPersoneDetails1";
            this.ucPersoneDetails1.Size = new System.Drawing.Size(790, 194);
            this.ucPersoneDetails1.TabIndex = 0;
            // 
            // ucMemberDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.ucFilter1);
            this.Controls.Add(this.ucMemberDatails1);
            this.Controls.Add(this.ucPersoneDetails1);
            this.Name = "ucMemberDetailsWithFilter";
            this.Size = new System.Drawing.Size(792, 422);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucPersoneDetails ucPersoneDetails1;
        private UserControls.ucMemberDatails ucMemberDatails1;
        private UserControls.ucFilter ucFilter1;
    }
}
