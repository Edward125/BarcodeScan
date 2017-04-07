using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ;
using System.IO.Ports;
using Edward;

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



       public enum IniSection
        {
            SysConfig,
            PLC_COM,
            Bar_COM,
        }


        /// <summary>
        /// create ini file,write the default value
        /// </summary>
        /// <param name="inifilepath">ini path</param>
        public static void createIniFile(string inifilepath)
        {
            IniFile.CreateIniFile(inifilepath);
            //
            IniFile.IniWriteValue(IniSection.PLC_COM .ToString (), "PLC_Port", PLC_Port);
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Baud_Rate", PLC_Baud_Rate);
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Data_Bits", PLC_Data_Bits.ToString());
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Stop_Bits", PLC_Stop_Bits.ToString());
            IniFile.IniWriteValue(IniSection.PLC_COM.ToString(), "PLC_Parity", PLC_Parity.ToString());
            //
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_A_Port", Scan_A_Port);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_B_Port", Scan_B_Port);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_C_Port", Scan_C_Port);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_D_Port", Scan_D_Port);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Baud_Rate", Scan_Baud_Rate);
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Data_Bits", Scan_Data_Bits.ToString());
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Stop_Bits", Scan_Stop_Bits.ToString());
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Scan_Parity", Scan_Parity.ToString());
            //
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Open_Add_Enter", Open_Add_Enter.ToString());
            IniFile.IniWriteValue(IniSection.Bar_COM.ToString(), "Close_Add_Enter", Close_Add_Enter.ToString());
        }



   


    }

}
