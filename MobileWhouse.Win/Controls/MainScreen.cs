using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.Util;
using MobileWhouse.Controls.PRD;
using System.Diagnostics;
using MobileWhouse.Forms;
using MobileWhouse.Net;
using MobileWhouse.Models;
using MobileWhouse.Controls.Package;

namespace MobileWhouse.Controls
{
    public partial class MainScreen : BaseControl
    {
        public MainScreen()
        {
            InitializeComponent();
            ClientApplication.Instance.SelectedDepotChanged += new EventHandler(OnSelectedDepotChanged);
            lblversion.Text = string.Concat("V:", Program.Versiyon, " B:", Program.BuildNumber());
        }

        void OnSelectedDepotChanged(object sender, EventArgs e)
        {
            if (ClientApplication.Instance.SelectedDepot == null)
                btnSelectDepot.Text = "Depo Seç";
            else
                btnSelectDepot.Text = "Depo: " + ClientApplication.Instance.SelectedDepot.Name;
            bool enable = ClientApplication.Instance.SelectedDepot != null;
            btnSayim.Enabled = enable;
            btnSevkiyat.Enabled = enable;
            btnStokRafDurumu.Enabled = enable;
            btnRafHareketi.Enabled = enable;
            btnStokHareketi.Enabled = enable;
            btnStokTransfer.Enabled = enable;
            btnmalkabul.Enabled = enable;
            btnUretim.Enabled = enable;
            btnIrsaliye.Enabled = enable;
            btnkalite.Enabled = enable;
            btnambalaj.Enabled = enable;
            this.Focus();
        }

        private void btnSayim_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new SelectSayimType(ClientApplication.Instance.SelectedDepot));
        }

        private void btnStokHareketi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lutfen Hedef Depo Seciniz !");

            using (FormSelectDepot form = new FormSelectDepot())
            {
                form._OnlyWithLocation = false;
                form.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null && form.Selected.Id != ClientApplication.Instance.SelectedDepot.Id)
                {
                    MainForm.ShowControl(new StokHareketiControl(form.Selected));
                }
            }
        }

        private void btnRafHareketi_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new RafHareketiControl());
        }

        private void btnSevkiyat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new SevkControl());
        }

        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            using (FormSelectSevkiyat form = new FormSelectSevkiyat())
            {
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null)
                {
                    IrsaliyeOlusturControl control = new IrsaliyeOlusturControl(form.Selected);
                    MainForm.ShowControl(control);
                }
            }
        }

        private void btnStokRafDurumu_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new StokRafDurumuControl());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //MainForm.DialogResult = DialogResult.Abort;
            MainForm.Close();
            MainForm.Dispose();
            MainForm = null;
        }

        private void btnSelectDepot_Click(object sender, EventArgs e)
        {
            using (FormSelectDepot form = new FormSelectDepot())
            {
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null)
                {
                    ClientApplication.Instance.SelectedDepot = form.Selected;
                    FileHelper.SaveFile("selectedDepot.xml", FileHelper.ToXml(ClientApplication.Instance.SelectedDepot));
                }
            }
        }

        private void btnStokTransfer_Click(object sender, EventArgs e)
        {
            //MobileWhouse.Util.Screens.Error("Lutfen Hedef Depo Seciniz !");

            using (FormSelectDepot form = new FormSelectDepot())
            {
                form._OnlyWithLocation = false;
                form.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                if (form.ShowDialog() == DialogResult.OK
                    && form.Selected != null && form.Selected.Id != ClientApplication.Instance.SelectedDepot.Id)
                {

                    MainForm.ShowControl(new DepoTransferControl(form.Selected));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItemM item = new ItemM();//45172
            item.PurchaseSales = "Alış";
            item.CoId = 2715;
            item.DocTraId = 1292;
            item.EntityId = 1047799;
            item.CurrencyOption = "Sevk_Tarihindeki_Kur";
            item.InvoiceStatus = "İrsaliye";
            item.IsWaybil = true;
            item.BranchId = 6749;
            item.DocDate = new DateTime(2022, 2, 4).Date;
            item.InventoryStatus = "Giriş";
            item.ReceiptDate = new DateTime(2022, 2, 4).Date;
            item.EDespatchStatus = "Hazır";
            item.CurTraId = 114;
            item.DespatchAdviceTypeCode = "SEVK";
            item.EDespatchProfile = "TEMELIRSALIYE";
            item.IseDespatch = true;
            item.ActualDespatchDate = new DateTime(2022, 2, 4).Date;
            item.PSValForContract = "Alış";
            item.CardType = "Cari";
            item.CardCode = "120 00 00 0001";
            item.MCardId = 1047799;
            item.CreateUserId = 11886;
            item.CreateDate = DateTime.Now;
            item.Address1 = "İvedik Organize Sanayi Bölgesi 32. Cadde";
            item.Address2 = "729.Sokak No:32";
            item.Address3 = "İvedik";
            item.Amt = 2000;
            item.AmtDisc0 = 0;
            item.AmtDisc0Tra = 0;
            item.AmtDiscTotal = 0;
            item.AmtDiscTotalTra = 0;
            item.AmtOtv = 0;
            item.AmtOtvTra = 0;
            item.AmtReceipt = 0;
            item.AmtReceiptTra = 0;
            item.AmtRound = 0;
            item.AmtRoundTra = 0;
            item.AmtTra = 2000;
            item.AmtVat = 360;
            item.AmtVatDisc = 0;
            item.AmtVatDiscTra = 0;
            item.AmtVatTra = 360;
            item.AmtOtherTax = 0;
            item.AmtOtherTaxTra = 0;
            item.CountryId = 103;
            item.CurTraCode = "TRY";
            item.IsoCurTraCode = "TRY";
            item.CurRateTra = 1.000000000000000000M;
            item.Disc0Rate = 0;
            item.Disc1Rate = 0;
            item.Disc2Rate = 0;
            item.Disc0Rate = 0;
            item.DocNo = "123456-2";
            item.DueDay = 30;
            item.SourceApp = "SatınalmaSiparişi";
            item.SourceApp3 = "İrsaliye";
            item.SourceMId = 9288;
            item.VatDiscRate = 0.000000M;
            item.ZipCode = "06000";
            item.DocTraCode = "İRA-101";
            item.InvoiceType = "Normal";
            item.EbookDocumentType = "Yok";
            item.EntityCode = "120 00 00 0001";
            item.CoCode = "100";
            item.CoCurId = 114;
            item.PurchaseSalesVal = 1;
            item.AmtOiv = 0;
            item.AmtOivTra = 0;
            item.BrCountryId = 103;
            item.HasBrCountry = 1;
            item.PrdType = 1;
            item.IsOutsideEntityControls = true;

            ItemD itemd1 = new ItemD();
            itemd1.ItemId = 114539;
            itemd1.WhouseId = 3680;
            itemd1.CoId = 2715;
            itemd1.DcardId = 114539;
            itemd1.LineType = "S";
            itemd1.LotId = 1293;
            itemd1.LotCode = "20020002";
            itemd1.ReservationType = "Satış_Siparişi";
            itemd1.IsWaybil = true;
            itemd1.PurchaseSales = "Alış";
            itemd1.EntityId = 1047799;
            itemd1.DocTraId = 1292;
            itemd1.DocTraCode = "İRA-101";
            itemd1.ToleranceRateByItem = 0;
            itemd1.QtyInvoiced = 0;
            itemd1.Balance1 = 0;
            itemd1.Balance2 = 0;
            itemd1.Balance3 = 0;
            itemd1.MasterInvoiceStatus = "İrsaliye";
            itemd1.ReceiptDate = new DateTime(2022, 2, 4).Date;
            itemd1.EDespatchStatus = "Hazır";
            itemd1.TPlusMinus = 1;
            itemd1.SourceMId = 9288;
            itemd1.BranchId = 6749;
            itemd1.SourceApp = "SatınalmaSiparişi";
            itemd1.SourceApp3 = "İrsaliye";
            itemd1.SourceDId = 18270;
            itemd1.QtyScrap = 0;
            itemd1.StockMoveType = "StockMove";
            itemd1.DocNo = item.DocNo;
            itemd1.WoOutsideType = "TekOperasyon";
            itemd1.Qty = 100;
            itemd1.DefaultAsortMode = 1;
            itemd1.UnitPriceCost = 0;
            itemd1.DeliveredQuantity = 0;
            itemd1.ReceivedQuantity = 0;
            itemd1.AmtCost = 0;
            itemd1.AmtCost2 = 0;
            itemd1.AmtCostManual = 0;
            itemd1.AmtCostManual2 = 0;
            itemd1.PlusMinus = "Giriş";
            itemd1.CreateUserId = 11886;
            itemd1.CreateDate = DateTime.Now;
            itemd1.Amt = 1000;
            itemd1.AmtDisc0 = 0;
            itemd1.AmtDisc = 0;
            itemd1.AmtWithDisc = 1000;
            itemd1.AmtDisc1 = 0;
            itemd1.AmtDisc2 = 0;
            itemd1.AmtDisc3 = 0;
            itemd1.AmtDisc4 = 0;
            itemd1.AmtDisc5 = 0;
            itemd1.AmtDisc6 = 0;
            itemd1.AmtMaktuOtv = 0;
            itemd1.AmtOtv = 0;
            itemd1.AmtOiv = 0;
            itemd1.AmtTra = 1000;
            itemd1.AmtVat = 180;
            itemd1.AmtVatDisc = 0;
            itemd1.CurTraCode = "TRY";
            itemd1.CurRateTra = 1.000000000000000000M;
            itemd1.CurTraId = 114;
            itemd1.Disc1Rate = 0;
            itemd1.Disc2Rate = 0;
            itemd1.Disc3Rate = 0;
            itemd1.QtyFreePrm = 0;
            itemd1.QtyFreeSec = 0;
            itemd1.QtyPrm = 0;
            itemd1.VatCode = "18";
            itemd1.VatRate = 18.00M;
            itemd1.OtvRate = 0;
            itemd1.OivRate = 0;
            itemd1.UnitPrice = 10.00000000M;
            itemd1.UnitPriceTra = 10.00000000M;
            itemd1.VatDiscRate = 0.000000M;
            itemd1.VatId = 158;
            itemd1.VatStatus = "Hariç";
            itemd1.DueDay = item.DueDay;
            itemd1.WhouseCode = "D-030";
            itemd1.LineNo = 10;
            itemd1.UnitId = 165;
            itemd1.UnitCode = "KG";
            itemd1.AmtDisc0Tra = 0;
            itemd1.AmtDisc1Tra = 0;
            itemd1.AmtDisc2Tra = 0;
            itemd1.AmtDisc3Tra = 0;
            itemd1.AmtDisc4Tra = 0;
            itemd1.AmtDisc5Tra = 0;
            itemd1.AmtDisc6Tra = 0;
            itemd1.AmtDiscTra = 0;
            itemd1.AmtWithDiscTra = 1000.00M;
            itemd1.AmtWithDiscTraForUnit = 10;
            itemd1.UnitPriceTra = 0.00000000M;

            item.UyumDetailItem = new List<ItemD>();
            item.UyumDetailItem.Add(itemd1);

            MobileWhouse.UyumWebService.UyumServiceResponseOfString res = ClientApplication.Instance.SaveWebService(item);
            if (res != null)
            {
 
            }

            /*
	</UyumDetailItem>
	<UyumDetailItem DetailProperty="ItemDCollection">
		<DocDate>04.02.2022 00:00:00</DocDate>
		<ItemId>114540</ItemId>
		<WhouseId>3680</WhouseId>
		<CoId>2715</CoId>
		<DcardId>114540</DcardId>
		<LineType>S</LineType>
		<LotId>1292</LotId>
		<LotCode>1111111</LotCode>
		<Id>118565</Id>
		<ReservationType>Satış_Siparişi</ReservationType>
		<IsWaybil>True</IsWaybil>
		<PurchaseSales>Alış</PurchaseSales>
		<EntityId>1047799</EntityId>
		<DocTraId>1292</DocTraId>
		<DocTraCode>İRA-101</DocTraCode>
		<ToleranceRateByItem>0,00</ToleranceRateByItem>
		<BwhItemName>Terluran GP22 ABS</BwhItemName>
		<QtyInvoiced>0,00</QtyInvoiced>
		<BranchCode>100</BranchCode>
		<Balance1>0,00</Balance1>
		<Balance2>0,00</Balance2>
		<Balance3>0,00</Balance3>
		<MasterInvoiceStatus>İrsaliye</MasterInvoiceStatus>
		<ReceiptDate>04.02.2022 00:00:00</ReceiptDate>
		<eDespatchStatus>Hazır</eDespatchStatus>
		<ItemMId>45172</ItemMId>
		<TPlusMinus>1</TPlusMinus>
		<CoCode>100</CoCode>
		<Whouse1Desc>Üretim Depo</Whouse1Desc>
		<CoDesc>ÜSTÜN PLASTİK AMBALAJ SANAYİ VE TİCARET A.Ş.</CoDesc>
		<SourceMId>9288</SourceMId>
		<BranchId>6749</BranchId>
		<SourceApp>SatınalmaSiparişi</SourceApp>
		<SourceApp3>İrsaliye</SourceApp3>
		<SourceDId>18271</SourceDId>
		<QtyScrap>0,00</QtyScrap>
		<StockMoveType>StockMove</StockMoveType>
		<PropertyKey>1292|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0</PropertyKey>
		<DocNo>123456</DocNo>
		<WoOutsideType>TekOperasyon</WoOutsideType>
		<Qty>100,00000</Qty>
		<DefaultAsortMode>1</DefaultAsortMode>
		<UnitPriceCost>0,00000000</UnitPriceCost>
		<DeliveredQuantity>0,00000</DeliveredQuantity>
		<ReceivedQuantity>0,00000</ReceivedQuantity>
		<AmtCost>0,00</AmtCost>
		<AmtCost2>0,00</AmtCost2>
		<AmtCostManual>0,00</AmtCostManual>
		<AmtCostManual2>0,00</AmtCostManual2>
		<PlusMinus>Giriş</PlusMinus>
		<CreateUserId>11886</CreateUserId>
		<CreateDate>04.02.2022 13:50:12</CreateDate>
		<Amt>1000,00</Amt>
		<AmtDisc0>0,00</AmtDisc0>
		<AmtDisc>0,00</AmtDisc>
		<AmtWithDisc>1000,00</AmtWithDisc>
		<AmtDisc1>0,00</AmtDisc1>
		<AmtDisc2>0,00</AmtDisc2>
		<AmtDisc3>0,00</AmtDisc3>
		<AmtDisc4>0,00</AmtDisc4>
		<AmtDisc5>0,00</AmtDisc5>
		<AmtDisc6>0,00</AmtDisc6>
		<AmtMaktuOtv>0,00</AmtMaktuOtv>
		<AmtOtv>0,00</AmtOtv>
		<AmtOiv>0,00</AmtOiv>
		<AmtTra>1000,00</AmtTra>
		<AmtVat>180,00</AmtVat>
		<AmtVatDisc>0,00</AmtVatDisc>
		<CurTraCode>TRY</CurTraCode>
		<CurRateTra>1,000000000000000000</CurRateTra>
		<CurTraId>114</CurTraId>
		<Disc1Rate>0,00</Disc1Rate>
		<Disc2Rate>0,00</Disc2Rate>
		<Disc3Rate>0,00</Disc3Rate>
		<QtyFreePrm>0,00000</QtyFreePrm>
		<QtyFreeSec>0,00000</QtyFreeSec>
		<QtyPrm>100,00000</QtyPrm>
		<VatCode>18</VatCode>
		<VatName>% 18 KDV</VatName>
		<VatRate>18,00</VatRate>
		<OtvRate>0,00</OtvRate>
		<OivRate>0,00</OivRate>
		<UnitPrice>10,00000000</UnitPrice>
		<UnitPriceTra>10,00000000</UnitPriceTra>
		<VatDiscRate>0,000000</VatDiscRate>
		<VatId>158</VatId>
		<VatStatus>Hariç</VatStatus>
		<DueDay>30</DueDay>
		<BranchDesc>ÜSTÜN PLASTİK AMBALAJ SANAYİ VE TİCARET A.Ş.</BranchDesc>
		<BwhDesc>Üretim Depo</BwhDesc>
		<WhouseCode>D-030</WhouseCode>
		<DcardCode>H01 DG AB 02</DcardCode>
		<DcardName>Terluran GP22 ABS</DcardName>
		<LineNo>20</LineNo>
		<UnitId>165</UnitId>
		<UnitCode>KG</UnitCode>
		<AmtDisc0Tra>0,00</AmtDisc0Tra>
		<AmtDisc1Tra>0,00</AmtDisc1Tra>
		<AmtDisc2Tra>0,00</AmtDisc2Tra>
		<AmtDisc3Tra>0,00</AmtDisc3Tra>
		<AmtDisc4Tra>0,00</AmtDisc4Tra>
		<AmtDisc5Tra>0,00</AmtDisc5Tra>
		<AmtDisc6Tra>0,00</AmtDisc6Tra>
		<AmtDiscTra>0,00</AmtDiscTra>
		<AmtWithDiscTra>1000,00</AmtWithDiscTra>
		<AmtWithDiscTraForUnit>10</AmtWithDiscTraForUnit>
		<UnitPriceTra0>0,00000000</UnitPriceTra0>
	</UyumDetailItem>
             */


            //MainForm.ShowControl(new AcikBelgeSilControl());
        }

        private void btnUretim_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PRD.PrdControl());
        }

        private void btnmalkabul_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new PSM.MalKabulControl());
        }

        private void btnkalite_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new QLT.QLTControl());
        }

        private void btnambalaj_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajMenuControl());
        }

        private void btnayar_Click(object sender, EventArgs e)
        {
            contextMenu1.Show(btnayar, new Point(0, 0));
            //using (FormAyarlar form = new FormAyarlar())
            //{
            //    form.ShowDialog();
            //}
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            using (FormAyarlar form = new FormAyarlar())
            {
                form.ShowDialog();
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new InputControl());
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "calc.exe";
                Process.Start(info);
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (!Screens.Question("PROGRAMI GÜNCELLEMEK İSTİYOR MUSUNUZ?")) return;
            new Updater.UpdateHelper().Update();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            if (Screens.ShowInputBox("Parola!!", "İşlem için şifre gerekiyor.", '*').Equals("20012001", StringComparison.OrdinalIgnoreCase))
            {
                FormParametreler prm = new FormParametreler();
                prm.ShowDialog();
            }
        }


    }
}

