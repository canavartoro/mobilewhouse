using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Log;
using MobileWhouse.Util;

namespace MobileWhouse.Controls.PRD
{
    public partial class IsEmriControl : BaseControl
    {
        public IsEmriControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.WorderMInfo worderM = null;

        private void txtisemri_OnSelected(object sender, object obj)
        {
            worderM = obj as MobileWhouse.ProdConnector.WorderMInfo;
            if (worderM != null)
            {
                listBox1.Items.Clear();
                IsEmriRaporHelper help = new IsEmriRaporHelper(worderM);
                if (help.WorderInfos != null)
                {
                    for (int i = 0; i < help.WorderInfos.Count; i++) 
                        listBox1.Items.Add(help.WorderInfos[i]);
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }

    }

    class IsEmriRaporHelper
    {
        const int ISEMRIMIKTAR = 0;
        const int URETILENMIKTAR = 1;
        const int URETIMSAYISI = 2;
        const int ISEMRITARIHI = 3;
        const int ISEMRIKALAN = 4;
        const int KALANKOLI = 5;
        const int ISTASYONKOD = 6;
        const int ISTASYONAD = 7;
        const int URETIMBASLAMA = 8;
        const int URETIMID = 9;
        const int KOLIICI = 10;
        const int STOKKOD = 12;
        const int STOKAD = 13;
        const int PALET_SAYISI = 14;

        public IsEmriRaporHelper(MobileWhouse.ProdConnector.WorderMInfo worder)
        {
            this.worderM = worder;
            if (this.worderM != null) GetWorderInfo();
        }

        private MobileWhouse.ProdConnector.WorderMInfo worderM = null;
        private List<string> worderInfos = null;

        public List<string> WorderInfos
        {
            get { return worderInfos; }
        }

        private void GetWorderInfo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                //                sbSqlString.AppendFormat(@"SELECT wm.qty,SUM(acop.qty) acop_qty,COUNT(acop.*) acop_caount,TO_CHAR(wm.start_date, 'DD.MM.YYYY') start_date,
                //ws.wstation_code,ws.description,TO_CHAR(zacop.start_date, 'DD.MM.YYYY') prod_start,zacop.worder_ac_op_id 
                //FROM prdt_worder_m wm LEFT JOIN prdt_worder_ac_op acop ON wm.worder_m_id = acop.worder_m_id LEFT JOIN 
                //zz_worder_ac_op zacop ON wm.worder_m_id = zacop.worder_m_id AND zacop.is_closed = 0 LEFT JOIN 
                //prdd_wstation ws ON zacop.wstation_id = ws.wstation_id
                //WHERE wm.worder_no = '{0}'
                //GROUP BY wm.qty,wm.start_date,ws.wstation_code,ws.description,zacop.start_date,zacop.worder_ac_op_id ", worderM.WorderNo);

                sbSqlString.AppendFormat(@"SELECT wm.qty,SUM(acop.qty) acop_qty,COUNT(acop.*) acop_caount,TO_CHAR(wm.start_date, 'DD.MM.YYYY') start_date,
wm.qty - SUM(acop.qty) qty_reain,CASE WHEN it.density > 0 THEN TRUNC((wm.qty - SUM(acop.qty)) / it.density) ELSE 0 END qty_remain2,
ws.wstation_code,ws.description,TO_CHAR(zacop.start_date, 'DD.MM.YYYY') prod_start,zacop.worder_ac_op_id,it.density,
wm.worder_m_id,it.item_code,it.item_name,(SELECT COUNT(*) FROM (SELECT x.palette_no FROM zz_package_m x WHERE x.palette_no IS NOT NULL AND x.worder_m_id = wm.worder_m_id GROUP BY x.palette_no) t) palette_count 
FROM prdt_worder_m wm LEFT JOIN prdt_worder_ac_op acop ON wm.worder_m_id = acop.worder_m_id LEFT JOIN 
zz_worder_ac_op zacop ON wm.worder_m_id = zacop.worder_m_id AND zacop.is_closed = 0 LEFT JOIN 
prdd_wstation ws ON zacop.wstation_id = ws.wstation_id INNER JOIN invd_item it ON wm.item_id = it.item_id
WHERE wm.worder_no = '{0}'
GROUP BY wm.qty,wm.start_date,ws.wstation_code,ws.description,zacop.start_date,zacop.worder_ac_op_id,wm.worder_m_id,it.density,it.item_code,it.item_name   ", worderM.WorderNo);

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
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            worderInfos = new List<string>();
                            worderInfos.Add(string.Format("İş Emri Başlangıç:\t{0}", res.Value.Rows[0][ISEMRITARIHI]));
                            worderInfos.Add(string.Format("İş Emri Miktarı:\t{0}", StringUtil.ToDecimal(res.Value.Rows[0][ISEMRIMIKTAR]).ToString(Statics.DECIMAL_STRING_FORMAT)));
                            worderInfos.Add(string.Format("İş Emri Kalan Miktarı:\t{0}", StringUtil.ToDecimal(res.Value.Rows[0][ISEMRIKALAN]).ToString(Statics.DECIMAL_STRING_FORMAT)));
                            worderInfos.Add(string.Format("Üretilen Miktarı:\t{0}", StringUtil.ToDecimal(res.Value.Rows[0][1]).ToString(Statics.DECIMAL_STRING_FORMAT)));
                            worderInfos.Add(string.Format("Koli Sayısı:\t{0}\t Kalan Koli:{1}\tPalet:{2}", StringUtil.ToDecimal(res.Value.Rows[0][URETIMSAYISI]).ToString(Statics.DECIMAL_STRING_FORMAT),
                                StringUtil.ToDecimal(res.Value.Rows[0][KALANKOLI]).ToString(Statics.DECIMAL_STRING_FORMAT), StringUtil.ToDecimal(res.Value.Rows[0][PALET_SAYISI]).ToString(Statics.DECIMAL_STRING_FORMAT)));
                            worderInfos.Add(string.Format("Kutu İçi:\t{0}", StringUtil.ToDecimal(res.Value.Rows[0][KOLIICI]).ToString(Statics.DECIMAL_STRING_FORMAT)));
                            worderInfos.Add(string.Format("Çalışan Tezgah:\t{0} {1}", res.Value.Rows[0][ISTASYONKOD].ToString(), res.Value.Rows[0][ISTASYONAD].ToString()));
                            worderInfos.Add(string.Format("Çalışan Stok:\t{0} {1}", res.Value.Rows[0][STOKKOD].ToString(), res.Value.Rows[0][STOKAD].ToString()));
                            worderInfos.Add(string.Format("Üretim Başlangıç:\t{0}", res.Value.Rows[0][URETIMBASLAMA].ToString()));
                            int worderacop = StringUtil.ToInteger(res.Value.Rows[0][URETIMID].ToString());
                            if (worderacop > 0) GetEmployees(worderacop);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void GetEmployees(int worder_ac_op_id)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT we.""worder_employee_id"",we.""line_no"",
we.""prd_employee_id"",CONCAT(emp.""emp_name"",' ', emp.""emp_surname"") ""fullname"",we.""status"",we.""start_date"" 
FROM ""uyumsoft"".""zz_worder_employee"" we LEFT JOIN ""uyumsoft"".""prdd_employee"" emp ON we.""prd_employee_id"" = emp.""prd_employee_id""
WHERE we.""worder_ac_op_id"" = {0} ", worder_ac_op_id);

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
                        worderInfos.Add("\tPersoneller");
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            for (int i = 0; i < res.Value.Rows.Count; i++)
                            {
                                worderInfos.Add(res.Value.Rows[i][3].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                GetPackages(worder_ac_op_id);
            }
        }

        private void GetPackages(int worder_ac_op_id)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sbSqlString = new StringBuilder();
                sbSqlString.AppendFormat(@"SELECT pkg.package_no,emp.emp_name || ' ' || emp.emp_surname user_code,CASE WHEN pkg.is_real = 1 THEN 'Üretildi' ELSE 'Bekliyor' END durum FROM zz_package_m pkg LEFT JOIN prdd_employee emp ON pkg.user_code = emp.citizenship_no 
WHERE pkg.worder_ac_op_id = {0} ORDER BY pkg.package_id DESC ", worder_ac_op_id);

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
                        worderInfos.Add("\tEtiketler");
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            for (int i = 0; i < res.Value.Rows.Count; i++)
                            {
                                worderInfos.Add(string.Format("{0}\t{1}\t{2}", res.Value.Rows[i][0].ToString(), res.Value.Rows[i][1].ToString(), res.Value.Rows[i][2].ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
