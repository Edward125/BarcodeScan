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


        #region 參數定義

        private int _MaxTryCount = 3;
        private int _CurrentTryCount = 0;
        private bool _runing = true; //run:true;test scanner:false


        #endregion

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
            this.spPLC.BaudRate = Convert.ToInt32 (p.PLC_Baud_Rate);
            this.spPLC.DataBits = Convert.ToInt32(p.PLC_Data_Bits);
            this.spPLC.StopBits = p.PLC_Stop_Bits;
            this.spPLC.Parity = p.PLC_Parity;


            //
            comboBarA.Text = p.Scan_A_Port;
            this.spBar_A.BaudRate = Convert.ToInt32(p.Scan_Baud_Rate);
            this.spBar_A.DataBits = Convert.ToInt32(p.Scan_Data_Bits);
            this.spBar_A.StopBits = p.Scan_Stop_Bits;
            this.spBar_A.Parity = p.Scan_Parity;
            //
            comboBarB.Text = p.Scan_B_Port;
            this.spBar_B.BaudRate = Convert.ToInt32(p.Scan_Baud_Rate);
            this.spBar_B.DataBits = Convert.ToInt32(p.Scan_Data_Bits);
            this.spBar_B.StopBits = p.Scan_Stop_Bits;
            this.spBar_B.Parity = p.Scan_Parity;
            //
            comboBarC.Text = p.Scan_C_Port;
            this.spBar_C.BaudRate = Convert.ToInt32(p.Scan_Baud_Rate);
            this.spBar_C.DataBits = Convert.ToInt32(p.Scan_Data_Bits);
            this.spBar_C.StopBits = p.Scan_Stop_Bits;
            this.spBar_C.Parity = p.Scan_Parity;
            //
            comboBarD.Text = p.Scan_D_Port;
            this.spBar_D.BaudRate = Convert.ToInt32(p.Scan_Baud_Rate);
            this.spBar_D.DataBits = Convert.ToInt32(p.Scan_Data_Bits);
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
            //
            this.comboBar.SelectedIndex = 0;
            //
          //  if (string.IsNullOrEmpty(p.PLC_Port))
                getSerialPort(comboPLC, p.PLC_Port);
           // if (string.IsNullOrEmpty(p.Scan_A_Port))
                getSerialPort(comboBarA, p.Scan_A_Port);
           // if (string.IsNullOrEmpty(p.Scan_B_Port))
                getSerialPort(comboBarB, p.Scan_B_Port);
          //  if (string.IsNullOrEmpty(p.Scan_C_Port))
                getSerialPort(comboBarC, p.Scan_C_Port);
           // if (string.IsNullOrEmpty(p.Scan_D_Port))
                getSerialPort(comboBarD, p.Scan_D_Port);

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


            // Display a horizontal scroll bar.
            listbox.HorizontalScrollbar = true;

            // Create a Graphics object to use when determining the size of the largest item in the ListBox.
            Graphics g = listbox.CreateGraphics();

            // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
            int hzSize = (int)g.MeasureString(listbox.Items[listbox.Items.Count - 1].ToString(), listbox.Font).Width;
            // Set the HorizontalExtent property.
            listbox.HorizontalExtent = hzSize;


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
            try
            {

                if (log == p.LogType.SN)
                    File.AppendAllText(@logpath, @logcontents + "\r\n");
                else
                    File.AppendAllText(@logpath, DateTime.Now.ToString("yyyyMMddHHmmss") + " " + @logcontents + "\r\n");
            }
            catch (Exception)
            {
                //wait

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

            if (btnOpen.Text.Trim().ToUpper() == "OPEN")
            {
                btnOpen.Text = "Close";
                switch (comboBar.SelectedItem.ToString ())
                {
                    case "A":
                        TestOpenScanner(spBar_A , p.Scan_A_Port , "A", "PC->BarA:");
                        break;
                    case "B":
                        TestOpenScanner(spBar_B, p.Scan_B_Port ,"B", "PC->BarB:");
                        break;
                    case "C":
                        TestOpenScanner(spBar_C, p.Scan_C_Port ,"C", "PC->BarC:");
                        break;
                    case  "D":
                        TestOpenScanner(spBar_D,p.Scan_D_Port , "D", "PC->BarD:");
                        break ;
                    default:
                        break;
                }

                grbFunctionBtn.Enabled = false;
                this.comboBar.Enabled = false;
            }
            else
            {
                btnOpen.Text = "Open";
                switch (comboBar.SelectedItem.ToString ())
                {
                    case "A":
                       TestCloseScanner (spBar_A ,"A","PC->BarA:");
                        break;
                    case "B":
                        TestCloseScanner(spBar_B, "B", "PC->BarB:");
                        break;
                    case "C":
                        TestCloseScanner(spBar_C, "C", "PC->BarC:");
                        break;
                    case "D":
                        TestCloseScanner(spBar_D, "D", "PC->BarD:");
                        break;
                    default:
                        break;
                }
                grbFunctionBtn.Enabled = true;
                this.comboBar.Enabled = true;
            }




        }



        #region TestScanner

        /// <summary>
        /// 测试打开串口，并保存log
        /// </summary>
        /// <param name="portname">串口号</param>
        /// <param name="sp">串口控件</param>
        /// <param name="str1">条码枪标志,如A,B,C,D</param>
        /// <param name="str2">log前缀，如”PC->BarA:"</param>
        private void TestOpenScanner(SerialPort sp, string portname, string str1, string str2)
        {
            updateMessage(lstMessage, "Start test scanner " + str1 +" ,open it...");
            saveLog(p.LogType.SysLog, "Start test scanner " + str1 + " ,open it...");
            openScanner(sp,portname, str2);
            _runing = false;
        }



        /// <summary>
        /// 打开条码枪串口，并保存log
        /// </summary>
        /// <param name="portname">串口号</param>
        /// <param name="sp">串口控件</param>
        /// <param name="str2">log前缀，如”PC->BarA:"</param>
        private void openScanner(SerialPort sp,string portname, string str2)
        {

            openSerialPort(sp, portname);

            if (p.Send_Command_Use_Hex)
            {
                sendHex(sp, p.Open_Scan_Command);
            }
            else
            {
                if (p.Open_Add_Enter)
                    sendData(sp, p.Open_Scan_Command + Other.Chr(13));
                else
                    sendData(sp, p.Open_Scan_Command);
            }

            updateMessage(lstMessage, str2 + p.Open_Scan_Command);
            saveLog(p.LogType.SysLog, str2 + p.Open_Scan_Command);
        }

        /// <summary>
        /// 测试关闭串口，并保存log
        /// </summary>
        /// <param name="sp">串口控件</param>
        /// <param name="str1">条码枪标志,如A,B,C,D</param>
        /// <param name="str2">log前缀，如”PC->BarA:"</param>
        private void TestCloseScanner(SerialPort sp, string str1, string str2)
        {
            updateMessage(lstMessage, "End test scanner " + str1 + " ,close it...");
            saveLog(p.LogType.SysLog, "End test scanner " + str1 + " ,close it...");
            //sp.PortName = portname;
            closeScanner(sp, str2);
            _runing = true;
        }



        /// <summary>
        /// 打开条码枪串口，并保存log
        /// </summary>
        /// <param name="sp">串口控件</param>
        /// <param name="str2">log前缀，如”PC->BarA:"</param>
        private void closeScanner(SerialPort sp,string str2)
        {
            //sp.PortName = portname;
            if (p.Send_Command_Use_Hex)
                sendHex(sp, p.Close_Scan_Command);
            else
            {
                if (p.Close_Add_Enter)
                    sendData(sp, p.Close_Scan_Command + Other.Chr(13));
                else
                    sendData(sp, p.Close_Scan_Command);
            }
            updateMessage(lstMessage, str2 + p.Close_Scan_Command);
            saveLog(p.LogType.SysLog, str2 + p.Close_Scan_Command);
            closeSerialPort(sp);
        }

        
        #endregion



        private void btnRun_Click(object sender, EventArgs e)
        {
            //timerScanTimeout.Enabled = true;
            //timerScanTimeout.Start();

            //return;
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

            // check command....
            if (string.IsNullOrEmpty(p.Open_Scan_Command))
            {
                updateMessage(lstMessage, "Open Scanner command can't be empty or null,pls set it....");
                saveLog(p.LogType.SysLog, "Open Scanner command can't be empty or null,pls set it....");
                return;
            }
            if (string.IsNullOrEmpty(p.Close_Scan_Command))
            {
                updateMessage(lstMessage, "Close Scanner command can't be empty or null,pls set it...");
                saveLog(p.LogType.SysLog, "Close Scanner command can't be empty or null,pls set it...");
                return;
            }


            if (p.Send_Command_Use_Hex)
            {

                if (!p.IsHex(p.Open_Scan_Command ))
                {
                    MessageBox.Show("what you input is not HEX,pls check...", "Check Open Scanner COmmand is Hex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!p.IsHex(p.Close_Scan_Command ))
                {
                    MessageBox.Show("what you input is not HEX,pls check...", "Check Close Scanner Command is Hex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (!((p.Open_Scan_Command.Length % 2) == 0))
                {
                    MessageBox.Show("Open sanner command's length is not EVEN(偶数长度),pls check...", "Check Open sanner command length", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!((p.Close_Scan_Command.Length % 2) == 0))
                {
                    MessageBox.Show("Close sanner command's length is not EVEN(偶数长度),pls check...", "Check Close sanner command length", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //
            if (!openSerialPort(spPLC, p.PLC_Port))
                return;
            if (!openSerialPort(spBar_A, p.Scan_A_Port))
            {
                closeSerialPort(spPLC);
                return;
            }
            if (!openSerialPort(spBar_B, p.Scan_B_Port))
            {
                closeSerialPort(spPLC);
                closeSerialPort(spBar_A);
                return;
            }
            if (!openSerialPort(spBar_C, p.Scan_C_Port))
            {
                closeSerialPort(spPLC);
                closeSerialPort(spBar_A);
                closeSerialPort(spBar_B);
                return;
            }
            if (!openSerialPort(spBar_D, p.Scan_D_Port))
            {
                closeSerialPort(spPLC);
                closeSerialPort(spBar_A);
                closeSerialPort(spBar_B);
                closeSerialPort(spBar_C);
                return;
            }
           





            //
            this.btnRun.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnSet.Enabled = false;
            grbTestBarocdeScanner.Enabled = false;
            grbSerialPortSetting.Enabled = false;
            _runing = true;





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
                    saveLog(p.LogType.SysLog , "Open SerialPort=" + portname + " success.");//Message:" + e.Message + "\r\n");
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
                    updateMessage(lstMessage, "Close SerialPort=" + sp.PortName.ToString() + " success...");
                    saveLog(p.LogType.SysLog , "Close SerialPort=" + sp.PortName.ToString() + " success...");
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


        /// <summary>
        /// send hex to serial port
        /// </summary>
        /// <param name="spport">serial </param>
        /// <param name="strdata">hex data</param>
        private void sendHex(SerialPort spport, string strdata)
        {

            try
            {
                byte[] outBytes = new byte[strdata.Length / 2];
                for (int i = 1; i <= strdata.Length - 1; i += 2)
                {
                    outBytes[(i - 1) / 2] = (byte)Convert.ToInt32(("0x" + strdata.Substring(i - 1, 2)), 16);
                }
                spport.Write(outBytes, 0, outBytes.Length);
            }
            catch (Exception e)
            {

                updateMessage(lstMessage, "Send " + spport.PortName + " " + strdata + "fail");
                updateMessage(lstMessage, e.Message);
                saveLog(p.LogType.SysLog, "Send " + spport.PortName + " " + strdata + "fail," + e.Message);
            }

         
        }



        #endregion

        #region Dynamic detect serial port

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

        /// <summary>
        /// 检测USB串口的拔插
        /// </summary>
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

                                if ( btnRun.Enabled)
                                {
                                    getSerialPort(comboPLC, p.PLC_Port);
                                    getSerialPort(comboBarA, p.Scan_A_Port);
                                    getSerialPort(comboBarB, p.Scan_B_Port);
                                    getSerialPort(comboBarC, p.Scan_C_Port);
                                    getSerialPort(comboBarD, p.Scan_D_Port);


                                }
                                else
                                {
                                    //sp = new System.Media.SoundPlayer(global::SpotTestTester.Properties.Resources.ng);
                                    //sp.Play();
                                    updateMessage(lstMessage , "Port '" + portName + "' leaved.");
                                    saveLog(p.LogType.SysLog , "Port '" + portName + "' leaved.");
                                    // updateMessage(lstHistoryLog, "偵測到串口丟失，請重新設置后點擊開始，若無法啟動，點擊Restart再點擊Start。");
                                    //closePort(spPLC);
                                    //closePort(spSN);
                                    //pressStopButton();
                                }


                            }
                            catch (Exception ex)
                            {
                                //sp = new System.Media.SoundPlayer(global::SpotTestTester.Properties.Resources.ng);
                                //sp.Play();
                                //updateMessage(lstHistoryLog, "Port '" + portName + "' leaved.");
                                //updateMessage(lstHistoryLog, ex.Message);
                                updateMessage(lstMessage , ex.Message);
                                saveLog(p.LogType.SysLog , ex.Message);


                            }
                            Console.WriteLine("Port '" + portName + "' leaved.");
                        }

                        break;
                    case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
                        DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                        if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
                        {
                            getSerialPort(comboPLC, p.PLC_Port);
                            getSerialPort(comboBarA, p.Scan_A_Port);
                            getSerialPort(comboBarB, p.Scan_B_Port);
                            getSerialPort(comboBarC, p.Scan_C_Port);
                            getSerialPort(comboBarD, p.Scan_D_Port);
                            Console.WriteLine("Port '" + portName + "' arrived.");
                            updateMessage(lstMessage, "Port '" + portName + "' arrived.");
                            saveLog(p.LogType.SysLog, "Port '" + portName + "' arrived.");
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

        private void comboPLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.PLC_Port = comboPLC.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.PLC_COM.ToString(), "PLC_Port",p.PLC_Port, p.IniFilePath);
        }

        private void comboBarA_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_A_Port = comboBarA.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Scan_A_Port", p.Scan_A_Port, p.IniFilePath);
        }

        private void comboBarB_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_B_Port = comboBarB.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Scan_B_Port", p.Scan_B_Port, p.IniFilePath);
        }

        private void comboBarC_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_C_Port = comboBarC.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Scan_C_Port", p.Scan_C_Port, p.IniFilePath);
        }

        private void comboBarD_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Scan_D_Port = comboBarD.SelectedItem.ToString();
            IniFile.IniWriteValue(p.IniSection.Bar_COM.ToString(), "Scan_D_Port", p.Scan_D_Port, p.IniFilePath);
        }

        private void spPLC_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (spPLC.BytesToRead == 0)
                return;
            try
            {
                  string sReceive = spPLC.ReadExisting();
            spPLC.DiscardInBuffer();
            sReceive = sReceive.Trim();
            this.Invoke((EventHandler)(delegate
            {
                updateMessage(lstMessage, "PLC->PC:" + sReceive);
                saveLog(p.LogType.SysLog, "PLC->PC:" + sReceive);
                if (sReceive == "A")
                {
                    updateMessage(lstMessage, "PLC ready OK,start to open sanner to read barcode...");
                    saveLog (p.LogType.SysLog ,"PLC ready OK,start to open sanner to read barcode...");
                    txtBarA.Text = string.Empty;
                    txtBarB.Text = string.Empty;
                    txtBarC.Text = string.Empty;
                    txtBarD.Text = string.Empty;
                    p.BarA = string.Empty;
                    p.BarB = string.Empty;
                    p.BarC = string.Empty;
                    p.BarD = string.Empty;
                    updateMessage(lstMessage, "Open Scanner & start timeout counting...");
                    saveLog(p.LogType.SysLog, "Open Scanner & start timeout counting...");

                    if (p.Send_Command_Use_Hex)
                    {
                        sendHex(spBar_A, p.Open_Scan_Command);
                        sendHex(spBar_B, p.Open_Scan_Command);
                        sendHex(spBar_C, p.Open_Scan_Command);
                        sendHex(spBar_D, p.Open_Scan_Command);
                    }
                    else
                    {

                        if (p.Open_Add_Enter)
                        {
                            sendData(spBar_A, p.Open_Scan_Command + Other.Chr(13));
                            sendData(spBar_B, p.Open_Scan_Command + Other.Chr(13));
                            sendData(spBar_C, p.Open_Scan_Command + Other.Chr(13));
                            sendData(spBar_D, p.Open_Scan_Command + Other.Chr(13));
                        }
                        else
                        {
                            sendData(spBar_A, p.Open_Scan_Command);
                            sendData(spBar_B, p.Open_Scan_Command);
                            sendData(spBar_C, p.Open_Scan_Command);
                            sendData(spBar_D, p.Open_Scan_Command);
                        }
                    }



                    updateMessage(lstMessage, "PC->BarA:" + p.Open_Scan_Command);
                    updateMessage(lstMessage, "PC->BarB:" + p.Open_Scan_Command);
                    updateMessage(lstMessage, "PC->BarC:" + p.Open_Scan_Command);
                    updateMessage(lstMessage, "PC->BarD:" + p.Open_Scan_Command);
                    saveLog(p.LogType.SysLog, "PC->BarA:" + p.Open_Scan_Command);
                    saveLog(p.LogType.SysLog, "PC->BarB:" + p.Open_Scan_Command);
                    saveLog(p.LogType.SysLog, "PC->BarC:" + p.Open_Scan_Command);
                    saveLog(p.LogType.SysLog, "PC->BarD:" + p.Open_Scan_Command);

                    timerScanTimeout.Enabled = true;
                    timerScanTimeout.Start();

                }
            }));
            }
            catch (Exception)
            {
                
               // throw;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            closeSerialPort(spPLC);
            closeSerialPort(spBar_A);
            closeSerialPort(spBar_B);
            closeSerialPort(spBar_C);
            closeSerialPort(spBar_D);
            //
            this.btnRun.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnSet.Enabled = true;
            grbTestBarocdeScanner.Enabled = true;
            grbSerialPortSetting.Enabled = true;
        }

        private void spBar_A_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (spBar_A.BytesToRead == 0)
                return;
            try
            {
                string sReceive = spBar_A.ReadTo(Other.Chr(13));
                spBar_A.DiscardInBuffer();
                sReceive = sReceive.Trim();
                this.Invoke((EventHandler)(delegate
                {
                    updateMessage(lstMessage, "BarA->PC:" + sReceive);
                    saveLog(p.LogType.SysLog, "BarA->PC:" + sReceive);
                    updateMessage(lstMessage, "BarA:" + sReceive);
                    saveLog(p.LogType.SysLog, "BarA:" + sReceive);
                    updateMessage(lstBar, "BarA:" + sReceive);
                    p.BarA = sReceive.Trim().ToUpper();
                    txtBarA.Text = p.BarA;
                    saveLog(p.LogType.SNLog, "BarA:" + p.BarA);
                    //check A,B,C,D
                    if (_runing)
                    {
                        if (CheckAllBarComplete())
                        {
                            sendData(spPLC, "B");
                            updateMessage(lstMessage, "PC->PLC:B");
                            saveLog(p.LogType.SysLog, "PC->PLC:B");

                        }
                        else
                        {

                        }
                    }


                }));
            }
            catch (Exception)
            {
                
               // throw;
            }
            
       
        }

        private void spBar_B_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (spBar_B.BytesToRead == 0)
                return;
            try
            {
                 string sReceive = spBar_B.ReadTo(Other.Chr(13));
            spBar_B.DiscardInBuffer();
            sReceive = sReceive.Trim();
            this.Invoke((EventHandler)(delegate
            {
                updateMessage(lstMessage, "BarB->PC:" + sReceive);
                saveLog(p.LogType.SysLog, "BarB->PC:" + sReceive);
                updateMessage(lstMessage, "BarB:" + sReceive);
                saveLog(p.LogType.SysLog, "BarB:" + sReceive);
                updateMessage(lstBar, "BarB:" + sReceive);
                p.BarB = sReceive.Trim().ToUpper();
                txtBarB.Text = p.BarB;
                saveLog(p.LogType.SNLog, "BarB:" + p.BarB);
                //check A,B,C,D
                if (_runing)
                {
                    if (CheckAllBarComplete())
                    {
                        sendData(spPLC, "B");
                        updateMessage(lstMessage, "PC->PLC:B");
                        saveLog(p.LogType.SysLog, "PC->PLC:B");

                    }
                    else
                    {

                    }
                }

            }));
            }
            catch (Exception)
            {
                
                //throw;
            }
        }


        private void spBar_D_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (spBar_D.BytesToRead == 0)
                return;
            try
            {
                 string sReceive = spBar_D.ReadTo(Other.Chr(13));
            spBar_D.DiscardInBuffer();
            sReceive = sReceive.Trim();
            this.Invoke((EventHandler)(delegate
            {
                updateMessage(lstMessage, "BarD->PC:" + sReceive);
                saveLog(p.LogType.SysLog, "BarD->PC:" + sReceive);
                updateMessage(lstMessage, "BarD:" + sReceive);
                saveLog(p.LogType.SysLog, "BarD:" + sReceive);
                updateMessage(lstBar, "BarD:" + sReceive);
                p.BarD = sReceive.Trim().ToUpper();
                txtBarD.Text = p.BarD;
                saveLog(p.LogType.SNLog, "BarD:" + p.BarD);
                //check A,B,C,D
                if (_runing)
                {
                    if (CheckAllBarComplete())
                    {
                        sendData(spPLC, "B");
                        updateMessage(lstMessage, "PC->PLC:B");
                        saveLog(p.LogType.SysLog, "PC->PLC:B");

                    }
                    else
                    {

                    }
                }

            }));
            }
            catch (Exception)
            {
                
               // throw;
            }
        }




        #region CheckAllBarComplete

        private bool CheckAllBarComplete()
        {
            if (!string.IsNullOrEmpty(p.BarA) && !string.IsNullOrEmpty(p.BarB) && !string.IsNullOrEmpty(p.BarC) && !string.IsNullOrEmpty(p.BarD))
            {

                updateMessage(lstMessage, "4 barcodes are complete,save them to " + p.SNFile);

                if (File.Exists(p.SNFile))
                {
                    try
                    {
                        File.Delete(p.SNFile);
                    }
                    catch (Exception)
                    {

                    }
                }


                saveLog(p.LogType.SN, p.BarA);
                saveLog(p.LogType.SN, p.BarB);
                saveLog(p.LogType.SN, p.BarC);
                saveLog(p.LogType.SN, p.BarD);
                timerScanTimeout.Stop();
                return true;
            }
            else
            {
                
                return false;
            }

       
        }

        



        #endregion

        private void timerScanTimeout_Tick(object sender, EventArgs e)
        {
            timerScanTimeout.Stop();
            _CurrentTryCount++;
            if (_CurrentTryCount > _MaxTryCount)
            {

                updateMessage(lstMessage, "Current try to read barcode is bigger than max try times,reset plc...");
                saveLog(p.LogType.SysLog, "Current try to read barcode is bigger than max try times,reset plc...");
                sendData(spPLC, "C");
                updateMessage(lstMessage, "PC->PLC:C");
                saveLog(p.LogType.SysLog, "PC->PLC:C");
                _CurrentTryCount = 0;
                return;
            }
            else
            {
                updateMessage(lstMessage, "This is " + _CurrentTryCount + " time(s) read barcode timeout...");
                saveLog(p.LogType.SysLog, "This is " + _CurrentTryCount + " time(s) read barcode timeout...");

                if (!CheckAllBarComplete())
                {
                    updateMessage(lstMessage, "Then try to close sacnner & open it to read it again...");
                    saveLog(p.LogType.SysLog, "Then try to close sacnner & open it to read it again...");
                    if (string.IsNullOrEmpty(p.BarA))
                    {
                        //updateMessage(lstMessage, "Scanner A close...");
                        //saveLog(p.LogType.SysLog, "Scanner A close...");
                        //if (p.Close_Add_Enter)
                        //    sendData(spBar_A, p.Close_Scan_Command + Other.Chr(13));
                        //else
                        //    sendData(spBar_A, p.Close_Scan_Command);
                        //updateMessage(lstMessage, "PC->BarA:" + p.Close_Scan_Command);
                        //saveLog(p.LogType.SysLog, "PC->BarA:" + p.Close_Scan_Command);
                        //Delay(500);
                        //if (p.Open_Add_Enter)
                        //    sendData(spBar_A, p.Open_Scan_Command + Other.Chr(13));
                        //else
                        //    sendData(spBar_A, p.Open_Scan_Command);
                        //updateMessage(lstMessage, "PC->BarA:" + p.Open_Scan_Command);
                        //saveLog(p.LogType.SysLog, "PC->BarA:" + p.Open_Scan_Command);
                        ScanRetryReadBarcode(spBar_A, "Scanner A", "PC->BarA:");
                    }
                    if (string.IsNullOrEmpty(p.BarB))
                        ScanRetryReadBarcode(spBar_B, "Scanner B", "PC->BarB:");
                    if (string.IsNullOrEmpty(p.BarC))
                        ScanRetryReadBarcode(spBar_C, "Scanner C", "PC->BarC:");
                    if (string.IsNullOrEmpty(p.BarD))
                        ScanRetryReadBarcode(spBar_D, "Scanner D", "PC->BarD:");
                }
                timerScanTimeout.Start();
            }

            
        }



        #region ScanRetryReadBarcode

        private void ScanRetryReadBarcode(SerialPort sp,string str1,string str2)
        {
            updateMessage(lstMessage, str1 +" close...");
            saveLog(p.LogType.SysLog, str1 + " close...");

            if (p.Send_Command_Use_Hex)
            {
                sendHex(sp, p.Close_Scan_Command);
            }
            else
            {
                if (p.Close_Add_Enter)
                    sendData(sp, p.Close_Scan_Command + Other.Chr(13));
                else
                    sendData(sp, p.Close_Scan_Command);
            }
            updateMessage(lstMessage, str2  + p.Close_Scan_Command);
            saveLog(p.LogType.SysLog, str2  + p.Close_Scan_Command);
            Delay(500);

            if (p.Send_Command_Use_Hex)
            {
                sendHex(sp, p.Open_Scan_Command);
            }
            else
            {
                if (p.Open_Add_Enter)
                    sendData(sp, p.Open_Scan_Command + Other.Chr(13));
                else
                    sendData(sp, p.Open_Scan_Command);
            }

           
            updateMessage(lstMessage, str2  + p.Open_Scan_Command);
            saveLog(p.LogType.SysLog, str2 + p.Open_Scan_Command);
        }

        #endregion

        #region 延時子程式

        /// <summary>
        /// 延時子程序
        /// </summary>
        /// <param name="interval">延時的時間，單位毫秒</param>
        private void Delay(double interval)
        {
            DateTime time = DateTime.Now;
            double span = interval * 10000;
            while (DateTime.Now.Ticks - time.Ticks < span)
            {
                Application.DoEvents();
            }

        }

        #endregion

        private void spBar_C_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            if (spBar_C.BytesToRead == 0)
                return;
            try
            {
                string sReceive = spBar_C.ReadTo(Other.Chr(13));
                spBar_C.DiscardInBuffer();
                sReceive = sReceive.Trim();
                this.Invoke((EventHandler)(delegate
                {
                    updateMessage(lstMessage, "BarC->PC:" + sReceive);
                    saveLog(p.LogType.SysLog, "BarC->PC:" + sReceive);
                    updateMessage(lstMessage, "BarC:" + sReceive);
                    saveLog(p.LogType.SysLog, "BarC:" + sReceive);
                    updateMessage(lstBar, "BarC:" + sReceive);
                    p.BarC = sReceive.Trim().ToUpper();
                    txtBarC.Text = p.BarC;
                    saveLog(p.LogType.SNLog, "BarC:" + p.BarC);
                    //check A,B,C,D
                    if (_runing)
                    {
                        if (CheckAllBarComplete())
                        {
                            sendData(spPLC, "B");
                            updateMessage(lstMessage, "PC->PLC:B");
                            saveLog(p.LogType.SysLog, "PC->PLC:B");

                        }
                        else
                        {

                        }
                    }

                }));
            }
            catch (Exception)
            {

                //  throw;
            }
        
        }


    }
}
