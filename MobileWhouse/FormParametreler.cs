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
                    s.AppendFormat(@"UPDATE ""uyumsoft"".""zapd_mobile_parameters"" SET ""bloke_doc_tra_id"" = '{0}',""bloke_whouse_id"" = '{1}',""etiket_sure_limit"" = '{3}',""etiket_adet_limit"" = '{4}',""ambalaj_profix""='{5}',""palet_profix""='{6}',""malkabul_prefix""='{7}' WHERE ""paramater_id"" = '{2}'",
                        docTra.Id, depo.Id, mobileParam.paramater_id, Convert.ToInt32(numetiketsurelimit.Value), Convert.ToInt32(numetiketadetlimit.Value), textAmbPrefix.Text, textPltPrefix.Text, textMalPrefix.Text);
                }
                else
                {
                    s.AppendFormat(@"INSERT INTO ""uyumsoft"".""zapd_mobile_parameters"" (""bloke_doc_tra_id"",""bloke_whouse_id"",""etiket_sure_limit"",""etiket_adet_limit"",""ambalaj_profix"",""palet_profix"",""malkabul_prefix"") VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                        docTra.Id, depo.Id, Convert.ToInt32(numetiketsurelimit.Value), Convert.ToInt32(numetiketadetlimit.Value), textAmbPrefix.Text, textPltPrefix.Text, textMalPrefix.Text);
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
                    numetiketsurelimit.Value = mobileParam.etiket_sure_limit;
                    numetiketadetlimit.Value = mobileParam.etiket_adet_limit;
                    textAmbPrefix.Text = mobileParam.ambalaj_profix;
                    textPltPrefix.Text = mobileParam.palet_profix;
                    textMalPrefix.Text = mobileParam.malkabul_prefix;
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


/*
CREATE SEQUENCE "uyumsoft"."zapd_mobile_parameters_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zapd_mobile_parameters_id_seq"', 1, true);

ALTER SEQUENCE "uyumsoft"."zapd_mobile_parameters_id_seq" OWNER TO "uyum";
 CREATE TABLE "uyumsoft"."zapd_mobile_parameters" (
  "paramater_id" int4 NOT NULL DEFAULT nextval('zapd_mobile_parameters_id_seq'::regclass),
  "bloke_doc_tra_id" int4,
  "bloke_whouse_id" int4,
  "etiket_sure_limit" int4,
  "etiket_adet_limit" int4,
  CONSTRAINT "zapd_mobile_parameters_pkey" PRIMARY KEY ("paramater_id")
)
;

ALTER TABLE "uyumsoft"."zapd_mobile_parameters" 
  OWNER TO "uyum";
 */