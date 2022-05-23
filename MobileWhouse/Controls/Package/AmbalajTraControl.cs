using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Util;
using MobileWhouse.Models;
using MobileWhouse.Dilogs;
using MobileWhouse.UyumSave;
using System.Threading;
using MobileWhouse.Log;
using MobileWhouse.Attributes;
namespace MobileWhouse.Controls.Package
{
    [UyumModule("PKG003", "MobileWhouse.Controls.Package.AmbalajTraControl", "Ambalaj Transfer")]
    public partial class AmbalajTraControl : BaseControl
    {
        public AmbalajTraControl()
        {
            InitializeComponent();
            txtRaf.DepoId = ClientApplication.Instance.SelectedDepot.Id;
        }

        //const string DOCTRA_FILE_NAME = "ambTraDocTra.xml";
        private DocTra selectedDocTra = null;
        private NameIdItem _SelectedRaf;
        private Depot depo;
        private EmployeeLogin operatorLogin = new EmployeeLogin();

        private void ProccesDataBarcode(string barcode)
        {
            try
            {
                Screens.ShowWait();

                MobileWhouse.UTermConnector.ServiceRequestOfInPacKageM param = new MobileWhouse.UTermConnector.ServiceRequestOfInPacKageM();
                param.Token = ClientApplication.Instance.UTermToken;
                param.Value = new MobileWhouse.UTermConnector.InPacKageM();
                param.Value.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                param.Value.PackageNo = barcode;
                MobileWhouse.UTermConnector.ServiceResultOfOutPacKageD result = ClientApplication.Instance.UTermService.GetPackageMInfo(param);

                if (result.Result == false)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                if (!checksil.Checked) //ITEM_M_TMP ve ITEM_D_TMP Ekleme
                {
                    listView1.Focus();
                    #region master kayıt ekleme ve detay ekleme
                    bool pupdate = false;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].Selected = false;
                        MobileWhouse.UTermConnector.OutPacKageD package = listView1.Items[i].Tag as MobileWhouse.UTermConnector.OutPacKageD;
                        if (package.PackageMId == result.Value.PackageMId)
                        {
                            listView1.Items[i].Selected = true;
                            pupdate = true;
                        }
                    }
                    if (!pupdate)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = result.Value;
                        item.Text = result.Value.PackageNo;
                        item.SubItems.Add(result.Value.Qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                        item.SubItems.Add(result.Value.ItemCode);
                        item.SubItems.Add(result.Value.ItemName);
                        listView1.Items.Add(item);
                    }

                    //int icounter = Convert.ToInt32(DateTime.Now.ToString("hmsfff"));
                    //CreateNewDataRow(_PacKageD.Value.PackageMId,
                    //                 _PacKageD.Value.PackageNo,
                    //                 _PacKageD.Value.ItemId,
                    //                 _PacKageD.Value.ItemCode,
                    //                 _PacKageD.Value.ItemName,
                    //                 _PacKageD.Value.UnitId,
                    //                 _PacKageD.Value.UnitCode,
                    //                 _PacKageD.Value.Qty,
                    //                 _PacKageD.Value.LotId,
                    //                 _PacKageD.Value.LotCode,
                    //                 _PacKageD.Value.BranchUnitQty);
                    #endregion
                }
                else //ITEM_D_TMP QtyPRM update > Satırda Okutulan Barkodu silmek içindir.
                {
                    #region Detaydan okutulan barkodu silme
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        MobileWhouse.UTermConnector.OutPacKageD package = listView1.Items[i].Tag as MobileWhouse.UTermConnector.OutPacKageD;
                        if (package.PackageMId == result.Value.PackageMId)
                        {
                            listView1.Items.RemoveAt(i);
                            break;
                        }
                    }
                    #endregion Detaydan okutulan barkodu silme
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Screens.HideWait();
                lblokunan.Text = listView1.Items.Count.ToString();
            }
        }

        public override void OnRafBarkod(NameIdItem raf)
        {
            base.OnRafBarkod(raf);
            _SelectedRaf = raf;
            txtRaf.Text = raf.Name;
        }

        private void AmbalajTraControl_OnLoad(object sender, EventArgs e)
        {
            try
            {
                depo = ClientApplication.Instance.SelectedDepot;
                textDepo.Text = depo.Code;
                textDepo.OnPress();
                txtRaf.DepoId = depo.Id;
                //string selectedAmbDocTra = FileHelper.ReadFile("ambTraDocTra.xml");
                //if (!string.IsNullOrEmpty(selectedAmbDocTra))
                //{
                //    selectedDocTra = FileHelper.FromXml(selectedAmbDocTra, typeof(DocTra)) as DocTra;
                //    if (selectedDocTra == null)
                //    {
                //        FileHelper.DeleteFile(DOCTRA_FILE_NAME);
                //    }
                //    else
                //    {
                //        textHareket.Text = string.Concat(selectedDocTra.DocTraCode, " ", selectedDocTra.DocTraDesc);
                //    }
                //}
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }

        private void textBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string barkod = textBarkod.Text;
                ProccesDataBarcode(barkod);
                textBarkod.Text = "";
                textBarkod.Focus();
            }
        }

        private void uButton1_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajMenuControl());
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!operatorLogin.Login()) return;
                if (!operatorLogin.Operator.pkg003)
                {
                    Screens.Error("Bu işlem için yetkiniz yok!");
                    return;
                }

                StringBuilder validate = new StringBuilder();
                if (listView1.Items.Count == 0)
                {
                    validate.AppendLine("Okutma yapılmadı!");
                }
                if (selectedDocTra == null)
                {
                    validate.AppendLine("Hareket kodu seçilmelidir!");
                }

                if (depo == null)
                {
                    validate.AppendLine("Depo seçilmedi!");
                }

                if (depo.Id == ClientApplication.Instance.SelectedDepot.Id && _SelectedRaf == null)
                {
                    validate.AppendLine("Depo içi raf hareketinde Raf kodu zorunludur!");
                }

                DepotExtention depoext = new DepotExtention(depo);
                if (depoext.is_location_track && depoext.input_location_id == 0)
                {
                    validate.AppendLine("Depo giriş raf tanımı hatalı!");
                }
                if (validate.Length > 0)
                {
                    Screens.Error(validate.ToString());
                    return;
                }

                Screens.ShowWait();

                PackageTraM ambhareket = new PackageTraM();
                ambhareket.CoId = ClientApplication.Instance.Token.CoId;
                ambhareket.BranchId = ClientApplication.Instance.Token.BranchId;
                ambhareket.WhouseId = ClientApplication.Instance.SelectedDepot.Id;
                ambhareket.WhouseCode = ClientApplication.Instance.SelectedDepot.Code;
                if (depo != null)
                {
                    ambhareket.Whouse2Id = depo.Id;
                    ambhareket.Whouse2Code = depo.Code;
                }
                ambhareket.DocNo =
                ambhareket.PackageNo = DateTime.Now.ToString("yyMMddHHmmssfff");
                if (selectedDocTra.Status == 3)
                {
                    ambhareket.PackageOperationType = "Transfer";
                    ambhareket.InventoryStatus = "Transfer";
                }
                else if (selectedDocTra.Status == 2)
                {
                    ambhareket.PackageOperationType = "Sevk";
                    ambhareket.InventoryStatus = "Çıkış";
                }
                else
                {
                    ambhareket.PackageOperationType = "Giriş";
                    ambhareket.InventoryStatus = "Giriş";
                }
                ambhareket.SourceApp = "Ambalaj";
                ambhareket.PTypes = "Empty";
                ambhareket.Qty = 0;
                ambhareket.DocDate = DateTime.Today;
                ambhareket.DocTraId = selectedDocTra.Id;
                ambhareket.DocTraCode = selectedDocTra.DocTraCode;
                ambhareket.UyumDetailItem = new AmbalajHareketDetail[listView1.Items.Count];
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    MobileWhouse.UTermConnector.OutPacKageD package = listView1.Items[i].Tag as MobileWhouse.UTermConnector.OutPacKageD;
                    ambhareket.UyumDetailItem[i] = new AmbalajHareketDetail();
                    ambhareket.UyumDetailItem[i].CoId = ambhareket.CoId;
                    ambhareket.UyumDetailItem[i].BranchId = ambhareket.BranchId;
                    ambhareket.UyumDetailItem[i].AddString01 = "";
                    ambhareket.UyumDetailItem[i].ItemId = package.ItemId;
                    ambhareket.UyumDetailItem[i].ItemCode = package.ItemCode;
                    ambhareket.UyumDetailItem[i].LotId = package.LotId;
                    ambhareket.UyumDetailItem[i].LineNo = (i + 1) * 10;
                    ambhareket.UyumDetailItem[i].Qty = package.Qty;
                    ambhareket.UyumDetailItem[i].UnitId = package.UnitId;
                    ambhareket.UyumDetailItem[i].UnitCode = package.UnitCode;
                    ambhareket.UyumDetailItem[i].PackageDetailType = "A";
                    ambhareket.UyumDetailItem[i].DcardId = package.ItemId;
                    ambhareket.UyumDetailItem[i].DcardCode = package.ItemCode;
                    ambhareket.UyumDetailItem[i].PackageMId = package.PackageMId;
                    ambhareket.UyumDetailItem[i].PackageMNo = package.PackageNo;
                    ////if (_SelectedRaf != null)
                    {
                        if (_SelectedRaf != null)
                            ambhareket.UyumDetailItem[i].BwhLocationId = _SelectedRaf.Id;
                        else
                            ambhareket.UyumDetailItem[i].BwhLocationId = depoext.input_location_id;//_SelectedRaf.Id;
                        //ambdetay.LocationCode = _SelectedRaf.Name;//sakın gönderme valla patlar
                    }
                    ambhareket.UyumDetailItem[i].PackageOperationType = ambhareket.PackageOperationType;
                }

                MobileWhouse.UyumSave.UyumServiceRequestOfString Context = new MobileWhouse.UyumSave.UyumServiceRequestOfString();
                Context.Token = new MobileWhouse.UyumSave.UyumToken();
                Context.Token.UserName = ClientApplication.Instance.Token.UserName;
                Context.Token.Password = ClientApplication.Instance.Token.Password;
                Context.Value = ambhareket.ToXml();
                UyumServiceResponseOfString resp = ClientApplication.Instance.SaveServ.SaveUyumObjectFromXML(Context);
                if (!resp.Success)
                {
                    Screens.Error(resp.Message);
                }
                else
                {
                    PackageTraM ambhar = (PackageTraM)BaseModel.FromXml(typeof(PackageTraM), resp.Value);
                    Screens.Info(string.Concat("Belge kaydedildi. ", ambhar.Id, ", No:", ambhar.DocNo));
                    listView1.Items.Clear();
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

        private void textHareket_OnSelected(object sender, object obj)
        {
            selectedDocTra = obj as DocTra;
        }

        private void textDepo_OnSelected(object sender, object obj)
        {
            depo = obj as Depot;
            if (depo != null)
            {
                _SelectedRaf = null;
                txtRaf.DepoId = depo.Id;
            }
        }
    }
}
