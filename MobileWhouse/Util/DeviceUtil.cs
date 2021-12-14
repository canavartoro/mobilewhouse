using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using OpenNETCF.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Globalization;
using System.IO;

namespace MobileWhouse.Util
{
    public class DeviceUtil
    {
        internal static string IpGetir()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
        }

        internal static bool IpMacKur()
        {

            string _strIP = "0.0.0.0";
            string _strMAC = "00:00:00:00:00:00";
            INetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            if (allNetworkInterfaces.Length > 0)
            {
                try
                {
                    INetworkInterface interface2;
                    int num;
                    for (num = 0; num < allNetworkInterfaces.Length; num++)
                    {
                        interface2 = allNetworkInterfaces[num];
                        if ((interface2.GetType().Name == "WirelessNetworkInterface") && ((interface2.InterfaceOperationalStatus == InterfaceOperationalStatus.Operational) || (interface2.InterfaceOperationalStatus == InterfaceOperationalStatus.Connected)))
                        {
                            flag = true;
                            _strIP = interface2.CurrentIpAddress.ToString();
                            _strMAC = interface2.GetPhysicalAddress().ToString();
                            break;
                        }
                    }
                    if (!flag)
                    {
                        for (num = 0; num < allNetworkInterfaces.Length; num++)
                        {
                            interface2 = allNetworkInterfaces[num];
                            if ((interface2.InterfaceOperationalStatus == InterfaceOperationalStatus.Operational) || (interface2.InterfaceOperationalStatus == InterfaceOperationalStatus.Connected))
                            {
                                flag2 = true;
                                _strIP = interface2.CurrentIpAddress.ToString();
                                _strMAC = interface2.GetPhysicalAddress().ToString();
                                break;
                            }
                        }
                        if (!flag2)
                        {
                            for (num = 0; num < allNetworkInterfaces.Length; num++)
                            {
                                interface2 = allNetworkInterfaces[num];
                                if (interface2.InterfaceOperationalStatus == InterfaceOperationalStatus.Unreachable)
                                {
                                    flag3 = true;
                                    _strIP = interface2.CurrentIpAddress.ToString();
                                    _strMAC = interface2.GetPhysicalAddress().ToString();
                                    break;
                                }
                            }
                            if (!flag3)
                            {
                                interface2 = allNetworkInterfaces[0];
                                if (interface2.Name == "Serial over DMA")
                                {
                                    flag4 = true;
                                    _strIP = interface2.CurrentIpAddress.ToString();
                                    _strMAC = "00:EM:UL:AT:OR:--";
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return (((flag || flag2) || flag3) || flag4);
        }

        internal static string GetDeviceId()
        {
            byte[] uuid = new byte[16];
            bool useFix = false;

            uint len = 256;
            uint cb = 0; //For some reason this is very important
            byte[] buffer = new byte[256];
            buffer[0] = 0;
            buffer[1] = 1;
            uint ret;

            try
            {
                ret = Win32.KernelIoControl(0x1010054, //Win32API.IOCTL_HAL_GET_DEVICEID
                    IntPtr.Zero, 0, buffer, len, cb);

                Int32 dwPresetIDOffset = BitConverter.ToInt32(buffer, 4);
                Int32 dwPlatformIDOffset = BitConverter.ToInt32(buffer, 0xc);
                Int32 dwPlatformIDSize = BitConverter.ToInt32(buffer, 0x10);

                for (int i = 0; i < 10; i++)
                {
                    uuid[i] = buffer[dwPresetIDOffset + i];
                }

                //  Our ID is 16 bytes and we already have 10 of them...
                if (useFix)
                {
                    int diff = Math.Max(0, dwPlatformIDSize - 6);

                    dwPlatformIDOffset += diff;
                }

                dwPlatformIDSize = Math.Min(dwPlatformIDSize, 6);

                for (int i = dwPlatformIDOffset; i < dwPlatformIDOffset + dwPlatformIDSize; i++)
                {
                    uuid[(i - dwPlatformIDOffset) + 10] = buffer[i];
                }
            }
            catch (Exception exc)
            {
                Log.Logger.E(exc);
                return "";
            }

            string result = null;
            if (uuid != null)
            {
                string format0 = "{0:X2}{1:X2}-";
                string format1 = "{0:X2}{1:X2}";

                StringBuilder sb = new StringBuilder();

                sb.Append(string.Format(format0, uuid[0], uuid[1]));
                sb.Append(string.Format(format0, uuid[2], uuid[3]));
                sb.Append(string.Format(format0, uuid[4], uuid[5]));
                sb.Append(string.Format(format1, uuid[6], uuid[7]));
                sb.Append("\n");
                sb.Append(string.Format(format0, uuid[8], uuid[9]));
                sb.Append(string.Format(format0, uuid[10], uuid[11]));
                sb.Append(string.Format(format0, uuid[12], uuid[13]));
                sb.Append(string.Format(format1, uuid[14], uuid[15]));

                result = sb.ToString();
            }
            return result;
        }

        internal static void SetDatetime(string datetime)
        {
            try
            {
                Win32.SYSTEMTIME systemtime;
                systemtime.wYear = Convert.ToUInt16(datetime.Substring(6, 4));
                systemtime.wMonth = Convert.ToUInt16(datetime.Substring(3, 2));
                systemtime.wDayOfWeek = 1;
                systemtime.wDay = Convert.ToUInt16(datetime.Substring(0, 2));
                systemtime.wHour = Convert.ToUInt16(datetime.Substring(11, 2));
                systemtime.wMinute = Convert.ToUInt16(datetime.Substring(14, 2));
                systemtime.wSecond = Convert.ToUInt16(datetime.Substring(0x11, 2));
                systemtime.wMilliseconds = 0;
                Win32.SetLocalTime(ref systemtime);
            }
            catch (Exception)
            {
            }
        }

        internal static string DecimalSeparator
        {
            get
            {
                return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            }
        }

        internal static void CreateShurtcut()
        {
            #if PocketPC
            try
            {
                string str = "\"" + Utility.AppPath + @"\MobileWhouse.exe" + "\"";
                string str2 = "UYM.lnk";
                FileStream stream = new FileStream(@"\Windows\Programs\" + str2, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(str.Length.ToString() + "#" + str);
                writer.Close();
                stream.Close();
                writer = null;
                stream = null;
            }
            catch (Exception)
            {
            }
#endif
        }
        internal static void SetFileAttributesReadonly(string filename)
        {
            try
            {
                Win32.SetFileAttributes(filename, 1);
            }
            catch (Exception)
            {
            }
        }
    }

    internal class Win32
    {
        [DllImport("Coredll")]
        public static extern UInt32 KernelIoControl(UInt32 dwIoControlCode, IntPtr lpInBuf, UInt32 nInBufSize, byte[] buf, UInt32 nOutBufSize, [In, Out] uint lpBytesReturned);

        [DllImport("coredll.dll")]
        internal static extern bool SetLocalTime(ref SYSTEMTIME _objST);

        [DllImport("coredll.dll")]
        internal static extern bool SetFileAttributes(string lpFileName, uint dwFileAttributes);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }
    }
}
