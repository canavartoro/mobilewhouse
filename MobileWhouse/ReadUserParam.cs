using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse
{
    public class ReadUserParam
    {
        Dictionary<KeyParam, ParamValue> KeyValues;

        public ReadUserParam(string prm)
        {
            var sdMain = prm.Split('\n');
            KeyValues = new Dictionary<KeyParam, ParamValue>();
            foreach (var ss in sdMain)
            {
                if (string.IsNullOrEmpty(ss)) continue;

                var sdLine = ss.Split(';');
                if (sdLine.Length < 3) continue;

                var pageCode = sdLine[0].Trim().ToUpper();
                var key = sdLine[1].Trim().ToUpper();
                var value = sdLine[2];
                var kk = new KeyParam { KeyCode = key, PageCode = pageCode };
                KeyValues[kk] = new ParamValue(value);
            }
        }


        public ParamValue this[string page, string key]
        {
            get
            {
                var kk = new KeyParam { KeyCode = key.Trim().ToUpper(), PageCode = page.Trim().ToUpper() };
                if (!KeyValues.ContainsKey(kk)) return new ParamValue("");
                return KeyValues[kk];
            }
        }

        struct KeyParam
        {
            public string PageCode;
            public string KeyCode;

            public override int GetHashCode()
            {
                return (PageCode + "_" + KeyCode).GetHashCode();
            }
        }

        public class ParamValue
        {
            string _value = "";
            public ParamValue(string value)
            {
                _value = value;
            }

            public bool ToBool()
            {
                bool result = false;
                try
                {
                    result = bool.Parse(_value);
                }
                catch
                {

                }
                return result;
            }

            public int ToInt()
            {
                int result = 0;
                try
                {
                    result = Int32.Parse(_value);
                }
                catch
                {

                }
                return result;
            }

            public string ToSt()
            {
                string result = string.Empty;
                try
                {
                    result = _value;
                }
                catch
                {

                }
                return result;
            }


        }

    }
}
