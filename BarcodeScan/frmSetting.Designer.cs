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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.grbPLC = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combPLC_Parity = new System.Windows.Forms.ComboBox();
            this.combPLC_StopBits = new System.Windows.Forms.ComboBox();
            this.combPLC_DataBits = new System.Windows.Forms.ComboBox();
            this.combPLC_BaudRate = new System.Windows.Forms.ComboBox();
            this.grbBar = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combBar_BaudRate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combBar_DataBits = new System.Windows.Forms.ComboBox();
            this.combBarStopBits = new System.Windows.Forms.ComboBox();
            this.combBar_Parity = new System.Windows.Forms.ComboBox();
            this.grbBarControl = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkClose_Add_Enter = new System.Windows.Forms.CheckBox();
            this.chkOpen_Add_Enter = new System.Windows.Forms.CheckBox();
            this.txtClose_Scan_Command = new System.Windows.Forms.TextBox();
            this.txtOpen_Scan_Command = new System.Windows.Forms.TextBox();
            this.grbPLC.SuspendLayout();
            this.grbBar.SuspendLayout();
            this.grbBarControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPLC
            // 
            this.grbPLC.Controls.Add(this.label4);
            this.grbPLC.Controls.Add(this.label3);
            this.grbPLC.Controls.Add(this.label2);
            this.grbPLC.Controls.Add(this.label1);
            this.grbPLC.Controls.Add(this.combPLC_Parity);
            this.grbPLC.Controls.Add(this.combPLC_StopBits);
            this.grbPLC.Controls.Add(this.combPLC_DataBits);
            this.grbPLC.Controls.Add(this.combPLC_BaudRate);
            this.grbPLC.Location = new System.Drawing.Point(28, 28);
            this.grbPLC.Name = "grbPLC";
            this.grbPLC.Size = new System.Drawing.Size(200, 178);
            this.grbPLC.TabIndex = 0;
            this.grbPLC.TabStop = false;
            this.grbPLC.Text = "PLC Serial Setting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "StopBits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "DataBits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "BaudRate";
            // 
            // combPLC_Parity
            // 
            this.combPLC_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPLC_Parity.FormattingEnabled = true;
            this.combPLC_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            this.combPLC_Parity.Location = new System.Drawing.Point(84, 142);
            this.combPLC_Parity.Name = "combPLC_Parity";
            this.combPLC_Parity.Size = new System.Drawing.Size(101, 22);
            this.combPLC_Parity.TabIndex = 3;
            this.combPLC_Parity.SelectedIndexChanged += new System.EventHandler(this.combPLC_Parity_SelectedIndexChanged);
            // 
            // combPLC_StopBits
            // 
            this.combPLC_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPLC_StopBits.FormattingEnabled = true;
            this.combPLC_StopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.combPLC_StopBits.Location = new System.Drawing.Point(84, 99);
            this.combPLC_StopBits.Name = "combPLC_StopBits";
            this.combPLC_StopBits.Size = new System.Drawing.Size(101, 22);
            this.combPLC_StopBits.TabIndex = 2;
            this.combPLC_StopBits.SelectedIndexChanged += new System.EventHandler(this.combPLC_StopBits_SelectedIndexChanged);
            // 
            // combPLC_DataBits
            // 
            this.combPLC_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPLC_DataBits.FormattingEnabled = true;
            this.combPLC_DataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.combPLC_DataBits.Location = new System.Drawing.Point(84, 59);
            this.combPLC_DataBits.Name = "combPLC_DataBits";
            this.combPLC_DataBits.Size = new System.Drawing.Size(101, 22);
            this.combPLC_DataBits.TabIndex = 1;
            this.combPLC_DataBits.SelectedIndexChanged += new System.EventHandler(this.combPLC_DataBits_SelectedIndexChanged);
            // 
            // combPLC_BaudRate
            // 
            this.combPLC_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPLC_BaudRate.FormattingEnabled = true;
            this.combPLC_BaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.combPLC_BaudRate.Location = new System.Drawing.Point(84, 21);
            this.combPLC_BaudRate.Name = "combPLC_BaudRate";
            this.combPLC_BaudRate.Size = new System.Drawing.Size(101, 22);
            this.combPLC_BaudRate.TabIndex = 0;
            this.combPLC_BaudRate.SelectedIndexChanged += new System.EventHandler(this.combPLC_BaudRate_SelectedIndexChanged);
            // 
            // grbBar
            // 
            this.grbBar.Controls.Add(this.label5);
            this.grbBar.Controls.Add(this.label8);
            this.grbBar.Controls.Add(this.label6);
            this.grbBar.Controls.Add(this.combBar_BaudRate);
            this.grbBar.Controls.Add(this.label7);
            this.grbBar.Controls.Add(this.combBar_DataBits);
            this.grbBar.Controls.Add(this.combBarStopBits);
            this.grbBar.Controls.Add(this.combBar_Parity);
            this.grbBar.Location = new System.Drawing.Point(234, 28);
            this.grbBar.Name = "grbBar";
            this.grbBar.Size = new System.Drawing.Size(200, 178);
            this.grbBar.TabIndex = 1;
            this.grbBar.TabStop = false;
            this.grbBar.Text = "Scanner Serial Setting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Parity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "BaudRate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "StopBits";
            // 
            // combBar_BaudRate
            // 
            this.combBar_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBar_BaudRate.FormattingEnabled = true;
            this.combBar_BaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.combBar_BaudRate.Location = new System.Drawing.Point(82, 21);
            this.combBar_BaudRate.Name = "combBar_BaudRate";
            this.combBar_BaudRate.Size = new System.Drawing.Size(101, 22);
            this.combBar_BaudRate.TabIndex = 8;
            this.combBar_BaudRate.SelectedIndexChanged += new System.EventHandler(this.combBar_BaudRate_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "DataBits";
            // 
            // combBar_DataBits
            // 
            this.combBar_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBar_DataBits.FormattingEnabled = true;
            this.combBar_DataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.combBar_DataBits.Location = new System.Drawing.Point(82, 59);
            this.combBar_DataBits.Name = "combBar_DataBits";
            this.combBar_DataBits.Size = new System.Drawing.Size(101, 22);
            this.combBar_DataBits.TabIndex = 9;
            this.combBar_DataBits.SelectedIndexChanged += new System.EventHandler(this.combBar_DataBits_SelectedIndexChanged);
            // 
            // combBarStopBits
            // 
            this.combBarStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBarStopBits.FormattingEnabled = true;
            this.combBarStopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "OnePointFive",
            "Two"});
            this.combBarStopBits.Location = new System.Drawing.Point(82, 99);
            this.combBarStopBits.Name = "combBarStopBits";
            this.combBarStopBits.Size = new System.Drawing.Size(101, 22);
            this.combBarStopBits.TabIndex = 10;
            this.combBarStopBits.SelectedIndexChanged += new System.EventHandler(this.combBarStopBits_SelectedIndexChanged);
            // 
            // combBar_Parity
            // 
            this.combBar_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBar_Parity.FormattingEnabled = true;
            this.combBar_Parity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            this.combBar_Parity.Location = new System.Drawing.Point(82, 142);
            this.combBar_Parity.Name = "combBar_Parity";
            this.combBar_Parity.Size = new System.Drawing.Size(101, 22);
            this.combBar_Parity.TabIndex = 11;
            this.combBar_Parity.SelectedIndexChanged += new System.EventHandler(this.combBar_Parity_SelectedIndexChanged);
            // 
            // grbBarControl
            // 
            this.grbBarControl.Controls.Add(this.label10);
            this.grbBarControl.Controls.Add(this.label9);
            this.grbBarControl.Controls.Add(this.chkClose_Add_Enter);
            this.grbBarControl.Controls.Add(this.chkOpen_Add_Enter);
            this.grbBarControl.Controls.Add(this.txtClose_Scan_Command);
            this.grbBarControl.Controls.Add(this.txtOpen_Scan_Command);
            this.grbBarControl.Location = new System.Drawing.Point(440, 28);
            this.grbBarControl.Name = "grbBarControl";
            this.grbBarControl.Size = new System.Drawing.Size(213, 178);
            this.grbBarControl.TabIndex = 2;
            this.grbBarControl.TabStop = false;
            this.grbBarControl.Text = "Control Scanner Setting";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 14);
            this.label10.TabIndex = 5;
            this.label10.Text = "Close Scanner";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 14);
            this.label9.TabIndex = 4;
            this.label9.Text = "Open Scanner";
            // 
            // chkClose_Add_Enter
            // 
            this.chkClose_Add_Enter.AutoSize = true;
            this.chkClose_Add_Enter.Location = new System.Drawing.Point(15, 145);
            this.chkClose_Add_Enter.Name = "chkClose_Add_Enter";
            this.chkClose_Add_Enter.Size = new System.Drawing.Size(157, 18);
            this.chkClose_Add_Enter.TabIndex = 3;
            this.chkClose_Add_Enter.Text = "Close Scanner Add Enter";
            this.chkClose_Add_Enter.UseVisualStyleBackColor = true;
            this.chkClose_Add_Enter.CheckedChanged += new System.EventHandler(this.chkClose_Add_Enter_CheckedChanged);
            // 
            // chkOpen_Add_Enter
            // 
            this.chkOpen_Add_Enter.AutoSize = true;
            this.chkOpen_Add_Enter.Location = new System.Drawing.Point(14, 114);
            this.chkOpen_Add_Enter.Name = "chkOpen_Add_Enter";
            this.chkOpen_Add_Enter.Size = new System.Drawing.Size(156, 18);
            this.chkOpen_Add_Enter.TabIndex = 2;
            this.chkOpen_Add_Enter.Text = "Open Scanner Add Enter";
            this.chkOpen_Add_Enter.UseVisualStyleBackColor = true;
            this.chkOpen_Add_Enter.CheckedChanged += new System.EventHandler(this.chkOpen_Add_Enter_CheckedChanged);
            // 
            // txtClose_Scan_Command
            // 
            this.txtClose_Scan_Command.Location = new System.Drawing.Point(100, 74);
            this.txtClose_Scan_Command.Name = "txtClose_Scan_Command";
            this.txtClose_Scan_Command.Size = new System.Drawing.Size(94, 22);
            this.txtClose_Scan_Command.TabIndex = 1;
            this.txtClose_Scan_Command.TextChanged += new System.EventHandler(this.txtClose_Scan_Command_TextChanged);
            // 
            // txtOpen_Scan_Command
            // 
            this.txtOpen_Scan_Command.Location = new System.Drawing.Point(100, 37);
            this.txtOpen_Scan_Command.Name = "txtOpen_Scan_Command";
            this.txtOpen_Scan_Command.Size = new System.Drawing.Size(94, 22);
            this.txtOpen_Scan_Command.TabIndex = 0;
            this.txtOpen_Scan_Command.TextChanged += new System.EventHandler(this.txtOpen_Scan_Command_TextChanged);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 245);
            this.Controls.Add(this.grbBarControl);
            this.Controls.Add(this.grbBar);
            this.Controls.Add(this.grbPLC);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.Text = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.grbPLC.ResumeLayout(false);
            this.grbPLC.PerformLayout();
            this.grbBar.ResumeLayout(false);
            this.grbBar.PerformLayout();
            this.grbBarControl.ResumeLayout(false);
            this.grbBarControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPLC;
        private System.Windows.Forms.GroupBox grbBar;
        private System.Windows.Forms.GroupBox grbBarControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combPLC_Parity;
        private System.Windows.Forms.ComboBox combPLC_StopBits;
        private System.Windows.Forms.ComboBox combPLC_DataBits;
        private System.Windows.Forms.ComboBox combPLC_BaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combBar_BaudRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combBar_DataBits;
        private System.Windows.Forms.ComboBox combBarStopBits;
        private System.Windows.Forms.ComboBox combBar_Parity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkClose_Add_Enter;
        private System.Windows.Forms.CheckBox chkOpen_Add_Enter;
        private System.Windows.Forms.TextBox txtClose_Scan_Command;
        private System.Windows.Forms.TextBox txtOpen_Scan_Command;
    }
}