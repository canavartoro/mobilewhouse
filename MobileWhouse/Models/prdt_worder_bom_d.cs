using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using MobileWhouse.Data;
using MobileWhouse.Log;

namespace MobileWhouse.Models
{
    public class prdt_worder_bom_d
    {
        public prdt_worder_bom_d() { }

        public int ITEM_ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public int WORDER_BOM_D_ID { get; set; }
        public int WORDER_M_ID { get; set; }
        public int ITEM_BOM_M_ID { get; set; }
        public int UNIT_ID { get; set; }
        public string UNIT_CODE { get; set; }
        public decimal QTY_BASE_BOM { get; set; }
        public decimal QTY_REMAIN { get; set; }
        public decimal QTY_READ { get; set; }
        public int WHOUSE_ID { get; set; }
        public int LINE_NO { get; set; }
        public int QTY_TYPE { get; set; }

        public string Aciklama
        {
            get { return string.Concat(ITEM_CODE, " ", ITEM_NAME); }
        }

        public static List<prdt_worder_bom_d> GetMaterials(int worder_m_id, int operation_id, bool depostok)
        {
            StringBuilder sbSqlString = new StringBuilder();
            sbSqlString.AppendFormat(@"SELECT IT.ITEM_ID,IT.ITEM_CODE,IT.ITEM_NAME,BD.WORDER_BOM_D_ID,BD.WORDER_M_ID,BD.ITEM_BOM_M_ID,IT.UNIT_ID,UN.UNIT_CODE,BD.QTY_BASE_BOM,BD.QTY_TYPE,BD.WHOUSE_ID,BD.LINE_NO 
FROM PRDT_WORDER_BOM_D BD INNER JOIN INVD_ITEM IT ON BD.ITEM_ID = IT.ITEM_ID INNER JOIN INVD_UNIT UN ON IT.UNIT_ID = UN.UNIT_ID
WHERE BD.BRANCH_ID = '{1}' AND BD.CO_ID = '{0}' AND BD.WORDER_M_ID = '{2}' AND BD.OPERATION_ID = '{3}' AND BD.IS_NOT_DEPLETION = 0 ORDER BY BD.USER_LINE_NO ",
                          ClientApplication.Instance.ClientToken.CoId,
                          ClientApplication.Instance.ClientToken.BranchId,
                          worder_m_id, operation_id);

            MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
            param.Token = ClientApplication.Instance.Token;
            param.Value = sbSqlString.ToString();
            Logger.I(param.Value);

            MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
            if (res != null)
            {
                if (res.Result == false)
                {
                    MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                }
                else
                {
                    return DataProvider.TableToList(res.Value, typeof(prdt_worder_bom_d)) as List<prdt_worder_bom_d>;
                }
            }
            return null;
        }
    }
}
