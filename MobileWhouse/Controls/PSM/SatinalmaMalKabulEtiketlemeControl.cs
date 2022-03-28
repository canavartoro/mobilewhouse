using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Models;
using MobileWhouse.Attributes;
using MobileWhouse.UyumConnector;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.PSM
{
    [UyumModule("PSM002", "MobileWhouse.Controls.PSM.SatinalmaMalKabulEtiketlemeControl", "S. MAL KABUL ETİKETLEME")]
    public partial class SatinalmaMalKabulEtiketlemeControl : BaseControl
    {
        public SatinalmaMalKabulEtiketlemeControl()
        {
            InitializeComponent();
        }

        public SatinalmaMalKabulEtiketlemeControl(invt_item_m invt_item_m)
        {
            InitializeComponent();
            this._invt_item_m = invt_item_m;
            IrsaliyeDetay();
            secmalkabuldoktra.SourceApplication = 212;
        }

        private invt_item_m _invt_item_m = null;
        private List<invt_item_d> details = null;
        private MobileParameter mobileParam = null;
        private invt_item_d selected = null;

        private void IrsaliyeDetay()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"SELECT d.item_d_id,d.item_id,it.item_code,it.item_name,d.unit_id,un.unit_code,d.line_no,d.lot_id,lt.lot_code,d.qty,d.whouse_id,wh.whouse_code,d.source_d_id,d.source_m_id 
FROM invt_item_d d INNER JOIN invd_item it ON d.item_id = it.item_id INNER JOIN 
invd_unit un ON d.unit_id = un.unit_id LEFT JOIN invd_lot lt ON d.lot_id = lt.lot_id LEFT JOIN
invd_whouse wh ON d.whouse_id = wh.whouse_id
WHERE d.item_m_id = {0}
ORDER BY d.line_no", _invt_item_m.item_m_id);

                UyumConnector.ServiceRequestOfString paramSql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                paramSql.Token = ClientApplication.Instance.Token;
                paramSql.Value = sql.ToString();
                MobileWhouse.UyumConnector.ServiceResultOfDataTable rs = ClientApplication.Instance.Service.ExecuteSQL(paramSql);
                if (rs != null && rs.Value != null && rs.Value.Rows.Count > 0)
                {
                    listView1.BeginUpdate();
                    listView1.Items.Clear();

                    details = Data.DataProvider.TableToList(rs.Value, typeof(invt_item_d)) as List<invt_item_d>;
                    if (details != null && details.Count > 0)
                    {
                        for (int i = 0; i < details.Count; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Tag = details[i];
                            item.Text = details[i].item_code;
                            item.SubItems.Add(details[i].item_name);
                            item.SubItems.Add(details[i].unit_code);
                            item.SubItems.Add(details[i].qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                            item.SubItems.Add(details[i].lot_code);
                            listView1.Items.Add(item);
                        }
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
                listView1.EndUpdate();
            }
        }

        public string GetPackageNo()
        {
            try
            {
                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Format("SELECT concat('{0}', lpad(((nextval('zz_package_m_package_pl_seq'::regclass))::character varying)::text, 12, '0'::text)) ", mobileParam.malkabul_prefix);
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        if (res.Value != null && res.Value.Rows.Count > 0)
                            return res.Value.Rows[0][0].ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            return null;
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new MalKabulControl());
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                Screens.Warning("Listeden satır seçin.");
                listView1.Focus();
                return;
            }

            int adet = numAmb.IntValue;
            if (adet <= 0) adet = 1;
            decimal miktar = txtmiktar.DecimalValue;

            for (int i = 0; i < adet; i++)
            {
                AmbalajHareketDetail ambdetay = new AmbalajHareketDetail();
                ambdetay.AddString01 = selected.lot_code;
                ambdetay.ItemId = selected.item_id;
                ambdetay.ItemCode = selected.item_code;
                ambdetay.LotId = selected.lot_id;
                ambdetay.LineNo = (listbarkod.Items.Count + 1) * 10;
                ambdetay.Qty = miktar;
                ambdetay.SourceDId = selected.item_d_id;
                ambdetay.UnitId = selected.unit_id;
                ambdetay.UnitCode = selected.unit_code;
                ambdetay.PackageDetailType = "S";
                ambdetay.DcardId = selected.item_id;
                ambdetay.DcardCode = selected.item_code;
                ambdetay.PackageOperationType = "Giriş";
                ListViewItem item = new ListViewItem();
                item.Text = selected.item_code;
                item.Tag = ambdetay;
                item.SubItems.Add(selected.item_code);
                item.SubItems.Add(miktar.ToString(Statics.DECIMAL_STRING_FORMAT));
                listbarkod.Items.Add(item);
                selected.qty_barkod += miktar;
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                selected = listView1.Items[listView1.SelectedIndices[0]].Tag as invt_item_d;
                lblbilgi.Text = string.Concat(selected.item_code, " ", selected.item_name, " ",
                    selected.qty.ToString(Statics.DECIMAL_STRING_FORMAT), " X ", selected.qty_barkod.ToString(Statics.DECIMAL_STRING_FORMAT));
            }
        }

        private void listbarkod_ItemActivate(object sender, EventArgs e)
        {
            if (listbarkod.SelectedIndices.Count > 0)
            {
                if (!Screens.Question("seçilen satır silinecek onaylıyor musunuz?")) return;
                AmbalajHareketDetail ambdetay = listbarkod.Items[listbarkod.SelectedIndices[0]].Tag as AmbalajHareketDetail;
                if (ambdetay != null)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        invt_item_d item = listView1.Items[i].Tag as invt_item_d;
                        if (item != null && item.item_d_id == ambdetay.SourceDId)
                        {
                            item.qty_barkod -= ambdetay.Qty;
                            break;
                        }
                    }
                }
                listbarkod.Items.RemoveAt(listbarkod.SelectedIndices[0]);
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {

                if (mobileParam == null)
                {
                    Screens.Error("Mobil parametreler bulunamadı!");
                    return;
                }
                if (string.IsNullOrEmpty(mobileParam.malkabul_prefix))
                {
                    Screens.Error("Mobil parametreler Mal Kabul Prefix tanımlı değil!");
                    return;
                }

                if (!printmalkabul.IsSelectPrinter && !Screens.Question("Yazıcı seçilmedi! işleme devam edilsin mi? Barkod basılmayacak.")) return;

                btnkapat.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                List<string> barcodes = new List<string>();
                StringBuilder serror = new StringBuilder();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    invt_item_d item = listView1.Items[i].Tag as invt_item_d;
                    if (item.qty != item.qty_barkod)
                    {
                        serror.Append("Stok:").Append(item.item_code).Append(", Gelen:")
                            .Append(item.qty.ToString("N"))
                            .Append(",Etiket:").Append(item.qty_barkod.ToString("N"))
                            .Append(Environment.NewLine);
                    }
                }
                if (serror.Length > 0)
                {
                    Screens.Error(string.Concat("ETİKETLEME HATASI!", Environment.NewLine, serror.ToString()));
                    return;
                }

                DocTra selectedDocTra = secmalkabuldoktra.SelectedObject as DocTra;
                if (object.ReferenceEquals(null, selectedDocTra))
                {
                    Screens.Error("Hareket kodu seçilmelidir!");
                    return;
                }

                MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo();
                param.Token = ClientApplication.Instance.ProdToken;
                param.Value = new MobileWhouse.ProdConnector.PackageTraMInfo();
                param.Value.DocDate = DateTime.Today;
                param.Value.DocNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                param.Value.SourceMId = _invt_item_m.item_m_id;
                param.Value.SourceApp = 1000;
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.Details = new MobileWhouse.ProdConnector.PackageTraDInfo[listbarkod.Items.Count];
                for (int i = 0; i < listbarkod.Items.Count; i++)
                {
                    AmbalajHareketDetail ambdetay = listbarkod.Items[i].Tag as AmbalajHareketDetail;
                    if (string.IsNullOrEmpty(ambdetay.PackageNo))
                    {
                        ambdetay.PackageMNo = GetPackageNo();
                        barcodes.Add(ambdetay.PackageMNo);
                    }
                    param.Value.Details[i] = new MobileWhouse.ProdConnector.PackageTraDInfo();
                    param.Value.Details[i].ItemId = ambdetay.ItemId;
                    param.Value.Details[i].PackageMId = ambdetay.ItemId;
                    param.Value.Details[i].PackageMNo = ambdetay.PackageMNo;
                    param.Value.Details[i].Qty = ambdetay.Qty;
                    param.Value.Details[i].SourceDId = ambdetay.SourceDId;
                    param.Value.Details[i].SourceMId = ambdetay.SourceMId;
                    param.Value.Details[i].UnitId = ambdetay.UnitId;
                    param.Value.Details[i].LotId = ambdetay.LotId;
                    param.Value.Details[i].BwhLocationId = 0;
                }

                MobileWhouse.ProdConnector.ServiceResultOfPackageTraDInfo resp = ClientApplication.Instance.ProdService.SavePackageTraM(param);
                if (!resp.Result)
                {
                    Screens.Error(resp.Message);
                }
                else
                {
                    if (resp.Value != null)
                        lblbilgi.Text = string.Concat(resp.Value.PackageMNo, " ", resp.Value.PackageMId);

                    if (printmalkabul.IsSelectPrinter)
                    {
                        //decimal raporcode = 221120315362129;

                        //if (cmbdizayn.SelectedValue != null && cmbdizayn.SelectedValue is System.Decimal)
                        //{
                        //    raporcode = Convert.ToDecimal(cmbdizayn.SelectedValue);
                        //}
                        for (int i = 0; i < barcodes.Count; i++)
                        {
                            AmbalajHareketDetail detail = listbarkod.Items[i].Tag as AmbalajHareketDetail;
                            printmalkabul.Print(string.Concat(" \"barcode\" = '", barcodes[i], "'  "));
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                btnkapat.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        void SatinalmaMalKabulEtiketlemeControl_OnLoad(object sender, System.EventArgs e)
        {
            try
            {
                mobileParam = MobileParameter.GetMobileParameter();
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
