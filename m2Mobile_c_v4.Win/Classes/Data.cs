    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Xml.Linq;
    using System.Web.Services.Description;
    using System.Windows.Forms;
    using System.Net;
    using m2Mobile_c_v4.WebReference;

namespace m2Mobile_c_v4
{
  
        public class Data
        {


            public static int _SelectedWareHouse = 0;
            public static int _BarcodeDelay = 0;

            public static string FrmAramaItemName = "";
            public static string FrmAramaItemCode = "";


            public static WebReference.ServiceRequestOfToken _Token = new m2Mobile_c_v4.WebReference.ServiceRequestOfToken();
            public static WebReference.UTerminalServices _UService = new m2Mobile_c_v4.WebReference.UTerminalServices();


            public static FormParameters FParam(string _FormName)
            {
                

                FormParameters _FormParam = new FormParameters();
                XElement xml = XElement.Load(Classes.SysDefinitions.GetApplicationDirectory().ToString() + "\\FormParameters.xml");
               
                var Params = (from data in xml.Descendants("ParamTable_Tr")
                              where data.Element("PRM_FORMNAME").Value.Equals(_FormName)
                              select new FormParameters()
                              {
                                  PRM_FORMNAME = data.Element("PRM_FORMNAME").Value,
                                  PRM_USEBARCODE = Boolean.Parse(data.Element("PRM_USEBARCODE").Value),
                                  PRM_USEPACKAGECODE = Boolean.Parse(data.Element("PRM_USEPACKAGECODE").Value),
                                  PRM_USESERIALCODE = Boolean.Parse(data.Element("PRM_USESERIALCODE").Value),
                                  PRM_USESTOCKCODE = Boolean.Parse(data.Element("PRM_USESTOCKCODE").Value),
                                  PRM_USERACKCODE = Boolean.Parse(data.Element("PRM_USERACKCODE").Value),
                                  PRM_PACKAGEPREVALUE = data.Element("PRM_PACKAGEPREVALUE").Value,
                                  PRM_BARCODEPREVALUE = data.Element("PRM_BARCODEPREVALUE").Value,
                                  PRM_SERIALPREVALUE = data.Element("PRM_SERIALPREVALUE").Value,
                                  PRM_STOCKPREVALUE = data.Element("PRM_STOCKPREVALUE").Value,
                                  PRM_ALLOWMANUELENTRY = Boolean.Parse(data.Element("PRM_ALLOWMANUELENTRY").Value),
                                  PRM_MAXAMOUNT = Int32.Parse(data.Element("PRM_MAXAMOUNT").Value),
                                  PRM_DEFAULTAMOUNT = Int32.Parse(data.Element("PRM_DEFAULTAMOUNT").Value),
                                  PRM_READSQUENCE1 = data.Element("PRM_READSQUENCE1").Value,
                                  PRM_READSQUENCE2 = data.Element("PRM_READSQUENCE2").Value,
                                  PRM_READSQUENCE3 = data.Element("PRM_READSQUENCE3").Value,
                                  PRM_READSQUENCE4 = data.Element("PRM_READSQUENCE4").Value,
                                  PRM_READSQUENCE5 = data.Element("PRM_READSQUENCE5").Value,
                                  PRM_PACKAGELABEL = data.Element("PRM_PACKAGELABEL").Value,
                                  PRM_SERIALLABEL = data.Element("PRM_SERIALLABEL").Value,
                                  PRM_STOCKLABEL = data.Element("PRM_STOCKLABEL").Value,
                                  PRM_BARCODELABEL = data.Element("PRM_BARCODELABEL").Value,
                                  PRM_RACKLABEL = data.Element("PRM_RACKLABEL").Value,
                              }).FirstOrDefault();
                return Params;
            }

            public static Boolean UpdateWebServices(string _Url)
            {
                Boolean RetVal = true;
                if (_Url == "")
                {
                    XElement xml = XElement.Load(Classes.SysDefinitions.GetApplicationDirectory().ToString() + "\\SysDef.xml");
                    var Params = (from data in xml.Descendants("MainParam")
                                  select new
                                  {
                                      _Url = data.Element("WebServiceUrl").Value,
                                  }).FirstOrDefault();

                    _UService.Url = Params._Url.ToString();
                }
                else
                    _UService.Url = _Url;
                try
                {

                }
                catch (SystemException)
                {
                    RetVal = false;
                }

                return RetVal;
            }

            public static HttpStatusCode CheckWebService(string Url)
            {
                HttpStatusCode _Res = new HttpStatusCode();
                _Res = HttpStatusCode.OK;

                try
                {
                    string aa = _UService.HelloWord().ToString();
                    if (aa == "") _Res = HttpStatusCode.ServiceUnavailable;
                }
                catch (SystemException ex)
                {
                    _Res = HttpStatusCode.ServiceUnavailable;
                    Console.WriteLine(ex.Message.ToString());
                }

                return _Res;

            }

            public static ServiceResultOfItemInfo _SrvcItemInfo(string _Barcode)
            {
                m2Mobile_c_v4.WebReference.ServiceRequestOfItemSelectParam _ItemPrm = new ServiceRequestOfItemSelectParam();
                _ItemPrm.Token = new Token();
                _ItemPrm.Token = Data._Token.Token;
                _ItemPrm.Value = new ItemSelectParam();
                _ItemPrm.Value.DepotId = Data._SelectedWareHouse;
                _ItemPrm.Value.Barkod = _Barcode;

                m2Mobile_c_v4.WebReference.ServiceResultOfItemInfo _ItemInfo = Data._UService.GetItemInfo(_ItemPrm);
                return _ItemInfo;



            }
            public static ServiceResultOfInt32 _SrvcItemInfoUseItemID(string _ItemCode)
            {
                m2Mobile_c_v4.WebReference.ServiceRequestOfString _ItemPrm = new ServiceRequestOfString();
                _ItemPrm.Token = new Token();
                _ItemPrm.Token = Data._Token.Token;
                _ItemPrm.Value = _ItemCode;

                m2Mobile_c_v4.WebReference.ServiceResultOfInt32 _ItemInfo = Data._UService.GetItemIdUseItemCode(_ItemPrm);
                return _ItemInfo;



            }
            public static Boolean IsNumber(string _Gelen)
            {
                Boolean _RetVal = true;
                Decimal _Kontrol = 0;
                try
                {
                    _Kontrol = Decimal.Parse(_Gelen.ToString());
                }
                catch (System.Exception e)
                {
                    MessageBox.Show(e.Message);
                    _RetVal = false;
                }

                return _RetVal;
            }

        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public int Id { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }


