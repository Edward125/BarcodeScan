using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edward;
using System.IO;

namespace BarcodeScan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            checkFolder();
            if (!File.Exists(p.IniFilePath))
                p.createIniFile(p.IniFilePath);
            else
            {
                p.readConfigValue(p.IniFilePath);
            }

            loadUI();

        }




        #region checkFoder
        private void checkFolder()
        {

        //public static string AppFolder = Application.StartupPath + @"\BarcodeScan";
        //public static string SNFile = AppFolder + @"\SN.txt"; //存放4个条码的文本文件
        //public static string SysLogFolder = AppFolder + @"\SysLog"; //存放所有信息的文件夹
        //public static string SNLogFolder = AppFolder + @"\SNLog"; //存放历史条码的文件夹
        //public static string SysLogFile = SysLogFolder + @"\Sys_" + DateTime.Now.ToString("yyyyMMdd") + @".log";
        //public static string SNLogFile = SNLogFolder + @"\SN_" + DateTime.Now.ToString("yyyyMMdd") + @".log";


            if (!Directory.Exists (p.AppFolder ))
                Directory.CreateDirectory (p.AppFolder);
            if (!Directory.Exists (p.SysLogFolder ))
                Directory.CreateDirectory (p.SysLogFolder);
            if (!Directory.Exists(p.SNLogFolder))
                Directory.CreateDirectory(p.SNLogFolder);
            if (!File.Exists(p.SNFile))
            {
                FileStream fs = File.Create(p.SNFile);
                fs.Close();
            }
            if (!File.Exists(p.SysLogFile))
            {
                FileStream fs = File.Create(p.SysLogFile);
                fs.Close ();
            }
            if (!File.Exists(p.SNLogFile))
            {
                FileStream fs = File.Create(p.SNLogFile);
                fs.Close();
            }
            
        }
        #endregion

        #region loadUI

        private void loadConfigUI()
        {
            //
            comboPLC.Text = p.PLC_Port;
            this.spPLC.BaudRate = Convert.ToInt16(p.PLC_Baud_Rate);
            this.spPLC.DataBits = Convert.ToInt16(p.PLC_Data_Bits);
            this.spPLC.StopBits = p.PLC_Stop_Bits;
            this.spPLC.Parity = p.PLC_Parity;
            //
            comboBarA.Text = p.Scan_A_Port;
            this.spBar_A.BaudRate = Convert.ToInt16(p.Scan_Baud_Rate);
            this.spBar_A.DataBits = Convert.ToInt16(p.Scan_Data_Bits);
            this.spBar_A.StopBits = p.Scan_Stop_Bits;
            this.spBar_A.Parity = p.Scan_Parity;
            //
            comboBarB.Text = p.Scan_B_Port;
            this.spBar_B.BaudRate = Convert.ToInt16(p.Scan_Baud_Rate);
            this.spBar_B.DataBits = Convert.ToInt16(p.Scan_Data_Bits);
            this.spBar_B.StopBits = p.Scan_Stop_Bits;
            this.spBar_B.Parity = p.Scan_Parity;
            //
            comboBarC.Text = p.Scan_C_Port;
            this.spBar_B.BaudRate = Convert.ToInt16(p.Scan_Baud_Rate);
            this.spBar_B.DataBits = Convert.ToInt16(p.Scan_Data_Bits);
            this.spBar_B.StopBits = p.Scan_Stop_Bits;
            this.spBar_B.Parity = p.Scan_Parity;
            //
            comboBarD.Text = p.Scan_D_Port;
            this.spBar_D.BaudRate = Convert.ToInt16(p.Scan_Baud_Rate);
            this.spBar_D.DataBits = Convert.ToInt16(p.Scan_Data_Bits);
            this.spBar_D.StopBits = p.Scan_Stop_Bits;
            this.spBar_D.Parity = p.Scan_Parity;
          
        }


        private void loadUI()
        {
            loadConfigUI();

            //
            this.Text = this.ProductName + ", Ver:" + Application.ProductVersion + ", Author:edward_song@yeah.net";
            //
            this.lstMessage.Items.Clear();
            this.lstBar.Items.Clear();
            //
            this.txtBarA.Text = string.Empty;
            this.txtBarB.Text = string.Empty;
            this.txtBarC.Text = string.Empty;
            this.txtBarD.Text = string.Empty;
            //
            this.btnRun.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnSet.Enabled = true;
            this.btnOpen.Enabled = true;


        }

        #endregion


        #region 更新信息
        /// <summary>
        /// 更新信息到listbox中
        /// </summary>
        /// <param name="listbox">listbox name</param>
        /// <param name="message">message</param>
        public static void updateMessage(ListBox listbox, string message)
        {
            if (listbox.Items.Count > 1000)
                listbox.Items.RemoveAt(0);

            string item = string.Empty;
            item = DateTime.Now.ToString("HH:mm:ss") + " " + @message;
            listbox.Items.Add(item);
            if (listbox.Items.Count > 1)
            {
                listbox.TopIndex = listbox.Items.Count - 1;
                listbox.SetSelected(listbox.Items.Count - 1, true);
            }
        }
        #endregion




        private void btnSet_Click(object sender, EventArgs e)
        {
            frmSetting f = new frmSetting();
            //f.ShowDialog();

            if (f.ShowDialog(this) != DialogResult.OK) //setting form closed
            {
                loadConfigUI();
            }
  
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }


    }
}
