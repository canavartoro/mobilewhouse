using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Models;
using MobileWhouse.Util;
using MobileWhouse.ProdConnector;
using MobileWhouse.Log;
using System.Data.SqlClient;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    [UyumModule("PRD009", "MobileWhouse.Controls.PRD.HurdaTartimControl", "Hurda Tartım")]
    public partial class HurdaTartimControl : BaseControl
    {
        public HurdaTartimControl()
        {
            InitializeComponent();
        }

        private void GetPackage()
        {
            try
            {
                if (string.IsNullOrEmpty(txtbarkod.Text))
                {
                    txtbarkod.Focus();
                    return;
                }

                decimal qtyScrap = txtmiktar.DecimalValue;
                if (qtyScrap <= 0)
                {
                    Screens.Error("Hurda miktarı girin!");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                package_m package = package_m.GetPackage(txtbarkod.Text);
                if (package == null)
                {
                    Screens.Error("Okutulan barkod sistemde bulunamadı!");
                    return;
                }
                else
                {
                    if (package.is_created)
                    {
                        Screens.Error("Okutulan barkod paletlenmiş! " + package.palette_no);
                        return;
                    }
                    if (!package.is_scrapt)
                    {
                        Screens.Error("Okutulan barkod hurda barkodu değil! " + package.palette_no);
                        return;
                    }

                    ServiceRequestOfWorderAcOpInfo param = new ServiceRequestOfWorderAcOpInfo();
                    param.Token = ClientApplication.Instance.ProdToken;
                    param.Value = new WorderAcOpInfo();
                    param.Value.Id = package.worder_ac_op_id;
                    param.Value.WorderOpDId = package.worder_op_d_id;
                    param.Value.WorderMId = package.worder_m_id;
                    param.Value.WorderScrapMaterialList = new WorderScrapMaterialInfo[1];
                    param.Value.WorderScrapMaterialList[0] = new WorderScrapMaterialInfo();
                    param.Value.WorderScrapMaterialList[0].ScrapReasonId = package.scrap_reason_id;
                    param.Value.WorderScrapMaterialList[0].QtyScrap = qtyScrap;
                    param.Value.WorderScrapMaterialList[0].SourceBomMId = package.worder_ac_bom_m_id;
                    param.Value.WorderScrapMaterialList[0].SourceItemId = package.item_id;
                    param.Value.WorderScrapMaterialList[0].UnitId = package.unit_id;
                    param.Value.WorderScrapMaterialList[0].ScrapResultType = package.scrap_result_type; //Mamul = 1,Malzeme = 2,FarkliKod = 3,YanUrun = 4,DemonteUrun = 5,TersUrun = 6
                    param.Value.WorderScrapMaterialList[0].WorderBomDId = package.worder_ac_bom_d_id;
                    param.Value.WorderScrapMaterialList[0].NoteLarge = "El terminalinden oluşturuldu";
                    param.Value.WorderScrapMaterialList[0].DiffItemId = package.diff_item_id;
                    param.Value.WorderScrapMaterialList[0].DiffUnitId = package.diff_unit_id;
                    param.Value.WorderScrapMaterialList[0].WhouseId = package.whouse_id;
                    param.Value.WorderScrapMaterialList[0].LineNo = package.worder_ac_bom_d_line_no;

                    ServiceResultOfInt32 res = ClientApplication.Instance.ProdService.SaveWorderScrap(param);
                    if (res.Result)
                    {
                        UpdatePackage(package, res.Value, qtyScrap);
                        //MainForm.ShowControl(null);
                    }
                    else
                    {
                        Screens.Error(res.Message);
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
                txtisemri.Text = "";
                txtmiktar.Text = "";
                txtbarkod.Text = "";
                txtbarkod.Focus();
            }
        }

        private void GetPackageWeight()
        {
            try
            {
                if (string.IsNullOrEmpty(txtbarkod.Text))
                {
                    txtbarkod.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                using (SqlConnection conn = new SqlConnection(Statics.SqlConnectionString))
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = string.Concat("SELECT TOP 1 BARKOD FROM PSBARKODNO WITH (NOLOCK) WHERE BARKOD LIKE '%", txtbarkod.Text, "%' ORDER BY TARIH DESC");
                    conn.Open();
                    object kantar = comm.ExecuteScalar();
                    if (kantar != null && kantar.ToString().IndexOf("AGIRLIK") != -1)
                    {
                        int start = kantar.ToString().IndexOf("AGIRLIK") + 8;
                        int length = kantar.ToString().Length - start;
                        string agirlik = kantar.ToString().Substring(start, length);
                        txtmiktar.Text = agirlik;
                        Application.DoEvents();
                    }
                    //else
                    //{
                    //    Screens.Warning("Barkod ağırlık bilgisi kantardan alınamadı!");
                    //}
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

        private void UpdatePackage(package_m package, int id, decimal qtyScrap)
        {
            try
            {
                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Concat("UPDATE uyumsoft.zz_package_m SET qty = ", qtyScrap.ToString(Statics.DECIMAL_STRING_FORMAT), ", erp_worder_ac_op_id = ", id,
                    ", update_date = CURRENT_TIMESTAMP, update_user_id = ", ClientApplication.Instance.ClientToken.UserId, "  WHERE package_id = ", package.package_id);
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void btnyazdir_Click(object sender, EventArgs e)
        {

        }

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            GetPackage();
        }

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetPackageWeight();
                GetPackage();
            }
        }
    }
}
