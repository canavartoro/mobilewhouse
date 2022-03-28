using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Util;
using MobileWhouse.Data;

namespace MobileWhouse.Models
{
    internal class MobileParameter
    {
        public MobileParameter() { }

        private int _paramater_id = 0;
        public int paramater_id
        {
            get { return _paramater_id; }
            set { _paramater_id = value; }
        }

        private int _bloke_doc_tra_id = 0;
        public int bloke_doc_tra_id
        {
            get { return _bloke_doc_tra_id; }
            set { _bloke_doc_tra_id = value; }
        }

        private string _bloke_doc_tra_code = "";
        public string bloke_doc_tra_code
        {
            get { return _bloke_doc_tra_code; }
            set { _bloke_doc_tra_code = value; }
        }

        private int _bloke_whouse_id = 0;
        public int bloke_whouse_id
        {
            get { return _bloke_whouse_id; }
            set { _bloke_whouse_id = value; }
        }

        private string _bloke_whouse_code = "";
        public string bloke_whouse_code
        {
            get { return _bloke_whouse_code; }
            set { _bloke_whouse_code = value; }
        }

        private int _etiket_sure_limit = 0;
        public int etiket_sure_limit
        {
            get { return _etiket_sure_limit; }
            set { _etiket_sure_limit = value; }
        }

        private int _etiket_adet_limit = 0;
        public int etiket_adet_limit
        {
            get { return _etiket_adet_limit; }
            set { _etiket_adet_limit = value; }
        }

        private string _ambalaj_profix = "";
        public string ambalaj_profix
        {
            get { return _ambalaj_profix; }
            set { _ambalaj_profix = value; }
        }

        private string _palet_profix = "";
        public string palet_profix
        {
            get { return _palet_profix; }
            set { _palet_profix = value; }
        }

        private string _malkabul_prefix = "";
        public string malkabul_prefix
        {
            get { return _malkabul_prefix; }
            set { _malkabul_prefix = value; }
        }

        public static MobileParameter GetMobileParameter()
        {
            MobileParameter mobilparam = null;
            try
            {
                Screens.ShowWait();

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = @"SELECT prm.paramater_id,prm.bloke_doc_tra_id,blktr.doc_tra_code bloke_doc_tra_code,
prm.bloke_whouse_id,blkwh.whouse_code bloke_whouse_code,prm.etiket_sure_limit,prm.etiket_adet_limit,prm.ambalaj_profix,prm.palet_profix,prm.malkabul_prefix 
FROM ""uyumsoft"".""zapd_mobile_parameters"" prm LEFT JOIN 
uyumsoft.gnld_doc_tra blktr ON prm.bloke_doc_tra_id = blktr.doc_tra_id LEFT JOIN
uyumsoft.invd_whouse blkwh ON prm.bloke_whouse_id = blkwh.whouse_id ORDER BY 1 DESC LIMIT 1 ";
                MobileWhouse.UyumConnector.ServiceResultOfDataTable worderMInfo = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (worderMInfo.Result && worderMInfo.Value != null && worderMInfo.Value.Rows.Count > 0)
                {
                    mobilparam = (MobileParameter)DataProvider.TableToObject(worderMInfo.Value, typeof(MobileParameter));
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
            return mobilparam;
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
  "ambalaj_profix" varchar(3) COLLATE "pg_catalog"."default",
  "palet_profix" varchar(3) COLLATE "pg_catalog"."default",
  "malkabul_prefix" varchar(3) COLLATE "pg_catalog"."default",
  CONSTRAINT "zapd_mobile_parameters_pkey" PRIMARY KEY ("paramater_id")
)
;

ALTER TABLE "uyumsoft"."zapd_mobile_parameters" 
  OWNER TO "uyum";
 */