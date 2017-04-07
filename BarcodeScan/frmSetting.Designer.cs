namespace BarcodeScan
{
    partial class frmSetting
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
            this.grbPLC = new System.Windows.Forms.GroupBox();
            this.grbBar = new System.Windows.Forms.GroupBox();
            this.grbBarControl = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grbPLC
            // 
            this.grbPLC.Location = new System.Drawing.Point(28, 28);
            this.grbPLC.Name = "grbPLC";
            this.grbPLC.Size = new System.Drawing.Size(200, 270);
            this.grbPLC.TabIndex = 0;
            this.grbPLC.TabStop = false;
            this.grbPLC.Text = "PLC Serial Setting";
            // 
            // grbBar
            // 
            this.grbBar.Location = new System.Drawing.Point(234, 28);
            this.grbBar.Name = "grbBar";
            this.grbBar.Size = new System.Drawing.Size(200, 270);
            this.grbBar.TabIndex = 1;
            this.grbBar.TabStop = false;
            this.grbBar.Text = "Scanner Serial Setting";
            // 
            // grbBarControl
            // 
            this.grbBarControl.Location = new System.Drawing.Point(440, 28);
            this.grbBarControl.Name = "grbBarControl";
            this.grbBarControl.Size = new System.Drawing.Size(200, 270);
            this.grbBarControl.TabIndex = 2;
            this.grbBarControl.TabStop = false;
            this.grbBarControl.Text = "Control Scanner Setting";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 357);
            this.Controls.Add(this.grbBarControl);
            this.Controls.Add(this.grbBar);
            this.Controls.Add(this.grbPLC);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.Text = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPLC;
        private System.Windows.Forms.GroupBox grbBar;
        private System.Windows.Forms.GroupBox grbBarControl;
    }
}