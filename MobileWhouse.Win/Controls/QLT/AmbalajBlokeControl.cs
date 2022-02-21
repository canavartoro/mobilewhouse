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
using MobileWhouse.Dilogs;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.QLT
{
    [UyumModule("QLT002", "MobileWhouse.Controls.QLT.AmbalajBlokeControl", "Kalite Bloke")]
    public partial class AmbalajBlokeControl : BaseControl
    {
        public AmbalajBlokeControl()
        {
            InitializeComponent();
        }

        MobileWhouse.UTermConnector.PackageDetail package = null;
        MobileParameter mobileParam = null;
        private EmployeeLogin operatorLogin = new EmployeeLogin();

        private void btnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new QLTControl());
        }

        private void btnklavye_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txtbarkod);
        }

        private void btnbarkod_Click(object sender, EventArgs e)
        {
            txtbarkod_KeyPress(txtbarkod, new KeyPressEventArgs((char)13));
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
                    txtbarkod.Text = "";

                    if (mobileParam == null)
                    {
                        mobileParam = MobileParameter.GetMobileParameter();
                        if (mobileParam == null)
                        {
                            Screens.Error("Mobil parametre bilgilerine ulaşılamadı! Sistem yöneticinize bildirin.");
                            return;
                        }
                    }


                    MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam _Ipp = new MobileWhouse.UTermConnector.ServiceRequestOfItemPickingParam();
                    _Ipp.Token = ClientApplication.Instance.UTermToken;
                    _Ipp.Value = new MobileWhouse.UTermConnector.ItemPickingParam();
                    if (checkkaldir.Checked)
                        _Ipp.Value.WhouseId = mobileParam.bloke_whouse_id;
                    else
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
                            lblbarkod.Text = package.PackageNo;
                            lblstok.Text = package.ItemInfo.Name;
                            lblmiktar.Text = package.ItemInfo.Qty.ToString(Statics.DECIMAL_STRING_FORMAT);
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
                    txtbarkod.Focus();
                    txtbarkod.SelectAll();
                }
            }
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!operatorLogin.Login()) return;
                if (!operatorLogin.Operator.qlt002)
                {
                    Screens.Error("Bu işlem için yetkiniz yok!");
                    return;
                }

                if (package != null && Screens.Question("Ambalaj bloke edilsin mi?"))
                {
                    if (mobileParam == null)
                    {
                        mobileParam = MobileParameter.GetMobileParameter();
                        if (mobileParam == null)
                        {
                            Screens.Error("Mobil parametre bilgilerine ulaşılamadı! Sistem yöneticinize bildirin.");
                            return;
                        }
                    }

                    Screens.ShowWait();

                    MobileWhouse.Models.DepotExtention depoext = new MobileWhouse.Models.DepotExtention(new MobileWhouse.UyumConnector.Depot { Id = mobileParam.bloke_whouse_id });
                    if (depoext.is_location_track && depoext.input_location_id == 0)
                    {
                        Screens.Error("Depo giriş raf tanımı hatalı!");
                    }

                    PackageTraM ambhareket = new PackageTraM();
                    ambhareket.CoId = ClientApplication.Instance.Token.CoId;
                    ambhareket.BranchId = ClientApplication.Instance.Token.BranchId;
                    ambhareket.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                    ambhareket.WhouseCode = ClientApplication.Instance.SelectedDepot.Code;

                    if (checkkaldir.Checked)
                    {
                        ambhareket.Whouse2Id = ClientApplication.Instance.SelectedDepot.Id;
                        ambhareket.Whouse2Code = ClientApplication.Instance.SelectedDepot.Name;
                    }
                    else
                    {
                        ambhareket.Whouse2Id = mobileParam.bloke_whouse_id;
                        ambhareket.Whouse2Code = mobileParam.bloke_whouse_code;
                    }

                    ambhareket.DocNo =
                    ambhareket.PackageNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                    ambhareket.PackageOperationType = "Transfer";
                    ambhareket.InventoryStatus = "Transfer";
                    ambhareket.SourceApp = "Ambalaj";
                    ambhareket.PTypes = "Empty";
                    ambhareket.Qty = 0;
                    ambhareket.DocDate = DateTime.Today;
                    ambhareket.DocTraId = mobileParam.bloke_doc_tra_id;
                    ambhareket.DocTraCode = mobileParam.bloke_doc_tra_code;
                    ambhareket.Note1 = operatorLogin.Operator.citizenship_no;
                    ambhareket.Note2 = textNot.Text;
                    ambhareket.UyumDetailItem = new AmbalajHareketDetail[1];

                    ambhareket.UyumDetailItem[0] = new AmbalajHareketDetail();
                    ambhareket.UyumDetailItem[0].CoId = ambhareket.CoId;
                    ambhareket.UyumDetailItem[0].BranchId = ambhareket.BranchId;
                    ambhareket.UyumDetailItem[0].AddString01 = "";
                    ambhareket.UyumDetailItem[0].ItemId = package.ItemInfo.Id;
                    ambhareket.UyumDetailItem[0].ItemCode = package.ItemInfo.Name;
                    ambhareket.UyumDetailItem[0].LineNo = 10;
                    ambhareket.UyumDetailItem[0].Qty = package.Qty;
                    ambhareket.UyumDetailItem[0].UnitId = package.ItemInfo.UnitId;
                    ambhareket.UyumDetailItem[0].PackageDetailType = "A";
                    ambhareket.UyumDetailItem[0].DcardId = package.ItemInfo.Id;
                    ambhareket.UyumDetailItem[0].DcardCode = package.ItemInfo.Name;
                    ambhareket.UyumDetailItem[0].PackageMId = package.PackageMId;
                    ambhareket.UyumDetailItem[0].PackageMNo = package.PackageNo;
                    ////if (_SelectedRaf != null)
                    {
                        ambhareket.UyumDetailItem[0].BwhLocationId = depoext.input_location_id;//_SelectedRaf.Id;
                        //ambdetay.LocationCode = _SelectedRaf.Name;//sakın gönderme valla patlar
                    }
                    ambhareket.UyumDetailItem[0].PackageOperationType = ambhareket.PackageOperationType;


                    MobileWhouse.UyumSave.UyumServiceRequestOfString Context = new MobileWhouse.UyumSave.UyumServiceRequestOfString();
                    Context.Token = new MobileWhouse.UyumSave.UyumToken();
                    Context.Token.UserName = ClientApplication.Instance.Token.UserName;
                    Context.Token.Password = ClientApplication.Instance.Token.Password;
                    Context.Value = ambhareket.ToXml();
                    MobileWhouse.UyumSave.UyumServiceResponseOfString resp = ClientApplication.Instance.SaveServ.SaveUyumObjectFromXML(Context);
                    if (!resp.Success)
                    {
                        Screens.Error(resp.Message);
                    }
                    else
                    {
                        PackageTraM ambhar = (PackageTraM)BaseModel.FromXml(typeof(PackageTraM), resp.Value);
                        Screens.Info(string.Concat("Belge kaydedildi. ", ambhar.Id, ", No:", ambhar.DocNo));

                        lblbarkod.Text = "";
                        lblstok.Text = "";
                        lblmiktar.Text = "";
                        package = null;
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
                txtbarkod.Focus();
            }
        }

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textNot);
        }

        private void textNot_GotFocus(object sender, EventArgs e)
        {
            Screens.ShowKeyboard(true);
        }

        private void textNot_LostFocus(object sender, EventArgs e)
        {
            Screens.ShowKeyboard(false);
        }

    }
}
