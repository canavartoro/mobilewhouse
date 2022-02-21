﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Models;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using System.Diagnostics;
using MobileWhouse.Log;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PRD
{
    [UyumModule("PRD006", "MobileWhouse.Controls.PRD.UretimGirisControl", "Palet Oluşturma")]
    public partial class UretimGirisControl : BaseControl
    {
        public UretimGirisControl()
        {
            InitializeComponent();
        }

        private int worder_m_id = 0;

        private void ClearForm()
        {
            //txtistasyon.Text = "";
            listView1.Items.Clear();
            lblbilgi.Text = "";
            worder_m_id = 0;
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

                Cursor.Current = Cursors.WaitCursor;

                package_m package = package_m.GetPackage(txtbarkod.Text);
                if (chksil.Checked)
                {
                    bool finded = false;
                    if (listView1.Items.Count > 0)
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            if (listView1.Items[i].SubItems[3].Text == package.package_no)
                            {
                                finded = true;
                                listView1.Items.RemoveAt(i);
                            }
                        }
                    }
                    if (!finded)
                    {
                        Screens.Error("Okutulan barkod listede bulunamadı!");
                        return;
                    }
                }
                else
                {
                    if (worder_m_id == 0) worder_m_id = package.worder_m_id;
                    if (worder_m_id != package.worder_m_id)
                    {
                        Screens.Error("Farklı işemri okutuldu! Palet İÇİN okutulan barkodlar hep aynı iş emrinden olmalı");
                        return;
                    }

                    if (!package.is_real)
                    {
                        if (!Screens.Question(string.Concat(package.package_no, " nolu barkod üretilmemiş. Üretilsin mi?")))
                        {
                            Screens.Error("Okutulan barkod üretilmemiş! " + package.package_no);
                            return;
                        }
                        MobileWhouse.ProdConnector.PrdGobalInfo wstation = secistasyon.SelectedObject as MobileWhouse.ProdConnector.PrdGobalInfo;
                        if (wstation == null)
                        {
                            Screens.Error("İstasyon seçilmedi!");
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

                        MobileWhouse.UyumSave.ServiceResultOfBoolean result = ClientApplication.Instance.SaveServ.SavePrdWorderAcOp(context);
                        if (!result.Result)
                        {
                            Screens.Error(result.Message);
                            return;
                        }
                        else
                        {
                            package_m.UpdatePackage(package, StringUtil.ToInteger(result.Message));
                        }
                    }// üretim sonu

                    if (package.is_created)
                    {
                        Screens.Error("Okutulan barkod paletlenmiş! " + package.palette_no);
                        return;
                    }
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].SubItems[3].Text == package.package_no)
                        {
                            Screens.Error(string.Concat(package.package_no, " daha önce okutulmuş!"));
                            return;
                        }
                    }

                    listView1.BeginUpdate();
                    ListViewItem item = new ListViewItem();
                    item.Text = package.item_code;
                    item.SubItems.Add(package.item_name);
                    item.SubItems.Add(package.qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                    item.SubItems.Add(package.package_no);
                    item.ImageIndex = 0;
                    item.Tag = package;
                    listView1.Items.Add(item);
                }
                lblbilgi.Text = string.Concat(listView1.Items.Count);
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                listView1.EndUpdate();
                Cursor.Current = Cursors.Default;
                txtbarkod.Text = "";
                txtbarkod.Focus();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void txtbarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) GetPackage();
        }

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            GetPackage();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                MobileWhouse.ProdConnector.PrdGobalInfo wstation = secistasyon.SelectedObject as MobileWhouse.ProdConnector.PrdGobalInfo;
                if (wstation == null)
                {
                    Screens.Error("İstasyon seçilmedi!");
                    return;
                }

                if (listView1.Items.Count == 0)
                {
                    Screens.Error("Koli barkodları okutulmalıdır!");
                    return;
                }

                Screens.ShowWait();

                string[] ids = new string[listView1.Items.Count];
                MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfPackageTraMInfo();
                param.Token = ClientApplication.Instance.ProdToken;
                param.Value = new MobileWhouse.ProdConnector.PackageTraMInfo();
                param.Value.Whouse2Id = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.Details = new MobileWhouse.ProdConnector.PackageTraDInfo[listView1.Items.Count];
                decimal qty_net = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    package_m package = listView1.Items[i].Tag as package_m;

                    if (i == 0)
                    {
                        param.Value.SourceMId = package.erp_worder_ac_op_id;
                    }

                    qty_net += package.qty;
                    param.Value.DocDate = package.create_date.Date;

                    ids[i] = package.package_id.ToString();

                    param.Value.Details[i] = new MobileWhouse.ProdConnector.PackageTraDInfo();
                    param.Value.Details[i].ItemId = package.item_id;
                    param.Value.Details[i].PackageMNo = package.package_no;
                    param.Value.Details[i].Qty = package.qty;
                    param.Value.Details[i].UnitId = package.unit_id;
                    param.Value.Details[i].SourceMId = param.Value.SourceMId;

                }
                param.Value.PackageMQty = qty_net;

                MobileWhouse.ProdConnector.ServiceResultOfPackageTraDInfo res = ClientApplication.Instance.ProdService.SavePackageTraM(param);
                if (res.Result)
                {
                    //if (uretimgirisprint.IsSelectPrinter)
                    //    uretimgirisprint.Print(12000006, "rpp_prd_9010", "ItemMId", res.Value.PackageMId);

                    if (uretimgirisprint.IsSelectPrinter)
                        uretimgirisprint.Print(string.Concat(" \"barcode\" = '", res.Value.PackageMNo, "'  "));

                    StringBuilder sbSqlString = new StringBuilder();
                    sbSqlString.AppendFormat(@"UPDATE zz_package_m SET package_tra_m_id = {0}, palette_no = '{1}', is_created = 1  ", res.Value.PackageMId, res.Value.PackageMNo);
                    sbSqlString.AppendFormat("WHERE package_id IN ({0})", string.Join(",", ids));

                    MobileWhouse.UyumConnector.ServiceRequestOfString paramsql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                    paramsql.Token = ClientApplication.Instance.Token;
                    paramsql.Value = sbSqlString.ToString();
                    Logger.I(paramsql.Value);
                    ClientApplication.Instance.Service.ExecuteSQL(paramsql);
                    ClearForm();
                }
                else
                {
                    Screens.Error(res.Message);
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

    }
}
