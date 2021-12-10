using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectItemPicking : Form
    {
        public Depot SelectedItemPicking
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && lvwDepots.SelectedIndices.Count > 0)
                {
                 return lvwDepots.Items[lvwDepots.SelectedIndices[0]].Tag as Depot;
                }
                return null;
            }
        }

        public FormSelectItemPicking()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfDepotSelectParam param = new ServiceRequestOfDepotSelectParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new DepotSelectParam();
                param.Value.DescriptionFilter = txtName.Text.Trim();
                param.Value.OnlyWithLocation = true;

                ServiceResultOfListOfDepot depots = ClientApplication.Instance.Service.GetDepots(param);
                lvwDepots.BeginUpdate();

                lvwDepots.Items.Clear();
                for (int i = 0; i < depots.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = depots.Value[i].Id.ToString();
                    item.SubItems.Add(depots.Value[i].Name);
                    item.Tag = depots.Value[i];
                    lvwDepots.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                ClientApplication.ShowError(ex);
            }
            finally
            {
                lvwDepots.EndUpdate();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}