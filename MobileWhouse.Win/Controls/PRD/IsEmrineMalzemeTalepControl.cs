using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using System.Globalization;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    //"PRDT_TRANSFER_M ( PrdTransferMCollection )" PrdTransferM.xml		İş Emrine Bağlı Talep Girişi
    [UyumModule("PRD001", "MobileWhouse.Controls.PRD.IsEmrineMalzemeTalepControl", "İş Emrine Malzeme Talebi")]
    public partial class IsEmrineMalzemeTalepControl : BaseControl
    {
        public IsEmrineMalzemeTalepControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.UyumConnector.Depot depo = null;
        private MobileWhouse.ProdConnector.WorderMInfo worderM = null;

        private void GetRecete()
        {
            try
            {
                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.Append("SELECT B.ITEM_ID,I.ITEM_CODE,I.ITEM_NAME,B.UNIT_ID,U.UNIT_CODE,B.QTY_BASE_BOM QTY,COALESCE(BWH.QTY_PRM,0) ONHAND, ");
                sbSqlString.Append("B.WORDER_BOM_D_ID,B.BOM_LINE_TYPE,B.LINE_NO,B.WHOUSE_ID,W.WHOUSE_CODE ");
                sbSqlString.Append("FROM PRDT_WORDER_BOM_D B INNER JOIN INVD_ITEM I ON B.ITEM_ID = I.ITEM_ID INNER JOIN ");
                sbSqlString.Append("INVD_UNIT U ON B.UNIT_ID = U.UNIT_ID LEFT JOIN INVD_WHOUSE W ON B.WHOUSE_ID = W.WHOUSE_ID LEFT JOIN ");
                sbSqlString.Append("INVD_BWH_ITEM_D BWH ON B.ITEM_ID = BWH.ITEM_ID AND B.WHOUSE_ID = BWH.WHOUSE_ID ");
                sbSqlString.AppendFormat("WHERE B.BRANCH_ID = {0} AND B.CO_ID = {1} ", ClientApplication.Instance.Token.BranchId, ClientApplication.Instance.Token.CoId);
                sbSqlString.AppendFormat(" AND B.WORDER_M_ID = {0} ", worderM.Id);

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = sbSqlString.ToString();

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        listisemri.BeginUpdate();
                        listisemri.Items.Clear();
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            decimal miktar = 1;
                            if (!string.IsNullOrEmpty(txtmiktar.Text))
                                miktar = Convert.ToDecimal(txtmiktar.Text, ClientApplication.Instance.Culture);
                            decimal gereken = 0, onhand = 0;
                            for (int i = 0; i < res.Value.Rows.Count; i++)
                            {
                                decimal qty = 0, hand = 0;
                                qty = Convert.ToDecimal(res.Value.Rows[i]["QTY"], ClientApplication.Instance.Culture) * miktar;
                                hand = Convert.ToDecimal(res.Value.Rows[i]["ONHAND"], ClientApplication.Instance.Culture);
                                ListViewItem item = new ListViewItem();
                                item.Text = res.Value.Rows[i]["ITEM_CODE"].ToString();
                                item.SubItems.Add(res.Value.Rows[i]["ITEM_NAME"].ToString());
                                item.SubItems.Add(res.Value.Rows[i]["UNIT_CODE"].ToString());
                                item.SubItems.Add(qty.ToString("0,0.#####"));
                                item.SubItems.Add(hand.ToString("0,0.#####"));
                                item.Tag = res.Value.Rows[i];
                                listisemri.Items.Add(item);
                                gereken += qty;
                                onhand += hand;
                            }
                            //lblbilgi.Text = string.Concat("Satır Sayısı:,", res.Value.Rows.Count, ", Gereken:", gereken.ToString("#.###"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                listisemri.EndUpdate();
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (worderM == null)
                {
                    Screens.Error("İş emri seçilmelidir!");
                    return;
                }

                if (depo == null)
                {
                    Screens.Error("Depo seçilmelidir!");
                    return;
                }

                if (listisemri.Items.Count == 0)
                {
                    Screens.Error("İş emri malzemesi boş olamaz!");
                    return;
                }

                decimal qtyTrailing = Convert.ToDecimal(txtmiktar.Text, ClientApplication.Instance.Culture);

                if (qtyTrailing <= 0)
                {
                    Screens.Error("Transfer miktarı girin!");
                    return;
                }

                if (!Screens.Question("Belge kaydedilsin mi?")) return;

                MobileWhouse.ProdConnector.TransferMInfo transferM = new MobileWhouse.ProdConnector.TransferMInfo();
                transferM.TransferWhouseId = ClientApplication.Instance.SelectedDepot.Id;
                transferM.WoTypeId = worderM.WoTypeId;
                transferM.DocDate = DateTime.Now.Date;
                //transferM.DocTraId = 12142;
                transferM.WhouseId = depo.Id;
                transferM.TransferWorderList = new MobileWhouse.ProdConnector.TransferWorderInfo[listisemri.Items.Count];
                transferM.IsOut = false;
                transferM.IsTransferDCreate = true;//belge detaylarini otomatik olusturma
                //transferM.IsTransferDCreate = checkTransfer.Checked;

                for (int i = 0; i < listisemri.Items.Count; i++)
                {
                    DataRow dr = listisemri.Items[i].Tag as DataRow;
                    MobileWhouse.ProdConnector.TransferWorderInfo trans = new MobileWhouse.ProdConnector.TransferWorderInfo();
                    trans.WorderMId = worderM.Id;
                    trans.WorderMQty = qtyTrailing;//worderM.Qty;
                    trans.WorderItemId = worderM.ItemId;
                    trans.WorderUnitId = worderM.UnitId;
                    trans.ItemId = StringUtil.ToInteger(dr["ITEM_ID"]);
                    trans.UnitId = StringUtil.ToInteger(dr["UNIT_ID"]);
                    trans.Qty = qtyTrailing;//Convert.ToDecimal(dr["QTY"], ClientApplication.Instance.Culture);
                    trans.QtyTrailing = qtyTrailing * StringUtil.ToDecimal(dr["QTY"]);
                    transferM.TransferWorderList[i] = trans;
                }

                MobileWhouse.ProdConnector.ServiceRequestOfTransferMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfTransferMInfo();
                param.Token = ClientApplication.Instance.ProdToken;
                param.Value = transferM;

                MobileWhouse.ProdConnector.ServiceResultOfTransferMInfo res = ClientApplication.Instance.ProdService.PrdTransferCreate(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        Screens.Info(string.Concat("Belge kaydedildi, Id:", res.Value.Id, ", No:", res.Value.DocNo));
                        //lblbilgi.Text = string.Concat("Id:", res.Value.Id, ", No:", res.Value.DocNo);
                        depo = null;
                        worderM = null;
                        listisemri.Items.Clear();
                        txtmiktar.Text = "";
                        txtdepo.SetText("");
                        txtisemrino.SetText("");
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                listisemri.EndUpdate();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (listisemri.SelectedIndices.Count > 0)
            {
                //if (!Screens.Question("Seçilen iş emri malzeme satırı talep listesinden çıkartılsın mı?")) return;
                listisemri.Items.RemoveAt(listisemri.SelectedIndices[0]);
            }
        }

        private void txtmiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
            string numberDecimalSeparator = numberFormat.NumberDecimalSeparator;
            string negativeSign = numberFormat.NegativeSign;
            string str3 = e.KeyChar.ToString();
            if (((!char.IsDigit(e.KeyChar) && !str3.Equals(numberDecimalSeparator)) &&
                ((!str3.Equals(negativeSign)) && ((e.KeyChar != '\b') &&
                (e.KeyChar != Convert.ToChar(Keys.Delete))))) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void listisemri_ItemActivate(object sender, EventArgs e)
        {
            if (listisemri.SelectedIndices.Count > 0)
            {
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            decimal qtyTrailing = Convert.ToDecimal(txtmiktar.Text, ClientApplication.Instance.Culture);
            if (qtyTrailing > 0 && listisemri.Items.Count > 0)
            {
                listisemri.BeginUpdate();
                for (int i = 0; i < listisemri.Items.Count; i++)
                {
                    DataRow dr = listisemri.Items[i].Tag as DataRow;
                    listisemri.Items[i].SubItems[3].Text = (qtyTrailing * Convert.ToDecimal(dr["QTY"], ClientApplication.Instance.Culture)).ToString("0,0.#####");
                }
                listisemri.EndUpdate();
            }
        }

        private void txtisemrino_OnSelected(object sender, object obj)
        {
            worderM = obj as MobileWhouse.ProdConnector.WorderMInfo;
            if (worderM != null)
            {
                txtisemrino.Text = worderM.WorderNo;
                //txtstokkod.Text = string.Concat(worderM.ItemCode, " ", worderM.ItemName);
                GetRecete();
            }
        }

        private void txtdepo_OnSelected(object sender, object obj)
        {
            depo = obj as MobileWhouse.UyumConnector.Depot;
        }
    }
}
