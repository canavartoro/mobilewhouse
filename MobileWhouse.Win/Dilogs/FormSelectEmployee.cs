using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.ProdConnector;
using MobileWhouse.Util;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectEmployee : Form
    {
        public FormSelectEmployee()
        {
            InitializeComponent();
        }

        private PrdGobalInfo employee = null;
        public PrdGobalInfo Employee
        {
            get { return employee; }
        }

        private int wstationId = 0;
        public int WstationId
        {
            get { return wstationId; }
            set { wstationId = value; }
        }

        private void Ara()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ServiceRequestOfPrdGobalParam param = new ServiceRequestOfPrdGobalParam();
                param.Token = ClientApplication.Instance.ProdToken;
                param.PageSize = 9999;
                param.Value = new PrdGobalParam();
                param.Value.PageSize = 9999;
                param.Value.PrdGobalType = 11; //IsIstasyonundaPersonel
                param.Value.PrdGobalId = wstationId;
                if (!string.IsNullOrEmpty(txtisemri.Text))
                    param.Value.PrdGobalCode = txtisemri.Text;

                if (!string.IsNullOrEmpty(txtstokkod.Text))
                    param.Value.PrdGobalName = txtstokkod.Text;

                ServiceResultOfListOfPrdGobalInfo res = ClientApplication.Instance.ProdService.GetPrdGobalInfo(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        listView1.BeginUpdate();
                        listView1.Items.Clear();
                        for (int i = 0; i < res.Value.Length; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = res.Value[i].PrdGobalId.ToString();
                            item.SubItems.Add(res.Value[i].PrdGobalName);
                            item.SubItems.Add(res.Value[i].PrdGobalName2);
                            item.SubItems.Add(res.Value[i].PrdGobalCode2);
                            item.SubItems.Add(res.Value[i].PrdGobalCode3);
                            item.Tag = res.Value[i];
                            listView1.Items.Add(item);
                        }
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
                employee = listView1.Items[listView1.SelectedIndices[0]].Tag as PrdGobalInfo;
                if (employee != null)
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