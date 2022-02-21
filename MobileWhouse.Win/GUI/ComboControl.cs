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
using System.Threading;

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
                if (dataSourceType == DataSourceType.Yok) return;

                System.Threading.Thread.Sleep(200);

                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();

                if (dataSourceType == DataSourceType.Durus)
                {
                    sbSqlString.AppendFormat(@"SELECT BR.BREAK_REASON_CODE || ' ' || BR.DESCRIPTION AS TXT,BR.BREAK_REASON_ID AS ID FROM UYUMSOFT.PRDD_BREAK_REASON BR WHERE BR.BRANCH_ID = {0} AND BR.CO_ID = {1} ORDER BY BR.BREAK_REASON_CODE", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Personel)
                {
                    sbSqlString.AppendFormat(@"SELECT EM.PRD_EMPLOYEE_ID AS ID,EM.EMP_NAME || ' ' || EM.EMP_SURNAME AS TXT FROM UYUMSOFT.PRDD_EMPLOYEE EM WHERE EM.BRANCH_ID = {0} AND EM.CO_ID = {1} AND EM.ISPASSIVE = 0 ORDER BY EM.EMP_NAME ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Vardiya)
                {
                    sbSqlString.AppendFormat(@"SELECT SH.SHIFTS_CODE || ' ' || SH.DESCRIPTION || ' ' || TO_CHAR(SH.START_DATE,'HH24:MI') || ' - ' || 
TO_CHAR(SH.END_DATE,'HH24:MI') AS TXT,SH.SHIFTS_ID AS ID FROM PRDD_SHIFTS SH
WHERE SH.BRANCH_ID = {0} AND SH.CO_ID = {1} ORDER BY SH.SHIFTS_CODE ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Hurda)
                {
                    sbSqlString.AppendFormat(@"SELECT SC.SCRAP_REASON_CODE || ' ' || SC.DESCRIPTION AS TXT,SC.SCRAP_REASON_ID AS ID,SC.SCRAP_REASON_CODE,SC.DESCRIPTION,SC.SCRAP_RESULT_TYPE,SC.IS_NOT_ENTRY_QTY,SC.SCRAP_IN_WHOUSE_ID,SC.SCRAP_IS_TRANSFER,SC.SCRAP_TRN_WHOUSE2_ID,SC.SCRAP_TRN_DOC_TRA_ID,SC.SCRAP_NET_CALCULATE FROM PRDD_SCRAP_REASON SC WHERE SC.CO_ID = '{1}' AND SC.BRANCH_ID = '{0}' ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                    if (hurdaTip != ScrapType.Tumu)
                        sbSqlString.AppendFormat(" AND SC.SCRAP_RESULT_TYPE = '{0}' ", hurdaTip.GetHashCode());
                    sbSqlString.Append(" ORDER BY SC.SCRAP_REASON_CODE");
                }
                else if (dataSourceType == DataSourceType.KontrolGrubu)
                {
                    sbSqlString.AppendFormat(@"SELECT gr.control_group_desc || ' ' || gr.control_group_code AS TXT, gr.control_group_id AS ID FROM qltd_control_groups gr WHERE gr.branch_id = {0} AND gr.co_id = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Dizayn)
                {
                    sbSqlString.AppendFormat(@"SELECT rpu.report_name AS TXT,rpu.report_code AS ID,rpu.report_id,
rpu.report_name,rpu.report_desc,rpu.report_code,rpu.report_file_name,rpu.source_app,rpu.report_type 
FROM uyumsoft.appd_reports_u rpu WHERE rpu.page_code = 'INV9009' ");
                }
                else if (dataSourceType == DataSourceType.KaliteDegerlendirmeGrubu)
                {
                    sbSqlString.AppendFormat(@"SELECT duty_gruop_id AS ID,duty_gruop_code || ' ' || duty_gruop_desc AS TXT FROM qltd_duty_groups WHERE BRANCH_ID = {0} AND CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.KaliteDepartman)
                {
                    sbSqlString.AppendFormat(@"SELECT department_id AS ID,department_code || ' ' || department_desc || ' ' || COALESCE(description4,'') AS TXT FROM qltd_department WHERE BRANCH_ID = {0} AND CO_ID = {1} ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.KaliteUygunsuzlukKonu)
                {
                    sbSqlString.AppendFormat(@"SELECT subject_id AS ID,subject_code || ' ' || COALESCE(subject_desc,'') AS TXT FROM qltd_discord_subject WHERE BRANCH_ID = {0} AND CO_ID = {1} ORDER BY subject_code", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Operasyon)
                {
                    sbSqlString.AppendFormat(@"SELECT operation_id AS ID,operation_code || ' ' || COALESCE(description,'') AS TXT FROM prdd_operation WHERE BRANCH_ID = {0} AND CO_ID = {1} ORDER BY operation_code ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
                }
                else if (dataSourceType == DataSourceType.Istasyon)
                {
                    sbSqlString.AppendFormat(@"SELECT wstation_id AS ID,wstation_code || ' ' || COALESCE(description,'') AS TXT FROM prdd_wstation WHERE BRANCH_ID = {0} AND CO_ID = {1} ORDER BY wstation_code ", ClientApplication.Instance.ClientToken.BranchId, ClientApplication.Instance.ClientToken.CoId);
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
                        //this.DataSource = res.Value;
                        //this.DisplayMember = "TXT";
                        //this.ValueMember = "ID";
                        //this.SelectedIndex = -1;
                        SetDataSource(this, res.Value);
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

        private DataSourceType dataSourceType = DataSourceType.Yok;
        public DataSourceType DataSourceType
        {
            get { return dataSourceType; }
            set 
            {
                dataSourceType = value;
                if (!Utility.IsDesignMode && value != DataSourceType.Yok)
                {
                    new Thread(new ThreadStart(GetDataItems)).Start();
                }
            }
        }

        private bool load = false;
        private void ComboControl_ParentChanged(object sender, EventArgs e)
        {
            if (!Utility.IsDesignMode)
            {
                if (!load)
                {
                    load = true;
                    //GetDataItems();
                    new System.Threading.Thread(new System.Threading.ThreadStart(GetDataItems)).Start();
                }
            }
        }

        private void SetDataSource(System.Windows.Forms.Control sender, object data)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetComboBoxDataSource p = new SetComboBoxDataSource(SetDataSource);
                    this.Invoke(p, new object[] { sender, data });
                }
                else
                {
                    this.DataSource = data;
                    this.DisplayMember = "TXT";
                    this.ValueMember = "ID";
                    this.SelectedIndex = -1;
                }
            }
            catch (Exception e)
            {
                Logger.E(e);
            }
        }
    }
}
