using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Data;
using MobileWhouse.Models;

namespace MobileWhouse
{
    public partial class FormParametreler : Form
    {
        public FormParametreler()
        {
            InitializeComponent();
        }

        MobileParameter mobileParam = null;

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                MobileWhouse.UyumConnector.Depot depo = secblokedepo.SelectedObject as MobileWhouse.UyumConnector.Depot;
                MobileWhouse.UyumConnector.DocTra docTra = secblokehareket.SelectedObject as MobileWhouse.UyumConnector.DocTra;
                if (depo == null)
                {
                    Screens.Error("Bloke depo seçilmedi!");
                    return;
                }
                if (docTra == null)
                {
                    Screens.Error("Bloke hareket seçilmedi!");
                    return;
                }

                if (!Screens.Question("Parametre bilgileri kaydedilsin mi?")) return;

                Screens.ShowWait();

                StringBuilder s = new StringBuilder();
                if (mobileParam != null && mobileParam.paramater_id > 0)
                {
                    s.AppendFormat(@"UPDATE ""uyumsoft"".""zapd_mobile_parameters"" SET ""bloke_doc_tra_id"" = '{0}',""bloke_whouse_id"" = '{1}' WHERE ""paramater_id"" = '{2}'",
                        docTra.Id, depo.Id, mobileParam.paramater_id);
                }
                else
                {
                    s.AppendFormat(@"INSERT INTO ""uyumsoft"".""zapd_mobile_parameters"" (""bloke_doc_tra_id"",""bloke_whouse_id"") VALUES ('{0}','{1}')", docTra.Id, depo.Id);
                }

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = s.ToString();
                MobileWhouse.UyumConnector.ServiceResultOfDataTable worderMInfo = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (worderMInfo.Result)
                {
                    Screens.Info("Bilgiler kaydedildi");
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Screens.HideWait();
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormParametreler_Load(object sender, EventArgs e)
        {
            try
            {
                mobileParam = MobileParameter.GetMobileParameter();
                if (mobileParam != null)
                {
                    secblokedepo.SetText(mobileParam.bloke_whouse_code);
                    secblokehareket.SetText(mobileParam.bloke_doc_tra_code);
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Screens.HideWait();
            }
        }
    }
}