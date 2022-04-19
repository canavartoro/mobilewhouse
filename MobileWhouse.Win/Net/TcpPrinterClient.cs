using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using MobileWhouse.Util;
using System.Threading;
using MobileWhouse.Log;
using System.IO;
using System.Net.Sockets;
using MobileWhouse.Models;

namespace MobileWhouse.Net
{
    public class TcpPrinterClient : IDisposable
    {
        public TcpPrinterClient()
        {
            Connect();
        }

        protected System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();


        public void Connect()
        {
            try
            {
                //int port = RegisterCache.Cache.ReadInt(RegisterCache.KEY_PRINT_PORT, 8888);
                //System.Net.ServicePointManager.Expect100Continue = false;
                //clientSocket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                //IPHostEntry hostEntry = Dns.GetHostEntry(RegisterCache.Cache.ReadRegister(RegisterCache.KEY_PRINT_SERV, "10.10.11.129"));
                //IPEndPoint printEndPoint = new IPEndPoint(IPAddress.Parse(RegisterCache.Cache.ReadRegister(RegisterCache.KEY_PRINT_SERV, "10.10.11.129")), port);
                //clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 8888);
                clientSocket.Connect(IPAddress.Parse(AppConfig.Default.PrintServerHost), AppConfig.Default.PrintServerPort);
                //clientSocket.Connect(printEndPoint);
                //clientSocket.SendTimeout = 40000;
                //clientSocket.ReceiveTimeout = 40000;

            }
            catch (Exception e)
            {
                Screens.Error(e.Message);
            }
        }

        public void Close()
        {
            try
            {
                try
                {
                    Thread.Sleep(500);
                    if (clientSocket != null) clientSocket.Close();
                    clientSocket = null;
                }
                catch (Exception exclose) { Logger.E(exclose); }
            }
            catch (IOException ioe) // Catch exceptions  
            {
                Logger.E(ioe.Message);
            }
            catch (Exception e)
            {
                Logger.E(e);
            }
        }

        public PrintersDesigns PrintServer(string userName, string printerName, string designName, string critaria)
        {
            PrintersDesigns resp = new PrintersDesigns();
            try
            {
                using (NetworkStream serverStream = clientSocket.GetStream())
                {
                    if (clientSocket != null && serverStream != null && serverStream.CanWrite)
                    {
                        string xmlstr = string.Concat(userName, "|print|", printerName, "|", designName, "|", critaria);
                        Logger.I(xmlstr);
                        byte[] outStream = Encoding.GetEncoding("Windows-1254").GetBytes(xmlstr);
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();

                        Thread.Sleep(250);

                        if (serverStream.CanRead)
                        {
                            byte[] bytesFrom = new byte[10025];
                            serverStream.Read(bytesFrom, 0, bytesFrom.Length);
                            ClientInf receiveData = ClientInf.ParsData(bytesFrom);
                            if (receiveData != null)
                            {
                                resp.Massage = receiveData.Message;
                                resp.Result = Convert.ToBoolean(receiveData.Data);
                            }
                        }
                        serverStream.Flush();
                        serverStream.Close();
                    }
                }
            }
            catch (IOException ie)
            {
                Logger.E(ie.Message);
                return new PrintersDesigns(false, ie.Message);
            }
            catch (Exception e)
            {
                Logger.E(e.Message);
                return new PrintersDesigns(false, e.Message);
            }
            return resp;
        }

        public PrintersDesigns GetPrintersDesigns()
        {
            PrintersDesigns resp = new PrintersDesigns();
            try
            {
                using (NetworkStream serverStream = clientSocket.GetStream())
                {
                    if (clientSocket != null && serverStream != null && serverStream.CanWrite)
                    {
                        string xmlstr = string.Concat("|get|||");
                        Logger.I(xmlstr);
                        byte[] outStream = Encoding.GetEncoding("Windows-1254").GetBytes(xmlstr);
                        serverStream.Write(outStream, 0, outStream.Length);
                        serverStream.Flush();

                        if (serverStream.CanRead)
                        {
                            byte[] bytesFrom = new byte[10025];
                            serverStream.Read(bytesFrom, 0, bytesFrom.Length);
                            ClientInf receiveData = ClientInf.ParsData(bytesFrom);
                            if (receiveData != null)
                            {
                                string[] arrDesign = receiveData.Message.Split(';');
                                if (arrDesign != null && arrDesign.Length > 0)
                                {
                                    foreach (string d in arrDesign) resp.Designs.Add(d);
                                }
                                string[] arrPrinters = receiveData.Data.Split(';');
                                if (arrPrinters != null && arrPrinters.Length > 0)
                                {
                                    foreach (string p in arrPrinters) resp.Printers.Add(p);
                                }
                                resp.Result = true;
                            }
                        }
                        serverStream.Flush();
                        serverStream.Close();
                    }
                }
            }
            catch (IOException ie)
            {
                Logger.E(ie.Message);
                return new PrintersDesigns(false, ie.Message);
            }
            catch (Exception e)
            {
                Logger.E(e.Message);
                return new PrintersDesigns(false, e.Message);
            }
            return resp;
        }


        #region IDisposable
        ~TcpPrinterClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (clientSocket != null)
                {
                    clientSocket.Close();
                }

                clientSocket = null;
            }

            disposed = true;
        }

        #endregion
    }

    public class TcpPrinter : TcpPrinterClient
    {
        public TcpPrinter() : base() { }

        NetworkStream serverStream = null;

        public void Open()
        {
            try
            {
                serverStream = clientSocket.GetStream();
            }
            catch (IOException ie)
            {
                Logger.E(ie.Message);
            }
            catch (Exception e)
            {
                Logger.E(e.Message);
            }
        }

        public PrintersDesigns Print(string userName, string printerName, string designName, string critaria)
        {
            PrintersDesigns resp = new PrintersDesigns();
            try
            {

                if (clientSocket != null && serverStream != null && serverStream.CanWrite)
                {
                    string xmlstr = string.Concat(userName, "|print|", printerName, "|", designName, "|", critaria);
                    Logger.I(xmlstr);
                    byte[] outStream = Encoding.GetEncoding("Windows-1254").GetBytes(xmlstr);
                    serverStream.Write(outStream, 0, outStream.Length);
                    //serverStream.Flush();
                    Thread.Sleep(100);
                    if (serverStream.CanRead)
                    {
                        byte[] bytesFrom = new byte[1024];
                        serverStream.Read(bytesFrom, 0, bytesFrom.Length);
                        ClientInf receiveData = ClientInf.ParsData(bytesFrom);
                        if (receiveData != null)
                        {
                            resp.Massage = receiveData.Message;
                            resp.Result = Convert.ToBoolean(receiveData.Data);
                        }
                    }
                }
            }
            catch (IOException ie)
            {
                Logger.E(ie.Message);
                return new PrintersDesigns(false, ie.Message);
            }
            catch (Exception e)
            {
                Logger.E(e.Message);
                return new PrintersDesigns(false, e.Message);
            }
            return resp;
        }

        ~TcpPrinter()
        {
            Dispose(false);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (serverStream != null)
                {
                    serverStream.Flush();
                    serverStream.Close();
                    serverStream.Dispose();
                }
                serverStream = null;
            }

            disposed = true;
        }
    }

}
