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
    public partial class FormSelectDepot : Form
    {
        public Depot Selected
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

        //bu depoya eşit olmayan depolar gelsin.
        public int DepotId { get; set; }
        public bool _OnlyWithLocation = true;

        public FormSelectDepot()
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
                ServiceRequestOfDepotSelectParam param = new ServiceRequestOfDepotSelectParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new DepotSelectParam();
                param.Value.DescriptionFilter = txtName.Text.Trim();
                param.Value.OnlyWithLocation = false;
                param.Value.NotEqualDepotId = DepotId;

                ServiceResultOfListOfDepot depots = ClientApplication.Instance.Service.GetDepots(param);
                lvwDepots.BeginUpdate();

                lvwDepots.Items.Clear();
                for (int i = 0; i < depots.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    //item.Text = depots.Value[i].Id.ToString();
                    //item.SubItems.Add(depots.Value[i].Code);
                    //item.SubItems.Add(depots.Value[i].Name);
                    item.Text = depots.Value[i].Code;
                    item.SubItems.Add(depots.Value[i].Name);
                    item.SubItems.Add(depots.Value[i].Id.ToString());
                    item.Tag = depots.Value[i];
                    lvwDepots.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwDepots.EndUpdate();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvwDepots.SelectedIndices.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvwDepots_ItemActivate(object sender, EventArgs e)
        {
            if (lvwDepots.SelectedIndices.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}