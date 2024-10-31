namespace NewProject.Instructors
{
    partial class frmShowInstructorDetails
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
            this.ucInstructorDetails1 = new NewProject.UserControls.ucInstructorDetails();
            this.ucPersoneDetails1 = new NewProject.UserControls.ucPersoneDetails();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucInstructorDetails1
            // 
            this.ucInstructorDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ucInstructorDetails1.Location = new System.Drawing.Point(12, 303);
            this.ucInstructorDetails1.Name = "ucInstructorDetails1";
            this.ucInstructorDetails1.Size = new System.Drawing.Size(790, 130);
            this.ucInstructorDetails1.TabIndex = 1;
            // 
            // ucPersoneDetails1
            // 
            this.ucPersoneDetails1.Location = new System.Drawing.Point(12, 70);
            this.ucPersoneDetails1.Name = "ucPersoneDetails1";
            this.ucPersoneDetails1.Size = new System.Drawing.Size(796, 227);
            this.ucPersoneDetails1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.lblTitle.Location = new System.Drawing.Point(85, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 48);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Tilte";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmShowInstructorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(820, 440);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ucInstructorDetails1);
            this.Controls.Add(this.ucPersoneDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowInstructorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowInstructorDetails";
            this.Load += new System.EventHandler(this.frmShowInstructorDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucPersoneDetails ucPersoneDetails1;
        private UserControls.ucInstructorDetails ucInstructorDetails1;
        private System.Windows.Forms.Label lblTitle;
    }
}