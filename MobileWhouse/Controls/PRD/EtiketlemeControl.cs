using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.Models;
using MobileWhouse.Util;
using System.Diagnostics;
using System.Threading;
using MobileWhouse.Log;

namespace MobileWhouse.Controls.PRD
{
    public partial class EtiketlemeControl : BaseControl
    {
        public EtiketlemeControl()
        {
            InitializeComponent();
        }

        private MobileWhouse.ProdConnector.PrdGobalInfo wstation = null;
        private worder_ac_op worder_acop = null;

        private void GetProducts()
        {
            try
            {
                if (wstation == null) return;

                Cursor.Current = Cursors.WaitCursor;

                worder_acop = worder_ac_op.GetProducts(wstation.PrdGobalId);
                if (worder_acop != null)
                {
                    txtisemri.Text = string.Concat(worder_acop.worder_no, " ", worder_acop.item_code);
                    btnyazdir.Enabled = true;
                }
                else
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void txtisemri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnistasyon_Click(object sender, EventArgs e)
        {
            using (FormSelectWstation frm = new FormSelectWstation())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.Wstation != null)
                {
                    wstation = frm.Wstation;
                    txtistasyon.Text = string.Concat(wstation.PrdGobalCode, " ", wstation.PrdGobalName);
                    GetProducts();
                }
            }
        }

        private void btnyazdir_Click(object sender, EventArgs e)
        {
            try
            {
                if (wstation == null)
                {
                    Screens.Error("İstasyonda seçilmedi!");
                    return;
                }

                if (worder_acop == null)
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
                }

                if (string.IsNullOrEmpty(txtkoliici.Text)) txtkoliici.Text = "1";
                if (string.IsNullOrEmpty(txtadet.Text)) txtadet.Text = "1";
                decimal adet = 1;
                int koli = 1;

                try
                {
                    adet = StringUtil.ToDecimal(txtkoliici.Text);
                    koli = StringUtil.ToInteger(txtadet.Text);
                }
                catch (Exception ex)
                {
                    Screens.Warning(string.Concat("Girdiğiniz değerleri kontrol edin! Hatalı giriş yapıldı. ", ex.Message));
                    return;
                }

                if (adet < 1 || koli < 1 || koli > 10)
                {
                    Screens.Warning(string.Concat("Girdiğiniz değerleri kontrol edin! Hatalı giriş yapıldı. "));
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;

                for (int i = 0; i < koli; i++)
                {
                    param.Value = new StringBuilder().Append(@"INSERT INTO ""uyumsoft"".""zz_package_m"" (""create_user_id"",""create_date"",""worder_ac_op_id"",""worder_m_id"",""worder_op_d_id"",""operation_id"",""operation_no"",""item_id"",""unit_id"",""qty"",""whouse_id"") VALUES (")
                   .AppendFormat("'{0}',CURRENT_TIMESTAMP,", ClientApplication.Instance.ClientToken.UserId)
                   .AppendFormat("'{0}','{1}','{2}','{3}','{4}',", worder_acop.worder_ac_op_id, worder_acop.worder_m_id, worder_acop.worder_op_d_id, worder_acop.operation_id, worder_acop.operation_no)
                   .AppendFormat("'{0}','{1}','{2}',", worder_acop.item_id, worder_acop.unit_id, adet.ToString(Statics.DECIMAL_STRING_FORMAT))
                   .AppendFormat("'{0}')", ClientApplication.Instance.SelectedDepot.Id)
                   .Append(@" RETURNING ""package_no"",""package_id"" ").ToString();

                    Logger.I(param.Value);

                    MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                    if (res != null)
                    {
                        if (res.Result == false)
                        {
                            MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                            break;
                        }
                        else
                        {
                            if (res.Value != null && res.Value.Rows.Count > 0)
                            {
                                txtbarkod.Text = res.Value.Rows[0][0].ToString();

                                //if (printetiketleme.IsSelectPrinter)
                                //    printetiketleme.Print(221102615313372M, "rpp_prd_9009", "pitemmid", StringUtil.ToInteger(res.Value.Rows[0][1]));

                                if (printetiketleme.IsSelectPrinter)
                                    printetiketleme.Print(221121015401868M, "rpp_prd_9011", "pitemmid", StringUtil.ToInteger(res.Value.Rows[0][1]));



                                //string printerName, int userId, string userPassword, decimal reportCode, string procecureName, string[] parameterField, object[] parameterValue
                                //string printing = ClientApplication.Instance.ReportServ.SendDirectReport2();

                                //var result = ClientApplication.Instance.UTermService.DirectPrintFromServer(new MobileWhouse.UTermConnector.ServiceRequestOfDirectPrintInParamsIn
                                //{
                                //    Token = ClientApplication.Instance.UTermToken,
                                //    Value = new MobileWhouse.UTermConnector.DirectPrintInParamsIn
                                //    {
                                //        PageCode = "rpp_prd_9009",
                                //        PrinterName = "Microsoft XPS Document Writer",//@"\\10.0.0.10\HPColor",
                                //        PrintItemId = Convert.ToInt32(res.Value.Rows[0][1])
                                //    }
                                //});

                                //var result = ClientApplication.Instance.UTermService.PackageBarcodePrint(new MobileWhouse.UTermConnector.ServiceRequestOfString
                                //{
                                //    Token = ClientApplication.Instance.UTermToken,
                                //    Value = txtbarkod.Text
                                //});

                                //if (result.Result)
                                //{
                                //    MessageBox.Show("Barkod Yazıldı");
                                //}
                                //else
                                //{
                                //    MessageBox.Show(result.Message, "Hata");
                                //}
                            }
                        }
                    }

                    Thread.Sleep(200);
                    Application.DoEvents();
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

            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;

            //    MobileWhouse.UyumConnector.ServiceRequestOfSelectParam packageParam = new MobileWhouse.UyumConnector.ServiceRequestOfSelectParam();
            //    packageParam.Value = new MobileWhouse.UyumConnector.SelectParam();
            //    packageParam.Token = ClientApplication.Instance.Token;
            //    packageParam.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;

            //    MobileWhouse.UyumConnector.ServiceResultOfPackageInfo packageInfo = ClientApplication.Instance.Service.CreateNewPackage(packageParam);

            //    if (!packageInfo.Result)
            //    {
            //        throw new Exception(packageInfo.Message);
            //    }
            //    else
            //    {

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MobileWhouse.Util.Screens.Error(ex);
            //}
            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //}
        }
    }
}

/*
 SELECT APPD_REPORTS_U.REPORT_ID, ML_APPD_REPORTS_U.REPORT_NAME AS REPORT_NAME, 
APPD_REPORTS_U.REPORT_FILE_NAME, ML_APPD_REPORTS_U.REPORT_DESC AS REPORT_DESC, 
APPD_REPORTS_U.REPORT_TYPE, APPD_REPORTS_U.SOURCE_APP, 
APPD_REPORTS_U.REPORT_CODE, APPD_REPORTS_U.PAGE_CODE, APPD_REPORTS_U.DEFAULT_REPORT, 
APPD_REPORTS_U.IS_ODBC_REPORT, APPD_REPORTS_U.IS_MOBILE, APPD_REPORTS_U.REPORTS_PARAMS_XML, APPD_REPORTS_U.DEFAULT_EMAIL 
FROM APPD_REPORTS_U  LEFT JOIN APPD_REPORTS_U_LANG ML_APPD_REPORTS_U ON ML_APPD_REPORTS_U.LANG_ID=64 
AND ML_APPD_REPORTS_U.REPORT_ID=APPD_REPORTS_U.REPORT_ID 
WHERE APPD_REPORTS_U.PAGE_CODE = 'PRD9009'

 */