namespace NewProject.Suscription
{
    partial class frmShowSuscriptionDetails
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
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucMemberDatails1 = new NewProject.UserControls.ucMemberDatails();
            this.ucPersoneDetails1 = new NewProject.UserControls.ucPersoneDetails();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucInstructorDetails1 = new NewProject.UserControls.ucInstructorDetails();
            this.ucPersoneDetails2 = new NewProject.UserControls.ucPersoneDetails();
            this.ucSuscriptionDetails1 = new NewProject.UserControls.ucSuscriptionDetails();
            this.guna2TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.tabPage1);
            this.guna2TabControl1.Controls.Add(this.tabPage2);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(-1, 3);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(650, 437);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucMemberDatails1);
            this.tabPage1.Controls.Add(this.ucPersoneDetails1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(642, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ucMemberDatails1
            // 
            this.ucMemberDatails1.Location = new System.Drawing.Point(3, 210);
            this.ucMemberDatails1.Name = "ucMemberDatails1";
            this.ucMemberDatails1.Size = new System.Drawing.Size(638, 170);
            this.ucMemberDatails1.TabIndex = 10;
            // 
            // ucPersoneDetails1
            // 
            this.ucPersoneDetails1.Location = new System.Drawing.Point(0, 0);
            this.ucPersoneDetails1.Name = "ucPersoneDetails1";
            this.ucPersoneDetails1.Size = new System.Drawing.Size(638, 204);
            this.ucPersoneDetails1.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucInstructorDetails1);
            this.tabPage2.Controls.Add(this.ucPersoneDetails2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(642, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucInstructorDetails1
            // 
            this.ucInstructorDetails1.Location = new System.Drawing.Point(-4, 242);
            this.ucInstructorDetails1.Name = "ucInstructorDetails1";
            this.ucInstructorDetails1.Size = new System.Drawing.Size(639, 130);
            this.ucInstructorDetails1.TabIndex = 13;
            // 
            // ucPersoneDetails2
            // 
            this.ucPersoneDetails2.Location = new System.Drawing.Point(-4, 32);
            this.ucPersoneDetails2.Name = "ucPersoneDetails2";
            this.ucPersoneDetails2.Size = new System.Drawing.Size(638, 204);
            this.ucPersoneDetails2.TabIndex = 12;
            // 
            // ucSuscriptionDetails1
            // 
            this.ucSuscriptionDetails1.Location = new System.Drawing.Point(-1, 442);
            this.ucSuscriptionDetails1.Name = "ucSuscriptionDetails1";
            this.ucSuscriptionDetails1.Size = new System.Drawing.Size(645, 246);
            this.ucSuscriptionDetails1.TabIndex = 1;
            // 
            // frmShowSuscriptionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 694);
            this.Controls.Add(this.ucSuscriptionDetails1);
            this.Controls.Add(this.guna2TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowSuscriptionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowSuscriptionDetails";
            this.Load += new System.EventHandler(this.frmShowSuscriptionDetails_Load);
            this.guna2TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private UserControls.ucMemberDatails ucMemberDatails1;
        private UserControls.ucPersoneDetails ucPersoneDetails1;
        private System.Windows.Forms.TabPage tabPage2;
        private UserControls.ucSuscriptionDetails ucSuscriptionDetails1;
        private UserControls.ucInstructorDetails ucInstructorDetails1;
        private UserControls.ucPersoneDetails ucPersoneDetails2;
    }
}