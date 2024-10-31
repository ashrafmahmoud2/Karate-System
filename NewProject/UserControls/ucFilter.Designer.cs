namespace NewProject.UserControls
{
    partial class ucFilter
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
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.ComboSerch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMemberName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddNew = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.btnAddNew);
            this.guna2GroupBox1.Controls.Add(this.ComboSerch);
            this.guna2GroupBox1.Controls.Add(this.txtMemberName);
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(1, 15, 1, 1);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(781, 66);
            this.guna2GroupBox1.TabIndex = 5;
            this.guna2GroupBox1.Text = "البحث ";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ComboSerch
            // 
            this.ComboSerch.BackColor = System.Drawing.Color.Transparent;
            this.ComboSerch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(22)))), ((int)(((byte)(199)))));
            this.ComboSerch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboSerch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSerch.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComboSerch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSerch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSerch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboSerch.ForeColor = System.Drawing.Color.Red;
            this.ComboSerch.ItemHeight = 30;
            this.ComboSerch.Location = new System.Drawing.Point(119, 18);
            this.ComboSerch.Name = "ComboSerch";
            this.ComboSerch.Size = new System.Drawing.Size(140, 36);
            this.ComboSerch.TabIndex = 79;
            // 
            // txtMemberName
            // 
            this.txtMemberName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(22)))), ((int)(((byte)(199)))));
            this.txtMemberName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMemberName.DefaultText = "";
            this.txtMemberName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMemberName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMemberName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMemberName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMemberName.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMemberName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMemberName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMemberName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMemberName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMemberName.Location = new System.Drawing.Point(265, 33);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.PasswordChar = '\0';
            this.txtMemberName.PlaceholderText = "";
            this.txtMemberName.SelectedText = "";
            this.txtMemberName.Size = new System.Drawing.Size(280, 26);
            this.txtMemberName.TabIndex = 78;
            this.txtMemberName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMemberName.TextChanged += new System.EventHandler(this.txtMemberName_TextChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::NewProject.Properties.Resources.add_new;
            this.btnAddNew.ImageRotate = 0F;
            this.btnAddNew.Location = new System.Drawing.Point(63, 28);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAddNew.Size = new System.Drawing.Size(33, 26);
            this.btnAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddNew.TabIndex = 81;
            this.btnAddNew.TabStop = false;
            // 
            // ucFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "ucFilter";
            this.Size = new System.Drawing.Size(790, 71);
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnAddNew;
        private Guna.UI2.WinForms.Guna2ComboBox ComboSerch;
        private Guna.UI2.WinForms.Guna2TextBox txtMemberName;
    }
}
