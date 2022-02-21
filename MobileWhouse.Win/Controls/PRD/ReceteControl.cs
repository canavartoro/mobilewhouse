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

namespace MobileWhouse.Controls.PRD
{
    [UyumModule("PRD011", "MobileWhouse.Controls.PRD.ReceteControl", "İş Emrine Malzeme Çıkış")]
    public partial class ReceteControl : BaseControl
    {
        public ReceteControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.WorderMInfo worderM = null;
        List<MobileWhouse.UTermConnector.PackageDetail> packages = null;
        private MobileWhouse.UyumConnector.DocTra selectedDocTra = null;
        private MobileWhouse.UyumConnector.Depot depo;

        private void GetRecete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.Append("SELECT B.ITEM_ID,I.ITEM_CODE,I.ITEM_NAME,B.UNIT_ID,U.UNIT_CODE,B.QTY_BASE_BOM QTY,COALESCE(BWH.QTY_PRM,0) ONHAND, ");
                sbSqlString.Append("B.WORDER_BOM_D_ID,B.BOM_LINE_TYPE,B.LINE_NO,B.WHOUSE_ID,W.WHOUSE_CODE ");
                sbSqlString.Append("FROM PRDT_WORDER_BOM_D B INNER JOIN INVD_ITEM I ON B.ITEM_ID = I.ITEM_ID INNER JOIN ");
                sbSqlString.Append("INVD_UNIT U ON B.UNIT_ID = U.UNIT_ID INNER JOIN INVD_WHOUSE W ON B.WHOUSE_ID = W.WHOUSE_ID LEFT JOIN ");
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
                            for (int i = 0; i < res.Value.Rows.Count; i++)
                            {
                                //decimal qty = 0, hand = 0;
                                //qty = Convert.ToDecimal(res.Value.Rows[i]["QTY"], ClientApplication.Instance.Culture) * miktar;
                                //hand = Convert.ToDecimal(res.Value.Rows[i]["ONHAND"], ClientApplication.Instance.Culture);
                                ListViewItem item = new ListViewItem();
                                item.Text = res.Value.Rows[i]["ITEM_CODE"].ToString();
                                item.SubItems.Add(res.Value.Rows[i]["ITEM_NAME"].ToString());
                                item.SubItems.Add(res.Value.Rows[i]["UNIT_CODE"].ToString());
                                item.SubItems.Add(res.Value.Rows[i]["QTY"].ToString());
                                //item.SubItems.Add(hand.ToString("0,0.#####"));
                                item.Tag = res.Value.Rows[i];
                                listisemri.Items.Add(item);
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
                txtbarkod.Focus();
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtisemri_OnSelected(object sender, object obj)
        {
            worderM = obj as MobileWhouse.ProdConnector.WorderMInfo;
            if (worderM != null)
            {
                packages = new List<MobileWhouse.UTermConnector.PackageDetail>();
                //txtstokkod.Text = string.Concat(worderM.ItemCode, " ", worderM.ItemName);
                GetRecete();
                txtbarkod.Focus();
            }
        }

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            txtbarkod_KeyPress(txtbarkod, new KeyPressEventArgs((char)13));
        }

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    Screens.ShowWait();

                    string barkod = txtbarkod.Text;
                    if (string.IsNullOrEmpty(barkod)) return;
                    txtbarkod.Text = "";

                    MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam _Ipp = new MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam();
                    _Ipp.Token = ClientApplication.Instance.UTermToken;
                    _Ipp.Value = new MobileWhouse.UTermConnector.ItemPickingParam();
                    _Ipp.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    _Ipp.Value.PackageNo = barkod;

                    MobileWhouse.UTermConnector.ServiceResultOfPackageDetail result = ClientApplication.Instance.UTermService.GetPackageInfo(_Ipp);
                    if (result.Result == false)
                    {
                        Screens.Error(result.Message.ToString());
                        return;
                    }
                    else
                    {
                        MobileWhouse.UTermConnector.PackageDetail package = result.Value;
                        if (package != null)
                        {
                            txtbarkod.Text = package.PackageNo;
                            bool find = false;
                            for (int i = 0; i < listisemri.Items.Count; i++)
                            {
                                if (listisemri.Items[i].Text.Equals(package.ItemInfo.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    find = true;
                                    int index = packages.FindIndex(x => x.PackageNo == package.PackageNo);
                                    if (index == -1)
                                    {
                                        packages.Add(package);
                                        ListViewItem item = new ListViewItem();
                                        item.Text = package.PackageNo;
                                        item.SubItems.Add(package.ItemInfo.Name);
                                        item.SubItems.Add(package.ItemInfo.Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                                        listbarkod.Items.Add(item);
                                    }
                                    else
                                    {
                                        Screens.Error(string.Concat("Daha önce okutulmuş barkod!", package.PackageNo));
                                        return;
                                    }
                                }
                            }
                            if (!find)
                            {
                                Screens.Error(string.Concat("Reçetede olmayan stok! ", package.ItemInfo.Name));
                                return;
                            }

                            //txtmiktar.Text = package.Qty.ToString(Statics.DECIMAL_STRING_FORMAT);//"0.#####");
                            //txtmiktar.Focus();
                            //txtmiktar.SelectAll();
                            return;
                        }

                    }
                }
                catch (Exception except)
                {
                    Screens.Error(except);
                }
                finally
                {
                    Screens.HideWait();
                    txtbarkod.Focus();
                    txtbarkod.SelectAll();
                }
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
                StringBuilder validate = new StringBuilder();
                if (listbarkod.Items.Count == 0)
                {
                    validate.AppendLine("Okutma yapılmadı!");
                }
                if (selectedDocTra == null)
                {
                    validate.AppendLine("Hareket kodu seçilmelidir!");
                }

                if (depo == null)
                {
                    validate.AppendLine("Depo seçilmedi!");
                }
                MobileWhouse.Models.DepotExtention depoext = new MobileWhouse.Models.DepotExtention(depo);
                if (depoext.is_location_track && depoext.input_location_id == 0)
                {
                    validate.AppendLine("Depo giriş raf tanımı hatalı!");
                }
                if (validate.Length > 0)
                {
                    Screens.Error(validate.ToString());
                    return;
                }

                Screens.ShowWait();

                PackageTraM ambhareket = new PackageTraM();
                ambhareket.CoId = ClientApplication.Instance.Token.CoId;
                ambhareket.BranchId = ClientApplication.Instance.Token.BranchId;
                ambhareket.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                ambhareket.WhouseCode = ClientApplication.Instance.SelectedDepot.Code;
                if (depo != null)
                {
                    ambhareket.Whouse2Id = depo.Id;
                    ambhareket.Whouse2Code = depo.Code;
                }
                ambhareket.DocNo =
                ambhareket.PackageNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                if (selectedDocTra.Status == 3)
                {
                    ambhareket.PackageOperationType = "Transfer";
                    ambhareket.InventoryStatus = "Transfer";
                }
                else if (selectedDocTra.Status == 2)
                {
                    ambhareket.PackageOperationType = "Sevk";
                    ambhareket.InventoryStatus = "Çıkış";
                }
                else
                {
                    ambhareket.PackageOperationType = "Giriş";
                    ambhareket.InventoryStatus = "Giriş";
                }
                ambhareket.SourceApp = "Ambalaj";
                ambhareket.PTypes = "Empty";
                ambhareket.Qty = 0;
                ambhareket.DocDate = DateTime.Today;
                ambhareket.DocTraId = selectedDocTra.Id;
                ambhareket.DocTraCode = selectedDocTra.DocTraCode;
                ambhareket.Note1 = worderM.WorderNo;
                ambhareket.UyumDetailItem = new AmbalajHareketDetail[packages.Count];
                for (int i = 0; i < packages.Count; i++)
                {
                    MobileWhouse.UTermConnector.PackageDetail package = packages[i];
                    ambhareket.UyumDetailItem[i] = new AmbalajHareketDetail();
                    ambhareket.UyumDetailItem[i].CoId = ambhareket.CoId;
                    ambhareket.UyumDetailItem[i].BranchId = ambhareket.BranchId;
                    ambhareket.UyumDetailItem[i].AddString01 = "";
                    ambhareket.UyumDetailItem[i].ItemId = package.ItemInfo.Id;
                    ambhareket.UyumDetailItem[i].ItemCode = package.ItemInfo.Name;
                    ambhareket.UyumDetailItem[i].LineNo = (i + 1) * 10;
                    ambhareket.UyumDetailItem[i].Qty = package.Qty;
                    ambhareket.UyumDetailItem[i].UnitId = package.ItemInfo.UnitId;
                    ambhareket.UyumDetailItem[i].PackageDetailType = "A";
                    ambhareket.UyumDetailItem[i].DcardId = package.ItemInfo.Id;
                    ambhareket.UyumDetailItem[i].DcardCode = package.ItemInfo.Name;
                    ambhareket.UyumDetailItem[i].PackageMId = package.PackageMId;
                    ambhareket.UyumDetailItem[i].PackageMNo = package.PackageNo;
                    ////if (_SelectedRaf != null)
                    {
                        ambhareket.UyumDetailItem[i].BwhLocationId = depoext.input_location_id;//_SelectedRaf.Id;
                        //ambdetay.LocationCode = _SelectedRaf.Name;//sakın gönderme valla patlar
                    }
                    ambhareket.UyumDetailItem[i].PackageOperationType = ambhareket.PackageOperationType;
                }

                MobileWhouse.UyumSave.UyumServiceRequestOfString Context = new MobileWhouse.UyumSave.UyumServiceRequestOfString();
                Context.Token = new MobileWhouse.UyumSave.UyumToken();
                Context.Token.UserName = ClientApplication.Instance.Token.UserName;
                Context.Token.Password = ClientApplication.Instance.Token.Password;
                Context.Value = ambhareket.ToXml();
                MobileWhouse.UyumSave.UyumServiceResponseOfString resp = ClientApplication.Instance.SaveServ.SaveUyumObjectFromXML(Context);
                if (!resp.Success)
                {
                    Screens.Error(resp.Message);
                }
                else
                {
                    PackageTraM ambhar = (PackageTraM)BaseModel.FromXml(typeof(PackageTraM), resp.Value);
                    Screens.Info(string.Concat("Belge kaydedildi. ", ambhar.Id, ", No:", ambhar.DocNo));
                    listbarkod.Items.Clear();
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

        private void textHareket_OnSelected(object sender, object obj)
        {
            selectedDocTra = obj as MobileWhouse.UyumConnector.DocTra;
        }

        private void textDepo_OnSelected(object sender, object obj)
        {
            depo = obj as MobileWhouse.UyumConnector.Depot;
        }

        private void btnklavye_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txtbarkod);
        }
    }
}
