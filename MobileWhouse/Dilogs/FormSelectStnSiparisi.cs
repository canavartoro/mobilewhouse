using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UTermConnector;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectStnSiparisi : Form
    {
        public OrderMInfo Selected
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && lvwItems.SelectedIndices.Count > 0)
                {
                    return lvwItems.Items[lvwItems.SelectedIndices[0]].Tag as OrderMInfo;
                }
                return null;
            }

        }

        private Depot _Depot;

        public FormSelectStnSiparisi()
        {
            InitializeComponent();
            btnIrsaliye.Visible = true;
            btnSelect.Visible = false;
        }

        public FormSelectStnSiparisi(Depot depot)
        {
            InitializeComponent();
            _Depot = depot;
            if (_Depot == null)
            {
                btnSelect.Visible = false ;
                btnIrsaliye.Visible = true ;
            }
            else
            {
                btnSelect.Visible = true;
                btnIrsaliye.Visible = false ;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _LoadData();
        }

        private void _LoadData()
        {
            try
            {
                lvwItems.BeginUpdate();
                lvwItems.Items.Clear();

                ServiceRequestOfOrderMParam param = new ServiceRequestOfOrderMParam();
                param.Token = ClientApplication.Instance.UTermToken;
                param.Value = new  OrderMParam();
                param.Value.PurchaseSales = 1;
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.PageSize = 500;

                ServiceResultOfListOfOrderMInfo orderMInfo = ClientApplication.Instance.UTermService.GetOrderMInfo(param);
                if (!orderMInfo.Result)
                {
                    throw new Exception(orderMInfo.Message);
                }

                for (int i = 0; i < orderMInfo.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = orderMInfo.Value[i];
                    item.Text = orderMInfo.Value[i].DocDate.ToString("dd/MM/yy");
                    item.SubItems.Add(orderMInfo.Value[i].DocNo);
                    item.SubItems.Add(orderMInfo.Value[i].EntityName);
                    item.SubItems.Add(orderMInfo.Value[i].DeliveryDate.ToString("dd/MM/yy"));
                    item.SubItems.Add(orderMInfo.Value[i].SalesPersonName);
                    item.SubItems.Add(orderMInfo.Value[i].Id.ToString());
                    item.SubItems.Add(orderMInfo.Value[i].DocTraId.ToString());

                    lvwItems.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                lvwItems.EndUpdate();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dateP_ValueChanged(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void eName_TextChanged(object sender, EventArgs e)
        {
            //if (eName.Text.Length > 2)
            //{
                _LoadData();
            //}
        }
    }
}