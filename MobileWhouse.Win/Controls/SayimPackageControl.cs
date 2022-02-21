using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UTermConnector;
using MobileWhouse.Util;

namespace MobileWhouse.Controls
{
    public partial class SayimPackageControl : BaseControl
    {
        public SayimPackageControl()
        {
            InitializeComponent();
        }

        DataTable Dt = new DataTable();
        int _LineNo = 0;

        int pKaynakRafId = 0;
        string pKaynakRafCode = string.Empty;

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Btn_Save.Enabled = false;
            try
            {
                #region Belge No ve Tarih Kontrolü
                string pDocNo = Tx_DocNo.Text.ToString();
                DateTime pDocDate = DateTime.ParseExact(Dt_DocDate.Text, "dd.MM.yyyy", null).Date;


                if (pDocNo == "" || pDocDate == null)
                {
                    Btn_Save.Enabled = true;
                    Screens.Error("Belge numarası girilmedi.");
                    return;
                }

                if (pDocDate == null)
                {
                    Btn_Save.Enabled = true;
                    Screens.Error("Belge tarihi girilmedi.");
                    return;
                }
                #endregion Belge No Version Tarih Kontrolü
                List<PackageCycleCountDParam> pPackageCycleDInList = new List<PackageCycleCountDParam>();

                foreach (DataRow DRow in Dt.Rows)
                {
                    PackageCycleCountDParam pPackageCycleD = new PackageCycleCountDParam();
                    pPackageCycleD.BwhLocationId = Int32.Parse(DRow["LOCATION_ID"].ToString());
                    pPackageCycleD.PackageNo = DRow["PACKAGE_NO"].ToString();
                    pPackageCycleDInList.Add(pPackageCycleD);
                }

                ServiceRequestOfPackageCycleCountMParam _Param = new ServiceRequestOfPackageCycleCountMParam();
                _Param.Token = new Token();
                _Param.Token = ClientApplication.Instance.UTermToken;
                _Param.Value = new PackageCycleCountMParam();
                _Param.Value.DocDate = pDocDate;
                _Param.Value.DocNo = pDocNo;
                _Param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                _Param.Value.PackageCycleCountlist = pPackageCycleDInList.ToArray();
                ServiceResultOfInt32 _Gelen = ClientApplication.Instance.UTermService.CreatePackageCycleCountM(_Param);
                if (_Gelen.Result == true)
                {
                    Btn_Save.Enabled = true;
                    Screens.Info("İşlem tamamlandı.");
                    ClearValues();
                }
                else
                {
                    Btn_Save.Enabled = true;
                    Screens.Error(_Gelen.Message.ToString());
                    return;
                }
            }
            catch (SystemException ex)
            {
                Btn_Save.Enabled = true;
                Screens.Error(String.Format("Genel hata \n Erp Hata: {0}", ex.Message.ToString()));
            }
            Btn_Save.Enabled = true;
        }

        private void tx_LocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocationControl();
            }
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            if (Screens.Question("Çıkmak İstediğinizden Emin Misiniz ?"))
            {
                MainForm.ShowControl(new SelectSayimType());
            }
        }

        private void SayimPackageControl_OnLoad(object sender, EventArgs e)
        {
            try
            {
                Dt.TableName = "TableDetay";
                CreateDtColumns(Dt); // Detay Grid Sutun Oluştur
                SetGridColumns();
            }
            catch (Exception EX)
            {

                Screens.Error("Hata : " + EX.Message);
            }
            Tx_Barcode.KeyDown += new KeyEventHandler(Tx_Barcode_KeyDown);

            Dt_DocDate.Format = DateTimePickerFormat.Custom;
            Dt_DocDate.CustomFormat = "dd.MM.yyyy";

            ClearValues();
        }

        private DataGridTableStyle LoadTableStyle(string xMappingName)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = xMappingName;

            int pRafNoWidth = -1;
            int pPackageNoWidth = Convert.ToInt32(dataGrid1.Width * 0.80);

            if (1 == 1)//(Data._SelectedWareHouseControlLocation) //Rafı kontrol et işaretli ise göster
            {
                pRafNoWidth = Convert.ToInt32(dataGrid1.Width * 0.30);
                pPackageNoWidth = Convert.ToInt32(dataGrid1.Width * 0.50);
            }


            NewGridColumn(ts, "LINE_NO", "Sıra No", Convert.ToInt32(dataGrid1.Width * 0.20));
            NewGridColumn(ts, "LOCATION_ID", "", -1);
            NewGridColumn(ts, "LOCATION_CODE", "Raf Kodu", pRafNoWidth);
            NewGridColumn(ts, "PACKAGE_NO", "Ambalaj No", pPackageNoWidth);

            return ts;
        }
        private static void NewGridColumn(DataGridTableStyle ts, string xMappingName, string xHeaderText, int xWidth)
        {
            DataGridColumnStyle Col1 = new DataGridTextBoxColumn();
            Col1.MappingName = xMappingName;
            Col1.HeaderText = xHeaderText;
            Col1.Width = xWidth;
            ts.GridColumnStyles.Add(Col1);
        }

        private void Tx_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
            }
            else
            {
                Screens.ShowWait();
                ProcessData(Tx_Barcode.Text);
                Screens.HideWait();
            }
        }
        void ProcessData(string _xCode)
        {
            ProccesDataBarcode(_xCode);
        }
        void ProccesDataBarcode(string _xCode)
        {
            if (1 == 1)//(Data._SelectedWareHouseControlLocation)
            {
                LocationControl();
            }

            //GetPackageCycleCountD Eğer Ambalaj Okutulmuşmu diye kontroleetmek isterler ise kullnırsın

            if (string.IsNullOrEmpty(_xCode))
            {
                MessageBox.Show("Ambalaj Giriniz");
                Tx_Barcode.Focus();
                return;
            }

            if (Chk_Delete.CheckState == CheckState.Unchecked) // Gride Ekle
            {
                ServiceRequestOfInGetPacKageM _InGetPacKageM = new ServiceRequestOfInGetPacKageM();
                _InGetPacKageM.Token = new Token();
                _InGetPacKageM.Token = ClientApplication.Instance.UTermToken;
                _InGetPacKageM.Value = new InGetPacKageM();
                _InGetPacKageM.Value.PackageNo = _xCode;
                _InGetPacKageM.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                ServiceResultOfBoolean _PackageMControl = ClientApplication.Instance.UTermService.GetPackageMControl(_InGetPacKageM);
                if (_PackageMControl.Result == false && !string.IsNullOrEmpty(_PackageMControl.Message))
                {
                    Screens.Error(_PackageMControl.Message.ToString());
                    return;
                }
                if (_PackageMControl.Result == false)
                {
                    Screens.Error(string.Format("İşyerinizde Ambalaj Tanımınız Bulunamadı [GetPackageMControl-1] \n Ambalaj No :{0}", _xCode));
                    return;
                }
                #region Okutulan Barkod Daha Önce Okutuldumu ?
                DataRow[] drs = Dt.Select(string.Concat(" PACKAGE_NO = '", _xCode, "' "));
                if (drs != null && drs.Length > 0)
                {
                    Screens.Error(String.Format("Bu Barkod [{0}] Daha Önce Okutuldu.", _xCode));
                    Tx_Barcode.Text = "";
                    Tx_Barcode.Focus();
                    return;
                }
                //var DataTableEnums = Dt.AsEnumerable();
                //var names = from emp in DataTableEnums
                //            select emp.Field<String>(Dt.Columns["PACKAGE_NO"]);
                //int pcount = names.Where(p => p == _xCode).Count();
                //if (pcount > 0)
                //{
                //    Screens.Error(String.Format("Bu Barkod [{0}] Daha Önce Okutuldu.", _xCode));
                //    Tx_Barcode.Text = "";
                //    Tx_Barcode.Focus();
                //    return;
                //}

                #endregion Okutulan Barkod Daha Önce Okutuldumu ?
                #region Grid'e satır ekle
                CreateNewDataRow(pKaynakRafId,
                                 pKaynakRafCode,
                                 _xCode);
                #endregion Grid'e satır ekle
            }
            else // Gridden Çıkart
            {
                #region Detaydan okutulan barkodu silme
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i]["PACKAGE_NO"].ToString() == _xCode)
                    {
                        Dt.Rows[i].Delete();
                        break;
                    }
                }
                #endregion datatable'dan çıkart
            }

            Tx_Barcode.Text = "";
            Tx_Barcode.Focus();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            Dt.DefaultView.Sort = "LINE_NO DESC";
            dataGrid1.DataSource = Dt;
            dataGrid1.Refresh();
        }

        private void ClearValues()
        {
            Tx_Barcode.Text = string.Empty;
            tx_LocationCode.Text = string.Empty;
            _LineNo = 0;
            Dt.Clear();
            RefreshGrid();
            Dt_DocDate.Text = DateTime.Now.Date.ToString();
            Tx_DocNo.Text = Dt_DocDate.Text.Replace(".", "") + " Sayımı";

            if (1 != 1)//(Data._SelectedWareHouseControlLocation == false)
            {
                tx_LocationCode.Hide();
                tx_Location_Label.Hide();
            }
            else
            {
                tx_LocationCode.Show();
                tx_Location_Label.Show();
            }
        }

        private void LocationControl()
        {
            pKaynakRafId = 0;
            pKaynakRafCode = string.Empty;

            if (!string.IsNullOrEmpty(tx_LocationCode.Text.ToString()))
            {
                ServiceRequestOfItemSelectParam _Sp = new ServiceRequestOfItemSelectParam();
                _Sp.Token = new Token();
                _Sp.Token = ClientApplication.Instance.UTermToken;
                _Sp.Value = new ItemSelectParam();
                _Sp.Value.Barkod = tx_LocationCode.Text.ToString();
                _Sp.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                ServiceResultOfNameIdItem _ResKaynak = ClientApplication.Instance.UTermService.GetLocationInfo(_Sp);
                if (_ResKaynak.Result == false)
                {
                    Screens.Error(String.Format(@"Raf Kodu : {0}
                                                    Hata     : {1}", tx_LocationCode.Text
                                                                   , _ResKaynak.Message.ToString()));
                    tx_LocationCode.Text = string.Empty;
                    tx_LocationCode.Focus();
                    return;
                }
                pKaynakRafId = _ResKaynak.Value.Id;
                pKaynakRafCode = _ResKaynak.Value.Name;
            }
            Tx_Barcode.Focus();
        }

        private void CreateNewDataRow(int xLocId, string xLocCode, string xPackageNo)
        {
            _LineNo++;
            DataRow Dr = Dt.NewRow();
            Dr["LINE_NO"] = _LineNo;
            Dr["LOCATION_ID"] = xLocId;
            Dr["LOCATION_CODE"] = xLocCode;
            Dr["PACKAGE_NO"] = xPackageNo;
            Dt.Rows.Add(Dr);
        }

        private void CreateDtColumns(DataTable xDataTable)
        {
            xDataTable.Columns.Add("LINE_NO", Type.GetType("System.Int32"));
            xDataTable.Columns.Add("LOCATION_ID", Type.GetType("System.Int32"));
            xDataTable.Columns.Add("LOCATION_CODE", Type.GetType("System.String"));
            xDataTable.Columns.Add("PACKAGE_NO", Type.GetType("System.String"));
        }
        private void SetGridColumns()
        {
            try
            {
                dataGrid1.TableStyles.Clear();
                dataGrid1.TableStyles.Add(LoadTableStyle("TableDetay"));
            }
            catch (SystemException ex)
            {
                Screens.Error(String.Format("Hata \n {0}", ex.Message));
            }
        }
    }
}
