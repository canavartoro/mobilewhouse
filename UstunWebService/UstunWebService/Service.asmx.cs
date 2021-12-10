using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using UstunWebService.Helpers;
using UstunWebService.SenfoniGS;
using UstunWebService.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using UstunWebService.Models;
using UstunWebService.Data;

namespace UstunWebService
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        private MobileWhouseService.MobileWhouse GetMobileWhouse()
        {
            MobileWhouseService.MobileWhouse mobileWhouse = new MobileWhouseService.MobileWhouse();
            string url = global::UstunWebService.Properties.Settings.Default.UyumUrl;
            if (string.IsNullOrWhiteSpace(url)) url = @"http://hyperv01:1120/WebService/MW/MobileWhouse.asmx";
            if (!url.Contains("MobileWhouse"))
            {
                if (url.EndsWith("/")) url = string.Concat(url, "WebService/MW/MobileWhouse.asmx");
                else
                    url = string.Concat(url, "/WebService/MW/MobileWhouse.asmx");
            }
            mobileWhouse.Url = url;
            mobileWhouse.Timeout = 999999;
            return mobileWhouse;
        }

        private SenfoniGS.GeneralSenfoniService GetSenfoniService()
        {
            SenfoniGS.GeneralSenfoniService senfoniService = new SenfoniGS.GeneralSenfoniService();
            string url = global::UstunWebService.Properties.Settings.Default.UyumUrl;
            if (string.IsNullOrWhiteSpace(url)) url = @"http://hyperv01:1120/WebService/General/GeneralSenfoniService.asmx";
            if (!url.Contains("GeneralSenfoniService"))
            {
                if (url.EndsWith("/")) url = string.Concat(url, "WebService/General/GeneralSenfoniService.asmx");
                else
                    url = string.Concat(url, "/WebService/General/GeneralSenfoniService.asmx");
            }
            senfoniService.Url = url;
            senfoniService.Timeout = 999999;
            return senfoniService;
        }

        private UTerminalService.UTerminalServices GetUTerminalService()
        {
            UTerminalService.UTerminalServices utermService = new UTerminalService.UTerminalServices();
            string url = global::UstunWebService.Properties.Settings.Default.UyumUrl;
            if (string.IsNullOrWhiteSpace(url)) url = @"http://hyperv01:1120/WebService/General/GeneralSenfoniService.asmx";
            if (!url.ToLower().Contains("uterminalservices"))
            {
                if (url.EndsWith("/")) url = string.Concat(url, "webservice/trm/uterminalservices.asmx");
                else
                    url = string.Concat(url, "/webservice/trm/uterminalservices.asmx");
            }
            utermService.Url = url;
            utermService.Timeout = 999999;
            return utermService;
        }

        private SaveService.UyumSaveWebService GetUyumSaveWebService()
        {
            SaveService.UyumSaveWebService saveWebService = new SaveService.UyumSaveWebService();
            string url = global::UstunWebService.Properties.Settings.Default.UyumUrl;
            if (string.IsNullOrWhiteSpace(url)) url = @"http://oralive.ofis.uyumcloud.com/WebService/Erp/UyumSaveWebService.asmx";
            if (!url.ToLower().Contains("uyumsavewebservice"))
            {
                if (url.EndsWith("/")) url = string.Concat(url, "WebService/Erp/UyumSaveWebService.asmx");
                else
                    url = string.Concat(url, "/WebService/Erp/UyumSaveWebService.asmx");
            }
            saveWebService.Url = url;
            saveWebService.Timeout = 999999;
            return saveWebService;
        }

        //[WebMethod]
        public string Login(string username, string password)
        {
            string result = "";
            try
            {
                using (var data = new DataClient())
                {
                    Token token = new Token { Username = username, Password = password };
                    //string passwordHash = Membership.CreateUser(token.Username, token.Password).GetPassword();
                    //EventLog.WriteEntry("Application", "Password : " + token.Password, EventLogEntryType.Information, 1);
                    string passwordHash = FormsAuthentication.HashPasswordForStoringInConfigFile(token.Password, "sha1");
                    result = new LoginHelper().Login(token.Username, passwordHash, data);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                result = new ServiceResult<Token>(ex).ToString();
            }
            finally
            {
            }
            return result;
        }

        //[WebMethod]
        public string GetBranchList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetBranchList(token, filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string GetItemsATT(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);

                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetItemAttribute(filterModel, token, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string GetItemsQuality(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);

                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetItemQualityList(filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string GetItemsLot(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ItemLotFilterModel filterModel = JsonConvert.DeserializeObject<ItemLotFilterModel>(filterJson);

                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetItemLotList(filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string GetHandsetParam(string tokenJson)
        {
            try
            {
                ServiceResult<List<UserParam>> result = new ServiceResult<List<UserParam>>();
                var utermService = GetUTerminalService();
                UTerminalService.ServiceRequestOfInt32 param = new UTerminalService.ServiceRequestOfInt32();
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                param.Token = new UTerminalService.Token();
                param.Token.UserName = token.Username;
                param.Token.Password = token.Password;
                param.Token.BranchId = token.BranchId;
                param.Token.CoId = token.CoId;
                param.Value = token.BranchId;

                var userBrachParamResult = utermService.HandsetBranchParametre(param);
                if (userBrachParamResult != null)
                {
                    List<UserParam> userParams = new List<UserParam>();

                    var sdMain = userBrachParamResult.Value.Split('\n');
                    foreach (var ss in sdMain)
                    {
                        if (string.IsNullOrEmpty(ss)) continue;

                        var sdLine = ss.Split(';');
                        if (sdLine.Length < 3) continue;

                        var pageCode = sdLine[0].Trim().ToUpper();
                        var key = sdLine[1].Trim().ToUpper();
                        var value = sdLine[2];
                        var kk = new UserParam { KeyCode = key, PageCode = pageCode, Value = value };
                        userParams.Add(kk);
                    }

                    result.Success = userBrachParamResult.Result;
                    result.ErrorMessage = userBrachParamResult.Message;
                    result.Result = userParams;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = "Sunucu yanıt vermedi!";
                }
                return result.ToString();

            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<List<UserParam>> result = new ServiceResult<List<UserParam>>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string GetBranchWhouseList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                    return QueryHelper.GetBranchWhouseList(filterModel, token, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }


        //[WebMethod]
        public string GetDocNumberFromBranch(string tokenJson, string filterJson)
        {
            try
            {
                ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);

                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                MobileWhouseService.MobileWhouse mobileWhouse = GetMobileWhouse();
                MobileWhouseService.ServiceRequestOfDateTime param = new MobileWhouseService.ServiceRequestOfDateTime();
                param.Token = new MobileWhouseService.Token();
                param.Token.CoId = token.CoId;
                param.Token.BranchId = token.BranchId;
                param.Token.UserName = token.Username;
                param.Token.Password = token.Password;
                if (!string.IsNullOrWhiteSpace(filterModel.doc_date))
                    param.Value = DateTime.Parse(filterModel.doc_date, new CultureInfo("tr-TR", true));
                else
                    param.Value = DateTime.Now.Date;

                Logger.WriteFileLog(new StringBuilder().Append("Belge no giden:").Append(Logger.ToJson(param)).ToString());

                MobileWhouseService.ServiceResultOfString result = mobileWhouse.GetIrsaliyeBelgeNo(param);
                if (result != null)
                {
                    Logger.WriteFileLog(new StringBuilder().Append("Belge no gelen:").Append(Logger.ToJson(result)).ToString());
                    if (result.Result)
                    {
                        return new ServiceResult<string>()
                        {
                            Success = true,
                            Result = result.Value,
                            ErrorMessage = ""
                        }.ToString();
                    }
                    else
                    {
                        Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(result.Message).Append("Detay:").Append(Logger.ToXml(param)).ToString());
                        return new ServiceResult<string>()
                        {
                            Success = false,
                            Result = "",
                            ErrorMessage = string.Format("Sunucu hatası:", result.Message)
                        }.ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                return new ServiceResult<string>()
                {
                    Success = false,
                    Result = "",
                    ErrorMessage = ex.Message
                }.ToString();
            }
            finally
            {

            }
            return "";
        }

        //[WebMethod]
        public string GetDocNumber(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    if (filterModel.filterId == 212)
                    {
                        ServiceResult<string> serviceResult = QueryHelper.GetPackageDocNo(filterModel, data);
                        if (serviceResult != null)
                        {
                            //Logger.WriteFileLog(new StringBuilder().Append("Belge no gelen:").Append(Logger.ToJson(result)).ToString());
                            if (serviceResult.Success)
                            {
                                return new ServiceResult<string>()
                                {
                                    Success = true,
                                    Result = serviceResult.Result,
                                    ErrorMessage = serviceResult.ErrorMessage
                                }.ToString();
                            }
                            else
                            {
                                Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(serviceResult.ErrorMessage).Append("Detay:").Append(Logger.ToXml(serviceResult)).ToString());
                                return new ServiceResult<string>()
                                {
                                    Success = false,
                                    Result = "",
                                    ErrorMessage = string.Concat("Sunucu hatası:", serviceResult.ErrorMessage)
                                }.ToString();
                            }
                        }
                    }
                    else
                    {
                        MobileWhouseService.MobileWhouse mobileWhouse = GetMobileWhouse();
                        MobileWhouseService.ServiceRequestOfDocNoParam param = new MobileWhouseService.ServiceRequestOfDocNoParam();
                        param.Token = new MobileWhouseService.Token();
                        param.Token.CoId = token.CoId;
                        param.Token.BranchId = token.BranchId;
                        param.Token.UserName = token.Username;
                        param.Token.Password = token.Password;
                        param.Value = new MobileWhouseService.DocNoParam();
                        param.Value.DocTraId = filterModel.id;
                        param.Value.SourceApp = filterModel.filterId;
                        param.Value.CoId = token.CoId;
                        param.Value.BranchId = token.BranchId;
                        param.Value.PurchaseSalesVal = filterModel.purchaseSales;
                        if (!string.IsNullOrWhiteSpace(filterModel.doc_date))
                            param.Value.DocDate = DateTime.Parse(filterModel.doc_date, new CultureInfo("tr-TR", true));
                        else
                            param.Value.DocDate = DateTime.Now.Date;

                        //Logger.WriteFileLog(new StringBuilder().Append("Belge no giden:").Append(Logger.ToJson(param)).ToString());

                        MobileWhouseService.ServiceResultOfString result = mobileWhouse.GetDocNoInfo(param);
                        if (result != null)
                        {
                            //Logger.WriteFileLog(new StringBuilder().Append("Belge no gelen:").Append(Logger.ToJson(result)).ToString());
                            if (result.Result)
                            {
                                return new ServiceResult<string>()
                                {
                                    Success = true,
                                    Result = result.Value,
                                    ErrorMessage = ""
                                }.ToString();
                            }
                            else
                            {
                                Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(result.Message).Append("Detay:").Append(Logger.ToXml(param)).ToString());
                                return new ServiceResult<string>()
                                {
                                    Success = false,
                                    Result = "",
                                    ErrorMessage = string.Concat("Sunucu hatası:", result.Message)
                                }.ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                return new ServiceResult<string>()
                {
                    Success = false,
                    Result = "",
                    ErrorMessage = string.Concat("Genel hata:", ex.Message)
                }.ToString();
            }
            finally
            {
            }
            return "";
        }

        //[WebMethod]
        public string GetCoEntityList(string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);

                    return QueryHelper.GetCoEntityList(filterModel, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string GetItemDemandList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    //conn = ConnectionHelper.Instance.GetConnection();
                    return QueryHelper.GetItemDemandList(token, filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string GetPurchaseOrderDList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetPurchaseOrderDList(token, filterModel, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string InsertTempDocumentMD(string tokenJson, string filterJson, string orderListJson)
        {
            ServiceResult<TempDocumentMModel> serviceResult = new ServiceResult<TempDocumentMModel>();

            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                    TempDocumentMModel masterTemp = new TempDocumentMModel();
                    masterTemp.BRANCH_ID = token.BranchId;
                    masterTemp.USER_ID = token.UserId;
                    masterTemp.WHOUSE_ID = token.WhouseId;
                    masterTemp.ENTITY_ID = filterModel.entity_id;

                    if (!String.IsNullOrEmpty(filterModel.doc_tra))
                    {
                        masterTemp.DOC_TRA_CODE = filterModel.doc_tra;
                    }

                    if (filterModel.purchaseSales == 0)
                    {
                        masterTemp.DOCUMENT_TYPE = 80;
                    }
                    else if (filterModel.purchaseSales == 1)
                    {
                        masterTemp.DOCUMENT_TYPE = 10;
                    }
                    else
                    {
                        masterTemp.DOCUMENT_TYPE = 40;
                    }

                    ServiceResult<TempDocumentMModel> masterResult = QueryHelper.InsertMasterTempDocument(masterTemp, data);

                    if (masterResult.Success && masterResult.Result != null)
                    {
                        masterTemp = masterResult.Result;
                        serviceResult.Result = masterResult.Result;
                        serviceResult.Success = masterResult.Success;
                        if (masterTemp.DOCUMENT_TYPE == 80)
                        {
                            List<ItemDemandDListModel> ItemDemandDList = new List<ItemDemandDListModel>();
                            ItemDemandDList = QueryHelper.GetItemDemandDList(filterModel.entity_id, data);
                            foreach (ItemDemandDListModel item in ItemDemandDList)
                            {
                                TempDocumentDModel detail = new TempDocumentDModel();
                                detail.BRANCH_ID = token.BranchId;
                                detail.DOCUMENT_M_ID = masterTemp.DOCUMENT_M_ID;
                                detail.ITEM_ID = item.ITEM_ID;
                                detail.LOT_ID = 0;
                                detail.ORDER_D_ID = item.ORDER_D_ID;
                                detail.ORDER_M_ID = item.ORDER_M_ID;
                                detail.QTY = item.QTY;
                                detail.QTY_PRM = item.QTY_PRM;
                                detail.QTY_READ = 0;
                                detail.SOURCE_D_ID = item.ORDER_D_ID;
                                detail.SOURCE_M_ID = item.ORDER_M_ID;
                                detail.UNIT_ID = item.UNIT_ID;
                                detail.UNIT_NAME = item.UNIT_CODE;
                                detail.USER_ID = token.UserId;
                                detail.WHOUSE_CODE = item.WHOUSE_CODE1;
                                detail.WHOUSE_CODE2 = item.WHOUSE_CODE2;
                                detail.DOC_DATE = item.DOC_DATE; //Talep Tarihi
                                detail.SHIPPING_DATE = item.SHIPPING_DATE; //Sevk Tarihi

                                detail.ATTRIBUTE1_ID = item.ITEM_ATTRIBUTE1_ID;
                                detail.ATTRIBUTE1_CODE = item.ITEM_ATTRIBUTE1_CODE;
                                detail.ATTRIBUTE2_ID = item.ITEM_ATTRIBUTE2_ID;
                                detail.ATTRIBUTE2_CODE = item.ITEM_ATTRIBUTE2_CODE;
                                detail.ATTRIBUTE3_ID = item.ITEM_ATTRIBUTE3_ID;
                                detail.ATTRIBUTE3_CODE = item.ITEM_ATTRIBUTE3_CODE;

                                detail.LOT_ID = item.LOT_ID;
                                //detail.LOT_CODE = item.LOT_CODE != null ? item.LOT_CODE : "";
                                detail.QUALITY_ID = item.QUALITY_ID;
                                detail.QUALITY_CODE = item.QUALITY_CODE;
                                detail.COLOR_ID = item.COLOR_ID;
                                detail.COLOR_CODE = item.COLOR_CODE;

                                ServiceResult<int> detailRes = QueryHelper.InsertDetailTempDocument(detail, data);
                                if (detailRes.Success != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(detailRes.ErrorMessage).Append("Detay:").Append(Logger.ToXml(detail)).ToString());
                                    serviceResult.Success = false;
                                    serviceResult.ErrorMessage = detailRes.ErrorMessage;
                                    QueryHelper.DeleteTempMaster(masterTemp, data);
                                }
                            }
                        }
                        else
                        {
                            List<PurchaseOrderDListModel> OrderDList = new List<PurchaseOrderDListModel>();
                            OrderDList = JsonConvert.DeserializeObject<List<PurchaseOrderDListModel>>(orderListJson);
                            foreach (PurchaseOrderDListModel item in OrderDList)
                            {
                                TempDocumentDModel detail = new TempDocumentDModel();
                                detail.BRANCH_ID = token.BranchId;
                                detail.DOCUMENT_M_ID = masterTemp.DOCUMENT_M_ID;
                                detail.ITEM_ID = item.ITEM_ID;
                                detail.LOT_ID = 0;
                                detail.ORDER_D_ID = item.ORDER_D_ID;
                                detail.ORDER_M_ID = item.ORDER_M_ID;
                                detail.QTY = item.QTY;
                                detail.QTY_PRM = item.QTY;
                                detail.SOURCE_D_ID = item.ORDER_D_ID;
                                detail.SOURCE_M_ID = item.ORDER_M_ID;
                                detail.UNIT_ID = item.UNIT_ID;
                                detail.USER_ID = token.UserId;
                                detail.DOC_DATE = item.DOC_DATE;
                                detail.DOC_NO = item.DOC_NO;
                                detail.DOC_DATE = item.DOC_DATE;

                                detail.ATTRIBUTE1_ID = item.ITEM_ATTRIBUTE1_ID;
                                detail.ATTRIBUTE1_CODE = item.ITEM_ATTRIBUTE1_CODE;
                                detail.ATTRIBUTE2_ID = item.ITEM_ATTRIBUTE2_ID;
                                detail.ATTRIBUTE2_CODE = item.ITEM_ATTRIBUTE2_CODE;
                                detail.ATTRIBUTE3_ID = item.ITEM_ATTRIBUTE3_ID;
                                detail.ATTRIBUTE3_CODE = item.ITEM_ATTRIBUTE3_CODE;

                                detail.LOT_ID = item.LOT_ID;
                                detail.LOT_CODE = item.LOT_CODE != null ? item.LOT_CODE : "";
                                detail.QUALITY_ID = item.QUALITY_ID;
                                detail.QUALITY_CODE = item.QUALITY_CODE;
                                detail.COLOR_ID = item.COLOR_ID;
                                detail.COLOR_CODE = item.COLOR_CODE;

                                ServiceResult<int> detailRes = QueryHelper.InsertDetailTempDocument(detail, data);
                                if (detailRes.Success != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(detailRes.ErrorMessage).Append("Detay:").Append(Logger.ToXml(detail)).ToString());
                                    serviceResult.Success = false;
                                    serviceResult.ErrorMessage = detailRes.ErrorMessage;
                                    QueryHelper.DeleteTempMaster(masterTemp, data);
                                }
                            }
                        }
                    }
                    else
                    {
                        serviceResult.Success = false;
                        serviceResult.ErrorMessage = masterResult.ErrorMessage;
                    }
                    serviceResult.Success = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message;
            }
            finally
            {

            }
            return serviceResult.ToString();
        }

        //[WebMethod]
        public string DocNoControl(string tokenJson, string filterJson, string t_controlDocNo)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    string tempM = JsonConvert.DeserializeObject<string>(t_controlDocNo);

                    return QueryHelper.DocNoControl(token, tempM, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                return new ServiceResult<bool> { Result = false, Success = false, ErrorMessage = ex.Message }.ToString();
            }
        }

        //[WebMethod]
        public string InsertTempDocumentM(string tokenJson, string filterJson, string tempDocumentMJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    TempDocumentMModel tempM = JsonConvert.DeserializeObject<TempDocumentMModel>(tempDocumentMJson);

                    return QueryHelper.InsertMasterTempDocument(tempM, data).ToString();
                }
                //return new QueryHelper().GetBranchList(conn);
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string UpdateTempDocumentM(string tokenJson, string filterJson, string tempDocumentMJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    TempDocumentMModel tempM = JsonConvert.DeserializeObject<TempDocumentMModel>(tempDocumentMJson);

                    DateTime date = DateTime.Parse(tempM.DOC_DATE, new CultureInfo("en-US", true));

                    return QueryHelper.UpdateTempMasterForSave(tempM, token.UserId, token.Password, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string getTempDocumentMList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetTempDocumentM(filterModel.id, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string getTempDocumentDList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetTempDocumentDList(token.UserId, token.BranchId, filterModel.id, data).ToString();//QueryHelper.GetTempDocumentDList(token.UserId, token.BranchId, filterModel.id,  data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string DeleteTempMaster(string tokenJson, string filterJson, string tempMModelJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    TempDocumentMModel tempM = JsonConvert.DeserializeObject<TempDocumentMModel>(tempMModelJson);
                    tempM = new TempDocumentMModel();
                    tempM.DOCUMENT_M_ID = filterModel.id;
                    return QueryHelper.DeleteTempMaster(tempM, data).ToString();//QueryHelper.DeleteTempMaster(tempM,  data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string DeleteTempDetail(string tokenJson, string filterJson, string tempMModelJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    TempDocumentDModel tempD = JsonConvert.DeserializeObject<TempDocumentDModel>(tempMModelJson);
                    return QueryHelper.DeleteTempDetail(tempD, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<bool> result = new ServiceResult<bool>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string GetDoctraList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetDocTraList(filterModel, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }
        //[WebMethod]
        public string GetAssetLocationList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetAssetLocationList(filterModel, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string searchAssetLocationMethod(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.searchAssetLocationMethod(filterModel, token, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string InsertOrDeleteTempD(string tokenJson, string filterJson, string tempDModelJson, int isDelete, int isAddDetail)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    TempDocumentDModel tempD = JsonConvert.DeserializeObject<TempDocumentDModel>(tempDModelJson);
                    if (isAddDetail == 1 && isDelete == 0)
                    {
                        return QueryHelper.InsertDetailTempDocument(tempD, data).ToString();
                    }
                    if (isDelete > 0)
                    {
                        return QueryHelper.DeleteTempDetailForItem(tempD, data).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<TempDocumentDModel> result = new ServiceResult<TempDocumentDModel>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }

            finally
            {

            }
            return null;

        }

        //[WebMethod]
        public string UpdateAssetLocation(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.UpdateAssetLocation(filterModel, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string searchItemMethod(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.searchItemMethod(filterModel, token, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<List<ItemBarcodeModel>> result = new ServiceResult<List<ItemBarcodeModel>>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }


        //[WebMethod]
        public string UpdateTempDetail(string tokenJson, string filterJson, string tempDModelJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    TempDocumentDModel tempD = JsonConvert.DeserializeObject<TempDocumentDModel>(tempDModelJson);

                    return QueryHelper.UpdateTempDetail(tempD, data).ToString();
                }

            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
            return null;
        }

        //[WebMethod]
        public string InsertUpdateTempDocumentDListWithTempD(string tokenJson,
                                                  string filterJson,
                                                  string tempDocumentDListJson,
                                                  string searchItemListJson,
                                                  int isDelete,
                                                  int isAddDetail,
                                                  int tempDocumentMId,
                                                  string tempDocumentMJson)
        {

            ServiceResult<List<TempDocumentDModel>> result = new ServiceResult<List<TempDocumentDModel>>();

            try
            {
                using (var data = new DataClient())
                {
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    string passwordHash = FormsAuthentication.HashPasswordForStoringInConfigFile(token.Password, "sha1");
                    string lResultJson = new LoginHelper().Login(token.Username, passwordHash, data);

                    ListFilterModel filter = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    List<TempDocumentDModel> tempDocumentDList = JsonConvert.DeserializeObject<List<TempDocumentDModel>>(tempDocumentDListJson);
                    List<ItemBarcodeModel> searchItemList = JsonConvert.DeserializeObject<List<ItemBarcodeModel>>(searchItemListJson);
                    TempDocumentMModel tempDocumentM = JsonConvert.DeserializeObject<TempDocumentMModel>(tempDocumentMJson);
                    tempDocumentDList = tempDocumentDList.OrderBy(x => x.ORDER_D_ID).ToList();
                    result.Success = true;
                    data.Begin();

                    if (!(tempDocumentDList != null))
                    {
                        tempDocumentDList = new List<TempDocumentDModel>();
                    }
                    if (searchItemList != null && searchItemList.Count > 0)
                    {
                        foreach (var searchItem in searchItemList)
                        {
                            //searchItem.insertedQty = 0;
                            if (tempDocumentDList.Where(x => x.ITEM_ID == searchItem.ITEM_ID && x.UNIT_ID == searchItem.UNIT_ID).ToList().Count > 0)
                            {
                                if (isDelete == 1)
                                {
                                    #region deleteSearchItem
                                    if (tempDocumentDList.Count > 0)
                                    {
                                        TempDocumentDModel tempDModel = new TempDocumentDModel();
                                        ServiceResult<List<TempDocumentDModel>> dListResult = new ServiceResult<List<TempDocumentDModel>>();
                                        decimal qty = searchItem.QTY;
                                        foreach (var tempD in tempDocumentDList.Where(x => x.ITEM_ID == searchItem.ITEM_ID && x.UNIT_ID == searchItem.UNIT_ID).OrderByDescending(x => x.QTY).ToList())
                                        {
                                            #region tempD
                                            tempDModel = new TempDocumentDModel();
                                            dListResult = new ServiceResult<List<TempDocumentDModel>>();

                                            foreach (var item in searchItemList)
                                            {
                                                if (tempD.ITEM_ID == item.ITEM_ID && tempD.UNIT_ID == item.UNIT_ID)
                                                {
                                                    tempDModel = new TempDocumentDModel
                                                    {

                                                        BRANCH_ID = token.BranchId,
                                                        DOCUMENT_M_ID = tempDocumentMId,
                                                        DOCUMENT_D_ID = tempD.DOCUMENT_D_ID,
                                                        ITEM_ID = searchItem.ITEM_ID,
                                                        ITEM_CODE = searchItem.ITEM_CODE,
                                                        ITEM_NAME = searchItem.ITEM_NAME,
                                                        UNIT_NAME = searchItem.UNIT_CODE,
                                                        UNIT_ID = searchItem.UNIT_ID,
                                                        QTY_READ = tempD.QTY_READ,
                                                        USER_ID = token.UserId,
                                                        BARCODE_NO = searchItem.BARCODE,
                                                        ATTRIBUTE1_ID = searchItem.ATTRIBUTE1_ID,
                                                        ATTRIBUTE1_CODE = searchItem.ATTRIBUTE1_CODE,
                                                        ATTRIBUTE2_ID = searchItem.ATTRIBUTE2_ID,
                                                        ATTRIBUTE2_CODE = searchItem.ATTRIBUTE2_CODE,
                                                        ATTRIBUTE3_ID = searchItem.ATTRIBUTE3_ID,
                                                        ATTRIBUTE3_CODE = searchItem.ATTRIBUTE3_CODE,
                                                        QUALITY_ID = searchItem.QUALITY_ID,
                                                        QUALITY_CODE = searchItem.QUALITY_CODE,
                                                        LOT_ID = searchItem.LOT_ID,
                                                        LOT_CODE = searchItem.LOT_CODE
                                                    };

                                                }
                                            }

                                            #region stokkod
                                            dListResult = QueryHelper.GetTempDControlByItem(tempDModel, token, data);

                                            if (dListResult.Success == true)
                                            {
                                                if (tempD.QTY_READ != 0)
                                                {
                                                    if (dListResult.Result.Count == 0)
                                                    {
                                                        throw new Exception("Önceki okutulan miktardan fazlası silinemez.");
                                                    }
                                                    else
                                                    {
                                                        if (searchItem.QTY > dListResult.Result.Sum(x => x.QTY_READ))
                                                        {
                                                            throw new Exception("Önceki okutulan miktardan fazlası silinemez.");
                                                        }
                                                        foreach (var tempDModelItem in dListResult.Result)
                                                        {
                                                            //tempD2Model = item;
                                                            if (qty > 0)
                                                            {
                                                                if (qty >= tempDModelItem.QTY_READ)
                                                                {

                                                                    tempD.QTY_READ = tempD.QTY_READ - searchItem.QTY;
                                                                    qty = qty - searchItem.QTY;

                                                                    if (isAddDetail == 0)
                                                                    {
                                                                        tempDModelItem.QTY_READ = tempDModelItem.QTY_READ - searchItem.QTY;
                                                                        var updatetempDResult = QueryHelper.UpdateTempDetail(tempDModelItem, data, true);

                                                                        if (updatetempDResult.Success == true)
                                                                        {

                                                                        }
                                                                        else
                                                                        {
                                                                            result.Success = false;
                                                                            result.ErrorMessage += updatetempDResult.ErrorMessage;
                                                                            throw new Exception(result.ErrorMessage);
                                                                        }
                                                                    }

                                                                }
                                                                else
                                                                {

                                                                    tempDModelItem.QTY_READ = tempDModelItem.QTY_READ - searchItem.QTY;
                                                                    var updatetempDResult = QueryHelper.UpdateTempDetail(tempDModelItem, data, true);
                                                                    if (updatetempDResult.Success == true)
                                                                    {
                                                                        tempD.QTY_READ = tempD.QTY_READ - searchItem.QTY;
                                                                        qty = 0;

                                                                        break;
                                                                    }
                                                                    else
                                                                    {
                                                                        result.Success = false;
                                                                        result.ErrorMessage += updatetempDResult.ErrorMessage;
                                                                        throw new Exception(result.ErrorMessage);
                                                                    }
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                            else
                                            {
                                                result.Success = false;
                                                result.ErrorMessage += dListResult.ErrorMessage;
                                                throw new Exception(result.ErrorMessage);
                                            }

                                            if (tempD.QTY_READ == 0 && isAddDetail == 1)
                                            {
                                                var deletetempDResult = QueryHelper.DeleteTempDetail(tempD, data);
                                                if (deletetempDResult.Success == true)
                                                {
                                                    tempDocumentDList.Remove(tempD);
                                                }
                                                else
                                                {
                                                    result.Success = false;
                                                    result.ErrorMessage += deletetempDResult.ErrorMessage;
                                                    throw new Exception(result.ErrorMessage);
                                                }
                                            }

                                            #endregion

                                            #endregion
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region updateTempDetail By Search Item
                                    ServiceResult<List<TempDocumentDModel>> dListResult;
                                    List<TempDocumentDModel> TempDocumentDIdList = new List<TempDocumentDModel>();
                                    TempDocumentDModel tempDModel = new TempDocumentDModel();
                                    decimal qty = searchItem.QTY;
                                    foreach (var tempD in tempDocumentDList)
                                    {
                                        foreach (var item in searchItemList)
                                        {
                                            dListResult = new ServiceResult<List<TempDocumentDModel>>();
                                            if (tempD.ITEM_ID == item.ITEM_ID && tempD.UNIT_ID == item.UNIT_ID)
                                            {
                                                if (tempD.QTY_PRM == 0 && isAddDetail == 1)
                                                {
                                                    tempDModel = new TempDocumentDModel
                                                    {

                                                        BRANCH_ID = token.BranchId,
                                                        DOCUMENT_M_ID = tempDocumentMId,
                                                        DOCUMENT_D_ID = tempD.DOCUMENT_D_ID,
                                                        ITEM_ID = searchItem.ITEM_ID,
                                                        ITEM_CODE = searchItem.ITEM_CODE,
                                                        ITEM_NAME = searchItem.ITEM_NAME,
                                                        UNIT_NAME = searchItem.UNIT_CODE,
                                                        UNIT_ID = searchItem.UNIT_ID,
                                                        QTY_READ = searchItem.QTY,
                                                        USER_ID = token.UserId,
                                                        BARCODE_NO = searchItem.BARCODE,
                                                        ATTRIBUTE1_ID = searchItem.ATTRIBUTE1_ID,
                                                        ATTRIBUTE1_CODE = searchItem.ATTRIBUTE1_CODE,
                                                        ATTRIBUTE2_ID = searchItem.ATTRIBUTE2_ID,
                                                        ATTRIBUTE2_CODE = searchItem.ATTRIBUTE2_CODE,
                                                        ATTRIBUTE3_ID = searchItem.ATTRIBUTE3_ID,
                                                        ATTRIBUTE3_CODE = searchItem.ATTRIBUTE3_CODE,
                                                        QUALITY_ID = searchItem.QUALITY_ID,
                                                        QUALITY_CODE = searchItem.QUALITY_CODE,
                                                        LOT_ID = searchItem.LOT_ID,
                                                        LOT_CODE = searchItem.LOT_CODE

                                                    };
                                                }


                                                if (tempD.QTY_READ + searchItem.QTY <= tempD.QTY_PRM && qty > 0 && filter.more_than_order_qty == 0)
                                                {
                                                    tempDModel = new TempDocumentDModel
                                                    {

                                                        BRANCH_ID = token.BranchId,
                                                        DOCUMENT_M_ID = tempDocumentMId,
                                                        DOCUMENT_D_ID = tempD.DOCUMENT_D_ID,
                                                        ITEM_ID = searchItem.ITEM_ID,
                                                        ITEM_CODE = searchItem.ITEM_CODE,
                                                        ITEM_NAME = searchItem.ITEM_NAME,
                                                        UNIT_NAME = searchItem.UNIT_CODE,
                                                        UNIT_ID = searchItem.UNIT_ID,
                                                        QTY_READ = searchItem.QTY,
                                                        USER_ID = token.UserId,
                                                        BARCODE_NO = searchItem.BARCODE,
                                                        ATTRIBUTE1_ID = searchItem.ATTRIBUTE1_ID,
                                                        ATTRIBUTE1_CODE = searchItem.ATTRIBUTE1_CODE,
                                                        ATTRIBUTE2_ID = searchItem.ATTRIBUTE2_ID,
                                                        ATTRIBUTE2_CODE = searchItem.ATTRIBUTE2_CODE,
                                                        ATTRIBUTE3_ID = searchItem.ATTRIBUTE3_ID,
                                                        ATTRIBUTE3_CODE = searchItem.ATTRIBUTE3_CODE,
                                                        QUALITY_ID = searchItem.QUALITY_ID,
                                                        QUALITY_CODE = searchItem.QUALITY_CODE,
                                                        LOT_ID = searchItem.LOT_ID,
                                                        LOT_CODE = searchItem.LOT_CODE
                                                    };
                                                    qty = qty - searchItem.QTY;
                                                }
                                                else if (filter.more_than_order_qty == 1)
                                                {
                                                    tempDModel = new TempDocumentDModel
                                                    {

                                                        BRANCH_ID = token.BranchId,
                                                        DOCUMENT_M_ID = tempDocumentMId,
                                                        DOCUMENT_D_ID = tempD.DOCUMENT_D_ID,
                                                        ITEM_ID = searchItem.ITEM_ID,
                                                        ITEM_CODE = searchItem.ITEM_CODE,
                                                        ITEM_NAME = searchItem.ITEM_NAME,
                                                        UNIT_NAME = searchItem.UNIT_CODE,
                                                        UNIT_ID = searchItem.UNIT_ID,
                                                        QTY_READ = searchItem.QTY,
                                                        USER_ID = token.UserId,
                                                        BARCODE_NO = searchItem.BARCODE,
                                                        ATTRIBUTE1_ID = searchItem.ATTRIBUTE1_ID,
                                                        ATTRIBUTE1_CODE = searchItem.ATTRIBUTE1_CODE,
                                                        ATTRIBUTE2_ID = searchItem.ATTRIBUTE2_ID,
                                                        ATTRIBUTE2_CODE = searchItem.ATTRIBUTE2_CODE,
                                                        ATTRIBUTE3_ID = searchItem.ATTRIBUTE3_ID,
                                                        ATTRIBUTE3_CODE = searchItem.ATTRIBUTE3_CODE,
                                                        QUALITY_ID = searchItem.QUALITY_ID,
                                                        QUALITY_CODE = searchItem.QUALITY_CODE,
                                                        LOT_ID = searchItem.LOT_ID,
                                                        LOT_CODE = searchItem.LOT_CODE
                                                    };
                                                }

                                            }

                                        }
                                    }


                                    #region stokkod
                                    dListResult = QueryHelper.GetTempDControlByItem(tempDModel, token, data);
                                    if (dListResult.Success == true)
                                    {
                                        if (dListResult.Result.Sum(x => x.QTY_READ) + searchItem.QTY > dListResult.Result.Sum(x => x.QTY_PRM) && dListResult.Result.Sum(x => x.QTY_PRM) != 0 && filter.more_than_order_qty == 0)
                                        {
                                            throw new Exception("Sipariş miktarından fazlası eklenemez.");
                                        }

                                        if (dListResult.Result.Count == 0)
                                        {
                                            var insertTempDResult = QueryHelper.InsertDetailTempDocument(tempDModel, data);
                                            if (insertTempDResult.Success == true)
                                            {
                                                tempDModel.DOCUMENT_D_ID = insertTempDResult.Result;
                                                TempDocumentDIdList.Add(tempDModel);
                                            }
                                            else
                                            {
                                                result.Success = false;
                                                result.ErrorMessage += insertTempDResult.ErrorMessage;
                                            }

                                        }
                                        else
                                        {
                                            tempDModel = dListResult.Result.FirstOrDefault();
                                            tempDModel.QTY_READ = tempDModel.QTY_READ + searchItem.QTY;
                                            var updatetempDResult = QueryHelper.UpdateTempDetail(tempDModel, data);
                                            if (updatetempDResult.Success == true)
                                            {

                                            }
                                            else
                                            {
                                                result.Success = false;
                                                result.ErrorMessage += updatetempDResult.ErrorMessage;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        result.Success = false;
                                        result.ErrorMessage += dListResult.ErrorMessage;
                                    }
                                    #endregion

                                    if (result.Success != true)
                                    {
                                        foreach (var item in TempDocumentDIdList)
                                        {
                                            QueryHelper.DeleteTempDetail(item, data);
                                        }
                                    }
                                    else
                                    {
                                        result = QueryHelper.GetTempDocumentDTableItemList(token, data, tempDocumentMId, new ListFilterModel { });
                                        tempDocumentDList = result.Result;

                                    }

                                    #endregion
                                }
                            }
                            else
                            {
                                #region insertTempDetail 
                                if (isAddDetail == 1 && isDelete == 0)
                                {
                                    TempDocumentDModel tempDocumentD = new TempDocumentDModel();
                                    tempDocumentD.BRANCH_ID = token.BranchId;
                                    tempDocumentD.DOCUMENT_M_ID = tempDocumentMId;
                                    tempDocumentD.ITEM_ID = searchItem.ITEM_ID;
                                    tempDocumentD.ITEM_CODE = searchItem.ITEM_CODE;
                                    tempDocumentD.ITEM_NAME = searchItem.ITEM_NAME;
                                    tempDocumentD.UNIT_NAME = searchItem.UNIT_CODE;
                                    tempDocumentD.UNIT_ID = searchItem.UNIT_ID;
                                    tempDocumentD.QTY_READ = searchItem.QTY;
                                    tempDocumentD.USER_ID = token.UserId;
                                    tempDocumentD.BARCODE_NO = searchItem.BARCODE;
                                    tempDocumentD.ATTRIBUTE1_ID = searchItem.ATTRIBUTE1_ID;
                                    tempDocumentD.ATTRIBUTE1_CODE = searchItem.ATTRIBUTE1_CODE;
                                    tempDocumentD.ATTRIBUTE2_ID = searchItem.ATTRIBUTE2_ID;
                                    tempDocumentD.ATTRIBUTE2_CODE = searchItem.ATTRIBUTE2_CODE;
                                    tempDocumentD.ATTRIBUTE3_ID = searchItem.ATTRIBUTE3_ID;
                                    tempDocumentD.ATTRIBUTE3_CODE = searchItem.ATTRIBUTE3_CODE;
                                    tempDocumentD.QUALITY_ID = searchItem.QUALITY_ID;
                                    tempDocumentD.QUALITY_CODE = searchItem.QUALITY_CODE;
                                    tempDocumentD.LOT_ID = searchItem.LOT_ID;
                                    tempDocumentD.LOT_CODE = searchItem.LOT_CODE;

                                    if (searchItem.BARCODE != null)
                                    {
                                        tempDocumentD.BARCODE_NO = searchItem.BARCODE;
                                    }
                                    ServiceResult<int> tempDocumentDInsertResult = QueryHelper.InsertDetailTempDocument(tempDocumentD, data);
                                    if (tempDocumentDInsertResult.Success)
                                    {
                                        if (tempDocumentDInsertResult.Result > 0)
                                        {
                                            tempDocumentD.DOCUMENT_D_ID = tempDocumentDInsertResult.Result;
                                        }
                                        if (tempDocumentD.DOCUMENT_D_ID > 0)
                                        {
                                            tempDocumentDList.Add(tempDocumentD);

                                        }

                                    }
                                    else
                                    {
                                        throw new Exception("Detay kaydedilemedi.Hata:" + tempDocumentDInsertResult.ErrorMessage);

                                    }

                                }
                                else
                                {
                                    throw new Exception("Okutulan Stok Listede Bulunamamıştır.");

                                }
                                #endregion
                            }
                        }
                    }
                    data.Commit();
                    result.Result = tempDocumentDList;
                    #region mainAppProcess
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {


            }
            return result.ToString();
        }

        //[WebMethod]
        public string GetDoctra2List(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetDocTra2List(filterModel, token, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }


        [WebMethod(Description = "Depo Stok Bilgisi")]
        public string GetBwhItemInfo(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetBwhItemInfo(filterModel, token, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string GetItemInfo(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetItemInfo(filterModel, token, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string GetLocationInfoList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetLocationInfoList(filterModel, token, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string GetTempDocumentMForHalfDocument(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetTempDocumentMForHalfDocument(token.UserId, data).ToString();
                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string TransferTempDocument(string tokenJson, string filterJson)
        {
            TempDocumentMModel tempM;
            object sendObj = null;
            try
            {
                using (var data = new DataClient())
                {
                    data.Begin();
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    SenfoniGS.GeneralSenfoniService senfoniService = GetSenfoniService();
                    SaveService.UyumSaveWebService saveService = GetUyumSaveWebService();

                    ServiceResult<List<TempDocumentMModel>> tempMResult = QueryHelper.GetTempDocumentM(filterModel.id, data);
                    var result = new ServiceResult<TempDocumentMModel>();
                    if (tempMResult.Success == true && tempMResult.Result.Count > 0)
                    {
                        ServiceResult<CompanyModel> companyModel = QueryHelper.GetCompany(token.CoId, data);

                        tempM = tempMResult.Result.FirstOrDefault();
                        var tempDResult = QueryHelper.GetTempDocumentDList(token.UserId, token.BranchId, filterModel.id, data);
                        List<TempDocumentDModel> tempD = tempDResult.Result.Where(x => x.QTY_READ > 0).ToList();
                        if (tempDResult.Success == true)
                        {
                            #region SatınalmaSiparişi

                            if (tempM.DOCUMENT_TYPE == 10)
                            {

                                ServiceRequestOfItemDef x = ConvertToItemDefMethod(token, tempM, tempD, 1, 0, 0, 0, SourceApplication.SatınalmaSiparişi, true, data);
                                sendObj = x;
                                var resultSenfoni = senfoniService.SaveWaybill(x);

                                if (resultSenfoni.Result != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(resultSenfoni.Message).Append(",Detay:").Append(Logger.ToJson(x)).ToString());
                                    throw new Exception(resultSenfoni.Message);

                                }
                            }
                            #endregion


                            #region DirektKabul

                            else if (tempM.DOCUMENT_TYPE == 20)
                            {

                                //IsWaybill False Olabilir
                                ServiceRequestOfItemDef x = ConvertToItemDefMethod(token, tempM, tempD, 0, companyModel.Result.CUR_ID, 0, 1, SourceApplication.İrsaliye, true, data);
                                sendObj = x;
                                var resultSenfoni = senfoniService.SaveWaybill(x);
                                if (resultSenfoni.Result != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(resultSenfoni.Message).Append("Detay:").Append(Logger.ToXml(x)).ToString());
                                    throw new Exception(resultSenfoni.Message);

                                }
                            }
                            #endregion


                            #region DepoSayim

                            else if (tempM.DOCUMENT_TYPE == 30)
                            {


                                ServiceRequestOfItemDef x = ConvertToItemDefMethod(token, tempM, tempD, 0, 0, 0, 0, SourceApplication.DepoSayim, true, data);
                                sendObj = x;
                                var resultSenfoni = senfoniService.SaveCycleCountM(x);
                                if (resultSenfoni.Result != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(resultSenfoni.Message).Append("Detay:").Append(Logger.ToXml(x)).ToString());
                                    throw new Exception(resultSenfoni.Message);

                                }
                            }
                            #endregion


                            #region SatışSiparişi

                            else if (tempM.DOCUMENT_TYPE == 40)
                            {



                                ServiceRequestOfItemDef x = ConvertToItemDefMethod(token, tempM, tempD, 2, 0, 0, 0, SourceApplication.SatışSiparişi, true, data);
                                sendObj = x;
                                var resultSenfoni = senfoniService.SaveWaybill(x);
                                if (resultSenfoni.Result != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(resultSenfoni.Message).Append("Detay:").Append(Logger.ToXml(x)).ToString());
                                    throw new Exception(resultSenfoni.Message);

                                }
                            }

                            #endregion


                            #region DirektSevk

                            else if (tempM.DOCUMENT_TYPE == 50)
                            {


                                ServiceRequestOfItemDef x = ConvertToItemDefMethod(token, tempM, tempD, 0, companyModel.Result.CUR_ID, 0, 1, SourceApplication.İrsaliye, true, data);
                                sendObj = x;
                                var resultSenfoni = senfoniService.SaveWaybill(x);
                                if (resultSenfoni.Result != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(resultSenfoni.Message).Append("Detay:").Append(Logger.ToXml(x)).ToString());
                                    throw new Exception(resultSenfoni.Message);

                                }
                            }
                            #endregion


                            #region StokHareket

                            else if (tempM.DOCUMENT_TYPE == 60)
                            {
                                ServiceRequestOfItemDef x = ConvertToItemDefMethod(token, tempM, tempD, 0, companyModel.Result.CUR_ID, 0, 1, SourceApplication.Stok, false, data);
                                sendObj = x;


                                var resultSenfoni = senfoniService.SaveItemM(x);
                                if (resultSenfoni.Result != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(resultSenfoni.Message).Append("Detay:").Append(Logger.ToJson(x)).ToString());
                                    throw new Exception(resultSenfoni.Message);
                                }
                            }
                            #endregion


                            #region Sabit Kıymet Sayım

                            else if (tempM.DOCUMENT_TYPE == 70)
                            {

                                ServiceResult<int> AssetCountMResult = QueryHelper.InsertAssetCountM(tempM, token, data);
                                sendObj = tempM;
                                if (AssetCountMResult.Success)
                                {
                                    foreach (var item in tempD)
                                    {
                                        item.ASSET_CARD_COUNT_M_ID = AssetCountMResult.Result;
                                        ServiceResult<int> AssetCountDResult = QueryHelper.InsertAssetCountD(item, token, data);
                                        if (AssetCountDResult.Success == false)
                                        {
                                            Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(AssetCountDResult.ErrorMessage).Append("Detay:").Append(Logger.ToXml(item)).ToString());
                                            throw new Exception("Geçici Belge Kaydedilirken Hata:" + AssetCountDResult.ErrorMessage);
                                        }

                                    }

                                }

                            }
                            #endregion

                            #region Mal Talep Sevk

                            else if (tempM.DOCUMENT_TYPE == 80)
                            {
                                SaveService.UyumServiceRequestOfString x = ConvertToStringMethod(token, tempM, tempD, 1, 0, 0, 0, SourceApplication.SatınalmaSiparişi, true);

                                sendObj = x;

                                var resultSenfoni = saveService.SaveUyumObjectFromXML(x);

                                if (resultSenfoni.Success != true)
                                {
                                    Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(resultSenfoni.Message).Append(",Detay:").Append(Logger.ToJson(x)).ToString());
                                    throw new Exception(resultSenfoni.Message);
                                }
                            }
                            #endregion
                        }

                        else
                        {
                            throw new Exception(tempDResult.ErrorMessage);

                        }
                    }
                    else
                    {
                        throw new Exception(string.Concat("Belge detayları bulunamadı!", tempMResult.ErrorMessage));

                    }


                    data.Commit();

                    ServiceResult<TempDocumentMModel> DeleteMasterResult = QueryHelper.DeleteTempMaster(tempM, data);
                    if (DeleteMasterResult.Success == false)
                    {
                        Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(DeleteMasterResult.ErrorMessage).Append("Detay:").Append(Logger.ToXml(tempM)).ToString());
                        throw new Exception(DeleteMasterResult.ErrorMessage);

                    }
                    result.Result = tempMResult.Result.FirstOrDefault();
                    result.Success = true;
                    return result.ToString();

                    //return new QueryHelper().GetBranchList(conn);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).AppendLine().Append("Detay:").Append(ex.StackTrace).AppendLine().Append("Giden:").Append(Logger.ToJson(sendObj)).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        public ServiceRequestOfItemDef ConvertToItemDefMethod(Token token, TempDocumentMModel tempM, List<TempDocumentDModel> tempD, int PurchaseSales, int CurId, int CurRateTypeId, decimal CurTra, SourceApplication sourceApp, bool IsWaybill, DataClient conn)
        {
            ServiceRequestOfItemDef x = new ServiceRequestOfItemDef();
            x.Value = new ItemDef();
            x.Token = new SenfoniGS.Token();

            x.Value.Details = new List<ItemDetailDef>().ToArray();
            List<ItemDetailDef> detailList = new List<ItemDetailDef>();
            x.Value.CoId = token.CoId;
            x.Value.BranchId = tempM.BRANCH_ID;
            x.Value.DocTraId = tempM.TRANSACTION_ID > 0 && tempM.DOC_TRA_ID == 0 ? tempM.TRANSACTION_ID : tempM.DOC_TRA_ID;
            x.Value.EntityId = tempM.ENTITY_ID;
            x.Value.CreateUserId = tempM.USER_ID;
            x.Value.WhouseId = tempM.WHOUSE_ID;
            x.Value.WhouseId2 = tempM.WHOUSE_ID2;

            var costCenterCode = "";//Transfer
            if (tempM.DOCUMENT_TYPE == 60)
                costCenterCode = SarfCikisHelper.CostCenterCode(tempM.WHOUSE_ID, conn);

            x.Value.SourceApp = sourceApp;
            x.Value.SourceApp3 = sourceApp;

            DateTime date = DateTime.Now;
            if (DateTime.TryParse(tempM.DOC_DATE, CultureInfo.CreateSpecificCulture("tr-TR"), DateTimeStyles.None, out date))
                date = DateTime.Now.Date;

            x.Value.DocDate = date;
            x.Value.ReceiptDate = date;
            x.Value.DocNo = tempM.DOC_NO;
            x.Value.IsDocDifferentCur = false;
            if (tempM.DOC_NO_ID > 0)
                x.Value.DocNumberDId = tempM.DOC_NO_ID;

            if (!string.IsNullOrWhiteSpace(tempM.SERIAL_NUMBER))
            {
                if (tempM.SERIAL_NUMBER.Length > 3)
                    x.Value.VoucherSerial = tempM.SERIAL_NUMBER.Substring(0, 3);
                else
                    x.Value.VoucherSerial = tempM.SERIAL_NUMBER;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tempM.DOC_NO))
                {
                    x.Value.VoucherSerial = tempM.DOC_NO.Substring(0, 2);
                }
            }

            x.Value.VoucherNo = tempM.SORT_NO;
            x.Value.Note1 = tempM.NOTE_LARGE;
            x.Token.BranchId = tempM.BRANCH_ID;
            x.Token.UserName = token.Username;
            x.Token.Password = token.Password;
            x.Token.CoId = token.CoId;
            x.Value.IsWaybil = IsWaybill;
            x.Value.ProjectMId = tempM.PROJECT_M_ID;

            if (CurId > 0)
            {
                x.Value.CurId = CurId;
                x.Value.CurRateTypeId = CurRateTypeId;
                x.Value.CurTra = CurTra;

            }

            int lineNo = 10;
            foreach (var item in tempD)
            {
                ItemDetailDef detail = new ItemDetailDef();

                detail.WhouseId = tempM.WHOUSE_ID;
                detail.UnitId = item.UNIT_ID;
                detail.LotId = item.LOT_ID;
                detail.DcardId = item.ITEM_ID;
                detail.LineNo = lineNo;
                detail.Qty = item.QTY_READ;
                detail.QtyPrm = item.QTY_READ;
                detail.Barcode = item.BARCODE_NO;

                detail.ItemAttribute1Id = item.ATTRIBUTE1_ID;
                detail.ItemAttribute2Id = item.ATTRIBUTE2_ID;
                detail.ItemAttribute3Id = item.ATTRIBUTE3_ID;
                detail.QualityId = item.QUALITY_ID;
                detail.LotId = item.LOT_ID;
                detail.ColorId = item.COLOR_ID;
                detail.CostCenterCode = costCenterCode;

                if (tempM.DOCUMENT_TYPE == 10 || tempM.DOCUMENT_TYPE == 20)
                {
                    if (!string.IsNullOrWhiteSpace(item.LOT_CODE) && item.LOT_ID == 0)
                    {
                        detail.IsLotGenerate = true;
                        detail.LotCode = item.LOT_CODE;
                    }
                }

                if (PurchaseSales > 0)
                {
                    ListFilterModel filterModel = new ListFilterModel();
                    filterModel.id = item.SOURCE_D_ID;
                    filterModel.branch_id = tempM.BRANCH_ID;
                    filterModel.entity_id = tempM.ENTITY_ID;
                    filterModel.purchaseSales = PurchaseSales;
                    ServiceResult<PurchaseOrderDListModel> orderD = QueryHelper.GetPurchaseOrderD(token, filterModel, conn);
                    detail.CurTraId = orderD.Result.CUR_TRA_ID;
                    detail.CurRateTra = orderD.Result.CUR_RATE_TRA;
                    detail.CurRateTypeId = orderD.Result.CUR_RATE_TYPE_ID;
                    detail.Amt = orderD.Result.UNIT_PRICE * item.QTY_READ * detail.CurRateTra;
                    detail.AmtTra = orderD.Result.UNIT_PRICE * item.QTY_READ;
                    detail.UnitPrice = orderD.Result.UNIT_PRICE;
                    detail.SourceMId = item.SOURCE_M_ID;
                    detail.SourceDId = item.SOURCE_D_ID;
                    detail.Note2 = "El terminalinden oluşturuldu";
                    detail.SourceApp = sourceApp;

                    x.Value.CurId = orderD.Result.CUR_TRA_ID;
                    x.Value.CurRateTypeId = orderD.Result.CUR_RATE_TYPE_ID;
                    x.Value.CurTra = orderD.Result.CUR_RATE_TRA;

                    x.Value.DueDate = orderD.Result.DUE_DATE;
                    x.Value.DueDay = orderD.Result.DUE_DAY;



                }


                if (CurId > 0)
                {
                    detail.CurTraId = CurId;
                    detail.CurRateTypeId = CurRateTypeId;
                    detail.CurRateTra = CurTra;
                }

                x.Value.SourceMId = detail.SourceMId;

                detailList.Add(detail);
                lineNo += 10;
            }
            x.Value.Details = detailList.ToArray();



            return x;
        }

        public SaveService.UyumServiceRequestOfString ConvertToStringMethod(Token token, TempDocumentMModel tempM, List<TempDocumentDModel> tempD, int PurchaseSales, int CurId, int CurRateTypeId, decimal CurTra, SourceApplication sourceApp, bool IsWaybill)
        {
            SaveService.UyumServiceRequestOfString x = new SaveService.UyumServiceRequestOfString();
            x.Token = new SaveService.UyumToken();
            ItemDemandObject itemDemand = new ItemDemandObject();

            x.Token.UserName = token.Username;
            x.Token.Password = token.Password;

            List<ItemDemandDetailObject> detailList = new List<ItemDemandDetailObject>();

            itemDemand.Type = "INV.ItemDemand3M, INV";
            itemDemand.BranchCode = token.BranchCode;
            itemDemand.BranchCode2 = token.BranchCode;
            itemDemand.CoCode = token.CoCode;
            itemDemand.DocNo = tempM.DOC_NO;
            itemDemand.SourceApp = SaveService.SourceApplication.Stok;
            itemDemand.SourceApp2 = SaveService.SourceApplication.MalTalepSevk;
            itemDemand.DocTraWaybillCode = tempM.DOC_TRA_CODE;

            //itemDemand.ConfirmNo = tempM.conf
            //itemDemand.DemandStatu = tempM.
            //itemDemand.PlanUserFullname = 
            //itemDemand.AmtTra = tempM.

            DateTime date = DateTime.Now;
            if (DateTime.TryParse(tempM.DOC_DATE, CultureInfo.CreateSpecificCulture("tr-TR"), DateTimeStyles.None, out date))
                date = DateTime.Now.Date;

            itemDemand.DocDate = date;

            int lineNo = 10;
            foreach (var item in tempD)
            {
                ItemDemandDetailObject detail = new ItemDemandDetailObject();

                detail.DetailProperty = "ItemDemand3DCollection";
                detail.DocDate = item.DOC_DATE;
                detail.BranchCode = token.BranchCode;
                detail.BranchCode2 = token.BranchCode;
                detail.CoCode = token.CoCode;
                detail.ItemCode = item.ITEM_CODE;
                detail.LineNo = lineNo;
                detail.Qty = item.QTY;
                detail.QtyConfirm = item.QTY_PRM;
                detail.QtyPrm = item.QTY_PRM;
                detail.QtyShipping = item.QTY_READ;
                detail.UnitCode = item.UNIT_NAME;
                detail.WhouseCode = item.WHOUSE_CODE;
                //detail.ShippingDate = item;

                //itemDemand.WhouseCode = item.WHOUSE_CODE2;
                //itemDemand.DemandDate = item.

                //detail.AmtTra
                //detail.BwhQtyPrm = item.qty
                //detail.CurTraCode = item.c
                //detail.UnitPrice = item.;

                //itemDemand.ConfirmNo = tempD.

                detailList.Add(detail);
                lineNo += 10;
            }

            itemDemand.UyumDetailItem = detailList.ToArray();

            XmlSerializer xsSubmit = new XmlSerializer(typeof(ItemDemandObject));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, itemDemand);
                    xml = sww.ToString(); // Your XML
                }
            }

            x.Value = xml;

            return x;
        }


        //[WebMethod]
        public string GetProjectList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                    return QueryHelper.GetProjectList(token, filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string GetBwhItemList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                    return QueryHelper.GetBwhItemList(token, filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string GetVehicleList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    return QueryHelper.GetVehicleList(token, filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
        }

        //[WebMethod]
        public string GetOrderList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    Logger.WriteFileLog(new StringBuilder().Append("Siapriş Liste 1:").Append(Logger.ToJson(filterJson)).ToString());
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                    return QueryHelper.GetOrderMList(token, filterModel, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
            return null;
        }

        //[WebMethod]
        public string GetOrderDList(string tokenJson, string filterJson)
        {
            try
            {
                Logger.WriteFileLog(new StringBuilder().Append("Sipariş Detay:").Append(Logger.ToJson(filterJson)).ToString());
                ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                List<ReferralOrderDetail> resp = new List<ReferralOrderDetail>();

                UTerminalService.ServiceRequestOfSelectParam param = new UTerminalService.ServiceRequestOfSelectParam();
                param.Token = new UTerminalService.Token();
                param.Token.UserName = token.Username;
                param.Token.Password = token.Password;
                param.Token.BranchId = token.BranchId;
                param.Token.CoId = token.CoId;
                param.Value = new UTerminalService.SelectParam();
                param.Value.InfoId = filterModel.item_id;

                UTerminalService.ServiceResultOfListOfReferralDetailInfo result = GetUTerminalService().GetOrderDetails(param);

                ServiceResult<List<ReferralOrderDetail>> res = new ServiceResult<List<ReferralOrderDetail>>();

                if (result != null)
                {
                    //Logger.WriteFileLog(new StringBuilder().Append("Ambalaj bilgisi:").Append("Detay:").Append(Logger.ToXml(result)).ToString());
                    res.Success = result.Result;
                    if (result.Result)
                    {
                        resp = new List<ReferralOrderDetail>();
                        foreach (var item in result.Value)
                        {
                            ReferralOrderDetail detailInf = new ReferralOrderDetail();

                            detailInf.SourceDId = item.ReferralDetailId;
                            detailInf.SourceMId = item.ReferralMasterId;
                            detailInf.EntityId = item.PackageTypeId;
                            detailInf.EntityName = item.PackageTypeCode;
                            detailInf.DocDate = item.ArrivalDate;
                            detailInf.DocNo = item.OrderNo;
                            detailInf.Qty = item.QtyOrder;
                            detailInf.QtyShipping = item.QtyReferral;
                            resp.Add(detailInf);

                        }
                    }

                    res.ErrorMessage = result.Message;
                }
                else
                {
                    res.Success = false;
                    res.ErrorMessage = "Sunucu yanıt vermedi!";
                }
                res.Result = resp;

                return res.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
            return null;
        }

        //[WebMethod]
        public string CreateDocNo(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    ServiceResult<string> serviceResult = QueryHelper.GetCycleDocNo(data);
                    if (serviceResult != null)
                    {
                        //Logger.WriteFileLog(new StringBuilder().Append("Belge no gelen:").Append(Logger.ToJson(result)).ToString());
                        if (serviceResult.Success)
                        {
                            return new ServiceResult<string>()
                            {
                                Success = true,
                                Result = serviceResult.Result,
                                ErrorMessage = serviceResult.ErrorMessage
                            }.ToString();
                        }
                        else
                        {
                            Logger.WriteFileLog(new StringBuilder().Append("Sunucu hatası:").Append(serviceResult.ErrorMessage).Append("Detay:").Append(Logger.ToXml(serviceResult)).ToString());
                            return new ServiceResult<string>()
                            {
                                Success = false,
                                Result = "",
                                ErrorMessage = string.Concat("Sunucu hatası:", serviceResult.ErrorMessage)
                            }.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                return new ServiceResult<string>()
                {
                    Success = false,
                    Result = "",
                    ErrorMessage = string.Concat("Genel hata:", ex.Message)
                }.ToString();
            }
            finally
            {
            }
            return "";
        }

        //[WebMethod]
        public string searchPackageMethod(string tokenJson, string filterJson)
        {
            try
            {
                PackageFilterModel filterModel = JsonConvert.DeserializeObject<PackageFilterModel>(filterJson);
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                PackageHelper packageUtil = new PackageHelper(GetUTerminalService());
                if (filterModel.ProcessType == PackageHelper.AMBALAJ_BUL)//Ambalaj sorgulama
                {
                    ServiceResult<List<PackageDetailModel>> res = packageUtil.GetPackageInfo(token.Username, token.Password, filterModel.WhouseId, filterModel.PackageNo);
                    return res.ToString();
                }
                else if (filterModel.ProcessType == PackageHelper.AMBALAJ_TRANSFER)//Ambalaj transfer kayit
                {
                    ServiceResult<List<PackageDetailModel>> res = packageUtil.CreatePackageTraMTransfer(token, filterModel.WhouseId, filterModel.Whouse2Id, filterModel.DocDate, filterModel.DocNo, filterModel.PackageDList);
                    return res.ToString();
                }
                else if (filterModel.ProcessType == PackageHelper.AMBALAJ_TRANSFER || filterModel.ProcessType == PackageHelper.AMBALAJ_OLUSTUR)//Ambalaj oluştur kayit
                {
                    ServiceResult<List<PackageDetailModel>> res = packageUtil.CreatePackageTraM(token, filterModel.WhouseId, filterModel.Whouse2Id, filterModel.DocDate, filterModel.DocNo, filterModel.PackageM, filterModel.PackageDList);
                    return res.ToString();
                }
                else if (filterModel.ProcessType == PackageHelper.AMBALAJ_SAYIM)//Ambalaj sayim kayit
                {
                    ServiceResult<List<PackageDetailModel>> res = packageUtil.CreatePackageCycleCountM(token, filterModel.WhouseId, filterModel.DocNo, filterModel.DocDate, filterModel.Note, filterModel.PackageDList);
                    return res.ToString();
                }
                else if (filterModel.ProcessType == PackageHelper.AMBALAJ_COZ) // ambalaj cozme
                {
                    ServiceResult<List<PackageDetailModel>> res = packageUtil.RevortPackage(token.Username, token.Password, filterModel.WhouseId, filterModel.PackageDId, filterModel.PackageNo);
                    return res.ToString();
                }
                else if (filterModel.ProcessType == PackageHelper.AMBALAJLARI_AL)
                {
                    ServiceResult<List<PackageDetailModel>> res = packageUtil.GetPackageMList(token, filterModel.WhouseId, filterModel.PackageNo);
                    res.Success = true;
                    return res.ToString();
                }
                else if (filterModel.ProcessType == PackageHelper.COZ_DEPO)
                {
                    ServiceResult<List<PackageDetailModel>> res = packageUtil.GetRevortDepots();
                    res.Result = new List<PackageDetailModel>();
                    res.Success = true;
                    return res.ToString();
                }
                else
                {
                    ServiceResult<List<PackageDetailModel>> res = new ServiceResult<List<PackageDetailModel>>();
                    res.Result = new List<PackageDetailModel>();
                    res.Success = false;
                    res.ErrorMessage = "Bilinmeyen metod";
                    return res.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                return new ServiceResult<List<PackageDetailModel>>(ex).ToString();
            }
            finally
            {

            }
            return null;
        }

        //[WebMethod]
        public string GetRecordList(string tokenJson, string filterJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    Logger.WriteFileLog(new StringBuilder().Append("Kayıt Listesi: ").Append(Logger.ToJson(filterJson)).ToString());
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    JsonSerializerSettings serializeOptions = new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        NullValueHandling = NullValueHandling.Ignore,
                    };
                    string response = QueryHelper.GetRecords(token, filterModel, data).ToString();

                    Trace.WriteLine(response);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
            return null;
        }

        //[WebMethod]
        public string ErmasPaletSevk(string tokenJson, string filterJson, string tempDocumentMJson)
        {
            try
            {
                using (var data = new DataClient())
                {
                    ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                    Token token = JsonConvert.DeserializeObject<Token>(tokenJson);
                    TempDocumentMModel tempM = JsonConvert.DeserializeObject<TempDocumentMModel>(tempDocumentMJson);

                    return QueryHelper.InsertErmasPaletSevk(tempM, token.UserId, token.Username, token.Password, data).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {

            }
        }

        //[WebMethod]
        public string GetPackageTypes(string tokenJson, string filterJson)
        {
            try
            {
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                JsonSerializerSettings serializeOptions = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    NullValueHandling = NullValueHandling.Ignore,
                };

                PackageHelper packageUtil = new PackageHelper(GetUTerminalService());

                string response = packageUtil.GetPackageTypes(token).ToString();

                Trace.WriteLine(response);

                return response;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
            return null;
        }

        //[WebMethod]
        public string GetPackageMInfo(string tokenJson, string filterJson)
        {
            try
            {

                ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                JsonSerializerSettings serializeOptions = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    NullValueHandling = NullValueHandling.Ignore,
                };

                PackageHelper packageUtil = new PackageHelper(GetUTerminalService());

                string response = packageUtil.GetPackageMInfo(token, filterModel.barcode).ToString();

                Trace.WriteLine(response);

                return response;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                //EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error, 1);
                //return ex.Message;
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
            }
            return null;
        }

        //[WebMethod]
        public string PrintBarcode(string tokenJson, string filterJson)
        {
            IDbConnection conn = null;
            try
            {
                ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                JsonSerializerSettings serializeOptions = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    NullValueHandling = NullValueHandling.Ignore,
                };

                PackageHelper packageUtil = new PackageHelper(GetUTerminalService());

                string response = packageUtil.PrintBarcode(token, filterModel.barcode).ToString();

                Trace.WriteLine(response);

                return response;
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                ServiceResult<int> result = new ServiceResult<int>();
                result.Success = false;
                result.ErrorMessage = ex.Message;
                return result.ToString();
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
            return null;
        }

        //[WebMethod]
        public string GetReferralOrders(string tokenJson, string filterJson)
        {
            var serviceResult = new ServiceResult<List<ReferralOrder>>();
            try
            {
                Logger.WriteFileLog(new StringBuilder().Append("Siapriş Liste 1:").Append(Logger.ToJson(filterJson)).ToString());

                ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                var prm = new UTerminalService.ServiceRequestOfSelectParam();
                prm.Token = (UTerminalService.Token)token;
                prm.Value = new UTerminalService.SelectParam();
                prm.Value.DepotId = filterModel.filterId;
                prm.Value.IsItemPicking = 0;
                prm.Value.SearchEntity = filterModel.searchText;

                var refferalorders = GetUTerminalService().GetReferralOrders(prm);

                if (refferalorders != null)
                {
                    if (refferalorders.Result)
                    {
                        serviceResult.Success = true;
                        serviceResult.ErrorMessage = refferalorders.Message;
                        serviceResult.Result = new List<ReferralOrder>();

                        for (int t = 0; t < refferalorders.Value.Length; t++)
                        {
                            var orderM = new ReferralOrder();
                            orderM.OrderMId = refferalorders.Value[t].Id;
                            orderM.DocNo = refferalorders.Value[t].DocNo;
                            orderM.ShippingAddress1 = refferalorders.Value[t].ShippingAddress1;
                            orderM.ShippingAddress2 = refferalorders.Value[t].ShippingAddress2;
                            orderM.ShippingAddress3 = refferalorders.Value[t].ShippingAddress3;
                            orderM.TransporterCode = refferalorders.Value[t].TransporterCode;
                            orderM.TransporterDesc = refferalorders.Value[t].TransporterDesc;
                            orderM.TransportTypeCode = refferalorders.Value[t].TransportTypeCode;
                            orderM.TransportTypeDesc = refferalorders.Value[t].TransportTypeDesc;
                            orderM.EntityId = refferalorders.Value[t].EntityId;
                            orderM.EntityCode = refferalorders.Value[t].EntityCode;
                            orderM.EntityName = refferalorders.Value[t].EntityName;
                            serviceResult.Result.Add(orderM);
                        }
                    }
                    else
                    {
                        serviceResult.Success = false;
                        serviceResult.ErrorMessage = refferalorders.Message;
                    }
                }

                return serviceResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message;
                return serviceResult.ToString();
            }
        }

        //[WebMethod]
        public string GetPackageOrderInfoFromTemp(string tokenJson, string filterJson, string paramJson)
        {
            var serviceResult = new ServiceResult<OutPacKageDInf>();
            try
            {
                ListFilterModel filterModel = JsonConvert.DeserializeObject<ListFilterModel>(filterJson);
                PackageTempAddItemInParam paramModel = JsonConvert.DeserializeObject<PackageTempAddItemInParam>(paramJson);
                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                var prm = new UTerminalService.ServiceRequestOfPackageTempAddItemIn();
                prm.Token = (UTerminalService.Token)token;
                prm.Value = new UTerminalService.PackageTempAddItemIn();
                prm.Value.SourceApp = 143;
                prm.Value.SourceApp2 = 212;/*Ambalaj = 212*/
                prm.Value.SourceMId = 0;
                prm.Value.WhouseId = paramModel.WhouseId;
                prm.Value.Ids = paramModel.Ids?.ToArray();
                prm.Value.BomPacKageTraMGetItems = paramModel.BomPacKageTraMGetItems;

                var dataTempValues = GetUTerminalService().GetPackageOrderInfoFromTemp(prm);
                if (dataTempValues != null && dataTempValues.Result)
                {
                    var prmBarkod = new UTerminalService.ServiceRequestOfPackageTempAddItemIn();
                    prmBarkod.Token = (UTerminalService.Token)token;
                    prmBarkod.Value = new UTerminalService.PackageTempAddItemIn();
                    prmBarkod.Value.SourceApp = 143;
                    prmBarkod.Value.SourceApp2 = 210;/*Stok = 210*/
                    prmBarkod.Value.SourceMId = 0;
                    prmBarkod.Value.WhouseId = paramModel.WhouseId;
                    prmBarkod.Value.Ids = paramModel.Ids?.ToArray();
                    prmBarkod.Value.BomPacKageTraMGetItems = paramModel.BomPacKageTraMGetItems;

                    var dataTempValuesBarkod = GetUTerminalService().GetPackageOrderInfoFromTemp(prmBarkod);

                    if (dataTempValuesBarkod != null && dataTempValuesBarkod.Result)
                    {
                        var prmSeri = new UTerminalService.ServiceRequestOfPackageTempAddItemIn();
                        prmSeri.Token = (UTerminalService.Token)token;
                        prmSeri.Value = new UTerminalService.PackageTempAddItemIn();
                        prmSeri.Value.SourceApp = 143;
                        prmSeri.Value.SourceApp2 = 209;/*BağımsızSeri = 209*/
                        prmSeri.Value.SourceMId = 0;
                        prmSeri.Value.WhouseId = paramModel.WhouseId;
                        prmSeri.Value.Ids = paramModel.Ids?.ToArray();
                        prmSeri.Value.BomPacKageTraMGetItems = paramModel.BomPacKageTraMGetItems;

                        var dataTempValuesSeri = GetUTerminalService().GetPackageOrderInfoFromTemp(prmSeri);

                        if (dataTempValuesSeri != null && dataTempValuesSeri.Result)
                        {
                            serviceResult.Success = true;
                            serviceResult.Result = new OutPacKageDInf();
                            serviceResult.Result.TempValues = dataTempValues.Value;
                            serviceResult.Result.TempValuesBarkod = dataTempValuesBarkod.Value;
                            serviceResult.Result.TempValuesSeri = dataTempValuesSeri.Value;
                        }
                        else
                        {
                            serviceResult.Success = false;
                            serviceResult.ErrorMessage = $"Sunucu hatası {dataTempValuesSeri?.Message}";
                        }
                    }
                    else
                    {
                        serviceResult.Success = false;
                        serviceResult.ErrorMessage = $"Sunucu hatası {dataTempValuesBarkod?.Message}";
                    }
                }
                else
                {
                    serviceResult.Success = false;
                    serviceResult.ErrorMessage = $"Sunucu hatası {dataTempValues?.Message}";
                }

                return serviceResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(ex.Message).Append("Detay:").Append(ex.StackTrace).ToString());
                serviceResult.Success = false;
                serviceResult.ErrorMessage = ex.Message;
                return serviceResult.ToString();
            }
        }

        [WebMethod]
        public string AppLogSave(string applog)
        {
            try
            {
                Logger.WriteFileLog(applog);
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [WebMethod]
        public string AppVersion(string version)
        {
            try
            {
                var revinifile = HttpContext.Current.Server.MapPath($"~/MobileWhouse.ini");
                if (!string.IsNullOrWhiteSpace(version))
                {
                    SarfCikisHelper.WritePrivateProfileString("APPLICATION", "VERSION", version, revinifile);
                    return version;
                }
                else
                {
                    StringBuilder temp = new StringBuilder(255);
                    int i = SarfCikisHelper.GetPrivateProfileString("APPLICATION", "VERSION", "2.0.0.0", temp, 255, revinifile);
                    if (i == 0)
                    {
                        SarfCikisHelper.WritePrivateProfileString("APPLICATION", "VERSION", "2.0.0.0", revinifile);
                    }
                    return temp.ToString();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}