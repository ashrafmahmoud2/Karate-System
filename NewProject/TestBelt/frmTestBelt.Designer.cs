namespace NewProject.TestBelt
{
    partial class frmTestBelt
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
            this.ucMainView1 = new NewProject.UserControls.ucMainView();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SuspendLayout();
            // 
            // ucMainView1
            // 
            this.ucMainView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ucMainView1.Location = new System.Drawing.Point(-1, 0);
            this.ucMainView1.Name = "ucMainView1";
            this.ucMainView1.Size = new System.Drawing.Size(1032, 686);
            this.ucMainView1.TabIndex = 0;
            this.ucMainView1.Load += new System.EventHandler(this.ucMainView1_Load);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 35;
            this.guna2Elipse1.TargetControl = this;
            // 
            // frmTestBelt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(183)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1032, 697);
            this.Controls.Add(this.ucMainView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTestBelt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTestBelt";
            this.Load += new System.EventHandler(this.frmTestBelt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucMainView ucMainView1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}