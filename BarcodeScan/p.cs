using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ;
using System.IO.Ports;
using Edward;
using System.IO;
using System.Text.RegularExpressions;

namespace BarcodeScan
{
    public static class p
    {
        //
        public static string AppFolder = Application.StartupPath + @"\BarcodeScan";
        public static string SNFile = AppFolder + @"\SN.txt"; //存放4个条码的文本文件
        public static string SysLogFolder = AppFolder + @"\SysLog"; //存放所有信息的文件夹
        public static string SNLogFolder = AppFolder + @"\SNLog"; //存放历史条码的文件夹
        public static string SysLogFile = SysLogFolder + @"\Sys_" + DateTime.Now.ToString("yyyyMMdd") + @".log";
        public static string SNLogFile = SNLogFolder + @"\SN_" + DateTime.Now.ToString("yyyyMMdd") + @".log";
        //
        public static string IniFilePath = AppFolder + @"\SysConfig.ini";
        // PLC
        public static string PLC_Port = string.Empty;
        public static string PLC_Baud_Rate = "9600";
        public static string PLC_Data_Bits = "8";
        public static StopBits PLC_Stop_Bits = StopBits.One;
        public static Parity PLC_Parity = Parity.None;
        //Scan
        public static string Scan_A_Port = string.Empty;
        public static string Scan_B_Port = string.Empty;
        public static string Scan_C_Port = string.Empty;
        public static string Scan_D_Port = string.Empty;
        public static string Scan_Baud_Rate = "9600";
        public static string Scan_Data_Bits = "8";
        public static StopBits Scan_Stop_Bits = StopBits.One;
        public static Parity Scan_Parity = Parity.None;
        //
        public static string Open_Scan_Command = string.Empty;
        public static string Close_Scan_Command = string.Empty;
        public static bool Open_Add_Enter = true;
        public static bool Close_Add_Enter = true;
        public static bool Send_Command_Use_Hex = true;
        //
        public static string BarA = string.Empty;
        public static string BarB = string.Empty;
        public static string BarC = string.Empty;
        public static string BarD = string.Empty;



       public  enum IniSection
        {
            SysConfig,
            PLC_COM,
            Bar_COM,
        }



       public enum LogType
       {
           SysLog,
           SNLog,
           SN
       }



        /// <summary>
        /// create ini file,write the default value
        /// </summary>
        /// <param name="inifilepath">ini path</param>
        public static void createIniFile(string inifilepath)
        {
            IniFile.CreateIniFile(inifilepath);
            //IniFile.IniFilePath = inifilepath;
            //
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Port", PLC_Port, inifilepath);
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Baud_Rate", PLC_Baud_Rate, inifilepath);
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Data_Bits", PLC_Data_Bits.ToString(), inifilepath);
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Stop_Bits", PLC_Stop_Bits.ToString(), inifilepath);
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Parity", PLC_Parity.ToString(), inifilepath);
            //
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_A_Port", Scan_A_Port, inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_B_Port", Scan_B_Port, inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_C_Port", Scan_C_Port, inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_D_Port", Scan_D_Port, inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Baud_Rate", Scan_Baud_Rate, inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Data_Bits", Scan_Data_Bits.ToString(), inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Stop_Bits", Scan_Stop_Bits.ToString(), inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Parity", Scan_Parity.ToString(), inifilepath);
            //
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Open_Scan_Command", Open_Scan_Command, inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Close_Scan_Command", Close_Scan_Command, inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Open_Add_Enter", Open_Add_Enter.ToString(), inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Close_Add_Enter", Close_Add_Enter.ToString(), inifilepath);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Send_Command_Use_Hex", Send_Command_Use_Hex .ToString (), inifilepath);
        }


        public static void readConfigValue(string inifilepath)
        {

            //
            PLC_Port = IniFile.IniReadValue(IniSection.PLC_COM.ToString(), "PLC_Port", inifilepath);
            string _PLC_Baud_Rate = IniFile.IniReadValue(IniSection.PLC_COM.ToString(), "PLC_Baud_Rate", inifilepath);
            if (!string.IsNullOrEmpty(_PLC_Baud_Rate))
                PLC_Baud_Rate = _PLC_Baud_Rate;
            string _PLC_Data_Bits = IniFile.IniReadValue(IniSection.PLC_COM.ToString(), "PLC_Data_Bits", inifilepath);
            if (!string.IsNullOrEmpty(_PLC_Data_Bits))
                PLC_Data_Bits = _PLC_Data_Bits;
            string _PLC_Stop_Bits = IniFile.IniReadValue(IniSection.PLC_COM.ToString(), "PLC_Stop_Bits", inifilepath);
            if (!string.IsNullOrEmpty(_PLC_Stop_Bits))
                PLC_Stop_Bits = (StopBits )Enum.Parse (typeof (StopBits ), _PLC_Stop_Bits);
            string _PLC_Parity = IniFile.IniReadValue(IniSection.PLC_COM.ToString(), "PLC_Parity", inifilepath);
            if (!string.IsNullOrEmpty(_PLC_Parity))
                PLC_Parity = (Parity)Enum.Parse(typeof(Parity), _PLC_Parity);

            //
            Scan_A_Port = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_A_Port", inifilepath);
            Scan_B_Port = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_B_Port", inifilepath);
            Scan_C_Port = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_C_Port", inifilepath);
            Scan_D_Port = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_D_Port", inifilepath);

            string _Scan_Baud_Rate = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_Baud_Rate", inifilepath);
            if (!string.IsNullOrEmpty(_Scan_Baud_Rate))
                Scan_Baud_Rate = _Scan_Baud_Rate;
            string _Scan_Data_Bits = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_Data_Bits", inifilepath);
            if (!string.IsNullOrEmpty(_Scan_Data_Bits))
                PLC_Data_Bits = _Scan_Data_Bits;
            string _Scan_Stop_Bits = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_Stop_Bits", inifilepath);
            if (!string.IsNullOrEmpty(_Scan_Stop_Bits))
                PLC_Stop_Bits = (StopBits)Enum.Parse(typeof(StopBits), _Scan_Stop_Bits);
            string _Scan_Parity = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Scan_Parity", inifilepath);
            if (!string.IsNullOrEmpty(_Scan_Parity))
                PLC_Parity = (Parity)Enum.Parse(typeof(Parity), _Scan_Parity);

            //
            Open_Scan_Command = IniFile.IniReadValue(IniSection.Bar_COM.ToString (), "Open_Scan_Command", inifilepath);
            Close_Scan_Command = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Close_Scan_Command", inifilepath);
            Open_Add_Enter = Convert.ToBoolean(IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Open_Add_Enter", inifilepath));
            Close_Add_Enter  = Convert.ToBoolean(IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Close_Add_Enter", inifilepath));
            //
            string _Send_Command_Use_Hex = IniFile.IniReadValue(IniSection.Bar_COM.ToString(), "Send_Command_Use_Hex", inifilepath);
            if (string.IsNullOrEmpty(_Send_Command_Use_Hex))
            {
                IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Send_Command_Use_Hex", Send_Command_Use_Hex.ToString(), inifilepath);
            }
            else
                Send_Command_Use_Hex = Convert.ToBoolean(_Send_Command_Use_Hex);
             
            
        }


        /// <summary>
        /// check the string if it is hex
        /// </summary>
        /// <param name="str">string </param>
        /// <returns>Hex,return true;not hex,return false</returns>
        public static  bool IsHex(string str)
        {
            return Regex.IsMatch(str, @"^[0-9,A-D,a-d]*$");
        }

    }

}
