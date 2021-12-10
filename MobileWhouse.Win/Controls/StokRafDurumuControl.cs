using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Controls
{
    public partial class StokRafDurumuControl : BaseControl
    {
        public StokRafDurumuControl()
        {
            InitializeComponent();

            txtItemCode.DepoId = txtLocationCode.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            txtLocationCode.Text = raf.Name;
            btnListele_Click(btnListele, EventArgs.Empty);
            txtItemCode.Focus();
        }

        public override void OnItemBarkod(ItemInfo item)
        {
            txtItemCode.Text = item.Name;
            btnListele_Click(btnListele, EventArgs.Empty);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {            
            try
            {
                ServiceRequestOfStokRafSelectParam param = new ServiceRequestOfStokRafSelectParam();

                param.Token = ClientApplication.Instance.Token;
                param.Value = new StokRafSelectParam();
                param.Value.LocationCode = txtLocationCode.Text.Trim();
                param.Value.ItemCode = txtItemCode.Text.Trim();
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;

                ServiceResultOfListOfStokRafInfo infos = ClientApplication.Instance.Service.GetStokRafInfo(param);
                
                lvwInfos.BeginUpdate();

                lvwInfos.Items.Clear();

                for (int i = 0; i < infos.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = infos.Value[i].ItemCode;
                    item.SubItems.Add(infos.Value[i].ItemName);
                    item.SubItems.Add(infos.Value[i].Qty.ToString());
                    item.SubItems.Add(infos.Value[i].UnitCode);
                    item.SubItems.Add(infos.Value[i].LocationCode);

                    item.Tag = infos.Value[i];

                    lvwInfos.Items.Add(item);

                }

            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwInfos.EndUpdate();
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnShowItem_Click(object sender, EventArgs e)
        {
            using (FormSelectItem form = new FormSelectItem())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.Selected != null)
                    {
                        txtItemCode.Text = form.Selected.Name;
                    }
                }
            }
        }

        private void btnShowRaf_Click(object sender, EventArgs e)
        {
            using (FormSelectRaf form = new FormSelectRaf(ClientApplication.Instance.SelectedDepot))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.Selected != null)
                    {
                        txtLocationCode.Text = form.Selected.Name;
                    }
                }
            }
        }
    }
}
