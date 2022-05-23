using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Controls
{
    public partial class RafHareketiControl : BaseControl
    {
        public bool FirstLoad { get; set; }
        public int RafHareketMId { get; set; }
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf1;
        private NameIdItem _SelectedRaf2;
        private DocTra _SelectedDocTra;
        private Depot _Depot;

        public enum InventoryStatus
        {
            Giris = 1,
            Cikis = 2,
            Transfer = 3,
            Devir = 4
        }

        public RafHareketiControl()
        {
            InitializeComponent();
            FirstLoad = true;

            txtStok.DepoId = txtRafCikis.DepoId = txtRafGiris.DepoId =
                ClientApplication.Instance.SelectedDepot.Id;


            dcQty.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledLocationTra;
            dcQty.Text = "1";

            ServiceRequestOfDepoHareketParam serReqOfUserDepoId = new ServiceRequestOfDepoHareketParam();
            serReqOfUserDepoId.Token = ClientApplication.Instance.Token;
            serReqOfUserDepoId.Value = new DepoHareketParam();
            serReqOfUserDepoId.Value.HedefDepoId =
            serReqOfUserDepoId.Value.DepoId = ClientApplication.Instance.SelectedDepot.Id;

            ServiceResultOfRafHareketM serResOfRafHareketM = ClientApplication.Instance.Service.RafHareketIlkYukleme(serReqOfUserDepoId);

            if (!serResOfRafHareketM.Result)
                return;

            FirstLoad = false;
            RafHareketMId = serResOfRafHareketM.Value.Id;
            _SelectedDocTra = new DocTra();


            txtHareketKod.Text = serResOfRafHareketM.Value.DocTra.DocTraCode;
            dteDocDate.Text = serResOfRafHareketM.Value.DocDate.Date.ToShortDateString();

            txtRafCikis.Enabled = true;
            txtRafGiris.Enabled = true;

            if (serResOfRafHareketM.Value.DocTra.Status == (int)InventoryStatus.Giris)
            {
                txtRafCikis.Enabled = false;
            }

            if (serResOfRafHareketM.Value.DocTra.Status == (int)InventoryStatus.Cikis)
            {
                txtRafGiris.Enabled = false;
            }

            for (int i = 0; i < serResOfRafHareketM.Value.RafHareketDetayList.Length; i++)
            {
                RafHareketD rafHareketD = serResOfRafHareketM.Value.RafHareketDetayList[i];

                ListViewItem listViewItem = new ListViewItem();

                listViewItem.Text = rafHareketD.ItemCode;
                listViewItem.SubItems.Add(rafHareketD.QtyPrm.ToString());
                listViewItem.Tag = rafHareketD;

                lstDetails.Items.Add(listViewItem);
            }

            //txtHareketKod.Enabled = false;
        }


        private void txtHareketKod_KeyDown(object sender, KeyEventArgs e)
        {
            if (!txtHareketKod.Enabled)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                FormSelectHareketKod docTraForm = new FormSelectHareketKod();
                if (docTraForm.ShowDialog() == DialogResult.OK && docTraForm.Selected != null)
                {
                    txtHareketKod.Text = docTraForm.Selected.DocTraCode;
                    _SelectedDocTra = docTraForm.Selected;

                    if (_SelectedDocTra.Status == (int)InventoryStatus.Giris || _SelectedDocTra.Status == (int)InventoryStatus.Devir)
                    {
                        txtRafGiris.Enabled = true;
                        txtRafCikis.Enabled = false;
                    }
                    else
                        if (_SelectedDocTra.Status == (int)InventoryStatus.Cikis)
                        {
                            txtRafGiris.Enabled = false;
                            txtRafCikis.Enabled = true;
                        }
                        else
                            if (_SelectedDocTra.Status == (int)InventoryStatus.Transfer)
                            {
                                txtRafGiris.Enabled = true;
                                txtRafCikis.Enabled = true;
                            }
                }
            }
        }

        private void txtWhouseCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormSelectDepot depotForm = new FormSelectDepot();
                if (depotForm.ShowDialog() == DialogResult.OK && depotForm.Selected != null)
                {
                    _Depot = depotForm.Selected;
                }
            }
        }

        private static void _SetItemDetails(RafHareketD detay, ListViewItem item)
        {
            item.SubItems.Clear();
            item.Text = detay.ItemCode;
            item.SubItems.Add(detay.QtyPrm.ToString());
            item.Tag = detay;
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            base.OnRafBarkod(raf);
            //_SelectedRaf1 = null;
            //_SelectedRaf2 = null;

            if (txtRafGiris.Focused)
            {
                _SelectedRaf2 = raf;
                txtRafGiris.Text = raf.Name;
            }
            else
                if (txtRafCikis.Focused)
                {
                    _SelectedRaf1 = raf;
                    txtRafCikis.Text = raf.Name;
                }
                else
                {
                    if (txtRafGiris.Enabled)
                    {
                        _SelectedRaf2 = raf;
                        txtRafGiris.Text = raf.Name;
                    }
                    else
                        if (txtRafCikis.Enabled)
                        {
                            _SelectedRaf1 = raf;
                            txtRafCikis.Text = raf.Name;
                        }
                }
            txtStok.Focus();
        }

        public override void OnItemBarkod(MobileWhouse.UyumConnector.ItemInfo item)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                base.OnItemBarkod(item);
                _SelectedItem = item;

                if (_SelectedDocTra == null)
                {
                    MobileWhouse.Util.Screens.Error("Hareket kodu seçiniz");
                    return;
                }
                if (_SelectedItem == null)
                {
                    MobileWhouse.Util.Screens.Error("Stok seçiniz");
                    return;
                }
                if (_SelectedRaf1 == null && _SelectedRaf2 == null)
                {
                    MobileWhouse.Util.Screens.Error("Raf Giriniz.");
                    return;
                }
                if (txtRafCikis.Enabled && txtRafGiris.Enabled && (_SelectedRaf1 == null || _SelectedRaf2 == null))
                {
                    MobileWhouse.Util.Screens.Error("Raf Giriniz.");
                    Cursor.Current = Cursors.Default;
                    //throw new Exception("Raf giriniz.");
                    return;
                }
                decimal miktar = 0;

                miktar = dcQty.Value * _SelectedItem.StokMultiplier;
                if (miktar <= 0)
                {
                    throw new Exception("Miktar 0 yada negatif olamaz");
                }

                ListViewItem lstItem = null;
                RafHareketD detay = null;
                string rafName = string.Empty;
                string rafName2 = string.Empty;
                int rafId = 0;
                int raf2Id = 0;
                if (_SelectedRaf1 != null)
                {
                    rafId = _SelectedRaf1.Id;
                    rafName = _SelectedRaf1.Name;
                }
                if (_SelectedRaf2 != null)
                {
                    raf2Id = _SelectedRaf2.Id;
                    rafName2 = _SelectedRaf2.Name;
                }
                if (rafId == 0)
                {
                    rafId = raf2Id;
                    rafName = rafName2;
                    raf2Id = 0;
                    rafName2 = string.Empty;
                }
                for (int i = 0; i < lstDetails.Items.Count; i++)
                {
                    RafHareketD detail = lstDetails.Items[i].Tag as RafHareketD;

                    if (detail.LocationId == rafId && detail.LocationId2 == raf2Id && detail.ItemId == _SelectedItem.Id)
                    {
                        lstItem = lstDetails.Items[i];
                        detay = detail;
                        break;
                    }
                }
                if (detay != null)
                {
                    if (chkSil.Checked)
                    {
                        if (miktar > detay.QtyPrm)
                        {
                            throw new Exception("Varolandan daha fazla urun siliyorsunuz");
                        }

                        detay.QtyPrm -= miktar;
                    }
                    else
                    {
                        detay.QtyPrm += miktar;
                    }
                }
                else
                {
                    if (chkSil.Checked)
                    {
                        throw new Exception("Bu stok zaten bu sayimda yok");
                    }
                    detay = new RafHareketD();
                    detay.QtyPrm = miktar;
                    detay.ItemCode = _SelectedItem.Description;
                    detay.ItemId = _SelectedItem.Id;
                    detay.UnitId = item.UnitId;

                    if (rafId != 0)
                    {
                        detay.LocationCode = rafName;
                        detay.LocationId = rafId;
                    }
                    if (raf2Id != 0)
                    {
                        detay.LocationId2 = raf2Id;
                    }


                }
                if (lstItem == null)
                {
                    lstItem = new ListViewItem();
                    _SetItemDetails(detay, lstItem);
                    lstDetails.Items.Insert(0, lstItem);
                }
                else
                {
                    if (detay.QtyPrm == 0)
                        lstDetails.Items.Remove(lstItem);
                    else
                        _SetItemDetails(detay, lstItem);
                }


                if (FirstLoad)
                {
                    ServiceRequestOfRafHareketM rafM = new ServiceRequestOfRafHareketM();
                    rafM.Token = ClientApplication.Instance.Token;
                    rafM.Value = new RafHareketM();
                    rafM.Value.Whouse2Id =
                    rafM.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    rafM.Value.DocDate = dteDocDate.Value;
                    rafM.Value.RafHareketDetay = new RafHareketD();

                    rafM.Value.RafHareketDetay.ItemId = _SelectedItem.Id;
                    rafM.Value.RafHareketDetay.UnitId = _SelectedItem.UnitId;
                    rafM.Value.DocTra = _SelectedDocTra;


                    rafM.Value.RafHareketDetay.LocationId = rafId;

                    if (_SelectedRaf1 != null && _SelectedRaf2 != null)
                    {
                        rafM.Value.RafHareketDetay.LocationId2 = _SelectedRaf2.Id;
                    }

                    rafM.Value.RafHareketDetay.QtyPrm = ((RafHareketD)(lstItem.Tag)).QtyPrm;

                    ServiceResultOfListOfInt32 id = ClientApplication.Instance.Service.InsertRafHareketFisiFirst(rafM);

                    if (!id.Result)
                    {
                        throw new Exception(id.Message);
                    }

                    RafHareketMId = id.Value[0];
                    RafHareketD rafHareketD = lstItem.Tag as RafHareketD;
                    rafHareketD.Id = id.Value[1];

                    FirstLoad = false;
                }
                else
                {
                    RafHareketD rafHareket = (RafHareketD)(lstItem.Tag);

                    ServiceRequestOfRafHareketInfo rafInfo = new ServiceRequestOfRafHareketInfo();
                    rafInfo.Token = ClientApplication.Instance.Token;
                    rafInfo.Value = new RafHareketInfo();
                    rafInfo.Value.RafHareketDetail = rafHareket;
                    rafInfo.Value.RafHareketMId = RafHareketMId;
                    rafInfo.Value.RafHareketDetail.UnitId = rafHareket.UnitId;

                    rafInfo.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;

                    ServiceResultOfInt32 id = ClientApplication.Instance.Service.InsertRafHareketFisiDevam(rafInfo);

                    if (!id.Result)
                    {
                        throw new Exception(id.Message);
                    }

                    rafHareket.Id = id.Value;
                }

                _SelectedItem = null;
                txtStok.Text = string.Empty;
                txtStok.Focus();
                dcQty.Text = "1";

                if (lstDetails.Items.Count > 0)
                {
                    txtHareketKod.Enabled = false;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RafHareketMId == 0)
            {
                MobileWhouse.Util.Screens.Error("Raf Hareketi Bulunamadı...");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32();
                param.Token = ClientApplication.Instance.Token;
                param.Value = RafHareketMId;

                ServiceResultOfBoolean result = ClientApplication.Instance.Service.RafHareketKaydet(param);

                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }

                RafHareketMId = 0;
                FirstLoad = true;
                _SelectedItem = null;
                _SelectedRaf1 = null;
                _SelectedRaf2 = null;
                _SelectedDocTra = null;

                txtHareketKod.Text = string.Empty;
                txtRafCikis.Text = string.Empty;
                txtRafGiris.Text = string.Empty;
                txtStok.Text = string.Empty;
                dcQty.Text = "1";
                lstDetails.Items.Clear();
                txtHareketKod.Enabled = true;
                Cursor.Current = Cursors.Default;
                MobileWhouse.Util.Screens.Info("Kayıt Yapıldı");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnhareket_Click(object sender, EventArgs e)
        {
            txtHareketKod_KeyDown(txtHareketKod, new KeyEventArgs(Keys.Enter));
        }
    }
}
