using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using MobileWhouse.Log;

namespace MobileWhouse.Util
{
    [XmlRoot("AYARLAR")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public class AppConfig
    {
        public AppConfig() { }

        private static AppConfig _default = null;
        public static AppConfig Default
        {
            get 
            {
                if (_default == null)
                {
                    _default = new AppConfig();
                    _default.Load();
                }
                return _default;
            }
        }

        private bool _rememberMe = false;
        [XmlElement("HATIRLA")]
        public bool RememberMe
        {
            get { return _rememberMe; }
            set { _rememberMe = value; }
        }

        private string _lastUsername = string.Empty;
        [XmlElement("KULLANICI")]
        public string LastUsername
        {
            get { return _lastUsername; }
            set { _lastUsername = value; }
        }

        private string _webServiceUrl = "http://10.0.0.250:400/";
        [XmlElement("WEBSERVIS")]
        public string WebServiceUrl
        {
            get { return _webServiceUrl; }
            set { _webServiceUrl = value; }
        }

        private string _appServerUrl = "http://10.0.0.250:2002/";
        [XmlElement("APPSERVIS")]
        public string AppServerUrl
        {
            get { return _appServerUrl; }
            set { _appServerUrl = value; }
        }

        private string _printServerHost = "10.0.0.250";
        [XmlElement("PRINTHOST")]
        public string PrintServerHost
        {
            get { return _printServerHost; }
            set { _printServerHost = value; }
        }

        private int _printServerPort = 8888;
        [XmlElement("PRINTPORT")]
        public int PrintServerPort
        {
            get { return _printServerPort; }
            set { _printServerPort = value; }
        }

        private string _branchCode = string.Empty;
        [XmlElement("ISYERI")]
        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }

        private int _traceLevel = 3;
        [XmlElement("APPLOG")]
        public int TraceLevel
        {
            get { return _traceLevel; }
            set { _traceLevel = value; }
        }

        public void Load()
        {
            try
            {
                string configFile = string.Concat(Util.Utility.AppPath, "\\config.xml");
                if (File.Exists(configFile))
                {
                    using (Stream stream = new FileStream(configFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        XmlSerializer xmlserializer = new XmlSerializer(typeof(AppConfig));
                        _default = (AppConfig)xmlserializer.Deserialize(stream);
                        stream.Close();
                    }
                }
                else
                {
                    Save();
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }

        public void Save()
        {
            try
            {
                using (Stream stream = new FileStream(string.Concat(Util.Utility.AppPath, "\\config.xml"), FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(AppConfig));
                    xmlserializer.Serialize(stream, AppConfig.Default);
                    stream.Close();
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }
    }
}
