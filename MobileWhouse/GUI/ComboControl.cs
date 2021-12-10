using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Models;
using System.Diagnostics;
using MobileWhouse.Enums;
using MobileWhouse.Log;

namespace MobileWhouse.GUI
{
    public partial class ComboControl : ComboBox
    {
        public ComboControl()
        {
            InitializeComponent();
        }

        private void GetDataItems()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();

                if (dataSourceType == DataSourceType.Durus)
                {
                    sbSqlString.AppendFormat(@"SELECT BR.BREAK_REASON_CODE || ' ' || BR.DESCRIPTION AS TXT,BR.BREAK_REASON_ID AS ID FROM UYUMSOFT.PRDD_BREAK_REASON BR WHERE BR.BRANCH_ID = {0} AND BR.CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Personel)
                {
                    sbSqlString.AppendFormat(@"SELECT EM.PRD_EMPLOYEE_ID AS ID,EM.EMP_NAME || ' ' || EM.EMP_SURNAME AS TXT FROM UYUMSOFT.PRDD_EMPLOYEE EM WHERE EM.BRANCH_ID = {0} AND EM.CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Vardiya)
                {
                    sbSqlString.AppendFormat(@"SELECT SH.SHIFTS_CODE || ' ' || SH.DESCRIPTION || ' ' || TO_CHAR(SH.START_DATE,'HH24:MI') || ' - ' || 
TO_CHAR(SH.END_DATE,'HH24:MI') AS TXT,SH.SHIFTS_ID AS ID FROM PRDD_SHIFTS SH
WHERE SH.BRANCH_ID = {0} AND SH.CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Hurda)
                {
                    sbSqlString.AppendFormat(@"SELECT SC.SCRAP_REASON_CODE || ' ' || SC.DESCRIPTION AS TXT,SC.SCRAP_REASON_ID AS ID,SC.SCRAP_REASON_CODE,SC.DESCRIPTION,SC.SCRAP_RESULT_TYPE,SC.IS_NOT_ENTRY_QTY,SC.SCRAP_IN_WHOUSE_ID,SC.SCRAP_IS_TRANSFER,SC.SCRAP_TRN_WHOUSE2_ID,SC.SCRAP_TRN_DOC_TRA_ID,SC.SCRAP_NET_CALCULATE FROM PRDD_SCRAP_REASON SC WHERE SC.CO_ID = '{1}' AND SC.BRANCH_ID = '{0}' ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                    if (hurdaTip != ScrapType.Tumu)
                        sbSqlString.AppendFormat(" AND SC.SCRAP_RESULT_TYPE = '{0}' ", hurdaTip.GetHashCode());
                }

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
                        this.DataSource = res.Value;
                        this.DisplayMember = "TXT";
                        this.ValueMember = "ID";
                        this.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private ScrapType hurdaTip = ScrapType.Tumu;
        public ScrapType HurdaTip
        {
            get { return hurdaTip; }
            set { hurdaTip = value; }
        }

        private DataSourceType dataSourceType = DataSourceType.Vardiya;
        public DataSourceType DataSourceType
        {
            get { return dataSourceType; }
            set { dataSourceType = value; }
        }

        private bool load = false;
        private void ComboControl_ParentChanged(object sender, EventArgs e)
        {
            if (!Utility.IsDesignMode)
            {
                if (!load)
                {
                    load = true;
                    GetDataItems();
                }
            }
        }
    }
}
