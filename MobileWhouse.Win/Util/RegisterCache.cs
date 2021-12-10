using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using MobileWhouse.Log;

namespace MobileWhouse.Util
{
    public class RegisterCache
    {
        private string hKeyName = "UYUMSOFT";

        private static RegisterCache register = null;
        public static RegisterCache Cache
        {
            get
            {
                if (register == null)
                {
                    register = new RegisterCache();
                }
                return register;
            }
        }

        public RegisterCache() { }

        public string ReadRegister(string key, string dvalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey(hKeyName) == null)
                {
                    Registry.CurrentUser.CreateSubKey(hKeyName);
                    WriteRegister(key, dvalue);
                    return dvalue;
                }
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey(hKeyName);
                string str = key2.GetValue(key, dvalue).ToString();
                key2.Close();
                return str;
            }
            catch (Exception except)
            {
                Logger.E(except);
                return dvalue;
            }
        }

        public string ReadRegister(string name, string key, string dvalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey(name) == null)
                {
                    Registry.CurrentUser.CreateSubKey(name);
                    WriteRegister(name, key, dvalue);
                    return dvalue;
                }
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey(name);
                RegistryKey key3 = key2.OpenSubKey(name, true);
                if (key3 == null)
                {
                    key2.Close();
                    return null;
                }
                if (key3.GetValue(key) == null)
                {
                    return null;
                }
                string str = key3.GetValue(key).ToString();
                key3.Close();
                key2.Close();
                return str;
            }
            catch (Exception exc)
            {
                Logger.E(exc);
                return null;
            }
        }

        public bool WriteRegister(string key, string svalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey(hKeyName, true) == null)
                {
                    Registry.CurrentUser.CreateSubKey(hKeyName);
                }
                Registry.CurrentUser.OpenSubKey(hKeyName, true).SetValue(key, svalue);
                return true;
            }
            catch (Exception exc)
            {
                Logger.E(exc);
                return false;
            }
        }

        public bool WriteRegister(string name, string key, string svalue)
        {
            try
            {
                if (Registry.CurrentUser.OpenSubKey(name, true) == null)
                {
                    Registry.CurrentUser.CreateSubKey(name);
                }
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey(name, true);
                if (key2.OpenSubKey(name, true) == null)
                {
                    key2.CreateSubKey(name);
                }
                key2.OpenSubKey(name, true).SetValue(key, svalue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string EncryptText(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext)) return "";

            try
            {
                byte[] encData_byte = new byte[plaintext.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(plaintext);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            return "";
        }

        public static string DecryptText(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return "";
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encryptedText);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            return "";
        }

        public int ReadInt(string key, int dvalue)
        {
            string readval = ReadRegister(key, dvalue.ToString());
            if (string.IsNullOrEmpty(readval)) return dvalue;
            int val = dvalue;
            try { val = Convert.ToInt32(readval); }
            catch { }
            return val;
        }

        public bool ReadBool(string key, bool dvalue)
        {
            string readval = ReadRegister(key, dvalue.ToString());
            if (string.IsNullOrEmpty(readval)) return dvalue;
            return readval.Equals("1");
        }

    }
}
