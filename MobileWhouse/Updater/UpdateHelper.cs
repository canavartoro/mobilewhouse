using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Util;
using System.Net;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using MobileWhouse.Models;

namespace MobileWhouse.Updater
{
    public class UpdateHelper
    {
        private string updatername = "MobileWhouseUpdater.exe";
        public void Update()
        {
            try
            {
                UpdaterExtract();

                string full_url = AppConfig.Default.AppServerUrl + "/uyumsoft.zip";

                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(full_url);
                httpRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                System.IO.Stream dataStream = httpResponse.GetResponseStream();

                byte[] inBuf = new byte[10000001];
                int bytesToRead = StringUtil.ToInteger(inBuf.Length);
                int bytesRead = 0;
                while (bytesToRead > 0)
                {
                    int n = dataStream.Read(inBuf, bytesRead, bytesToRead);
                    if (n == 0)
                    {
                        break; // TODO: might not be correct. Was : Exit While
                    }
                    bytesRead += n;
                    bytesToRead -= n;
                }

                FileStream fstr = new FileStream(Utility.AppPath + "uyumsoft.zip", FileMode.OpenOrCreate, FileAccess.Write);
                fstr.Write(inBuf, 0, bytesRead);
                dataStream.Close();
                fstr.Close();

                if (!File.Exists(Utility.AppPath + "uyumsoft.zip"))
                {
                    Screens.Error("UYGULAMA PAKETİ SUNUCUDAN ÇEKİLEMEDİ! " + Utility.AppPath + "uyumsoft.zip");
                    return;
                }
                if (!File.Exists(Utility.AppPath + updatername))
                {
                    Screens.Error("UYGULAMA PAKET AYRIŞTIRICI BULUNAMADI! " + Utility.AppPath + updatername);
                    return;
                }

                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = string.Concat(Utility.AppPath, updatername);
                Process.Start(p);
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception except)
            {
                Screens.Error(except);
            }
        }

        private void UpdaterExtract()
        {
            try
            {
                string[] Files = null;

                if (Utility.AppPath.StartsWith("\\"))
                {
                    //Pocket PC
                    updatername = "MobileWhouseUpdater.exe";
                    Files = new[] { "Ionic.Zip.CF.dll", "MobileWhouseUpdater.exe" };
                }
                else
                {
                    //PC
                    updatername = "MobileWhouseUpdater.Win.exe";
                    Files = new[] { "Ionic.Zip.dll", "MobileWhouseUpdater.Win.exe" };
                }

                foreach (string file in Files)
                {
                    Assembly _Assembly = Assembly.GetExecutingAssembly();
                    Stream _Stream = _Assembly.GetManifestResourceStream(String.Format("MobileWhouse.Updater.{0}", file));
                    BinaryReader _BinaryReader = new BinaryReader(_Stream);
                    byte[] _byte = _BinaryReader.ReadBytes((int)_Stream.Length);
                    _BinaryReader.Close();
                    FileStream _FileStream = new FileStream(Utility.AppPath + file, FileMode.OpenOrCreate);
                    BinaryWriter _BinaryWriter = new BinaryWriter(_FileStream);
                    _BinaryWriter.Write(_byte);
                    _BinaryWriter.Flush();
                    _BinaryWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Screens.Error(string.Concat("GÜNCELLEME YARDIMCISI OLUŞTURULAMADI! ", Utility.AppPath, updatername, ", Hata:", ex.Message));
                return;
            }
        }
    }
}
