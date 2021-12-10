using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Util;

namespace MobileWhouse.Controls
{
    public partial class DepoTransferControl : BaseControl
    {
        private Depot _TargetDepot;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;
        private bool FirstLoad;
        private int StokHareketMId;

        public DepoTransferControl()
        {
            InitializeComponent();
            txtItemCode.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        public DepoTransferControl(Depot target)
        {
            try
            {
                InitializeComponent();
                _TargetDepot = target;
                lblTargetDepo.Text = target.Name;
                lblDepo.Text = ClientApplication.Instance.SelectedDepot.Name;
                txtItemCode.DepoId = ClientApplication.Instance.SelectedDepot.Id;

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

            ServiceResultOfStokHareketM serResOfStokHareketM = ClientApplication.Instance.Service.DepoTransferIlkYukleme(serReqOfUserDepoId);

            if (!serResOfStokHareketM.Result)
                return;

            FirstLoad = false;
            StokHareketMId = serResOfStokHareketM.Value.Id;

            dtDocDate.Value = serResOfStokHareketM.Value.DocDate;
            for (int i = 0; i < serResOfStokHareketM.Value.StokHareketDetayList.Length; i++)
            {
                StokHareketD stokHareketD = serResOfStokHareketM.Value.StokHareketDetayList[i];

                ListViewItem listViewItem = new ListViewItem();

                listViewItem.Text = stokHareketD.ItemCode;
                listViewItem.SubItems.Add(stokHareketD.QtyPrm.ToString());
                listViewItem.Tag = stokHareketD;

                lstDetails.Items.Add(listViewItem);
            }
        }

        private static void _SetItemDetails(StokHareketD detay, ListViewItem item)
        {
            item.SubItems.Clear();
            item.Text = detay.ItemCode;
            item.SubItems.Add(detay.QtyPrm.ToString());
            item.Tag = detay;
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
                    MobileWhouse.Util.Screens.Info("Stok seçiniz");
                    return;
                }
                decimal miktar = 0;

                miktar = txtMiktar.Value * _SelectedItem.StokMultiplier;
                if (miktar <= 0)
                {
                    throw new Exception("Miktar 0 yada negatif olamaz");
                }

                ListViewItem lstItem = null;
                StokHareketD detay = null;


                for (int i = 0; i < lstDetails.Items.Count; i++)
                {
                    StokHareketD detail = lstDetails.Items[i].Tag as StokHareketD;

                    if (detail.ItemId == _SelectedItem.Id)
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
                    detay = new StokHareketD();
                    detay.QtyPrm = miktar;
                    detay.ItemCode = _SelectedItem.Description;
                    detay.ItemId = _SelectedItem.Id;
                    detay.UnitId = item.UnitId;
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
                    ServiceRequestOfStokHareketM stokM = new ServiceRequestOfStokHareketM();
                    stokM.Token = ClientApplication.Instance.Token;
                    stokM.Value = new StokHareketM();
                    stokM.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    stokM.Value.Whouse2Id = _TargetDepot.Id;
                    stokM.Value.DocDate = dtDocDate.Value;
                    stokM.Value.StokHareketDetay = new StokHareketD();

                    stokM.Value.StokHareketDetay.ItemId = _SelectedItem.Id;
                    stokM.Value.StokHareketDetay.UnitId = _SelectedItem.UnitId;

                    stokM.Value.StokHareketDetay.LocationId = _SelectedRaf == null ? 0 : _SelectedRaf.Id;

                    stokM.Value.StokHareketDetay.QtyPrm = ((StokHareketD)(lstItem.Tag)).QtyPrm;

                    ServiceResultOfListOfInt32 id = ClientApplication.Instance.Service.InsertDepoTransferFisiFirst(stokM);

                    if (!id.Result)
                    {
                        throw new Exception(id.Message);
                    }

                    StokHareketMId = id.Value[0];
                    StokHareketD stokHareketD = lstItem.Tag as StokHareketD;
                    stokHareketD.Id = id.Value[1];

                    FirstLoad = false;
                }
                else
                {
                    StokHareketD stokHareket = (StokHareketD)(lstItem.Tag);

                    ServiceRequestOfStokHareketInfo stokInfo = new ServiceRequestOfStokHareketInfo();
                    stokInfo.Token = ClientApplication.Instance.Token;
                    stokInfo.Value = new StokHareketInfo();
                    stokInfo.Value.StokHareketDetail = stokHareket;
                    stokInfo.Value.StokHareketMId = StokHareketMId;
                    stokInfo.Value.StokHareketDetail.UnitId = stokHareket.UnitId;

                    stokInfo.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    stokInfo.Value.Whouse2Id = _TargetDepot.Id;

                    ServiceResultOfInt32 id = ClientApplication.Instance.Service.InsertDepoTransferFisiDevam(stokInfo);

                    if (!id.Result)
                    {
                        throw new Exception(id.Message);
                    }

                    stokHareket.Id = id.Value;
                }

                _SelectedItem = null;
                txtItemCode.Text = string.Empty;
                txtItemCode.Focus();
                txtMiktar.Text = "1";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Screens.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (StokHareketMId == 0)
            {
                Screens.Error("Stok Hareketi Bulunamadı...");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32();
                param.Token = ClientApplication.Instance.Token;
                param.Value = StokHareketMId;

                ServiceResultOfBoolean result = ClientApplication.Instance.Service.DepoTransferKaydet(param);

                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }

                StokHareketMId = 0;
                FirstLoad = true;
                _SelectedItem = null;
                _SelectedRaf = null;

               // txtRaf.Text = string.Empty;
                txtItemCode.Text = string.Empty;
                txtMiktar.Text = "1";
                lstDetails.Items.Clear();
                Cursor.Current = Cursors.Default;
                MobileWhouse.Util.Screens.Info("Kayıt Yapıldı");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Screens.Error(ex);
            }
        }
    }
}
