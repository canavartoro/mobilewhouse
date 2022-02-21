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
using MobileWhouse.Log;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    [UyumModule("PRD005", "MobileWhouse.Controls.PRD.EtiketOnayControl", "Üretim")]
    public partial class EtiketOnayControl : BaseControl
    {
        public EtiketOnayControl()
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
                    txtadet.Text = worder_acop.density.ToString(Statics.DECIMAL_STRING_FORMAT);
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

        private void GetPackage()
        {
            try
            {
                if (wstation == null)
                {
                    Screens.Error("İş istasyonu seçilmelidir!");
                    return;
                }

                if (worder_acop == null)
                {
                    Screens.Error("İstasyonda açık üretim bulunamadı!");
                    return;
                }
                if (string.IsNullOrEmpty(textbarkod.Text))
                {
                    textbarkod.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                package_m package = package_m.GetPackage(textbarkod.Text);
                if (package.is_created)
                {
                    Screens.Error("Okutulan barkod paletlenmiş! " + package.palette_no);
                    return;
                }
                if (package.is_real)
                {
                    Screens.Error("Okutulan barkod onaylanmış! " + package.palette_no);
                    return;
                }

                MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef context = new MobileWhouse.UyumSave.UyumServiceRequestOfPrdWorderDef();
                context.Token = new MobileWhouse.UyumSave.UyumToken();
                context.Token.Password = ClientApplication.Instance.Token.Password;
                context.Token.UserName = ClientApplication.Instance.Token.UserName;
                context.Value = new MobileWhouse.UyumSave.PrdWorderDef();
                context.Value.StartDate = package.create_date.Date;
                context.Value.EndDate = DateTime.Now.Date;
                context.Value.WorderMId = package.worder_m_id;
                context.Value.WorderOpDId = package.worder_op_d_id;
                context.Value.IsUseSendMaterialList = false;
                context.Value.ScrapQty = 0;
                context.Value.WstationId = wstation.PrdGobalId;
                context.Value.Qty = package.qty;
                context.Value.UnitId = package.unit_id;
                context.Value.Note = package.package_no;

                if (worder_acop.Employee != null && worder_acop.Employee.Count > 0)
                {
                    context.Value.WorderEmployeeList = new MobileWhouse.UyumSave.WorderEmployeeFields[worder_acop.Employee.Count];
                    for (int l = 0; l < worder_acop.Employee.Count; l++)
                    {
                        context.Value.WorderEmployeeList[l] = new MobileWhouse.UyumSave.WorderEmployeeFields();
                        context.Value.WorderEmployeeList[l].PrdEmployeeId = worder_acop.Employee[l].prd_employee_id;
                        context.Value.WorderEmployeeList[l].StartDate = worder_acop.start_date;
                        context.Value.WorderEmployeeList[l].EndDate = DateTime.Now;
                    }
                }
                MobileWhouse.UyumSave.ServiceResultOfBoolean result = ClientApplication.Instance.SaveServ.SavePrdWorderAcOp(context);
                if (!result.Result)
                {
                    Screens.Error(result.Message);
                }
                else 
                {
                   package_m.UpdatePackage(package, StringUtil.ToInteger(result.Message));
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                textbarkod.Text = "";
                textbarkod.Focus();
            }
        }

        private void txtisemri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void secistasyon_OnSelected(object sender, object obj)
        {
            wstation = secistasyon.SelectedObject as MobileWhouse.ProdConnector.PrdGobalInfo;
            if (wstation != null) GetProducts();
        }

        private void textbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) GetPackage();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }
    }
}
