namespace MobileWhouse.Properties
{
    using Microsoft.Win32;
    using System;
    using System.Windows.Forms;

    internal class Settings
    {
        public string BranchCode = string.Empty;
        public static Settings Default = new Settings();
        private const string KEY_NAME = @"SOFTWARE\Uyum\MobileWhouse";
        public string LastUsername = string.Empty;
        public bool RememberMe = true;
        public string WebServiceUrl = "http://192.168.1.54:8677/WebService/MW/MobileWhouse.asmx";

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
                    key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Uyum\MobileWhouse");
                    if (key != null)
                    {
                        this.RememberMe = Convert.ToBoolean(key.GetValue("RememberMe", true));
                        this.LastUsername = key.GetValue("LastUsername", string.Empty).ToString();
                        this.BranchCode = key.GetValue("BranchCode", string.Empty).ToString();
                        this.WebServiceUrl = key.GetValue("WebServiceUrl", "http://192.168.1.54:8677/WebService/MW/MobileWhouse.asmx").ToString();
                    }
                }
                finally
                {
                    if (key != null)
                    {
                        key.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void Save()
        {
            try
            {
                RegistryKey key = null;
                try
                {
                    key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Uyum\MobileWhouse", true);
                    if (key == null)
                    {
                        key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Uyum\MobileWhouse");
                    }
                    key.SetValue("RememberMe", this.RememberMe);
                    key.SetValue("LastUsername", this.LastUsername);
                    key.SetValue("BranchCode", this.BranchCode);
                    key.SetValue("WebServiceUrl", this.WebServiceUrl);
                }
                finally
                {
                    if (key != null)
                    {
                        key.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

