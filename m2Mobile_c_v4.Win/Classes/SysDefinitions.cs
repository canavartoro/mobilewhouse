using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Resources;
using System.Threading;
using System.Xml;
using m2Mobile_c_v4.Resources.Languages;
using System.IO;
using System.Text.RegularExpressions;

namespace m2Mobile_c_v4.Classes
{
   

    class SysDefinitions
    {
        public static string _CurrentLanguage = "";
        public static int _exmenuid = 1;
        public static bool _firstLoad;
        public static int _menuid = 1;
        public static int _SysUserId = 0;
        public static ResourceManager ResMan = Tr_TR.ResourceManager;

        public static void CursorState(string _State)
        {
            if (_State == "Wait")
            {
                Cursor.Current = Cursors.WaitCursor;
                Cursor.Show();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                Cursor.Hide();
            }
        }

        public static void FirstLoad()
        {
            _CurrentLanguage = GetXmlData("MainParam", "CurrentLanguage");
            string str3 = _CurrentLanguage;
            if (str3 != null)
            {
                if (!(str3 == "Turkish"))
                {
                    if (str3 == "English")
                    {
                        ResMan = en_US.ResourceManager;
                    }
                }
                else
                {
                    ResMan = Tr_TR.ResourceManager;
                }
            }
            FileInfo info = new FileInfo(GetApplicationDirectory() + @"\TermMenu.xml");
            _firstLoad = true;
            info = null;
        }

        public static string GetApplicationDirectory()
        {
            try
            {
                string full_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
                if (full_path.StartsWith("file"))
                {
                    var xDevice = new Regex("[A-Z]");
                    string xPath = full_path.Replace("file:\\", "").Substring(0, 1);
                    if (xDevice.IsMatch(xPath))
                        full_path = full_path.Replace("file:\\", "");
                }
                return full_path;
            }
            catch (Exception exc)
            {
                Err(string.Concat("Uygulama yolu alınırken hata:", exc.Message));
                return "";
            }
        }

        public static Form GetFormByName(string frmname)
        {
            Type type = (from a in Assembly.GetExecutingAssembly().GetTypes()
                where (a.BaseType == typeof(Form)) && (a.Name == frmname)
                select a).FirstOrDefault<Type>();
            if (type == null)
            {
                return null;
            }
            return (Form) Activator.CreateInstance(type);
        }

        public static string GetXmlData(string _Table, string _Node)
        {
            if (File.Exists(GetApplicationDirectory().ToString() + @"\SysDef.xml"))
            {
                return (from data in XElement.Load(GetApplicationDirectory().ToString() + @"\SysDef.xml").Descendants(_Table) select new { _Value = data.Element(_Node).Value }).FirstOrDefault()._Value.ToString();
            }
            return string.Empty;
        }

        public static string SecurtyForInjection(string Deger)
        {
            Deger = Deger.Replace(" , ", "");
            Deger = Deger.Replace(" / ", "");
            Deger = Deger.Replace(@" \ ", "");
            Deger = Deger.Replace(" ? ", "");
            Deger = Deger.Replace(" * ", "");
            Deger = Deger.Replace(" ‘ ", "");
            Deger = Deger.Replace(" OR ", "");
            Deger = Deger.Replace(" AND ", "");
            Deger = Deger.Replace(" % ", "");
            Deger = Deger.Replace(" & ", "");
            Deger = Deger.Replace(" > ", "");
            Deger = Deger.Replace(" = ", "");
            Deger = Deger.Replace(" ! ", "");
            Deger = Deger.Replace(" – ", "");
            Deger = Deger.Replace(" # ", "");
            Deger = Deger.Replace(" like ", "");
            Deger = Deger.Replace(" drop ", "");
            Deger = Deger.Replace(" create ", "");
            Deger = Deger.Replace(" modify ", "");
            Deger = Deger.Replace(" rename ", "");
            Deger = Deger.Replace(" alter ", "");
            Deger = Deger.Replace(" cast ", "");
            Deger = Deger.Replace(" join ", "");
            Deger = Deger.Replace(" union ", "");
            Deger = Deger.Replace(" where ", "");
            Deger = Deger.Replace(" insert ", "");
            Deger = Deger.Replace(" delete ", "");
            Deger = Deger.Replace(" update ", "");
            return Deger;
        }

        [DllImport("coredll.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME time);
        public static void SetSysTime(DateTime Dt)
        {
            SYSTEMTIME systemtime;
            DateTime time = Dt;
            systemtime.year = (short) time.Year;
            systemtime.month = (short) time.Month;
            systemtime.dayOfWeek = (short) time.DayOfWeek;
            systemtime.day = (short) time.Day;
            systemtime.hour = (short) time.Hour;
            systemtime.minute = (short) time.Minute;
            systemtime.second = (short) time.Second;
            systemtime.milliseconds = (short) time.Millisecond;
            SetLocalTime(ref systemtime);
        }

        public static void SetXmlData(string _Table, string _Node, string _Value)
        {
            XDocument document = XDocument.Load(GetApplicationDirectory().ToString() + @"\SysDef.xml");
            IEnumerable<XElement> enumerable = from element in document.Descendants(_Table) select element;
            foreach (XElement element in enumerable)
            {
                element.SetElementValue(_Node, _Value);
            }
            document.Save(GetApplicationDirectory().ToString() + @"\SysDef.xml");
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }

        public static void Err(string msg)
        {
            Cursor.Current = Cursors.Default;
            Cursor.Show();
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        public static void Warn(string msg)
        {
            Cursor.Current = Cursors.Default;
            Cursor.Show();
            MessageBox.Show(msg, "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        public static void Info(string msg)
        {
            Cursor.Current = Cursors.Default;
            Cursor.Show();
            MessageBox.Show(msg, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public static bool Question(string msg)
        {
            Cursor.Current = Cursors.Default;
            Cursor.Show();
            return MessageBox.Show(msg, "Dikkat", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK;
        }
    }
}

