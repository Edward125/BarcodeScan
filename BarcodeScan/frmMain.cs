using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edward;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;

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



        #region savelog

        /// <summary>
        /// 保存log
        /// </summary>
        /// <param name="logtype">log類型</param>
        /// <param name="logcontents">log內容</param>
        public static void saveLog(p.LogType log, string logcontents)
        {
            //根据logtype获取对应的文件路徑以及文件名
            string logpath = string.Empty;


            if (log == p.LogType.SysLog)
                logpath = p.SysLogFile;
            if (log == p.LogType.SNLog)
                logpath = p.SNLogFile;
            if (log == p.LogType.SN)
                logpath = p.SNFile;


            //判斷文件是否存在，不存在就创建文件，存在就写入文件
            if (!File.Exists(@logpath))
            {
                FileStream fs = File.Create(@logpath);
                fs.Close();
            }
            else
            {
                try
                {
                    File.AppendAllText(@logpath, DateTime.Now.ToString("yyyyMMddHHmmss") + " " + @logcontents + "\r\n");
                }
                catch (Exception)
                {
                    //wait

                }
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

        private void btnRun_Click(object sender, EventArgs e)
        {


            //check config value before start
            if (!checkSerialPortEmpty(p.PLC_Port, "PLC Portname can't be empty,pls set it...", this.comboPLC))
                return;
            if (!checkSerialPortEmpty(p.Scan_A_Port, "Scanner A Portname can't be empty,pls set it...", this.comboBarA))
               return;
            if (!checkSerialPortEmpty(p.Scan_B_Port, "Scanner B Portname can't be empty,pls set it...", this.comboBarB))
                return;
            if (!checkSerialPortEmpty(p.Scan_C_Port, "Scanner C Portname can't be empty,pls set it...", this.comboBarC))
                return;
            if (!checkSerialPortEmpty(p.Scan_D_Port, "Scanner D Portname can't be empty,pls set it...", this.comboBarD))
                return;

            







        }


        /// <summary>
        /// 检查串口的值是否为空,为空返回false，不为空返回true
        /// </summary>
        /// <param name="portvalue">串口的值参数</param>
        /// <param name="errmeesage">为空时的报错信息</param>
        /// <param name="comboport">选择串口值的combolist</param>
        /// <returns>empyt,return false,not empty,retun true</returns>
        private bool checkSerialPortEmpty(string portvalue, string errmeesage,ComboBox comboport)
        {
            if (string.IsNullOrEmpty(portvalue))
            {
                updateMessage(lstMessage, errmeesage);
                saveLog(p.LogType.SysLog, errmeesage);
                comboport.Focus();
                return false;
            }
            else
                return true;

        }



        #region 串口操作（SerialPort）


        /// <summary>
        /// 获取串口 
        /// </summary>
        /// <param name="combox"></param>
        private void getSerialPort(ComboBox combox)
        {
            combox.Items.Clear();
            combox.Text = string.Empty;
            foreach (string sp in System.IO.Ports.SerialPort.GetPortNames())
            {
                combox.Items.Add(sp);
            }

            if (combox.Items.Count > 0)
            {
                combox.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// 获取串口 
        /// </summary>
        /// <param name="combox"></param>
        /// <param name="paramdate">存储串口的数据</param>
        private void getSerialPort(ComboBox combox, string paramdate)
        {
            combox.Items.Clear();
            combox.Text = string.Empty;
            foreach (string sp in System.IO.Ports.SerialPort.GetPortNames())
            {
                combox.Items.Add(sp);
            }

            if (combox.Items.Count > 0)
            {
                if (string.IsNullOrEmpty(paramdate))
                    combox.SelectedIndex = 0;
                else
                    combox.Text = paramdate;
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sp">控件</param>
        /// <param name="portname">串口名称</param>
        /// <returns>OK=true,NG=false</returns>
        private bool openSerialPort(SerialPort sp, string portname)
        {
            // bool result = true;

            if (!sp.IsOpen)
            {
                try
                {
                    sp.PortName = portname;
                    sp.Open();
                    updateMessage(lstMessage , "Open SerialPort=" + portname + " success.");//Message:" + e.Message);
                    saveLog(p.LogType.SysLog , "Open SerialPort=" + portname + " success.\r\n");//Message:" + e.Message + "\r\n");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can't open SerialPort=" + portname + ",Message:" + e.Message);
                    updateMessage(lstMessage , "Can't open SerialPort=" + portname + ",Message:" + e.Message);
                    saveLog(p.LogType.SysLog , "Can't open SerialPort=" + portname + ",Message:" + e.Message + "\r\n");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// close serial port
        /// </summary>
        /// <param name="sp">OK=true,NG=false</param>
        /// <returns></returns>
        private bool closeSerialPort(SerialPort sp)
        {
            if (sp.IsOpen)
            {
                try
                {
                    sp.Close();
                }
                catch (Exception e)
                {
                    
                   updateMessage(lstMessage  ,"Can't close SerialPort=" + sp.PortName.ToString() + ",Message:" + e.Message);
                   saveLog(p.LogType.SysLog , "Can't close SerialPort=" + sp.PortName.ToString() + ",Message:" + e.Message + "\r\n");
                   return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 发送数据到串口
        /// </summary>
        /// <param name="spport">串口控件</param>
        /// <param name="strdata">发送的数据</param>
        private void sendData(SerialPort spport, string strdata)
        {
            try
            {
                spport.Write(strdata);
            }
            catch (Exception e)
            {
                updateMessage(lstMessage , "Send " + spport.PortName + " " + strdata + "fail");
                updateMessage(lstMessage , e.Message);
                saveLog(p.LogType.SysLog , "Send " + spport.PortName + " " + strdata + "fail," + e.Message);
            }
        }

        #endregion

        #region 动态选择串口（Dynamic detect serial port）

        // usb消息定义
        public const int WM_DEVICE_CHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004;
        public const UInt32 DBT_DEVTYP_PORT = 0x00000003;

        [StructLayout(LayoutKind.Sequential)]
        struct DEV_BROADCAST_HDR
        {
            public UInt32 dbch_size;
            public UInt32 dbch_devicetype;
            public UInt32 dbch_reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        protected struct DEV_BROADCAST_PORT_Fixed
        {
            public uint dbcp_size;
            public uint dbcp_devicetype;
            public uint dbcp_reserved;
            // Variable?length field dbcp_name is declared here in the C header file.
        }

        ///<summary>
        /// 检测USB串口的拔插
        ///</summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICE_CHANGE)        // 捕获USB设备的拔出消息WM_DEVICECHANGE
            {

                string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT_Fixed))));
                switch (m.WParam.ToInt32())
                {

                    case DBT_DEVICE_REMOVE_COMPLETE:    // USB拔出 
                        DEV_BROADCAST_HDR dbhdr0 = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                        if (dbhdr0.dbch_devicetype == DBT_DEVTYP_PORT)
                        {
                            try
                            {
                                // comboPortName.Items.Remove(portName);

                                getSerialPort(comboPLC, p.PLC_Port);
                                getSerialPort(comboBarA, p.Scan_A_Port);
                                getSerialPort(comboBarB, p.Scan_B_Port);
                                getSerialPort(comboBarC, p.Scan_C_Port);
                                getSerialPort(comboBarD, p.Scan_D_Port);
                      

                            }
                            catch (Exception ex)
                            {
                                //sp = new System.Media.SoundPlayer(global::SpotTestTester.Properties.Resources.ng);
                                //sp.Play();
                     
                            }
                            Console.WriteLine("已侦测到串口 '" + portName + "' 被移除...");
                            saveLog(p.LogType.SysLog, "已侦测到串口 '" + portName + "' 被移除...");
                        }

                        break;
                    case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
                        DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                        if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
                        {
        
                            Console.WriteLine("已侦测到串口 '" + portName + "' 插入电脑.");
                            saveLog(p.LogType.SysLog, "已侦测到串口 '" + portName + "' 插入电脑.");
                        }
                     break;
                }
            }
            base.WndProc(ref m);
        }


        #endregion

        private void brnRefresh_Click(object sender, EventArgs e)
        {
            getSerialPort(comboPLC, p.PLC_Port);
            getSerialPort(comboBarA, p.Scan_A_Port);
            getSerialPort(comboBarB, p.Scan_B_Port);
            getSerialPort(comboBarC, p.Scan_C_Port);
            getSerialPort(comboBarD, p.Scan_D_Port);
        }


    }
}
