using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UTermConnector;
using MobileWhouse.Util;

namespace MobileWhouse.Controls
{
    public partial class FrmIrsaliye : Form, IDisposable
    {
        Boolean _Multi = false;
        int _Type = 0;
        int _TypeFilter = 0;
        int pDefaultDocTraId = 0;
        string pDefaultDocTraCode = string.Empty;
        bool pDefaultDocTraTransfer = false;

        bool pIsUseDocNoWaybill = false;

        string _xNakliyeSekli = "";
        string _xNakliyeSekliId = "";
        string _xNakliyeKodu = "";
        string _xNakliyeKoduId = "";
        string _xIrsaliyeKodu = "";
        Nullable<DateTime> _xIrsaliyeTarihi = null;
        string _xIrsaliyeNo = "";
        string _xIrsaliyeSeri = "";
        string _xIrsaliyeSira = "";
        string _xIrsaliyeKoduId = "";
        bool _xPrint = false;
        bool _xIsTransfer = false; //İrsaliye transfer mi
        int _xAgainstWhouseId = 0; //İrsaliye transfer ise hedef depo

        //string _xNote1 = ""; //İrsaliye Note1
        //string _xNote2 = ""; //İrsaliye Note2
        //string _xNote3 = ""; //İrsaliye Note3




        public FrmIrsaliye(Boolean _MultiSelect, int _pType, int _pTypeFilter, int _DefaultDocTraId, string _DefaultDocTraCode, bool _DefaultDocTraTransfer)
        {
            InitializeComponent();
            _Multi = _MultiSelect;
            _Type = _pType;
            _TypeFilter = _pTypeFilter;
            pDefaultDocTraId = _DefaultDocTraId;
            pDefaultDocTraCode = _DefaultDocTraCode;
            pDefaultDocTraTransfer = _DefaultDocTraTransfer;

            ShowAgainstWhouseCode(pDefaultDocTraTransfer);
        }

        public string _NakliyeSekli
        {
            get { return _xNakliyeSekli; }
        }
        public string _NakliyeSekliId
        {
            get { return _xNakliyeSekliId; }
        }
        public string _NakliyeKodu
        {
            get { return _xNakliyeKodu; }
        }
        public string _NakliyeKoduId
        {
            get { return _xNakliyeKoduId; }
        }
        public string _IrsaliyeKodu
        {
            get { return _xIrsaliyeKodu; }
        }
        public string _IrsaliyeKoduId
        {
            get { return _xIrsaliyeKoduId; }
        }
        public Nullable<DateTime> _IrsaliyeTarihi
        {
            get { return _xIrsaliyeTarihi; }
        }
        public string _IrsaliyeNo
        {
            get { return _xIrsaliyeNo; }
        }
        public string _IrsaliyeSeri
        {
            get { return _xIrsaliyeSeri; }
        }
        public string _IrsaliyeSira
        {
            get { return _xIrsaliyeSira; }
        }
        public bool _Print
        {
            get { return _xPrint; }
        }
        public bool _IsTransfer
        {
            get { return _xIsTransfer; }
        }

        public int _AgainstWhouseId
        {
            get { return _xAgainstWhouseId; }
        }
        public int _TransportTypeId { get; set; }
        public string _TransportTypeCode { get; set; }

        public string _Note1
        {
            get { return Tx_Note1.Text; }
            set { Tx_Note1.Text = value; }
        }

        public string _Note2
        {
            get { return Tx_Note2.Text; }
            set { Tx_Note2.Text = value; }
        }

        public string _Note3
        {
            get { return Tx_Note3.Text; }
            set { Tx_Note3.Text = value; }
        }


        #region araç bilgileri
        int _xVehicleId = 0; //ARaç Kodu
        string _xLicencePlate = string.Empty; //Plaka
        string _xDriverName = string.Empty; // Ad
        string _xDriverFamilyName = string.Empty; //Soyad
        string _xDriverIdentifyNo = string.Empty; //Tckn
        string _xDriverGsmNo = string.Empty; //gsm
        string _xTransportEquipment = string.Empty; //Dorse Plaka
        string _xShippingDesc1 = string.Empty; //Açıklama

        public int _VehicleId { get { return _xVehicleId; } }
        public string _LicencePlate { get { return _xLicencePlate; } }
        public string _DriverName { get { return _xDriverName; } }
        public string _DriverFamilyName { get { return _xDriverFamilyName; } }
        public string _DriverIdentifyNo { get { return _xDriverIdentifyNo; } }
        public string _DriverGsmNo { get { return _xDriverGsmNo; } }
        public string _TransportEquipment { get { return _xTransportEquipment; } }
        public string _ShippingDesc1 { get { return _xShippingDesc1; } }
        #endregion araç bilgileri

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmIrsaliye_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            string _Gelen = "";

            ServiceRequestOfString _Giden = new ServiceRequestOfString();
            _Giden.Token = ClientApplication.Instance.UTermToken;

            ServiceResultOfListOfNameIdItem _Response = ClientApplication.Instance.UTermService.GetTransportTypes(_Giden);


            _Giden = new ServiceRequestOfString();
            _Giden.Token = ClientApplication.Instance.UTermToken;
            ServiceResultOfOutDocNoParameter _ResponseGetDocNo = ClientApplication.Instance.UTermService.GetDocNoParameter(_Giden);
            if (_ResponseGetDocNo.Result == true)
                pIsUseDocNoWaybill = _ResponseGetDocNo.Value.IsUseDocNoWaybill;


            /*Seçmek istemeyenler için ilk kayıt boş olarak oluşturuldu-Megasan*/
            ComboboxItem CiBos = new ComboboxItem();
            CiBos.Text = "";
            CiBos.Value = "";
            CiBos.Id = 0;
            Cbo_Nakliye.Items.Add(CiBos);
            /*Seçmek istemeyenler için ilk kayıt boş olarak oluşturuldu-Megasan*/

            foreach (NameIdItem _Val in _Response.Value)
            {
                ComboboxItem Ci = new ComboboxItem();
                Ci.Text = _Val.Name;
                Ci.Value = _Val.Name;
                Ci.Id = _Val.Id;
                Cbo_Nakliye.Items.Add(Ci);
            }

            //Seyfi 03.02.2016/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Cbo_Nakliye.SelectedIndex = 0;
            bool vBarcodeShreddingEnable = false;//bool.Parse(Classes.SysDefinitions.GetXmlData("BarcodeShredding", "BarcodeShreddingEnable").ToString());
            if (vBarcodeShreddingEnable)
            {
                int vDocTraId = 0;//Int32.Parse(Classes.SysDefinitions.GetXmlData("BarcodeShredding", "WaybillTraId").ToString());
                string vDocTraCode = "";//Classes.SysDefinitions.GetXmlData("BarcodeShredding", "WaybilTraCode").ToString();
                Tx_IrsaliyeKodu.Tag = vDocTraId;
                Tx_IrsaliyeKodu.Text = vDocTraCode;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            bool isMultiOpenWaybillNumber = false;
            try
            {
                isMultiOpenWaybillNumber = ClientApplication.Instance.HandsetParam["FrmIrsaliye", "PRM_MULTI_SELECT_WAYBILL_NUMBER_SHOW"].ToBool();
            }
            catch
            { }

            if (_Multi == true && !isMultiOpenWaybillNumber)
            {
                Lbl_WaybillNumber.Visible = false;
                Tx_IrsaliyeNo.Visible = false;
                Lbl_WaybillSerialOrder.Visible = false;
                Tx_IrsaliyeSeri.Visible = false;
                Tx_IrsaliyeSira.Visible = false;
            }
            Dt_IrsaliyeTarihi.Format = DateTimePickerFormat.Custom;
            Dt_IrsaliyeTarihi.CustomFormat = "dd.MM.yyyy";

            Tx_IrsaliyeKodu.Tag = pDefaultDocTraId;
            Tx_IrsaliyeKodu.Text = pDefaultDocTraCode;
            Cursor.Current = Cursors.Default;
            Cursor.Hide();

            //Tx_Note1.Text = Data._Note1;
            //Tx_Note2.Text = Data._Note2;
            //Tx_Note3.Text = Data._Note3;

            //Data._Note1 = string.Empty;
            //Data._Note2 = string.Empty;
            //Data._Note3 = string.Empty;

            if (this._TransportTypeId > 0)
            {
                SetText(Cbo_Nakliye, this._TransportTypeCode);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowAgainstWhouseCode(false);
            try
            {
                FrmArama Fa = new FrmArama("DocTra2", 0, 0, _TypeFilter);
                Fa.ShowDialog();
                Tx_IrsaliyeKodu.Tag = Fa.RetKey.ToString();
                Tx_IrsaliyeKodu.Text = Fa.RetKey2.ToString();
                _xIsTransfer = Fa.RetKeyIsTransfer;
                if (_xIsTransfer)
                {
                    ShowAgainstWhouseCode(true);
                }

            }
            catch (Exception ex)
            {
                Screens.Error(ex.Message);
                throw;
            }
        }



        private void Cbo_Nakliye_SelectedIndexChanged(object sender, EventArgs e)
        {
            _xNakliyeSekliId = ((ComboboxItem)Cbo_Nakliye.SelectedItem).Value.ToString();
            ServiceRequestOfString _Giden = new ServiceRequestOfString();
            _Giden.Token = ClientApplication.Instance.UTermToken;

            ServiceResultOfListOfNameIdItem _Response = ClientApplication.Instance.UTermService.GetTransporters(_Giden);
            Cbo_NakliyeKod.Items.Clear();
            foreach (NameIdItem _Val in _Response.Value)
            {
                ComboboxItem Ci = new ComboboxItem();
                Ci.Text = _Val.Name;
                Ci.Value = _Val.Name;
                Ci.Id = _Val.Id;
                Cbo_NakliyeKod.Items.Add(Ci);
            }
        }

        private void Cbo_NakliyeKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _xNakliyeKoduId = ((ComboboxItem)Cbo_NakliyeKod.SelectedItem).Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmAracBilgi pFrmAracBilgi = new FrmAracBilgi();
                pFrmAracBilgi.ShowDialog();

                _xVehicleId = pFrmAracBilgi._VehicleId; ; //ARaç Kodu
                _xLicencePlate = pFrmAracBilgi._LicencePlate; ; //Plaka
                _xDriverName = pFrmAracBilgi._DriverName; ; // Ad
                _xDriverFamilyName = pFrmAracBilgi._DriverFamilyName; ; //Soyad
                _xDriverIdentifyNo = pFrmAracBilgi._DriverIdentifyNo; ; //Tckn
                _xDriverGsmNo = pFrmAracBilgi._DriverGsmNo; //gsm
                _xTransportEquipment = pFrmAracBilgi._TransportEquipment; ; //Dorse Plaka
                _xShippingDesc1 = pFrmAracBilgi._ShippingDesc1; //Açıklama
            }
            catch (SystemException ex)
            {
                Screens.Error("Frm İrsaliye Hata : " + ex.Message);
            }

        }

        /// <summary>
        /// İrsaliye'de Transfer'de hedef depo seçimi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgainstWhouseCode_Click(object sender, EventArgs e)
        {
            FrmArama fa = new FrmArama("GetBranchWareHouse", 0, 0, 0);
            fa.TopMost = true;
            fa.ShowDialog();

            if (fa.RetKey.ToString() == "" || fa.RetKey == null) return;
            try
            {
                TxAgainstWhouseCode.Tag = fa.RetKey.ToString();
                TxAgainstWhouseCode.Text = fa.RetKey2.ToString();
                _xAgainstWhouseId = Int32.Parse(fa.RetKey.ToString());
            }
            catch (SystemException ex)
            {
                Screens.Error("System Hata 3:" + ex.Message);
            }
            catch (Exception ex)
            {
                Screens.Error("Hata 3:" + ex.Message);
            }
        }

        /// <summary>
        /// İrsaliye'de hedef depo gizle/göster
        /// </summary>
        /// <param name="xshow"></param>
        private void ShowAgainstWhouseCode(bool xshow)
        {
            if (xshow)
            {
                TxAgainstWhouseCode.Show();
                Lbl_AgainstWhouseCode.Show();
                btnAgainstWhouseCode.Show();
            }
            else
            {
                _xIsTransfer = false;
                _xAgainstWhouseId = 0;
                TxAgainstWhouseCode.Hide();
                Lbl_AgainstWhouseCode.Hide();
                btnAgainstWhouseCode.Hide();
            }
        }

        /// <summary>
        /// Vazgeççç
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _xNakliyeKoduId = "";
            _xIrsaliyeKodu = "";
            _xIrsaliyeNo = "";
            _xIrsaliyeSeri = "";
            _xIrsaliyeTarihi = null;
            _xIrsaliyeSira = "";
            _xNakliyeKodu = "";
            _xNakliyeSekli = "";
            _xIrsaliyeKoduId = "";
            //_xNote1 = "";
            //_xNote2 = "";
            //_xNote3 = "";
            _xAgainstWhouseId = 0;
            this.Close();
        }

        private void Btn_MakeWayBill_Click(object sender, EventArgs e)
        {
            if (pIsUseDocNoWaybill == false && string.IsNullOrEmpty(Tx_IrsaliyeNo.Text.ToString()))
            {
                Screens.Error("Belge Numarası Parametrelerinde [İrsaliye] İçin Kullanım işaretli olmadığından İrsaliye Numarası Girişi Zorunludur");
                return;
            }

            //MessageBox.Show("İşlem Yapılamıyor!!!");
            //return;
            foreach (Control obj in this.Controls)
            {
                if (obj.Tag == null) continue;

                if (obj.Tag.ToString() == "Lbl_WaybillNumber") continue;
                if (_Type == 1 && obj.Tag.ToString() == "Lbl_ShippingType") continue;

                if (obj.Tag.ToString() != "" && obj.Text.ToString() == "")
                {
                    //string _MessageStr = Classes.SysDefinitions.ResMan.GetString("Msg_InfoIncorrect");
                    Screens.Error("Bilgisi hatalı ");
                    return;
                }

            }
            _xNakliyeSekli = Cbo_Nakliye.Text.ToString();
            _xNakliyeKodu = Cbo_NakliyeKod.Text.ToString();
            _xIrsaliyeTarihi = DateTime.ParseExact(Dt_IrsaliyeTarihi.Text, "dd.MM.yyyy", null);
            _xIrsaliyeSira = Tx_IrsaliyeSira.Text.ToString();
            _xIrsaliyeSeri = Tx_IrsaliyeSeri.Text.ToString();
            _xIrsaliyeNo = Tx_IrsaliyeNo.Text.ToString();
            _xIrsaliyeKodu = Tx_IrsaliyeKodu.Text.ToString();
            if (Cbo_Nakliye.SelectedItem != null)
                _xNakliyeSekliId = ((ComboboxItem)Cbo_Nakliye.SelectedItem).Id.ToString();
            if (Cbo_NakliyeKod.SelectedItem != null)
                _xNakliyeKoduId = ((ComboboxItem)Cbo_NakliyeKod.SelectedItem).Id.ToString();
            _xIrsaliyeKoduId = Tx_IrsaliyeKodu.Tag.ToString();

            //_xNote1 = Tx_Note1.Text.ToString();
            //_xNote2 = Tx_Note2.Text.ToString();
            //_xNote3 = Tx_Note3.Text.ToString();

            _xPrint = cbPrint.Checked;

            if (_xNakliyeSekli == null) _xNakliyeSekli = "";
            if (_xNakliyeKodu == null) _xNakliyeKodu = "";
            if (_xIrsaliyeSira == null) _xIrsaliyeSira = "";
            if (_xNakliyeSekliId == null) _xNakliyeSekli = "";
            if (_xNakliyeKoduId == null) _xNakliyeSekli = "";
            if (_xIrsaliyeNo == null) _xIrsaliyeNo = "";
            if (_xIrsaliyeKodu == null) _xIrsaliyeKodu = "";

            //if (_xNote1 == null) _xNote1 = "";
            //if (_xNote2 == null) _xNote2 = "";
            //if (_xNote3 == null) _xNote3 = "";

            this.Close();
        }


        private void SetText(Control cntrl, string text)
        {
            if (cntrl.InvokeRequired)
            {
                ControlSetText p = new ControlSetText(SetText);
                this.Invoke(p, new object[] { cntrl, text });
            }
            else
            {
                cntrl.Text = text;
            }
        }

        private void Tx_IrsaliyeKodu_TextChanged(object sender, EventArgs e)
        {

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

    public delegate void ControlSetText(Control cntrl, string text);
}