using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Attributes;
using MobileWhouse.Util;
using MobileWhouse.UTermConnector;
using MobileWhouse.Dilogs;
using MobileWhouse.Models;
using MobileWhouse.Data;
using MobileWhouse.Attributes;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.PSM
{
    [UyumModule("PSM003", "MobileWhouse.Controls.PSM.CariBazindaSatinalmaControl", "SATINALMA")]
    public partial class CariBazindaSatinalmaControl : BaseControl
    {
        private MobileWhouse.UyumConnector.CoEntityInfo entityInfo = null;
        public MobileWhouse.UyumConnector.CoEntityInfo EntityInfo
        {
            get { return entityInfo; }
        }

        private OrderDInfo[] _OrdList = null;
        private List<PurchaseOrderDModel> orderdetails = null;

        public CariBazindaSatinalmaControl()
        {
            InitializeComponent();
        }

        public CariBazindaSatinalmaControl(MobileWhouse.UyumConnector.CoEntityInfo entity)
        {
            InitializeComponent();
            this.entityInfo = entity;
        }

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
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.EntityMId = entityInfo.EntityId;
                param.Value.PurchaseSales = 1;
                param.Value.PageSize = 500;

                ServiceResultOfListOfOrderDInfo orderDInfo = ClientApplication.Instance.UTermService.GetOrderDInfo(param);
                if (!orderDInfo.Result)
                {
                    throw new Exception(orderDInfo.Message);
                }

                string[] orderids = null;
                _OrdList = orderDInfo.Value;

                if (_OrdList != null && _OrdList.Length > 0)
                {
                    orderids = new string[_OrdList.Length];
                    for (int i = 0; i < orderDInfo.Value.Length; i++)
                    {
                        orderids[i] = orderDInfo.Value[i].Id.ToString();
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

                    UyumConnector.ServiceRequestOfString paramSql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                    paramSql.Token = ClientApplication.Instance.Token;
                    paramSql.Value = string.Concat(@"SELECT 
D.ORDER_M_ID ""ORDER_M_ID"",D.ORDER_D_ID ""ORDER_D_ID"",I.ITEM_CODE ""ITEM_CODE"",I.ITEM_NAME ""ITEM_NAME"",I.ITEM_ID ""ITEM_ID"",
CAST(D.QTY_PRM - (CASE WHEN D.QTY > 0 THEN ((D.QTY_PRM / D.QTY) * D.QTY_SHIPPING) ELSE 0 END) AS NUMERIC(18,5)) AS ""QTY"",U.DESCRIPTION  AS ""UNIT_DESC"",
D.LINE_TYPE ""LINE_TYPE"",D.BRANCH_ID ""BRANCH_ID"",0 AS ""QTY_READ"",U.UNIT_ID ""UNIT_ID"",CAST(M.DOC_DATE AS DATE) ""DOC_DATE"",
TO_CHAR(M.DOC_DATE, 'DD-MM-YYYY') AS ""DOC_DATE_S"",M.DOC_NO ""DOC_NO"",E.ENTITY_CODE ""ENTITY_CODE"",E.ENTITY_NAME ""ENTITY_NAME"",
E.ENTITY_ID ""ENTITY_ID"",M.DELIVERY_DATE ""DELIVERY_DATE"",CAST(D.CUR_RATE_TRA AS NUMERIC(18,5)) ""CUR_RATE_TRA"",
D.CUR_TRA_ID ""CUR_TRA_ID"",D.CUR_RATE_TYPE_ID ""CUR_RATE_TYPE_ID"",CAST(M.CUR_RATE_TRA AS NUMERIC(18,5)) AS ""CUR_RATE_TRA_M"",M.CUR_TRA_ID AS ""CUR_TRA_ID_M"",
M.CUR_RATE_TYPE_ID AS ""CUR_RATE_TYPE_ID_M"",CAST(D.UNIT_PRICE AS NUMERIC(18,5)) ""UNIT_PRICE"",D.DUE_DATE ""DUE_DATE"",D.DUE_DAY ""DUE_DAY"",
CASE WHEN BI.TOLERANCE_MAX_PO > 0 THEN BI.TOLERANCE_MAX_PO ELSE I.TOLERANCE_MAX_PO END ""TOLERANCE_MAX_PO"",D.UNIT_PRICE_TRA AS ""UNIT_PRICE_TRA"" 
FROM PSMT_ORDER_D D INNER JOIN PSMT_ORDER_M M ON M.ORDER_M_ID = D.ORDER_M_ID INNER JOIN 
FIND_ENTITY E ON M.ENTITY_ID = E.ENTITY_ID INNER JOIN 
INVD_ITEM I ON I.ITEM_ID = D.ITEM_ID INNER JOIN INVD_UNIT U ON U.UNIT_ID = I.UNIT_ID INNER JOIN 
INVD_BRANCH_ITEM BI ON BI.BRANCH_ID = ", ClientApplication.Instance.ClientToken.BranchId, @" AND BI.ITEM_ID = I.ITEM_ID
WHERE D.ORDER_D_ID IN (", string.Join(",", orderids), ")");
                    Logger.I(paramSql.Value);

                    MobileWhouse.UyumConnector.ServiceResultOfDataTable rs = ClientApplication.Instance.Service.ExecuteSQL(paramSql);
                    if (rs != null && rs.Value != null)
                    {
                        orderdetails = DataProvider.TableToList(rs.Value, typeof(PurchaseOrderDModel)) as List<PurchaseOrderDModel>;
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
                        item.Text = _OrdList[i].DcardCode;
                        item.SubItems.Add(_OrdList[i].DcardName);
                        item.SubItems.Add(_OrdList[i].Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                        item.SubItems.Add(_OrdList[i].QtyRemaining.ToString(Statics.DECIMAL_STRING_FORMAT));
                        item.SubItems.Add(_OrdList[i].WhouseCode);
                        item.SubItems.Add(_OrdList[i].WhouseDesc);
                        item.SubItems.Add(_OrdList[i].LotCode);

                        //item.Text = _OrdList[i].WhouseCode;
                        //item.SubItems.Add(_OrdList[i].WhouseDesc);
                        //item.SubItems.Add(_OrdList[i].EntityName);
                        //item.SubItems.Add(_OrdList[i].DcardCode);
                        //item.SubItems.Add(_OrdList[i].DcardName);
                        //item.SubItems.Add(_OrdList[i].QtyShipping.ToString(Statics.DECIMAL_STRING_FORMAT));
                        //item.SubItems.Add(_OrdList[i].QtyRemaining.ToString(Statics.DECIMAL_STRING_FORMAT));
                        //item.SubItems.Add(_OrdList[i].Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                        //item.SubItems.Add(_OrdList[i].LotCode);
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
            MainForm.ShowControl(new MalKabulControl());
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
                    string siparisNo = string.Empty;
                    string partiNo = string.Empty;
                    decimal qty = 0;
                    string strbarcode = txt_Barcode.Text;
                    if (strbarcode.IndexOf('|') != -1)
                    {
                        string[] barkodData = strbarcode.Split('|');
                        if (barkodData != null)
                        {
                            if (barkodData.Length > 0)
                                strbarcode = barkodData[0];
                            if (barkodData.Length > 1)
                                qty = StringUtil.ToDecimal(barkodData[1]);
                            if (barkodData.Length > 2)
                                partiNo = barkodData[2];
                            if (barkodData.Length > 3)
                                siparisNo = barkodData[3];
                        }
                    }
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
                    decimal qtyShipping = num2;
                    bool useTolerance = false;
                    List<OrderDInfo> enumerable3 = this._OrdList.Where(p => p.DcardId == _itemIdMan).ToList();
                    foreach (OrderDInfo info3 in enumerable3)
                    {
                        if ((info3.DcardId == _itemIdMan) && (info3.Qty < info3.QtyRemaining))
                        {
                            if ((info3.Qty + qtyShipping) > info3.QtyRemaining)
                            {
                                qtyShipping -= info3.QtyRemaining;
                            }
                        }
                    }
                    if (qtyShipping > 0) useTolerance = true;


                    List<OrderDInfo> enumerable2 = this._OrdList.Where(p => p.DcardId == _itemIdMan).ToList();
                    for (int i = 0; i < enumerable2.Count; i++)
                    {
                        OrderDInfo info3 = enumerable2[i];
                        PurchaseOrderDModel order = orderdetails.FirstOrDefault(x => x.ORDER_D_ID == info3.Id);

                        decimal tolerance = info3.QtyRemaining;
                        if (useTolerance)
                            tolerance = tolerance + ((tolerance * order.TOLERANCE_MAX_PO) / 100);

                        if ((info3.DcardId == _itemIdMan) && (info3.Qty < tolerance))
                        {
                            if ((info3.Qty + num2) > tolerance)
                            {
                                num2 -= tolerance - info3.Qty;
                                info3.LotCode = partiNo;
                                info3.Qty += tolerance - info3.Qty;
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

                UyumConnector.DocTra selectDoctra = lookupdoctra.SelectedObject as UyumConnector.DocTra;

                if (selectDoctra == null)
                {
                    Screens.Error("Hareket kodu seçilmelidir!");
                    return;
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
                    Screens.ShowWait();

                    MobileWhouse.UyumSave.UyumServiceRequestOfItemDef paramWaybill = new MobileWhouse.UyumSave.UyumServiceRequestOfItemDef();
                    paramWaybill.Token = new MobileWhouse.UyumSave.UyumToken();
                    paramWaybill.Token.UserName = ClientApplication.Instance.Token.UserName;
                    paramWaybill.Token.Password = ClientApplication.Instance.Token.Password;
                    paramWaybill.Value = new MobileWhouse.UyumSave.ItemDef();
                    paramWaybill.Value.CoId = ClientApplication.Instance.Token.CoId;
                    paramWaybill.Value.BranchId = ClientApplication.Instance.Token.BranchId;
                    paramWaybill.Value.DocTraId = selectDoctra.Id;//_orderM.DocTraId;
                    paramWaybill.Value.EntityId = entityInfo.EntityId;
                    paramWaybill.Value.CreateUserId = ClientApplication.Instance.ClientToken.UserId;
                    paramWaybill.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    paramWaybill.Value.WhouseId2 = ClientApplication.Instance.SelectedDepot.Id;

                    paramWaybill.Value.SourceApp = MobileWhouse.UyumSave.SourceApplication.SatınalmaSiparişi;
                    paramWaybill.Value.SourceApp2 = MobileWhouse.UyumSave.SourceApplication.SatınalmaSiparişi;
                    paramWaybill.Value.SourceApp3 = MobileWhouse.UyumSave.SourceApplication.İrsaliye;

                    paramWaybill.Value.DocDate = this.Dt_IrsaliyeTarihi.Value.Date;
                    paramWaybill.Value.ReceiptDate = this.Dt_IrsaliyeTarihi.Value.Date;
                    paramWaybill.Value.DocNo = Tx_IrsaliyeNo.Text;
                    paramWaybill.Value.IsDocDifferentCur = false;
                    //paramWaybill.Value.SourceMId = _orderM.Id;
                    paramWaybill.Value.VoucherSerial = this.Tx_IrsaliyeSeri.Text;

                    paramWaybill.Value.VoucherNo = this.Tx_IrsaliyeSeri.Text.ToString();
                    paramWaybill.Value.Note1 = "El terminalinden oluşturuldu";
                    paramWaybill.Value.InvoiceStatus = MobileWhouse.UyumSave.InvoiceStatus.İrsaliye;
                    paramWaybill.Value.IsWaybil = true;
                    int lineNo = 10;
                    List<MobileWhouse.UyumSave.ItemDetailDef> details = new List<MobileWhouse.UyumSave.ItemDetailDef>();
                    //foreach (OrderDInfo info2 in this._OrdList)
                    for (int l = 0; l < listView1.Items.Count; l++)
                    {
                        OrderDInfo info2 = listView1.Items[l].Tag as OrderDInfo;
                        if (info2.Qty > 0)
                        {
                            PurchaseOrderDModel orderd = null;
                            int i = orderdetails.FindIndex(p => p.ORDER_D_ID == info2.Id);
                            if (i >= 0)
                            {
                                orderd = orderdetails[i];
                            }

                            MobileWhouse.UyumSave.ItemDetailDef detail = new MobileWhouse.UyumSave.ItemDetailDef();
                            detail.WhouseId = info2.WhouseId;
                            detail.UnitId = info2.ItemUnitId;
                            detail.LotId = 0;
                            detail.DcardId = info2.DcardId;
                            detail.LineNo = lineNo;
                            detail.Qty = info2.Qty;
                            detail.QtyPrm = info2.Qty;
                            detail.Barcode = "";

                            detail.ItemAttribute1Id = info2.ItemAttr1Id;
                            detail.ItemAttribute2Id = info2.ItemAttr2Id;
                            detail.ItemAttribute3Id = info2.ItemAttr3Id;
                            detail.QualityId = info2.QualityId;
                            detail.LotId = info2.LotId;
                            detail.ColorId = info2.ColorId;

                            if (!string.IsNullOrEmpty(info2.LotCode))
                            {
                                detail.IsLotGenerate = true;
                                detail.LotCode = info2.LotCode;
                            }

                            if (orderd != null)
                            {
                                detail.CurTraId = orderd.CUR_TRA_ID;
                                detail.CurRateTra = orderd.CUR_RATE_TRA;
                                detail.CurRateTypeId = orderd.CUR_RATE_TYPE_ID;
                                detail.Amt = Math.Round(orderd.UNIT_PRICE_TRA * info2.Qty * detail.CurRateTra, 2);
                                detail.AmtTra = Math.Round(orderd.UNIT_PRICE_TRA * info2.Qty, 2);
                                detail.UnitPriceTra = orderd.UNIT_PRICE_TRA;
                                detail.SourceMId = orderd.ORDER_M_ID;
                                detail.SourceDId = info2.Id;
                                detail.Note2 = "El terminalinden oluşturuldu";
                                detail.SourceApp = UyumSave.SourceApplication.SatınalmaSiparişi;

                                paramWaybill.Value.CurId = orderd.CUR_TRA_ID;
                                paramWaybill.Value.CurRateTypeId = orderd.CUR_RATE_TYPE_ID;
                                paramWaybill.Value.CurTra = orderd.CUR_RATE_TRA;

                                paramWaybill.Value.DueDate = orderd.DUE_DATE;
                                paramWaybill.Value.DueDay = orderd.DUE_DAY;
                            }

                            details.Add(detail); lineNo += 10;
                        }
                    }
                    paramWaybill.Value.Details = details.ToArray();

                    UyumSave.ServiceResultOfBoolean res = ClientApplication.Instance.SaveServ.SaveWaybill(paramWaybill);

                    if (res != null)
                    {
                        if (!res.Result)
                        {
                            Screens.Error(res.Message);
                        }
                        else
                        {
                            Screens.Info(string.Concat("Belge kaydedildi ", res.Message));
                            MainForm.ShowControl(null);
                        }
                        return;
                    }

                    //this._xIrsaliyeTarihi = this.Dt_IrsaliyeTarihi.Value.Date;
                    //this._xIrsaliyeSira = this.Tx_IrsaliyeSira.Text.ToString();
                    //this._xIrsaliyeSeri = this.Tx_IrsaliyeSeri.Text.ToString();
                    //this._xIrsaliyeNo = this.Tx_IrsaliyeNo.Text.ToString();

                    //if (this._xIrsaliyeSira == null)
                    //{
                    //    this._xIrsaliyeSira = "";
                    //}
                    //if (this._xIrsaliyeNo == null)
                    //{
                    //    this._xIrsaliyeNo = "";
                    //}
                    //if (!this._MultiSelect)
                    //{
                    //    str = this.Tx_IrsaliyeSeri.Text.ToString();
                    //    str2 = this.Tx_IrsaliyeSira.Text.ToString();
                    //}

                    //Screens.ShowWait();

                    //ServiceRequestOfCoDocTraInSelectTemp param = new ServiceRequestOfCoDocTraInSelectTemp();
                    //param.Token = ClientApplication.Instance.UTermToken;
                    //param.Value = new CoDocTraInSelectTemp();
                    //param.Value.SourceOrderDocTraId = _orderM.DocTraId; //int.Parse(this._r["DocTraId"].ToString());
                    //param.Value.SourceAppLication = 0x66;
                    //param.Value.SourceAppLication2 = 0x3e8;
                    //ServiceResultOfInt32 coDocTraTemp = ClientApplication.Instance.UTermService.GetCoDocTraTemp(param);
                    //if (!coDocTraTemp.Result)
                    //{
                    //    throw new Exception(string.Format("Satınmalma Sipariş Hareket Koduna Ait İrsaliye Hareket Kodu Bulunamadı\n Stn.Sip.Hareket Ref.No:{0}", param.Value.SourceOrderDocTraId));
                    //}
                    //ServiceRequestOfWaybillInfo context = new ServiceRequestOfWaybillInfo();
                    //context.Token = ClientApplication.Instance.UTermToken;
                    //context.Value = new WaybillInfo();
                    //context.Value.MasterId = _orderM.Id;
                    //context.Value.BelgeNo = Tx_IrsaliyeNo.Text;
                    //context.Value.Date = Convert.ToDateTime(this._xIrsaliyeTarihi);
                    //context.Value.DocTraId = int.Parse(coDocTraTemp.Value.ToString());
                    //List<OrderDetailInfo> list = new List<OrderDetailInfo>();
                    //foreach (OrderDInfo info2 in this._OrdList)
                    //{
                    //    if (info2.Qty > 0)
                    //    {
                    //        OrderDetailInfo item = new OrderDetailInfo
                    //        {
                    //            ItemId = info2.DcardId,
                    //            LotId = info2.LotId,
                    //            PackageTypeId = info2.PackageTypeId,
                    //            QualityId = info2.QualityId,
                    //            WhouseId = ClientApplication.Instance.SelectedDepot.Id,
                    //            Qty = info2.Qty,
                    //            OrderDetailId = info2.Id,
                    //            OrderMId = info2.MId
                    //        };
                    //        list.Add(item);
                    //    }
                    //}
                    //context.Value.OrderDetails = list.ToArray();
                    //ServiceResultOfBoolean flag2 = ClientApplication.Instance.UTermService.SavePurchaseWaybill(context);
                    //if (flag2.Result)
                    //{
                    //    Screens.Info("İrsaliye Oluşturuldu");
                    //    Screens.HideWait();
                    //    MainForm.ShowControl(null);
                    //}
                    //else
                    //{
                    //    Screens.Error(string.Concat("İrsaliye Oluşturulamadı ", Environment.NewLine, flag2.Message));
                    //}
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

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txt_Barcode);
        }

        private void t2_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textBox1);
        }

        private void btnparti_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count > 0)
                {
                    OrderDInfo order = listView1.Items[listView1.SelectedIndices[0]].Tag as OrderDInfo;
                    PartiLotInf partilot = FormPartiInput.ShowInput(order.DcardName + " için parti kodu girin", order.Qty);
                    if (partilot != null && !string.IsNullOrEmpty(partilot.LotCode))
                    {
                        if (partilot.Miktar != order.Qty)
                        {
                            OrderDInfo order2 = Utility.Clone(order) as OrderDInfo;
                            order2.Qty = partilot.Miktar;
                            order2.LotCode = partilot.LotCode;

                            order.Qty -= partilot.Miktar;
                            listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text = order.Qty.ToString(Statics.DECIMAL_STRING_FORMAT);

                            ListViewItem item = new ListViewItem();
                            item.Tag = order2;
                            item.Text = order2.DcardCode;
                            item.SubItems.Add(order2.DcardName);
                            item.SubItems.Add(order2.Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                            item.SubItems.Add(order2.QtyRemaining.ToString(Statics.DECIMAL_STRING_FORMAT));
                            item.SubItems.Add(order2.WhouseCode);
                            item.SubItems.Add(order2.WhouseDesc);
                            item.SubItems.Add(partilot.LotCode);

                            listView1.Items.Insert(listView1.SelectedIndices[0], item);
                        }
                        else
                        {
                            order.LotCode = partilot.LotCode;
                            listView1.Items[listView1.SelectedIndices[0]].SubItems[6].Text = partilot.LotCode;
                        }
                    }
                }
                else
                {
                    Screens.Warning("Listeden perti girilecek satır seçin!");
                    return;
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedIndices.Count > 0)
            {
                OrderDInfo info3 = listView1.Items[listView1.SelectedIndices[0]].Tag as OrderDInfo;
                if (info3 != null)
                {
                    info3.Qty = Screens.ShowInputBox("Miktar düzeltme", info3.Qty);
                }

                this.SetDataToGrid();
            }
        }
    }
}
