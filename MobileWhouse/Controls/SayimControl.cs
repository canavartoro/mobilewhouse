using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Controls
{
    public partial class SayimControl : BaseControl
    {
        private RafSayimFisi _Fis;
        private List<RafSayimDetay> _Details;
        private ItemInfo _SelectedItem;
        private NameIdItem _SelectedRaf;

        //public RafSayimDetay SelectedDetail
        //{
        //    get
        //    {
        //        return _SelectedDetail;
        //    }
        //    set
        //    {
        //        if (_SelectedDetail == value)
        //            return;
        //        _SelectedDetail = value;
        //        if (_SelectedDetail == null)
        //        {
        //            btnDuzelt.Enabled = false;
        //            btnEkle.Enabled = true;
        //        }
        //        else
        //        {
        //            btnDuzelt.Enabled = true;
        //            btnEkle.Enabled = false;
        //            txtMiktar.Enabled = true;
        //            txtMiktar.Focus();
        //            txtItemCode.Text = _SelectedDetail.ItemCode;
        //            txtItemCode.Enabled = false;
        //            txtRaf.Text = _SelectedDetail.LocationCode;
        //            txtRaf.Enabled = false;
        //            _SelectedItem = new ItemInfo();
        //            _SelectedItem.Id = _SelectedDetail.ItemId;
        //            _SelectedItem.Name = _SelectedDetail.ItemCode;

        //            _SelectedRaf = new NameIdItem();
        //            _SelectedRaf.Id = _SelectedDetail.LocationId;
        //            _SelectedRaf.Name = _SelectedDetail.LocationCode;
        //        }
        //    }
        //}

        public SayimControl()
        {
            InitializeComponent();
            txtItemCode.DepoId = txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            //MainForm.Text = ClientApplication.Instance.SelectedDepot.Name;
        }

        public SayimControl(RafSayimFisi fis, bool loadDetails)
        {
            InitializeComponent();
            txtItemCode.DepoId = txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
            _Fis = fis;
            txtBelgeNo.Text = fis.DocNo;
            dtDocDate.Value = fis.Date;

            txtMiktar.Enabled = ClientApplication.Instance.ClientToken.IsQtyEnabledCycleCount;
            txtMiktar.Text = "1";

            if (loadDetails)
            {
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32();
                param.Token = ClientApplication.Instance.Token;
                param.Value = fis.Id;

                ServiceResultOfListOfRafSayimDetay list = ClientApplication.Instance.Service.GetRafSayimDetaylari(param);
                if (!list.Result)
                {
                    throw new Exception(list.Message);
                }
                else
                {
                    try
                    {
                        lvwItems.BeginUpdate();
                        _Details = new List<RafSayimDetay>();
                        _Details.AddRange(list.Value);
                        for (int i = 0; i < list.Value.Length; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            _SetItemDetails(list.Value[i], item);

                            lvwItems.Items.Add(item);
                        }
                    }
                    finally
                    {
                        lvwItems.EndUpdate();
                    }
                }
            }
            else
            {
                _Details = new List<RafSayimDetay>();
            }
        }

        private static void _SetItemDetails(RafSayimDetay detay, ListViewItem item)
        {
            item.SubItems.Clear();
            item.Text = detay.LocationCode;
            item.SubItems.Add(detay.ItemCode);
            item.SubItems.Add(detay.QtyPrm.ToString());
            item.Tag = detay;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            _SelectedRaf = raf;
            txtRaf.Text = raf.Name;
            txtItemCode.Focus();
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            _SelectedItem = item;
            txtItemCode.Text = item.Name;
            btnEkle_Click(this, EventArgs.Empty);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedItem == null)
                {
                    MobileWhouse.Util.Screens.Error("Stokkodu seçiniz...");
                    return;
                }
                if (_SelectedRaf == null)
                {
                    MobileWhouse.Util.Screens.Error("Raf seçiniz...");
                    return;
                }
                decimal miktar = txtMiktar.Value;
                if (miktar == 0)
                    return;
                miktar = miktar * _SelectedItem.StokMultiplier;
                if (miktar <= 0)
                {
                    throw new Exception("Miktar 0 yada negatif olamaz");
                }
                ListViewItem item = null;
                RafSayimDetay detay = null;
                for (int i = 0; i < lvwItems.Items.Count; i++)
                {
                    RafSayimDetay detail = lvwItems.Items[i].Tag as RafSayimDetay;
                    if (detail.LocationId == _SelectedRaf.Id
                        && detail.ItemId == _SelectedItem.Id)
                    {
                        item = lvwItems.Items[i];
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
                    detay = new RafSayimDetay();
                    detay.QtyPrm = miktar;
                    detay.ItemCode = _SelectedItem.Name;
                    detay.ItemId = _SelectedItem.Id;
                    detay.LocationCode = _SelectedRaf.Name;
                    detay.LocationId = _SelectedRaf.Id;
                }

                ServiceRequestOfRafSayimKayitInfo req = new ServiceRequestOfRafSayimKayitInfo();
                req.Token = ClientApplication.Instance.Token;
                req.Value = new RafSayimKayitInfo();
                req.Value.DepotId = _Fis.DepoId;
                req.Value.Detay = detay;
                req.Value.MasterId = _Fis.Id;

                ServiceResultOfBoolean result = ClientApplication.Instance.Service.SaveRafSayimDetay(req);
                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }

                if (item == null)
                {
                    item = new ListViewItem();
                    _SetItemDetails(detay, item);
                    lvwItems.Items.Insert(0, item);
                }
                else
                {
                    _SetItemDetails(detay, item);
                }

                _SelectedItem = null;
                txtItemCode.Text = string.Empty;
                txtItemCode.Focus();
                txtMiktar.Text = "1";
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                _Fis.Date = dtDocDate.Value;
                _Fis.DocNo = txtBelgeNo.Text;

                ServiceRequestOfRafSayimFisi param = new ServiceRequestOfRafSayimFisi();
                param.Token = ClientApplication.Instance.Token;
                param.Value = _Fis;

                ServiceResultOfBoolean result = ClientApplication.Instance.Service.SaveRafSayimFisi(param);
                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void chkSil_CheckStateChanged(object sender, EventArgs e)
        {
            txtItemCode.Focus();
        }
    }
}
