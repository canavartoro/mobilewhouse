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
    public partial class FormSelectSayim : Form
    {
        public RafSayimFisi Selected
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && lvwItems.SelectedIndices.Count > 0)
                {
                    return lvwItems.Items[lvwItems.SelectedIndices[0]].Tag as RafSayimFisi;
                }
                return null;
            }
        }

        private Depot _Depot;

        public FormSelectSayim()
        {
            InitializeComponent();
        }

        public FormSelectSayim(Depot depot)
        {
            InitializeComponent();
            _Depot = depot;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _LoadSayimFisleri();
        }

        private void _LoadSayimFisleri()
        {
            try {
                lvwItems.BeginUpdate();
                ServiceRequestOfInt32 req = new ServiceRequestOfInt32();
                req.Token = ClientApplication.Instance.Token;
                req.Value = _Depot.Id ;

                ServiceResultOfListOfRafSayimFisi response = ClientApplication.Instance.Service.GetRafSayimlari(req);
                if (!response.Result)
                {
                    throw new Exception(response.Message);
                }

                lvwItems.Items.Clear();
                for (int i = 0; i < response.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = response.Value[i].DocNo;
                    item.SubItems.Add(response.Value[i].DepoCode);
                    item.SubItems.Add(response.Value[i].Date.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(response.Value[i].User);
                    item.Tag = response.Value[i];
                    lvwItems.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally {
                lvwItems.EndUpdate();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}