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
using MobileWhouse.Util;

namespace MobileWhouse.Controls
{
    public partial class SelectSayimType : BaseControl
    {
        private Depot _Depot;

        public SelectSayimType()
        {
            InitializeComponent();
        }

        public SelectSayimType(Depot depot)
        {
            InitializeComponent();
            _Depot = depot;
        }

        private void mnNewSayim_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32();
                param.Token = ClientApplication.Instance.Token;
                param.Value = _Depot.Id;

                ServiceResultOfRafSayimFisi result = ClientApplication.Instance.Service.InsertRafSayimFisi(param);
                if (result.Result)
                {
                    MainForm.ShowControl(new SayimControl(result.Value, false));
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
        }

        private void mnContinueSayim_Click(object sender, EventArgs e)
        {
            using (FormSelectSayim form = new FormSelectSayim(_Depot))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.Selected != null)
                    {
                        MainForm.ShowControl(new SayimControl(form.Selected, true));
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnambsayim_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new SayimPackageControl());
        }
    }
}
