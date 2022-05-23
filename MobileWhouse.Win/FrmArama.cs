using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MobileWhouse.Util;
using MobileWhouse.UTermConnector;

namespace MobileWhouse
{
    public partial class FrmArama : Form, IDisposable
    {
        string Pkey = "";
        string Pkey2 = "";
        string Pkey3 = "";
        string Pkey4 = "";
        string Pkey5 = "";
        string Pkey6 = "";
        string Pkey7 = "";
        string Pkey8 = "";
        string Pkey9 = "";
        string Pkey10 = "";
        string Pkey11 = "";
        bool PkeyIsTransfer = false; //Hareket Kodu Transfer Mi?

        string _Type = "";
        int _id = 0;
        int _id2 = 0;
        int _TypeFilter = 0;
        public object SelectedItem { get; set; }

        Dictionary<string, string> resultDic = new Dictionary<string, string>();

        public FrmArama(string _Ptype, int _Pid, int _Pid2, int _pTypeFilter)
        {

            InitializeComponent();
            _Type = _Ptype;
            _id = _Pid;
            _id2 = _Pid2;
            _TypeFilter = _pTypeFilter;

            if(_Ptype == "OrderM3_Multi")
                SearchEntityVisible(true);
            else
                SearchEntityVisible(false);
            //this.TopMost = true;
        }
        public string RetKey
        {
            get { return Pkey; }
        }

        public string RetKey2
        {
            get { return Pkey2; }
        }

        public string RetKey3
        {
            get { return Pkey3; }
        }

        public string RetKey4
        {
            get { return Pkey4; }
        }
        public string RetKey5
        {
            get { return Pkey5; }
        }
        public string RetKey6
        {
            get { return Pkey6; }
        }

        public string RetKey7
        {
            get { return Pkey7; }
        }

        public string RetKey8
        {
            get { return Pkey8; }
        }

        public string RetKey9
        {
            get { return Pkey9; }
        }

        public string RetKey10
        {
            get { return Pkey10; }
        }
        public string RetKey11
        {
            get { return Pkey11; }
        }
        public bool RetKeyIsTransfer
        {
            get { return PkeyIsTransfer; }
        }

        public Dictionary<string, string> ResultDict
        {
            get { return resultDic; }
        }

        void GetData()
        {

            Screens.ShowWait();

            DataSet Ds = new DataSet();
            //switch (_Type)
            //{
            //    case "OrderM": Ds = Data.TrmService.GetOrderMaster(); break;
            //    case "OrderD": Ds = Data.TrmService.GetOrderDetail(_id); break;
            //    case "ShipOrderM": Ds = Data.TrmService.GetShipOrderMaster(); break;
            //    case "ShipOrderD": Ds = Data.TrmService.GetShipOrderDetail(_id); break;
            //    case "PackageM": Ds = Data.TrmService.GetPackageMaster(); break;
            //    case "PackageD": Ds = Data.TrmService.GetPackageDetail(_id); break;


            //}

            if (_Type == "DocTra")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 210;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;
                GridSearch.DataSource = _LstDoc.Value;
                SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                GridSearch.Refresh();
            }

            if (_Type == "DocTraFat")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 2;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;
                GridSearch.DataSource = _LstDoc.Value;

                SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                GridSearch.Refresh();
            }

            if (_Type == "DocTra2")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 1000;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId; ;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;

                if (_TypeFilter != 0)
                {
                    List<DocTra> ListDocTra = new List<DocTra>();
                    foreach (DocTra item in _LstDoc.Value)
                    {
                        if (item.PurchaseSales != _TypeFilter)
                        {
                            if (_TypeFilter == 2 && ClientApplication.Instance._PurchaseReturnDisplay) //Satış işleminde Alış iade hareket kodlarını göster
                            {
                                if (item.PurchaseSales != 4)
                                    continue;
                            }
                            else
                            {
                                continue;
                            }
                                
                        }
                            

                        ListDocTra.Add(item);
                    }
                    //var query = _LstDoc.Value.Where(p => p.PurchaseSales == _TypeFilter);
                    GridSearch.DataSource = ListDocTra.ToList();
                    SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                    GridSearch.Refresh();
                }
                else
                {
                    GridSearch.DataSource = _LstDoc.Value;
                    GridSearch.Refresh();
                }
                this.TopMost = true;
            }




            if (_Type == "DocTra3")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 212;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId; ;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;
                GridSearch.DataSource = _LstDoc.Value;
                SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                GridSearch.Refresh();
            }
            if (_Type == "DocTra4")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 211;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId; ;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;
                GridSearch.DataSource = _LstDoc.Value;
                SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                GridSearch.Refresh();
            }

            if (_Type == "DocTra5")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 1000;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId; 
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;

                if (_TypeFilter > 0)
                {
                    var query = _LstDoc.Value.Where(p => p.PurchaseSales >= _TypeFilter && p.PurchaseSales <= 4);
                    ServiceResultOfListOfDocTra pqueryList = new ServiceResultOfListOfDocTra();
                    pqueryList.Value = query.ToArray();
                    GridSearch.DataSource = pqueryList.Value;
                    SetDocTraGridStyle(pqueryList.Value.GetType().Name); //Stil
                }
                else
                {
                    GridSearch.DataSource = _LstDoc.Value;
                    SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                }
                GridSearch.Refresh();

            }

            if (_Type == "DocTra6")
            {
                ServiceRequestOfTrmDocTraInParam _DocInn = new ServiceRequestOfTrmDocTraInParam();
                _DocInn.Token = new Token();
                _DocInn.Value = new TrmDocTraInParam();
                _DocInn.Token = ClientApplication.Instance.UTermToken;
                _DocInn.Value.SourceApplication = 300;
                _DocInn.Value.InventoryStatus = 2;
                _DocInn.Value.IsreasonMondatory = 0;
                _DocInn.Value.IsOutside = 0;
                _DocInn.Value.IsScrap = 0;
                _DocInn.Value.IsReWork = 0;
                _DocInn.Value.PageSize = 300;
                ServiceResultOfListOfTrmDocTraOutParam _DocOut = ClientApplication.Instance.UTermService.GetDocTraInfo(_DocInn);
                if (_DocOut.Result == true)
                {
                    GridSearch.DataSource = _DocOut.Value;
                    SetDocTraGridStyle(_DocOut.Value.GetType().Name); //Stil
                    GridSearch.Refresh();
                }

            }


            if (_Type == "DocTraTrans")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 210;
                _DtSl.Value.InventoryStatus = 3;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;
                GridSearch.DataSource = _LstDoc.Value;
                SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                GridSearch.Refresh();

            }

            if (_Type == "DocTra7")
            {
                ServiceRequestOfDocTraSelectParam _DtSl = new ServiceRequestOfDocTraSelectParam();
                _DtSl.Token = ClientApplication.Instance.UTermToken;
                _DtSl.Value = new DocTraSelectParam();
                _DtSl.Value.SourceApplication = 122;
                _DtSl.Value.CoId = ClientApplication.Instance.ClientToken.CoId;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtSl);
                if (_LstDoc.Result == false) goto Son;
                GridSearch.DataSource = _LstDoc.Value;
                SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                GridSearch.Refresh();
            }

            if (_Type == "OrderM1") //Satınalma
            {
                ServiceRequestOfOrderMParam _OrmP = new ServiceRequestOfOrderMParam();
                _OrmP.Token = new Token();
                _OrmP.Token = ClientApplication.Instance.UTermToken;
                _OrmP.Value = new OrderMParam();
                _OrmP.Value.PurchaseSales = 1;
                _OrmP.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                _OrmP.Value.PageSize = 500;

                ServiceResultOfListOfOrderMInfo _OrmI = ClientApplication.Instance.UTermService.GetOrderMInfo(_OrmP);
                if (_OrmI.Result == false) goto Son;
                GridSearch.DataSource = _OrmI.Value;
                GridSearch.Refresh();
            }

            if (_Type == "OrderM2") //Sevk
            {
                ServiceRequestOfSelectParam _SParam = new ServiceRequestOfSelectParam();
                _SParam.Token = new Token();
                _SParam.Token = ClientApplication.Instance.UTermToken;
                _SParam.Value = new SelectParam();
                _SParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                _SParam.Value.IsItemPicking = 1;
                if (ClientApplication.Instance.HandsetParam["AllPage", "KAYIT_LISTELEME_GUN_SAYISI"] != null)
                {
                    int pGunSay = ClientApplication.Instance.HandsetParam["AllPage", "KAYIT_LISTELEME_GUN_SAYISI"].ToInt();
                    if (pGunSay > 0)
                        _SParam.Value.SearchDate = DateTime.Now.Date.AddDays(pGunSay * (-1));
                }
                ServiceResultOfListOfReferralInfo _RefInfo = ClientApplication.Instance.UTermService.GetReferralOrders(_SParam);

                if (_RefInfo.Result == false) goto Son;
                GridSearch.DataSource = _RefInfo.Value;
                GridSearch.Refresh();

            }

            if (_Type == "OrderM3" || _Type == "OrderM3_Multi") //Sevk
            {
                ServiceRequestOfSelectParam _SParam = new ServiceRequestOfSelectParam();
                _SParam.Token = new Token();
                _SParam.Token = ClientApplication.Instance.UTermToken;
                _SParam.Value = new SelectParam();
                _SParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                _SParam.Value.IsItemPicking = 0;
                _SParam.Value.SearchEntity = Tx_Entity.Text.ToString();
                if (ClientApplication.Instance.HandsetParam["AllPage", "KAYIT_LISTELEME_GUN_SAYISI"] != null)
                {
                    int pGunSay = ClientApplication.Instance.HandsetParam["AllPage", "KAYIT_LISTELEME_GUN_SAYISI"].ToInt();
                    if (pGunSay > 0)
                        _SParam.Value.SearchDate = DateTime.Now.Date.AddDays(pGunSay * (-1));
                }
                ServiceResultOfListOfReferralInfo _RefInfo = ClientApplication.Instance.UTermService.GetReferralOrders(_SParam);



                if (_RefInfo.Result == false) goto Son;
                GridSearch.DataSource = _RefInfo.Value;
                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                //ts.MappingName = "TableD";
                tableStyle.MappingName = _RefInfo.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Id", HeaderText = "Id", Width = 10 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "DocNo", HeaderText = "Belge No", Width = 130 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityName", HeaderText = "Cari Adı", Width = 350 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "TransportTypeCode", HeaderText = "Nakliye Kod", Width = 150 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "TransportTypeDesc", HeaderText = "Nakliye Ad", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "TransporterCode", HeaderText = "Nakliye Şekli Kod", Width = 150 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "TransporterDesc", HeaderText = "Nakliye Şekli Ad", Width = 200 });
                
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityId", HeaderText = "Cari Id", Width = -1 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityCode", HeaderText = "Cari Kodu", Width = 150 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ShippingAddress1", HeaderText = "Sevk Adres-1", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ShippingAddress2", HeaderText = "Sevk Adres-2", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ShippingAddress3", HeaderText = "Sevk Adres-3", Width = 200 });

                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
                GridSearch.Refresh();
            }
            // OĞUZHAN START
            if (_Type == "OrderDetails") //PaletOlustur_MusteriKontrol_SiparisBagla
            {
                ServiceRequestOfSelectParam _SParam = new ServiceRequestOfSelectParam();
                _SParam.Token = new Token();
                _SParam.Token = ClientApplication.Instance.UTermToken;
                _SParam.Value = new SelectParam();
                _SParam.Value.InfoId = this._id;

                ServiceResultOfListOfReferralDetailInfo _RefInfo = ClientApplication.Instance.UTermService.GetOrderDetails(_SParam);

                if (_RefInfo.Result == false) goto Son;
                GridSearch.DataSource = _RefInfo.Value;
                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                //ts.MappingName = "TableD";

                tableStyle.MappingName = _RefInfo.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ReferralDetailId", HeaderText = "Id", Width = 75 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "OrderNo", HeaderText = "Sipariş No", Width = 75 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ArrivalDate", HeaderText = "Tarih", Width = 75 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "PackageTypeCode", HeaderText = "Cari Adı", Width = 220 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "QtyOrder", HeaderText = "Miktar", Width = 75 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "QtyReferral", HeaderText = "Svek Edilen", Width = 75 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ReferralMasterId", HeaderText = "Sipariş Id", Width = 100 });

                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
                GridSearch.Refresh();
            }
            // OĞUZHAN END

            if (_Type == "Package")
            {
                ServiceRequestOfSelectParam2 _Sp2 = new ServiceRequestOfSelectParam2();
                _Sp2.Token = new Token();
                _Sp2.Token = ClientApplication.Instance.UTermToken;
                _Sp2.Value = new SelectParam2();
                _Sp2.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                _Sp2.Value.InfoId = _id;
                //_Sp2.Value.DocTraId = _TraId;
                //_Sp2.Value.DocTraCode = _TraCode;

                ServiceResultOfListOfNameIdItem _Res = ClientApplication.Instance.UTermService.GetReferralOrdersPackage(_Sp2);
                GridSearch.DataSource = _Res.Value;

                DataGridTableStyle tableStyle = new DataGridTableStyle();
                //tableStyle.MappingName = "MainStyle";

                DataGridTextBoxColumn _Col1 = new DataGridTextBoxColumn();
                _Col1.Width = -1;
                _Col1.MappingName = "Id";
                _Col1.HeaderText = "";
                tableStyle.GridColumnStyles.Add(_Col1);

                DataGridTextBoxColumn _Col2 = new DataGridTextBoxColumn();
                _Col2.Width = 200;
                _Col2.MappingName = "Name";
                _Col2.HeaderText = "";
                tableStyle.GridColumnStyles.Add(_Col2);

                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                GridSearch.Refresh();
            }

            if (_Type == "WorderM")
            {
                ServiceRequestOfTrmWorderMInParam _Wparam = new ServiceRequestOfTrmWorderMInParam();
                _Wparam.Token = new Token();
                _Wparam.Value = new TrmWorderMInParam();
                _Wparam.Token = ClientApplication.Instance.UTermToken;
                _Wparam.Value.WorderMatrlTrnType = 0;
                _Wparam.Value.PageSize = 10000;
                ServiceResultOfListOfTrmWorderMOutParam _Wres = ClientApplication.Instance.UTermService.GetWorderMInfo(_Wparam);
                GridSearch.DataSource = _Wres.Value;
            }

            if (_Type == "WorderM2")
            {
                ServiceRequestOfTrmWorderMInParam _Wparam = new ServiceRequestOfTrmWorderMInParam();
                _Wparam.Token = new Token();
                _Wparam.Value = new TrmWorderMInParam();
                _Wparam.Token = ClientApplication.Instance.UTermToken;
                _Wparam.Value.WorderMatrlTrnType = 1;
                _Wparam.Value.PageSize = 10000;
                ServiceResultOfListOfTrmWorderMOutParam _Wres = ClientApplication.Instance.UTermService.GetWorderMInfo(_Wparam);
                GridSearch.DataSource = _Wres.Value;
            }
            if (_Type == "WorderMPackage") //İş Emri Ambalaj Takip-netbor
            {
                ServiceRequestOfTrmWorderMInParam _Wparam = new ServiceRequestOfTrmWorderMInParam();
                _Wparam.Token = new Token();
                _Wparam.Value = new TrmWorderMInParam();
                _Wparam.Token = ClientApplication.Instance.UTermToken;
                _Wparam.Value.WorderMatrlTrnType = 0;
                _Wparam.Value.PageSize = 10000;
                ServiceResultOfListOfTrmWorderMOutParam _Wres = ClientApplication.Instance.UTermService.GetWorderMInfo(_Wparam);
                GridSearch.DataSource = _Wres.Value;
            }
            if (_Type == "WorderOP")
            {
                ServiceRequestOfTrmWorderOpDInParam _WoInp = new ServiceRequestOfTrmWorderOpDInParam();
                _WoInp.Token = new Token();
                _WoInp.Value = new TrmWorderOpDInParam();
                _WoInp.Token = ClientApplication.Instance.UTermToken;
                _WoInp.Value.WorderMId = _id;
                _WoInp.Value.PageSize = 10000;
                _WoInp.Value.IsOutsideOperation = false;
                _WoInp.Value.WStationId = 0;
                ServiceResultOfListOfTrmWorderOpDOutParam _WoRes = ClientApplication.Instance.UTermService.GetWorderOpDInfo(_WoInp);
                GridSearch.DataSource = _WoRes.Value;
            }

            if (_Type == "WorderWS")
            {
                ServiceRequestOfTrmWStationInParam _WsInp = new ServiceRequestOfTrmWStationInParam();
                _WsInp.Token = new Token();
                _WsInp.Value = new TrmWStationInParam();
                _WsInp.Token = ClientApplication.Instance.UTermToken;
                _WsInp.Value.PageSize = 10000;
                _WsInp.Value.OperationId = _id2;
                ServiceResultOfListOfTrmWStationOutParam _WsParam = ClientApplication.Instance.UTermService.GetWstationInfo(_WsInp);
                GridSearch.DataSource = _WsParam.Value;
            }

            if (_Type == "WorderEP")
            {
                ServiceRequestOfTrmWstationEmployeesInParam _WiParam = new ServiceRequestOfTrmWstationEmployeesInParam();
                _WiParam.Token = new Token();
                _WiParam.Token = ClientApplication.Instance.UTermToken;
                _WiParam.Value = new TrmWstationEmployeesInParam();
                _WiParam.Value.PageSize = 10000;
                _WiParam.Value.WstationId = _id;

                ServiceResultOfListOfTrmWstationEmployeesOutParam _WsOut = ClientApplication.Instance.UTermService.GetWstationEmployeeInfo(_WiParam);
                GridSearch.DataSource = _WsOut.Value;
            }

            if (_Type == "Entity")
            {
                ServiceRequestOfTrmCoEntityInParam _Coep = new ServiceRequestOfTrmCoEntityInParam();
                _Coep.Token = new Token();
                _Coep.Value = new TrmCoEntityInParam();
                _Coep.Token = ClientApplication.Instance.UTermToken;
                _Coep.Value.PageSize = 1000;
                ServiceResultOfListOfTrmCoEntityOutParam _CoParam = ClientApplication.Instance.UTermService.GetOutCoEntityInfo(_Coep);
                if (_CoParam.Result == true) GridSearch.DataSource = _CoParam.Value;
            }

            if (_Type == "FhEnOrderM")
            {
                ServiceRequestOfTrmOrderMInParam _OrMi = new ServiceRequestOfTrmOrderMInParam();
                _OrMi.Token = new Token();
                _OrMi.Value = new TrmOrderMInParam();
                _OrMi.Token = ClientApplication.Instance.UTermToken;
                _OrMi.Value.EntityId = _id;
                ServiceResultOfListOfTrmOrderMOutParam _Oprm = ClientApplication.Instance.UTermService.GetOutsideOrderMInfo(_OrMi);
                if (_Oprm.Result == true) GridSearch.DataSource = _Oprm.Value;
            }


            if (_Type == "GetWareHouse")
            {
                ServiceRequestOfDepoListInSelectParam _Sp = new ServiceRequestOfDepoListInSelectParam();
                _Sp.Token = new Token();
                _Sp.Token = ClientApplication.Instance.UTermToken;
                _Sp.Value = new DepoListInSelectParam();
                _Sp.Value.IsWorkPlace = false;
                _Sp.Value.DescriptionFilter = "";
                _Sp.Value.OnlyWithLocation = false;
                _Sp.Value.NotEqualDepotId = 0;
                _Sp.Value.IsscraptIsRework = true;

                ServiceResultOfListOfDepoListOut _Sonuc = ClientApplication.Instance.UTermService.UTrmGetWareHouses(_Sp);
                GridSearch.DataSource = _Sonuc.Value;
            }
            if (_Type == "GetBranchWareHouse")
            {
                ServiceRequestOfDepoListInSelectParam _Sp = new ServiceRequestOfDepoListInSelectParam();
                _Sp.Token = new Token();
                _Sp.Token = ClientApplication.Instance.UTermToken;
                _Sp.Value = new DepoListInSelectParam();
                _Sp.Value.IsWorkPlace = true;
                _Sp.Value.DescriptionFilter = "";
                _Sp.Value.OnlyWithLocation = false;
                _Sp.Value.NotEqualDepotId = 0;
                _Sp.Value.IsscraptIsRework = true;

                ServiceResultOfListOfDepoListOut _Sonuc = ClientApplication.Instance.UTermService.UTrmGetWareHouses(_Sp);
		if (_Sonuc.Result == false) goto Son;
                GridSearch.DataSource = _Sonuc.Value;

                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                //ts.MappingName = "TableD";
                tableStyle.MappingName = _Sonuc.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Id", HeaderText = "Id", Width = -1 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Code", HeaderText = "Code", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Name", HeaderText = "Name", Width = 300 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BranchId", HeaderText = "BranchId", Width = -1 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BranchCode", HeaderText = "BranchCode", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BranchName", HeaderText = "BranchName", Width = 300 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsLocNegative", HeaderText = "IsLocNegative", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsUTerminalShippingShelfControl", HeaderText = "IsUTerminalShippingShelfControl", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsLocationTrack", HeaderText = "IsLocationTrack", Width = 200 });



                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
                GridSearch.Refresh();
            }

            if (_Type == "TrmSearchDocTra")
            {

            }


            if (_Type == "LocationCount")
            {
                ServiceRequestOfInt32 _Cprm = new ServiceRequestOfInt32();
                _Cprm.Token = new Token();
                _Cprm.Token = ClientApplication.Instance.UTermToken;
                _Cprm.Value = new int();
                _Cprm.Value = ClientApplication.Instance.SelectedDepot.Id;
                ServiceResultOfListOfRafSayimFisi _Fisler = ClientApplication.Instance.UTermService.GetLocationCounts(_Cprm);
                GridSearch.DataSource = _Fisler.Value;

            }
            if (_Type == "GetOrderD") //Mikrosan
            {
                ServiceRequestOfUTrmOrderDListInParam _OrderDlistIn = new ServiceRequestOfUTrmOrderDListInParam();
                _OrderDlistIn.Token = new Token();
                _OrderDlistIn.Token = ClientApplication.Instance.UTermToken;
                _OrderDlistIn.Value = new UTrmOrderDListInParam();
                ServiceResultOfListOfUTrmOrderDListOutParam _OrderDOut = ClientApplication.Instance.UTermService.GetOrderDlist(_OrderDlistIn);
                if (_OrderDOut.Result == true) GridSearch.DataSource = _OrderDOut.Value;

            }

            if (_Type == "GetSalesPersons")
            {
                var SalesPersonServiceResult = ClientApplication.Instance.UTermService.GetSalesPersons(new ServiceRequestOfInt32 { Token = ClientApplication.Instance.UTermToken, Value = 1 });
                if (SalesPersonServiceResult.Result)
                {
                    GridSearch.DataSource = SalesPersonServiceResult.Value;
                    #region Column Style
                    GridSearch.TableStyles.Clear();
                    DataGridTableStyle tableStyle = new DataGridTableStyle();
                    //ts.MappingName = "TableD";
                    tableStyle.MappingName = SalesPersonServiceResult.Value.GetType().Name;
                    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Id", HeaderText = "Id", Width = -1 });
                    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ContactName", HeaderText = "ContactName", Width = 300 });
                    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "SalesPersonCode", HeaderText = "SalesPersonCode", Width = 300 });
                    GridSearch.TableStyles.Clear();
                    GridSearch.TableStyles.Add(tableStyle);
                    #endregion Column Style
                    GridSearch.Refresh();
                }
            }

            if (_Type == "GetCurrencys")
            {
                var GetCurrencyServiceResult = ClientApplication.Instance.UTermService.GetCurrencys(new ServiceRequestOfInt32 { Token = ClientApplication.Instance.UTermToken, Value = 1 });
                if (GetCurrencyServiceResult.Result)
                {
                    GridSearch.DataSource = GetCurrencyServiceResult.Value;
                }
            }
            if (_Type.StartsWith("GetPriceListM"))
            {
                //string[] pInPrm = _Type.Split('|');
                //DateTime pDocDate = Convert.ToDateTime(pInPrm[1]);
                //int pPurchaseSalesTupe = int.Parse(pInPrm[2]);

                //PriceListMInParam pPriceListMInParam = new PriceListMInParam(){
                //};

                //var GetGetPriceListMResult = ClientApplication.Instance.UTermService.GetPriceListM(new ServiceRequestOfPriceListMInParam()
                //{
                //    Token = ClientApplication.Instance.UTermToken,
                //    Value = new PriceListMInParam
                //    {
                //        DocDate = pDocDate,
                //        PurchaseSalesType = pPurchaseSalesTupe
                //    }
                //});

                //if (GetGetPriceListMResult.Result)
                //{
                //    GridSearch.DataSource = GetGetPriceListMResult.Value;
                //    #region Column Style
                //    GridSearch.TableStyles.Clear();
                //    DataGridTableStyle tableStyle = new DataGridTableStyle();
                //    //ts.MappingName = "TableD";

                //    tableStyle.MappingName = GetGetPriceListMResult.Value.GetType().Name;
                //    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "PriceListMId", HeaderText = "Id", Width = 15 });
                //    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "PriceListCode", HeaderText = "Fiyat Listesi Kodu", Width = 150 });
                //    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "PriceListDesc", HeaderText = "Fiyat Listesi Açıklama", Width = 200 });
                //    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BranchCode", HeaderText = "İşyeri Kodu", Width = 250 });

                //    GridSearch.TableStyles.Clear();
                //    GridSearch.TableStyles.Add(tableStyle);
                //    #endregion Column Style
                //    GridSearch.Refresh();
                //}
            }
            if (_Type == "GetCoDisc")
            {
                ServiceRequestOfInt32 _InsertParam = new ServiceRequestOfInt32();
                _InsertParam.Token = new Token();
                _InsertParam.Token = ClientApplication.Instance.UTermToken;
                _InsertParam.Value = 2; //Tutrsal iskontolar gelsin.
                ServiceResultOfListOfCoDiscOutParam _GetOutCoDiscInfo = ClientApplication.Instance.UTermService.GetOutCoDiscInfo(_InsertParam); //2 = Tutarsal İskontolar gelsin. Boyutlu sipariş girişi - Vaye Tekstil.

                //ServiceResultOfListOfCoDiscOutParam _GetOutCoDiscInfo = ClientApplication.Instance.UTermService.GetOutCoDiscInfo(new ServiceRequestOfInt32 { Token = ClientApplication.Instance.UTermToken, Value = 2 }); //2 = Tutarsal İskontolar gelsin. Boyutlu sipariş girişi - Vaye Tekstil.
                if (_GetOutCoDiscInfo.Result)
                {
                    GridSearch.DataSource = _GetOutCoDiscInfo.Value;
                }
            }



            if (_Type == "GetLoadingM")
            {
                ServiceRequestOfYuklemeMInParam _YuklemeMInParam = new ServiceRequestOfYuklemeMInParam();
                _YuklemeMInParam.Token = new Token();
                _YuklemeMInParam.Value = new YuklemeMInParam();
                _YuklemeMInParam.Token = ClientApplication.Instance.UTermToken;
                _YuklemeMInParam.Value.WhouseOutId = ClientApplication.Instance.SelectedDepot.Id;
                var GetLoadingInstMListServiceResult = ClientApplication.Instance.UTermService.GetLoadingInstMList(_YuklemeMInParam);
                if (GetLoadingInstMListServiceResult.Result == true) GridSearch.DataSource = GetLoadingInstMListServiceResult.Value;
            }

            if (_Type == "GetTransferM")
            {
                ServiceRequestOfTrmTransferMInParam _TrmTransferMInParam = new ServiceRequestOfTrmTransferMInParam();
                _TrmTransferMInParam.Token = new Token();
                _TrmTransferMInParam.Value = new TrmTransferMInParam();
                _TrmTransferMInParam.Token = ClientApplication.Instance.UTermToken;
                _TrmTransferMInParam.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                _TrmTransferMInParam.Value.LoadDetails = false;
                var GetTransferMListResult = ClientApplication.Instance.UTermService.GetTransferMList(_TrmTransferMInParam);
                if (GetTransferMListResult.Result == true) GridSearch.DataSource = GetTransferMListResult.Value;
            }
            if (_Type == "GetItemPickingM")
            {
                ServiceRequestOfSelectParam _GetSevkiyatlarInParam = new ServiceRequestOfSelectParam();
                _GetSevkiyatlarInParam.Token = new Token();
                _GetSevkiyatlarInParam.Value = new SelectParam();
                _GetSevkiyatlarInParam.Token = ClientApplication.Instance.UTermToken;

                if (_id > 0) //Depo girilirse Depodakileri getir. frm_MalSevkRaf
                    _GetSevkiyatlarInParam.Value.DepotId = _id; //Hazırlama kayıtlarının deposu

                var GetSevkiyatlarResult = ClientApplication.Instance.UTermService.GetSevkiyatlar(_GetSevkiyatlarInParam);
                if (GetSevkiyatlarResult.Result == true)
                    GridSearch.DataSource = GetSevkiyatlarResult.Value;
            }
            if (_Type == "GetPackageType")
            {
                //GetPackageTypeInfo

                var GetPackageTypeResult = ClientApplication.Instance.UTermService.GetPackageTypes(new ServiceRequestOfInt32
                {
                    Token = ClientApplication.Instance.UTermToken,
                    Value = 0
                });

                if (GetPackageTypeResult.Result == true)
                    GridSearch.DataSource = GetPackageTypeResult.Value;

            }

            if (_Type == "PrdWorderAcOp")
            {
                var opDate = DateTime.Today;
                string dateStr = "";
                if (this.ResultDict.TryGetValue("SearchDate", out dateStr))
                {
                    opDate = Convert.ToDateTime(dateStr);
                }


                var SearchPrdWorderAcOpResult = ClientApplication.Instance.UTermService.SearchPrdWorderAcOp(new ServiceRequestOfPrdWorderAcOpListIn
                {
                    Token = ClientApplication.Instance.UTermToken,
                    Value = new PrdWorderAcOpListIn
                    {
                        BranchId = ClientApplication.Instance.UTermToken.BranchId,
                        //  WhouseId = ClientApplication.Instance.SelectedDepot.Id,
                        OperationEndDate = opDate
                    }
                });

                if (SearchPrdWorderAcOpResult.Result == true)
                    GridSearch.DataSource = SearchPrdWorderAcOpResult.Value;
                else
                {
                    MessageBox.Show(SearchPrdWorderAcOpResult.Message, "Arama Hatası");
                }

            }

            if (_Type == "GetSoybasPipePlaningMList")
            {
                ServiceRequestOfInt32 _TrmGetSoybasPipePlnMInPrm = new ServiceRequestOfInt32();
                _TrmGetSoybasPipePlnMInPrm.Token = new Token();
                _TrmGetSoybasPipePlnMInPrm.Token = ClientApplication.Instance.UTermToken;

                _TrmGetSoybasPipePlnMInPrm.Value = new Int32();
                _TrmGetSoybasPipePlnMInPrm.Value = 0;
                var GetPipePlaningMListResult = ClientApplication.Instance.UTermService.GetSoybasPipePlaningMList(_TrmGetSoybasPipePlnMInPrm);
                if (GetPipePlaningMListResult.Result == true)
                {
                    GridSearch.DataSource = GetPipePlaningMListResult.Value;
                }
            }

            if (_Type == "GetWaybillM" || _Type == "GetBwhInM")
            {
                ServiceRequestOfBoolean prmBwhInMAndWaybill = new ServiceRequestOfBoolean();
                prmBwhInMAndWaybill.Token = new Token();
                prmBwhInMAndWaybill.Token = ClientApplication.Instance.UTermToken;
                prmBwhInMAndWaybill.Value = _Type == "GetWaybillM";

                ServiceResultOfListOfItemMInfo resBwhInMAndWaybill = ClientApplication.Instance.UTermService.GetBwhInMAndWaybillInfo(prmBwhInMAndWaybill);
                GridSearch.DataSource = resBwhInMAndWaybill.Value;
            }


            if (_Type == "GetVehicleOutList")
            {
                var GetVehicleListResult = ClientApplication.Instance.UTermService.GetVehicleList(new ServiceRequestOfInt32
                {
                    Token = ClientApplication.Instance.UTermToken,
                    Value = 0
                });

                if (GetVehicleListResult.Result == true)
                {
                    #region Column Style
                    GridSearch.TableStyles.Clear();
                    DataGridTableStyle tableStyle = new DataGridTableStyle();
                    //ts.MappingName = "TableD";

                    tableStyle.MappingName = GetVehicleListResult.Value.GetType().Name;
                    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "VehicleId", HeaderText = "Id", Width = 15 });
                    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Description", HeaderText = "Araç Kodu", Width = 250 });
                    tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "LicensePlate", HeaderText = "Plaka", Width = 250 });

                    GridSearch.TableStyles.Clear();
                    GridSearch.TableStyles.Add(tableStyle);
                    #endregion Column Style
                    GridSearch.DataSource = GetVehicleListResult.Value;
                }
                    

            }

            if (_Type == "BwhInM")
            {
                ServiceRequestOfString _BwhInM = new ServiceRequestOfString();
                _BwhInM.Token = new Token();
                _BwhInM.Token = ClientApplication.Instance.UTermToken;
                ServiceResultOfListOfTrmActualImpMForBwhInMOutParam _BwhInMParam = ClientApplication.Instance.UTermService.GetActualImpMForBwhInM(_BwhInM);
                if (_BwhInMParam.Result == true) GridSearch.DataSource = _BwhInMParam.Value;
            }

            if (_Type == "DocTraBwhInM")
            {
                ServiceRequestOfDocTraSelectParam _DtDocTraBwhInM = new ServiceRequestOfDocTraSelectParam();
                _DtDocTraBwhInM.Token = ClientApplication.Instance.UTermToken;
                _DtDocTraBwhInM.Value = new DocTraSelectParam();
                _DtDocTraBwhInM.Value.SourceApplication = 210;
                _DtDocTraBwhInM.Value.CoId = ClientApplication.Instance.ClientToken.CoId;
                _DtDocTraBwhInM.Value.InventoryStatus = 1;
                _DtDocTraBwhInM.Value.InvoiceType = 2;
                ServiceResultOfListOfDocTra _LstDoc = ClientApplication.Instance.UTermService.GetDocTra(_DtDocTraBwhInM);
                if (_LstDoc.Result == false) goto Son;
                GridSearch.DataSource = _LstDoc.Value;
                SetDocTraGridStyle(_LstDoc.Value.GetType().Name); //Stil
                GridSearch.Refresh();
            }

            if (_Type == "GetBranchWareHouseBwhInM")
            {
                ServiceRequestOfDepoListInSelectParam _Sp = new ServiceRequestOfDepoListInSelectParam();
                _Sp.Token = new Token();
                _Sp.Token = ClientApplication.Instance.UTermToken;
                _Sp.Value = new DepoListInSelectParam();
                _Sp.Value.IsWorkPlace = true;
                _Sp.Value.DescriptionFilter = "";
                _Sp.Value.OnlyWithLocation = false;
                _Sp.Value.NotEqualDepotId = 0;
                _Sp.Value.IsscraptIsRework = false;

                ServiceResultOfListOfDepoListOut _Sonuc = ClientApplication.Instance.UTermService.UTrmGetWareHouses(_Sp);
                GridSearch.DataSource = _Sonuc.Value;

                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                //ts.MappingName = "TableD";
                tableStyle.MappingName = _Sonuc.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Id", HeaderText = "Id", Width = -1 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Code", HeaderText = "Code", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Name", HeaderText = "Name", Width = 300 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BranchId", HeaderText = "BranchId", Width = -1 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BranchCode", HeaderText = "BranchCode", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BranchName", HeaderText = "BranchName", Width = 300 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsLocNegative", HeaderText = "IsLocNegative", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsUTerminalShippingShelfControl", HeaderText = "IsUTerminalShippingShelfControl", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsLocationTrack", HeaderText = "IsLocationTrack", Width = 200 });



                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
                GridSearch.Refresh();
            }

            if (_Type == "GetTransferMInfo")
            {
                ServiceRequestOfGetTransferMInParam _GetTransferMInfoPrm = new ServiceRequestOfGetTransferMInParam();
                _GetTransferMInfoPrm.Token = new Token();
                _GetTransferMInfoPrm.Token = ClientApplication.Instance.UTermToken;
                _GetTransferMInfoPrm.Value = new GetTransferMInParam();
                _GetTransferMInfoPrm.Value.PrdTransferShippingType = 1;
                _GetTransferMInfoPrm.Value.WhouseId = _id; //ClientApplication.Instance.SelectedDepot.Id; //Giriş yapılan depodaki kayıtlar...
                ServiceResultOfListOfGetTransferMOutParam _GetTransferMInfoOutList = ClientApplication.Instance.UTermService.GetTransferMInfo(_GetTransferMInfoPrm);
                if (_GetTransferMInfoOutList.Result == false) goto Son;
                GridSearch.DataSource = _GetTransferMInfoOutList.Value;
                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = _GetTransferMInfoOutList.Value.GetType().Name;
                AddGridColumnStyle(tableStyle, "TransferMId", "TransferMId", 10);
                AddGridColumnStyle(tableStyle, "DocNo", "Belge No", 200);
                AddGridColumnStyle(tableStyle, "DocDate", "Belge Tarih", 200);
                AddGridColumnStyle(tableStyle, "RequestDate", "Talep Tarihi", 200);

                AddGridColumnStyle(tableStyle, "WhouseId", "WhouseId", -1);
                AddGridColumnStyle(tableStyle, "WhouseCode", "K.Depo", 100);
                AddGridColumnStyle(tableStyle, "TransferWhouseId", "TransferWhouseId", -1);
                AddGridColumnStyle(tableStyle, "TransferWhouseCode", "H.Depo", 100);

                AddGridColumnStyle(tableStyle, "PrdTransferShippingType", "PrdTransferShippingType", -1);
                AddGridColumnStyle(tableStyle, "UsUsername", "Kullanıcı", -1);
                AddGridColumnStyle(tableStyle, "Description", "Description", 200);
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
                GridSearch.Refresh();
            }
            if (_Type.StartsWith("GetItemList")) //Stok Listesi.
            {
                var pGetItemListPrms = _Type.ToString().Split(',');
                if (pGetItemListPrms == null) goto Son;

                ServiceRequestOfGetItemListInParam _GetItemListInParam = new ServiceRequestOfGetItemListInParam();
                _GetItemListInParam.Token = new Token();
                _GetItemListInParam.Token = ClientApplication.Instance.UTermToken;
                _GetItemListInParam.Value = new GetItemListInParam();
                _GetItemListInParam.Value.ItemCode = pGetItemListPrms[1].ToString();
                ServiceResultOfListOfGetItemListOutResult _GetItemListOut = ClientApplication.Instance.UTermService.GetItemList(_GetItemListInParam);
                if (_GetItemListOut.Result == false) goto Son;
                GridSearch.DataSource = _GetItemListOut.Value;
                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = _GetItemListOut.Value.GetType().Name;
                AddGridColumnStyle(tableStyle, "ItemCode", "ItemCode", 200);
                AddGridColumnStyle(tableStyle, "ItemName", "ItemName", 200);
                AddGridColumnStyle(tableStyle, "ItemId", "ItemId", -1);
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
                GridSearch.Refresh();
            }

            #region soybaş satın alma hazırlama

            if (_Type == "GetSoybasLot")
            {
                ServiceRequestOfInt32 _GetSoybasLot = new ServiceRequestOfInt32();
                _GetSoybasLot.Token = new Token();
                _GetSoybasLot.Token = ClientApplication.Instance.UTermToken;
                if (_id > 0)
                {
                    _GetSoybasLot.Value = new int();
                    _GetSoybasLot.Value = _id;
                }
                ServiceResultOfListOfSoybasLotOutParam _GetSoybasLotParam = ClientApplication.Instance.UTermService.GetSoybasLot(_GetSoybasLot);
                if (_GetSoybasLotParam.Result == true) GridSearch.DataSource = _GetSoybasLotParam.Value;

                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = _GetSoybasLotParam.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "ItemCode", HeaderText = "Stok Kodu", Width = 300 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "LotCode", HeaderText = "Parti Kodu", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "LotId", HeaderText = "Parti Id", Width = -1 });
                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
            }

            if (_Type == "GetSoybasEntity")
            {
                ServiceRequestOfInt32 _GetSoybasEntity = new ServiceRequestOfInt32();
                _GetSoybasEntity.Token = new Token();
                _GetSoybasEntity.Token = ClientApplication.Instance.UTermToken;
                ServiceResultOfListOfSoybasEntityOutParam _GetSoybasEntityParam = ClientApplication.Instance.UTermService.GetSoybasEntity(_GetSoybasEntity);
                if (_GetSoybasEntityParam.Result == true) GridSearch.DataSource = _GetSoybasEntityParam.Value;

                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = _GetSoybasEntityParam.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityName", HeaderText = "Cari Adı", Width = 300 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityCode", HeaderText = "Cari Kodu", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityId", HeaderText = "Cari Id", Width = -1 });
                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
            }

            if (_Type == "GetSoybasBarcodeLabel")
            {
                ServiceRequestOfInt32 _GetSoybasBarcode = new ServiceRequestOfInt32();
                _GetSoybasBarcode.Token = new Token();
                _GetSoybasBarcode.Token = ClientApplication.Instance.UTermToken;
                ServiceResultOfListOfSoybasBarcodeLabelOutParam _GetSoybasBarcodeParam = ClientApplication.Instance.UTermService.GetSoybasBarcodeLabel(_GetSoybasBarcode);
                if (_GetSoybasBarcodeParam.Result == true) GridSearch.DataSource = _GetSoybasBarcodeParam.Value;

                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = _GetSoybasBarcodeParam.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BarcodeLabelDesc", HeaderText = "Barkod Etiket Açıklaması", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "BarcodeLabelId", HeaderText = "Barkod Etiket Id", Width = -1 });
                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
            }
            #endregion

            #region Entes BAŞLA
            if (_Type == "GetEntesItemM") //Entes (İrs/İTH master Listesi)
            {
                /*Eksik Cummit Nedeni ile kapatıldı.
                ServiceRequestOfEntesItemMInParam _SParam = new uTerminal.ServiceRequestOfEntesItemMInParam();
                _SParam.Token = new uTerminal.Token();
                _SParam.Token = ClientApplication.Instance.UTermToken;
                _SParam.Value = new uTerminal.EntesItemMInParam();
                _SParam.Value.IsWaybill = _id == 1 ? true : false;
                ServiceResultOfListOfEntesItemMOut _RefInfo = ClientApplication.Instance.UTermService.GetEntesItemM(_SParam);

                if (_RefInfo.Result == false) goto Son;
                GridSearch.DataSource = _RefInfo.Value;
                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                //ts.MappingName = "TableD";
                tableStyle.MappingName = _RefInfo.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Id", HeaderText = "Id", Width = 10 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityId", HeaderText = "Cari Id", Width = -1 });

                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "DocNo", HeaderText = "Belge No", Width = 130 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "DocDate", HeaderText = "Belge Tarih", Width = 80 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityName", HeaderText = "Cari Adı", Width = 350 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityCode", HeaderText = "Cari Kodu", Width = 150 });

                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style
                GridSearch.Refresh();
                 * */
            }
            #endregion Entes BİTTİ
            
        Son:
            GridSearch.Refresh();

            Screens.HideWait();

        }

        private static int AddGridColumnStyle(DataGridTableStyle tableStyle, string xMappingName, string xHeaderText, int xWidth)
        {
            return tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = xMappingName, HeaderText = xHeaderText, Width = xWidth });
        }

        

        private void SetDocTraGridStyle(string xMappingName)
        {
            #region Column Style
            GridSearch.TableStyles.Clear();
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            //ts.MappingName = "TableD";
            tableStyle.MappingName = xMappingName;
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Id", HeaderText = "Id", Width = -1 });
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "DocTraDesc", HeaderText = "DocTraDesc", Width = 300 });
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "DocTraCode", HeaderText = "DocTraCode", Width = 200 });
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Status", HeaderText = "Status", Width = 100 });
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "PurchaseSales", HeaderText = "PurchaseSales", Width = 100 });
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsNotItemRecord", HeaderText = "IsNotItemRecord", Width = 100 });
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "InvoiceType", HeaderText = "InvoiceType", Width = 100 });
            tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "IsreasonMondatory", HeaderText = "IsreasonMondatory", Width = 100 });
            GridSearch.TableStyles.Clear();
            GridSearch.TableStyles.Add(tableStyle);
            #endregion Column Style
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Pkey = GridSearch[GridSearch.CurrentCell.RowNumber, 0].ToString();
            }
            catch (SystemException)
            {
                //Classes.SysDefinitions.Err(string.Concat(ex.Message , "[001]"));
            }

            try
            {
                Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
                Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 2].ToString();
            }
            catch (SystemException)
            {
                //Classes.SysDefinitions.Err(string.Concat(ex.Message , "[001]"));
            }

            try
            {
                Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 2].ToString();
            }
            catch (SystemException)
            {
                //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[002]"));
            }
            try
            {
                Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString();
            }
            catch (SystemException)
            {
                //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
            }
            if (_Type == "WorderM")
            {
                try
                {
                    Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 12].ToString();
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
                
            }
            if (_Type.StartsWith("DocTra"))
            {
                try
                {
                    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 2].ToString();
                    Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString();
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }
            if (_Type == "DocTra2") //İrsaliye Hareket Kodu
            {
                try
                {
                    PkeyIsTransfer = bool.Parse(GridSearch[GridSearch.CurrentCell.RowNumber, 8].ToString()); //Transfer Mi?
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }
            if (_Type == "DocTra4")
            {
                try
                {
                    Pkey5 = GridSearch[GridSearch.CurrentCell.RowNumber, 5].ToString();
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }

            if (_Type == "GetBranchWareHouse")
            {
                try
                {
                    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
                    Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 6].ToString();
                    Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 7].ToString();
                    Pkey5 = GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString();
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }

            if (_Type == "PrdWorderAcOp")
            {
                try
                {
                    Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 5].ToString();//ItemId
                    Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 6].ToString();//Item Kodu
                    resultDic.Clear();
                    resultDic.Add("Qty", GridSearch[GridSearch.CurrentCell.RowNumber, 8].ToString());
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }
            if (_Type == "WorderMPackage") //İş Emri Ambalaj Takip-netbor
            {
                try
                {
                    resultDic.Clear();
                    resultDic.Add("ItemId", GridSearch[GridSearch.CurrentCell.RowNumber, 6].ToString());
                    resultDic.Add("ItemCode", GridSearch[GridSearch.CurrentCell.RowNumber, 7].ToString());
                    resultDic.Add("Qty", GridSearch[GridSearch.CurrentCell.RowNumber, 13].ToString());
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }

            }
            if (_Type == "OrderM3_Multi") //İş Emri Çoklu Seçim
            {
                try
                {
                    // Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
                    //IEnumerable Icol=  GridSearch.DataSource as IEnumerable;
                    bool lEntityCheck = ClientApplication.Instance.HandsetParam["Frm_PaletSevk", "MUSTERI_KONTROL"].ToBool();
                    int lastEntity = 0;

                    var ss = GridSearch.DataSource as object[];

                    Pkey2 = "";
                    Pkey = "";
                    List<string> orderCodes = new List<string>();
                    List<string> orderId = new List<string>();

                    for (int i = 0; i < ss.Length; i++)
                    {
                        if (GridSearch.IsSelected(i))
                        {
                            if (lEntityCheck)
                            {
                                int currEntity = Convert.ToInt32(GridSearch[i, 4]);
                                if (lastEntity != 0 && currEntity != 0 && lastEntity != currEntity)
                                {
                                    MessageBox.Show("Seçtiğiniz siparişler birden fazla müşteriye ait olamaz. ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                    return;
                                }
                                if (currEntity != 0) lastEntity = currEntity;
                            }
                            orderCodes.Add(GridSearch[i, 1].ToString());
                            orderId.Add(GridSearch[i, 0].ToString());
                        }
                    }
                    Pkey = string.Join(",", orderId.ToArray());
                    Pkey2 = string.Join(",", orderCodes.ToArray());

                    if (string.IsNullOrEmpty(Pkey) && string.IsNullOrEmpty(Pkey2))
                    {
                        Pkey = GridSearch[GridSearch.CurrentCell.RowNumber, 0].ToString();
                        Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
                    }
                    Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 6].ToString();//Nakliye Şekli Kodu
                    Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 6].ToString();//Nakliye Şekli Adı
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }
            if (_Type == "GetSoybasPipePlaningMList") //Soybaş Sargı - Rezerv
            {
                try
                {
                    resultDic.Clear();
                    resultDic.Add("SoybasPipePlaningMId", GridSearch[GridSearch.CurrentCell.RowNumber, 0].ToString());      //Plan No - Id - sıralama talep edildi.          
                    resultDic.Add("ProdItemCode", GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString());              //Stok Kodu- sıralama talep edildi.              
                    resultDic.Add("QtyFreeSec", GridSearch[GridSearch.CurrentCell.RowNumber, 2].ToString());                //KG- sıralama talep edildi.                     
                    resultDic.Add("ProdQty", GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString());                   //Metre- sıralama talep edildi.                  
                    resultDic.Add("ProdItemName", GridSearch[GridSearch.CurrentCell.RowNumber, 4].ToString());              //Stok Adı                                       
                    resultDic.Add("ProdItemAttributeCode1", GridSearch[GridSearch.CurrentCell.RowNumber, 5].ToString());    //Özellik-1                                      
                    resultDic.Add("ProdItemAttributeCode2", GridSearch[GridSearch.CurrentCell.RowNumber, 6].ToString());    //Özellik-2                                      
                    resultDic.Add("ProdItemAttributeCode3", GridSearch[GridSearch.CurrentCell.RowNumber, 7].ToString());    //Özellik-3                                      
                    resultDic.Add("ProdQualityCode", GridSearch[GridSearch.CurrentCell.RowNumber, 8].ToString());           //Kalite                                         
                    resultDic.Add("DefaultPipeDiameter", GridSearch[GridSearch.CurrentCell.RowNumber, 9].ToString());       //Boru Çapı                                      
                    resultDic.Add("DefaultCutBand", GridSearch[GridSearch.CurrentCell.RowNumber, 10].ToString());           //Kesim Bant                                     
                    resultDic.Add("ProdBandWidthMin", GridSearch[GridSearch.CurrentCell.RowNumber, 11].ToString());         //Stok Bant-min                                  
                    resultDic.Add("ProdBandWidthMax", GridSearch[GridSearch.CurrentCell.RowNumber, 12].ToString());         //Stok Bant-mix                                  
                    resultDic.Add("DefaultCutDepth", GridSearch[GridSearch.CurrentCell.RowNumber, 13].ToString());          //Kesim Kalınlık                                 
                    resultDic.Add("ProdItemDepthMin", GridSearch[GridSearch.CurrentCell.RowNumber, 14].ToString());         //Stok Bant-min                                  
                    resultDic.Add("ProdItemDepthMax", GridSearch[GridSearch.CurrentCell.RowNumber, 15].ToString());         //Stok Bant-mix  
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }

            if (_Type == "GetWaybillM" || _Type == "GetBwhInM")
            {
                try
                {
                    this.SelectedItem = ((ItemMInfo[])GridSearch.DataSource)[GridSearch.CurrentRowIndex];
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
                
            }

            if (_Type == "BwhInM")
            {
                try
                {
                    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
                    Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString();
                    Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 5].ToString();
                    Pkey5 = GridSearch[GridSearch.CurrentCell.RowNumber, 7].ToString();
                    Pkey6 = GridSearch[GridSearch.CurrentCell.RowNumber, 8].ToString();
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }
            if (_Type == "GetTransferMInfo")
            {
                try
                {
                    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString(); //DocNo
                    Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 2].ToString(); //DocDate
                    Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString(); //RequestDate
                    Pkey5 = GridSearch[GridSearch.CurrentCell.RowNumber, 4].ToString(); //WhouseId
                    Pkey6 = GridSearch[GridSearch.CurrentCell.RowNumber, 5].ToString(); //WhouseCode
                    Pkey7 = GridSearch[GridSearch.CurrentCell.RowNumber, 6].ToString(); //TransferWhouseId
                    Pkey8 = GridSearch[GridSearch.CurrentCell.RowNumber, 7].ToString(); //TransferWhouseCode
                    Pkey9 = GridSearch[GridSearch.CurrentCell.RowNumber, 8].ToString(); //PrdTransferShippingType
                    Pkey10= GridSearch[GridSearch.CurrentCell.RowNumber, 9].ToString(); //UsUsername
                    Pkey11= GridSearch[GridSearch.CurrentCell.RowNumber, 10].ToString(); //Description
                }
                catch (SystemException)
                {
                    //Classes.SysDefinitions.Err(string.Concat(ex.Message, "[003]"));
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Pkey = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void GridSearch_DoubleClick(object sender, EventArgs e)
        {
            BtnOk_Click(null, null);

            //Pkey = GridSearch[GridSearch.CurrentCell.RowNumber, 0].ToString();
            //if (_Type == "DocTra")
            //{
            //    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
            //    Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString();
            //}
            //if (_Type == "OrderM1") //Satınalma
            //{
            //    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
            //}
            //if (_Type == "OrderM2") //Satınalma
            //{
            //    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
            //}
            //if (_Type == "DocTra2") //İrsaliyeHareket Kodu
            //{
            //    Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
            //}



            //this.Close(); 
        }

        private void FrmArama_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            string _Gelen = "";
            //foreach (Control Ctrl in this.Controls)
            //{
            //    _Gelen = "";
            //    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //    if (_Gelen == null) continue;
            //    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //}
            //_Gelen = "";
            //foreach (Control Ctrl in this.panel1.Controls)
            //{
            //    _Gelen = "";
            //    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //    if (_Gelen == null) continue;
            //    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //}
            //_Gelen = "";
            //foreach (Control Ctrl in this.panel2.Controls)
            //{
            //    _Gelen = "";
            //    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //    if (_Gelen == null) continue;
            //    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //}

            GetData();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click_1(object sender, EventArgs e)
        {
            GetData();
        }
        private void SearchEntityVisible(bool xvisible)
        {
            Tx_Entity.Visible = xvisible;
            Lbl_Current.Visible = xvisible;
            btnCari.Visible = xvisible;
            btnAra.Visible = xvisible;
            /*
            if (xvisible)
            {
                GridSearch.Dock = System.Windows.Forms.DockStyle.None;

            }
            else
            {
                GridSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            }
            GridSearch.BringToFront();
            this.Hide();
            this.Show();*/
        }

        private void btnCari_Click_1(object sender, EventArgs e)
        {
            FrmAramaFirma fa = new FrmAramaFirma("Entity", 0, 0);
            fa.ShowDialog();
            if (fa.RetKey.ToString() == "" || fa.RetKey == null) return;
            try
            {
                //_EntityId = int.Parse(fa.RetKey3.ToString());
                //Tx_Entity.Text = fa.RetKey2.ToString();
                Tx_Entity.Text = "*" + fa.RetKey.ToString();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(String.Format("Hata : {0}", ex.Message));
            }
        }
    }
}