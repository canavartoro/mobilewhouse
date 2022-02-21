using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Models;
using MobileWhouse.Enums;
using MobileWhouse.Util;
using MobileWhouse.Dilogs;
using MobileWhouse.Log;

namespace MobileWhouse.GUI
{
    public partial class ULookupEdit : UserControl
    {
        public ULookupEdit()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(ULookupEdit_Paint);
        }

        private System.Windows.Forms.Timer timerLoader;

        private int _SourceApplication = 0;
        public int SourceApplication
        {
            get { return _SourceApplication; }
            set
            {
                _SourceApplication = value;
            }
        }
        private int _purchase_sales = -1;
        public int PurchaseSales
        {
            get { return _purchase_sales; }
            set { _purchase_sales = value; }
        }

        private string datafieldName = "";
        public string DataFieldName
        {
            get { return datafieldName; }
            set { datafieldName = value; }
        }

        private bool showdescription = false;
        public bool ShowDescription
        {
            get { return showdescription; }
            set
            {
                showdescription = value;
                ResaiseControls();
            }
        }

        private string filterCondition = "";
        public string FilterCondition
        {
            get { return filterCondition; }
            set { filterCondition = value; }
        }

        private bool rememberValue = false;
        public bool RememberValue
        {
            get { return rememberValue; }
            set
            {
                rememberValue = value;
            }
        }

        private bool showLabelText = false;
        public bool ShowLabelText
        {
            get { return showLabelText; }
            set
            {
                showLabelText = value;
                ResaiseControls();
            }
        }

        private int labelWith = 70;
        public int LabelWidth
        {
            get { return labelWith; }
            set
            {
                labelWith = value;
                ResaiseControls();
            }
        }

        public string LabelText
        {
            get { return labelkod.Text; }
            set
            {
                labelkod.Text = value;
            }
        }

        private DataSourceType dataType = DataSourceType.Yok;
        public DataSourceType DataType
        {
            get { return dataType; }
            set
            {
                dataType = value;
                if (dataType == DataSourceType.BelgeNo)
                {
                    textkod.MaxLength = 15;
                }
            }
        }

        public event OnSelectedObject OnSelected;

        private object selectedObject = null;
        public object SelectedObject
        {
            get { return selectedObject; }
        }

        private void SaveSelected()
        {
            //if (OnSelected != null)
            //    this.OnSelected.Invoke(this, this.selectedObject);

            if (RememberValue && this.selectedObject != null)
            {
                AppCache.WriteCache(this.Name, textkod.Text);
                //FileHelper.SaveFile(this.Name, FileHelper.ToXml(this.selectedObject));
            }
            //LoadFields();
        }

        private void SetFields(string code, string desc)
        {
            //if (OnSelected != null)
            //    this.OnSelected.Invoke(this, this.selectedObject);

            if (RememberValue && this.selectedObject != null)
            {
                //FileHelper.SaveFile(this.Name, FileHelper.ToXml(this.selectedObject));
                AppCache.WriteCache(this.Name, code);
            }
            textkod.Text = code;
            textdesc.Text = desc;
            textkod.Focus();
        }

        private void ResaiseControls()
        {
            labelkod.Size = new Size(labelWith, 25 + Screens.LookupEditHeigh);

            textkod.Size = new Size(this.Width - (labelWith + 50), 23 + Screens.LookupEditHeigh);
            textkod.Location = new Point(labelWith, 2);

            if (showLabelText)
            {
                labeldesc.Visible = true;
                labeldesc.Size = new Size(labelWith, 25);
                textdesc.Size = new Size(this.Width - labelWith, 23);
                textdesc.Location = new Point(labelWith, 26);
            }
            else
            {
                labeldesc.Visible = false;
                textdesc.Size = new Size(this.Width, 23);
                textdesc.Location = new Point(0, 26);
            }

            labeldesc.Visible = showdescription;
            textdesc.Visible = showdescription;

            this.Height = showdescription ? 50 : 27 + Screens.LookupEditHeigh;
        }

        public string GetText()
        {
            return textkod.Text;
        }

        public void SetText(string txt)
        {
            selectedObject = null;
            textdesc.Text = "";
            textkod.Text = txt;
            textkod_KeyPress(textkod, new KeyPressEventArgs('\r'));
        }

        public void SetFocus()
        {
            this.Focus();
            textkod.Focus();
            return;
        }

        public new string Text
        {
            get { return textkod.Text; }
            set
            {
                textkod.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    //textkod_KeyPress(textkod, new KeyPressEventArgs('\r'));
                }
                else
                {
                    textdesc.Text = "";
                    selectedObject = null;
                }
            }
        }

        public string Description
        {
            get { return textdesc.Text; }
            set
            {
                textdesc.Text = value;
            }
        }

        private bool onload = false;
        private void ULookupEdit_Paint(object sender, PaintEventArgs e)
        {
            if (!Utility.IsDesignMode)
            {
                if (!onload)
                {
                    onload = true;
                    ResaiseControls();
                    if (RememberValue)
                    {
                        string kod = AppCache.ReadCache(this.Name, "");
                        if (!string.IsNullOrEmpty(kod))
                        {
                            textkod.Text = kod;
                            //OnPress();
                        }
                    }
                }
            }
        }

        private void textdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textkod_ParentChanged(object sender, EventArgs e)
        {
            ResaiseControls();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (DataType != DataSourceType.Yok)
            {
                if (dataType == DataSourceType.Istasyon || dataType == DataSourceType.Uretim_IsEmri_Istasyon)
                {
                    using (FormSelectWstation frm = new FormSelectWstation())
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.Wstation != null)
                        {
                            this.selectedObject = frm.Wstation;
                            SetFields(frm.Wstation.PrdGobalCode, frm.Wstation.PrdGobalName);
                        }
                    }
                }
                else if (dataType == DataSourceType.IsEmri)
                {
                    using (FormSelectWorder frm = new FormSelectWorder())
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.WorderM != null)
                        {
                            this.selectedObject = frm.WorderM;
                            SetFields(frm.WorderM.WorderNo, string.Concat(frm.WorderM.ItemCode, " ", frm.WorderM.ItemName));
                        }
                    }
                }
                else if (dataType == DataSourceType.Depo)
                {
                    using (FormSelectDepot form = new FormSelectDepot())
                    {
                        form._OnlyWithLocation = false;
                        form.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                        if (form.ShowDialog() == DialogResult.OK
                            && form.Selected != null && form.Selected.Id != ClientApplication.Instance.SelectedDepot.Id)
                        {
                            this.selectedObject = form.Selected;
                            SetFields(form.Selected.Code, form.Selected.Name);
                        }
                    }
                }
                else if (dataType == DataSourceType.Hurda)
                {
                    FormSelectHareketKod docTraForm = new FormSelectHareketKod();
                    if (docTraForm.ShowDialog() == DialogResult.OK && docTraForm.Selected != null)
                    {
                        this.selectedObject = docTraForm.Selected;
                        SetFields(docTraForm.Selected.DocTraCode, docTraForm.Selected.DocTraDesc);
                    }
                }
                else if (dataType == DataSourceType.ScrapItem)
                {
                    using (FormSelectScrapItem frm = new FormSelectScrapItem())
                    {
                        if (frm.ShowDialog() == DialogResult.OK && frm.Item != null)
                        {
                            this.selectedObject = frm.Item;
                            SetFields(string.Concat(frm.Item.item_code, " ", frm.Item.item_name), frm.Item.item_name);
                        }
                    }
                }
                else if (dataType == DataSourceType.Cari)
                {
                    using (FormSelectEntity form = new FormSelectEntity())
                    {
                        if (form.ShowDialog() == DialogResult.OK
                            && form.EntityInfo != null)
                        {
                            this.selectedObject = form.EntityInfo;
                            SetFields(form.EntityInfo.EntityCode, form.EntityInfo.EntityName);
                        }
                    }
                }
                else if (dataType == DataSourceType.Hareket)
                {
                    using (FormSelectHareketKod form = new FormSelectHareketKod())
                    {
                        form.SourceApplication = _SourceApplication;
                        form.PurchaseSales = _purchase_sales;
                        if (form.ShowDialog() == DialogResult.OK
                            && form.Selected != null)
                        {
                            this.selectedObject = form.Selected;
                            SetFields(form.Selected.DocTraCode, form.Selected.DocTraDesc);
                        }
                    }
                }

                if (this.selectedObject != null && OnSelected != null)
                {
                    OnSelected(this, this.selectedObject);
                }
            }
            else
            {
                if (OnSelected != null)
                {
                    OnSelected(this, null);
                }
            }
        }

        private void MTALookupEdit_Resize(object sender, EventArgs e)
        {
            ResaiseControls();
        }

        public void OnPress()
        {
            textkod_KeyPress(textkod, new KeyPressEventArgs((char)13));
        }

        public void OnClick()
        {
            btn_Click(btn, EventArgs.Empty);
        }

        private void textkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string code = textkod.Text.Replace("*", "");
                textkod.Text = "";

                try
                {
                    if (string.IsNullOrEmpty(code)) return;

                    Cursor.Current = Cursors.WaitCursor;

                    if (dataType == DataSourceType.Istasyon)
                    {
                        MobileWhouse.ProdConnector.ServiceRequestOfPrdGobalParam param = new MobileWhouse.ProdConnector.ServiceRequestOfPrdGobalParam();
                        param.Token = ClientApplication.Instance.ProdToken;
                        param.PageSize = 9999;
                        param.Value = new MobileWhouse.ProdConnector.PrdGobalParam();
                        param.Value.PageSize = 9999;
                        param.Value.PrdGobalType = 1;
                        param.Value.PrdGobalCode = code;

                        MobileWhouse.ProdConnector.ServiceResultOfListOfPrdGobalInfo res = ClientApplication.Instance.ProdService.GetPrdGobalInfo(param);
                        if (res != null)
                        {
                            if (res.Result == false)
                            {
                                Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                            }
                            else
                            {
                                if (res.Value != null && res.Value.Length > 0)
                                {
                                    this.selectedObject = res.Value[0];
                                    SetFields(res.Value[0].PrdGobalCode, res.Value[0].PrdGobalName);
                                }
                            }
                        }
                    }
                    else if (dataType == DataSourceType.IsEmri)
                    {
                        MobileWhouse.ProdConnector.ServiceRequestOfWorderMParam param = new MobileWhouse.ProdConnector.ServiceRequestOfWorderMParam();
                        param.Token = ClientApplication.Instance.ProdToken;
                        param.PageSize = 9999;
                        param.Value = new MobileWhouse.ProdConnector.WorderMParam();
                        param.Value.PageSize = 9999;
                        param.Value.WorderNo = code;

                        MobileWhouse.ProdConnector.ServiceResultOfListOfWorderMInfo res = ClientApplication.Instance.ProdService.GetWorderMInfo(param);
                        if (res != null)
                        {
                            if (res.Result == false)
                            {
                                MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                            }
                            else
                            {
                                if (res.Value != null && res.Value.Length > 0)
                                {
                                    this.selectedObject = res.Value[0];
                                    SetFields(res.Value[0].WorderNo, string.Concat(res.Value[0].ItemCode, " ", res.Value[0].ItemName));
                                }
                            }
                        }
                    }
                    else if (dataType == DataSourceType.Depo)
                    {
                        MobileWhouse.UyumConnector.ServiceRequestOfDepotSelectParam param = new MobileWhouse.UyumConnector.ServiceRequestOfDepotSelectParam();
                        param.Token = ClientApplication.Instance.Token;
                        param.Value = new MobileWhouse.UyumConnector.DepotSelectParam();
                        param.Value.DescriptionFilter = code;
                        param.Value.OnlyWithLocation = false;

                        MobileWhouse.UyumConnector.ServiceResultOfListOfDepot depots = ClientApplication.Instance.Service.GetDepots(param);

                        if (depots != null)
                        {
                            if (depots.Result == false)
                            {
                                MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", depots.Message));
                            }
                            else
                            {
                                if (depots.Value != null && depots.Value.Length > 0)
                                {
                                    this.selectedObject = depots.Value[0];
                                    SetFields(depots.Value[0].Code, depots.Value[0].Name);
                                }
                            }
                        }
                    }
                    else if (dataType == DataSourceType.Hareket)
                    {
                        if (_SourceApplication == 0)
                        {

                            UyumConnector.ServiceRequestOfDocTraSelectParam param = new UyumConnector.ServiceRequestOfDocTraSelectParam();
                            param.Token = ClientApplication.Instance.Token;
                            param.Value = new UyumConnector.DocTraSelectParam();
                            param.Value.DocTraCodeFilter = code;
                            param.Value.BranchId = ClientApplication.Instance.Token.BranchId;
                            param.Value.CoId = ClientApplication.Instance.Token.CoId;
                            param.Value.SourceApplication = _SourceApplication;

                            UyumConnector.ServiceResultOfListOfDocTra docTras = ClientApplication.Instance.Service.GetDocTras(param);
                            if (!docTras.Result)
                            {
                                Screens.Error(docTras.Message);
                                return;
                            }

                            if (docTras.Value != null && docTras.Value.Length > 0)
                            {
                                this.selectedObject = docTras.Value[0];
                                SetFields(docTras.Value[0].DocTraCode, docTras.Value[0].DocTraDesc);
                            }
                        }
                        else
                        {
                            StringBuilder sql = new StringBuilder();
                            sql.Append(string.Concat(@"SELECT DESCRIPTION ""DocTraDesc"", DOC_TRA_ID ""Id"",  DOC_TRA_CODE ""DocTraCode"", INVENTORY_STATUS ""Status"" FROM GNLD_DOC_TRA WHERE GNLD_DOC_TRA.SOURCE_APP = ", _SourceApplication));
                            if (_purchase_sales > 0)
                                sql.Append(" AND GNLD_DOC_TRA.PURCHASE_SALES = ").Append(_purchase_sales);

                            sql.AppendFormat(" AND GNLD_DOC_TRA.DOC_TRA_CODE LIKE '{0}%' ", code);

                            UyumConnector.ServiceRequestOfString param = new UyumConnector.ServiceRequestOfString();
                            param.Token = ClientApplication.Instance.Token;
                            param.Value = sql.ToString();
                            //param.Value = string.Concat(@"SELECT DESCRIPTION ""DocTraDesc"", DOC_TRA_ID ""Id"",  DOC_TRA_CODE ""DocTraCode"", INVENTORY_STATUS ""Status"" FROM GNLD_DOC_TRA WHERE GNLD_DOC_TRA.SOURCE_APP = ", _SourceApplication,
                            //    " AND DOC_TRA_CODE LIKE '", code, "%' ");

                            UyumConnector.ServiceResultOfDataTable restbl = ClientApplication.Instance.Service.ExecuteSQL(param);
                            if (!restbl.Result)
                            {
                                Screens.Error(restbl.Message);
                                return;
                            }

                            if (restbl.Value != null && restbl.Value.Rows.Count > 0)
                            {
                                MobileWhouse.UyumConnector.DocTra doctra = new MobileWhouse.UyumConnector.DocTra();
                                doctra.Id = Convert.ToInt32(restbl.Value.Rows[0]["Id"]);
                                doctra.DocTraCode = restbl.Value.Rows[0]["DocTraCode"].ToString();
                                doctra.DocTraDesc = restbl.Value.Rows[0]["DocTraDesc"].ToString();
                                doctra.Status = Convert.ToInt32(restbl.Value.Rows[0]["Status"]);
                                this.selectedObject = doctra;
                                SetFields(doctra.DocTraCode, doctra.DocTraDesc);
                            }
                        }
                    }
                    else if (dataType == DataSourceType.ScrapItem)
                    {
                        MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                        param.Token = ClientApplication.Instance.Token;
                        param.Value = string.Format(@"SELECT it.item_id,it.item_name,it.item_code,it.unit_id,un.unit_code FROM invd_item it LEFT JOIN invd_unit un ON it.unit_id = un.unit_id
WHERE it.item_code LIKE '{0}%' AND it.item_code LIKE 'H90%'
ORDER BY it.item_name", code);
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
                                {
                                    invd_item item = new invd_item();
                                    item.item_id = Convert.ToInt32(res.Value.Rows[0][0]);
                                    item.item_name = res.Value.Rows[0][1].ToString();
                                    item.item_code = res.Value.Rows[0][2].ToString();
                                    item.unit_id = Convert.ToInt32(res.Value.Rows[0][3]);
                                    item.unit_code = res.Value.Rows[0][4].ToString();
                                    this.selectedObject = item;
                                    SetFields(item.item_code, item.item_name);
                                }
                            }
                        }
                    }
                    else if (dataType == DataSourceType.Cari)
                    {
                        MobileWhouse.UyumConnector.ServiceRequestOfCoEntityMParam param = new MobileWhouse.UyumConnector.ServiceRequestOfCoEntityMParam();
                        param.Token = ClientApplication.Instance.Token;
                        param.Value = new MobileWhouse.UyumConnector.CoEntityMParam();
                        param.Value.PageSize = 9999;
                        param.Value.StartWith = true;
                        param.Value.EntityCode = code;

                        MobileWhouse.UyumConnector.ServiceResultOfListOfCoEntityInfo res = ClientApplication.Instance.Service.GetCoEntityInfo(param);
                        if (res != null)
                        {
                            if (res.Result == false)
                            {
                                Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                            }
                            else
                            {
                                this.selectedObject = res.Value[0];
                                SetFields(res.Value[0].EntityCode, res.Value[0].EntityName);
                            }
                        }
                    }
                    else if (dataType == DataSourceType.Uretim_IsEmri_Istasyon)
                    {
                        MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                        param.Token = ClientApplication.Instance.Token;
                        param.Value = string.Format(@"SELECT ac.wstation_id,ws.wstation_code,ws.description,ws.wcenter_id,wc.wcenter_code,wc.description wcenter_desc,
ws.mtr_output_whouse_id,mtr_wh.whouse_code mtr_output_whouse_code,ws.prd_input_doc_tra_id,tr.doc_tra_code prd_input_doc_tra_code
FROM zz_worder_ac_op ac INNER JOIN prdd_wstation ws ON ac.wstation_id = ws.wstation_id LEFT JOIN 
prdt_worder_m m ON ac.worder_m_id = m.worder_m_id LEFT JOIN 
prdd_wcenter wc ON ws.wcenter_id = wc.wcenter_id LEFT JOIN 
invd_whouse mtr_wh ON ws.mtr_output_whouse_id = mtr_wh.whouse_id LEFT JOIN gnld_doc_tra tr ON ws.prd_input_doc_tra_id = tr.doc_tra_id
WHERE m.worder_no LIKE '{0}' OR ws.wstation_code = '{0}' LIMIT 1", code);
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
                                {
                                    MobileWhouse.ProdConnector.PrdGobalInfo inf = new MobileWhouse.ProdConnector.PrdGobalInfo();
                                    inf.PrdGobalId = Convert.ToInt32(res.Value.Rows[0][0]);
                                    inf.PrdGobalCode = res.Value.Rows[0][1].ToString();
                                    inf.PrdGobalName = res.Value.Rows[0][2].ToString();
                                    inf.PrdGobalId2 = Convert.ToInt32(res.Value.Rows[0][3]);
                                    inf.PrdGobalCode2 = res.Value.Rows[0][4].ToString();
                                    inf.PrdGobalName2 = res.Value.Rows[0][5].ToString();
                                    inf.PrdGobalId3 = Convert.ToInt32(res.Value.Rows[0][6]);
                                    inf.PrdGobalCode3 = res.Value.Rows[0][7].ToString();
                                    inf.PrdGobalId4 = Convert.ToInt32(res.Value.Rows[0][8]);
                                    inf.PrdGobalCode4 = res.Value.Rows[0][9].ToString();

                                    this.selectedObject = inf;
                                    SetFields(inf.PrdGobalCode, inf.PrdGobalName);
                                }
                            }
                        }
                    }
                    if (this.selectedObject != null && OnSelected != null)
                    {
                        OnSelected(this, this.selectedObject);
                    }
                }
                catch (Exception exception)
                {
                    Screens.Error(exception);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    textkod.Focus();
                    textkod.SelectAll();
                }

                this.OnKeyPress(e);
            }
            else if (e.KeyChar == '\'')
            {
                e.Handled = true;
                this.textkod.Text = this.textkod.Text + "`";
            }
        }

        private void textkod_GotFocus(object sender, EventArgs e)
        {
            if (!Utility.IsDesignMode)
                Screens.ShowKeyboard(true);
        }

        private void textkod_LostFocus(object sender, EventArgs e)
        {
            this.OnLostFocus(e);
            if (!Utility.IsDesignMode)
                Screens.ShowKeyboard(false);

        }

        private void MTALookupEdit_Click(object sender, EventArgs e)
        {
            Screens.ShowKeyboard(false);
        }

        private void ULookupEdit_ParentChanged(object sender, EventArgs e)
        {
            if (!Utility.IsDesignMode)
            {
                if (!onload)
                {
                    this.timerLoader = new System.Windows.Forms.Timer();
                    this.timerLoader.Interval = 200;
                    this.timerLoader.Enabled = true;
                    this.timerLoader.Tick += new System.EventHandler(this.timerLoader_Tick);
                }
            }
        }

        private void timerLoader_Tick(object sender, EventArgs e)
        {
            if (!this.Name.Equals("ULookupEdit", StringComparison.Ordinal))
            {
                timerLoader.Enabled = false;
                onload = true;
                ResaiseControls();
                if (RememberValue)
                {
                    //string selectedDepot = FileHelper.ReadFile(this.Name);
                    //if (!string.IsNullOrEmpty(selectedDepot))
                    //{
                    //    this.selectedObject = FileHelper.FromXml(selectedDepot, typeof(MobileWhouse.UyumConnector.DocTra));

                    //}

                    string kod = AppCache.ReadCache(this.Name, "");
                    if (!string.IsNullOrEmpty(kod))
                    {
                        textkod.Text = kod;
                        OnPress();
                    }
                }
                timerLoader.Dispose();
                timerLoader = null;
            }
        }

        private void btnk_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textkod);
        }
    }

}
