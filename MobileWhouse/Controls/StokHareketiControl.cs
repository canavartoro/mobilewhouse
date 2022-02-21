using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls
{
    //[UyumModule("INV001", "MobileWhouse.Controls.StokHareketiControl", "Stok Transfer")]
    public partial class StokHareketiControl : BaseControl
    {
        private Depot _TargetDepot;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private bool FirstLoad;
        private int RafHareketMId;

        public StokHareketiControl()
        {
            InitializeComponent();

            txtItemCode.DepoId = txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        public StokHareketiControl(Depot target)
        {
            try
            {
                InitializeComponent();
                _TargetDepot = target;
                lblTargetDepo.Text = target.Name;
                lblDepo.Text = ClientApplication.Instance.SelectedDepot.Name;
                txtItemCode.DepoId = txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;

                _LoadItem();
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            
        }

        private void _LoadItem()
        {
            FirstLoad = true;

            txtMiktar.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledLocationTra;
            txtMiktar.Text = "1";


            ServiceRequestOfDepoHareketParam serReqOfUserDepoId = new ServiceRequestOfDepoHareketParam();
            serReqOfUserDepoId.Token = ClientApplication.Instance.Token;
            serReqOfUserDepoId.Value = new DepoHareketParam();
            serReqOfUserDepoId.Value.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            serReqOfUserDepoId.Value.HedefDepoId = _TargetDepot.Id;

            ServiceResultOfRafHareketM serResOfRafHareketM = ClientApplication.Instance.Service.RafHareketIlkYukleme(serReqOfUserDepoId);

            if (!serResOfRafHareketM.Result)
                return;

            FirstLoad = false;
            RafHareketMId = serResOfRafHareketM.Value.Id;
            
            dtDocDate.Value = serResOfRafHareketM.Value.DocDate;
            for (int i = 0; i < serResOfRafHareketM.Value.RafHareketDetayList.Length; i++)
            {
                RafHareketD rafHareketD = serResOfRafHareketM.Value.RafHareketDetayList[i];

                ListViewItem listViewItem = new ListViewItem();

                listViewItem.Text = rafHareketD.ItemCode;
                listViewItem.SubItems.Add(rafHareketD.QtyPrm.ToString());
                listViewItem.Tag = rafHareketD;

                lstDetails.Items.Add(listViewItem);
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
            try
            {
                base.OnRafBarkod(raf);

                _SelectedRaf = raf;
                txtRaf.Text = raf.Name;
                txtItemCode.Focus();
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            
        }

        public override void OnItemBarkod(MobileWhouse.UyumConnector.ItemInfo item)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                base.OnItemBarkod(item);
                _SelectedItem = item;

                if (_SelectedItem == null)
                {
                    Cursor.Current = Cursors.Default;
                    MobileWhouse.Util.Screens.Error("Stok seçiniz");
                    return;
                }
                if (_SelectedRaf == null)
                {
                    Cursor.Current = Cursors.Default;
                    MobileWhouse.Util.Screens.Error("Raf Giriniz.");
                    return;
                }
                decimal miktar = 0;

                miktar = txtMiktar.Value * _SelectedItem.StokMultiplier;
                if (miktar <= 0)
                {
                    throw new Exception("Miktar 0 yada negatif olamaz");
                }

                ListViewItem lstItem = null;
                RafHareketD detay = null;


                for (int i = 0; i < lstDetails.Items.Count; i++)
                {
                    RafHareketD detail = lstDetails.Items[i].Tag as RafHareketD;

                    if (detail.LocationId == _SelectedRaf.Id && detail.ItemId == _SelectedItem.Id)
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
                        detay.LocationCode = _SelectedRaf.Name;
                        detay.LocationId = _SelectedRaf.Id;
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
                    rafM.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    rafM.Value.Whouse2Id = _TargetDepot.Id;
                    rafM.Value.DocDate = dtDocDate.Value;
                    rafM.Value.RafHareketDetay = new RafHareketD();

                    rafM.Value.RafHareketDetay.ItemId = _SelectedItem.Id;
                    rafM.Value.RafHareketDetay.UnitId = _SelectedItem.UnitId;

                    rafM.Value.RafHareketDetay.LocationId = _SelectedRaf == null ? 0: _SelectedRaf.Id;

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
                    rafInfo.Value.Whouse2Id = _TargetDepot.Id;

                    ServiceResultOfInt32 id = ClientApplication.Instance.Service.InsertRafHareketFisiDevam(rafInfo);

                    if (!id.Result)
                    {
                        throw new Exception(id.Message);
                    }

                    rafHareket.Id = id.Value;
                }
                Cursor.Current = Cursors.Default;
                _SelectedItem = null;
                txtItemCode.Text = string.Empty;
                txtItemCode.Focus();
                txtMiktar.Text = "1";
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
                Cursor.Current = Cursors.Default;
                RafHareketMId = 0;
                FirstLoad = true;
                _SelectedItem = null;
                _SelectedRaf = null;

                txtRaf.Text = string.Empty;
                txtItemCode.Text = string.Empty;
                txtMiktar.Text = "1";
                lstDetails.Items.Clear();

                MobileWhouse.Util.Screens.Info("Kayıt Yapıldı");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnRaf_Click(object sender, EventArgs e)
        {
            using (FormSelectRaf form = new FormSelectRaf(ClientApplication.Instance.SelectedDepot))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.Selected != null)
                    {
                        txtRaf.Text = form.Selected.Name;
                    }
                }
            }
        }
    }
}
