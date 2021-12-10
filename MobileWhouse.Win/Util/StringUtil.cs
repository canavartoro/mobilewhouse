using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

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

            value = Regex.Replace(value, @"[^0-9.-]", string.Empty, RegexOptions.Compiled);

            return Convert.ToDecimal(value, CultureInfo.GetCultureInfo("en-US"));
        }

        public static int ToInteger(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;

            value = Regex.Replace(value, @"[^0-9-]", string.Empty, RegexOptions.Compiled);

            return Convert.ToInt32(value, CultureInfo.GetCultureInfo("en-US"));
        }

        public static int ToInteger(object value)
        {
            if (value == null) return 0;

            if (value == DBNull.Value) return 0;

            return ToInteger(value.ToString());
        }
    }
}
