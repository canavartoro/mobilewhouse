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
    
    public partial class Frm_MalKabul : Form, IDisposable
    {
        
        FormParameters FormParam = new FormParameters();
        DataTable Dt = new DataTable();

        Boolean _MultiSelect = false;
        int _Procces = 1;
        int _MaxSequence = 0;
        string _RafKodu = "";
        string _AmbalajKodu = "";
        string _SeriKodu = "";
        string _StokKodu = "";
        string _MessageStr = "";
        DateTime lastKeyPress = DateTime.Now;
        uTerminalServices.ServiceResultOfListOfOrderDInfo _OrdList;
        int _OrderMId = 0;
        string _OrderMDoc = "";
        object[] _Idler;
        
        public Frm_MalKabul()
        {
            
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            FrmAramaMulti fa = new FrmAramaMulti();
            fa.ShowDialog();
            if (fa.RetKey == null) return;
            List<Int16> _GelenList = fa.RetKey;
            _Idler = new object[500];

            for (int i = 0; i < _GelenList.Count; i++)
            {
                _Idler[i] = _GelenList[i];
            } 


            //FrmArama fa = new FrmArama("",0,0);
            //fa.ShowDialog();
            //if (fa.RetKey.ToString() == "" || fa.RetKey.ToString() == null) return;
            try
            {
               
                //_OrderMId = Int32.Parse(fa.RetKey.ToString());
                _OrderMDoc = fa.RetKey2.ToString();
                TxOrderNo.Text = _OrderMDoc;

                uTerminalServices.ServiceRequestOfOrderDParam _OrdP = new uTerminal.uTerminalServices.ServiceRequestOfOrderDParam();
                _OrdP.Token = new uTerminal.uTerminalServices.Token();
                _OrdP.Token = Data._Token.Token;
                _OrdP.Value = new uTerminal.uTerminalServices.OrderDParam();

                if (_GelenList.Count == 0) return;

                if (_GelenList.Count > 1)
                {
                    _MultiSelect = true;
                    _OrdP.Value.OrderMIds = _Idler;
                    
                }
                else
                {
                    _OrdP.Value.OrderMId = int.Parse(_Idler[0].ToString());
                    _MultiSelect = false;
                }
                
                
                _OrdP.Value.PageSize = 3000;
                _OrdP.Value.PurchaseSales = 1;

                _OrdList = new ServiceResultOfListOfOrderDInfo();
                _OrdList = Data._UService.GetOrderDInfo(_OrdP);
                
                
            }
            catch (SystemException)
            {
                
            }

            SetDataToGrid();
            dataGrid1.DataSource = Dt;
            dataGrid1.Refresh();
        }


        private void SetDataToGrid()
        {
            Dt.Rows.Clear();
            try
            {
                var _Liste = from p in _OrdList.Value orderby p.DcardId select p;

                foreach (uTerminalServices.OrderDInfo _DInfo in _Liste)
                {
                    DataRow Dr = Dt.NewRow();
                    Dr["ITEM_ID"] = _DInfo.DcardId;
                    Dr["STOK_AD"] = _DInfo.DcardCode + " / " + _DInfo.DcardName;
                    Dr["BIRIM"] = _DInfo.ItemUnitCode.ToString();
                    Dr["PARTI"] = "";
                    Dr["AMBALAJ"] = "";
                    Dr["SIPMIK"] = _DInfo.QtyRemaining;
                    Dr["OKUNAN"] = _DInfo.Qty;
                    Dt.Rows.Add(Dr);
                }
            }
            catch (SystemException)
            {
            }
            dataGrid1.DataSource = Dt;
            dataGrid1.Refresh();
        }

        private void SetGridColumns()
        {
            try
            {
                dataGrid1.TableStyles.Clear();

                DataGridTableStyle ts = new DataGridTableStyle();
                ts.MappingName = "Table1";

                DataGridColumnStyle Col0 = new DataGridTextBoxColumn();
                Col0.MappingName = "ITEM_ID";
                Col0.HeaderText = "";
                Col0.Width = -1;
                ts.GridColumnStyles.Add(Col0);


                DataGridColumnStyle Col1 = new DataGridTextBoxColumn();
                Col1.MappingName = "STOK_AD";
                Col1.HeaderText = "Stok Adı";
                Col1.Width = Convert.ToInt32(dataGrid1.Width * 0.50);
                ts.GridColumnStyles.Add(Col1);

                DataGridColumnStyle Col11 = new DataGridTextBoxColumn();
                Col11.MappingName = "BIRIM";
                Col11.HeaderText = "Birim";
                Col11.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col11);

                DataGridColumnStyle Col2 = new DataGridTextBoxColumn();
                Col2.MappingName = "SIPMIK";
                Col2.HeaderText = "Sip.Mik";
                Col2.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col2);

                DataGridColumnStyle Col3 = new DataGridTextBoxColumn();
                Col3.MappingName = "OKUNAN";
                Col3.HeaderText = "Okunan";
                Col3.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col3);


                DataGridColumnStyle Col4 = new DataGridTextBoxColumn();
                Col4.MappingName = "PARTI";
                Col4.HeaderText = "Parti";
                Col4.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col4);

                DataGridColumnStyle Col5 = new DataGridTextBoxColumn();
                Col5.MappingName = "AMBALAJ";
                Col5.HeaderText = "Ambalaj";
                Col5.Width = Convert.ToInt32(dataGrid1.Width * 0.12);
                ts.GridColumnStyles.Add(Col5);


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
                Dt.TableName = "Table1";
                FormParam = Data.FParam("Frm_MalKabul");
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

                Tx_Barcode.KeyDown += new KeyEventHandler(Tx_Barcode_KeyDown);

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

                Tx_Miktar.Text = FormParam.PRM_DEFAULTAMOUNT.ToString();
                SetSquence();
                Tx_Barcode.Focus();

                if (FormParam.PRM_USERACKCODE == false)
                {
                    Tx_Raf.Visible = false;
                    Lbl_Rack.Visible = false;
                }

                Dt.Columns.Add("ITEM_ID", Type.GetType("System.Int32"));
                Dt.Columns.Add("STOK_AD", Type.GetType("System.String"));
                Dt.Columns.Add("BIRIM", Type.GetType("System.String"));
                Dt.Columns.Add("SIPMIK", Type.GetType("System.String"));
                Dt.Columns.Add("OKUNAN", Type.GetType("System.Int32"));
                Dt.Columns.Add("PARTI", Type.GetType("System.String"));
                Dt.Columns.Add("AMBALAJ", Type.GetType("System.String"));
                SetGridColumns();
            }
            catch (SystemException)
            {
            }

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
                if (Dt.Rows.Count == 0)
                {
                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_SelectOrder");
                    MessageBox.Show(_MessageStr);
                    Tx_Barcode.Text = "";
                    return;
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
                    _RafKodu = _xCode;

                    uTerminalServices.ServiceRequestOfItemSelectParam _Sp = new ServiceRequestOfItemSelectParam();
                    _Sp.Token = new Token();
                    _Sp.Token = Data._Token.Token;
                    _Sp.Value = new ItemSelectParam();
                    _Sp.Value.Barkod = _RafKodu;
                    _Sp.Value.DepotId = Data._SelectedWareHouse;

                    uTerminalServices.ServiceResultOfNameIdItem _Res = Data._UService.GetLocationInfo(_Sp);
                    if (_Res.Result == false)
                    {
                        MessageBox.Show(_Res.Message.ToString());
                        return;
                    }
                    
                    Tx_Raf.Text = _RafKodu;
                    Tx_Barcode.Focus();
                }
                if (_Fp.ToString() == FormParam.PRM_SERIALLABEL.ToString().ToString())
                { _SeriKodu = _xCode; Tx_Barcode.Focus(); }
                if (_Fp.ToString() == FormParam.PRM_STOCKLABEL.ToString())
                { _StokKodu = _xCode; Tx_Barcode.Focus(); }


                if (_Procces == _MaxSequence)
                {
                    ProccesDataBarcode(_xCode);
                    _Procces = 1;
                    Tx_Raf.Text = "";
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
                ServiceResultOfItemInfo _ItemInfo = Data._SrvcItemInfo(_xCode);

                if (_ItemInfo.Result == false)
                {
                    MessageBox.Show(_ItemInfo.Message.ToString());
                    return;
                }
                decimal _Miktar = Int32.Parse(Tx_Miktar.Text.ToString()) * (Chk_Delete.CheckState == CheckState.Checked ? -1 : 1);

                var _Kont = from t in _OrdList.Value where t.DcardId == _ItemInfo.Value.Id select t;
                var _ToplaKalan = _Kont.Sum(t => t.QtyRemaining);
                var _ToplaOkunan = _Kont.Sum(t => t.Qty);
                if (_Miktar > 0)
                {
                    if ((Decimal.Parse(_ToplaKalan.ToString()) - Decimal.Parse(_ToplaOkunan.ToString())) < _Miktar)
                    {
                        _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_MorePieces");
                        MessageBox.Show(_MessageStr);
                        return;
                    }
                }
                else
                {

                    if (Decimal.Parse(_ToplaOkunan.ToString()) == 0)
                    {
                        _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_NoRecordDelete");
                        MessageBox.Show(_MessageStr);
                        return;
                    }

                    if (Decimal.Parse(_ToplaOkunan.ToString()) < _Miktar * -1)
                    {
                        _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_MorePieces");
                        MessageBox.Show(_MessageStr);
                        return;
                    }

                    _Miktar = _Miktar * -1;
                Tekrar1:
                    var _ListeDelete = from p in _OrdList.Value where p.DcardId == _ItemInfo.Value.Id && p.Qty > 0 select p;
                    foreach (uTerminalServices.OrderDInfo _DInfo in _ListeDelete) //_OrdList.Value
                    {
                        if (_DInfo.Qty >= (_Miktar))
                        {
                            _DInfo.Qty -= _Miktar;
                        }
                        else
                        {
                            _Miktar -= _DInfo.Qty;
                            _DInfo.Qty = 0;
                            goto Tekrar1;
                        }

                    }

                    SetDataToGrid();
                    return;
                }




            Tekrar:
                var _Liste = from p in _OrdList.Value where p.DcardId == _ItemInfo.Value.Id && p.Qty < p.QtyRemaining select p;

                foreach (uTerminalServices.OrderDInfo _DInfo in _Liste) //_OrdList.Value
                {
                    if (_DInfo.DcardId != _ItemInfo.Value.Id) continue;
                    if (_DInfo.Qty >= _DInfo.QtyRemaining) continue;
                    if (_DInfo.Qty + _Miktar > _DInfo.QtyRemaining)
                    {
                        _Miktar = _Miktar - (_DInfo.QtyRemaining - _DInfo.Qty);
                        _DInfo.Qty += _DInfo.QtyRemaining - _DInfo.Qty;
                        
                        goto Tekrar;
                    }
                    else
                    {
                        _DInfo.Qty += _Miktar;
                        break;
                    }
                }

                SetDataToGrid();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i][0].ToString() == _ItemInfo.Value.Id.ToString())
                        dataGrid1.Select(i);
                }
            }
            catch (SystemException)
            {
            }
      
        }

        private void Frm_MalKabul_Closed(object sender, EventArgs e)
        {
            FormParam = null;
            Dt = null;
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
            Tx_Raf.Text = "";
            _RafKodu = ""; 
            _AmbalajKodu = ""; 
            _SeriKodu = ""; 
            _StokKodu = "";
            SetSquence();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (Dt.Rows.Count.Count() == 0)
            //{
            //    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_SelectOrder");
            //    MessageBox.Show(_MessageStr);
            //    Tx_Barcode.Text = "";
            //    return;
            //}

           // if (Data.TrmService.SaveOrder(Int32.Parse(TxOrderNo.Text.ToString()),Ds) == true)
           //{
           // _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_SaveSucces");
           // MessageBox.Show(_MessageStr);
           //}
           //else
           //{
           // _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_SaveUnSucces");
           // MessageBox.Show(_MessageStr);
           //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _IrsaliyeNo = "";
            string _IrsaliyeTarihi = "";
            string _IrsaliyeKoduId = "";
            string _IrsaliyeSeri = "";
            string _IrsaliyeSira = "";
            string _NakliyeKoduId = "";
            string _NakliyeSekliId = "";

            Boolean _OkumaVar = false;
            foreach (DataRow Dr in Dt.Rows)
            {
                if (int.Parse(Dr["OKUNAN"].ToString()) > 0) { _OkumaVar = true; break; }
            }

            if (_OkumaVar == false)
            {
                MessageBox.Show("Okuma Yoktur İrsaliye Oluşturulamaz");
                return;
            }

            try
            {
               
                FrmIrsaliye Fi = new FrmIrsaliye(_MultiSelect,1,1);
                Fi.ShowDialog();
                if (Fi._IrsaliyeTarihi == null) return;

                _IrsaliyeNo = Fi._IrsaliyeNo;
                _IrsaliyeTarihi = Fi._IrsaliyeTarihi.ToString();
                _IrsaliyeKoduId = Fi._IrsaliyeKoduId;
                _NakliyeKoduId = Fi._NakliyeKoduId.ToString();
                _NakliyeSekliId = Fi._NakliyeSekliId.ToString();

                if (_MultiSelect == false)
                {
                    _IrsaliyeSeri = Fi._IrsaliyeSeri;
                    _IrsaliyeSira = Fi._IrsaliyeSira;
                }
               
                Classes.SysDefinitions.CursorState("Wait");
                uTerminalServices.ServiceRequestOfWaybillInfo _WiInfo = new ServiceRequestOfWaybillInfo();
                _WiInfo.Token = new Token();
                _WiInfo.Token = Data._Token.Token;
                _WiInfo.Value = new WaybillInfo();
                _WiInfo.Value.BelgeNo = _IrsaliyeNo;
                _WiInfo.Value.Date = Convert.ToDateTime(_IrsaliyeTarihi);
                _WiInfo.Value.DocTraId = Int32.Parse(_IrsaliyeKoduId);
                if (_MultiSelect == false)
                {
                    _WiInfo.Value.VoucherSerial = _IrsaliyeSeri;
                    _WiInfo.Value.VoucherNo = _IrsaliyeSira;
                }
                _WiInfo.Value.TransporterId = Int32.Parse(_NakliyeKoduId.ToString());
                _WiInfo.Value.TransportTypeId = Int32.Parse(_NakliyeSekliId.ToString());

                if (_MultiSelect == false)
                    _WiInfo.Value.MasterId = int.Parse(_Idler[0].ToString());
                else
                    _WiInfo.Value.MasterIds = _Idler;

                List<OrderDetailInfo> _OrdListe = new List<OrderDetailInfo>();


                foreach (uTerminalServices.OrderDInfo _DInfo in _OrdList.Value)
                {
                    OrderDetailInfo _Od = new OrderDetailInfo();
                    _Od.ItemId = _DInfo.DcardId;
                    _Od.LotId = 0;
                    _Od.PackageTypeId = 0;
                    _Od.QualityId = 0;
                    _Od.UnitId = 0;
                    _Od.WhouseId = Data._SelectedWareHouse;
                    _Od.Qty = _DInfo.Qty;
                    _Od.OrderDetailId = _DInfo.Id;
                    _Od.OrderMId = _DInfo.MId;
                    _OrdListe.Add(_Od);
                }

                _WiInfo.Value.OrderDetails = _OrdListe.ToArray();
                uTerminalServices.ServiceResultOfBoolean _Gelen = Data._UService.SavePurchaseWaybill(_WiInfo);
                if (_Gelen.Result == true)
                {
                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_WalbillCreate");
                    MessageBox.Show(_MessageStr);
                    Classes.SysDefinitions.CursorState("Default");
                    ClearValues();
                }
                else
                {
                    _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_WalbillNotCreate") + Environment.NewLine + _Gelen.Message.ToString();
                    MessageBox.Show(_MessageStr);
                    Classes.SysDefinitions.CursorState("Default");
                    return;
                }
            }
            catch (SystemException err)
            {
                _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_WalbillNotCreate") + " " + Environment.NewLine + " " + err.Message.ToString();
                MessageBox.Show(_MessageStr);
                Classes.SysDefinitions.CursorState("Default");
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
            //Ds.Clear();
            //Ds.Reset();
            Dt.Clear();
            TxOrderNo.Text = "";
            Tx_Barcode.Text = "";
            Tx_Raf.Text = "";
            dataGrid1.DataSource = null;
            dataGrid1.Refresh();
        }

        private void TxOrderNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lbl_OrderNumber_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}