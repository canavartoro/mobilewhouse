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

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectItem : Form
    {
        public ItemWithName Selected
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && lvwStok.SelectedIndices.Count > 0)
                {
                    return lvwStok.Items[lvwStok.SelectedIndices[0]].Tag as ItemWithName;
                }
                return null;
            }
        }

        public FormSelectItem()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new SelectParam();
                param.Value.Filter = txtName.Text.Trim();
                if (ClientApplication.Instance.SelectedDepot != null)
                    param.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;

                ServiceResultOfListOfItemWithName items = ClientApplication.Instance.Service.GetStoklar(param);
                lvwStok.BeginUpdate();

                lvwStok.Items.Clear();
                for (int i = 0; i < items.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = items.Value[i].Id.ToString();
                    item.SubItems.Add(items.Value[i].Name);
                    item.SubItems.Add(items.Value[i].Description);
                    item.Tag = items.Value[i];
                    lvwStok.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                lvwStok.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
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