using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MobileWhouse.Models;
using MobileWhouse.Data;
using MobileWhouse.Log;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectScrapItem : Form
    {
        public FormSelectScrapItem()
        {
            InitializeComponent();
        }

        private invd_item item = null;
        public invd_item Item
        {
            get { return item; }
        }

        private void GetItems()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = @"SELECT it.item_id,it.item_name,it.item_code,it.unit_id,un.unit_code FROM invd_item it LEFT JOIN invd_unit un ON it.unit_id = un.unit_id
WHERE it.item_code LIKE 'H90%'
ORDER BY it.item_name";
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
                        List<invd_item> list = DataProvider.TableToList(res.Value, typeof(invd_item)) as List<invd_item>;
                        if (list != null && list.Count > 0)
                        {
                            listView1.BeginUpdate();

                            for (int i = 0; i < list.Count; i++)
                            {
                                ListViewItem _item = new ListViewItem();
                                _item.Text = (i + 1).ToString();
                                _item.Tag = list[i];
                                _item.SubItems.Add(list[i].item_name);
                                _item.SubItems.Add(list[i].item_code);
                                listView1.Items.Add(_item);
                            }
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

        private void FormSelectScrapItem_Load(object sender, EventArgs e)
        {
            GetItems();
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
                item = listView1.Items[listView1.SelectedIndices[0]].Tag as invd_item;

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            btnsec_Click(btnsec, EventArgs.Empty);
        }
    }
}