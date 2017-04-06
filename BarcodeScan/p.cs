using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ;

namespace BarcodeScan
{
    public static  class p
    {
        //
        public static string AppFolder = Application.StartupPath + @"\BarcodeScan";
        public static string SNFile = AppFolder + @"\SN.txt"; //存放4个条码的文本文件
        public static string SysLogFolder = AppFolder + @"\SysLog"; //存放所有信息的文件夹
        public static string SNLogFolder = AppFolder + @"\SNLog"; //存放历史条码的文件夹



    }
}
