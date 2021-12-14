using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.UTermConnector;

namespace MobileWhouse.Controls.PSM
{
    public partial class SatinalmaMalKabulControl : BaseControl
    {
        public SatinalmaMalKabulControl()
        {
            InitializeComponent();
        }

        private string _xIrsaliyeNo = "";
        private string _xIrsaliyeSeri = "";
        private string _xIrsaliyeSira = "";
        private bool _MultiSelect = false;
        private DateTime _xIrsaliyeTarihi;
        private OrderDInfo[] _OrdList = null;

        public SatinalmaMalKabulControl(MobileWhouse.UTermConnector.OrderMInfo orderm)
        {
            InitializeComponent();
            _orderM = orderm;
        }

        private MobileWhouse.UTermConnector.OrderMInfo _orderM = null;

        private void getSatisDetayData()
        {
            try
            {
                Screens.ShowWait();

                listView1.BeginUpdate();
                listView1.Items.Clear();

                ServiceRequestOfOrderDParam param = new ServiceRequestOfOrderDParam();
                param.Token = ClientApplication.Instance.UTermToken;
                param.Value = new OrderDParam();
                param.Value.PurchaseSales = 1;
                param.Value.OrderMId = _orderM.Id;
                param.Value.PageSize = 500;

                ServiceResultOfListOfOrderDInfo orderDInfo = ClientApplication.Instance.UTermService.GetOrderDInfo(param);
                if (!orderDInfo.Result)
                {
                    throw new Exception(orderDInfo.Message);
                }

                _OrdList = orderDInfo.Value;
                if (_OrdList != null && _OrdList.Length > 0)
                {
                    for (int i = 0; i < orderDInfo.Value.Length; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = orderDInfo.Value[i];
                        item.Text = orderDInfo.Value[i].DcardCode;
                        item.SubItems.Add(orderDInfo.Value[i].DcardName);
                        item.SubItems.Add("0");
                        item.SubItems.Add(orderDInfo.Value[i].QtyRemaining.ToString(Statics.DECIMAL_STRING_FORMAT));
                        item.SubItems.Add(orderDInfo.Value[i].WhouseCode);
                        item.SubItems.Add(orderDInfo.Value[i].WhouseDesc);
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                listView1.EndUpdate();
                Screens.HideWait();
            }
        }

        private void SetDataToGrid()
        {
            try
            {
                if (_OrdList != null && _OrdList.Length > 0)
                {
                    listView1.BeginUpdate();
                    listView1.Items.Clear();
                    for (int i = 0; i < _OrdList.Length; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = _OrdList[i];
                        item.Text = _OrdList[i].WhouseCode;
                        item.SubItems.Add(_OrdList[i].WhouseDesc);
                        item.SubItems.Add(_OrdList[i].EntityName);
                        item.SubItems.Add(_OrdList[i].DcardCode);
                        item.SubItems.Add(_OrdList[i].DcardName);
                        item.SubItems.Add(_OrdList[i].QtyShipping.ToString(Statics.DECIMAL_STRING_FORMAT));
                        item.SubItems.Add(_OrdList[i].QtyRemaining.ToString(Statics.DECIMAL_STRING_FORMAT));
                        item.SubItems.Add(_OrdList[i].Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                        listView1.Items.Add(item);
                    }
                }

                //IOrderedEnumerable<OrderDInfo> enumerable = from p in this._OrdList.Value
                //                                            orderby p.DcardId
                //                                            select p;
                //foreach (OrderDInfo info in enumerable)
                //{
                //    DataRow row = this.dataSet1.Dt_Detaylar.NewRow();
                //    row["Dty_Kod"] = info.WhouseCode;
                //    row["Dty_Adı"] = info.WhouseDesc;
                //    row["Stk_Kod"] = info.DcardCode;
                //    row["Stk_Adı"] = info.DcardName;
                //    row["Sip_Sevk_Miktarı"] = info.QtyShipping;
                //    row["Sip_Kal_Mik"] = info.QtyRemaining;
                //    row["Ok_Miktarı"] = info.Qty;
                //    row["Dty_RefNo"] = info.Id;
                //    row["DcardId"] = info.DcardId;
                //    this.dataSet1.Dt_Detaylar.Rows.Add(row);
                //}
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                listView1.EndUpdate();
            }
        }

        public override void OnItemBarkod(MobileWhouse.UyumConnector.ItemInfo item)
        {
            base.OnItemBarkod(item);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void SatinalmaMalKabulControl_OnLoad(object sender, EventArgs e)
        {
            getSatisDetayData();
        }

        private void txt_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    string strbarcode = txt_Barcode.Text;
                    int _itemIdMan = 0;
                    ServiceRequestOfItemSelectParam param = new ServiceRequestOfItemSelectParam();
                    param.Token = ClientApplication.Instance.UTermToken;
                    param.Value = new ItemSelectParam();
                    param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                    param.Value.Barkod = strbarcode;
                    ServiceResultOfItemInfo info = ClientApplication.Instance.UTermService.GetItemInfo(param);
                    if (!info.Result)
                    {
                        ServiceRequestOfString _ItemPrm = new ServiceRequestOfString();
                        _ItemPrm.Token = ClientApplication.Instance.UTermToken;
                        _ItemPrm.Value = strbarcode;
                        ServiceResultOfInt32 num = ClientApplication.Instance.UTermService.GetItemIdUseItemCode(_ItemPrm);
                        if (!num.Result)
                        {
                            MessageBox.Show(num.Message);
                            return;
                        }
                        _itemIdMan = num.Value;
                    }
                    else
                    {
                        _itemIdMan = info.Value.Id;
                    }
                    decimal num2 = (decimal)this.textBox1.DoubleValue * ((this.Chk_Delete.CheckState == CheckState.Checked) ? -1 : 1);
                    decimal num3 = 0M;
                    decimal num4 = 0M;
                    foreach (OrderDInfo info2 in this._OrdList)
                    {
                        if (info2.DcardId == _itemIdMan)
                        {
                            num3 += info2.QtyRemaining;
                            num4 += info2.Qty;
                        }
                    }
                    if (num2 > 0M)
                    {
                        goto Label_029B;
                    }
                    if (decimal.Parse(num4.ToString()) == 0M)
                    {
                        Screens.Error("Silinecek Kayıt Bulunamadı");
                        return;
                    }
                    if (decimal.Parse(num4.ToString()) < (num2 * -1M))
                    {
                        Screens.Error("Fazla Adet Girildi");
                        return;
                    }
                    num2 *= -1M;
                Label_01DA:
                    IEnumerable<OrderDInfo> enumerable = this._OrdList.Where(p => p.DcardId == _itemIdMan);
                    foreach (OrderDInfo info3 in enumerable)
                    {
                        if (info3.Qty >= num2)
                        {
                            info3.Qty -= num2;
                        }
                        else
                        {
                            num2 -= info3.Qty;
                            info3.Qty = 0M;
                            goto Label_01DA;
                        }
                    }
                    this.SetDataToGrid();
                    return;
                Label_029B:
                    IEnumerable<OrderDInfo> enumerable2 = this._OrdList.Where(p => p.DcardId == _itemIdMan);
                    foreach (OrderDInfo info3 in enumerable2)
                    {
                        if ((info3.DcardId == _itemIdMan) && (info3.Qty < info3.QtyRemaining))
                        {
                            if ((info3.Qty + num2) > info3.QtyRemaining)
                            {
                                num2 -= info3.QtyRemaining - info3.Qty;
                                info3.Qty += info3.QtyRemaining - info3.Qty;
                                goto Label_029B;
                            }
                            info3.Qty += num2;
                            break;
                        }
                    }
                    this.SetDataToGrid();
                }
                catch (Exception ex)
                {
                    Screens.Error(ex);
                }
                finally
                {
                    txt_Barcode.Text = string.Empty;
                    txt_Barcode.Focus();
                }
            }
        }

        private void btn_IrsaliyeOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                string str2 = "";
                bool flag = false;
                foreach (OrderDInfo row in _OrdList)
                {
                    if (row.Qty > 0)
                    {
                        flag = true;
                        break;
                    }
                }
                //foreach (DataRow row in this.dataSet1.Dt_Detaylar.Rows)
                //{
                //    if (int.Parse(row["Ok_Miktarı"].ToString()) > 0)
                //    {
                //        flag = true;
                //        break;
                //    }
                //}
                if (!flag)
                {
                    Screens.Error("Okuma Yoktur İrsaliye Oluşturulamaz");
                    return;
                }
                else
                {
                    this._xIrsaliyeTarihi = this.Dt_IrsaliyeTarihi.Value.Date;
                    this._xIrsaliyeSira = this.Tx_IrsaliyeSira.Text.ToString();
                    this._xIrsaliyeSeri = this.Tx_IrsaliyeSeri.Text.ToString();
                    this._xIrsaliyeNo = this.Tx_IrsaliyeNo.Text.ToString();

                    if (this._xIrsaliyeSira == null)
                    {
                        this._xIrsaliyeSira = "";
                    }
                    if (this._xIrsaliyeNo == null)
                    {
                        this._xIrsaliyeNo = "";
                    }
                    if (!this._MultiSelect)
                    {
                        str = this.Tx_IrsaliyeSeri.Text.ToString();
                        str2 = this.Tx_IrsaliyeSira.Text.ToString();
                    }

                    Screens.ShowWait();

                    ServiceRequestOfCoDocTraInSelectTemp param = new ServiceRequestOfCoDocTraInSelectTemp();
                    param.Token = ClientApplication.Instance.UTermToken;
                    param.Value = new CoDocTraInSelectTemp();
                    param.Value.SourceOrderDocTraId = _orderM.DocTraId; //int.Parse(this._r["DocTraId"].ToString());
                    param.Value.SourceAppLication = 0x66;
                    param.Value.SourceAppLication2 = 0x3e8;
                    ServiceResultOfInt32 coDocTraTemp = ClientApplication.Instance.UTermService.GetCoDocTraTemp(param);
                    if (!coDocTraTemp.Result)
                    {
                        throw new Exception(string.Format("Satınmalma Sipariş Hareket Koduna Ait İrsaliye Hareket Kodu Bulunamadı\n Stn.Sip.Hareket Ref.No:{0}", param.Value.SourceOrderDocTraId));
                    }
                    ServiceRequestOfWaybillInfo context = new ServiceRequestOfWaybillInfo();
                    context.Token = ClientApplication.Instance.UTermToken;
                    context.Value = new WaybillInfo();
                    context.Value.MasterId = _orderM.Id;
                    context.Value.BelgeNo = Tx_IrsaliyeNo.Text;
                    context.Value.Date = Convert.ToDateTime(this._xIrsaliyeTarihi);
                    context.Value.DocTraId = int.Parse(coDocTraTemp.Value.ToString());
                    List<OrderDetailInfo> list = new List<OrderDetailInfo>();
                    foreach (OrderDInfo info2 in this._OrdList)
                    {
                        if (info2.Qty > 0)
                        {
                            OrderDetailInfo item = new OrderDetailInfo
                            {
                                ItemId = info2.DcardId,
                                LotId = info2.LotId,
                                PackageTypeId = info2.PackageTypeId,
                                QualityId = info2.QualityId,
                                WhouseId = ClientApplication.Instance.SelectedDepot.Id,
                                Qty = info2.Qty,
                                OrderDetailId = info2.Id,
                                OrderMId = info2.MId
                            };
                            list.Add(item);
                        }
                    }
                    context.Value.OrderDetails = list.ToArray();
                    ServiceResultOfBoolean flag2 = ClientApplication.Instance.UTermService.SavePurchaseWaybill(context);
                    if (flag2.Result)
                    {
                        Screens.Info("İrsaliye Oluşturuldu");
                        Screens.HideWait();
                        MainForm.ShowControl(null);
                    }
                    else
                    {
                        Screens.Error(string.Concat("İrsaliye Oluşturulamadı ", Environment.NewLine, flag2.Message));
                    }
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Screens.HideWait();
            }
        }

       
    }
}
