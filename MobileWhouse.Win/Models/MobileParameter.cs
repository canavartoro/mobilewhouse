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

        public static MobileParameter GetMobileParameter()
        {
            MobileParameter mobilparam = null;
            try
            {
                Screens.ShowWait();

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = @"SELECT prm.paramater_id,prm.bloke_doc_tra_id,blktr.doc_tra_code bloke_doc_tra_code,
prm.bloke_whouse_id,blkwh.whouse_code bloke_whouse_code
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
