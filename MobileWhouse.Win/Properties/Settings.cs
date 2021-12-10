using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace MobileWhouse.Properties
{
    internal class Settings
    {
        public static Settings Default = new Settings();
        const string KEY_NAME = @"SOFTWARE\Uyum\MobileWhouse";

        public bool RememberMe = true;
        public string LastUsername = string.Empty;
        //public string WebServiceUrl = "http://localhost:8677/WebService/MW/MobileWhouse.asmx";
        public string WebServiceUrl = "http://localhost:8677/";//http://10.0.0.250:400/
        public string AppServerUrl = "http://10.0.0.250:2002/";//http://10.0.0.250:2002/
        public string ReportServUrl = "http://localhost:62624/";//http://10.0.0.250:500/
        public string BranchCode = string.Empty;
        public int TraceLevel = 3;

        public Settings()
        {
            Default = this;
        }

        public void Load()
        {
            try
            {

                RegistryKey key = null;

                try
                {
                    key = Registry.LocalMachine.OpenSubKey(KEY_NAME);
                    if (key != null)
                    {
                        RememberMe = Convert.ToBoolean(key.GetValue("RememberMe", true));
                        LastUsername = key.GetValue("LastUsername", string.Empty).ToString();
                        BranchCode = key.GetValue("BranchCode", string.Empty).ToString();
                        WebServiceUrl = key.GetValue("WebServiceUrl", "http://192.168.1.54:8677/").ToString();
                        AppServerUrl = key.GetValue("AppServerUrl", "http://10.0.0.250:2002/").ToString();
                        ReportServUrl = key.GetValue("ReportServUrl", "http://10.0.0.250:500/").ToString();
                        TraceLevel = Convert.ToInt32(key.GetValue("TraceLevel", "3").ToString());
                    }
                }
                finally
                {
                    if (key != null)
                        key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Save()
        {
            try
            {
                RegistryKey key = null;

                try
                {
                    key = Registry.LocalMachine.OpenSubKey(KEY_NAME, true);
                    if (key == null)
                        key = Registry.LocalMachine.CreateSubKey(KEY_NAME);

                    key.SetValue("RememberMe", RememberMe);
                    key.SetValue("LastUsername", LastUsername);
                    key.SetValue("BranchCode", BranchCode);
                    key.SetValue("WebServiceUrl", WebServiceUrl);
                    key.SetValue("AppServerUrl", AppServerUrl);
                    key.SetValue("ReportServUrl", ReportServUrl);
                    key.SetValue("TraceLevel", TraceLevel.ToString());
                }
                finally
                {
                    if (key != null)
                        key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
