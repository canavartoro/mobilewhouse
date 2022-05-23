using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using System.Globalization;
using MobileWhouse.Models;
using MobileWhouse.Util;
using MobileWhouse.Data;
using System.IO;
using MobileWhouse.Log;
using MobileWhouse.Dilogs;

namespace MobileWhouse
{
    internal class ClientApplication
    {
        public event EventHandler SelectedDepotChanged;

        public ReadUserParam HandsetParam = new ReadUserParam("");

        private static ClientApplication _Instance;

        private ProdConnector.Production _prodService;
        private UyumConnector.MobileWhouse _Service;
        private UTermConnector.UTerminalServices _utermservice;
        private UyumSave.UyumSaveWebService _saveServ;
        private UyumWebService.UyumWebService _webservice;
        private LoginResult _ClientToken;
        private Token _Token;
        private FormMain _MainForm;
        private CultureInfo _Culture;
        private Depot _SelectedDepot;
        public bool _IsQuality = false;
        public bool _IsColor = false;
        public bool _IsLot = false;
        public bool _IsAttribute1 = false;
        public bool _IsAttribute2 = false;
        public bool _IsAttribute3 = false;
        public bool _IsFreeUnit1 = false;
        public bool _PurchaseReturnDisplay = false;
        

        public static ClientApplication Instance
        {
            get
            {
                return _Instance;
            }
        }

        public Depot SelectedDepot
        {
            get
            {
                return _SelectedDepot;
            }
            set
            {
                _SelectedDepot = value;
                if (SelectedDepotChanged != null)
                {
                    SelectedDepotChanged(this, EventArgs.Empty);
                }
            }
        }

        public FormMain MainForm
        {
            get
            {
                return _MainForm;
            }
        }

        public LoginResult ClientToken
        {
            get
            {
                return _ClientToken;
            }
            set
            {
                _ClientToken = value;
            }
        }

        public UyumConnector.MobileWhouse Service
        {
            get
            {
                return _Service;
            }
        }

        public ProdConnector.Production ProdService
        {
            get
            {
                return _prodService;
            }
        }

        public UTermConnector.UTerminalServices UTermService
        {
            get
            {
                return _utermservice;
            }
        }

        public UyumSave.UyumSaveWebService SaveServ
        {
            get
            {
                return _saveServ;
            }
        }


        public CultureInfo Culture
        {
            get
            {
                return _Culture;
            }
        }

        public Token Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }
        }

        private ProdConnector.Token token;
        public ProdConnector.Token ProdToken
        {
            get
            {
                if (_Token != null && token == null)
                {
                    token = new MobileWhouse.ProdConnector.Token();
                    token.BranchCode = _Token.BranchCode;
                    token.BranchDesc = _Token.BranchDesc;
                    token.BranchId = _Token.BranchId;
                    token.CoId = _Token.CoId;
                    token.DeviceId = _Token.DeviceId;
                    token.Password = _Token.Password;
                    token.UserName = _Token.UserName;
                }
                return token;
            }
        }

        private UTermConnector.Token utoken;
        public UTermConnector.Token UTermToken
        {
            get
            {
                if (_Token != null && utoken == null)
                {
                    utoken = new MobileWhouse.UTermConnector.Token();
                    utoken.BranchCode = _Token.BranchCode;
                    utoken.BranchDesc = _Token.BranchDesc;
                    utoken.BranchId = _Token.BranchId;
                    utoken.CoId = _Token.CoId;
                    utoken.DeviceId = _Token.DeviceId;
                    utoken.Password = _Token.Password;
                    utoken.UserName = _Token.UserName;
                }
                return utoken;
            }
        }

        public MobileWhouse.UyumWebService.UyumServiceResponseOfString SaveWebService(object xmlobj)
        {
            MobileWhouse.UyumWebService.UyumServiceRequestOfString Context = new MobileWhouse.UyumWebService.UyumServiceRequestOfString();
            Context.Token = new MobileWhouse.UyumWebService.UyumToken();
            if (_Token != null)
            {
                Context.Token.UserName = _Token.UserName;
                Context.Token.Password = _Token.Password;
            }
            Context.Value = FileHelper.ToXml(xmlobj);
            return _webservice.SaveUyumObjectFromXML(Context);
        }

        public object SaveWebService(object xmlobj, Type t)
        {
            MobileWhouse.UyumWebService.UyumServiceResponseOfString res = null;
            MobileWhouse.UyumWebService.UyumServiceRequestOfString Context = new MobileWhouse.UyumWebService.UyumServiceRequestOfString();
            Context.Token = new MobileWhouse.UyumWebService.UyumToken();
            if (_Token != null)
            {
                Context.Token.UserName = _Token.UserName;
                Context.Token.Password = _Token.Password;
            }
            Context.Value = FileHelper.ToXml(xmlobj);
            res = _webservice.SaveUyumObjectFromXML(Context);
            if (!res.Success)
            {
                Screens.Error(res.Message);
                return null;
            }
            else
            {
                return BaseModel.FromXml(t, res.Value);
            }
        }

        public void SendTrace()
        {
            try
            {
                string applog = TextWriterTraceListener.GetTraceContent();
                if (!string.IsNullOrEmpty(applog))
                {
                    StringBuilder sdata = new StringBuilder();
                    sdata.Append(DeviceUtil.GetDeviceInfo());
                    sdata.Append(applog);

                    AppServ.Service serv = new MobileWhouse.AppServ.Service();
                    serv.Url = string.Concat(AppConfig.Default.AppServerUrl, "/Service.asmx");
                    string save = serv.AppLogSave(sdata.ToString());
                    if (!string.IsNullOrEmpty(save))
                    {
                        Screens.Error(string.Concat("Bilgiler sunucuya yazılamadı. ", save));
                        return;
                    }
                    Screens.Info("Log bilgileri sunucuya gönderildi.");
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
                Logger.E(exc);
            }
        }



        public ClientApplication()
        {
            _Instance = this;
        }

        public void Relead()
        {
            //Properties.Settings sett = new Properties.Settings();
            //sett.Load();
            string servUrl = "";
            if (!string.IsNullOrEmpty(AppConfig.Default.WebServiceUrl))
            {
                if (AppConfig.Default.WebServiceUrl[AppConfig.Default.WebServiceUrl.Length - 1] == '/')
                    servUrl = AppConfig.Default.WebServiceUrl;
                else
                    servUrl = string.Concat(AppConfig.Default.WebServiceUrl, "/");
            }

            //string reportUrl = "";//http://localhost:62624/WriteWebService/ReportWebService.asmx
            //if (!string.IsNullOrEmpty(AppConfig.Default.ReportServUrl))
            //{
            //    if (AppConfig.Default.ReportServUrl[AppConfig.Default.ReportServUrl.Length - 1] == '/')
            //        reportUrl = AppConfig.Default.ReportServUrl;
            //    else
            //        reportUrl = string.Concat(AppConfig.Default.ReportServUrl, "/");
            //}

            try
            {
                _Service = new MobileWhouse.UyumConnector.MobileWhouse();
                _Service.Url = string.Concat(servUrl, "WebService/MW/MobileWhouse.asmx");
                _Service.Timeout = 180000;

                _prodService = new MobileWhouse.ProdConnector.Production();
                _prodService.Url = string.Concat(servUrl, "WebService/MW/Production.asmx");
                _prodService.Timeout = 180000;

                _utermservice = new MobileWhouse.UTermConnector.UTerminalServices();
                _utermservice.Url = string.Concat(servUrl, "webservice/trm/uterminalservices.asmx");
                _utermservice.Timeout = 180000;

                _saveServ = new MobileWhouse.UyumSave.UyumSaveWebService();
                _saveServ.Url = string.Concat(servUrl, "WebService/ERP/UyumSaveWebService.asmx");
                _saveServ.Timeout = 180000;

                //_reportServ = new MobileWhouse.ReportServ.ReportWebService();
                //_reportServ.Url = string.Concat(reportUrl, "WriteWebService/ReportWebService.asmx");
                //_reportServ.Timeout = 180000;

                _webservice = new MobileWhouse.UyumWebService.UyumWebService();
                _webservice.Url = string.Concat(servUrl, "WebService/UyumWebService.asmx");
                _webservice.Timeout = 180000;
            }
            catch (Exception exc)
            {
                MobileWhouse.Util.Screens.Error(string.Concat("Sunucu servis bağlantılarında hata var! Ayarları kontrol edin.", exc.Message));
            }

            _Culture = new CultureInfo(1055);
        }

        public void Run()
        {
            try
            {
                MobileWhouse.Log.TextWriterTraceListener listener = new MobileWhouse.Log.TextWriterTraceListener();
                System.Diagnostics.Debug.Listeners.Add(listener);

                //Basla:
                Relead();

                FormLogin login = new FormLogin();
                DialogResult result = login.ShowDialog();
                login.Dispose();

                if (result == DialogResult.OK && _ClientToken != null)
                {
                    try
                    {
                        using (_MainForm = new FormMain())
                        {
                            _MainForm.Text = ClientApplication.Instance.Token.BranchDesc;
                            DialogResult rest = _MainForm.ShowDialog();
                            //if (rest == DialogResult.Abort) goto Basla;
                        }
                    }
                    catch (Exception ex)
                    {
                        MobileWhouse.Util.Screens.Error(ex);
                    }
                }
            }
            catch (Exception exception)
            {
                MobileWhouse.Util.Screens.Error(exception);
            }
        }

        //public static void ShowError(Exception ex)
        //{
        //    MessageBox.Show(string.Format(Properties.Resources.Err_GenericException, ex.Message),
        //        Properties.Resources.Err_Error);
        //}

        //public static void ShowError(string message)
        //{
        //    MessageBox.Show(message,
        //        Properties.Resources.Err_Error);
        //}
    }
}
