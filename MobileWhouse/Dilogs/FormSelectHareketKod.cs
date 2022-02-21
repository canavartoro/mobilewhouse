using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Util;
using MobileWhouse.Data;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectHareketKod : Form
    {
        private int _SourceApplication = 0;
        public int SourceApplication
        {
            get { return _SourceApplication; }
            set { _SourceApplication = value; }
        }
        private int _purchase_sales = -1;
        public int PurchaseSales
        {
            get { return _purchase_sales; }
            set { _purchase_sales = value; }
        }

        public DocTra Selected
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && lswDocTra.SelectedIndices.Count > 0)
                {
                    return lswDocTra.Items[lswDocTra.SelectedIndices[0]].Tag as DocTra;
                }
                return null;
            }
        }

        public FormSelectHareketKod()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnSearch_Click(this, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_SourceApplication == 0)
                {

                    ServiceRequestOfDocTraSelectParam param = new ServiceRequestOfDocTraSelectParam();
                    param.Token = ClientApplication.Instance.Token;
                    param.Value = new DocTraSelectParam();
                    param.Value.DocTraCodeFilter = txtDocTraCode.Text;
                    param.Value.BranchId = ClientApplication.Instance.Token.BranchId;
                    param.Value.CoId = ClientApplication.Instance.Token.CoId;
                    param.Value.SourceApplication = _SourceApplication;

                    ServiceResultOfListOfDocTra docTras = ClientApplication.Instance.Service.GetDocTras(param);
                    if (!docTras.Result)
                    {
                        Screens.Error(docTras.Message);
                        return;
                    }
                    lswDocTra.BeginUpdate();
                    lswDocTra.Items.Clear();
                    for (int i = 0; i < docTras.Value.Length; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = docTras.Value[i].Id.ToString();
                        item.SubItems.Add(docTras.Value[i].DocTraCode);
                        item.SubItems.Add(docTras.Value[i].DocTraDesc);
                        item.Tag = docTras.Value[i];
                        lswDocTra.Items.Add(item);
                    }
                }
                else
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(string.Concat(@"SELECT DESCRIPTION ""DocTraDesc"", DOC_TRA_ID ""Id"",  DOC_TRA_CODE ""DocTraCode"", INVENTORY_STATUS ""Status"" FROM GNLD_DOC_TRA WHERE GNLD_DOC_TRA.SOURCE_APP = ", _SourceApplication));
                    if (_purchase_sales > 0)
                        sql.Append(" AND GNLD_DOC_TRA.PURCHASE_SALES = ").Append(_purchase_sales);

                    ServiceRequestOfString param = new ServiceRequestOfString();
                    param.Token = ClientApplication.Instance.Token;
                    param.Value = sql.ToString();

                    ServiceResultOfDataTable restbl = ClientApplication.Instance.Service.ExecuteSQL(param);
                    if (!restbl.Result)
                    {
                        Screens.Error(restbl.Message);
                        return;
                    }

                    List<DocTra> doctralist = DataProvider.TableToList(restbl.Value, typeof(DocTra)) as List<DocTra>;
                    if (doctralist != null)
                    {
                        lswDocTra.BeginUpdate();
                        lswDocTra.Items.Clear();
                        for (int i = 0; i < doctralist.Count; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = doctralist[i].Id.ToString();
                            item.SubItems.Add(doctralist[i].DocTraCode);
                            item.SubItems.Add(doctralist[i].DocTraDesc);
                            item.Tag = doctralist[i];
                            lswDocTra.Items.Add(item);
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
                lswDocTra.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}