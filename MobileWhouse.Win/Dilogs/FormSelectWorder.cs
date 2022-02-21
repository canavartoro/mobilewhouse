using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.ProdConnector;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectWorder : Form
    {
        public FormSelectWorder()
        {
            InitializeComponent();
        }

        private WorderMInfo worderM = null;
        public WorderMInfo WorderM
        {
            get { return worderM; }
        }

        private void Ara()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ServiceRequestOfWorderMParam param = new ServiceRequestOfWorderMParam();
                param.Token = ClientApplication.Instance.ProdToken;
                param.PageSize = 9999;
                param.Value = new WorderMParam();
                param.Value.PageSize = 9999;
                if (!string.IsNullOrEmpty(txtisemri.Text))
                    param.Value.WorderNo = txtisemri.Text;

                if (!string.IsNullOrEmpty(txtstokkod.Text))
                    param.Value.ItemCode = txtstokkod.Text;

                ServiceResultOfListOfWorderMInfo res = ClientApplication.Instance.ProdService.GetWorderMInfo(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        listView1.BeginUpdate();
                        listView1.Items.Clear();
                        for (int i = 0; i < res.Value.Length; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = res.Value[i].WorderNo.ToString();
                            item.SubItems.Add(res.Value[i].ItemCode);
                            item.SubItems.Add(res.Value[i].ItemName);
                            item.SubItems.Add(res.Value[i].UnitCode);
                            item.SubItems.Add(res.Value[i].Qty.ToString("#.###"));
                            item.SubItems.Add(res.Value[i].WoOpenDate.ToString("dd.MM.yyyy"));
                            item.Tag = res.Value[i];
                            listView1.Items.Add(item);
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
                listView1.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void txtisemri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Ara();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnsec_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                worderM = listView1.Items[listView1.SelectedIndices[0]].Tag as WorderMInfo;
                if (worderM != null)
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            btnsec_Click(btnsec, EventArgs.Empty);
        }
    }
}
