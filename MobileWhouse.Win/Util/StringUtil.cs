using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using MobileWhouse.Log;

namespace MobileWhouse.Util
{
    public class StringUtil
    {
        public static decimal ToDecimal(object value)
        {
            if (value == null) return 0M;

            if (value == DBNull.Value) return 0M;

            return ToDecimal(value.ToString());
        }

        public static decimal ToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0M;

            value = value.Replace(",", ".");

            value = Regex.Replace(value, @"[^0-9.-]", string.Empty, RegexOptions.Compiled);

            return Convert.ToDecimal(value, CultureInfo.GetCultureInfo("en-US"));
        }

        public static int ToInteger(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;

            value = Regex.Replace(value, @"[^0-9-]", string.Empty, RegexOptions.Compiled);

            return Convert.ToInt32(value, CultureInfo.GetCultureInfo("en-US"));
        }

        public static DateTime ToDatetime(string value)
        {
            if (string.IsNullOrEmpty(value)) return DateTime.MinValue;

            try
            {
                return Convert.ToDateTime(value, CultureInfo.GetCultureInfo("tr-TR"));
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }

            return DateTime.MinValue;
        }

        public static int ToInteger(object value)
        {
            if (value == null) return 0;

            if (value == DBNull.Value) return 0;

            return ToInteger(value.ToString());
        }

        internal static string UTF8ByteArrayToString(byte[] _arrBytes)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(_arrBytes, 1, _arrBytes.Length - 1);
        }

        internal static string MD5Uret(string _strSifre)
        {
            MD5 md = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md.ComputeHash(Encoding.UTF8.GetBytes(_strSifre))).Replace("-", "").ToUpper();
        }
    }
}
