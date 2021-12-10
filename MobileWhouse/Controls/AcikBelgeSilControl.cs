using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Controls
{
    public partial class AcikBelgeSilControl : BaseControl
    {
        public AcikBelgeSilControl()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnAcikDepo_Click(object sender, EventArgs e)
        {
            if (!MobileWhouse.Util.Screens.Question("Açık Depoiçi Raf Hareketleri silinsin mi ?"))
            {
                MobileWhouse.Util.Screens.Info("İşlem iptal edildi...");
                return;
            }
            
            try
            {
                ServiceRequestOfInt32 param = new ServiceRequestOfInt32();
                param.Token = ClientApplication.Instance.Token;
                param.Value = ClientApplication.Instance.ClientToken.UserId;

                ServiceResultOfBoolean result = ClientApplication.Instance.Service.AcikDepoRafSil(param);

                if (!result.Result)
                {
                    throw new Exception(result.Message);
                }
                MobileWhouse.Util.Screens.Info("İşlem başarıyla tamamlandı...");

            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }
    }
}
