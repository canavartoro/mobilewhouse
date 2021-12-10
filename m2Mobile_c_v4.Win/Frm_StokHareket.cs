using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using uTerminal.uTerminalServices;

namespace uTerminal.Forms
{
    
    public partial class Frm_StokHareket : Form, IDisposable
    {
        DataTable Dt = new DataTable();
        FormParameters FormParam = new FormParameters();
        DataSet Ds = new DataSet();
        int _Procces = 1;
        int _MaxSequence = 0;
        string _AmbalajKodu = "";
        string _SeriKodu = "";
        string _StokKodu = "";
        string _MessageStr = "";
        string _RafKodu = "";
        DateTime lastKeyPress = DateTime.Now;
        Boolean _FirstLoad = false;
        string _TraId = "";
        string _TraCode = "";
        string _TraType = "";
        List<int> _RecordResult;
        string _TargetBranchId = "";
        int _SalesOrderMId = 0;
        int _SalesOrderDId = 0;
        int _LineNo = 0;
        string _parti_kod = string.Empty;
        string _renk_kod = string.Empty;

        public Frm_StokHareket()
        {
            
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmArama fa = new FrmArama("DocTra",0,0,0);
            fa.ShowDialog();
            if (fa.RetKey.ToString() == "" || fa.RetKey == null) return;
            try
            {
                _TraId = fa.RetKey.ToString();
                _TraCode = fa.RetKey2.ToString();
                _TraType = fa.RetKey4.ToString();

                TxTransCode.Text = _TraCode;

                if (_TraType == "3")
                {
                    
                    TxTargetDepot.Visible = true;
                    Lbl_SourceWh.Visible = true;
                    button2.Visible = true;

                    //uTerminalServices.ServiceRequestOfDepotSelectParam _SelParam = new uTerminal.uTerminalServices.ServiceRequestOfDepotSelectParam();
                    //_SelParam.Token = Data._Token.Token;
                    //_SelParam.Value = new uTerminal.uTerminalServices.DepotSelectParam();
                    //uTerminalServices.ServiceResultOfListOfDepot _ListWp = Data._UService.GetWareHouses(_SelParam);

                    //foreach (Depot _Val in _ListWp.Value)
                    //{
                    //    if (_Val.Id == Data._SelectedWareHouse) continue;
                    //    ComboboxItem Ci = new ComboboxItem();
                    //    Ci.Text = _Val.Code;
                    //    Ci.Value = _Val.Id;
                    //    Ci.Id = _Val.Id;
                    //    Cbo_TargetDepot.Items.Add(Ci);
                    //}
                }
                else
                {
                    TxTargetDepot.Visible = false;
                    Lbl_SourceWh.Visible = false;
                    button2.Visible = false;
                }

            }
            catch (SystemException)
            {
            }
        }


        private void SetGridColumns()
        {

            try
            {
                dataGrid1.TableStyles.Clear();

                DataGridTableStyle ts = new DataGridTableStyle();
                ts.MappingName = "Table1";

                DataGridColumnStyle Col1 = new DataGridTextBoxColumn();
                Col1.MappingName = "ID";
                Col1.HeaderText = "ID";
                Col1.Width = -1;
                ts.GridColumnStyles.Add(Col1);

                DataGridColumnStyle Col2 = new DataGridTextBoxColumn();
                Col2.MappingName = "MID";
                Col2.HeaderText = "MID";
                Col2.Width = -1;
                ts.GridColumnStyles.Add(Col2);

                DataGridColumnStyle Col3 = new DataGridTextBoxColumn();
                Col3.MappingName = "STOK_KOD";
                Col3.HeaderText = "Stok Kodu";
                Col3.Width = Convert.ToInt32(dataGrid1.Width * 0.20);
                ts.GridColumnStyles.Add(Col3);

                DataGridColumnStyle Col4 = new DataGridTextBoxColumn();
                Col4.MappingName = "STOK_ADI";
                Col4.HeaderText = "Stok Adı";
                Col4.Width = Convert.ToInt32(dataGrid1.Width * 0.30);
                ts.GridColumnStyles.Add(Col4);

                DataGridColumnStyle Col5 = new DataGridTextBoxColumn();
                Col5.MappingName = "PARTI";
                Col5.HeaderText = "Parti";
                Col5.Width = Convert.ToInt32(dataGrid1.Width * 0.125);
                ts.GridColumnStyles.Add(Col5);

                DataGridColumnStyle Col6 = new DataGridTextBoxColumn();
                Col6.MappingName = "AMBALAJ";
                Col6.HeaderText = "Ambalaj";
                Col6.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col6);

                DataGridColumnStyle Col7 = new DataGridTextBoxColumn();
                Col7.MappingName = "SIP_MIK";
                Col7.HeaderText = "Sip.Mik";
                Col7.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col7);

                DataGridColumnStyle Col8 = new DataGridTextBoxColumn();
                Col8.MappingName = "OKUNAN";
                Col8.HeaderText = "Okunan";
                Col8.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col8);

                DataGridColumnStyle Col9 = new DataGridTextBoxColumn();
                Col9.MappingName = "RAF_KODU";
                Col9.HeaderText = "Raf";
                Col9.Width = -1;
                ts.GridColumnStyles.Add(Col9);

                DataGridColumnStyle Col10 = new DataGridTextBoxColumn();
                Col10.MappingName = "SERI_KOD";
                Col10.HeaderText = "Seri";
                Col10.Width = -1;
                ts.GridColumnStyles.Add(Col10);

                DataGridColumnStyle Col11 = new DataGridTextBoxColumn();
                Col11.MappingName = "AMBALAJ_KODU";
                Col11.HeaderText = "Ambalaj";
                Col11.Width = -1;
                ts.GridColumnStyles.Add(Col11);

                DataGridColumnStyle Col12 = new DataGridTextBoxColumn();
                Col12.MappingName = "STOK_AD2";
                Col12.HeaderText = "Stok Ad-2";
                Col12.Width = -1;
                ts.GridColumnStyles.Add(Col12);

                DataGridColumnStyle Col13 = new DataGridTextBoxColumn();
                Col13.MappingName = "LINENO";
                Col13.HeaderText = "Line No";
                Col13.Width = -1;
                ts.GridColumnStyles.Add(Col13);
                dataGrid1.TableStyles.Add(ts);
            }
            catch (SystemException)
            {
            }
        }

        private void Frm_MalKabul_Load(object sender, EventArgs e)
        {
            try
            {
                _RafKodu = "";
                _TraId = "";
                _TraCode = "";

                DataTableDefinition();

                FormParam = Data.FParam(this.Name.ToString());
                _Procces = 1;
                _MaxSequence = 1;



                if (FormParam.PRM_READSQUENCE1 == "")
                {
                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_ReadSequence");
                    MessageBox.Show(_MessageStr);
                    this.Close();
                }

                _MaxSequence = 1;

                if (FormParam.PRM_READSQUENCE1 != "") _MaxSequence = 1;
                if (FormParam.PRM_READSQUENCE2 != "") _MaxSequence = 2;
                if (FormParam.PRM_READSQUENCE3 != "") _MaxSequence = 3;
                if (FormParam.PRM_READSQUENCE4 != "") _MaxSequence = 4;
                if (FormParam.PRM_READSQUENCE5 != "") _MaxSequence = 5;

                string _Gelen = "";
                foreach (Control Ctrl in PanelHeader.Controls)
                {
                    _Gelen = "";
                    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                    if (_Gelen == null) continue;
                    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                }

                _Gelen = "";
                foreach (Control Ctrl in PanelBody.Controls)
                {
                    _Gelen = "";
                    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                    if (_Gelen == null) continue;
                    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                }

                _Gelen = "";
                foreach (Control Ctrl in PanelFooter.Controls)
                {
                    _Gelen = "";
                    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                    if (_Gelen == null) continue;
                    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
                }


                uTerminalServices.ServiceRequestOfDepoHareketParam _DepoHarParam = new ServiceRequestOfDepoHareketParam();
                _DepoHarParam.Token = new Token();
                _DepoHarParam.Token = Data._Token.Token;
                _DepoHarParam.Value = new DepoHareketParam();
                _DepoHarParam.Value.DepoId = Data._SelectedWareHouse;

                uTerminalServices.ServiceResultOfStokHareketM _Res = Data._UService.ControlItemTempFirstLoad(_DepoHarParam);
                if (_Res.Result == false)
                {
                    _FirstLoad = true;
                }
                else
                {
                    _RecordResult = new List<int>();
                    _RecordResult.Add(_Res.Value.Id);

                    Tx_DocNo.Text = _Res.Value.DocNo.ToString();
                    Tx_Note1.Text = _Res.Value.Note1.ToString(); //Açılacaktır dede
                    _TraCode = _Res.Value.DocTra.DocTraCode.ToString();
                    _TraId = _Res.Value.DocTra.Id.ToString();
                    _TraType = _Res.Value.DocTra.Status.ToString();
                    Dt_DocDate.Text = _Res.Value.DocDate.ToString();
                    TxTransCode.Text = _TraCode;

                    if (_Res.Value.DocTra.Status == 3)
                    {
                        TxTargetDepot.Visible = true;
                        Lbl_SourceWh.Visible = true;
                        button2.Visible = true;
                        //uTerminalServices.ServiceRequestOfDepotSelectParam _SelParam = new uTerminal.uTerminalServices.ServiceRequestOfDepotSelectParam();
                        //_SelParam.Token = Data._Token.Token;
                        //_SelParam.Value = new uTerminal.uTerminalServices.DepotSelectParam();
                        //uTerminalServices.ServiceResultOfListOfDepot _ListWp = Data._UService.GetWareHouses(_SelParam);

                        //foreach (Depot _Val in _ListWp.Value)
                        //{
                        //    ComboboxItem Ci = new ComboboxItem();
                        //    Ci.Text = _Val.Code;
                        //    Ci.Value = _Val.Id;
                        //    Cbo_TargetDepot.Items.Add(Ci);
                        //}
                        TxTargetDepot.Text = _Res.Value.DocTra.DocTraCode;
                    }
                    _LineNo = 0;
                    if (_Res.Value.StokHareketDetayList != null)
                    {
                        foreach (StokHareketD _Detay in _Res.Value.StokHareketDetayList)
                        {
                            CreateNewDataRow(_Detay.ItemCode,
                                             _Detay.UnitCode,
                                             _parti_kod,
                                             _renk_kod,
                                             _Detay.QtyPrm.ToString(),
                                             _Detay.ItemName2,
                                             _Detay.Barcode);
                        }
                    }
                }

                Tx_Miktar.Text = FormParam.PRM_DEFAULTAMOUNT.ToString();
                SetSquence();
                Tx_Barcode.Focus();
                Dt.DefaultView.Sort = "LINENO DESC";
                dataGrid1.DataSource = Dt;
                SiparisSecim();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("System Hata :" + ex.Message);
                Lbl_StockMovements.Text = "System Hata :" + ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.Message);
                Lbl_StockMovements.Text = "Hata :" + ex.Message;
            }

            Tx_Barcode.KeyDown += new KeyEventHandler(Tx_Barcode_KeyDown);

        }
        /// <summary>
        /// Detay Sutunlarını Oluştur.
        /// </summary>
        private void DataTableDefinition()
        {
            DataRowCreate("STOK_AD", Type.GetType("System.String"));
            DataRowCreate("BIRIM", Type.GetType("System.String"));
            DataRowCreate("PARTI_KOD", Type.GetType("System.String"));
            DataRowCreate("RENK", Type.GetType("System.String"));
            DataRowCreate("OKUNAN", Type.GetType("System.String"));
            DataRowCreate("STOK_AD2", Type.GetType("System.String"));
            DataRowCreate("LINENO", Type.GetType("System.Int32"));
            DataRowCreate("BARKOD",Type.GetType("System.String"));

            /*Sıralaması*/
            Dt.Columns["STOK_AD"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "STOK_AD").ToString()));
            Dt.Columns["BIRIM"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "BIRIM").ToString()));
            Dt.Columns["PARTI_KOD"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "PARTI_KOD").ToString()));
            Dt.Columns["RENK"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "RENK").ToString()));
            Dt.Columns["OKUNAN"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "OKUNAN").ToString()));
            Dt.Columns["STOK_AD2"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "STOK_AD2").ToString()));
            Dt.Columns["LINENO"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "LINENO").ToString()));
            Dt.Columns["BARKOD"].SetOrdinal(Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", "BARKOD").ToString()));
            /*Sıralaması*/
        }
        /// <summary>
        /// Sutun Oluşturmak içindir.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="dataType"></param>
        /// <param name="Ordinal"></param>
        /// <returns></returns>
        private void DataRowCreate(string caption, Type dataType)
        {
            //Column index Sysdef.xml'de column index var .
            //ordinal = Int32.Parse(Classes.SysDefinitions.GetXmlData("StokHareketColumnIndex", caption).ToString());

            DataColumn DataColumnNew = new DataColumn();
            DataColumnNew.ColumnName = caption;
            DataColumnNew.Caption = caption;
            DataColumnNew.DataType = dataType;
            Dt.Columns.Add(DataColumnNew);
        }

        void Tx_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                if (FormParam.PRM_ALLOWMANUELENTRY == false)
                {
                    if (((TimeSpan)(DateTime.Now - lastKeyPress)).TotalMilliseconds > Data._BarcodeDelay)
                    {
                        Tx_Barcode.Text = "";
                        e.Handled = true;
                    }
                    lastKeyPress = DateTime.Now;
                }
            }
            else
            {
                if (Tx_DocNo.Text.ToString() == "" || Tx_DocNo.Text.ToString() == null)
                {
                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_DocNumber");
                    MessageBox.Show(_MessageStr);
                    return;
                }

                if (Convert.ToDateTime(Dt_DocDate.Text.ToString()) == null)
                {
                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_Date");
                    MessageBox.Show(_MessageStr);
                    return;
                }

                if (TxTransCode.Text.ToString() == "" || TxTransCode.Text.ToString() == null)
                {
                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_TransactionCode");
                    MessageBox.Show(_MessageStr);
                    return;
                }

                if (_TraType == "3")
                {
                    if (TxTargetDepot.Text.ToString() == "" || TxTargetDepot.Text.ToString() == null)
                    {
                        _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_TargetDepot");
                        MessageBox.Show(_MessageStr);
                        return;
                    }
                }
                
                ProcessData(Tx_Barcode.Text);
            }
        }
        
        void ProcessData(string _xCode)
        {
            try
            {
                object _Fp = new object();
                if (_Procces == 1) _Fp = FormParam.PRM_READSQUENCE1;
                if (_Procces == 2) _Fp = FormParam.PRM_READSQUENCE2;
                if (_Procces == 3) _Fp = FormParam.PRM_READSQUENCE3;
                if (_Procces == 4) _Fp = FormParam.PRM_READSQUENCE4;
                if (_Procces == 5) _Fp = FormParam.PRM_READSQUENCE5;

                object _FpVal = new object();
                if (_Fp.ToString() == FormParam.PRM_BARCODELABEL) _FpVal = FormParam.PRM_BARCODEPREVALUE;
                if (_Fp.ToString() == FormParam.PRM_PACKAGELABEL) _FpVal = FormParam.PRM_PACKAGEPREVALUE;
                if (_Fp.ToString() == FormParam.PRM_SERIALLABEL) _FpVal = FormParam.PRM_SERIALPREVALUE;
                if (_Fp.ToString() == FormParam.PRM_STOCKLABEL) _FpVal = FormParam.PRM_STOCKPREVALUE;


                if (_Fp.ToString() != FormParam.PRM_RACKLABEL)
                {
                    if (_FpVal.ToString() != "" && _FpVal.ToString().Length > _xCode.Length)
                    {
                        _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_InfoIncorrect");
                        MessageBox.Show(_Fp.ToString() + " " + _MessageStr);
                        Tx_Barcode.Text = "";
                        return;
                    }

                    if (_FpVal.ToString() != "" && _FpVal.ToString() != "" && _xCode.Substring(0, _FpVal.ToString().Length) != _FpVal.ToString())
                    {
                        _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_PreCode");
                        MessageBox.Show(_Fp + " " + _MessageStr + " " + _FpVal.ToString());
                        return;
                    }
                }

                if (_Fp.ToString() == FormParam.PRM_PACKAGELABEL.ToString())
                { _AmbalajKodu = _xCode; Tx_Barcode.Focus(); }
                if (_Fp.ToString() == FormParam.PRM_RACKLABEL.ToString().ToString())
                {
                    //_RafKodu = _xCode;

                    //uTerminalServices.ServiceRequestOfItemSelectParam _Sp = new ServiceRequestOfItemSelectParam();
                    //_Sp.Token = new Token();
                    //_Sp.Token = Data._Token.Token;
                    //_Sp.Value = new ItemSelectParam();
                    //_Sp.Value.Barkod = _RafKodu;
                    //_Sp.Value.DepotId = Data._SelectedWareHouse;

                    //uTerminalServices.ServiceResultOfNameIdItem _Res = Data._UService.GetRafInfo(_Sp);
                    //if (_Res.Result == false)
                    //{
                    //    MessageBox.Show(_Res.Message.ToString());
                    //    return;
                    //}
                    //Tx_Raf.Text = _RafKodu;
                    //Tx_Barcode.Focus();
                }
                if (_Fp.ToString() == FormParam.PRM_SERIALLABEL.ToString().ToString())
                { _SeriKodu = _xCode; Tx_Barcode.Focus(); }
                if (_Fp.ToString() == FormParam.PRM_STOCKLABEL.ToString())
                { _StokKodu = _xCode; Tx_Barcode.Focus(); }


                if (_Procces == _MaxSequence)
                {
                    ProccesDataBarcode(_xCode);
                    _Procces = 1;
                    Tx_Barcode.Text = "";
                }
                else _Procces += 1;

                SetSquence();
                Tx_Barcode.Text = "";
            }
            catch (SystemException)
            {
            }
        }

        void ProccesDataBarcode(string _xCode)
        {
            try
            {
                uTerminalServices.ServiceRequestOfItemSelectParam _ItemPrm = new ServiceRequestOfItemSelectParam();
                _ItemPrm.Token = new Token();
                _ItemPrm.Token = Data._Token.Token;
                _ItemPrm.Value = new ItemSelectParam();
                _ItemPrm.Value.DepotId = Data._SelectedWareHouse;
                _ItemPrm.Value.Barkod = _xCode;

                uTerminalServices.ServiceResultOfItemInfo _ItemInfo = Data._UService.GetItemInfo(_ItemPrm);

                if (_ItemInfo.Result == false)
                {
                    MessageBox.Show(_ItemInfo.Message.ToString());
                    return;
                }

                _ItemInfo.Value.Qty = Int16.Parse(Tx_Miktar.Text.ToString());

                if (Chk_Delete.CheckState == CheckState.Unchecked) //ITEM_M_TMP ve ITEM_D_TMP Ekleme
                {
                    #region master kayıt ekleme ve detay ekleme
                    CreateNewDataRow(_ItemInfo.Value.Description.ToString(),
                                     _ItemInfo.Value.ReadUnitCode.ToString(),
                                     _parti_kod,
                                     _renk_kod,
                                     _ItemInfo.Value.Qty.ToString(),
                                     _ItemInfo.Value.Description2.ToString(),
                                     _xCode);

                    if (_FirstLoad == true)
                    {
                        uTerminalServices.ServiceRequestOfStokHareketM _ReqM = new ServiceRequestOfStokHareketM();
                        _ReqM.Token = new Token();
                        _ReqM.Token = Data._Token.Token;
                        _ReqM.Value = new StokHareketM();
                        _ReqM.Value.StokHareketDetay = new StokHareketD();
                        _ReqM.Value.DocDate = Convert.ToDateTime(Dt_DocDate.Text).Date;
                        _ReqM.Value.DocNo = Tx_DocNo.Text;
                        _ReqM.Value.DocTra = new DocTra();
                        _ReqM.Value.DocTra.DocTraCode = _TraCode;

                        _ReqM.Value.DocTra.Id = Int32.Parse(_TraId);
                        _ReqM.Value.Note1 = Tx_Note1.Text;
                        _ReqM.Value.StokHareketDetay.ItemCode = _ItemInfo.Value.Name;
                        _ReqM.Value.StokHareketDetay.ItemId = _ItemInfo.Value.Id;
                        _ReqM.Value.StokHareketDetay.UnitId = _ItemInfo.Value.UnitId;
                        _ReqM.Value.StokHareketDetay.QtyPrm = _ItemInfo.Value.Qty;
                        _ReqM.Value.StokHareketDetay.ItemName2 = _ItemInfo.Value.Description2;
                        _ReqM.Value.StokHareketDetay.SourceOrderMId = _SalesOrderMId;
                        _ReqM.Value.StokHareketDetay.SourceOrderDId = _SalesOrderDId;
                        _ReqM.Value.StokHareketDetay.ReservationType = ReservationType.Satış_Siparişi;
                        _ReqM.Value.StokHareketDetay.Barcode = _xCode; //silmede kullanılacak

                        //_ReqM.Value.StokHareketDetayList = new StokHareketD[1];
                        //_ReqM.Value.StokHareketDetayList[0] = _ReqM.Value.StokHareketDetay;

                        _ReqM.Value.WhouseId = Data._SelectedWareHouse;
                        _ReqM.Value.Whouse2Id = (_TraType == "3" ? Int32.Parse(TxTargetDepot.Tag.ToString()) : 0);
                        _ReqM.Value.Branch2Id = (_TraType == "3" ? Int32.Parse(_TargetBranchId) : 0);
                        _RecordResult = Data._UService.InsertItemTempFirst(_ReqM).Value.ToList();
                        _FirstLoad = false;
                    }
                    else
                    {
                        uTerminalServices.ServiceRequestOfStokHareketInfo _ShInfo = new ServiceRequestOfStokHareketInfo();
                        _ShInfo.Token = new Token();
                        _ShInfo.Token = Data._Token.Token;
                        _ShInfo.Value = new StokHareketInfo();
                        _ShInfo.Value.StokHareketDetail = new StokHareketD();
                        _ShInfo.Value.StokHareketDetail.ItemCode = _ItemInfo.Value.Name;
                        _ShInfo.Value.StokHareketDetail.ItemId = _ItemInfo.Value.Id;
                        _ShInfo.Value.StokHareketDetail.QtyPrm = _ItemInfo.Value.Qty;
                        _ShInfo.Value.StokHareketDetail.UnitId = _ItemInfo.Value.UnitId;
                        _ShInfo.Value.StokHareketDetail.ItemName2 = _ItemInfo.Value.Description2;
                        _ShInfo.Value.StokHareketDetail.SourceOrderMId = _SalesOrderMId;
                        _ShInfo.Value.StokHareketDetail.SourceOrderDId = _SalesOrderDId;
                        _ShInfo.Value.StokHareketDetail.ReservationType = ReservationType.Satış_Siparişi;
                        _ShInfo.Value.StokHareketDetail.Barcode = _xCode; //silmede kullanılacak
                        _ShInfo.Value.StokHareketMId = _RecordResult[0];
                        _ShInfo.Value.WhouseId = Data._SelectedWareHouse;
                        _ShInfo.Value.Whouse2Id = (_TraType == "3" ? int.Parse(TxTargetDepot.Tag.ToString()) : 0);
                        Data._UService.InsertItemTempContinue(_ShInfo);
                    }
                    #endregion
                }
                else //ITEM_D_TMP QtyPRM update > Satırda Okutulan Barkodu silmek içindir.
                {
                    #region Detaydan okutulan barkodu silme
                    uTerminalServices.ServiceRequestOfStokHareketInfo _ShInfo = new ServiceRequestOfStokHareketInfo();
                    _ShInfo.Token = new Token();
                    _ShInfo.Token = Data._Token.Token;
                    _ShInfo.Value = new StokHareketInfo();
                    _ShInfo.Value.StokHareketDetail = new StokHareketD();
                    _ShInfo.Value.StokHareketDetail.ItemCode = _ItemInfo.Value.Name;
                    _ShInfo.Value.StokHareketDetail.ItemId = _ItemInfo.Value.Id;
                    _ShInfo.Value.StokHareketDetail.QtyPrm = _ItemInfo.Value.Qty;
                    _ShInfo.Value.StokHareketDetail.UnitId = _ItemInfo.Value.UnitId;
                    _ShInfo.Value.StokHareketDetail.ItemName2 = _ItemInfo.Value.Description2;
                    _ShInfo.Value.StokHareketDetail.SourceOrderMId = _SalesOrderMId;
                    _ShInfo.Value.StokHareketDetail.SourceOrderDId = _SalesOrderDId;
                    _ShInfo.Value.StokHareketDetail.Barcode = _xCode; //silmede kullanılacak
                    _ShInfo.Value.StokHareketMId = _RecordResult[0];
                    _ShInfo.Value.WhouseId = Data._SelectedWareHouse;
                    _ShInfo.Value.Whouse2Id = (_TraType == "3" ? int.Parse(TxTargetDepot.Tag.ToString()) : 0);
                    Data._UService.ItemTempDQtyUpdate(_ShInfo);
                    #region datatable'dan çıkart
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (Dt.Rows[i]["BARKOD"].ToString() == _xCode)
                        {
                            Dt.Rows[i]["OKUNAN"] = Int16.Parse(Dt.Rows[i]["OKUNAN"].ToString()) - Int16.Parse(_ItemInfo.Value.Qty.ToString());

                            if (Int16.Parse(Dt.Rows[i]["OKUNAN"].ToString()) == 0)
                            {
                                Dt.Rows[i].Delete();
                                _LineNo--; 
                            }
                            break;
                        }
                    }
                    #endregion datatable'dan çıkart
                    #endregion Detaydan okutulan barkodu silme
                }
            }
            catch (SystemException _ExMsg)
            {
                
                MessageBox.Show("System Hatası:" + _ExMsg.Message.ToString());
                return;
            }
            catch (Exception _Ex)
            {

                MessageBox.Show("Hata : " + _Ex.Message.ToString());
                return;
            }
            dataGrid1.Refresh();
        }

        /// <summary>
        /// Yeni satır eklemek içindir.
        /// </summary>
        /// <param name="xstok_kod"></param>
        /// <param name="xbirim"></param>
        /// <param name="xparti_kod"></param>
        /// <param name="xrenk_kod"></param>
        /// <param name="xokunan"></param>
        /// <param name="xstok_ad2"></param>
        /// <param name="xbarkod"></param>
        private void CreateNewDataRow(string xstok_kod, string xbirim,string xparti_kod, string xrenk_kod,string xokunan, string xstok_ad2,string xbarkod)
        {
            _LineNo++;
            DataRow Dr = Dt.NewRow();
            Dr["STOK_AD"] = xstok_kod ;
            Dr["BIRIM"] = xbirim;
            Dr["PARTI_KOD"] = xparti_kod;
            Dr["RENK"] = xrenk_kod ;
            Dr["OKUNAN"] =  Int16.Parse(xokunan);
            Dr["STOK_AD2"] = xstok_ad2 ;
            Dr["LINENO"] = _LineNo;
            Dr["BARKOD"] = xbarkod; //okunan barkod
            Dt.Rows.Add(Dr);
        }

        private void Frm_MalKabul_Closed(object sender, EventArgs e)
        {
            FormParam = null;
            Ds = null;
            dataGrid1.DataSource = null;
            this.Load -= Frm_MalKabul_Load;
            GC.Collect();
        }

        void SetSquence()
        {
            if (_Procces == 1) Lbl_State.Text = FormParam.PRM_READSQUENCE1;
            if (_Procces == 2) Lbl_State.Text = FormParam.PRM_READSQUENCE2;
            if (_Procces == 3) Lbl_State.Text = FormParam.PRM_READSQUENCE3;
            if (_Procces == 4) Lbl_State.Text = FormParam.PRM_READSQUENCE4;
            if (_Procces == 5) {Lbl_State.Text = FormParam.PRM_READSQUENCE5; Tx_Barcode.Text = ""; _RafKodu = ""; _AmbalajKodu = ""; _SeriKodu = ""; _StokKodu = ""; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Procces = 1;
            Tx_Barcode.Text = "";
            _RafKodu = ""; 
            _AmbalajKodu = ""; 
            _SeriKodu = ""; 
            _StokKodu = "";
            SetSquence();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                uTerminalServices.ServiceRequestOfInt32 _Param = new ServiceRequestOfInt32();
                _Param.Token = new Token();
                _Param.Token = Data._Token.Token;
                _Param.Value = _RecordResult[0];
                uTerminalServices.ServiceResultOfBoolean _Gelen = Data._UService.InsertItemM(_Param);
                if (_Gelen.Result == true)
                {

                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_SaveSucces");
                    MessageBox.Show( _MessageStr  );
                    ClearValues(); ;

                }
                else
                {
                    MessageBox.Show(_Gelen.Message.ToString());
                    return;
                }
            }
            catch (SystemException ex)
            {
                _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_SaveUnSucces");
                MessageBox.Show(String.Format("Hata:{0} \n Erp Hata: {1}",_MessageStr,ex.Message.ToString()  ));
            }
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tx_Miktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Tx_Miktar.Text.ToString() == "") return;

                if (Int32.Parse(Tx_Miktar.Text.ToString()) > 0)
                {
                    if (Int32.Parse(Tx_Miktar.Text.ToString()) > Int32.Parse(FormParam.PRM_MAXAMOUNT.ToString()))
                    {
                        _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_MaxAmount");
                        MessageBox.Show(_MessageStr);
                        Tx_Miktar.Text = "1";
                    }
                }
            }
            catch (SystemException)
            {
            }
        }

        private void ClearValues()
        {

            Ds.Clear();
            Ds.Reset();
            TxTransCode.Text = "";
            Tx_Barcode.Text = "";
            //_FirstLoad = false;
            _TraId = "";
            _TraCode = "";
            _TraType = "";
            Tx_Note1.Text = "";
            Tx_DocNo.Text = string.Empty;
            _LineNo = 0;
            txSiparisDetay.Text = "";
            _SalesOrderMId = 0;
            _SalesOrderDId = 0;
            Dt.Clear();
            dataGrid1.DataSource = Dt;
            dataGrid1.Refresh();
            _FirstLoad = true;
        }

        private void Cbo_TargetDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmArama fa = new FrmArama("GetWareHouse", 0, 0, 0);
            fa.ShowDialog();
            if (fa.RetKey.ToString() == "" || fa.RetKey == null) return;
            try
            {
                TxTargetDepot.Tag = fa.RetKey.ToString();
                TxTargetDepot.Text = fa.RetKey2.ToString();
                _TargetBranchId = fa.RetKey4.ToString();
               
            }
            catch (SystemException)
            {
            }
        }
        /// <summary>
        /// Satış Siparişi Seçimi İçindir . Mikrosan A.ş.
        /// </summary>
        private void SiparisSecim()
        {
            bool pSiparisSecimGoster = false;

            if (Classes.SysDefinitions.GetXmlData("MainParam", "SalesOrderDParam").ToString() == "ItemMSelectOrderD")
            {
                pSiparisSecimGoster = true;
            }
            labelSiparisDetay.Visible = pSiparisSecimGoster;
            txSiparisDetay.Visible = pSiparisSecimGoster;
            buttonSiparisDetay.Visible = pSiparisSecimGoster;
            if (pSiparisSecimGoster == false)
            {
                _SalesOrderMId = 0;
                _SalesOrderDId = 0;
            }
        }


        // <summary>
        /// Satış Siparişi Seçmek İçindir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            //ff
            FrmArama fa = new FrmArama("GetOrderD", 0, 0, 0);
            fa.ShowDialog();
            if (fa.RetKey.ToString() == "" || fa.RetKey == null) return;
            try
            {
                txSiparisDetay.Tag = fa.RetKey2.ToString();
                txSiparisDetay.Text = fa.RetKey4.ToString();
                _SalesOrderMId = Int32.Parse(fa.RetKey.ToString());
                _SalesOrderDId = Int32.Parse(fa.RetKey2.ToString());
            }
            catch (SystemException)
            {   
            }
        }

        private void buttonIptal_Click(object sender, EventArgs e)
        {
            try
            {
                uTerminalServices.ServiceRequestOfInt32 _Param = new ServiceRequestOfInt32();
                _Param.Token = new Token();
                _Param.Token = Data._Token.Token;
                _Param.Value = _RecordResult[0];
                uTerminalServices.ServiceResultOfBoolean _Gelen = Data._UService.DeleteItemTemp(_Param);
                if (_Gelen.Result == true)
                {

                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_DeleteSucces");
                    MessageBox.Show(_MessageStr);
                    ClearValues(); ;

                }
                else
                {
                    MessageBox.Show(_Gelen.Message.ToString());
                    return;
                }
            }
            catch (SystemException ex)
            {
                _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_SaveUnSucces");
                MessageBox.Show(String.Format("Hata:{0} \n Erp Hata: {1}", _MessageStr, ex.Message.ToString()));
            }
        }

        private void TxTransCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxTargetDepot_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dt_DocDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Tx_DocNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_DocNo_ParentChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_TransDate_ParentChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_TransCode_ParentChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_SourceWh_ParentChanged(object sender, EventArgs e)
        {

        }
       
    }
}