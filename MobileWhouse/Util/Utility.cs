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
                //return AppDomain.CurrentDomain.FriendlyName.Equals("DefaultDomain");
                //return Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1;
                return System.Diagnostics.Process.GetCurrentProcess().ToString().IndexOf("devenv", StringComparison.OrdinalIgnoreCase) > -1;
#if !PocketPC
                if (System.ComponentModel.LicenseUsageMode.Designtime == System.ComponentModel.LicenseManager.UsageMode) return false;
#endif

            }
        }

        public static bool IsWindowsCE
        {
            get { return Environment.OSVersion.Platform == PlatformID.WinCE; }
        }

        public static object Clone(object origin)
        {
            if (object.ReferenceEquals(origin, null)) return null;

            Type t = origin.GetType();
            PropertyInfo[] properties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            object destination = Activator.CreateInstance(t);

            if (destination == null)
                throw new ArgumentNullException("destination", "Destination object must first be instantiated.");

            if (origin == null)
                throw new ArgumentNullException("origin", "Destination object must first be instantiated.");

            foreach (PropertyInfo destinationProperty in properties)
            {
                if (destinationProperty.CanWrite)
                {
                    PropertyInfo p = t.GetProperty(destinationProperty.Name);
                    if (p != null)
                    {
                        destinationProperty.SetValue(destination, p.GetValue(origin, null), null);
                    }
                }
            }

            return destination;
        }
    }
}
