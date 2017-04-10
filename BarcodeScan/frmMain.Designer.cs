namespace BarcodeScan
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grbmessage = new System.Windows.Forms.GroupBox();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.brnRefresh = new System.Windows.Forms.Button();
            this.comboBarD = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBarB = new System.Windows.Forms.ComboBox();
            this.comboBarA = new System.Windows.Forms.ComboBox();
            this.comboBarC = new System.Windows.Forms.ComboBox();
            this.comboPLC = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBarD = new System.Windows.Forms.TextBox();
            this.txtBarC = new System.Windows.Forms.TextBox();
            this.txtBarB = new System.Windows.Forms.TextBox();
            this.txtBarA = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstBar = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grbTestBarocdeScanner = new System.Windows.Forms.GroupBox();
            this.comboBar = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.spPLC = new System.IO.Ports.SerialPort(this.components);
            this.spBar_A = new System.IO.Ports.SerialPort(this.components);
            this.spBar_B = new System.IO.Ports.SerialPort(this.components);
            this.spBar_C = new System.IO.Ports.SerialPort(this.components);
            this.spBar_D = new System.IO.Ports.SerialPort(this.components);
            this.grbmessage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grbTestBarocdeScanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbmessage
            // 
            this.grbmessage.Controls.Add(this.lstMessage);
            this.grbmessage.Location = new System.Drawing.Point(12, 148);
            this.grbmessage.Name = "grbmessage";
            this.grbmessage.Size = new System.Drawing.Size(423, 439);
            this.grbmessage.TabIndex = 0;
            this.grbmessage.TabStop = false;
            this.grbmessage.Text = "CommandList";
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.HorizontalScrollbar = true;
            this.lstMessage.ItemHeight = 14;
            this.lstMessage.Location = new System.Drawing.Point(6, 21);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(406, 410);
            this.lstMessage.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.brnRefresh);
            this.groupBox1.Controls.Add(this.comboBarD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBarB);
            this.groupBox1.Controls.Add(this.comboBarA);
            this.groupBox1.Controls.Add(this.comboBarC);
            this.groupBox1.Controls.Add(this.comboPLC);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SerialPortSetting";
            // 
            // brnRefresh
            // 
            this.brnRefresh.Location = new System.Drawing.Point(126, 94);
            this.brnRefresh.Name = "brnRefresh";
            this.brnRefresh.Size = new System.Drawing.Size(101, 28);
            this.brnRefresh.TabIndex = 3;
            this.brnRefresh.Text = "Refresh";
            this.brnRefresh.UseVisualStyleBackColor = true;
            this.brnRefresh.Click += new System.EventHandler(this.brnRefresh_Click);
            // 
            // comboBarD
            // 
            this.comboBarD.FormattingEnabled = true;
            this.comboBarD.Location = new System.Drawing.Point(163, 65);
            this.comboBarD.Name = "comboBarD";
            this.comboBarD.Size = new System.Drawing.Size(64, 22);
            this.comboBarD.TabIndex = 9;
            this.comboBarD.SelectedIndexChanged += new System.EventHandler(this.comboBarD_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bar_D";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bar_B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bar_C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bar_A:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "PLC:";
            // 
            // comboBarB
            // 
            this.comboBarB.FormattingEnabled = true;
            this.comboBarB.Location = new System.Drawing.Point(50, 100);
            this.comboBarB.Name = "comboBarB";
            this.comboBarB.Size = new System.Drawing.Size(64, 22);
            this.comboBarB.TabIndex = 3;
            this.comboBarB.SelectedIndexChanged += new System.EventHandler(this.comboBarB_SelectedIndexChanged);
            // 
            // comboBarA
            // 
            this.comboBarA.FormattingEnabled = true;
            this.comboBarA.Location = new System.Drawing.Point(50, 65);
            this.comboBarA.Name = "comboBarA";
            this.comboBarA.Size = new System.Drawing.Size(64, 22);
            this.comboBarA.TabIndex = 2;
            this.comboBarA.SelectedIndexChanged += new System.EventHandler(this.comboBarA_SelectedIndexChanged);
            // 
            // comboBarC
            // 
            this.comboBarC.FormattingEnabled = true;
            this.comboBarC.Location = new System.Drawing.Point(163, 32);
            this.comboBarC.Name = "comboBarC";
            this.comboBarC.Size = new System.Drawing.Size(64, 22);
            this.comboBarC.TabIndex = 1;
            this.comboBarC.SelectedIndexChanged += new System.EventHandler(this.comboBarC_SelectedIndexChanged);
            // 
            // comboPLC
            // 
            this.comboPLC.FormattingEnabled = true;
            this.comboPLC.Location = new System.Drawing.Point(50, 32);
            this.comboPLC.Name = "comboPLC";
            this.comboPLC.Size = new System.Drawing.Size(64, 22);
            this.comboPLC.TabIndex = 0;
            this.comboPLC.SelectedIndexChanged += new System.EventHandler(this.comboPLC_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBarD);
            this.groupBox2.Controls.Add(this.txtBarC);
            this.groupBox2.Controls.Add(this.txtBarB);
            this.groupBox2.Controls.Add(this.txtBarA);
            this.groupBox2.Location = new System.Drawing.Point(258, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 130);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CurrentBarcode";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 14);
            this.label9.TabIndex = 12;
            this.label9.Text = "Bar_D";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "Bar_C";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Bar_B";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bar_A:";
            // 
            // txtBarD
            // 
            this.txtBarD.Location = new System.Drawing.Point(52, 100);
            this.txtBarD.Name = "txtBarD";
            this.txtBarD.ReadOnly = true;
            this.txtBarD.Size = new System.Drawing.Size(298, 22);
            this.txtBarD.TabIndex = 3;
            this.txtBarD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBarC
            // 
            this.txtBarC.Location = new System.Drawing.Point(52, 74);
            this.txtBarC.Name = "txtBarC";
            this.txtBarC.ReadOnly = true;
            this.txtBarC.Size = new System.Drawing.Size(298, 22);
            this.txtBarC.TabIndex = 2;
            this.txtBarC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBarB
            // 
            this.txtBarB.Location = new System.Drawing.Point(52, 46);
            this.txtBarB.Name = "txtBarB";
            this.txtBarB.ReadOnly = true;
            this.txtBarB.Size = new System.Drawing.Size(298, 22);
            this.txtBarB.TabIndex = 1;
            this.txtBarB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBarA
            // 
            this.txtBarA.Location = new System.Drawing.Point(52, 19);
            this.txtBarA.Name = "txtBarA";
            this.txtBarA.ReadOnly = true;
            this.txtBarA.Size = new System.Drawing.Size(298, 22);
            this.txtBarA.TabIndex = 0;
            this.txtBarA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstBar);
            this.groupBox3.Location = new System.Drawing.Point(441, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 439);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BarcodeList";
            // 
            // lstBar
            // 
            this.lstBar.FormattingEnabled = true;
            this.lstBar.HorizontalScrollbar = true;
            this.lstBar.ItemHeight = 14;
            this.lstBar.Location = new System.Drawing.Point(6, 21);
            this.lstBar.Name = "lstBar";
            this.lstBar.Size = new System.Drawing.Size(368, 410);
            this.lstBar.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSet);
            this.groupBox4.Controls.Add(this.btnStop);
            this.groupBox4.Controls.Add(this.btnRun);
            this.groupBox4.Location = new System.Drawing.Point(623, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 62);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(133, 21);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(53, 30);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set...";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(77, 21);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(53, 30);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(6, 21);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(67, 30);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // grbTestBarocdeScanner
            // 
            this.grbTestBarocdeScanner.Controls.Add(this.comboBar);
            this.grbTestBarocdeScanner.Controls.Add(this.btnOpen);
            this.grbTestBarocdeScanner.Location = new System.Drawing.Point(623, 83);
            this.grbTestBarocdeScanner.Name = "grbTestBarocdeScanner";
            this.grbTestBarocdeScanner.Size = new System.Drawing.Size(192, 57);
            this.grbTestBarocdeScanner.TabIndex = 4;
            this.grbTestBarocdeScanner.TabStop = false;
            this.grbTestBarocdeScanner.Text = "Test Barcode Scanner";
            // 
            // comboBar
            // 
            this.comboBar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBar.FormattingEnabled = true;
            this.comboBar.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.comboBar.Location = new System.Drawing.Point(95, 25);
            this.comboBar.Name = "comboBar";
            this.comboBar.Size = new System.Drawing.Size(64, 22);
            this.comboBar.TabIndex = 10;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 21);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(67, 26);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // spPLC
            // 
            this.spPLC.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spPLC_DataReceived);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 597);
            this.Controls.Add(this.grbTestBarocdeScanner);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbmessage);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grbmessage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.grbTestBarocdeScanner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbmessage;
        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBarB;
        private System.Windows.Forms.ComboBox comboBarA;
        private System.Windows.Forms.ComboBox comboBarC;
        private System.Windows.Forms.ComboBox comboPLC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBarD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstBar;
        private System.Windows.Forms.Button brnRefresh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBarD;
        private System.Windows.Forms.TextBox txtBarC;
        private System.Windows.Forms.TextBox txtBarB;
        private System.Windows.Forms.TextBox txtBarA;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox grbTestBarocdeScanner;
        private System.Windows.Forms.ComboBox comboBar;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSet;
        private System.IO.Ports.SerialPort spPLC;
        private System.IO.Ports.SerialPort spBar_A;
        private System.IO.Ports.SerialPort spBar_B;
        private System.IO.Ports.SerialPort spBar_C;
        private System.IO.Ports.SerialPort spBar_D;
    }
}

