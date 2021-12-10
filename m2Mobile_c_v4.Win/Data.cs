namespace m2Mobile_c_v4
{
    using m2Mobile_c_v4.Classes;
    using System;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using WebReference;

    public class Data
    {
        static Data()
        {
            _SelectedWareHouse = 0;
            _BarcodeDelay = 0;
            _Token = new ServiceRequestOfToken();
            _UService = new UTerminalServices();
        }

        public static int _BarcodeDelay;
        public static int _SelectedWareHouse = 0;
        public static ServiceRequestOfToken _Token = new ServiceRequestOfToken();
        public static UTerminalServices _UService = new UTerminalServices();

        public static ServiceResultOfItemInfo _SrvcItemInfo(string _Barcode)
        {
            ServiceRequestOfItemSelectParam param = new ServiceRequestOfItemSelectParam();
            param.Token = _Token.Token;
            param.Value = new ItemSelectParam();
            param.Value.DepotId = _SelectedWareHouse;
            param.Value.Barkod = _Barcode;
            return _UService.GetItemInfo(param);
        }

        public static ServiceResultOfInt32 _SrvcItemInfoUseItemID(string _ItemCode)
        {
            ServiceRequestOfString param = new ServiceRequestOfString();
            param.Token = _Token.Token;
            param.Value = _ItemCode;
            return _UService.GetItemIdUseItemCode(param);
        }

        public static HttpStatusCode CheckWebService(string Url)
        {
            HttpStatusCode oK = (HttpStatusCode)0;
            oK = HttpStatusCode.OK;
            try
            {
                if (_UService.HelloWord().ToString() == "")
                {
                    oK = HttpStatusCode.ServiceUnavailable;
                }
            }
            catch (SystemException exception)
            {
                oK = HttpStatusCode.ServiceUnavailable;
                Console.WriteLine(exception.Message.ToString());
            }
            return oK;
        }

        public static FormParameters FParam(string _FormName)
        {
            FormParameters parameters = new FormParameters();
            return (from data in XElement.Load(SysDefinitions.GetApplicationDirectory().ToString() + @"\FormParameters.xml").Descendants("ParamTable_Tr")
                    where data.Element("PRM_FORMNAME").Value.Equals(_FormName)
                    select new FormParameters
                    {
                        PRM_FORMNAME = data.Element("PRM_FORMNAME").Value,
                        PRM_USEBARCODE = bool.Parse(data.Element("PRM_USEBARCODE").Value),
                        PRM_USEPACKAGECODE = bool.Parse(data.Element("PRM_USEPACKAGECODE").Value),
                        PRM_USESERIALCODE = bool.Parse(data.Element("PRM_USESERIALCODE").Value),
                        PRM_USESTOCKCODE = bool.Parse(data.Element("PRM_USESTOCKCODE").Value),
                        PRM_USERACKCODE = bool.Parse(data.Element("PRM_USERACKCODE").Value),
                        PRM_PACKAGEPREVALUE = data.Element("PRM_PACKAGEPREVALUE").Value,
                        PRM_BARCODEPREVALUE = data.Element("PRM_BARCODEPREVALUE").Value,
                        PRM_SERIALPREVALUE = data.Element("PRM_SERIALPREVALUE").Value,
                        PRM_STOCKPREVALUE = data.Element("PRM_STOCKPREVALUE").Value,
                        PRM_ALLOWMANUELENTRY = bool.Parse(data.Element("PRM_ALLOWMANUELENTRY").Value),
                        PRM_MAXAMOUNT = int.Parse(data.Element("PRM_MAXAMOUNT").Value),
                        PRM_DEFAULTAMOUNT = int.Parse(data.Element("PRM_DEFAULTAMOUNT").Value),
                        PRM_READSQUENCE1 = data.Element("PRM_READSQUENCE1").Value,
                        PRM_READSQUENCE2 = data.Element("PRM_READSQUENCE2").Value,
                        PRM_READSQUENCE3 = data.Element("PRM_READSQUENCE3").Value,
                        PRM_READSQUENCE4 = data.Element("PRM_READSQUENCE4").Value,
                        PRM_READSQUENCE5 = data.Element("PRM_READSQUENCE5").Value,
                        PRM_PACKAGELABEL = data.Element("PRM_PACKAGELABEL").Value,
                        PRM_SERIALLABEL = data.Element("PRM_SERIALLABEL").Value,
                        PRM_STOCKLABEL = data.Element("PRM_STOCKLABEL").Value,
                        PRM_BARCODELABEL = data.Element("PRM_BARCODELABEL").Value,
                        PRM_RACKLABEL = data.Element("PRM_RACKLABEL").Value
                    }).FirstOrDefault<FormParameters>();
        }

        public static bool IsNumber(string _Gelen)
        {
            bool flag = true;
            decimal num = 0M;
            try
            {
                num = decimal.Parse(_Gelen.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                flag = false;
            }
            return flag;
        }

        public static bool UpdateWebServices(string _Url)
        {
            if (_Url == "")
            {
                var type = (from data in XElement.Load(SysDefinitions.GetApplicationDirectory().ToString() + @"\SysDef.xml").Descendants("MainParam") select new { _Url = data.Element("WebServiceUrl").Value }).FirstOrDefault();
                _UService.Url = type._Url.ToString();
            }
            else
            {
                _UService.Url = _Url;
            }

            return true;
        }
    }
}

