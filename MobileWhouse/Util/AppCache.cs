using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MobileWhouse.Log;
using System.Collections;

namespace MobileWhouse.Util
{
    public class AppCache
    {
        const string CACHEFILENAME = "appcache.ini";

        public static int ReadCacheInt(string key, int dvalue)
        {
            string sval = ReadCache(key, dvalue.ToString());
            return StringUtil.ToInteger(sval);
        }

        public static string ReadCache(string key, string dvalue)
        {
            try
            {
                if (File.Exists(string.Concat(Util.Utility.AppPath, "\\", CACHEFILENAME)))
                {
                    List<string> list = new List<string>();
                    using (StreamReader reader = new StreamReader(string.Concat(Util.Utility.AppPath, "\\", CACHEFILENAME), Encoding.GetEncoding("Windows-1254"))) //Encoding.GetEncoding(1252)))
                    {
                        string str;
                        while ((str = reader.ReadLine()) != null)
                        {
                            if (str.IndexOf("=") != -1)
                            {
                                string[] strArray = str.Split(new char[] { '=' });
                                if (((strArray != null) && (strArray.Length > 0)) &&
                                    strArray[0].Equals(key, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    return strArray[1].Trim();
                                }
                            }
                            list.Add(str);
                        }
                        reader.Close();
                    }
                    list.Add(string.Concat(key, "=", dvalue));
                    WriteAll(list);
                }
                else
                {
                    WriteAll(new List<string>(new string[] { string.Concat(key, "=", dvalue) }));
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            return dvalue;
        }

        private static void WriteAll(List<string> lines)
        {
            using (FileStream stream = new FileStream(string.Concat(Util.Utility.AppPath, "\\", CACHEFILENAME), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("Windows-1254")))
                {
                    foreach (string strln in lines)
                    {
                        writer.WriteLine(strln);
                    }
                    writer.Flush();
                }
            }
        }

        public static void WriteCache(string key, string value)
        {
            try
            {
                if (File.Exists(string.Concat(Util.Utility.AppPath, "\\", CACHEFILENAME)))
                {
                    List<string> list = new List<string>();
                    using (StreamReader reader = new StreamReader(string.Concat(Util.Utility.AppPath, "\\", CACHEFILENAME), Encoding.GetEncoding("Windows-1254")))
                    {
                        bool newrow = true;
                        string str;
                        while ((str = reader.ReadLine()) != null)
                        {
                            if (str.IndexOf("=") != -1)
                            {
                                string[] strArray = str.Split(new char[] { '=' });
                                if (((strArray != null) && (strArray.Length > 0)) && strArray[0].Equals(key, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    newrow = false;
                                    list.Add(string.Concat(key, "=", value));
                                }
                                else
                                {
                                    list.Add(str);
                                }
                            }
                        }
                        reader.Close();
                        if (newrow) list.Add(string.Concat(key, "=", value));
                    }
                    WriteAll(list);
                }
                else
                {
                    WriteAll(new List<string>(new string[] { string.Concat(key, "=", value) }));
                    return;
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }
    }
}
