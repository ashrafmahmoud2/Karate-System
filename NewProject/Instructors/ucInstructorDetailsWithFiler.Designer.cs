namespace NewProject.Instructors
{
    partial class ucInstructorDetailsWithFiler
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
            this.ucInstructorDetails1 = new NewProject.UserControls.ucInstructorDetails();
            this.ucFilter1 = new NewProject.UserControls.ucFilter();
            this.ucPersoneDetails1 = new NewProject.UserControls.ucPersoneDetails();
            this.SuspendLayout();
            // 
            // ucInstructorDetails1
            // 
            this.ucInstructorDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ucInstructorDetails1.Location = new System.Drawing.Point(-1, 306);
            this.ucInstructorDetails1.Name = "ucInstructorDetails1";
            this.ucInstructorDetails1.Size = new System.Drawing.Size(790, 91);
            this.ucInstructorDetails1.TabIndex = 6;
            // 
            // ucFilter1
            // 
            this.ucFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ucFilter1.Location = new System.Drawing.Point(-3, 12);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(792, 72);
            this.ucFilter1.TabIndex = 5;
            // 
            // ucPersoneDetails1
            // 
            this.ucPersoneDetails1.Location = new System.Drawing.Point(3, 106);
            this.ucPersoneDetails1.Name = "ucPersoneDetails1";
            this.ucPersoneDetails1.Size = new System.Drawing.Size(781, 194);
            this.ucPersoneDetails1.TabIndex = 3;
            this.ucPersoneDetails1.Load += new System.EventHandler(this.ucPersoneDetails1_Load);
            // 
            // ucInstructorDetailsWithFiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.ucInstructorDetails1);
            this.Controls.Add(this.ucFilter1);
            this.Controls.Add(this.ucPersoneDetails1);
            this.Name = "ucInstructorDetailsWithFiler";
            this.Size = new System.Drawing.Size(792, 422);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucFilter ucFilter1;
        private UserControls.ucPersoneDetails ucPersoneDetails1;
        private UserControls.ucInstructorDetails ucInstructorDetails1;
    }
}
