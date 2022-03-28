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
    public partial class FormSelectSevkiyat : Form
    {
        public SevkiyatInfo Selected
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && lvwItems.SelectedIndices.Count > 0)
                {
                    return lvwItems.Items[lvwItems.SelectedIndices[0]].Tag as SevkiyatInfo;
                }
                return null;
            }

        }

        private Depot _Depot;

        public FormSelectSevkiyat()
        {
            InitializeComponent();
            btnIrsaliye.Visible = true;
            btnSelect.Visible = false;
        }

        public FormSelectSevkiyat(Depot depot)
        {
            InitializeComponent();
            _Depot = depot;
            if (_Depot == null)
            {
                btnSelect.Visible = false;
                btnIrsaliye.Visible = true;
            }
            else
            {
                btnSelect.Visible = true;
                btnIrsaliye.Visible = false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _LoadSevkEmirleri();
        }

        private void _LoadSevkEmirleri()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                lvwItems.BeginUpdate();
                lvwItems.Items.Clear();

                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new SelectParam();
                if (_Depot != null)
                {
                    param.Value.DepotId = _Depot.Id;
                    //param.Value.SearchDate = dateP.Value;
                    param.Value.SearchEntity = eName.Text;
                }
                else
                {
                    //param.Value.SearchDate = dateP.Value;
                    param.Value.SearchEntity = eName.Text;
                }

                ServiceResultOfListOfSevkiyatInfo sevkler = ClientApplication.Instance.Service.GetSevkiyatlar(param);
                if (!sevkler.Result)
                {
                    throw new Exception(sevkler.Message);
                }

                for (int i = 0; i < sevkler.Value.Length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = sevkler.Value[i];
                    item.Text = sevkler.Value[i].SevkEmriNo;
                    item.SubItems.Add(sevkler.Value[i].Client);
                    item.SubItems.Add(sevkler.Value[i].IsProcess.ToString());

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
                Cursor.Current = Cursors.Default;
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
            _LoadSevkEmirleri();
        }

        private void eName_TextChanged(object sender, EventArgs e)
        {
            //if (eName.Text.Length > 2)
            //{
            _LoadSevkEmirleri();
            //}
        }

        private void lvwItems_ItemActivate(object sender, EventArgs e)
        {
            if (lvwItems.SelectedIndices.Count > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}