using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using MobileWhouse.Log;

namespace MobileWhouse.Util
{
    public class Utility
    {
        public static string AppPath
        {
            get
            {
                try
                {
                    string _Path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                    if (_Path.StartsWith("file"))
                    {
                        var xDevice = new Regex("[A-Z]");
                        string xPath = _Path.Replace("file:\\", "").Substring(0, 1);
                        if (xDevice.IsMatch(xPath))
                            _Path = _Path.Replace("file:\\", "");
                    }
                    return _Path;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static bool IsDesignMode
        {
            get
            {
                return AppDomain.CurrentDomain.FriendlyName.Equals("DefaultDomain");
                //return Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1;
                //return System.Diagnostics.Process.GetCurrentProcess().ToString().IndexOf("devenv", StringComparison.OrdinalIgnoreCase) > -1;
#if !PocketPC
                if (System.ComponentModel.LicenseUsageMode.Designtime == System.ComponentModel.LicenseManager.UsageMode) return false;
#endif
                var procName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
                Logger.I(procName);
                return "devenv" != procName //WinForms app in VS IDE
                    && "xdesproc" != procName //WPF app in VS IDE/Blend
                    && "blend" != procName //WinForms app in Blend
                    //other IDE's process name if you detected by log from above
                    ;
            }
        }

        public static bool IsWindowsCE
        {
            get { return Environment.OSVersion.Platform == PlatformID.WinCE; }
        }


    }
}
