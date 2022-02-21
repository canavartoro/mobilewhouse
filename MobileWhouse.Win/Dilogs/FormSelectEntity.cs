using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectEntity : Form
    {
        public FormSelectEntity()
        {
            InitializeComponent();
        }

        private CoEntityInfo entityInfo = null;
        public CoEntityInfo EntityInfo
        {
            get { return entityInfo; }
        }

        private void Ara()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ServiceRequestOfCoEntityMParam param = new ServiceRequestOfCoEntityMParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new CoEntityMParam();
                param.Value.PageSize = 9999;
                param.Value.StartWith = true;
                
                if (!string.IsNullOrEmpty(txtkod.Text))
                    param.Value.EntityCode = txtkod.Text;

                if (!string.IsNullOrEmpty(txtad.Text))
                    param.Value.EntityName = txtad.Text;

                ServiceResultOfListOfCoEntityInfo res = ClientApplication.Instance.Service.GetCoEntityInfo(param);
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
                            item.Text = res.Value[i].EntityCode.ToString();
                            item.SubItems.Add(res.Value[i].EntityName);
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
                entityInfo = listView1.Items[listView1.SelectedIndices[0]].Tag as CoEntityInfo;
                if (entityInfo != null)
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