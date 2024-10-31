using System;
using System.Windows.Forms;
namespace Karate_System_Forms_
{
    partial class UserControl1
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtText = new Guna.UI2.WinForms.Guna2TextBox();
            this.ComboSerch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labTitel = new System.Windows.Forms.Label();
            this.btnAddNew = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnDelete = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnSerach = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSerach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AllowUserToOrderColumns = true;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(0, 270);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.Size = new System.Drawing.Size(1149, 344);
            this.DataGridView1.TabIndex = 65;
            // 
            // txtText
            // 
            this.txtText.AutoRoundedCorners = true;
            this.txtText.BorderRadius = 12;
            this.txtText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtText.DefaultText = "";
            this.txtText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtText.FillColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtText.Location = new System.Drawing.Point(512, 48);
            this.txtText.Name = "txtText";
            this.txtText.PasswordChar = '\0';
            this.txtText.PlaceholderText = "";
            this.txtText.SelectedText = "";
            this.txtText.Size = new System.Drawing.Size(300, 26);
            this.txtText.TabIndex = 66;
            this.txtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ComboSerch
            // 
            this.ComboSerch.AutoRoundedCorners = true;
            this.ComboSerch.BackColor = System.Drawing.Color.Transparent;
            this.ComboSerch.BorderRadius = 17;
            this.ComboSerch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboSerch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSerch.FillColor = System.Drawing.SystemColors.AppWorkspace;
            this.ComboSerch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSerch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSerch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboSerch.ForeColor = System.Drawing.Color.Red;
            this.ComboSerch.ItemHeight = 30;
            this.ComboSerch.Location = new System.Drawing.Point(641, 6);
            this.ComboSerch.Name = "ComboSerch";
            this.ComboSerch.Size = new System.Drawing.Size(140, 36);
            this.ComboSerch.TabIndex = 67;
            // 
            // labTitel
            // 
            this.labTitel.AutoSize = true;
            this.labTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labTitel.Location = new System.Drawing.Point(481, 225);
            this.labTitel.Name = "labTitel";
            this.labTitel.Size = new System.Drawing.Size(106, 37);
            this.labTitel.TabIndex = 72;
            this.labTitel.Text = "label1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::Karate_System_Forms_.Properties.Resources.add_new;
            this.btnAddNew.ImageRotate = 0F;
            this.btnAddNew.Location = new System.Drawing.Point(779, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAddNew.Size = new System.Drawing.Size(33, 39);
            this.btnAddNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddNew.TabIndex = 71;
            this.btnAddNew.TabStop = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Karate_System_Forms_.Properties.Resources.delete;
            this.btnDelete.ImageRotate = 0F;
            this.btnDelete.Location = new System.Drawing.Point(36, 225);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDelete.Size = new System.Drawing.Size(54, 39);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDelete.TabIndex = 70;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::Karate_System_Forms_.Properties.Resources.Update;
            this.btnUpdate.ImageRotate = 0F;
            this.btnUpdate.Location = new System.Drawing.Point(3, 225);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnUpdate.Size = new System.Drawing.Size(41, 39);
            this.btnUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUpdate.TabIndex = 68;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSerach
            // 
            this.btnSerach.Image = global::Karate_System_Forms_.Properties.Resources.find;
            this.btnSerach.ImageRotate = 0F;
            this.btnSerach.Location = new System.Drawing.Point(512, 35);
            this.btnSerach.Name = "btnSerach";
            this.btnSerach.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSerach.Size = new System.Drawing.Size(33, 39);
            this.btnSerach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSerach.TabIndex = 69;
            this.btnSerach.TabStop = false;
            this.btnSerach.Click += new System.EventHandler(this.btnSerach_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Image = global::Karate_System_Forms_.Properties.Resources.icons8_maximize_100;
            this.btnMaximize.ImageRotate = 0F;
            this.btnMaximize.Location = new System.Drawing.Point(36, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnMaximize.Size = new System.Drawing.Size(54, 39);
            this.btnMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximize.TabIndex = 64;
            this.btnMaximize.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Karate_System_Forms_.Properties.Resources.close;
            this.btnClose.ImageRotate = 0F;
            this.btnClose.Location = new System.Drawing.Point(2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.Size = new System.Drawing.Size(41, 39);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 62;
            this.btnClose.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Image = global::Karate_System_Forms_.Properties.Resources.minimize;
            this.btnMinimize.ImageRotate = 0F;
            this.btnMinimize.Location = new System.Drawing.Point(86, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnMinimize.Size = new System.Drawing.Size(33, 39);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 63;
            this.btnMinimize.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.labTitel);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSerach);
            this.Controls.Add(this.ComboSerch);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.btnMaximize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1152, 617);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSerach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox btnMaximize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnClose;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnMinimize;
        private System.Windows.Forms.DataGridView DataGridView1;
        private Guna.UI2.WinForms.Guna2TextBox txtText;
        private Guna.UI2.WinForms.Guna2ComboBox ComboSerch;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnDelete;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnUpdate;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnSerach;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnAddNew;
        private System.Windows.Forms.Label labTitel;
    }
}
