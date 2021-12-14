using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Dilogs;
using MobileWhouse.Models;
using System.Globalization;

namespace MobileWhouse.Controls.PRD
{
    /*
     SELECT PRDT_TRANSFER_M.TRANSFER_M_ID, PRDT_TRANSFER_M.CREATE_USER_ID, PRDT_TRANSFER_M.UPDATE_USER_ID, PRDT_TRANSFER_M.CREATE_DATE, PRDT_TRANSFER_M.UPDATE_DATE, PRDT_TRANSFER_M.CO_ID, GNLD_COMPANY.CO_CODE AS CO_CODE, GNLD_COMPANY.CO_DESC AS CO_DESC, PRDT_TRANSFER_M.BRANCH_ID, GNLD_BRANCH.BRANCH_CODE AS BRANCH_CODE, GNLD_BRANCH.BRANCH_DESC AS BRANCH_DESC, PRDT_TRANSFER_M.WO_TYPE_ID, PRDD_WO_TYPE.WO_TYPE_CODE AS WO_TYPE_CODE, PRDD_WO_TYPE.DESCRIPTION AS WO_TYPE_DESCRIPTION, PRDT_TRANSFER_M.DOC_DATE, PRDT_TRANSFER_M.DOC_NO, PRDT_TRANSFER_M.DESCRIPTION, PRDT_TRANSFER_M.WHOUSE_ID, INVD_WHOUSE.WHOUSE_CODE AS WHOUSE_CODE, INVD_WHOUSE.DESCRIPTION AS WHOUSE_DESC, PRDT_TRANSFER_M.TRANSFER_WHOUSE_ID, INVD_WHOUSE_TRANSFER.WHOUSE_CODE AS TRANSFER_WHOUSE_CODE, INVD_WHOUSE_TRANSFER.DESCRIPTION AS TRANSFER_WHOUSE_DESC, PRDT_TRANSFER_M.DOC_TRA_ID, GNLD_DOC_TRA.DOC_TRA_CODE, GNLD_DOC_TRA.DESCRIPTION AS DOC_TRA_DESC, PRDT_TRANSFER_M.US_ID, USERS.US_USERNAME AS US_USERNAME, USERS.US_NAME AS US_NAME, USERS.US_SURNAME AS US_SURNAME, PRDT_TRANSFER_M.PRD_EMPLOYEE_ID, PRDT_TRANSFER_M.REQUEST_DATE, PRDT_TRANSFER_M.REQUEST_STATUS, PRDT_TRANSFER_M.APPROVAL_STATUS_ID, GNLD_APPROVAL_STATUS_DEF.APPROVAL_STATUS_CODE, PRDT_TRANSFER_M.IS_APPROVE_BY_MASTER, PRDD_EMPLOYEE.CITIZENSHIP_NO, PRDD_EMPLOYEE.EMP_NAME, PRDD_EMPLOYEE.EMP_SURNAME, GNLD_DOC_TRA.INVENTORY_STATUS AS INVENTORY_STATUS, PRDT_TRANSFER_M.IS_TRANSFER, PRDT_TRANSFER_M.IS_NOT_OPR_CONF, PRDT_TRANSFER_M.IS_CHANGE_MATRL_TRN_TYPE, PRDT_TRANSFER_M.WORDER_MATRL_TRN_TRACE_TYPE, PRDT_TRANSFER_M.WORDER_MATRL_TRN_TYPE, PRDT_TRANSFER_M.PRD_TRANSFER_STATUS, PRDT_TRANSFER_M.MATERIEL_DISTRIBUTED_TYPE, PRDT_TRANSFER_M.PRD_TRF_SLC_WORDER, PRDT_TRANSFER_M.CAT_CODE1_ID, GNLD_CATEGORY1.CAT_CODE AS CAT_CODE1, PRDT_TRANSFER_M.CAT_CODE2_ID, GNLD_CATEGORY2.CAT_CODE AS CAT_CODE2, PRDT_TRANSFER_M.NOTE1, PRDT_TRANSFER_M.NOTE2, PRDT_TRANSFER_M.NOTE3, PRDT_TRANSFER_M.NOTE_LARGE, PRDT_TRANSFER_M.SOURCE_APP, PRDT_TRANSFER_M.SOURCE_M_ID, PRDT_TRANSFER_M.WSTATION_ID, PRDD_WSTATION.WSTATION_CODE AS WSTATION_CODE, PRDD_WSTATION.DESCRIPTION AS WSTATION_DESCRIPTION, PRDT_TRANSFER_M.DOC_TRA_WAYBILL_ID, GNLD_DOCTRA_WAYBIL.DOC_TRA_CODE AS DOC_TRA_WAYBILL_CODE, GNLD_DOCTRA_WAYBIL.DESCRIPTION AS DOC_TRA_WAYBILL_DESC, PRDT_TRANSFER_M.E_DOC_NO, PRDT_TRANSFER_M.ISSUE_TIME, PRDT_TRANSFER_M.ACTUAL_DESPATCH_DATE, PRDT_TRANSFER_M.START_TIME, PRDT_TRANSFER_M.REGISTER_NAME, PRDT_TRANSFER_M.VEHICLE_ID, PSMD_VEHICLE.DESCRIPTION AS VEHICLE_DESC, PRDT_TRANSFER_M.LICENSE_PLATE, PRDT_TRANSFER_M.DRIVER_IDENTIFY_NO, PRDT_TRANSFER_M.DRIVER_NAME, PRDT_TRANSFER_M.DRIVER_FAMILY_NAME, PRDT_TRANSFER_M.DRIVER_GSM_NO, PRDT_TRANSFER_M.SHIPPING_DESC1, PRDT_TRANSFER_M.TRANSPORT_EQUIPMENT FROM PRDT_TRANSFER_M  LEFT OUTER JOIN  UYUMSOFT.GNLD_COMPANY ON PRDT_TRANSFER_M.CO_ID = GNLD_COMPANY.CO_ID  LEFT OUTER JOIN  UYUMSOFT.GNLD_BRANCH ON PRDT_TRANSFER_M.BRANCH_ID = GNLD_BRANCH.BRANCH_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_WHOUSE ON PRDT_TRANSFER_M.WHOUSE_ID = INVD_WHOUSE.WHOUSE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_WHOUSE INVD_WHOUSE_TRANSFER ON PRDT_TRANSFER_M.TRANSFER_WHOUSE_ID = INVD_WHOUSE_TRANSFER.WHOUSE_ID  LEFT OUTER JOIN  UYUMSOFT.GNLD_APPROVAL_STATUS_DEF ON PRDT_TRANSFER_M.APPROVAL_STATUS_ID = GNLD_APPROVAL_STATUS_DEF.APPROVAL_STATUS_ID LEFT OUTER JOIN  UYUMSOFT.GNLD_DOC_TRA ON PRDT_TRANSFER_M.DOC_TRA_ID = GNLD_DOC_TRA.DOC_TRA_ID  LEFT OUTER JOIN  UYUMSOFT.PRDD_EMPLOYEE ON PRDT_TRANSFER_M.PRD_EMPLOYEE_ID = PRDD_EMPLOYEE.PRD_EMPLOYEE_ID  LEFT OUTER JOIN  UYUMSOFT.PRDD_WO_TYPE ON PRDT_TRANSFER_M.WO_TYPE_ID = PRDD_WO_TYPE.WO_TYPE_ID  LEFT OUTER JOIN  UYUMSOFT.USERS ON PRDT_TRANSFER_M.US_ID = USERS.US_ID  LEFT OUTER JOIN  UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY1 ON PRDT_TRANSFER_M.CAT_CODE1_ID = GNLD_CATEGORY1.CAT_CODE_ID LEFT OUTER JOIN  UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY2 ON PRDT_TRANSFER_M.CAT_CODE2_ID = GNLD_CATEGORY2.CAT_CODE_ID LEFT OUTER JOIN  UYUMSOFT.PRDD_WSTATION ON PRDT_TRANSFER_M.WSTATION_ID = PRDD_WSTATION.WSTATION_ID  LEFT OUTER JOIN  UYUMSOFT.PSMD_VEHICLE ON PRDT_TRANSFER_M.VEHICLE_ID = PSMD_VEHICLE.VEHICLE_ID LEFT OUTER JOIN  UYUMSOFT.GNLD_DOC_TRA GNLD_DOCTRA_WAYBIL ON PRDT_TRANSFER_M.DOC_TRA_WAYBILL_ID = GNLD_DOCTRA_WAYBIL.DOC_TRA_ID WHERE (PRDT_TRANSFER_M.BRANCH_ID = :BRANCH_ID AND PRDT_TRANSFER_M.WORDER_MATRL_TRN_TYPE = :WORDER_MATRL_TRN_TYPE AND PRDT_TRANSFER_M.IS_TRANSFER = :IS_TRANSFER AND PRDT_TRANSFER_M.PRD_TRANSFER_STATUS = :PRD_TRANSFER_STATUS) ORDER BY PRDT_TRANSFER_M.REQUEST_DATE ASC, PRDT_TRANSFER_M.DOC_DATE ASC, PRDT_TRANSFER_M.DOC_NO ASC
:BRANCH_ID - 6749
:WORDER_MATRL_TRN_TYPE - 2
:IS_TRANSFER - 0
:PRD_TRANSFER_STATUS - 1
*/

    public partial class MalzemeTalepSevkControl : BaseControl
    {
        public MalzemeTalepSevkControl()
        {
            InitializeComponent();
            txtraf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        private DataRow selectedWorderOut = null;
        private MobileWhouse.UyumConnector.NameIdItem _SelectedRaf;
        MobileWhouse.UTermConnector.PackageDetail package = null;

        private void Talepler()
        {
            try
            {
                Screens.ShowWait();

                StringBuilder s = new StringBuilder();
                s.AppendFormat(@"SELECT 
PRDT_TRANSFER_M.TRANSFER_M_ID, PRDT_TRANSFER_M.CREATE_USER_ID, PRDT_TRANSFER_M.UPDATE_USER_ID, PRDT_TRANSFER_M.CREATE_DATE, 
PRDT_TRANSFER_M.UPDATE_DATE, PRDT_TRANSFER_M.CO_ID, PRDT_TRANSFER_M.BRANCH_ID, PRDT_TRANSFER_M.WO_TYPE_ID, 
PRDD_WO_TYPE.WO_TYPE_CODE AS WO_TYPE_CODE, PRDD_WO_TYPE.DESCRIPTION AS WO_TYPE_DESCRIPTION, TO_CHAR(PRDT_TRANSFER_M.DOC_DATE,'DD/MM/YYYY') DOC_DATE, PRDT_TRANSFER_M.DOC_NO, PRDT_TRANSFER_M.DESCRIPTION, PRDT_TRANSFER_M.WHOUSE_ID, INVD_WHOUSE.WHOUSE_CODE AS WHOUSE_CODE, INVD_WHOUSE.DESCRIPTION AS WHOUSE_DESC, PRDT_TRANSFER_M.TRANSFER_WHOUSE_ID, INVD_WHOUSE_TRANSFER.WHOUSE_CODE AS TRANSFER_WHOUSE_CODE, INVD_WHOUSE_TRANSFER.DESCRIPTION AS TRANSFER_WHOUSE_DESC, PRDT_TRANSFER_M.DOC_TRA_ID, GNLD_DOC_TRA.DOC_TRA_CODE, GNLD_DOC_TRA.DESCRIPTION AS DOC_TRA_DESC, PRDT_TRANSFER_M.US_ID, USERS.US_USERNAME AS US_USERNAME, USERS.US_NAME AS US_NAME, USERS.US_SURNAME AS US_SURNAME, PRDT_TRANSFER_M.PRD_EMPLOYEE_ID, TO_CHAR(PRDT_TRANSFER_M.REQUEST_DATE,'DD/MM/YYYY') REQUEST_DATE, PRDT_TRANSFER_M.REQUEST_STATUS, PRDT_TRANSFER_M.APPROVAL_STATUS_ID, GNLD_APPROVAL_STATUS_DEF.APPROVAL_STATUS_CODE, PRDT_TRANSFER_M.IS_APPROVE_BY_MASTER, GNLD_DOC_TRA.INVENTORY_STATUS AS INVENTORY_STATUS, PRDT_TRANSFER_M.IS_TRANSFER, PRDT_TRANSFER_M.IS_NOT_OPR_CONF, PRDT_TRANSFER_M.IS_CHANGE_MATRL_TRN_TYPE, PRDT_TRANSFER_M.WORDER_MATRL_TRN_TRACE_TYPE, PRDT_TRANSFER_M.WORDER_MATRL_TRN_TYPE, PRDT_TRANSFER_M.PRD_TRANSFER_STATUS, PRDT_TRANSFER_M.MATERIEL_DISTRIBUTED_TYPE, PRDT_TRANSFER_M.PRD_TRF_SLC_WORDER, PRDT_TRANSFER_M.CAT_CODE1_ID, GNLD_CATEGORY1.CAT_CODE AS CAT_CODE1, PRDT_TRANSFER_M.CAT_CODE2_ID, GNLD_CATEGORY2.CAT_CODE AS CAT_CODE2, PRDT_TRANSFER_M.NOTE1, PRDT_TRANSFER_M.NOTE2, PRDT_TRANSFER_M.NOTE3, PRDT_TRANSFER_M.NOTE_LARGE, PRDT_TRANSFER_M.SOURCE_APP, PRDT_TRANSFER_M.SOURCE_M_ID, PRDT_TRANSFER_M.WSTATION_ID, PRDT_TRANSFER_M.DOC_TRA_WAYBILL_ID, GNLD_DOCTRA_WAYBIL.DOC_TRA_CODE AS DOC_TRA_WAYBILL_CODE, GNLD_DOCTRA_WAYBIL.DESCRIPTION AS DOC_TRA_WAYBILL_DESC, PRDT_TRANSFER_M.E_DOC_NO, PRDT_TRANSFER_M.ISSUE_TIME, PRDT_TRANSFER_M.ACTUAL_DESPATCH_DATE, PRDT_TRANSFER_M.START_TIME, PRDT_TRANSFER_M.REGISTER_NAME, PRDT_TRANSFER_M.VEHICLE_ID, PSMD_VEHICLE.DESCRIPTION AS VEHICLE_DESC, PRDT_TRANSFER_M.LICENSE_PLATE, PRDT_TRANSFER_M.DRIVER_IDENTIFY_NO, PRDT_TRANSFER_M.DRIVER_NAME, PRDT_TRANSFER_M.DRIVER_FAMILY_NAME, PRDT_TRANSFER_M.DRIVER_GSM_NO, PRDT_TRANSFER_M.SHIPPING_DESC1, PRDT_TRANSFER_M.TRANSPORT_EQUIPMENT 
FROM PRDT_TRANSFER_M  LEFT OUTER JOIN  
UYUMSOFT.INVD_WHOUSE ON PRDT_TRANSFER_M.WHOUSE_ID = INVD_WHOUSE.WHOUSE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_WHOUSE INVD_WHOUSE_TRANSFER ON PRDT_TRANSFER_M.TRANSFER_WHOUSE_ID = INVD_WHOUSE_TRANSFER.WHOUSE_ID  LEFT OUTER JOIN  
UYUMSOFT.GNLD_APPROVAL_STATUS_DEF ON PRDT_TRANSFER_M.APPROVAL_STATUS_ID = GNLD_APPROVAL_STATUS_DEF.APPROVAL_STATUS_ID LEFT OUTER JOIN  
UYUMSOFT.GNLD_DOC_TRA ON PRDT_TRANSFER_M.DOC_TRA_ID = GNLD_DOC_TRA.DOC_TRA_ID  LEFT OUTER JOIN  
UYUMSOFT.PRDD_WO_TYPE ON PRDT_TRANSFER_M.WO_TYPE_ID = PRDD_WO_TYPE.WO_TYPE_ID  LEFT OUTER JOIN  
UYUMSOFT.USERS ON PRDT_TRANSFER_M.US_ID = USERS.US_ID  LEFT OUTER JOIN  
UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY1 ON PRDT_TRANSFER_M.CAT_CODE1_ID = GNLD_CATEGORY1.CAT_CODE_ID LEFT OUTER JOIN  
UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY2 ON PRDT_TRANSFER_M.CAT_CODE2_ID = GNLD_CATEGORY2.CAT_CODE_ID LEFT OUTER JOIN   
UYUMSOFT.PSMD_VEHICLE ON PRDT_TRANSFER_M.VEHICLE_ID = PSMD_VEHICLE.VEHICLE_ID LEFT OUTER JOIN  
UYUMSOFT.GNLD_DOC_TRA GNLD_DOCTRA_WAYBIL ON PRDT_TRANSFER_M.DOC_TRA_WAYBILL_ID = GNLD_DOCTRA_WAYBIL.DOC_TRA_ID 
		 WHERE (PRDT_TRANSFER_M.BRANCH_ID = '{0}' AND PRDT_TRANSFER_M.WORDER_MATRL_TRN_TYPE = 2 
		 AND PRDT_TRANSFER_M.IS_TRANSFER = 0 AND PRDT_TRANSFER_M.PRD_TRANSFER_STATUS = 1) ", ClientApplication.Instance.Token.BranchId);

                if (!string.IsNullOrEmpty(txtarama.Text))
                    s.AppendFormat(" AND (PRDT_TRANSFER_M.DOC_NO LIKE '%{0}%') ", txtarama.Text.Replace("'", ""));

                s.Append(" ORDER BY PRDT_TRANSFER_M.REQUEST_DATE ASC, PRDT_TRANSFER_M.DOC_DATE ASC, PRDT_TRANSFER_M.DOC_NO ASC ");

                listtalep.BeginUpdate();
                listtalep.Items.Clear();
                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = s.ToString();
                MobileWhouse.UyumConnector.ServiceResultOfDataTable worderMInfo = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (worderMInfo.Result)
                {
                    for (int i = 0; i < worderMInfo.Value.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = worderMInfo.Value.Rows[i];
                        item.Text = worderMInfo.Value.Rows[i]["DOC_DATE"].ToString();
                        item.SubItems.Add(worderMInfo.Value.Rows[i]["DOC_NO"].ToString());
                        item.SubItems.Add(worderMInfo.Value.Rows[i]["WO_TYPE_CODE"].ToString());
                        item.SubItems.Add(worderMInfo.Value.Rows[i]["TRANSFER_WHOUSE_CODE"].ToString());
                        item.SubItems.Add(worderMInfo.Value.Rows[i]["WHOUSE_CODE"].ToString());
                        item.SubItems.Add(worderMInfo.Value.Rows[i]["DOC_TRA_CODE"].ToString());
                        item.SubItems.Add(worderMInfo.Value.Rows[i]["DESCRIPTION"].ToString());
                        item.SubItems.Add(worderMInfo.Value.Rows[i]["REQUEST_DATE"].ToString());
                        listtalep.Items.Add(item);
                    }
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                listtalep.EndUpdate();
                Screens.HideWait();
            }
        }

        private void TalepDetay()
        {
            try
            {
                if (selectedWorderOut == null) return;

                Screens.ShowWait();
                listbarkod.BeginUpdate();
                listbarkod.Items.Clear();
                StringBuilder s = new StringBuilder();
                s.AppendFormat(@"SELECT PRDT_TRANSFER_D.TRANSFER_D_ID, PRDT_TRANSFER_D.CREATE_USER_ID, PRDT_TRANSFER_D.UPDATE_USER_ID, PRDT_TRANSFER_D.CREATE_DATE, PRDT_TRANSFER_D.UPDATE_DATE, PRDT_TRANSFER_D.CO_ID, PRDT_TRANSFER_D.BRANCH_ID, PRDT_TRANSFER_D.TRANSFER_M_ID, PRDT_TRANSFER_D.WORDER_M_ID, PRDT_WORDER_M.WORDER_NO AS WORDER_NO,
PRDT_WORDER_M.ITEM_ID WORDER_ITEM_ID,WORDER_ITEM.ITEM_CODE WORDER_ITEM_CODE,PRDT_WORDER_M.UNIT_ID WORDER_UNIT_ID,PRDT_WORDER_M.QTY WORDER_QTY, PRDT_TRANSFER_D.LINE_NO, PRDT_TRANSFER_D.ITEM_ID, INVD_ITEM.ITEM_CODE AS ITEM_CODE, INVD_ITEM.ITEM_NAME AS ITEM_NAME, PRDT_TRANSFER_D.BOM_LINE_TYPE, PRDT_TRANSFER_D.ITEM_BOM_M_ID, PRDD_BOM_M1.ALTERNATIVE_NO, PRDD_BOM_M1.BOM_REV_NO, PRDT_TRANSFER_D.DESCRIPTION, PRDT_TRANSFER_D.QTY_TYPE, PRDT_TRANSFER_D.QTY_TRAILING, PRDT_TRANSFER_D.QTY_REQUIRED_TRAILING, PRDT_TRANSFER_D.QTY_RECOMMEND, PRDT_TRANSFER_D.UNIT_ID, INVD_UNIT.UNIT_CODE AS UNIT_CODE, PRDT_TRANSFER_D.WHOUSE_ID, INVD_WHOUSE.WHOUSE_CODE AS WHOUSE_CODE, INVD_WHOUSE.DESCRIPTION AS WHOUSE_DESC, PRDT_TRANSFER_D.WHOUSE2_ID, INVD_WHOUSE2.WHOUSE_CODE AS WHOUSE2_CODE, PRDT_TRANSFER_D.COLOR_ID, INVD_COLOR.COLOR_CODE AS COLOR_CODE, INVD_COLOR.DESCRIPTION AS COLOR_DESC, PRDT_TRANSFER_D.LOT_ID, INVD_LOT.LOT_CODE AS LOT_CODE, INVD_LOT.DESCRIPTION AS LOT_DESC, PRDT_TRANSFER_D.PACKAGE_TYPE_ID, INVD_PACKAGE_TYPE.PACKAGE_TYPE_CODE AS PACKAGE_TYPE_CODE, INVD_PACKAGE_TYPE.DESCRIPTION AS PACKAGE_TYPE_DESC, PRDT_TRANSFER_D.QUALITY_ID, INVD_QUALITY.QUALITY_CODE AS QUALITY_CODE, INVD_QUALITY.DESCRIPTION AS QUALITY_DESC, PRDT_TRANSFER_D.ITEM_ATTRIBUTE1_ID, PRDT_TRANSFER_D.ITEM_ATTRIBUTE2_ID, PRDT_TRANSFER_D.ITEM_ATTRIBUTE3_ID, ATT1.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_CODE1, ATT2.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_CODE2, ATT3.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_CODE3, GNLATT1.ITEM_ATTRIBUTE_CODE AS ITEM_GNL_ATTRIBUTE_CODE1, GNLATT2.ITEM_ATTRIBUTE_CODE AS ITEM_GNL_ATTRIBUTE_CODE2, GNLATT3.ITEM_ATTRIBUTE_CODE AS ITEM_GNL_ATTRIBUTE_CODE3, ATT1.DESCRIPTION AS ITEM_ATTRIBUTE_DESC1, ATT2.DESCRIPTION AS ITEM_ATTRIBUTE_DESC2, ATT3.DESCRIPTION AS ITEM_ATTRIBUTE_DESC3, PRDT_TRANSFER_D.ITEM_GNL_ATTRIBUTE1_ID, PRDT_TRANSFER_D.ITEM_GNL_ATTRIBUTE2_ID, PRDT_TRANSFER_D.ITEM_GNL_ATTRIBUTE3_ID, GNLATT1.DESCRIPTION AS ITEM_GNL_ATTRIBUTE_DESC1, GNLATT2.DESCRIPTION AS ITEM_GNL_ATTRIBUTE_DESC2, GNLATT3.DESCRIPTION AS ITEM_GNL_ATTRIBUTE_DESC3, PRDT_TRANSFER_D.DIM_CARD_ID1, INVD_DIM_CARD1.DIM_CARD_CODE AS DIM_CARD_CODE1, INVD_DIM_CARD1.DIM_CARD_NAME AS DIM_CARD_NAME1, PRDT_TRANSFER_D.DIM_CARD_ID2, INVD_DIM_CARD2.DIM_CARD_CODE AS DIM_CARD_CODE2, INVD_DIM_CARD2.DIM_CARD_NAME AS DIM_CARD_NAME2, PRDT_TRANSFER_D.IS_AUTOMATIC, PRDT_TRANSFER_D.DATA_ENTRY_TYPE, PRDT_TRANSFER_D.DATA_ENTRY_TYPE3, PRDT_TRANSFER_D.BWH_LOCATION_ID, INVD_BWH_LOCATION1.LOCATION_CODE AS LOCATION_CODE, PRDT_TRANSFER_D.QTY_FREE_PRM, PRDT_TRANSFER_D.QTY_FREE_SEC, PRDT_TRANSFER_D.FREE_PRM_M_ID, PRDT_TRANSFER_D.FREE_SEC_M_ID, INVD_FREE_UNIT_PRM.FREE_UNIT_CODE AS FREE_UNIT_PRM_CODE, INVD_FREE_UNIT_SEC.FREE_UNIT_CODE AS FREE_UNIT_SEC_CODE, PRDT_TRANSFER_D.REASON_ID, GNLD_REASON.REASON_CODE AS REASON_CODE, FIND_PROJECT_M.PROJECT_CODE AS PROJECT_CODE, PRDT_TRANSFER_D.PROJECT_M_ID, PRDT_TRANSFER_D.REGISTER_ID, HRMD_REGISTER.REGISTER_FULL_NAME, PRDT_TRANSFER_D.CONTACT_ID, GNLD_CONTACT.CONTACT_NAME, GNLD_CATEGORY1.CAT_CODE AS CAT_CODE1, GNLD_CATEGORY2.CAT_CODE AS CAT_CODE2, PRDT_TRANSFER_D.CAT_CODE1_ID, PRDT_TRANSFER_D.CAT_CODE2_ID, PRDT_TRANSFER_D.NOTE1, PRDT_TRANSFER_D.NOTE2, PRDT_TRANSFER_D.NOTE3, PRDT_TRANSFER_D.NOTE_LARGE, PRDT_TRANSFER_D.PRD_PACKAGE_TYPE_ID, INVD_PRD_PACKAGE_TYPE.PACKAGE_TYPE_CODE AS PRD_PACKAGE_TYPE_CODE, INVD_PRD_PACKAGE_TYPE.DESCRIPTION AS PRD_PACKAGE_TYPE_DESC, PRDT_TRANSFER_D.MTR_RESERVATION_TYPE, PRDT_TRANSFER_D.SOURCE_ORDER_M_ID, PRDT_TRANSFER_D.SOURCE_ORDER_D_ID 
FROM PRDT_TRANSFER_D  LEFT OUTER JOIN   
UYUMSOFT.INVD_ITEM ON PRDT_TRANSFER_D.ITEM_ID = INVD_ITEM.ITEM_ID  LEFT OUTER JOIN  
UYUMSOFT.PRDD_BOM_M PRDD_BOM_M1 ON PRDT_TRANSFER_D.ITEM_BOM_M_ID = PRDD_BOM_M1.BOM_M_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_COLOR ON PRDT_TRANSFER_D.COLOR_ID = INVD_COLOR.COLOR_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_LOT ON PRDT_TRANSFER_D.LOT_ID = INVD_LOT.LOT_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_PACKAGE_TYPE ON PRDT_TRANSFER_D.PACKAGE_TYPE_ID = INVD_PACKAGE_TYPE.PACKAGE_TYPE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_QUALITY ON PRDT_TRANSFER_D.QUALITY_ID = INVD_QUALITY.QUALITY_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_UNIT ON PRDT_TRANSFER_D.UNIT_ID = INVD_UNIT.UNIT_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_WHOUSE ON PRDT_TRANSFER_D.WHOUSE_ID = INVD_WHOUSE.WHOUSE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_ITEM_ATTRIBUTE ATT1 ON PRDT_TRANSFER_D.ITEM_ATTRIBUTE1_ID = ATT1.ITEM_ATTRIBUTE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_ITEM_ATTRIBUTE ATT2 ON PRDT_TRANSFER_D.ITEM_ATTRIBUTE2_ID = ATT2.ITEM_ATTRIBUTE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_ITEM_ATTRIBUTE ATT3 ON PRDT_TRANSFER_D.ITEM_ATTRIBUTE3_ID = ATT3.ITEM_ATTRIBUTE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE GNLATT1 ON PRDT_TRANSFER_D.ITEM_GNL_ATTRIBUTE1_ID = GNLATT1.ITEM_GNL_ATTRIBUTE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE GNLATT2 ON PRDT_TRANSFER_D.ITEM_GNL_ATTRIBUTE2_ID = GNLATT2.ITEM_GNL_ATTRIBUTE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE GNLATT3 ON PRDT_TRANSFER_D.ITEM_GNL_ATTRIBUTE3_ID = GNLATT3.ITEM_GNL_ATTRIBUTE_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_WHOUSE INVD_WHOUSE2 ON PRDT_TRANSFER_D.WHOUSE2_ID = INVD_WHOUSE2.WHOUSE_ID LEFT OUTER JOIN  
UYUMSOFT.GNLD_REASON ON PRDT_TRANSFER_D.REASON_ID = GNLD_REASON.REASON_ID LEFT OUTER JOIN  
UYUMSOFT.FIND_PROJECT_M ON PRDT_TRANSFER_D.PROJECT_M_ID = FIND_PROJECT_M.PROJECT_M_ID LEFT OUTER JOIN  
UYUMSOFT.HRMD_REGISTER ON PRDT_TRANSFER_D.REGISTER_ID = HRMD_REGISTER.REGISTER_ID LEFT OUTER JOIN  
UYUMSOFT.GNLD_CONTACT ON PRDT_TRANSFER_D.CONTACT_ID = GNLD_CONTACT.CONTACT_ID LEFT OUTER JOIN  
UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY1 ON PRDT_TRANSFER_D.CAT_CODE1_ID = GNLD_CATEGORY1.CAT_CODE_ID LEFT OUTER JOIN  
UYUMSOFT.GNLD_CATEGORY GNLD_CATEGORY2 ON PRDT_TRANSFER_D.CAT_CODE2_ID = GNLD_CATEGORY2.CAT_CODE_ID LEFT OUTER JOIN  
UYUMSOFT.INVD_FREE_UNIT INVD_FREE_UNIT_PRM ON PRDT_TRANSFER_D.FREE_PRM_M_ID = INVD_FREE_UNIT_PRM.FREE_UNIT_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_FREE_UNIT INVD_FREE_UNIT_SEC ON PRDT_TRANSFER_D.FREE_SEC_M_ID = INVD_FREE_UNIT_SEC.FREE_UNIT_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_DIM_CARD INVD_DIM_CARD1 ON PRDT_TRANSFER_D.DIM_CARD_ID1 = INVD_DIM_CARD1.DIM_CARD_ID  LEFT OUTER JOIN  
UYUMSOFT.INVD_DIM_CARD INVD_DIM_CARD2 ON PRDT_TRANSFER_D.DIM_CARD_ID2 = INVD_DIM_CARD2.DIM_CARD_ID  LEFT OUTER JOIN  
UYUMSOFT.PRDT_WORDER_M ON PRDT_TRANSFER_D.WORDER_M_ID = PRDT_WORDER_M.WORDER_M_ID  LEFT OUTER JOIN 
 UYUMSOFT.INVD_BWH_LOCATION INVD_BWH_LOCATION1 ON PRDT_TRANSFER_D.BWH_LOCATION_ID = INVD_BWH_LOCATION1.BWH_LOCATION_ID LEFT OUTER JOIN  
 UYUMSOFT.INVD_PRD_PACKAGE_TYPE ON PRDT_TRANSFER_D.PRD_PACKAGE_TYPE_ID = INVD_PRD_PACKAGE_TYPE.PRD_PACKAGE_TYPE_ID LEFT JOIN 
 UYUMSOFT.INVD_ITEM WORDER_ITEM ON PRDT_WORDER_M.ITEM_ID = WORDER_ITEM.ITEM_ID
 WHERE PRDT_TRANSFER_D.TRANSFER_M_ID = '{0}'", selectedWorderOut["TRANSFER_M_ID"]);

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = s.ToString();
                MobileWhouse.UyumConnector.ServiceResultOfDataTable transferDMaterials = ClientApplication.Instance.Service.ExecuteSQL(param);

                if (transferDMaterials.Result)
                {
                    for (int i = 0; i < transferDMaterials.Value.Rows.Count; i++)
                    {
                        TalepDetayInf detay = new TalepDetayInf(transferDMaterials.Value.Rows[i]);
                        ListViewItem item = new ListViewItem();
                        item.Tag = detay;
                        item.Text = (i + 1).ToString();
                        item.SubItems.Add(detay.ITEM_CODE);
                        item.SubItems.Add(detay.ITEM_NAME);
                        item.SubItems.Add(detay.UNIT_CODE);
                        item.SubItems.Add(detay.QTY_TRAILING.ToString(Statics.DECIMAL_STRING_FORMAT));//"0.#####"));
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                        //item.SubItems.Add(transferDMaterials.Value[i].QtyNeeded.ToString("0,0.#####"));
                        //item.SubItems.Add(transferDMaterials.Value[i].QtyTrailing.ToString("0,0.#####"));
                        //item.SubItems.Add(transferDMaterials.Value[i].BomLineTypeName);
                        listbarkod.Items.Add(item);
                    }
                    lblbilgi.Text = string.Concat(listbarkod.Items.Count, " satır");
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                listbarkod.EndUpdate();
                tabControl1.SelectedIndex = 1;
                Screens.HideWait();
            }
        }

        private void Ekle()
        {
            try
            {
                Screens.ShowWait();

                if (package == null)
                {
                    txtmiktar.Text = "";
                    txtbarkod.Text = "";
                    txtbarkod.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtmiktar.Text))
                {
                    Screens.Error("Miktar giriniz!");
                    txtmiktar.Text = "";
                    txtbarkod.Text = "";
                    txtbarkod.Focus();
                    return;
                }

                decimal qty = Convert.ToDecimal(txtmiktar.Text, ClientApplication.Instance.Culture);

                if (qty <= 0 || qty > package.Qty)
                {
                    Screens.Error("Miktar hatalı! Ambalaj miktarından fazla sevk edemezsiniz");
                    txtmiktar.Text = "";
                    txtbarkod.Text = "";
                    txtbarkod.Focus();
                    return;
                }

                if (listbarkod.Items.Count > 0)
                {
                    for (int i = 0; i < listbarkod.Items.Count; i++)
                    {
                        TalepDetayInf detay = listbarkod.Items[i].Tag as TalepDetayInf;
                        if (package.ItemInfo != null && detay.ITEM_ID == package.ItemInfo.Id && detay.QTY_TRAILING != detay.QTY_READ)
                        {
                            if (_SelectedRaf != null)
                                detay.LOCATION_ID = _SelectedRaf.Id;
                            detay.PACKAGE_M_ID = package.PackageDId;
                            detay.PACKAGE_NO = package.PackageNo;
                            detay.QTY_READ += qty;
                            detay.PackageDetails.Add(package);
                            listbarkod.Items[i].SubItems[5].Text = detay.QTY_READ.ToString(Statics.DECIMAL_STRING_FORMAT);//"0.#####");
                            listbarkod.Items[i].SubItems[6].Text = detay.PackageDetails.Count.ToString();
                        }
                    }
                }

                //MobileWhouse.UTermConnector.ServiceRequestOfPackageDetail _Ipp = new MobileWhouse.UTermConnector.ServiceRequestOfPackageDetail();
                //_Ipp.Token = ClientApplication.Instance.UTermToken;
                //_Ipp.Value = new MobileWhouse.UTermConnector.PackageDetail();
                //_Ipp.Value.WhouseId = kaynakdepo.Id;
                //_Ipp.Value.PackageNo = package.PackageNo;
                //_Ipp.Value.PackageMId = package.PackageMId;

                //MobileWhouse.UTermConnector.ServiceResultOfString result = ClientApplication.Instance.UTermService.RevortPackage(_Ipp);
                //if (result.Result == false)
                //{
                //    Screens.Error(result.Message.ToString());
                //    return;
                //}
                //else
                //{
                //    for (int i = 0; i < listbarkod.Items.Count; i++)
                //    {
                //        TalepDetayInf detay = listbarkod.Items[i].Tag as TalepDetayInf;
                //        if (package.ItemInfo != null && detay.ITEM_ID == package.ItemInfo.Id && detay.QTY_TRAILING != detay.QTY_READ)
                //        {
                //            detay.QTY_READ += package.Qty;
                //            detay.PackageDetails.Add(package);
                //            listbarkod.Items[i].SubItems[5].Text = detay.QTY_READ.ToString("0.#####");
                //            listbarkod.Items[i].SubItems[6].Text = detay.PackageDetails.Count.ToString();
                //        }
                //    }
                //}
            }
            catch (Exception except)
            {
                Screens.Error(except);
            }
            finally
            {
                Screens.HideWait();
                txtmiktar.Text = "";
                txtbarkod.Focus();
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnarama_Click(object sender, EventArgs e)
        {
            Talepler();
        }

        private void listtalep_ItemActivate(object sender, EventArgs e)
        {
            if (listtalep.Items.Count > 0 && listtalep.SelectedIndices.Count > 0)
            {
                selectedWorderOut = listtalep.Items[listtalep.SelectedIndices[0]].Tag as DataRow;
                TalepDetay();
            }
        }

        public override void OnRafBarkod(MobileWhouse.UyumConnector.NameIdItem raf)
        {
            base.OnRafBarkod(raf);
            _SelectedRaf = raf;
            txtraf.Text = raf.Name;
        }

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    Screens.ShowWait();

                    string barkod = txtbarkod.Text;
                    if (string.IsNullOrEmpty(barkod)) return;

                    MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam _Ipp = new MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam();
                    _Ipp.Token = ClientApplication.Instance.UTermToken;
                    _Ipp.Value = new MobileWhouse.UTermConnector.ItemPickingParam();
                    _Ipp.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    _Ipp.Value.PackageNo = barkod;

                    MobileWhouse.UTermConnector.ServiceResultOfPackageDetail result = ClientApplication.Instance.UTermService.GetPackageInfo(_Ipp);
                    if (result.Result == false)
                    {
                        Screens.Error(result.Message.ToString());
                        return;
                    }
                    else
                    {
                        package = result.Value;
                        if (package != null)
                        {
                            txtbarkod.Text = package.PackageNo;
                            txtmiktar.Text = package.Qty.ToString(Statics.DECIMAL_STRING_FORMAT);//"0.#####");
                            txtmiktar.Focus();
                            txtmiktar.SelectAll();
                            return;
                        }

                    }
                }
                catch (Exception except)
                {
                    Screens.Error(except);
                }
                finally
                {
                    Screens.HideWait();
                    txtmiktar.Focus();
                    txtmiktar.SelectAll();
                }
            }
        }

        private void txtmiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 13)
            {
                Ekle();
            }
            else
            {
                NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
                string numberDecimalSeparator = numberFormat.NumberDecimalSeparator;
                string negativeSign = numberFormat.NegativeSign;
                string str3 = e.KeyChar.ToString();
                if (((!char.IsDigit(e.KeyChar) && !str3.Equals(numberDecimalSeparator)) &&
                    ((!str3.Equals(negativeSign)) && ((e.KeyChar != '\b') &&
                    (e.KeyChar != Convert.ToChar(Keys.Delete))))) && (e.KeyChar != ' '))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnmiktar_Click(object sender, EventArgs e)
        {
            Ekle();
        }

        private void btnraf_Click(object sender, EventArgs e)
        {
            using (FormSelectRaf form = new FormSelectRaf(ClientApplication.Instance.SelectedDepot))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.Selected != null)
                    {
                        _SelectedRaf = form.Selected;
                        txtraf.Text = form.Selected.Name;
                    }
                }
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedWorderOut == null)
                {
                    Screens.Error("Malzeme talebi seçilmedi!");
                    return;
                }

                if (listbarkod.Items.Count == 0)
                {
                    Screens.Error("Barkod okutulmadı!");
                    return;
                }

                Screens.ShowWait();

                MobileWhouse.ProdConnector.ServiceRequestOfTransferMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfTransferMInfo();
                param.Token = ClientApplication.Instance.ProdToken;
                param.Value = new MobileWhouse.ProdConnector.TransferMInfo();
                param.Value.Id = StringUtil.ToInteger(selectedWorderOut["TRANSFER_M_ID"]);
                param.Value.DocDate = datebelge.Value.Date;
                param.Value.TransferWhouseId = StringUtil.ToInteger(selectedWorderOut["TRANSFER_WHOUSE_ID"]);
                param.Value.WhouseId = StringUtil.ToInteger(selectedWorderOut["WHOUSE_ID"]);
                param.Value.WoTypeId = StringUtil.ToInteger(selectedWorderOut["WO_TYPE_ID"]);
                //param.Value.DocTraId = 1332;
                List<MobileWhouse.ProdConnector.TransferWorderInfo> details = new List<MobileWhouse.ProdConnector.TransferWorderInfo>();
                for (int i = 0; i < listbarkod.Items.Count; i++)
                {
                    TalepDetayInf detay = listbarkod.Items[i].Tag as TalepDetayInf;
                    if (detay.QTY_READ > 0)
                    {
                        MobileWhouse.ProdConnector.TransferWorderInfo detail = new MobileWhouse.ProdConnector.TransferWorderInfo();
                        detail.TransferDId = detay.TRANSFER_D_ID;
                        detail.WorderItemId = detay.WORDER_ITEM_ID;
                        detail.WorderMId = detay.WORDER_M_ID;
                        detail.WorderMQty = detay.WORDER_QTY;
                        detail.WorderUnitId = detay.WORDER_UNIT_ID;
                        detail.BwhLocationOutId = 166;//detay.LOCATION_ID;
                        detail.BwhLocationInId = 168;//detay.LOCATION_ID;
                        detail.PackageMId = detay.PACKAGE_M_ID;
                        detail.PackageMNo = detay.PACKAGE_NO;
                        detail.QtyTrailing = detay.QTY_READ;
                        details.Add(detail);
                    }
                }
                param.Value.TransferWorderList = details.ToArray();

                MobileWhouse.ProdConnector.ServiceResultOfTransferMInfo result = ClientApplication.Instance.ProdService.PrdTransfer(param);
                if (result != null)
                {
                    if (result.Result)
                    {
                        Screens.Info("İşlem tamamlandı");
                        selectedWorderOut = null;
                        _SelectedRaf = null;
                        txtaciklama.Text = "";
                        txtraf.Text = "";
                        listbarkod.Items.Clear();
                        listtalep.Items.Clear();
                        tabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        Screens.Error(result.Message);
                    }
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

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            txtbarkod_KeyPress(txtbarkod, new KeyPressEventArgs((char)13));
        }

    }
}
