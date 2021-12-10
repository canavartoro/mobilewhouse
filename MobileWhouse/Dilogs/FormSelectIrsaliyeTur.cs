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
    public partial class FormSelectIrsaliyeTur : Form
    {
        public ItemWithName Selected
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && lvwDepots.SelectedIndices.Count > 0)
                {
                    return lvwDepots.Items[lvwDepots.SelectedIndices[0]].Tag as ItemWithName;
                }
                return null;
            }
        }

        public FormSelectIrsaliyeTur()
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
                ServiceRequestOfBoolean param = new ServiceRequestOfBoolean();
                param.Token = ClientApplication.Instance.Token;
                

                ServiceResultOfListOfItemWithName turs = ClientApplication.Instance.Service.GetIrsaliyeTurleri(param);
                if (!turs.Result)
                    throw new Exception(turs.Message);
                lvwDepots.BeginUpdate();

                lvwDepots.Items.Clear();
                for (int i = 0; i < turs.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = turs.Value[i].Id.ToString();
                    item.SubItems.Add(turs.Value[i].Name);
                    item.SubItems.Add(turs.Value[i].Description);
                    item.Tag = turs.Value[i];
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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}