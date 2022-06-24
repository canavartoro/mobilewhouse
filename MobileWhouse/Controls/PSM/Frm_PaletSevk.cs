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
    public partial class Frm_PaletSevk : BaseControl
    {
        bool _Okutma_HataVar = false;
        DateTime lastKeyPress = DateTime.Now;
        DataTable DtOrderQtyControl = new DataTable();
        DataTable DtOrder = new DataTable();
        DataTable DtPackage = new DataTable();

        DataTable DtPackageShow = new DataTable();
        DataTable DtPackageItems = new DataTable();
        DataTable DtPackageItemShow = new DataTable();
        bool _KarmaPaketIzinVar = false, _SadeceSipariseAitPaketler = false, _MusteriKontrol = false;

        List<DataRow> ReadPackages = new List<DataRow>();
        string[] ReferralOrderDIds = new string[0];
        string[] ReferralOrderCodes = new string[0];
        //int _OrderMId = 0;//GetReferralOrdersDetail

        int pSourceApp = 143; //SourceApplication.SevkEmri 
        //int pSourceApp2 = 212; //SourceApplication.Ambalaj
        bool _Print = false;
        string _PrinterName = string.Empty;

        int _PersonId = 0;
        string _PersonCode = string.Empty;
        #region Kolon Başlıkları
        ServiceResultOfListOfColumnLabels _ColumnLabelsList;
        string pColumnLabelAttiribute1 = "Öz.1"; //ColumnLabel
        string pColumnLabelAttiribute2 = "Öz.2"; //ColumnLabel
        string pColumnLabelAttiribute3 = "Öz.3"; //ColumnLabel
        string pColumnLabelQuality = "Klt."; //ColumnLabel
        string pColumnLabelColor = "Renk"; //ColumnLabel
        string pColumnLabelLot = "Parti"; //ColumnLabel     
        string pItemAddString01 = "Ek Alan-01"; //ColumnLabel     

        #endregion Kolon Başlıkları

        int pTempCoDocTraIdWaybill = 0;
        string pTempCoDocTraCodeWaybill = string.Empty;
        string _BarcodeBitisKarakter = string.Empty;
        ServiceResultOfPackageDetail _PacRes = new ServiceResultOfPackageDetail();

        int _VehicleId = 0; //ARaç Kodu
        string _LicencePlate = string.Empty; //Plaka
        string _DriverName = string.Empty; // Ad
        string _DriverFamilyName = string.Empty; //Soyad
        string _DriverIdentifyNo = string.Empty; //Tckn
        string _DriverGsmNo = string.Empty; //gsm
        string _TransportEquipment = string.Empty; //Dorse Plaka
        string _ShippingDesc1 = string.Empty; //Açıklama

        bool _IsTransfer = false; //İrsaliye transfer mi
        int _AgainstWhouseId = 0; //İrsaliye transfer ise hedef depo

        int pColumnWidth = 0; //Kolon Gizleme içindir.
        int pColumnWidth2 = 0; //Kolon Gizleme içindir.


        ServiceResultOfNameIdItem pRafKontrolReturn;
        bool pReadLocationUsed = false;
        int pReadLocationId = 0;

        public Frm_PaletSevk()
        {
            InitializeComponent();
        }

        private void Frm_PaletSevk_Load(object sender, EventArgs e)
        {

            GetLabels();

            DtOrder.TableName = "TableD";
            DtPackage.TableName = "PackageTable";
            DtPackageShow.TableName = "PackageTableShow";
            DtPackageItems.TableName = "PackageItemTable";
            DtPackageItemShow.TableName = "DtPackageItemShow";


            _BarcodeBitisKarakter = ClientApplication.Instance.HandsetParam["AllPage", "BARKOD_BITIS_KARAKTERI"].ToSt();
            _MusteriKontrol = ClientApplication.Instance.HandsetParam["AllPage", "MUSTERI_KONTROL"].ToBool();
            _KarmaPaketIzinVar = ClientApplication.Instance.HandsetParam["Frm_PaletSevk", "KARMA_PALET"].ToBool();
            _SadeceSipariseAitPaketler = ClientApplication.Instance.HandsetParam["Frm_PaletSevk", "SADECE_SIPARISE_AIT_PAKETLER"].ToBool();

            /* if (_KarmaPaketIzinVar)
             {
                 Tx_Barcode.Enabled = false;
                 BackColor = Color.Red;
                 btnSevkSec.Enabled = false;
                 MessageBox.Show("Bu Ekranda Karma Palet Kullanılamaz");
                 //
                 // Bu sistem üzerinde çalışmak ve detaylı 
                 // * test yapılması gerekmektedir.
                 // * NetBor
                 // * Salim Demiray, Ahmet Yıldırım
                 // * 2017-08-28
                 return;


             }*/

            ReadLocationUsed(); //raf okutma işlemi....
            GridColumnsGeneate();
            ActionTest();
        }

        private void GetLabels()
        {
            //_ColumnLabelsList = Data._GetLabels();

            if (_ColumnLabelsList != null)
            {
                var _ListeD = from p in _ColumnLabelsList.Value orderby p.ColumnName select p;
                foreach (ColumnLabels item in _ListeD)
                {
                    if (item.ColumnName == "ItemAttributeCode1") pColumnLabelAttiribute1 = item.ColumnLabel.Replace(" ", "");
                    if (item.ColumnName == "ItemAttributeCode2") pColumnLabelAttiribute2 = item.ColumnLabel.Replace(" ", "");
                    if (item.ColumnName == "ItemAttributeCode3") pColumnLabelAttiribute3 = item.ColumnLabel.Replace(" ", "");
                    if (item.ColumnName == "QualityCode") pColumnLabelQuality = item.ColumnLabel.Replace(" ", "");
                    if (item.ColumnName == "ColorCode") pColumnLabelColor = item.ColumnLabel.Replace(" ", "");
                    if (item.ColumnName == "LotCode") pColumnLabelLot = item.ColumnLabel.Replace(" ", "");
                    if (item.ColumnName == "Item_AddString01") pItemAddString01 = item.ColumnLabel.Replace(" ", "");
                }
            }
        }

        private void Tx_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (Tx_Barcode.Text.Length > 0 && _BarcodeBitisKarakter != string.Empty)
                {
                    if (_BarcodeBitisKarakter.ToLower() == "bosluk")
                    {
                        if (Tx_Barcode.Text.IndexOf(" ") > 0)
                        {
                            Tx_Barcode.Text = Tx_Barcode.Text.Substring(0, Tx_Barcode.Text.IndexOf(" "));
                        }
                    }
                    else if (Tx_Barcode.Text.IndexOf(_BarcodeBitisKarakter) > 0)
                    {
                        Tx_Barcode.Text = Tx_Barcode.Text.Substring(0, Tx_Barcode.Text.IndexOf(_BarcodeBitisKarakter) - 1);
                    }
                }
                ProcessData(Tx_Barcode.Text);
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {

        }


        private void btnPrintIrsaliye_Click(object sender, EventArgs e)
        {

        }


        int _NakliyeSekliId = 0, _NakliyeKoduId = 0, _IrsaliyeKoduId = 0;
        DateTime _IrsaliyeTarihi = DateTime.MinValue;
        string _IrsaliyeNo = "", _IrsaliyeSeri = "", _IrsaliyeSiraNo = "",
        _Irsaliye_Note1 = "",
        _Irsaliye_Note2 = "",
        _Irsaliye_Note3 = "";

        private void btnIrsaliyeOlustur_Click(object sender, EventArgs e)
        {
            btnIrsaliyeOlustur.Enabled = false;
            #region
            if (ClientApplication.Instance.HandsetParam["Frm_PaletSevk", "EKSIK_OKUTULAN_STOK_KONTROL"].ToBool())
            {
                StringBuilder pEksikOkunan = new StringBuilder();
                foreach (DataRow Dr in DtOrder.Rows)
                {
                    if (Dr["LINE_TYPE"].ToString() == "H") /*Hizmet İse*/
                        continue;

                    decimal pDiffQty = Convert.ToDecimal(Dr["QTY"]) - Convert.ToDecimal(Dr["READ_QTY"]);
                    if (pDiffQty > 0)
                    {
                        if (pEksikOkunan.ToString().Length == 0)
                            pEksikOkunan.AppendLine();
                        pEksikOkunan.AppendLine(string.Format("{0}:{1}:{2}:{3}:{4}", Dr["LINE_NO"].ToString(),
                                                                                    Dr["ITEM_CODE"].ToString(),
                                                                                    decimal.Round(Convert.ToDecimal(Dr["QTY"]), 2),
                                                                                    decimal.Round(Convert.ToDecimal(Dr["READ_QTY"]), 2),
                                                                                    decimal.Round(pDiffQty, 2)));
                    }
                }
                if (pEksikOkunan.ToString().Length > 0)
                {
                    if (!Screens.Question(string.Format("{0}{1}", "Eksik okunan Stoklarınız var. Devam Etmek İstiyormusunuz", pEksikOkunan.ToString())))
                    {
                        btnIrsaliyeOlustur.Enabled = true;
                        return;
                    }
                }

            }
            #endregion
            #region Eğer Sevk Emri içerisinde Hizmet Satırı var ise En az bir adet hizmet satırı seçilmek zorundadır.
            DataRow pHizmetVar = DtOrder.AsEnumerable().Where(t => t.Field<string>("LINE_TYPE") == "H").FirstOrDefault();
            if (pHizmetVar != null)
            {
                DataRow pSeciliHizmetVar = DtOrder.AsEnumerable().Where(t => t.Field<string>("LINE_TYPE") == "H" &&
                                                                           t.Field<bool>("CREATE_WAYBILL") == true).FirstOrDefault();
                if (pSeciliHizmetVar == null)
                {
                    Screens.Error("Hizmet Kartı Olan Bir Sevk Emrinde, İrsaliye Oluşturmak için En az 1 Adet Hizmet Seçilmelidir");
                    btnIrsaliyeOlustur.Enabled = true;
                    return;
                }
            }
            #endregion
            FrmIrsaliye Fi = new FrmIrsaliye(false, 1, 2, pTempCoDocTraIdWaybill, pTempCoDocTraCodeWaybill, false);
            Fi.ShowDialog();
            if (Fi._IrsaliyeTarihi == null)
            {
                btnIrsaliyeOlustur.Enabled = true;
                return;
            }


            if (!string.IsNullOrEmpty(Fi._NakliyeSekliId)) _NakliyeSekliId = Convert.ToInt32(Fi._NakliyeSekliId);
            if (!string.IsNullOrEmpty(Fi._NakliyeKoduId)) _NakliyeKoduId = Convert.ToInt32(Fi._NakliyeKoduId);
            if (!string.IsNullOrEmpty(Fi._IrsaliyeKoduId)) _IrsaliyeKoduId = Convert.ToInt32(Fi._IrsaliyeKoduId);
            _IrsaliyeTarihi = Fi._IrsaliyeTarihi ?? DateTime.MinValue;
            _IrsaliyeNo = Fi._IrsaliyeNo;
            _IrsaliyeSeri = Fi._IrsaliyeSeri;
            _IrsaliyeSiraNo = Fi._IrsaliyeSira;
            _Irsaliye_Note1 = Fi._Note1;
            _Irsaliye_Note2 = Fi._Note2;
            _Irsaliye_Note3 = Fi._Note3;

            _Print = Fi._Print;

            _VehicleId = Fi._VehicleId; ; //ARaç Kodu
            _LicencePlate = Fi._LicencePlate; ; //Plaka
            _DriverName = Fi._DriverName; ; // Ad
            _DriverFamilyName = Fi._DriverFamilyName; ; //Soyad
            _DriverIdentifyNo = Fi._DriverIdentifyNo; ; //Tckn
            _DriverGsmNo = Fi._DriverGsmNo; //gsm
            _TransportEquipment = Fi._TransportEquipment; ; //Dorse Plaka
            _ShippingDesc1 = Fi._ShippingDesc1; //Açıklama
            _IsTransfer = Fi._IsTransfer; //Hareket Kodu Transfer mi ?
            _AgainstWhouseId = Fi._AgainstWhouseId; //Hareket Kodu Transfer mi ?
            if (_IsTransfer && _AgainstWhouseId == 0)
            {
                btnIrsaliyeOlustur.Enabled = true;
                Screens.Error("Seçilen Hareket Kodunda Depolar Arası Stok Transferi İşaretli ise Karşı Depo Zorunludur [FrmPaletSevk]");
            }
            else
            {
                CreateOrderShipping();
            }
        }

        private void GridColumnsGeneate()
        {
            try
            {

                gridOrder.TableStyles.Clear();
                gridPackage.TableStyles.Clear();
                gridPackageItem.TableStyles.Clear();

                DtOrder.Columns.Clear();
                DtPackage.Columns.Clear();
                DtPackageItems.Columns.Clear();



                DataGridTableStyle tsGridOrder = new DataGridTableStyle();
                tsGridOrder.MappingName = "TableD";
                gridOrder.TableStyles.Add(tsGridOrder);

                DataGridTableStyle tsGridPackage = new DataGridTableStyle();
                tsGridPackage.MappingName = "PackageTableShow";
                gridPackage.TableStyles.Add(tsGridPackage);

                DataGridTableStyle tsGridPackageItem = new DataGridTableStyle();
                tsGridPackageItem.MappingName = "DtPackageItemShow";
                gridPackageItem.TableStyles.Add(tsGridPackageItem);

                #region Order Grid
                AddColumnToGrid(DtOrder, "LINE_NO", "S.No", typeof(string), tsGridOrder, gridOrder.Width * 0.10);
                AddColumnToGrid(DtOrder, "ITEM_CODE", "Stok Kodu", typeof(string), tsGridOrder, gridOrder.Width * 0.25);
                AddColumnToGrid(DtOrder, "ITEM_NAME", "Stok Adı", typeof(string), tsGridOrder, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrder, "ITEM_ID", "", typeof(int), tsGridOrder, -1);

                AddColumnToGrid(DtOrder, "QTY", "Miktar", typeof(decimal), tsGridOrder, gridOrder.Width * 0.15);
                AddColumnToGrid(DtOrder, "READ_QTY", "Okunan Miktar", typeof(decimal), tsGridOrder, gridOrder.Width * 0.15);
                AddColumnToGrid(DtOrder, "NOTE1", "Açk-1", typeof(string), tsGridOrder, gridOrder.Width * 0.25);

                AddColumnToGrid(DtOrder, "LINE_TYPE", "Tip", typeof(string), tsGridOrder, gridOrder.Width * 0.10);
                AddColumnToGrid(DtOrder, "CREATE_WAYBILL", "H.Seç", typeof(bool), tsGridOrder, gridOrder.Width * 0.15); //Stok Dışındaki Satırların İrsaliyeye Eklenmesi içindir

                AddColumnToGrid(DtOrder, "WAREHOUSE_CODE", "Depo Kodu", typeof(string), tsGridOrder, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrder, "WAREHOUSE_ID", "", typeof(int), tsGridOrder, -1);

                pColumnWidth = ClientApplication.Instance._IsQuality ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrder, "QUALITY_CODE", pColumnLabelQuality, typeof(string), tsGridOrder, pColumnWidth);
                AddColumnToGrid(DtOrder, "QUALITY_ID", "", typeof(int), tsGridOrder, -1);

                pColumnWidth = ClientApplication.Instance._IsColor ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrder, "COLOR_CODE", pColumnLabelColor, typeof(string), tsGridOrder, pColumnWidth);
                AddColumnToGrid(DtOrder, "COLOR_ID", "", typeof(int), tsGridOrder, -1);

                pColumnWidth = ClientApplication.Instance._IsLot ? Convert.ToInt32(gridOrder.Width * 0.30) : -1;
                AddColumnToGrid(DtOrder, "LOT_CODE", pColumnLabelLot, typeof(string), tsGridOrder, pColumnWidth);
                AddColumnToGrid(DtOrder, "LOT_ID", "", typeof(int), tsGridOrder, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute1 ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrder, "ITEM_ATTRIBUTE1_CODE", pColumnLabelAttiribute1, typeof(string), tsGridOrder, pColumnWidth);
                AddColumnToGrid(DtOrder, "ITEM_ATTRIBUTE1_ID", "Özellik-1 Id", typeof(int), tsGridOrder, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute2 ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrder, "ITEM_ATTRIBUTE2_CODE", pColumnLabelAttiribute2, typeof(string), tsGridOrder, pColumnWidth);
                AddColumnToGrid(DtOrder, "ITEM_ATTRIBUTE2_ID", "Özellik-2 Id", typeof(int), tsGridOrder, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute3 ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrder, "ITEM_ATTRIBUTE3_CODE", pColumnLabelAttiribute3, typeof(string), tsGridOrder, pColumnWidth);
                AddColumnToGrid(DtOrder, "ITEM_ATTRIBUTE3_ID", "Özellik-3 Id", typeof(int), tsGridOrder, -1);

                pColumnWidth = ClientApplication.Instance._IsFreeUnit1 ? Convert.ToInt32(gridOrder.Width * 0.30) : -1;
                pColumnWidth2 = ClientApplication.Instance._IsFreeUnit1 ? Convert.ToInt32(gridOrder.Width * 0.15) : -1;

                AddColumnToGrid(DtOrder, "QTY_FREE_PRM", "Bağımsız Miktar", typeof(decimal), tsGridOrder, pColumnWidth2);
                AddColumnToGrid(DtOrder, "FREE_PRM_CODE", "Bağımsız Birimi", typeof(string), tsGridOrder, pColumnWidth);
                AddColumnToGrid(DtOrder, "FREE_PRMM_ID", "", typeof(int), tsGridOrder, -1);


                AddColumnToGrid(DtOrder, "REFERRAL_DTL_ID", "", typeof(int), tsGridOrder, -1);
                AddColumnToGrid(DtOrder, "SOURCE_D_ID", "", typeof(int), tsGridOrder, -1);
                AddColumnToGrid(DtOrder, "SOURCE_M_ID", "", typeof(int), tsGridOrder, -1);

                //hrmd_payroll_type_d3
                AddColumnToGrid(DtOrder, "REFEREL_ORDER_CODE", "Sevk.Emri", typeof(string), tsGridOrder, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrder, "INCOTERMS_NAME", "Teslim Şekli", typeof(string), tsGridOrder, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrder, "PAYMENT_METHOD_DESC", "Ödeme Şekli", typeof(string), tsGridOrder, gridOrder.Width * 0.35);

                AddColumnToGrid(DtOrder, "ITEM_ADDSTRING01", pItemAddString01, typeof(string), tsGridOrder, gridOrder.Width * 0.30);
                AddColumnToGrid(DtOrder, "IS_SERIALTRACK", "Serili", typeof(bool), tsGridOrder, gridOrder.Width * 0.15); //Seri Takibi var .

                AddColumnToGrid(DtOrder, "SALES_TOLERANCE_MAX_SO", "F.S.%", typeof(decimal), tsGridOrder, gridOrder.Width * 0.20);
                AddColumnToGrid(DtOrder, "QTY_MAX_SO", "T.F.Sevk Mik.", typeof(decimal), tsGridOrder, -1);
                #endregion


                #region Find DataRow Grid
                //AddDtFindDataColumn();
                #endregion Find dataRow
                #region Package Grid

                AddColumnToGrid(DtPackage, "LINE_NO", "Satır No", typeof(string), tsGridPackage, gridPackage.Width * 0.25);
                AddColumnToGrid(DtPackage, "ITEM_CODE", "Stok Kodu", typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "ITEM_NAME", "Stok Adı", typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "ITEM_ID", "", typeof(int), tsGridPackage, -1);
                AddColumnToGrid(DtPackage, "PACKAGE_NO", "Ambalaj No", typeof(string), tsGridPackage, gridPackage.Width * 0.25);
                AddColumnToGrid(DtPackage, "PACKAGE_M_ID", "", typeof(int), tsGridPackage, -1);
                AddColumnToGrid(DtPackage, "QTY", "Miktar", typeof(decimal), tsGridPackage, gridPackage.Width * 0.15);
                AddColumnToGrid(DtPackage, "READ_QTY", "OkunanMiktar", typeof(decimal), tsGridPackage, gridPackage.Width * 0.25);

                pColumnWidth = ClientApplication.Instance._IsQuality ? Convert.ToInt32(gridPackage.Width * 0.35) : -1;
                AddColumnToGrid(DtPackage, "QUALITY_CODE", pColumnLabelQuality, typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "QUALITY_ID", "", typeof(int), tsGridPackage, -1);

                pColumnWidth = ClientApplication.Instance._IsColor ? Convert.ToInt32(gridPackage.Width * 0.35) : -1;
                AddColumnToGrid(DtPackage, "COLOR_CODE", pColumnLabelColor, typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "COLOR_ID", "", typeof(int), tsGridPackage, -1);

                pColumnWidth = ClientApplication.Instance._IsLot ? Convert.ToInt32(gridPackage.Width * 0.35) : -1;
                AddColumnToGrid(DtPackage, "LOT_CODE", pColumnLabelLot, typeof(string), tsGridPackage, gridPackage.Width * 0.30);
                AddColumnToGrid(DtPackage, "LOT_ID", "", typeof(int), tsGridPackage, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute1 ? Convert.ToInt32(gridPackage.Width * 0.35) : -1;
                AddColumnToGrid(DtPackage, "ITEM_ATTRIBUTE1_CODE", pColumnLabelAttiribute1, typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "ITEM_ATTRIBUTE1_ID", "Özellik-1 Id", typeof(int), tsGridPackage, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute2 ? Convert.ToInt32(gridPackage.Width * 0.35) : -1;
                AddColumnToGrid(DtPackage, "ITEM_ATTRIBUTE2_CODE", pColumnLabelAttiribute2, typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "ITEM_ATTRIBUTE2_ID", "Özellik-2 Id", typeof(int), tsGridPackage, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute3 ? Convert.ToInt32(gridPackage.Width * 0.35) : -1;
                AddColumnToGrid(DtPackage, "ITEM_ATTRIBUTE3_CODE", pColumnLabelAttiribute3, typeof(string), tsGridPackage, pColumnWidth);
                AddColumnToGrid(DtPackage, "ITEM_ATTRIBUTE3_ID", "Özellik-3 Id", typeof(int), tsGridPackage, -1);


                pColumnWidth = ClientApplication.Instance._IsFreeUnit1 ? Convert.ToInt32(gridOrder.Width * 0.30) : -1;
                pColumnWidth2 = ClientApplication.Instance._IsFreeUnit1 ? Convert.ToInt32(gridOrder.Width * 0.15) : -1;
                AddColumnToGrid(DtPackage, "QTY_FREE_PRM", "Bağımsız Miktar", typeof(decimal), tsGridPackage, pColumnWidth);
                AddColumnToGrid(DtPackage, "FREE_PRM_CODE", "Bağımsız Birimi", typeof(string), tsGridPackage, pColumnWidth2);
                AddColumnToGrid(DtPackage, "FREE_PRMM_ID", "", typeof(int), tsGridPackage, -1);

                AddColumnToGrid(DtPackage, "UNIT_ID", "", typeof(int), tsGridPackage, -1);
                AddColumnToGrid(DtPackage, "TOLERANCE_MAX_SO", "", typeof(decimal), tsGridPackage, -1);
                AddColumnToGrid(DtPackage, "TOLERANCE_MIN_SO", "", typeof(decimal), tsGridPackage, -1);

                AddColumnToGrid(DtPackage, "REFERRAL_DTL_ID", "", typeof(int), tsGridPackage, -1);
                AddColumnToGrid(DtPackage, "SOURCE_D_ID", "", typeof(int), tsGridPackage, -1);
                AddColumnToGrid(DtPackage, "SOURCE_M_ID", "", typeof(int), tsGridPackage, -1);

                AddColumnToGrid(DtPackage, "ENTITY_NAME", "Cari Adı", typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "ENTITY_ID", "", typeof(int), tsGridPackage, -1);

                AddColumnToGrid(DtPackage, "SOURCE_APP2", "Kaynak-2 Okunan Kaynak", typeof(int), tsGridPackage, gridPackage.Width * 0.15);
                AddColumnToGrid(DtPackage, "BARCODE", "Barkod", typeof(string), tsGridPackage, gridPackage.Width * 0.35);
                AddColumnToGrid(DtPackage, "SERIAL_NO", "Seri No", typeof(string), tsGridPackage, gridPackage.Width * 0.35);

                AddColumnToGrid(DtPackage, "READ_LOCATION_ID", "", typeof(int), tsGridPackage, -1);
                DtPackageShow.Columns.Clear();

                foreach (DataColumn item in DtPackage.Columns)
                {
                    DtPackageShow.Columns.Add(item.ColumnName, item.DataType);
                }

                #endregion
                TabPackageItem.Hide();


                if (_KarmaPaketIzinVar)
                {
                    TabPackageItem.Show();
                    #region PackageItem

                    AddColumnToGrid(DtPackageItems, "ITEM_CODE", "Stok Kodu", typeof(string), tsGridPackageItem, gridPackageItem.Width * 0.35);
                    AddColumnToGrid(DtPackageItems, "ITEM_NAME", "Stok Adı", typeof(string), tsGridPackageItem, gridPackageItem.Width * 0.35);
                    AddColumnToGrid(DtPackageItems, "ITEM_ID", "", typeof(int), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "PACKAGE_NO", "Ambalaj No", typeof(string), tsGridPackageItem, gridPackageItem.Width * 0.25);
                    AddColumnToGrid(DtPackageItems, "PACKAGE_M_ID", "", typeof(int), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "QTY", "Miktar", typeof(decimal), tsGridPackageItem, gridPackageItem.Width * 0.15);
                    AddColumnToGrid(DtPackageItems, "UNIT_CODE", "Birim Kodu", typeof(string), tsGridPackageItem, gridPackageItem.Width * 0.35);
                    AddColumnToGrid(DtPackageItems, "QTY_FREE_PRM", "Serbest Miktar", typeof(decimal), tsGridPackageItem, gridPackageItem.Width * 0.15);
                    AddColumnToGrid(DtPackageItems, "FREE_PRM_CODE", "Serbest Birim Kodu", typeof(string), tsGridPackageItem, gridPackageItem.Width * 0.35);

                    pColumnWidth = ClientApplication.Instance._IsQuality ? Convert.ToInt32(gridPackageItem.Width * 0.35) : -1;
                    AddColumnToGrid(DtPackageItems, "QUALITY_CODE", pColumnLabelQuality, typeof(string), tsGridPackageItem, pColumnWidth);
                    AddColumnToGrid(DtPackageItems, "QUALITY_ID", "Kalite", typeof(int), tsGridPackageItem, -1);

                    pColumnWidth = ClientApplication.Instance._IsColor ? Convert.ToInt32(gridPackageItem.Width * 0.35) : -1;
                    AddColumnToGrid(DtPackageItems, "COLOR_CODE", pColumnLabelColor, typeof(string), tsGridPackageItem, pColumnWidth);
                    AddColumnToGrid(DtPackageItems, "COLOR_ID", "Renk", typeof(int), tsGridPackageItem, -1);

                    pColumnWidth = ClientApplication.Instance._IsLot ? Convert.ToInt32(gridPackageItem.Width * 0.35) : -1;
                    AddColumnToGrid(DtPackageItems, "LOT_CODE", pColumnLabelLot, typeof(string), tsGridPackageItem, pColumnWidth);
                    AddColumnToGrid(DtPackageItems, "LOT_ID", "Parti", typeof(int), tsGridPackageItem, -1);

                    pColumnWidth = ClientApplication.Instance._IsAttribute1 ? Convert.ToInt32(gridPackageItem.Width * 0.35) : -1;
                    AddColumnToGrid(DtPackageItems, "ITEM_ATTRIBUTE1_CODE", pColumnLabelAttiribute1, typeof(string), tsGridPackageItem, pColumnWidth);
                    AddColumnToGrid(DtPackageItems, "ITEM_ATTRIBUTE1_ID", "Özellik-1 Id", typeof(int), tsGridPackageItem, -1);

                    pColumnWidth = ClientApplication.Instance._IsAttribute2 ? Convert.ToInt32(gridPackageItem.Width * 0.35) : -1;
                    AddColumnToGrid(DtPackageItems, "ITEM_ATTRIBUTE2_CODE", pColumnLabelAttiribute2, typeof(string), tsGridPackageItem, pColumnWidth);
                    AddColumnToGrid(DtPackageItems, "ITEM_ATTRIBUTE2_ID", "Özellik-2 Id", typeof(int), tsGridPackageItem, -1);

                    pColumnWidth = ClientApplication.Instance._IsAttribute3 ? Convert.ToInt32(gridPackageItem.Width * 0.35) : -1;
                    AddColumnToGrid(DtPackageItems, "ITEM_ATTRIBUTE3_CODE", pColumnLabelAttiribute3, typeof(string), tsGridPackageItem, pColumnWidth);
                    AddColumnToGrid(DtPackageItems, "ITEM_ATTRIBUTE3_ID", "Özellik-3 Id", typeof(int), tsGridPackageItem, -1);

                    AddColumnToGrid(DtPackageItems, "UNIT_ID", "", typeof(int), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "FREE_PRMM_ID", "", typeof(int), tsGridPackageItem, -1);

                    AddColumnToGrid(DtPackageItems, "TOLERANCE_MAX_SO", "", typeof(decimal), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "TOLERANCE_MIN_SO", "", typeof(decimal), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "MASTER_PACKAGE_M_ID", "", typeof(int), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "SOURCE_D_ID", "", typeof(int), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "SOURCE_M_ID", "", typeof(int), tsGridPackageItem, -1);
                    AddColumnToGrid(DtPackageItems, "REFERRAL_DTL_ID", "", typeof(int), tsGridPackageItem, -1);


                    DtPackageItemShow.Columns.Clear();

                    foreach (DataColumn item in DtPackageItems.Columns)
                    {
                        DtPackageItemShow.Columns.Add(item.ColumnName, item.DataType);
                    }


                    #endregion

                }
            }
            catch (SystemException exc)
            {
                Screens.Error("Sutun Oluşturma Hatası:" + exc.Message);
            }
        }
        /*
        private void AddDtFindDataColumn()
        {
            AddColumnToGrid(DtfindOrderDRow, "LINE_NO", "S.No", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "ITEM_CODE", "Stok Kodu", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "ITEM_NAME", "Stok Adı", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "ITEM_ID", "", typeof(int), null, -1);

            AddColumnToGrid(DtfindOrderDRow, "QTY", "Miktar", typeof(decimal), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "READ_QTY", "Okunan Miktar", typeof(decimal), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "NOTE1", "Açk-1", typeof(string), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "LINE_TYPE", "Tip", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "CREATE_WAYBILL", "H.Seç", typeof(bool), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "WAREHOUSE_CODE", "Depo Kodu", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "WAREHOUSE_ID", "", typeof(int), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "QUALITY_CODE", pColumnLabelQuality, typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "QUALITY_ID", "", typeof(int), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "COLOR_CODE", pColumnLabelColor, typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "COLOR_ID", "", typeof(int), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "LOT_CODE", pColumnLabelLot, typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "LOT_ID", "", typeof(int), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "ITEM_ATTRIBUTE1_CODE", pColumnLabelAttiribute1, typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "ITEM_ATTRIBUTE1_ID", "Özellik-1 Id", typeof(int), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "ITEM_ATTRIBUTE2_CODE", pColumnLabelAttiribute2, typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "ITEM_ATTRIBUTE2_ID", "Özellik-2 Id", typeof(int), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "ITEM_ATTRIBUTE3_CODE", pColumnLabelAttiribute3, typeof(string), null,0);
            AddColumnToGrid(DtfindOrderDRow, "ITEM_ATTRIBUTE3_ID", "Özellik-3 Id", typeof(int), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "QTY_FREE_PRM", "Bağımsız Miktar", typeof(decimal), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "FREE_PRM_CODE", "Bağımsız Birimi", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "FREE_PRMM_ID", "", typeof(int), null, 0);


            AddColumnToGrid(DtfindOrderDRow, "REFERRAL_DTL_ID", "", typeof(int), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "SOURCE_D_ID", "", typeof(int), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "SOURCE_M_ID", "", typeof(int), null, 0);

            //hrmd_payroll_type_d3
            AddColumnToGrid(DtfindOrderDRow, "REFEREL_ORDER_CODE", "Sevk.Emri", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "INCOTERMS_NAME", "Teslim Şekli", typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "PAYMENT_METHOD_DESC", "Ödeme Şekli", typeof(string), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "ITEM_ADDSTRING01", pItemAddString01, typeof(string), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "IS_SERIALTRACK", "Serili", typeof(bool), null, 0);

            AddColumnToGrid(DtfindOrderDRow, "SALES_TOLERANCE_MAX_SO", "F.S.%", typeof(decimal), null, 0);
            AddColumnToGrid(DtfindOrderDRow, "QTY_MAX_SO", "T.F.Sevk Mik.", typeof(decimal), null, 0);
        }
        */
        private void AddColumnToGrid(DataTable Dttable, string fieldName, string caption, Type xdataType, DataGridTableStyle ts, double width)
        {

            DataColumn DataColumnNew = new DataColumn();
            DataColumnNew.ColumnName = fieldName;
            DataColumnNew.Caption = fieldName;
            DataColumnNew.DataType = xdataType;
            Dttable.Columns.Add(DataColumnNew);

            if (ts != null)
            {

                try
                {
                    ts.GridColumnStyles.Add(new DataGridTextBoxColumn
                    {
                        MappingName = fieldName,
                        HeaderText = caption,
                        Width = (int)width
                    });
                }
                catch (Exception ex)
                {
                    Screens.Error("Hata [AddColumnToGrid]: " + ex.Message);
                }
            }
        }

        private void CreatePackageRow(OutPacKageD inOutPacKageD,
                                      bool AddFromTempFile,
                                      string xBarkod,
                                      string xSerialNo,
                                      decimal xMultiplierBarcodeQty)
        {

            //DataRow findOrderDRow = null;
            //            DtfindOrderDRow.Rows.Clear();
            List<ItemReadInfo> findOrderDRowList = new List<ItemReadInfo>();
            decimal pNeedQty = inOutPacKageD.Qty; //Ambalaj Miktarı
            if (inOutPacKageD.SourceApp2 == (int)SourceApplication.Stok)
                pNeedQty = xMultiplierBarcodeQty * pNeedQty;

            int filterSourceDId = -1;
            if (_SadeceSipariseAitPaketler)
            {
                filterSourceDId = inOutPacKageD.SourceDId;
            }
            decimal pBalanceQty = 0m;
            decimal masterLineNo = 0;
            decimal masterQty = 0;
            decimal masterReadQty = 0;
            decimal masterFreeQty = 0;
            decimal maxCouldReadValue = 0m;
            decimal pTotalmaxCouldReadValue = 0m;

            decimal ToleranceRatio = 0; //inOutPacKageD.SalesToleranceMax;
            foreach (DataRow drOrder in DtOrder.Rows)
            {
                #region Değerler
                int rowItemId = Convert.ToInt32(drOrder["ITEM_ID"]);
                int rowSourceId = Convert.ToInt32(drOrder["SOURCE_D_ID"]);

                int rowLotId = Convert.ToInt32(drOrder["LOT_ID"]);
                int rowQualityId = Convert.ToInt32(drOrder["QUALITY_ID"]);
                int rowColorId = Convert.ToInt32(drOrder["COLOR_ID"]);
                int rowItemAttribute1Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE1_ID"]);
                int rowItemAttribute2Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE2_ID"]);
                int rowItemAttribute3Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE3_ID"]);

                bool isRowHasFilterBySourceDId = filterSourceDId <= 0 || rowSourceId == filterSourceDId;

                masterLineNo = Convert.ToInt32(drOrder["LINE_NO"]);
                masterQty = Convert.ToDecimal(drOrder["QTY"]);
                masterReadQty = Convert.ToDecimal(drOrder["READ_QTY"]);
                masterFreeQty = Convert.ToDecimal(drOrder["QTY_FREE_PRM"]);
                maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

                decimal pLastQty = masterReadQty;
                if (inOutPacKageD.SourceApp2 == (int)SourceApplication.Stok)
                    pLastQty = xMultiplierBarcodeQty * inOutPacKageD.Qty;
                else
                    pLastQty = inOutPacKageD.Qty;

                pBalanceQty = (maxCouldReadValue - masterReadQty);
                #endregion Değerler
                if (rowItemId == inOutPacKageD.ItemId
                    && (rowLotId == 0 || rowLotId == inOutPacKageD.LotId)
                    && rowQualityId == inOutPacKageD.QualityId
                    && rowColorId == inOutPacKageD.ColorId
                    && rowItemAttribute1Id == inOutPacKageD.ItemAttribute1Id
                    && rowItemAttribute2Id == inOutPacKageD.ItemAttribute2Id
                    && rowItemAttribute3Id == inOutPacKageD.ItemAttribute3Id
                    && isRowHasFilterBySourceDId
                    && pBalanceQty > 0)
                //1 - 1 <= 20 
                //1 - 1 <= 19
                //34 - 18 <= 18
                //1 - 1 <= 20
                //1 - 1 <= 20
                //34 - 20 >=0
                {
                    decimal pAddReadQty = 0m;
                    if (pBalanceQty < pNeedQty)
                        pAddReadQty = pBalanceQty;
                    else
                        pAddReadQty = pNeedQty;

                    pTotalmaxCouldReadValue += pAddReadQty;
                    pNeedQty -= pAddReadQty;

                    ItemReadInfo pItemReadInfo = new ItemReadInfo()
                    {
                        ReferralDetailId = Convert.ToInt32(drOrder["REFERRAL_DTL_ID"]),
                        SourceDId = Convert.ToInt32(drOrder["SOURCE_D_ID"]),
                        ReadQty = pAddReadQty
                    };
                    findOrderDRowList.Add(pItemReadInfo);
                }
                if (pNeedQty <= 0)
                    break;
            }
            if (findOrderDRowList.Count == 0)
            {
                ToleranceRatio = inOutPacKageD.SalesToleranceMax;
                foreach (DataRow drOrder in DtOrder.Rows)
                {
                    #region Değerler
                    int rowItemId = Convert.ToInt32(drOrder["ITEM_ID"]);
                    int rowSourceId = Convert.ToInt32(drOrder["SOURCE_D_ID"]);

                    int rowLotId = Convert.ToInt32(drOrder["LOT_ID"]);
                    int rowQualityId = Convert.ToInt32(drOrder["QUALITY_ID"]);
                    int rowColorId = Convert.ToInt32(drOrder["COLOR_ID"]);
                    int rowItemAttribute1Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE1_ID"]);
                    int rowItemAttribute2Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE2_ID"]);
                    int rowItemAttribute3Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE3_ID"]);

                    bool isRowHasFilterBySourceDId = filterSourceDId <= 0 || rowSourceId == filterSourceDId;

                    masterLineNo = Convert.ToInt32(drOrder["LINE_NO"]);
                    masterQty = Convert.ToDecimal(drOrder["QTY"]);
                    masterReadQty = Convert.ToDecimal(drOrder["READ_QTY"]);
                    masterFreeQty = Convert.ToDecimal(drOrder["QTY_FREE_PRM"]);
                    maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

                    decimal pLastQty = masterReadQty;
                    if (inOutPacKageD.SourceApp2 == (int)SourceApplication.Stok)
                        pLastQty += xMultiplierBarcodeQty * inOutPacKageD.Qty;
                    else
                        pLastQty += inOutPacKageD.Qty;
                    #endregion Değerler
                    pBalanceQty = (maxCouldReadValue - masterReadQty);
                    if (rowItemId == inOutPacKageD.ItemId
                        && (rowLotId == 0 || rowLotId == inOutPacKageD.LotId)
                        && rowQualityId == inOutPacKageD.QualityId
                        && rowColorId == inOutPacKageD.ColorId
                        && rowItemAttribute1Id == inOutPacKageD.ItemAttribute1Id
                        && rowItemAttribute2Id == inOutPacKageD.ItemAttribute2Id
                        && rowItemAttribute3Id == inOutPacKageD.ItemAttribute3Id
                        && isRowHasFilterBySourceDId
                        && pBalanceQty > 0)
                    {
                        decimal pAddReadQty = 0m;
                        if (pBalanceQty < pNeedQty)
                            pAddReadQty = pBalanceQty;
                        else
                            pAddReadQty = pNeedQty;

                        pTotalmaxCouldReadValue += pAddReadQty;
                        pNeedQty -= pAddReadQty;

                        ItemReadInfo pItemReadInfo = new ItemReadInfo()
                        {
                            ReferralDetailId = Convert.ToInt32(drOrder["REFERRAL_DTL_ID"]),
                            SourceDId = Convert.ToInt32(drOrder["SOURCE_D_ID"]),
                            ReadQty = pAddReadQty
                        };
                        findOrderDRowList.Add(pItemReadInfo);
                    }
                    if (pNeedQty <= 0)
                        break;
                }
            }
            if (pNeedQty > 0)
            {
                Screens.Error(string.Format("{0}\nStok : {0}\nOkunanMiktar:{1}\nEksikMiktar:{2}\n ", "Miktarınız Sipariş Miktarınız ile uyuşmamaktadır[NeedQty].-CreatePackageRow"
                                                             , inOutPacKageD.ItemCode
                                                             , inOutPacKageD.Qty
                                                             , pNeedQty));
                _Okutma_HataVar = true;
                return;
            }
            if (findOrderDRowList.Count == 0)
            {
                Screens.Error("Okunan Ambalaja Uygun Sevk Satırı Bulunamadı-CreatePackageRow");
                _Okutma_HataVar = true;
                return;
            }
            #region Kontroller
            foreach (DataRow drPack in ReadPackages)
            {
                if (Convert.ToInt32(drPack["SOURCE_APP2"]) == (int)SourceApplication.Stok)
                    continue;

                if (Convert.ToInt32(drPack["SOURCE_APP2"]) == (int)SourceApplication.BağımsızSeri)
                {
                    if (ClientApplication.Instance.HandsetParam["Frm_PaletSevk", "GIRISI_OLMAYAN_SERI_CIKISI"].ToBool())
                    {
                        if (drPack["SERIAL_NO"].ToString() == inOutPacKageD.SerialNo)
                        {
                            Screens.Error(string.Format("Bu Seri Daha Önce Okunmuştur \n Seri :{0}", inOutPacKageD.SerialNo));
                            _Okutma_HataVar = true;
                            return;
                        }
                        else if (drPack["SERIAL_NO"].ToString() == xSerialNo)
                        {
                            Screens.Error(string.Format("Bu Seri Daha Önce Okunmuştur \n Seri :{0}", xSerialNo));
                            _Okutma_HataVar = true;
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                var readPackageMid = Convert.ToInt32(drPack["PACKAGE_M_ID"]);
                if (readPackageMid == inOutPacKageD.PackageMId)
                {
                    Screens.Error("Bu Ambalaj Daha Önce Okunmuştur[1]");
                    _Okutma_HataVar = true;
                    return;
                }
            }

            if (_SadeceSipariseAitPaketler)
            {

                foreach (ItemReadInfo findOrderRow in findOrderDRowList)
                {
                    if (findOrderRow.SourceDId != inOutPacKageD.SourceDId)
                    {
                        Screens.Error("Bu Ambalaj, Bu Sevk Emrine Ait değildir.");
                        _Okutma_HataVar = true;
                        return;
                    }
                }
            }
            #endregion Kontroller
            /*
            if (pTotalmaxCouldReadValue < (masterReadQty + inOutPacKageD.Qty))
            {
                MessageBox.Show(string.Format("Miktarı aşıyorsunuz[3] İzin Verilen:{0} Girilen:{1} ", pTotalmaxCouldReadValue, masterReadQty + inOutPacKageD.Qty));
                return;
            }*/
            foreach (ItemReadInfo findOrderRowItem in findOrderDRowList)
            {
                #region Ekle Satır
                var findOrderRow = DtOrder.Rows.Cast<DataRow>().Where(t => int.Parse(t["REFERRAL_DTL_ID"].ToString()) == findOrderRowItem.ReferralDetailId).FirstOrDefault();
                if (findOrderRow == null)
                    continue;

                findOrderRow["READ_QTY"] = Convert.ToDecimal(findOrderRow["READ_QTY"]) + findOrderRowItem.ReadQty;
                findOrderRow["QTY_FREE_PRM"] = masterFreeQty + inOutPacKageD.QtyFreePrm;
                findOrderRow["FREE_PRMM_ID"] = inOutPacKageD.FreePrmMId;
                findOrderRow["FREE_PRM_CODE"] = inOutPacKageD.FreePrmMCode;

                var drPackage = DtPackage.NewRow();

                drPackage["LINE_NO"] = masterLineNo;
                drPackage["ITEM_CODE"] = inOutPacKageD.ItemCode;
                drPackage["ITEM_NAME"] = inOutPacKageD.ItemName;
                drPackage["ITEM_ID"] = inOutPacKageD.ItemId;
                drPackage["UNIT_ID"] = inOutPacKageD.UnitId;
                drPackage["PACKAGE_NO"] = inOutPacKageD.PackageNo;
                drPackage["PACKAGE_M_ID"] = inOutPacKageD.PackageMId;
                //drPackage["QTY"] = (inOutPacKageD.Qty * xMultiplierBarcodeQty);
                drPackage["QTY"] = findOrderRowItem.ReadQty;


                drPackage["QUALITY_CODE"] = inOutPacKageD.QualityCode;
                drPackage["QUALITY_ID"] = inOutPacKageD.QualityId;
                drPackage["LOT_CODE"] = inOutPacKageD.LotCode;
                drPackage["LOT_ID"] = inOutPacKageD.LotId;
                drPackage["COLOR_CODE"] = inOutPacKageD.ColorCode;
                drPackage["COLOR_ID"] = inOutPacKageD.ColorId;

                drPackage["ITEM_ATTRIBUTE1_CODE"] = inOutPacKageD.ItemAttribute1Code;
                drPackage["ITEM_ATTRIBUTE1_ID"] = inOutPacKageD.ItemAttribute1Id;
                drPackage["ITEM_ATTRIBUTE2_CODE"] = inOutPacKageD.ItemAttribute2Code;
                drPackage["ITEM_ATTRIBUTE2_ID"] = inOutPacKageD.ItemAttribute2Id;
                drPackage["ITEM_ATTRIBUTE3_CODE"] = inOutPacKageD.ItemAttribute3Code;
                drPackage["ITEM_ATTRIBUTE3_ID"] = inOutPacKageD.ItemAttribute3Id;

                drPackage["QTY_FREE_PRM"] = inOutPacKageD.QtyFreePrm;
                drPackage["FREE_PRM_CODE"] = inOutPacKageD.FreePrmMCode;
                drPackage["FREE_PRMM_ID"] = inOutPacKageD.FreePrmMId;
                drPackage["TOLERANCE_MAX_SO"] = inOutPacKageD.SalesToleranceMax;
                drPackage["TOLERANCE_MIN_SO"] = inOutPacKageD.SalesToleranceMin;
                drPackage["REFERRAL_DTL_ID"] = findOrderRow["REFERRAL_DTL_ID"];
                drPackage["SOURCE_D_ID"] = inOutPacKageD.SourceDId;
                drPackage["SOURCE_M_ID"] = findOrderRow["SOURCE_M_ID"];

                drPackage["ENTITY_ID"] = inOutPacKageD.EntityId;
                drPackage["ENTITY_NAME"] = inOutPacKageD.EntityName;

                drPackage["SOURCE_APP2"] = inOutPacKageD.SourceApp2;
                drPackage["BARCODE"] = inOutPacKageD.Barcode;
                drPackage["SERIAL_NO"] = inOutPacKageD.SerialNo;

                if (AddFromTempFile)
                    drPackage["READ_LOCATION_ID"] = inOutPacKageD.ReadLocationId;
                else
                    drPackage["READ_LOCATION_ID"] = pReadLocationId;

                if (string.IsNullOrEmpty(inOutPacKageD.SerialNo) && !string.IsNullOrEmpty(xSerialNo))
                {
                    drPackage["BARCODE"] = xBarkod;
                    drPackage["SERIAL_NO"] = xSerialNo;
                }


                this.ReadPackages.Add(drPackage);

                if (!AddFromTempFile)
                {

                    inOutPacKageD.SourceMId = Int32.Parse(findOrderRow["SOURCE_M_ID"].ToString());
                    AddSerialInfoToWebTempTable(inOutPacKageD.PackageMId,
                                                Convert.ToInt32(drPackage["REFERRAL_DTL_ID"]),
                                                inOutPacKageD.SourceMId,
                                                inOutPacKageD.SourceApp2,
                                                xBarkod,
                                                xSerialNo,
                                                xMultiplierBarcodeQty);
                    this.reFreshSerialGrid();
                }
                #endregion Ekle Satır
            }
        }

        private void AddSerialInfoToWebTempTable(int xPackageMid, int _SourceDId, int OrderMId, int xSourceApp2, string xBarkod, string xSerialNo, decimal xMultiplierBarcodeQty)
        {
            var AddedResult = ClientApplication.Instance.UTermService.PackageTempAddItem(
                     new ServiceRequestOfPackageTempAddItemIn
                     {
                         Token = ClientApplication.Instance.UTermToken,
                         Value = new PackageTempAddItemIn
                         {
                             SourceApp = pSourceApp,
                             SourceApp2 = xSourceApp2,
                             SourceMId = OrderMId,
                             SourceDId = _SourceDId,
                             SourceM1Id = xPackageMid,
                             Barcode = xBarkod,
                             SerialNo = xSerialNo,
                             MultiplierBarcodeQty = xMultiplierBarcodeQty,
                             ReadLocationId = pReadLocationId

                         }
                     }
                 );

            if (!AddedResult.Result)
            {
                Screens.Error("Seri Temp Tabloya Yazılamadı:" + AddedResult.Message);
            }
        }


        void CreateBomItemRow(OutPacKageDBomItem bomItem, int ParamPackageMId)
        {
            DataRow findOrderRow = null;
            foreach (DataRow drOrder in DtOrder.Rows)
            {
                int rowItemId = Convert.ToInt32(drOrder["ITEM_ID"]);
                int rowLotId = Convert.ToInt32(drOrder["LOT_ID"]);
                int rowQualityId = Convert.ToInt32(drOrder["QUALITY_ID"]);
                int rowColorId = Convert.ToInt32(drOrder["COLOR_ID"]);
                int rowItemAttribute1Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE1_ID"]);
                int rowItemAttribute2Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE2_ID"]);
                int rowItemAttribute3Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE3_ID"]);
                if (rowItemId == bomItem.ItemId
                    && rowLotId == bomItem.LotId
                    && rowQualityId == bomItem.QualityId
                    && rowColorId == bomItem.ColorId
                    && rowItemAttribute1Id == bomItem.ItemAttribute1Id
                    && rowItemAttribute2Id == bomItem.ItemAttribute2Id
                    && rowItemAttribute3Id == bomItem.ItemAttribute3Id)
                {
                    findOrderRow = drOrder;
                    break;
                }
            }


            if (findOrderRow == null)
            {
                Screens.Error("Okunan Ambalaja Uygun Sevk Satırı Bulunamadı-CreateBomItemRow");
                return;
            }


            decimal masterLineNo = Convert.ToInt32(findOrderRow["LINE_NO"]);
            decimal masterQty = Convert.ToDecimal(findOrderRow["QTY"]);
            decimal masterReadQty = Convert.ToDecimal(findOrderRow["READ_QTY"]);
            decimal masterFreeQty = Convert.ToDecimal(findOrderRow["QTY_FREE_PRM"]);


            decimal ToleranceRatio = bomItem.SalesToleranceMax;

            var maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;


            if (maxCouldReadValue < (masterReadQty + bomItem.Qty))
            {
                Screens.Error(string.Format("Miktarı aşıyorsunuz[4] İzin Verilen:{0} Girilen:{1} ", maxCouldReadValue, masterReadQty + bomItem.Qty));
                return;
            }


            #region Add DataSet
            findOrderRow["READ_QTY"] = masterReadQty + bomItem.Qty;
            findOrderRow["QTY_FREE_PRM"] = masterFreeQty + bomItem.QtyFreePrm;
            findOrderRow["FREE_PRMM_ID"] = bomItem.FreePrmMId;
            findOrderRow["FREE_PRM_CODE"] = bomItem.FreePrmMCode;

            var drItem = this.DtPackageItems.NewRow();
            drItem["ITEM_CODE"] = bomItem.ItemCode;
            drItem["ITEM_NAME"] = bomItem.ItemName;
            drItem["ITEM_ID"] = bomItem.ItemId;
            drItem["PACKAGE_NO"] = bomItem.PackageMNo;
            drItem["PACKAGE_M_ID"] = ParamPackageMId;
            drItem["QTY"] = bomItem.Qty;

            drItem["QUALITY_CODE"] = bomItem.QualityCode;
            drItem["QUALITY_ID"] = bomItem.QualityId;

            drItem["LOT_CODE"] = bomItem.LotCode;
            drItem["LOT_ID"] = bomItem.LotId;

            drItem["COLOR_CODE"] = bomItem.ColorCode;
            drItem["COLOR_ID"] = bomItem.ColorId;

            drItem["ITEM_ATTRIBUTE1_CODE"] = bomItem.ItemAttribute1Code;
            drItem["ITEM_ATTRIBUTE1_ID"] = bomItem.ItemAttribute1Id;
            drItem["ITEM_ATTRIBUTE2_CODE"] = bomItem.ItemAttribute2Id;
            drItem["ITEM_ATTRIBUTE2_ID"] = bomItem.ItemAttribute2Id;
            drItem["ITEM_ATTRIBUTE3_CODE"] = bomItem.ItemAttribute3Id;
            drItem["ITEM_ATTRIBUTE3_ID"] = bomItem.ItemAttribute2Id;

            drItem["UNIT_CODE"] = bomItem.UnitCode;
            drItem["UNIT_ID"] = bomItem.UnitId;

            drItem["QTY_FREE_PRM"] = bomItem.Qty;
            drItem["FREE_PRM_CODE"] = bomItem.UnitCode;
            drItem["FREE_PRMM_ID"] = bomItem.UnitId;
            drItem["REFERRAL_DTL_ID"] = findOrderRow["REFERRAL_DTL_ID"];

            drItem["TOLERANCE_MAX_SO"] = bomItem.SalesToleranceMax;
            drItem["TOLERANCE_MIN_SO"] = bomItem.SalesToleranceMin;

            this.DtPackageItems.Rows.Add(drItem);
            #endregion

        }

        void ProcessData(string _xCode)
        {
            try
            {
                Screens.ShowWait();
                ProccesDataBarcode(_xCode);
                Screens.HideWait();
            }
            catch (Exception ex)
            {
                Screens.Error(ex.Message);
            }
        }

        void ProccesDataBarcode(string _xCode)
        {
            _Okutma_HataVar = false;
            ServiceResultOfOutPacKageD _PacKageD;
            try
            {
                ServiceRequestOfInPacKageM _InPacKageM = new ServiceRequestOfInPacKageM();
                _InPacKageM.Token = new Token();
                _InPacKageM.Token = ClientApplication.Instance.UTermToken;
                _InPacKageM.Value = new InPacKageM();


                //if(

                _InPacKageM.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;// firstRead_WareHouseId;
                _InPacKageM.Value.PackageNo = _xCode;
                _InPacKageM.Value.BomPacKageTraMGetItems = _KarmaPaketIzinVar;
                //public bool BomPacKageTraMGetItems { get; set; }


                _InPacKageM.Value.IsMultiInputOutputCriteria = true;
                //_InPacKageM.Value.MultiInputOutputCriteriaValues = new int[] { 1 /*Giriş*/ , 2 /*Çıkış*/};
                _InPacKageM.Value.MultiInputOutputCriteriaValues = new int[] { 1 /*Giriş*/}; //Sadece Girişler okutulmalı.

                _PacKageD = ClientApplication.Instance.UTermService.GetPackageMInfo(_InPacKageM);

                if (_PacKageD.Result == false || _PacKageD.Value == null)
                {
                    Screens.Error(_PacKageD.Message.ToString());
                    return;
                }
                if (_MusteriKontrol && _PacKageD.Value.EntityId > 0)
                {
                    foreach (DataRow drPack in ReadPackages)
                    {
                        int iEntityId = Convert.ToInt32(drPack["ENTITY_ID"]);
                        if (iEntityId > 0 && iEntityId != _PacKageD.Value.EntityId)
                        {
                            Screens.Error("Bu listeye an ancak " + drPack["ENTITY_NAME"] + " firmasının malları alınabilir");
                            return;
                        }
                    }
                }

                /*
                if (!_PacKageD.Value.HasDetail)
                {
                    MessageBox.Show("Detay İşaretli Olmak Zorundadır.");
                    return;
                }*/

                if (!ClientApplication.Instance.HandsetParam["Frm_PaletSevk", "AMBALAJ_BARKOD_SERI_OKU"].ToBool())
                {
                    if (pReadLocationUsed && RafKontrol() == false)
                        return;

                    #region Ambalaj - eski mantık
                    if (_PacKageD.Value.Revort)
                    {
                        Screens.Error("Çözüldü İşaretli Kayıt Seçilemez");
                        return;
                    }

                    if (Chk_Delete.CheckState == CheckState.Unchecked) //ITEM_M_TMP ve ITEM_D_TMP Ekleme
                    {
                        #region master kayıt ekleme ve detay ekleme

                        int icounter = Convert.ToInt32(DateTime.Now.ToString("hmsfff"));
                        AddPackageRow(_PacKageD.Value, false, string.Empty, string.Empty, 1);

                        #endregion
                    }
                    else //ITEM_D_TMP QtyPRM update > Satırda Okutulan Barkodu silmek içindir.
                    {
                        #region Detaydan okutulan barkodu silme
                        RemovePackegeD(_PacKageD, string.Empty, string.Empty, 1);
                        #endregion Detaydan okutulan barkodu silme
                    }
                    #endregion Ambalaj - eski mantık
                }
                else
                {
                    if (pReadLocationUsed && RafKontrol() == false)
                        return;

                    if (_PacKageD.Value.SourceApp2 == (int)SourceApplication.Ambalaj)
                    {
                        #region Ambalaj
                        if (_PacKageD.Value.Revort)
                        {
                            Screens.Error("Çözüldü İşaretli Kayıt Seçilemez");
                            return;
                        }

                        if (Chk_Delete.CheckState == CheckState.Unchecked) //ITEM_M_TMP ve ITEM_D_TMP Ekleme
                        {
                            #region master kayıt ekleme ve detay ekleme

                            int icounter = Convert.ToInt32(DateTime.Now.ToString("hmsfff"));
                            AddPackageRow(_PacKageD.Value, false, string.Empty, string.Empty, 1);
                            #endregion
                        }
                        else //ITEM_D_TMP QtyPRM update > Satırda Okutulan Barkodu silmek içindir.
                        {
                            #region Detaydan okutulan barkodu silme
                            RemovePackegeD(_PacKageD, string.Empty, string.Empty, 1);
                            #endregion Detaydan okutulan barkodu silme
                        }
                        #endregion Ambalaj
                        Tx_Miktar.Text = "1";
                        Tx_Barcode.Text = "";
                        Tx_Barcode.Focus();
                    }
                    else if (_PacKageD.Value.SourceApp2 == (int)SourceApplication.BağımsızSeri)
                    {
                        if (string.IsNullOrEmpty(tx_SerialNo.Text))
                        {
                            tx_SerialNo.BackColor = Color.GreenYellow;
                            tx_SerialNo.Enabled = true;
                            tx_SerialNo.Focus();
                            return;
                        }
                        #region BağımsızSeri
                        if (Chk_Delete.CheckState == CheckState.Unchecked) //ITEM_M_TMP ve ITEM_D_TMP Ekleme
                        {
                            #region master kayıt ekleme ve detay ekleme

                            int icounter = Convert.ToInt32(DateTime.Now.ToString("hmsfff"));
                            if (pReadLocationUsed) _PacKageD.Value.ReadLocationId = pReadLocationId;
                            AddPackageRow(_PacKageD.Value, false, Tx_Barcode.Text, tx_SerialNo.Text, 1);
                            #endregion
                        }
                        else //ITEM_D_TMP QtyPRM update > Satırda Okutulan Barkodu silmek içindir.
                        {
                            #region Detaydan okutulan barkodu silme
                            RemovePackegeD(_PacKageD, string.Empty, tx_SerialNo.Text, 1);
                            #endregion Detaydan okutulan barkodu silme
                        }
                        #endregion BağımsızSeri
                        tx_SerialNo.Text = string.Empty;
                        tx_SerialNo.Focus();
                        /*tx_SerialNo.Text = string.Empty;
                        tx_SerialNo.BackColor = Color.White;
                        tx_SerialNo.Enabled = false;*/
                    }
                    else if (_PacKageD.Value.SourceApp2 == (int)SourceApplication.Stok)
                    {
                        #region Stok
                        decimal pTx_Miktar = CommonOps.ConvertStrToDec(Tx_Miktar.Text.ToString());
                        if (pTx_Miktar == 0)
                        {
                            Screens.Error("Barkod Okutma'da Miktar Girişi Zorunludur İşaretli Olmak Zorundadır.");
                            return;
                        }

                        if (Chk_Delete.CheckState == CheckState.Unchecked) //ITEM_M_TMP ve ITEM_D_TMP Ekleme
                        {
                            #region master kayıt ekleme ve detay ekleme

                            int icounter = Convert.ToInt32(DateTime.Now.ToString("hmsfff"));
                            if (pReadLocationUsed) _PacKageD.Value.ReadLocationId = pReadLocationId;
                            AddPackageRow(_PacKageD.Value, false, string.Empty, string.Empty, pTx_Miktar);

                            #endregion
                        }
                        else //ITEM_D_TMP QtyPRM update > Satırda Okutulan Barkodu silmek içindir.
                        {
                            #region Detaydan okutulan barkodu silme
                            RemovePackegeD(_PacKageD, string.Empty, string.Empty, pTx_Miktar);
                            #endregion Detaydan okutulan barkodu silme
                        }
                        #endregion BağımsızSeri
                        Tx_Miktar.Text = "1";
                        Tx_Barcode.Text = "";
                        Tx_Barcode.Focus();
                    }

                }
                gridOrder.DataSource = DtOrder;
                gridOrder.Refresh();

            }
            catch (SystemException _ExMsg)
            {

                Screens.Error("System Hatası:" + _ExMsg.Message.ToString());
                return;
            }
            catch (Exception _Ex)
            {

                Screens.Error("Hata : " + _Ex.Message.ToString());
                return;
            }
            finally
            {
                Tx_Miktar.Text = "1";
                Tx_Barcode.Text = "";
                Tx_Barcode.Focus();
            }

            gridOrder.Refresh();
            bool pStokOkutmaBitti = false;
            if (pReadLocationUsed && _PacKageD != null)
                pStokOkutmaBitti = StokOkutmaBitti(_PacKageD);
            if (pStokOkutmaBitti && Chk_Delete.CheckState == CheckState.Unchecked && pReadLocationUsed && !_Okutma_HataVar)
            {
                tx_SerialNo.Text = string.Empty;
                tx_SerialNo.BackColor = Color.White;
                tx_SerialNo.Enabled = false;

                Screens.Info("Stok Okutma İşlemi Tamamlandı. Lütfen Raf Bilgisini Okutunuz !!!! [Frm_PaletSevk - Raf]");
                Tx_ReadLocationCode.Text = string.Empty;
                Tx_ReadLocationId.Text = string.Empty;
                Tx_ReadLocationCode.Focus();
            }
        }

        private bool StokOkutmaBitti(ServiceResultOfOutPacKageD _PacKageD)
        {
            bool pStokOkutmaBitti = false;
            if (_PacKageD.Value.ItemId > 0)
            {
                var pEksikOkumaVarmi = DtOrder.Rows.Cast<DataRow>().Where(t => (int)t["ITEM_ID"] == _PacKageD.Value.ItemId &&
                                                                               (decimal)t["QTY"] - (decimal)t["READ_QTY"] > 0).FirstOrDefault();
                if (pEksikOkumaVarmi == null)
                    pStokOkutmaBitti = true;
            }
            return pStokOkutmaBitti;
        }

        public void changeOrderCountToForDelete(DataRow readQtyValueDataRow, decimal xMultiplierBarcodeQty)
        {
            int ReferralOrdersDId = Convert.ToInt32(readQtyValueDataRow["REFERRAL_DTL_ID"]);

            DataRow findOrderRow = null;
            foreach (DataRow drOrder in DtOrder.Rows)
            {
                if (Convert.ToInt32(drOrder["REFERRAL_DTL_ID"]) == ReferralOrdersDId)
                {
                    findOrderRow = drOrder;
                    break;
                }
            }
            //decimal xQty = Convert.ToDecimal(readQtyValueDataRow["QTY"]) * xMultiplierBarcodeQty; 
            decimal xQty = Convert.ToDecimal(readQtyValueDataRow["QTY"]);
            decimal QtyFreePrm = Convert.ToDecimal(readQtyValueDataRow["QTY_FREE_PRM"]);

            if (findOrderRow != null)
            {
                findOrderRow["READ_QTY"] = Convert.ToDecimal(findOrderRow["READ_QTY"]) - xQty;
                findOrderRow["QTY_FREE_PRM"] = Convert.ToDecimal(findOrderRow["QTY_FREE_PRM"]) - QtyFreePrm;
            }
        }

        private void RemovePackegeD(ServiceResultOfOutPacKageD _PacKageD, string xBarkod, string xSerialNo, decimal xMultiplierBarcodeQty)
        {
            List<DataRow> newReadPackages = new List<DataRow>();
            #region Sil
            foreach (var item in this.ReadPackages.Cast<DataRow>().Where(t => int.Parse(t["PACKAGE_M_ID"].ToString()) == _PacKageD.Value.PackageMId).ToList())
            {
                var dtPc = item;
                if (dtPc == null)
                    continue;
                int pPackageMId = Convert.ToInt32(item["PACKAGE_M_ID"]);

                if (pReadLocationUsed && _PacKageD.Value.PackageMId != pPackageMId)
                    continue;

                int pSourceApp2 = Convert.ToInt32(dtPc["SOURCE_APP2"]);


                if (pSourceApp2 == (int)SourceApplication.Stok &&
                    _PacKageD.Value.SourceApp2 == (int)SourceApplication.Stok)
                {
                    if (xMultiplierBarcodeQty * _PacKageD.Value.Qty != Convert.ToInt32(dtPc["QTY"]))
                        continue;
                }
                if (_PacKageD.Value.SourceApp2 == (int)SourceApplication.BağımsızSeri)
                {
                    if (item["SERIAL_NO"].ToString() != xSerialNo)
                        continue;
                }
                if (Int32.Parse(dtPc["PACKAGE_M_ID"].ToString()) == _PacKageD.Value.PackageMId)
                {
                    var _OrderMId = Int32.Parse(dtPc["SOURCE_M_ID"].ToString());
                    var delResult = ClientApplication.Instance.UTermService.PackageTempDeleteItem(new ServiceRequestOfPackageTempAddItemIn
                    {
                        Token = ClientApplication.Instance.UTermToken,
                        Value = new PackageTempAddItemIn
                        {
                            SourceApp = pSourceApp, //Sevk Emri
                            SourceApp2 = _PacKageD.Value.SourceApp2, //Ambalaj
                            SourceMId = _OrderMId,
                            SourceDId = Convert.ToInt32(dtPc["REFERRAL_DTL_ID"]),
                            SourceM1Id = _PacKageD.Value.PackageMId,
                            SerialNo = xSerialNo,
                            MultiplierBarcodeQty = xMultiplierBarcodeQty
                        }
                    });
                    bool pDeleteRecord = true;
                    if (_PacKageD.Value.SourceApp2 == (int)SourceApplication.Stok)
                    {
                        if (delResult != null)
                        {
                            pDeleteRecord = delResult.Result;
                        }
                    }

                    if (!pDeleteRecord)
                        continue;

                    if (!_KarmaPaketIzinVar)
                    {
                        changeOrderCountToForDelete(dtPc, xMultiplierBarcodeQty);
                    }
                    else
                    {
                        for (int dtPackegeItemIndex = 0; dtPackegeItemIndex < DtPackageItems.Rows.Count; dtPackegeItemIndex++)
                        {
                            DataRow drPackItem = DtPackageItems.Rows[dtPackegeItemIndex];
                            if (Convert.ToInt32(drPackItem["MASTER_PACKAGE_M_ID"]) == _PacKageD.Value.PackageMId)
                            {
                                changeOrderCountToForDelete(drPackItem, 1);
                                DtPackageItems.Rows.Remove(drPackItem);
                                dtPackegeItemIndex--;
                            }
                        }
                    }
                }
            }
            #endregion Sil
            this.ReadPackages = this.ReadPackages.Cast<DataRow>().Where(t => int.Parse(t["PACKAGE_M_ID"].ToString()) != _PacKageD.Value.PackageMId).ToList();
            reFreshSerialGrid();
            reFreshPackageItemGrid();

        }

        private void AddPackageRow(OutPacKageD _PacKageD, bool AddFromTempTable, string xBarkod, string xSerialNo, decimal xMultiplierBarcodeQty)
        {

            if (!_KarmaPaketIzinVar)
            {
                CreatePackageRow(_PacKageD,
                                 AddFromTempTable,
                                 xBarkod,
                                 xSerialNo,
                                 xMultiplierBarcodeQty);
            }



            if (_KarmaPaketIzinVar)
            {

                foreach (DataRow drPack in ReadPackages)
                {
                    if (Convert.ToInt32(drPack["SOURCE_APP2"]) == (int)SourceApplication.Stok)
                        continue;

                    var readPackageMid = Convert.ToInt32(drPack["PACKAGE_M_ID"]);
                    if (readPackageMid == _PacKageD.PackageMId)
                    {
                        Screens.Error("Bu Ambalaj Daha Önce Okunmuştur [2]");
                        return;
                    }
                }
                if (QtyErrorControl_DtOrder(_PacKageD)) //Ambalaj Eklenince Hata oluyor mu ?
                    return;

                DataRow drOrder = DtOrder.Rows[0]; //Hangi sipariş olduğu bilgisi ; Birden fazla satıra denk gelebilir ondan dolayı sadece ilk kayıt önemli.

                var drPackage = DtPackage.NewRow();

                drPackage["LINE_NO"] = (ReadPackages.Count + 1) * 10;
                drPackage["PACKAGE_NO"] = _PacKageD.PackageNo;
                drPackage["PACKAGE_M_ID"] = _PacKageD.PackageMId;
                drPackage["ITEM_CODE"] = "";
                drPackage["ITEM_NAME"] = "";

                drPackage["QTY"] = 0;
                drPackage["FREE_PRM_CODE"] = "";
                drPackage["QTY_FREE_PRM"] = 0;
                drPackage["REFERRAL_DTL_ID"] = 0;
                drPackage["UNIT_ID"] = 0;
                drPackage["QUALITY_ID"] = 0;
                drPackage["LOT_ID"] = 0;
                drPackage["COLOR_ID"] = 0;
                drPackage["ITEM_ATTRIBUTE1_ID"] = 0;
                drPackage["ITEM_ATTRIBUTE2_ID"] = 0;
                drPackage["ITEM_ATTRIBUTE3_ID"] = 0;

                drPackage["QUALITY_CODE"] = "";
                drPackage["LOT_CODE"] = "";
                drPackage["COLOR_CODE"] = "";
                drPackage["ITEM_ATTRIBUTE1_CODE"] = "";
                drPackage["ITEM_ATTRIBUTE2_CODE"] = "";
                drPackage["ITEM_ATTRIBUTE3_CODE"] = "";

                drPackage["ENTITY_ID"] = _PacKageD.EntityId;
                drPackage["ENTITY_NAME"] = _PacKageD.EntityName;

                drPackage["SOURCE_D_ID"] = 0;
                drPackage["SOURCE_M_ID"] = drOrder["SOURCE_M_ID"];

                drPackage["SOURCE_APP2"] = _PacKageD.SourceApp2;
                drPackage["BARCODE"] = string.Empty;
                drPackage["SERIAL_NO"] = string.Empty;
                drPackage["READ_LOCATION_ID"] = 0;
                _PacKageD.SourceMId = Convert.ToInt32(drOrder["SOURCE_M_ID"]); //Başka Çare yok siparişe bağlamalı.


                List<DataRow> bomItemDataRows = new List<DataRow>();
                bool hasError = false;

                foreach (var bomItem in _PacKageD.BomItems)
                {
                    decimal pQty = bomItem.Qty;

                    hasError = hasError || !AddItemRowData(bomItem, pQty, _PacKageD.PackageMId, bomItemDataRows);
                    if (hasError) break;
                }

                if (!hasError)
                {
                    this.ReadPackages.Add(drPackage);

                    foreach (DataRow dr in bomItemDataRows)
                    {
                        //bomItemDataRows.Add(dr);
                        DtPackageItems.Rows.Add(dr);
                    }

                    if (!AddFromTempTable)
                    {
                        AddSerialInfoToWebTempTable(_PacKageD.PackageMId, _PacKageD.SourceDId, _PacKageD.SourceMId, _PacKageD.SourceApp2, xBarkod, xSerialNo, xMultiplierBarcodeQty);
                    }
                }


                if (!AddFromTempTable) this.reFreshSerialGrid();
            }

        }



        private bool AddItemRowData(OutPacKageDBomItem bomItem, decimal pQty, int MasterPackageId, List<DataRow> bomItemDataRows)
        {
            DataRow findOrderRow = null;

            decimal masterLineNo = 0m;
            decimal masterQty = 0m;
            decimal masterReadQty = 0m;
            decimal masterFreeQty = 0m;
            decimal ToleranceRatio = 0m;
            decimal maxCouldReadValue = 0m;

            //Fazla Sevk : Toleranssız Satırlara Bak
            foreach (DataRow drOrder in DtOrder.Rows)
            {
                #region Değerler
                int rowItemId = Convert.ToInt32(drOrder["ITEM_ID"]);
                int rowLotId = Convert.ToInt32(drOrder["LOT_ID"]);
                int rowQualityId = Convert.ToInt32(drOrder["QUALITY_ID"]);
                int rowSourceDId = Convert.ToInt32(drOrder["SOURCE_D_ID"]);

                int rowItemAttribute1Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE1_ID"]);
                int rowItemAttribute2Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE2_ID"]);
                int rowItemAttribute3Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE3_ID"]);

                bool SadeceSipariseAitKontrolEt = !_SadeceSipariseAitPaketler || (_SadeceSipariseAitPaketler && rowSourceDId == bomItem.SourceDId);

                masterQty = Convert.ToDecimal(drOrder["QTY"]);
                masterReadQty = Convert.ToDecimal(drOrder["READ_QTY"]);
                masterFreeQty = Convert.ToDecimal(drOrder["QTY_FREE_PRM"]);

                ToleranceRatio = 0; //bomItem.SalesToleranceMax; 
                maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

                decimal pLastQty = (masterReadQty + pQty);
                #endregion Değerler
                if (rowItemId == bomItem.ItemId
                    && (rowLotId == 0 || rowLotId == bomItem.LotId)
                    && rowQualityId == bomItem.QualityId
                    && rowItemAttribute1Id == bomItem.ItemAttribute1Id
                    && rowItemAttribute2Id == bomItem.ItemAttribute2Id
                    && rowItemAttribute3Id == bomItem.ItemAttribute3Id
                    && SadeceSipariseAitKontrolEt
                    && maxCouldReadValue >= pLastQty)
                {
                    findOrderRow = drOrder;
                    break;
                }
            }
            //Fazla Sevk : Toleranslı Satırlara Bak

            if (findOrderRow == null)
            {
                foreach (DataRow drOrder in DtOrder.Rows)
                {
                    #region Değerler
                    int rowItemId = Convert.ToInt32(drOrder["ITEM_ID"]);
                    int rowLotId = Convert.ToInt32(drOrder["LOT_ID"]);
                    int rowQualityId = Convert.ToInt32(drOrder["QUALITY_ID"]);
                    int rowSourceDId = Convert.ToInt32(drOrder["SOURCE_D_ID"]);

                    int rowItemAttribute1Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE1_ID"]);
                    int rowItemAttribute2Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE2_ID"]);
                    int rowItemAttribute3Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE3_ID"]);

                    bool SadeceSipariseAitKontrolEt = !_SadeceSipariseAitPaketler || (_SadeceSipariseAitPaketler && rowSourceDId == bomItem.SourceDId);

                    masterQty = Convert.ToDecimal(drOrder["QTY"]);
                    masterReadQty = Convert.ToDecimal(drOrder["READ_QTY"]);
                    masterFreeQty = Convert.ToDecimal(drOrder["QTY_FREE_PRM"]);

                    ToleranceRatio = bomItem.SalesToleranceMax;
                    maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

                    decimal pLastQty = (masterReadQty + bomItem.Qty);
                    #endregion Değerler
                    if (rowItemId == bomItem.ItemId
                        && (rowLotId == 0 || rowLotId == bomItem.LotId)
                        && rowQualityId == bomItem.QualityId
                        && rowItemAttribute1Id == bomItem.ItemAttribute1Id
                        && rowItemAttribute2Id == bomItem.ItemAttribute2Id
                        && rowItemAttribute3Id == bomItem.ItemAttribute3Id
                        && SadeceSipariseAitKontrolEt
                        && maxCouldReadValue >= pLastQty)
                    {
                        findOrderRow = drOrder;
                        break;
                    }
                }
            }

            if (findOrderRow == null)
            {
                Screens.Error(string.Format("Okunan Ambalajda  Uygun Sevk Satırı Bulunamadı: Stok Kodu:{0} Parti:{1} Kalite:{2} "
                    , bomItem.ItemCode, bomItem.LotCode, bomItem.QualityCode));
                return false;
            }

            masterLineNo = Convert.ToInt32(findOrderRow["LINE_NO"]);
            masterQty = Convert.ToDecimal(findOrderRow["QTY"]);
            masterReadQty = Convert.ToDecimal(findOrderRow["READ_QTY"]);
            masterFreeQty = Convert.ToDecimal(findOrderRow["QTY_FREE_PRM"]);

            ToleranceRatio = bomItem.SalesToleranceMax;
            maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

            if (maxCouldReadValue < (masterReadQty + pQty))
            {
                Screens.Error(string.Format("Miktarı aşıyorsunuz [1] İzin Verilen:{0} Girilen:{1} ", maxCouldReadValue, masterReadQty + bomItem.Qty));
                return false;
            }

            findOrderRow["READ_QTY"] = masterReadQty + pQty;
            findOrderRow["QTY_FREE_PRM"] = masterFreeQty + bomItem.QtyFreePrm;
            findOrderRow["FREE_PRMM_ID"] = bomItem.FreePrmMId;
            findOrderRow["FREE_PRM_CODE"] = bomItem.FreePrmMCode;


            var dr = DtPackageItems.NewRow();
            bomItemDataRows.Add(dr);
            //DtPackageItems.Rows.Add(dr);
            dr["ITEM_CODE"] = bomItem.ItemCode;
            dr["ITEM_NAME"] = bomItem.ItemName;
            dr["ITEM_ID"] = bomItem.ItemId;
            dr["PACKAGE_NO"] = bomItem.PackageMNo;


            dr["PACKAGE_M_ID"] = bomItem.PackageMId;
            dr["QTY"] = bomItem.Qty;
            dr["UNIT_CODE"] = bomItem.UnitCode;
            dr["QTY_FREE_PRM"] = bomItem.QtyFreePrm;
            dr["FREE_PRM_CODE"] = bomItem.QualityCode;

            dr["QUALITY_ID"] = bomItem.QualityId;
            dr["QUALITY_CODE"] = bomItem.QualityCode;

            dr["LOT_CODE"] = bomItem.LotCode;
            dr["LOT_ID"] = bomItem.LotId;

            dr["COLOR_ID"] = bomItem.ColorId;
            dr["COLOR_CODE"] = bomItem.ColorCode;

            dr["ITEM_ATTRIBUTE1_ID"] = bomItem.ItemAttribute1Id;
            dr["ITEM_ATTRIBUTE2_ID"] = bomItem.ItemAttribute2Id;
            dr["ITEM_ATTRIBUTE3_ID"] = bomItem.ItemAttribute3Id;

            dr["ITEM_ATTRIBUTE1_CODE"] = bomItem.ItemAttribute1Code;
            dr["ITEM_ATTRIBUTE2_CODE"] = bomItem.ItemAttribute2Code;
            dr["ITEM_ATTRIBUTE3_CODE"] = bomItem.ItemAttribute3Code;

            dr["UNIT_ID"] = bomItem.UnitId;
            dr["FREE_PRMM_ID"] = bomItem.FreePrmMId;
            dr["TOLERANCE_MAX_SO"] = bomItem.SalesToleranceMax;
            dr["TOLERANCE_MIN_SO"] = bomItem.SalesToleranceMin;
            dr["MASTER_PACKAGE_M_ID"] = MasterPackageId;
            dr["SOURCE_D_ID"] = bomItem.SourceDId;

            dr["REFERRAL_DTL_ID"] = findOrderRow["REFERRAL_DTL_ID"];

            return true;

        }


        void CreateOrderShipping()
        {
            _PrinterName = string.Empty;
            //if (_Print)
            //{
            //    _PrinterName = Classes.SysDefinitions.GetXmlData("MainParam", "DefaultPrinter").ToString();

            //    if (string.IsNullOrEmpty(_PrinterName))
            //    {
            //        MessageBox.Show(" Lütfen Printer Adını Tanımlayınız. \n Sysdef.xml Dosyasında , DefaultPrinter Parametresi Boş Olamaz.");
            //        btnIrsaliyeOlustur.Enabled = true;
            //        return;
            //    }
            //}


            int pItemId = 0;
            PackageCreateOrderShippingMOut prm = new PackageCreateOrderShippingMOut();

            List<PackageCreateOrderShippingOrderOut> orderItems = new List<PackageCreateOrderShippingOrderOut>();
            List<PackageCreateOrderShippingPackageOut> pReadPackages = new List<PackageCreateOrderShippingPackageOut>();
            foreach (DataRow Dr in DtOrder.Rows)
            {
                var ord = new PackageCreateOrderShippingOrderOut
                {
                    ItemId = Convert.ToInt32(Dr["ITEM_ID"]),
                    LineNo = Convert.ToInt32(Dr["LINE_NO"]),
                    QtyOrder = Convert.ToDecimal(Dr["QTY"]),
                    QtyReferral = Convert.ToDecimal(Dr["READ_QTY"]),
                    QualityId = Convert.ToInt32(Dr["QUALITY_ID"]),
                    LotId = Convert.ToInt32(Dr["LOT_ID"]),
                    ColorId = Convert.ToInt32(Dr["COLOR_ID"]),
                    ItemAttribute1Id = Convert.ToInt32(Dr["ITEM_ATTRIBUTE1_ID"]),
                    ItemAttribute2Id = Convert.ToInt32(Dr["ITEM_ATTRIBUTE2_ID"]),
                    ItemAttribute3Id = Convert.ToInt32(Dr["ITEM_ATTRIBUTE3_ID"]),
                    WhouseId = Convert.ToInt32(Dr["WAREHOUSE_ID"]),
                    ReferralOrdersDId = Convert.ToInt32(Dr["REFERRAL_DTL_ID"]),
                    CreateWaybill = Convert.ToBoolean(Dr["CREATE_WAYBILL"]),
                    OrderMId = Convert.ToInt32(Dr["SOURCE_M_ID"])

                };
                orderItems.Add(ord);
            }

            List<PackageCreateOrderShippingPackageDetailOut> pPackageItems = new List<PackageCreateOrderShippingPackageDetailOut>();
            List<DataRow> lstRows = new List<DataRow>();

            #region Load Details
            if (_KarmaPaketIzinVar == true)
            {
                foreach (DataRow itemD in DtPackageItems.Rows)
                {
                    pItemId = 0;
                    if (!string.IsNullOrEmpty(itemD["ITEM_ID"].ToString()))
                        pItemId = Convert.ToInt32(itemD["ITEM_ID"]);

                    PackageCreateOrderShippingPackageDetailOut ds = new PackageCreateOrderShippingPackageDetailOut
                    {
                        BomedPackageMid = Convert.ToInt32(itemD["PACKAGE_M_ID"]),
                        FreePrmMId = Convert.ToInt32(itemD["FREE_PRMM_ID"]),
                        ItemId = pItemId,
                        MasterPackageMid = Convert.ToInt32(itemD["MASTER_PACKAGE_M_ID"]),
                        Qty = Convert.ToDecimal(itemD["QTY"]),
                        QtyFreePrm = Convert.ToDecimal(itemD["QTY_FREE_PRM"]),
                        QualityId = Convert.ToInt32(itemD["QUALITY_ID"]),
                        LotId = Convert.ToInt32(itemD["LOT_ID"]),
                        ColorId = Convert.ToInt32(itemD["COLOR_ID"]),
                        ItemAttribute1Id = Convert.ToInt32(itemD["ITEM_ATTRIBUTE1_ID"]),
                        ItemAttribute2Id = Convert.ToInt32(itemD["ITEM_ATTRIBUTE2_ID"]),
                        ItemAttribute3Id = Convert.ToInt32(itemD["ITEM_ATTRIBUTE3_ID"]),
                        SourceDId = Convert.ToInt32(itemD["SOURCE_D_ID"]),
                        UnitId = Convert.ToInt32(itemD["UNIT_ID"]),
                        ReferralDetailId = Convert.ToInt32(itemD["REFERRAL_DTL_ID"])
                    };
                    pPackageItems.Add(ds);
                    lstRows.Add(itemD);
                }
            }
            else
            {
                foreach (DataRow itemD in ReadPackages)
                {
                    PackageCreateOrderShippingPackageDetailOut ds = new PackageCreateOrderShippingPackageDetailOut
                    {
                        BomedPackageMid = Convert.ToInt32(itemD["PACKAGE_M_ID"]),
                        FreePrmMId = Convert.ToInt32(itemD["FREE_PRMM_ID"]),
                        ItemId = Convert.ToInt32(itemD["ITEM_ID"]),
                        Qty = Convert.ToDecimal(itemD["QTY"]),
                        QtyFreePrm = Convert.ToDecimal(itemD["QTY_FREE_PRM"]),
                        QualityId = Convert.ToInt32(itemD["QUALITY_ID"]),
                        LotId = Convert.ToInt32(itemD["LOT_ID"]),
                        ColorId = Convert.ToInt32(itemD["COLOR_ID"]),
                        ItemAttribute1Id = Convert.ToInt32(itemD["ITEM_ATTRIBUTE1_ID"]),
                        ItemAttribute2Id = Convert.ToInt32(itemD["ITEM_ATTRIBUTE2_ID"]),
                        ItemAttribute3Id = Convert.ToInt32(itemD["ITEM_ATTRIBUTE3_ID"]),
                        SourceDId = Convert.ToInt32(itemD["SOURCE_D_ID"]),
                        UnitId = Convert.ToInt32(itemD["UNIT_ID"]),
                        ReferralDetailId = Convert.ToInt32(itemD["REFERRAL_DTL_ID"])
                    };
                    pPackageItems.Add(ds);
                    lstRows.Add(itemD);
                }
            }

            #endregion Load Details

            foreach (DataRow drPackage in ReadPackages)
            {
                var lineNo = Convert.ToInt32(drPackage["LINE_NO"]);
                var _OrderMId = Convert.ToInt32(drPackage["SOURCE_M_ID"]);
                //  throw new Exception("Order M ID tanımsız1");
                //Convert.ToInt32(drPackage["SOURCE_M_ID"]);
                var readReferralOrdersDId = Convert.ToInt32(drPackage["REFERRAL_DTL_ID"]); //Bu dolu olmalı.
                var readLocationId = Convert.ToInt32(drPackage["READ_LOCATION_ID"]); //Okuma Rafı

                if (_KarmaPaketIzinVar == true) //Karma ambalaj
                {
                    var pi = new PackageCreateOrderShippingPackageOut
                    {
                        LineNo = lineNo,
                        PackageMid = Convert.ToInt32(drPackage["PACKAGE_M_ID"]),
                        ReferralOrdersDId = readReferralOrdersDId,
                        ReadLocationId = readLocationId
                    };
                    pReadPackages.Add(pi);
                }
                else //Normal ambalaj
                {
                    var pi = new PackageCreateOrderShippingPackageOut
                    {
                        FreePrmMId = Convert.ToInt32(drPackage["FREE_PRMM_ID"]),
                        ItemId = Convert.ToInt32(drPackage["ITEM_ID"]),
                        LineNo = lineNo,
                        PackageMid = Convert.ToInt32(drPackage["PACKAGE_M_ID"]),
                        Qty = Convert.ToDecimal(drPackage["QTY"]),
                        QtyFreePrm = Convert.ToDecimal(drPackage["QTY_FREE_PRM"]),
                        QualityId = Convert.ToInt32(drPackage["QUALITY_ID"]),
                        LotId = Convert.ToInt32(drPackage["LOT_ID"]),
                        ColorId = Convert.ToInt32(drPackage["COLOR_ID"]),
                        ItemAttribute1Id = Convert.ToInt32(drPackage["ITEM_ATTRIBUTE1_ID"]),
                        ItemAttribute2Id = Convert.ToInt32(drPackage["ITEM_ATTRIBUTE2_ID"]),
                        ItemAttribute3Id = Convert.ToInt32(drPackage["ITEM_ATTRIBUTE3_ID"]),
                        ReferralOrdersDId = readReferralOrdersDId,
                        SourceApp2 = Convert.ToInt32(drPackage["SOURCE_APP2"]),
                        Barcode = drPackage["BARCODE"].ToString(),
                        SerialNo = drPackage["SERIAL_NO"].ToString(),
                        ReadLocationId = Convert.ToInt32(drPackage["READ_LOCATION_ID"])
                    };

                    #region Normal Palet Fazla Miktar Kontrolü
                    var MasterOrderItem = orderItems.FirstOrDefault(n => n.ReferralOrdersDId == readReferralOrdersDId);
                    if (MasterOrderItem != null)
                    {
                        decimal ToleranceMin = Convert.ToDecimal(drPackage["TOLERANCE_MIN_SO"]);
                        decimal ToleranceRatio = Convert.ToDecimal(drPackage["TOLERANCE_MAX_SO"]);

                        var minReadCouldValue = MasterOrderItem.QtyOrder * (100M - ToleranceMin) / 100M;
                        var maxCouldReadValue = MasterOrderItem.QtyOrder * (100M + ToleranceRatio) / 100M;

                        if (ToleranceMin > 0 && minReadCouldValue > MasterOrderItem.QtyReferral)
                        {
                            Screens.Error(string.Format("{0}. Satırda Okunan Miktar :{1} dir. Fakat {2} küçük olamaz.", lineNo, MasterOrderItem.QtyReferral, minReadCouldValue));
                            btnIrsaliyeOlustur.Enabled = true;
                            return;
                        }
                        var torelanceDic = lstRows.Select(n => new
                        {
                            Min = Convert.ToDecimal(n["TOLERANCE_MIN_SO"]),
                            Max = Convert.ToDecimal(n["TOLERANCE_MAX_SO"]),
                            ItemId = Convert.ToInt32(n["ITEM_ID"])
                        }).Distinct().ToDictionary(n => n.ItemId);

                        if (maxCouldReadValue < (MasterOrderItem.QtyReferral))
                        {
                            Screens.Error(string.Format("{2}. Satırda Miktarı aşıyorsunuz İzin Verilen:{0} Girilen:{1} ", maxCouldReadValue, MasterOrderItem.QtyReferral, lineNo));
                            btnIrsaliyeOlustur.Enabled = true;
                            return;
                        }
                    }
                    #endregion Normal Palet Fazla Miktar Kontrolü
                    if (pReadLocationUsed && Convert.ToInt32(drPackage["PACKAGE_M_ID"]) > 0)
                    {
                        var pFind = pReadPackages.Cast<PackageCreateOrderShippingPackageOut>().Where(t => t.PackageMid == Convert.ToInt32(drPackage["PACKAGE_M_ID"])).FirstOrDefault();
                        if (pFind != null)
                            continue;
                    }

                    pReadPackages.Add(pi);
                }
            }

            prm.IsMixedPalet = _KarmaPaketIzinVar; //Karma Palet
            prm.PackageDetails = pPackageItems.ToArray(); //Stok Bazında detay
            prm.Packages = pReadPackages.ToArray(); //Ambalaj

            prm.Orders = orderItems.ToArray(); //Sipariş

            /*
            throw new Exception("OrderMId Tanımlı Değil");
            prm.OrderMId = 0;// _OrderMId;
            */
            prm.NakliyeSekliId = _NakliyeSekliId;
            prm.NakliyeKoduId = _NakliyeKoduId;
            prm.IrsaliyeKoduId = _IrsaliyeKoduId;
            prm.IrsaliyeTarihi = _IrsaliyeTarihi;
            prm.IrsaliyeNo = _IrsaliyeNo;
            prm.IrsaliyeSeri = _IrsaliyeSeri;
            prm.IrsaliyeSiraNo = _IrsaliyeSiraNo;
            prm.SalesPersonId = _PersonId;

            prm.VehicleId = _VehicleId;
            prm.LicencePlate = _LicencePlate;
            prm.DriverName = _DriverName;
            prm.DriverFamilyName = _DriverFamilyName;
            prm.DriverIdentifyNo = _DriverIdentifyNo;
            prm.DriverGsmNo = _DriverGsmNo;
            prm.TransportEquipment = _TransportEquipment;
            prm.ShippingDesc1 = _ShippingDesc1;

            prm.AgainstWhouseId = _AgainstWhouseId; //Eğer Transfer ise Hedef depo 

            prm.Note1 = _Irsaliye_Note1;
            prm.Note2 = _Irsaliye_Note2;
            prm.Note3 = _Irsaliye_Note3;

            if (!string.IsNullOrEmpty(Tx_Note1.Text))
                prm.Note1 = Tx_Note1.Text; //Açıklama-1

            ClientApplication.Instance.UTermService.Timeout = -1;
            var res = ClientApplication.Instance.UTermService.PackageCreateOrderShipping(new ServiceRequestOfPackageCreateOrderShippingMOut
            {
                Token = ClientApplication.Instance.UTermToken,
                Value = prm
            });
            //Value = _PrinterName
            if (res.Result)
            {
                Screens.Info("İrsaliye Oluştu");
                btnIrsaliyeOlustur.Enabled = true;
                #region İrsaliye Yazdırma Rapor ServerDan
                if (!string.IsNullOrEmpty(_PrinterName)) //İrsaliye yazdır.
                {
                    int pItemMId = Convert.ToInt32(res.Value);
                    DirectPrintInParamsIn prmPrint = new DirectPrintInParamsIn();
                    prmPrint.PageCode = "RPP_PSM_4056";
                    prmPrint.PrinterName = _PrinterName;
                    prmPrint.PrintItemId = pItemMId;
                    var resPrint = ClientApplication.Instance.UTermService.DirectPrintFromServer(new ServiceRequestOfDirectPrintInParamsIn
                    {
                        Token = ClientApplication.Instance.UTermToken,
                        Value = prmPrint
                    });
                    if (resPrint.Result)
                    {
                        Screens.Error(string.Format("İrsaliye Yazdırıldı \n İrs.Ref.Id : {0} ", pItemMId));
                    }
                    else
                    {
                        Screens.Error(string.Format("İrsaliye Yazdırılırken Hata Oluştu. \n İrs.Ref.Id : {0} \n Hata : {1}", pItemMId, res.Message));
                    }
                }
                #endregion İrsaliye Yazdırma Rapor ServerDan
                // _OrderMId = 0;
                SetOrderDataGrid();
            }
            else
            {
                Screens.Error(string.Concat("Hata:", res.Message, ", Detay:", FileHelper.ToXml(prm)));
                btnIrsaliyeOlustur.Enabled = true;
                return;
            }


        }



        private void btnSevkSec_Click(object sender, EventArgs e)
        {
            FrmArama fa = new FrmArama("OrderM3_Multi", 0, 0, 0);
            fa.ShowDialog();
            if (fa.RetKey.ToString() == "" || fa.RetKey.ToString() == null) return;
            Update_ReadLocationId(0);
            try
            {
                Screens.ShowWait();

                // _OrderMId = Int32.Parse(fa.RetKey.ToString());
                var OrderIds = fa.RetKey.ToString().Split(',');
                if (_KarmaPaketIzinVar)
                {
                    string[] pOrderIds = OrderIds;
                    if (pOrderIds.Distinct().ToArray().Count() > 1)
                    {
                        throw new Exception("Karma Palet Kullanımında Birden Seçim Yapılamaz !!!!");
                    }
                }


                this.ReferralOrderCodes = fa.RetKey2.ToString().Split(',');
                this.TxTransporterDesc.Text = fa.RetKey4.ToString(); /*Nakliye Şekli Adı*/
                TxOrderNo.Text = fa.RetKey2.ToString();

                GetReferralOrderDetails(OrderIds);
            }
            catch (Exception ex)
            {
                Screens.Error("Hata : " + ex.Message);
            }

            Screens.HideWait();
        }

        private void GetReferralOrderDetails(string[] OrderIds)
        {
            this.ReferralOrderDIds = OrderIds;
            SetOrderDataGrid();
            ClientApplication.Instance.UTermService.Timeout = -1;
            var DataTempValues = ClientApplication.Instance.UTermService.GetPackageOrderInfoFromTemp(new ServiceRequestOfPackageTempAddItemIn
            {
                Token = ClientApplication.Instance.UTermToken,

                Value = new PackageTempAddItemIn
                {
                    SourceApp = pSourceApp,
                    SourceApp2 = (int)SourceApplication.Ambalaj,
                    SourceMId = 0,// _OrderMId,
                    WhouseId = ClientApplication.Instance.SelectedDepot.Id,
                    Ids = OrderIds,
                    BomPacKageTraMGetItems = _KarmaPaketIzinVar
                }
            });

            ClientApplication.Instance.UTermService.Timeout = -1;
            var DataTempValuesBarkod = ClientApplication.Instance.UTermService.GetPackageOrderInfoFromTemp(new ServiceRequestOfPackageTempAddItemIn
            {
                Token = ClientApplication.Instance.UTermToken,

                Value = new PackageTempAddItemIn
                {
                    SourceApp = pSourceApp,
                    SourceApp2 = (int)SourceApplication.Stok,
                    SourceMId = 0,// _OrderMId,
                    WhouseId = ClientApplication.Instance.SelectedDepot.Id,
                    Ids = OrderIds,
                    BomPacKageTraMGetItems = _KarmaPaketIzinVar
                }
            });
            ClientApplication.Instance.UTermService.Timeout = -1;
            var DataTempValuesSeri = ClientApplication.Instance.UTermService.GetPackageOrderInfoFromTemp(new ServiceRequestOfPackageTempAddItemIn
            {
                Token = ClientApplication.Instance.UTermToken,

                Value = new PackageTempAddItemIn
                {
                    SourceApp = pSourceApp,
                    SourceApp2 = (int)SourceApplication.BağımsızSeri,
                    SourceMId = 0,// _OrderMId,
                    WhouseId = ClientApplication.Instance.SelectedDepot.Id,
                    Ids = OrderIds,
                    BomPacKageTraMGetItems = _KarmaPaketIzinVar
                }
            });
            ClientApplication.Instance.UTermService.Timeout = 50 * 1000;

            if (DataTempValues.Result || DataTempValuesBarkod.Result || DataTempValuesSeri.Result)
            {
                if (DataTempValues.Result)
                {
                    foreach (var item in DataTempValues.Value.Cast<OutPacKageD>().OrderBy(t => t.ReadSequenceId).ToList())
                    {
                        this.AddPackageRow(item, true, string.Empty, string.Empty, 1);
                    }
                }
                if (DataTempValuesBarkod.Result)
                {
                    foreach (var item in DataTempValuesBarkod.Value.Cast<OutPacKageD>().OrderBy(t => t.ReadSequenceId).ToList())
                    {
                        this.AddPackageRow(item, true, string.Empty, string.Empty, item.MultiplierBarcodeQty);
                    }
                }
                if (DataTempValuesSeri.Result)
                {
                    foreach (var item in DataTempValuesSeri.Value.Cast<OutPacKageD>().OrderBy(t => t.ReadSequenceId).ToList())
                    {
                        this.AddPackageRow(item, true, item.Barcode, item.SerialNo, 1);
                    }
                }
                showLineNo = -1;
                reFreshSerialGrid();
                reFreshPackageItemGrid();
            }
        }


        private void SetOrderDataGrid()
        {
            try
            {
                Update_ReadLocationId(0);

                _Print = false;
                Tx_Note1.Text = string.Empty;
                DtOrder.Rows.Clear();
                ReadPackages.Clear();
                DtPackageItems.Rows.Clear();

                if (this.ReferralOrderDIds.Length > 0)
                {
                    int LineNo = 10;
                    int ixindexOrderM = 0;
                    foreach (var orderMIdstring in ReferralOrderDIds)
                    {
                        var OrderMIdRead = Int32.Parse(orderMIdstring);
                        var ReferralOrderCode = ReferralOrderCodes[ixindexOrderM];
                        ixindexOrderM++;
                        //    int indexOrderM=ReferralOrderDIds.Ind


                        ServiceRequestOfSelectParam _SParam = new ServiceRequestOfSelectParam();
                        _SParam.Token = ClientApplication.Instance.UTermToken;
                        _SParam.Value = new SelectParam();
                        _SParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                        _SParam.Value.InfoId = OrderMIdRead;
                        var _SvkList = new ServiceResultOfListOfReferralDetailInfo();
                        _SvkList = ClientApplication.Instance.UTermService.GetReferralOrdersDetail(_SParam);
                        if (!_SvkList.Result)
                            throw new Exception(_SvkList.Message);

                        var _Liste = from p in _SvkList.Value orderby p.ItemId orderby p.ReferralDetailId select p;

                        decimal pFazlaYuzdeliKalanMiktar = 0m;
                        foreach (ReferralDetailInfo _DtList in _Liste)
                        {

                            DataRow Dr = DtOrder.NewRow();
                            Dr["LINE_NO"] = LineNo;
                            Dr["ITEM_CODE"] = _DtList.ItemCode;
                            Dr["ITEM_NAME"] = _DtList.ItemName;
                            Dr["ITEM_ID"] = _DtList.ItemId;
                            Dr["WAREHOUSE_CODE"] = _DtList.WhouseCode;
                            Dr["WAREHOUSE_ID"] = _DtList.WhouseId;
                            Dr["QTY"] = _DtList.QtyRemainder;
                            Dr["READ_QTY"] = 0;

                            Dr["SALES_TOLERANCE_MAX_SO"] = _DtList.SalesToleranceMaxSo; //Fazla Sevk Yüzdesi.

                            pFazlaYuzdeliKalanMiktar = (_DtList.QtyShipping + ((_DtList.QtyShipping * _DtList.SalesToleranceMaxSo / 100) * _DtList.UnitFactor)) - _DtList.QtyReferral;

                            Dr["QTY_MAX_SO"] = pFazlaYuzdeliKalanMiktar; //Miktar + Fazla Sevk Miktarı (Miktar 10 ise ve % 10 ise; 12 olur ; Gönderim 3 var ise 9)

                            Dr["NOTE1"] = _DtList.Note1;

                            Dr["QUALITY_CODE"] = _DtList.QualityCode;
                            Dr["QUALITY_ID"] = _DtList.QualityId;

                            Dr["LOT_CODE"] = _DtList.LotCode;
                            Dr["LOT_ID"] = _DtList.LotId;


                            Dr["COLOR_CODE"] = _DtList.ColorCode;
                            Dr["COLOR_ID"] = _DtList.ColorId;

                            Dr["ITEM_ATTRIBUTE1_CODE"] = _DtList.ItemAttribute1Code;
                            Dr["ITEM_ATTRIBUTE1_ID"] = _DtList.ItemAttribute1Id;

                            Dr["ITEM_ATTRIBUTE2_CODE"] = _DtList.ItemAttribute2Code;
                            Dr["ITEM_ATTRIBUTE2_ID"] = _DtList.ItemAttribute2Id;

                            Dr["ITEM_ATTRIBUTE3_CODE"] = _DtList.ItemAttribute3Code;
                            Dr["ITEM_ATTRIBUTE3_ID"] = _DtList.ItemAttribute3Id;



                            Dr["QTY_FREE_PRM"] = 0;
                            Dr["FREE_PRM_CODE"] = "";
                            Dr["FREE_PRMM_ID"] = 0;
                            Dr["REFERRAL_DTL_ID"] = _DtList.ReferralDetailId;
                            Dr["SOURCE_D_ID"] = _DtList.SourceDId;
                            Dr["SOURCE_M_ID"] = OrderMIdRead;
                            Dr["REFEREL_ORDER_CODE"] = ReferralOrderCode;
                            Dr["LINE_TYPE"] = _DtList.Linetype;
                            Dr["CREATE_WAYBILL"] = false;

                            Dr["INCOTERMS_NAME"] = _DtList.IncotermsName; //Teslim Şekli
                            Dr["PAYMENT_METHOD_DESC"] = _DtList.PaymentMethodDesc; //Ödeme Şekli
                            Dr["ITEM_ADDSTRING01"] = _DtList.ItemAddString01; //Ödeme Şekli
                            Dr["IS_SERIALTRACK"] = _DtList.IsserialTrack; //Seri Takibi



                            LineNo += 10;

                            DtOrder.Rows.Add(Dr);

                            if (_DtList.TempCoDocTraIdWaybill > 0)
                            {
                                pTempCoDocTraIdWaybill = _DtList.TempCoDocTraIdWaybill;
                                pTempCoDocTraCodeWaybill = _DtList.TempCoDocTraCodeWaybill;
                            }
                        }

                    }
                }
                gridOrder.DataSource = DtOrder;
                gridOrder.Refresh();

                gridPackage.DataSource = null;
                gridPackage.Refresh();

                gridPackageItem.DataSource = null;
                gridPackageItem.Refresh();
            }
            catch (SystemException ex)
            {
                Screens.Error("Hata-003 :" + ex.Message);
            }
        }


        int showLineNo = -1;
        private void gridOrder_CurrentCellChanged(object sender, EventArgs e)
        {
            int selectedLineNo = Convert.ToInt32(gridOrder[gridOrder.CurrentCell.RowNumber, 0]);
            //if (selectedLineNo == showLineNo) return;
            showLineNo = selectedLineNo;

            reFreshSerialGrid();

        }

        private void reFreshSerialGrid()
        {
            this.DtPackageShow.Rows.Clear();
            foreach (DataRow dr in ReadPackages)
            {
                var readLineNo = Convert.ToInt32(dr["LINE_NO"]);
                if (showLineNo == -1)
                {
                    showLineNo = readLineNo;
                }
                if (readLineNo == showLineNo || _KarmaPaketIzinVar)
                {
                    var drNew = DtPackageShow.NewRow();

                    for (int i = 0; i < DtPackageShow.Columns.Count; i++)
                    {
                        drNew[i] = dr[i];
                    }
                    DtPackageShow.Rows.Add(drNew);
                }
            }
            if (!_KarmaPaketIzinVar)
            {
                if (showLineNo < 0)
                    lbSelectOrderInfo.Text = "";

                else
                {
                    lbSelectOrderInfo.Text = string.Format("{0} Satır Ambalajları", showLineNo);
                }
            }
            else
            {
                lbSelectOrderInfo.Text = "Karma Palet Ambalaj Bilgileri";

            }
            gridPackage.DataSource = DtPackageShow;
            gridPackage.Refresh();
        }

        private void gridPackage_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_KarmaPaketIzinVar)
            {
                int selectedPackageId = Convert.ToInt32(gridPackage[gridPackage.CurrentCell.RowNumber, 7]);

                string selectedPackageNo = (gridPackage[gridPackage.CurrentCell.RowNumber, 6] ?? "").ToString();
                //if (selectedLineNo == showLineNo) return;
                showPackageMId = selectedPackageId;
                reFreshPackageItemGrid();
            }
        }

        int showPackageMId = -1;
        void reFreshPackageItemGrid()
        {
            this.DtPackageItemShow.Clear();
            var selectedPackageNo = "";
            foreach (DataRow dr in DtPackageItems.Rows)
            {
                var readPackageMId = Convert.ToInt32(dr["MASTER_PACKAGE_M_ID"]);
                if (showPackageMId == -1)
                {
                    showPackageMId = readPackageMId;
                }

                if (readPackageMId == showPackageMId)
                {
                    selectedPackageNo = dr["PACKAGE_NO"].ToString();

                    var drNew = DtPackageItemShow.NewRow();

                    for (int i = 0; i < DtPackageItems.Columns.Count; i++)
                    {
                        drNew[i] = dr[i];
                    }
                    DtPackageItemShow.Rows.Add(drNew);
                }
            }

            gridPackageItem.DataSource = DtPackageItemShow;
            gridPackageItem.Refresh();


            lbSelectPackageInfo.Text = string.Format("[{0}] Ambalaja Ait Detaylar", selectedPackageNo);

        }

        private void gridOrder_DoubleClick(object sender, EventArgs e)
        {
            if (DtOrder.Rows.Count > 0)
            {
                var row = DtOrder.Rows[gridOrder.CurrentRowIndex];
                if (row != null)
                {
                    int pReferralDetailId = Convert.ToInt32(row["REFERRAL_DTL_ID"].ToString());
                    string pLineType = row["LINE_TYPE"].ToString();
                    if (pLineType == "H") /*Hizmet İse*/
                    {
                        bool pReferralDetailSelect = Boolean.Parse((row["CREATE_WAYBILL"]).ToString()); //Seçilmiş mi?
                        pReferralDetailSelect = pReferralDetailSelect == false ? true : false;
                        foreach (DataRow drOrder in DtOrder.Rows)
                        {
                            int rowDetailId = Convert.ToInt32(drOrder["REFERRAL_DTL_ID"]);
                            if (rowDetailId != pReferralDetailId)
                                continue;
                            drOrder["CREATE_WAYBILL"] = pReferralDetailSelect;
                        }
                        gridOrder.DataSource = DtOrder;
                        gridOrder.Refresh();
                    }
                }
            }
        }

        private void BtnSalesPerson_Click(object sender, EventArgs e)
        {
            FrmArama fa = new FrmArama("GetSalesPersons", 0, 0, 1); //iade hareket tiplerini filtrele
            fa.ShowDialog();
            if (fa.RetKey.ToString() == "" || fa.RetKey == null) return;
            try
            {
                _PersonId = Convert.ToInt32(fa.RetKey.ToString());
                _PersonCode = fa.RetKey2.ToString();
                Tx_SalesPerson.Text = _PersonCode;
            }
            catch (SystemException ex)
            {
                Screens.Error(string.Format("Hata : ", ex.Message));
            }
        }

        private void Tx_PackageNoRevort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Tx_PackageMId.Text = string.Empty;
                if (Tx_PackageNoRevort.Text.Length > 0 && _BarcodeBitisKarakter != string.Empty)
                {
                    if (_BarcodeBitisKarakter.ToLower() == "bosluk")
                    {
                        if (Tx_PackageNoRevort.Text.IndexOf(" ") > 0)
                        {
                            Tx_PackageNoRevort.Text = Tx_PackageNoRevort.Text.Substring(0, Tx_PackageNoRevort.Text.IndexOf(" "));
                        }
                    }
                    else if (Tx_PackageNoRevort.Text.IndexOf(_BarcodeBitisKarakter) > 0)
                    {
                        Tx_PackageNoRevort.Text = Tx_PackageNoRevort.Text.Substring(0, Tx_PackageNoRevort.Text.IndexOf(_BarcodeBitisKarakter) - 1);
                    }
                }
                try
                {
                    if (string.IsNullOrEmpty(Tx_PackageNoRevort.Text.ToString()))
                    {
                        throw new Exception(string.Format("Ambalaj Numarasına Ulaşılamadı-[PaletSevk>AmbalajÇöz]"));
                    }
                    ServiceRequestOfItemPickingParam _Ipp = new ServiceRequestOfItemPickingParam();
                    _Ipp.Token = ClientApplication.Instance.UTermToken;
                    _Ipp.Value = new ItemPickingParam();
                    _Ipp.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    _Ipp.Value.PackageNo = Tx_PackageNoRevort.Text.ToString();

                    _PacRes = ClientApplication.Instance.UTermService.GetPackageInfo(_Ipp);

                    if (_PacRes.Result == false)
                    {
                        Screens.Error(_PacRes.Message.ToString());
                        Tx_PackageNoRevort.Focus();
                        Btn_PackRelease.Enabled = false;
                        return;
                    }
                    Tx_PackageMId.Text = _PacRes.Value.PackageDId.ToString();
                    Btn_PackRelease.Enabled = true;
                }
                catch (SystemException)
                {
                    Btn_PackRelease.Enabled = false;
                    Tx_PackageNoRevort.Text = string.Empty;
                    Tx_PackageNoRevort.Focus();
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 0)
            {
                //1.sayfa
            }
            else if ((sender as TabControl).SelectedIndex == 1) //2.sayfa
            {
                //2.sayfa
            }
            else if ((sender as TabControl).SelectedIndex == 2) //2.sayfa
            {
                //3.sayfa
            }
            else if ((sender as TabControl).SelectedIndex == 3) //4.sayfa-Ambalaj Çöz
            {
                //4.sayfa
                Tx_PackageNoRevort.Text = string.Empty;
                Tx_PackageNoRevort.Focus();
                Btn_PackRelease.Enabled = false;
            }
        }

        private void Btn_PackRelease_Click(object sender, EventArgs e)
        {
            if (_PacRes.Result == false)
            {
                Screens.Error("Lütfen Ambalaj Kodu Giriniz");
                return;
            }
            if (string.IsNullOrEmpty(_PacRes.Value.PackageNo))
            {
                Screens.Error(string.Format("Ambalaj Numarasına Ulaşılamadı.\n Ambalaj ID:", _PacRes.Value.PackageDId));
                return;
            }

            ServiceRequestOfPackageDetail _Param = new ServiceRequestOfPackageDetail();
            _Param.Token = ClientApplication.Instance.UTermToken;
            _Param.Value = new PackageDetail();
            _Param.Value.PackageMId = _PacRes.Value.PackageDId;
            _Param.Value.PackageNo = _PacRes.Value.PackageNo;
            _Param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;

            ServiceResultOfString _Str = ClientApplication.Instance.UTermService.RevortPackage(_Param);
            if (_Str.Result == false)
            {
                Screens.Error(_Str.Message.ToString());
            }
            else
            {
                Screens.Info(string.Format("{0} \n {1},", "İşlem Tamamlandı", _Str.Value));
                Tx_PackageNoRevort.Text = string.Empty;
            }
            Tx_PackageNoRevort.Focus();
            Btn_PackRelease.Enabled = false;
        }

        private void TxOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(TxOrderNo.Text))
                {
                    ClientApplication.Instance.UTermService.Timeout = -1;
                    ServiceRequestOfSelectParam _SParam = new ServiceRequestOfSelectParam();
                    _SParam.Token = ClientApplication.Instance.UTermToken;
                    _SParam.Value = new SelectParam();
                    _SParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    _SParam.Value.IsItemPicking = 0;
                    _SParam.Value.SearchEntity = TxOrderNo.Text;

                    ServiceResultOfListOfReferralInfo _RefInfo = ClientApplication.Instance.UTermService.GetReferralOrders(_SParam);
                    if (_RefInfo.Result && _RefInfo.Value.Length > 0)
                    {
                        string[] OrderIds = new string[1] { _RefInfo.Value[0].Id.ToString() };
                        this.ReferralOrderCodes = new string[1] { _RefInfo.Value[0].DocNo };
                        this.TxTransporterDesc.Text = _RefInfo.Value[0].TransporterDesc; /*Nakliye Şekli Adı*/
                        TxOrderNo.Text = _RefInfo.Value[0].DocNo;
                        GetReferralOrderDetails(OrderIds);
                    }
                }
            }
        }

        /// <summary>
        /// Ambalaj eklenmesi durumunda miktar aşımı hatası var mı ?
        /// </summary>
        private bool QtyErrorControl_DtOrder(OutPacKageD _PacKageD)
        {
            bool hasErrorPackage = false;
            DtOrderQtyControl.Clear();
            #region Data table oluştur.


            if (DtOrderQtyControl.Columns.Count == 0)
            {
                DtOrderQtyControl.TableName = "TableDRead";
                DataGridTableStyle tsGridOrderQtyControl = new DataGridTableStyle();
                tsGridOrderQtyControl.MappingName = "TableDRead";
                AddColumnToGrid(DtOrderQtyControl, "LINE_NO", "S.No", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.10);
                AddColumnToGrid(DtOrderQtyControl, "ITEM_CODE", "Stok Kodu", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrderQtyControl, "ITEM_NAME", "Stok Adı", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrderQtyControl, "ITEM_ID", "", typeof(int), tsGridOrderQtyControl, -1);

                AddColumnToGrid(DtOrderQtyControl, "QTY", "Miktar", typeof(decimal), tsGridOrderQtyControl, gridOrder.Width * 0.15);
                AddColumnToGrid(DtOrderQtyControl, "READ_QTY", "Okunan Miktar", typeof(decimal), tsGridOrderQtyControl, gridOrder.Width * 0.15);


                AddColumnToGrid(DtOrderQtyControl, "NOTE1", "Açk-1", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.25);

                AddColumnToGrid(DtOrderQtyControl, "LINE_TYPE", "Tip", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.10);
                AddColumnToGrid(DtOrderQtyControl, "CREATE_WAYBILL", "H.Seç", typeof(bool), tsGridOrderQtyControl, gridOrder.Width * 0.15); //Stok Dışındaki Satırların İrsaliyeye Eklenmesi içindir

                AddColumnToGrid(DtOrderQtyControl, "WAREHOUSE_CODE", "Depo Kodu", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrderQtyControl, "WAREHOUSE_ID", "", typeof(int), tsGridOrderQtyControl, -1);

                pColumnWidth = ClientApplication.Instance._IsQuality ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrderQtyControl, "QUALITY_CODE", pColumnLabelQuality, typeof(string), tsGridOrderQtyControl, pColumnWidth);
                AddColumnToGrid(DtOrderQtyControl, "QUALITY_ID", "", typeof(int), tsGridOrderQtyControl, -1);

                pColumnWidth = ClientApplication.Instance._IsColor ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrderQtyControl, "COLOR_CODE", pColumnLabelColor, typeof(string), tsGridOrderQtyControl, pColumnWidth);
                AddColumnToGrid(DtOrderQtyControl, "COLOR_ID", "", typeof(int), tsGridOrderQtyControl, -1);

                pColumnWidth = ClientApplication.Instance._IsLot ? Convert.ToInt32(gridOrder.Width * 0.30) : -1;
                AddColumnToGrid(DtOrderQtyControl, "LOT_CODE", pColumnLabelLot, typeof(string), tsGridOrderQtyControl, pColumnWidth);
                AddColumnToGrid(DtOrderQtyControl, "LOT_ID", "", typeof(int), tsGridOrderQtyControl, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute1 ? Convert.ToInt32(gridOrder.Width * 0.20) : -1;
                AddColumnToGrid(DtOrderQtyControl, "ITEM_ATTRIBUTE1_CODE", pColumnLabelAttiribute1, typeof(string), tsGridOrderQtyControl, pColumnWidth);
                AddColumnToGrid(DtOrderQtyControl, "ITEM_ATTRIBUTE1_ID", "Özellik-1 Id", typeof(int), tsGridOrderQtyControl, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute2 ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrderQtyControl, "ITEM_ATTRIBUTE2_CODE", pColumnLabelAttiribute2, typeof(string), tsGridOrderQtyControl, pColumnWidth);
                AddColumnToGrid(DtOrderQtyControl, "ITEM_ATTRIBUTE2_ID", "Özellik-2 Id", typeof(int), tsGridOrderQtyControl, -1);

                pColumnWidth = ClientApplication.Instance._IsAttribute3 ? Convert.ToInt32(gridOrder.Width * 0.35) : -1;
                AddColumnToGrid(DtOrderQtyControl, "ITEM_ATTRIBUTE3_CODE", pColumnLabelAttiribute3, typeof(string), tsGridOrderQtyControl, pColumnWidth);
                AddColumnToGrid(DtOrderQtyControl, "ITEM_ATTRIBUTE3_ID", "Özellik-3 Id", typeof(int), tsGridOrderQtyControl, -1);

                pColumnWidth = ClientApplication.Instance._IsFreeUnit1 ? Convert.ToInt32(gridOrder.Width * 0.30) : -1;
                pColumnWidth2 = ClientApplication.Instance._IsFreeUnit1 ? Convert.ToInt32(gridOrder.Width * 0.15) : -1;

                AddColumnToGrid(DtOrderQtyControl, "FREE_PRM_CODE", "Bağımsız Birimi", typeof(string), tsGridOrderQtyControl, pColumnWidth);
                AddColumnToGrid(DtOrderQtyControl, "QTY_FREE_PRM", "Bağımsız Miktar", typeof(decimal), tsGridOrderQtyControl, pColumnWidth2);
                AddColumnToGrid(DtOrderQtyControl, "FREE_PRMM_ID", "", typeof(int), tsGridOrderQtyControl, -1);

                AddColumnToGrid(DtOrderQtyControl, "REFERRAL_DTL_ID", "", typeof(int), tsGridOrderQtyControl, -1);
                AddColumnToGrid(DtOrderQtyControl, "SOURCE_D_ID", "", typeof(int), tsGridOrderQtyControl, -1);
                AddColumnToGrid(DtOrderQtyControl, "SOURCE_M_ID", "", typeof(int), tsGridOrderQtyControl, -1);

                //hrmd_payroll_type_d3
                AddColumnToGrid(DtOrderQtyControl, "REFEREL_ORDER_CODE", "Sevk.Emri", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrderQtyControl, "INCOTERMS_NAME", "Teslim Şekli", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.35);
                AddColumnToGrid(DtOrderQtyControl, "PAYMENT_METHOD_DESC", "Ödeme Şekli", typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.35);

                AddColumnToGrid(DtOrderQtyControl, "ITEM_ADDSTRING01", pItemAddString01, typeof(string), tsGridOrderQtyControl, gridOrder.Width * 0.30);
                AddColumnToGrid(DtOrderQtyControl, "IS_SERIALTRACK", "Serili", typeof(bool), tsGridOrderQtyControl, gridOrder.Width * 0.15); //Seri Takibi var .

                AddColumnToGrid(DtOrderQtyControl, "SALES_TOLERANCE_MAX_SO", "F.S.%", typeof(decimal), tsGridOrderQtyControl, gridOrder.Width * 0.20);
                AddColumnToGrid(DtOrderQtyControl, "QTY_MAX_SO", "T.F.Sevk Mik.", typeof(decimal), tsGridOrderQtyControl, -1);
            }
            #endregion Data table oluştur.
            #region Sipariş Detay Satırlarını temp table'a at
            foreach (DataRow Dr in DtOrder.Rows)
            {

                var drItemRead = DtOrderQtyControl.NewRow();
                drItemRead["LINE_NO"] = Dr["LINE_NO"];
                drItemRead["ITEM_CODE"] = Dr["ITEM_CODE"];
                drItemRead["ITEM_NAME"] = Dr["ITEM_NAME"];
                drItemRead["ITEM_ID"] = Dr["ITEM_ID"];
                drItemRead["WAREHOUSE_CODE"] = Dr["WAREHOUSE_CODE"];
                drItemRead["WAREHOUSE_ID"] = Dr["WAREHOUSE_ID"];
                drItemRead["QTY"] = Dr["QTY"];
                drItemRead["READ_QTY"] = Dr["READ_QTY"];
                drItemRead["NOTE1"] = Dr["NOTE1"];
                drItemRead["QUALITY_CODE"] = Dr["QUALITY_CODE"];
                drItemRead["QUALITY_ID"] = Dr["QUALITY_ID"];
                drItemRead["LOT_CODE"] = Dr["LOT_CODE"];
                drItemRead["LOT_ID"] = Dr["LOT_ID"];
                drItemRead["COLOR_CODE"] = Dr["COLOR_CODE"];
                drItemRead["COLOR_ID"] = Dr["COLOR_ID"];
                drItemRead["ITEM_ATTRIBUTE1_CODE"] = Dr["ITEM_ATTRIBUTE1_CODE"];
                drItemRead["ITEM_ATTRIBUTE1_ID"] = Dr["ITEM_ATTRIBUTE1_ID"];
                drItemRead["ITEM_ATTRIBUTE2_CODE"] = Dr["ITEM_ATTRIBUTE2_CODE"];
                drItemRead["ITEM_ATTRIBUTE2_ID"] = Dr["ITEM_ATTRIBUTE2_ID"];
                drItemRead["ITEM_ATTRIBUTE3_CODE"] = Dr["ITEM_ATTRIBUTE3_CODE"];
                drItemRead["ITEM_ATTRIBUTE3_ID"] = Dr["ITEM_ATTRIBUTE3_ID"];
                drItemRead["QTY_FREE_PRM"] = Dr["QTY_FREE_PRM"];
                drItemRead["FREE_PRM_CODE"] = Dr["FREE_PRM_CODE"];
                drItemRead["FREE_PRMM_ID"] = Dr["FREE_PRMM_ID"];
                drItemRead["REFERRAL_DTL_ID"] = Dr["REFERRAL_DTL_ID"];
                drItemRead["SOURCE_D_ID"] = Dr["SOURCE_D_ID"];
                drItemRead["SOURCE_M_ID"] = Dr["SOURCE_M_ID"];
                drItemRead["REFEREL_ORDER_CODE"] = Dr["REFEREL_ORDER_CODE"];
                drItemRead["LINE_TYPE"] = Dr["LINE_TYPE"];
                drItemRead["CREATE_WAYBILL"] = Dr["CREATE_WAYBILL"];
                drItemRead["INCOTERMS_NAME"] = Dr["INCOTERMS_NAME"];
                drItemRead["PAYMENT_METHOD_DESC"] = Dr["PAYMENT_METHOD_DESC"];
                drItemRead["ITEM_ADDSTRING01"] = Dr["ITEM_ADDSTRING01"];
                drItemRead["IS_SERIALTRACK"] = Dr["IS_SERIALTRACK"];

                DtOrderQtyControl.Rows.Add(drItemRead);
            }
            #endregion Sipariş Detay Satırlarını temp table'a at

            List<DataRow> bomItemDataRows = new List<DataRow>();
            try
            {
                foreach (var bomItem in _PacKageD.BomItems)
                {
                    hasErrorPackage = hasErrorPackage || !QtyControl_AddItemRowData(bomItem, _PacKageD.PackageMId, bomItemDataRows);
                    if (hasErrorPackage) break;
                }
            }
            catch (Exception ex)
            {
                Screens.Error(string.Format("Ambalaj Okuma Hatası : {0}", ex.Message));
                hasErrorPackage = true;
            }
            return hasErrorPackage;
        }

        private bool QtyControl_AddItemRowData(OutPacKageDBomItem bomItem, int MasterPackageId, List<DataRow> bomItemDataRows)
        {
            DataRow findOrderRow = null;
            bool pToleranseUsed = false;
            decimal masterLineNo = 0m;
            decimal masterQty = 0m;
            decimal masterReadQty = 0m;
            decimal masterFreeQty = 0m;
            decimal ToleranceRatio = 0m;
            decimal maxCouldReadValue = 0m;

            //Fazla Sevk : Toleranssız Satırlara Bak
            foreach (DataRow drOrder in DtOrderQtyControl.Rows)
            {
                #region Değerler
                int rowItemId = Convert.ToInt32(drOrder["ITEM_ID"]);
                int rowLotId = Convert.ToInt32(drOrder["LOT_ID"]);
                int rowQualityId = Convert.ToInt32(drOrder["QUALITY_ID"]);
                int rowSourceDId = Convert.ToInt32(drOrder["SOURCE_D_ID"]);

                int rowItemAttribute1Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE1_ID"]);
                int rowItemAttribute2Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE2_ID"]);
                int rowItemAttribute3Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE3_ID"]);

                bool SadeceSipariseAitKontrolEt = !_SadeceSipariseAitPaketler || (_SadeceSipariseAitPaketler && rowSourceDId == bomItem.SourceDId);

                masterQty = Convert.ToDecimal(drOrder["QTY"]);
                masterReadQty = Convert.ToDecimal(drOrder["READ_QTY"]);
                ToleranceRatio = 0; //bomItem.SalesToleranceMax;
                maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

                decimal pLastQty = (masterReadQty + bomItem.Qty);
                #endregion Değerler
                if (rowItemId == bomItem.ItemId
                    && (rowLotId == 0 || rowLotId == bomItem.LotId)
                    && rowQualityId == bomItem.QualityId
                    && rowItemAttribute1Id == bomItem.ItemAttribute1Id
                    && rowItemAttribute2Id == bomItem.ItemAttribute2Id
                    && rowItemAttribute3Id == bomItem.ItemAttribute3Id
                    && SadeceSipariseAitKontrolEt
                    && maxCouldReadValue >= pLastQty)
                {
                    findOrderRow = drOrder;
                    break;
                }
            }
            //Fazla Sevk : Toleranslı Satırlara Bak
            if (findOrderRow == null)
            {
                foreach (DataRow drOrder in DtOrderQtyControl.Rows)
                {
                    #region Değerler
                    int rowItemId = Convert.ToInt32(drOrder["ITEM_ID"]);
                    int rowLotId = Convert.ToInt32(drOrder["LOT_ID"]);
                    int rowQualityId = Convert.ToInt32(drOrder["QUALITY_ID"]);
                    int rowSourceDId = Convert.ToInt32(drOrder["SOURCE_D_ID"]);

                    int rowItemAttribute1Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE1_ID"]);
                    int rowItemAttribute2Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE2_ID"]);
                    int rowItemAttribute3Id = Convert.ToInt32(drOrder["ITEM_ATTRIBUTE3_ID"]);

                    bool SadeceSipariseAitKontrolEt = !_SadeceSipariseAitPaketler || (_SadeceSipariseAitPaketler && rowSourceDId == bomItem.SourceDId);

                    masterQty = Convert.ToDecimal(drOrder["QTY"]);
                    masterReadQty = Convert.ToDecimal(drOrder["READ_QTY"]);
                    ToleranceRatio = bomItem.SalesToleranceMax;
                    maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

                    decimal pLastQty = (masterReadQty + bomItem.Qty);
                    #endregion Değerler
                    if (rowItemId == bomItem.ItemId
                        && (rowLotId == 0 || rowLotId == bomItem.LotId)
                        && rowQualityId == bomItem.QualityId
                        && rowItemAttribute1Id == bomItem.ItemAttribute1Id
                        && rowItemAttribute2Id == bomItem.ItemAttribute2Id
                        && rowItemAttribute3Id == bomItem.ItemAttribute3Id
                        && SadeceSipariseAitKontrolEt
                        && maxCouldReadValue >= pLastQty)
                    {
                        findOrderRow = drOrder;
                        pToleranseUsed = true;
                        break;
                    }
                }
            }

            if (findOrderRow == null)
            {
                Screens.Error(string.Format("Okunan Ambalajda  Uygun Sevk Satırı Bulunamadı[QtyControl_AddItemRowData]: Stok Kodu:{0} Parti:{1} Kalite:{2} "
                    , bomItem.ItemCode, bomItem.LotCode, bomItem.QualityCode));
                return false;
            }

            masterLineNo = Convert.ToInt32(findOrderRow["LINE_NO"]);
            masterQty = Convert.ToDecimal(findOrderRow["QTY"]);
            masterReadQty = Convert.ToDecimal(findOrderRow["READ_QTY"]);
            masterFreeQty = Convert.ToDecimal(findOrderRow["QTY_FREE_PRM"]);

            if (pToleranseUsed)
                ToleranceRatio = bomItem.SalesToleranceMax;

            maxCouldReadValue = masterQty * (100M + ToleranceRatio) / 100M;

            if (maxCouldReadValue < (masterReadQty + bomItem.Qty))
            {
                Screens.Error(string.Format("Miktarı aşıyorsunuz [2] [QtyControl_AddItemRowData] Satır No:{0} İzin Verilen:{1} Girilen:{2} ", masterLineNo, maxCouldReadValue, masterReadQty + bomItem.Qty));
                return false;
            }

            findOrderRow["READ_QTY"] = masterReadQty + bomItem.Qty;
            findOrderRow["QTY_FREE_PRM"] = masterFreeQty + bomItem.QtyFreePrm;
            return true;
        }

        private void Tx_PackageNoRevort_TextChanged(object sender, EventArgs e)
        {
            Tx_PackageMId.Text = string.Empty;
            Btn_PackRelease.Enabled = false;
        }

        /// <summary>
        /// El Terminali Parametrelerinde "OKUTMA_SIRASINDA_RAF_KULLAN" seçilir ise Raf okutulacak
        /// </summary>
        private void ReadLocationUsed()
        {
            pReadLocationUsed = false;
            //Depoda raf kullanımı var ise ve Karma Palet Kullanılmıyor ise ve El Terminali Parametrelerinde "OKUTMA_SIRASINDA_RAF_KULLAN" seçilir ise Raf okutulacak.
            if (ClientApplication.Instance.SelectedDepot.IsLocationTrack && !_KarmaPaketIzinVar && ClientApplication.Instance.HandsetParam["Frm_PaletSevk", "OKUTMA_SIRASINDA_RAF_KULLAN"].ToBool())
                pReadLocationUsed = true;

            Tx_ReadLocationCode.Visible = pReadLocationUsed;
            Lbl_ReadLocationCode.Visible = pReadLocationUsed;
            Tx_ReadLocationId.Visible = pReadLocationUsed;
        }

        /// <summary>
        /// Raf Depoda tanımlı mı ?
        /// </summary>
        /// <returns></returns>
        private Boolean RafKontrol()
        {
            ServiceRequestOfItemSelectParam _paramLocControl = new ServiceRequestOfItemSelectParam();
            _paramLocControl.Token = new Token();
            _paramLocControl.Token = ClientApplication.Instance.UTermToken;
            _paramLocControl.Value = new ItemSelectParam();
            _paramLocControl.Value.Barkod = Tx_ReadLocationCode.Text.ToString();
            _paramLocControl.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
            pRafKontrolReturn = ClientApplication.Instance.UTermService.GetLocationInfo(_paramLocControl);
            if (pRafKontrolReturn.Result == false)
            {
                Screens.Error("Raf" + Environment.NewLine + pRafKontrolReturn.Message.ToString());
                Tx_ReadLocationCode.Focus();

                return false;
            }

            return true;
        }

        private void Tx_ReadLocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Screens.ShowWait();
                if (pReadLocationUsed && RafKontrol() == false)
                {
                    Screens.HideWait();
                    Update_ReadLocationId(0);
                    Tx_ReadLocationCode.Focus();
                    return;
                }
                Update_ReadLocationId(pRafKontrolReturn.Value.Id);
                Tx_Barcode.Focus();
                Screens.HideWait();
            }
        }

        private void Update_ReadLocationId(int xReadLocationId)
        {
            pReadLocationId = xReadLocationId;
            Tx_ReadLocationId.Text = xReadLocationId.ToString();

            if (xReadLocationId == 0)
            {
                Tx_ReadLocationCode.Text = string.Empty;
                Tx_ReadLocationId.Text = string.Empty;
            }
        }
        /// <summary>
        /// test et....
        /// 
        /// </summary>
        private void ActionTest()
        {
            if (ClientApplication.Instance.Token.UserName == "kemal.ozkan")
            {
                #region test end.
                //TxOrderNo.Text = ("SE-33972").ToString(); //ENTES
                TxOrderNo.Text = ("SE-33972").ToString(); ////ENTES
                ClientApplication.Instance.UTermService.Timeout = -1;
                ServiceRequestOfSelectParam _SParam = new ServiceRequestOfSelectParam();
                _SParam.Token = ClientApplication.Instance.UTermToken;
                _SParam.Value = new SelectParam();
                _SParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                _SParam.Value.IsItemPicking = 0;
                _SParam.Value.SearchEntity = TxOrderNo.Text;

                ServiceResultOfListOfReferralInfo _RefInfo = ClientApplication.Instance.UTermService.GetReferralOrders(_SParam);
                if (_RefInfo.Result && _RefInfo.Value.Length > 0)
                {
                    string[] OrderIds = new string[1] { _RefInfo.Value[0].Id.ToString() };
                    this.ReferralOrderCodes = new string[1] { _RefInfo.Value[0].DocNo };
                    this.TxTransporterDesc.Text = _RefInfo.Value[0].TransporterDesc; /*Nakliye Şekli Adı*/
                    TxOrderNo.Text = _RefInfo.Value[0].DocNo;
                    GetReferralOrderDetails(OrderIds);

                    Tx_ReadLocationCode.Text = "MDC0701"; //ENTES 
                    //Tx_ReadLocationCode.Text = "EDH0101"; //ENTPA

                    Screens.ShowWait();
                    if (pReadLocationUsed && RafKontrol() == false)
                    {
                        Screens.HideWait();
                        Update_ReadLocationId(0);
                        Tx_ReadLocationCode.Focus();
                        return;
                    }
                    Update_ReadLocationId(pRafKontrolReturn.Value.Id);
                    Tx_Barcode.Focus();
                    Screens.HideWait();
                    //Tx_Barcode.Text = "202203170001";
                    //ProcessData(Tx_Barcode.Text);
                    //Tx_Barcode.Text = "202203170002";
                    //ProcessData(Tx_Barcode.Text);
                }
                #endregion test end.
            }
        }
    }
    /// <summary>
    /// ReadList
    /// </summary>
    public class ItemReadInfo
    {
        public int ReferralDetailId { get; set; }
        public int SourceDId { get; set; }
        public decimal ReadQty { get; set; }
    }

    public class CommonOps
    {
        /// <summary>
        /// String 'i Decimal'e çevir
        /// </summary>
        /// <param name="xQtyString"></param>
        /// <returns></returns>
        public static decimal ConvertStrToDec(string xQtyString)
        {
            decimal pReturnQty = 0m;
            string pdeger = string.Empty;
            try
            {
                pReturnQty = decimal.Parse(xQtyString);
            }
            catch (Exception ex)
            {
                pdeger = ex.Message;
                pReturnQty = 0;
            }

            return pReturnQty;
        }
    }
}