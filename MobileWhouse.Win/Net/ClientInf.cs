using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Log;

namespace MobileWhouse.Net
{
    [Serializable]
    public class ClientInf
    {
        public const string LOGIN_REQUEST = "login";
        public const string LOGOFF_REQUEST = "logoff";
        public const string PRINT_REQUEST = "print";
        public const string GET_REQUEST = "get";
        public const string OK_REQUEST = "ok";
        public const string MESSAGE_REQUEST = "message";
        public const string CLOSE_REQUEST = "close";
        public const string UPDATE_REQUEST = "update";

        public ClientInf() { }

        private string name = "";
        private string message = "";
        private string data = "";
        private string command = "";


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        public static ClientInf ParsData(byte[] bytesdata)
        {
            if (bytesdata == null) return null;

            String strdata = Encoding.GetEncoding("Windows-1254").GetString(bytesdata, 0, bytesdata.Length);
            Logger.I(strdata);
            ClientInf client = null;

            if (!string.IsNullOrEmpty(strdata) && strdata.IndexOf("|") != -1)
            {
                strdata = strdata.Replace("\0", "");
                client = new ClientInf();
                string[] arrdata = strdata.Split('|');
                if (arrdata != null)
                {
                    if (arrdata.Length > 0)
                        client.Name = arrdata[0];
                    if (arrdata.Length > 1)
                        client.Command = arrdata[1];
                    if (arrdata.Length > 2)
                        client.Message = arrdata[2];
                    if (arrdata.Length > 3)
                        client.Data = arrdata[3];
                }
            }


            return client;

        }
    }

}
