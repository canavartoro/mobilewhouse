using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using MobileWhouse.Util;

namespace MobileWhouse.Models
{
    [XmlRoot(ElementName = "Uyum")]
    public class ItemM : BaseModel
    {
        private int prdTypeField = 0;
        [XmlElement(ElementName = "PrdType")]
        public int PrdType
        {
            get { return this.prdTypeField; }
            set { this.prdTypeField = value; }
        }

        private bool isOutsideEntityControlsField = false;
        [XmlElement(ElementName = "IsOutsideEntityControls")]
        public bool IsOutsideEntityControls
        {
            get { return this.isOutsideEntityControlsField; }
            set { this.isOutsideEntityControlsField = value; }
        }

        private List<ItemD> uyumDetailItemField;
        [XmlElement(ElementName = "UyumDetailItem")]
        public List<ItemD> UyumDetailItem
        {
            get { return this.uyumDetailItemField; }
            set { this.uyumDetailItemField = value; }
        }

        private int idField;
        [XmlElement(ElementName = "Id")]
        public int Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        private string purchaseSalesField;
        [XmlElement(ElementName = "PurchaseSales")]
        public string PurchaseSales
        {
            get { return this.purchaseSalesField; }
            set { this.purchaseSalesField = value; }
        }

        private int coIdField;
        [XmlElement(ElementName = "CoId")]
        public int CoId
        {
            get { return this.coIdField; }
            set { this.coIdField = value; }
        }

        private int docTraIdField;
        [XmlElement(ElementName = "DocTraId")]
        public int DocTraId
        {
            get { return this.docTraIdField; }
            set { this.docTraIdField = value; }
        }

        private int entityIdField;
        [XmlElement(ElementName = "EntityId")]
        public int EntityId
        {
            get { return this.entityIdField; }
            set { this.entityIdField = value; }
        }

        private string currencyOptionField;
        [XmlElement(ElementName = "CurrencyOption")]
        public string CurrencyOption
        {
            get { return this.currencyOptionField; }
            set { this.currencyOptionField = value; }
        }

        private string invoiceStatusField;
        [XmlElement(ElementName = "InvoiceStatus")]
        public string InvoiceStatus
        {
            get { return this.invoiceStatusField; }
            set { this.invoiceStatusField = value; }
        }

        private bool isWaybilField;
        [XmlElement(ElementName = "IsWaybil")]
        public bool IsWaybil
        {
            get { return this.isWaybilField; }
            set { this.isWaybilField = value; }
        }

        private string coDescField;
        [XmlElement(ElementName = "CoDesc")]
        public string CoDesc
        {
            get { return this.coDescField; }
            set { this.coDescField = value; }
        }

        private int branchIdField;
        [XmlElement(ElementName = "BranchId")]
        public int BranchId
        {
            get { return this.branchIdField; }
            set { this.branchIdField = value; }
        }

        private DateTime docDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime DocDate
        {
            get { return this.docDateField; }
            set { this.docDateField = value; }
        }

        [XmlElement(ElementName = "DocDate")]
        public string DocDateString
        {
            get { return this.docDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.docDateField = StringUtil.ToDatetime(value); }
        }

        private string inventoryStatusField;
        [XmlElement(ElementName = "InventoryStatus")]
        public string InventoryStatus
        {
            get { return this.inventoryStatusField; }
            set { this.inventoryStatusField = value; }
        }

        private DateTime receiptDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime ReceiptDate
        {
            get { return this.receiptDateField; }
            set { this.receiptDateField = value; }
        }

        [XmlElement(ElementName = "ReceiptDate")]
        public string ReceiptDateString
        {
            get { return this.receiptDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.receiptDateField = StringUtil.ToDatetime(value); }
        }

        private string eDespatchStatusField;
        [XmlElement(ElementName = "EDespatchStatus")]
        public string EDespatchStatus
        {
            get { return this.eDespatchStatusField; }
            set { this.eDespatchStatusField = value; }
        }

        private int curTraIdField;
        [XmlElement(ElementName = "CurTraId")]
        public int CurTraId
        {
            get { return this.curTraIdField; }
            set { this.curTraIdField = value; }
        }

        //private double latitudeField;
        //[XmlElement(ElementName = "Latitude")]
        //public double Latitude
        //{
        //    get { return this.latitudeField; }
        //    set { this.latitudeField = value; }
        //}

        //private double longitudeField;
        //[XmlElement(ElementName = "Longitude")]
        //public double Longitude
        //{
        //    get { return this.longitudeField; }
        //    set { this.longitudeField = value; }
        //}

        //private string uUIDField;
        //[XmlElement(ElementName = "UUID")]
        //public string UUID
        //{
        //    get { return this.uUIDField; }
        //    set { this.uUIDField = value; }
        //}

        //private DateTime startTimeField;
        //[System.Xml.Serialization.XmlIgnore]
        //public DateTime StartTime
        //{
        //    get { return this.startTimeField; }
        //    set { this.startTimeField = value; }
        //}

        //[XmlElement(ElementName = "StartTime")]
        //public string StartTimeString
        //{
        //    get { return this.startTimeField.ToString("dd.MM.yyyy HH:mm:ss"); }
        //    set { this.startTimeField = StringUtil.ToDatetime(value); }
        //}

        //private DateTime issueTimeField;
        //[System.Xml.Serialization.XmlIgnore]
        //public DateTime IssueTime
        //{
        //    get { return this.issueTimeField; }
        //    set { this.issueTimeField = value; }
        //}

        //[XmlElement(ElementName = "IssueTime")]
        //public string IssueTimeString
        //{
        //    get { return this.issueTimeField.ToString("dd.MM.yyyy HH:mm:ss"); }
        //    set { this.issueTimeField = StringUtil.ToDatetime(value); }
        //}

        private string despatchAdviceTypeCodeField;
        [XmlElement(ElementName = "DespatchAdviceTypeCode")]
        public string DespatchAdviceTypeCode
        {
            get { return this.despatchAdviceTypeCodeField; }
            set { this.despatchAdviceTypeCodeField = value; }
        }

        private string eDespatchProfileField;
        [XmlElement(ElementName = "eDespatchProfile")]
        public string EDespatchProfile
        {
            get { return this.eDespatchProfileField; }
            set { this.eDespatchProfileField = value; }
        }

        private bool iseDespatchField;
        [XmlElement(ElementName = "IseDespatch")]
        public bool IseDespatch
        {
            get { return this.iseDespatchField; }
            set { this.iseDespatchField = value; }
        }

        private DateTime actualDespatchDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime ActualDespatchDate
        {
            get { return this.actualDespatchDateField; }
            set { this.actualDespatchDateField = value; }
        }

        [XmlElement(ElementName = "ActualDespatchDate")]
        public string ActualDespatchDateString
        {
            get { return this.actualDespatchDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.actualDespatchDateField = StringUtil.ToDatetime(value); }
        }

        private string pSValForContractField;
        [XmlElement(ElementName = "PSValForContract")]
        public string PSValForContract
        {
            get { return this.pSValForContractField; }
            set { this.pSValForContractField = value; }
        }

        private string cardTypeField;
        [XmlElement(ElementName = "CardType")]
        public string CardType
        {
            get { return this.cardTypeField; }
            set { this.cardTypeField = value; }
        }

        private string cardCodeField;
        [XmlElement(ElementName = "CardCode")]
        public string CardCode
        {
            get { return this.cardCodeField; }
            set { this.cardCodeField = value; }
        }

        private string cardNameField;
        [XmlElement(ElementName = "CardName")]
        public string CardName
        {
            get { return this.cardNameField; }
            set { this.cardNameField = value; }
        }

        private int mCardIdField;
        [XmlElement(ElementName = "MCardId")]
        public int MCardId
        {
            get { return this.mCardIdField; }
            set { this.mCardIdField = value; }
        }

        private int createUserIdField;
        [XmlElement(ElementName = "CreateUserId")]
        public int CreateUserId
        {
            get { return this.createUserIdField; }
            set { this.createUserIdField = value; }
        }

        private DateTime createDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime CreateDate
        {
            get { return this.createDateField; }
            set { this.createDateField = value; }
        }

        [XmlElement(ElementName = "CreateDate")]
        public string CreateDateString
        {
            get { return this.createDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.createDateField = StringUtil.ToDatetime(value); }
        }

        private string address1Field;
        [XmlElement(ElementName = "Address1")]
        public string Address1
        {
            get { return this.address1Field; }
            set { this.address1Field = value; }
        }

        private string address2Field;
        [XmlElement(ElementName = "Address2")]
        public string Address2
        {
            get { return this.address2Field; }
            set { this.address2Field = value; }
        }

        private string address3Field;
        [XmlElement(ElementName = "Address3")]
        public string Address3
        {
            get { return this.address3Field; }
            set { this.address3Field = value; }
        }

        private decimal amtField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Amt
        {
            get
            {
                return this.amtField;
            }
            set
            {
                this.amtField = value;
            }
        }

        [XmlElement(ElementName = "Amt")]
        public string AmtString
        {
            get { return this.amtField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc0Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc0
        {
            get
            {
                return this.amtDisc0Field;
            }
            set
            {
                this.amtDisc0Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc0")]
        public string AmtDisc0String
        {
            get { return this.amtDisc0Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc0Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc0TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc0Tra
        {
            get
            {
                return this.amtDisc0TraField;
            }
            set
            {
                this.amtDisc0TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc0Tra")]
        public string AmtDisc0TraString
        {
            get { return this.amtDisc0TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc0TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDiscTotalField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDiscTotal
        {
            get
            {
                return this.amtDiscTotalField;
            }
            set
            {
                this.amtDiscTotalField = value;
            }
        }

        [XmlElement(ElementName = "AmtDiscTotal")]
        public string AmtDiscTotalString
        {
            get { return this.amtDiscTotalField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDiscTotalField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDiscTotalTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDiscTotalTra
        {
            get
            {
                return this.amtDiscTotalTraField;
            }
            set
            {
                this.amtDiscTotalTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDiscTotalTra")]
        public string AmtDiscTotalTraString
        {
            get { return this.amtDiscTotalTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDiscTotalTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtOtvField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOtv
        {
            get
            {
                return this.amtOtvField;
            }
            set
            {
                this.amtOtvField = value;
            }
        }

        [XmlElement(ElementName = "AmtOtv")]
        public string AmtOtvString
        {
            get { return this.amtOtvField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOtvField = StringUtil.ToDecimal(value); }
        }

        private decimal amtOtvTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOtvTra
        {
            get
            {
                return this.amtOtvTraField;
            }
            set
            {
                this.amtOtvTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtOtvTra")]
        public string AmtOtvTraString
        {
            get { return this.amtOtvTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOtvTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtReceiptField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtReceipt
        {
            get
            {
                return this.amtReceiptField;
            }
            set
            {
                this.amtReceiptField = value;
            }
        }

        [XmlElement(ElementName = "AmtReceipt")]
        public string AmtReceiptString
        {
            get { return this.amtReceiptField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtReceiptField = StringUtil.ToDecimal(value); }
        }

        private decimal amtReceiptTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtReceiptTra
        {
            get
            {
                return this.amtReceiptTraField;
            }
            set
            {
                this.amtReceiptTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtReceiptTra")]
        public string AmtReceiptTraString
        {
            get { return this.amtReceiptTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtReceiptTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtRoundField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtRound
        {
            get
            {
                return this.amtRoundField;
            }
            set
            {
                this.amtRoundField = value;
            }
        }

        [XmlElement(ElementName = "AmtRound")]
        public string AmtRoundString
        {
            get { return this.amtRoundField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtRoundField = StringUtil.ToDecimal(value); }
        }

        private decimal amtRoundTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtRoundTra
        {
            get
            {
                return this.amtRoundTraField;
            }
            set
            {
                this.amtRoundTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtRoundTra")]
        public string AmtRoundTraString
        {
            get { return this.amtRoundTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtRoundTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtTra
        {
            get
            {
                return this.amtTraField;
            }
            set
            {
                this.amtTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtTra")]
        public string AmtTraString
        {
            get { return this.amtTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtVatField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtVat
        {
            get
            {
                return this.amtVatField;
            }
            set
            {
                this.amtVatField = value;
            }
        }

        [XmlElement(ElementName = "AmtVat")]
        public string AmtVatString
        {
            get { return this.amtVatField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtVatField = StringUtil.ToDecimal(value); }
        }

        private decimal amtVatDiscField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtVatDisc
        {
            get
            {
                return this.amtVatDiscField;
            }
            set
            {
                this.amtVatDiscField = value;
            }
        }

        [XmlElement(ElementName = "AmtVatDisc")]
        public string AmtVatDiscString
        {
            get { return this.amtVatDiscField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtVatDiscField = StringUtil.ToDecimal(value); }
        }

        private decimal amtVatDiscTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtVatDiscTra
        {
            get
            {
                return this.amtVatDiscTraField;
            }
            set
            {
                this.amtVatDiscTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtVatDiscTra")]
        public string AmtVatDiscTraString
        {
            get { return this.amtVatDiscTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtVatDiscTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtVatTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtVatTra
        {
            get
            {
                return this.amtVatTraField;
            }
            set
            {
                this.amtVatTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtVatTra")]
        public string AmtVatTraString
        {
            get { return this.amtVatTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtVatTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtOtherTaxField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOtherTax
        {
            get
            {
                return this.amtOtherTaxField;
            }
            set
            {
                this.amtOtherTaxField = value;
            }
        }

        [XmlElement(ElementName = "AmtOtherTax")]
        public string AmtOtherTaxString
        {
            get { return this.amtOtherTaxField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOtherTaxField = StringUtil.ToDecimal(value); }
        }

        private decimal amtOtherTaxTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOtherTaxTra
        {
            get
            {
                return this.amtOtherTaxTraField;
            }
            set
            {
                this.amtOtherTaxTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtOtherTaxTra")]
        public string AmtOtherTaxTraString
        {
            get { return this.amtOtherTaxTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOtherTaxTraField = StringUtil.ToDecimal(value); }
        }

        private int branchCodeField;
        [XmlElement(ElementName = "BranchCode")]
        public int BranchCode
        {
            get { return this.branchCodeField; }
            set { this.branchCodeField = value; }
        }

        private string branchDescField;
        [XmlElement(ElementName = "BranchDesc")]
        public string BranchDesc
        {
            get { return this.branchDescField; }
            set { this.branchDescField = value; }
        }

        private int countryIdField;
        [XmlElement(ElementName = "CountryId")]
        public int CountryId
        {
            get { return this.countryIdField; }
            set { this.countryIdField = value; }
        }

        private string countryNameField;
        [XmlElement(ElementName = "CountryName")]
        public string CountryName
        {
            get { return this.countryNameField; }
            set { this.countryNameField = value; }
        }

        private string curTraCodeField;
        [XmlElement(ElementName = "CurTraCode")]
        public string CurTraCode
        {
            get { return this.curTraCodeField; }
            set { this.curTraCodeField = value; }
        }

        private string isoCurTraCodeField;
        [XmlElement(ElementName = "IsoCurTraCode")]
        public string IsoCurTraCode
        {
            get { return this.isoCurTraCodeField; }
            set { this.isoCurTraCodeField = value; }
        }

        private decimal curRateTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal CurRateTra
        {
            get
            {
                return this.curRateTraField;
            }
            set
            {
                this.curRateTraField = value;
            }
        }

        [XmlElement(ElementName = "CurRateTra")]
        public string CurRateTraString
        {
            get { return this.curRateTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.curRateTraField = StringUtil.ToDecimal(value); }
        }

        private decimal disc0RateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Disc0Rate
        {
            get
            {
                return this.disc0RateField;
            }
            set
            {
                this.disc0RateField = value;
            }
        }

        [XmlElement(ElementName = "Disc0Rate")]
        public string Disc0RateString
        {
            get { return this.disc0RateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.disc0RateField = StringUtil.ToDecimal(value); }
        }

        private decimal disc1RateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Disc1Rate
        {
            get
            {
                return this.disc1RateField;
            }
            set
            {
                this.disc1RateField = value;
            }
        }

        [XmlElement(ElementName = "Disc1Rate")]
        public string Disc1RateString
        {
            get { return this.disc1RateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.disc1RateField = StringUtil.ToDecimal(value); }
        }

        private decimal disc2RateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Disc2Rate
        {
            get
            {
                return this.disc2RateField;
            }
            set
            {
                this.disc2RateField = value;
            }
        }

        [XmlElement(ElementName = "Disc2Rate")]
        public string Disc2RateString
        {
            get { return this.disc2RateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.disc2RateField = StringUtil.ToDecimal(value); }
        }

        private decimal disc3RateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Disc3Rate
        {
            get
            {
                return this.disc3RateField;
            }
            set
            {
                this.disc3RateField = value;
            }
        }

        [XmlElement(ElementName = "Disc3Rate")]
        public string Disc3RateString
        {
            get { return this.disc3RateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.disc3RateField = StringUtil.ToDecimal(value); }
        }

        private string docNoField;
        [XmlElement(ElementName = "DocNo")]
        public string DocNo
        {
            get { return this.docNoField; }
            set { this.docNoField = value; }
        }

        private int dueDayField;
        [XmlElement(ElementName = "DueDay")]
        public int DueDay
        {
            get { return this.dueDayField; }
            set { this.dueDayField = value; }
        }

        private string sourceAppField;
        [XmlElement(ElementName = "SourceApp")]
        public string SourceApp
        {
            get { return this.sourceAppField; }
            set { this.sourceAppField = value; }
        }

        private string sourceApp3Field;
        [XmlElement(ElementName = "SourceApp3")]
        public string SourceApp3
        {
            get { return this.sourceApp3Field; }
            set { this.sourceApp3Field = value; }
        }

        private int sourceMIdField;
        [XmlElement(ElementName = "SourceMId")]
        public int SourceMId
        {
            get { return this.sourceMIdField; }
            set { this.sourceMIdField = value; }
        }

        private decimal vatDiscRateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal VatDiscRate
        {
            get
            {
                return this.vatDiscRateField;
            }
            set
            {
                this.vatDiscRateField = value;
            }
        }

        [XmlElement(ElementName = "VatDiscRate")]
        public string VatDiscRateString
        {
            get { return this.vatDiscRateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.vatDiscRateField = StringUtil.ToDecimal(value); }
        }

        private string zipCodeField;
        [XmlElement(ElementName = "ZipCode")]
        public string ZipCode
        {
            get { return this.zipCodeField; }
            set { this.zipCodeField = value; }
        }

        private string docTraCodeField;
        [XmlElement(ElementName = "DocTraCode")]
        public string DocTraCode
        {
            get { return this.docTraCodeField; }
            set { this.docTraCodeField = value; }
        }

        private string invoiceTypeField;
        [XmlElement(ElementName = "InvoiceType")]
        public string InvoiceType
        {
            get { return this.invoiceTypeField; }
            set { this.invoiceTypeField = value; }
        }

        private string docTraDescField;
        [XmlElement(ElementName = "DocTraDesc")]
        public string DocTraDesc
        {
            get { return this.docTraDescField; }
            set { this.docTraDescField = value; }
        }

        private string ebookDocumentTypeField;
        [XmlElement(ElementName = "EbookDocumentType")]
        public string EbookDocumentType
        {
            get { return this.ebookDocumentTypeField; }
            set { this.ebookDocumentTypeField = value; }
        }

        private string entityCodeField;
        [XmlElement(ElementName = "EntityCode")]
        public string EntityCode
        {
            get { return this.entityCodeField; }
            set { this.entityCodeField = value; }
        }

        private string entityNameField;
        [XmlElement(ElementName = "EntityName")]
        public string EntityName
        {
            get { return this.entityNameField; }
            set { this.entityNameField = value; }
        }

        private string coCodeField;
        [XmlElement(ElementName = "CoCode")]
        public string CoCode
        {
            get { return this.coCodeField; }
            set { this.coCodeField = value; }
        }

        private int coCurIdField;
        [XmlElement(ElementName = "CoCurId")]
        public int CoCurId
        {
            get { return this.coCurIdField; }
            set { this.coCurIdField = value; }
        }

        private int purchaseSalesValField;
        [XmlElement(ElementName = "PurchaseSalesVal")]
        public int PurchaseSalesVal
        {
            get { return this.purchaseSalesValField; }
            set { this.purchaseSalesValField = value; }
        }

        private decimal amtOivField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOiv
        {
            get
            {
                return this.amtOivField;
            }
            set
            {
                this.amtOivField = value;
            }
        }

        [XmlElement(ElementName = "AmtOiv")]
        public string AmtOivString
        {
            get { return this.amtOivField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOivField = StringUtil.ToDecimal(value); }
        }

        private decimal amtOivTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOivTra
        {
            get
            {
                return this.amtOivTraField;
            }
            set
            {
                this.amtOivTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtOivTra")]
        public string AmtOivTraString
        {
            get { return this.amtOivTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOivTraField = StringUtil.ToDecimal(value); }
        }

        private int brCountryIdField;
        [XmlElement(ElementName = "BrCountryId")]
        public int BrCountryId
        {
            get { return this.brCountryIdField; }
            set { this.brCountryIdField = value; }
        }

        private int hasBrCountryField;
        [XmlElement(ElementName = "HasBrCountry")]
        public int HasBrCountry
        {
            get { return this.hasBrCountryField; }
            set { this.hasBrCountryField = value; }
        }

        private string typeField = "INV.ItemM, INV";
        [XmlAttribute(AttributeName = "Type")]
        public string Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }
    }

    [XmlRoot(ElementName = "UyumDetailItem")]
    public class ItemD
    {
        private DateTime docDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime DocDate
        {
            get
            {
                return this.docDateField;
            }
            set
            {
                this.docDateField = value;
            }
        }

        [XmlElement(ElementName = "DocDate")]
        public string DocDateString
        {
            get { return this.docDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.docDateField = StringUtil.ToDatetime(value); }
        }

        private int itemIdField;
        [XmlElement(ElementName = "ItemId")]
        public int ItemId
        {
            get { return this.itemIdField; }
            set { this.itemIdField = value; }
        }

        private int whouseIdField;
        [XmlElement(ElementName = "WhouseId")]
        public int WhouseId
        {
            get { return this.whouseIdField; }
            set { this.whouseIdField = value; }
        }

        private int coIdField;
        [XmlElement(ElementName = "CoId")]
        public int CoId
        {
            get { return this.coIdField; }
            set { this.coIdField = value; }
        }

        private int dcardIdField;
        [XmlElement(ElementName = "DcardId")]
        public int DcardId
        {
            get { return this.dcardIdField; }
            set { this.dcardIdField = value; }
        }

        private string lineTypeField;
        [XmlElement(ElementName = "LineType")]
        public string LineType
        {
            get { return this.lineTypeField; }
            set { this.lineTypeField = value; }
        }

        private int lotIdField;
        [XmlElement(ElementName = "LotId")]
        public int LotId
        {
            get { return this.lotIdField; }
            set { this.lotIdField = value; }
        }

        private string lotCodeField;
        [XmlElement(ElementName = "LotCode")]
        public string LotCode
        {
            get { return this.lotCodeField; }
            set { this.lotCodeField = value; }
        }

        private int idField;
        [XmlElement(ElementName = "Id")]
        public int Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        private string reservationTypeField;
        [XmlElement(ElementName = "ReservationType")]
        public string ReservationType
        {
            get { return this.reservationTypeField; }
            set { this.reservationTypeField = value; }
        }

        private bool isWaybilField;
        [XmlElement(ElementName = "IsWaybil")]
        public bool IsWaybil
        {
            get { return this.isWaybilField; }
            set { this.isWaybilField = value; }
        }

        private string purchaseSalesField;
        [XmlElement(ElementName = "PurchaseSales")]
        public string PurchaseSales
        {
            get { return this.purchaseSalesField; }
            set { this.purchaseSalesField = value; }
        }

        private int entityIdField;
        [XmlElement(ElementName = "EntityId")]
        public int EntityId
        {
            get { return this.entityIdField; }
            set { this.entityIdField = value; }
        }

        private int docTraIdField;
        [XmlElement(ElementName = "DocTraId")]
        public int DocTraId
        {
            get { return this.docTraIdField; }
            set { this.docTraIdField = value; }
        }

        private string docTraCodeField;
        [XmlElement(ElementName = "DocTraCode")]
        public string DocTraCode
        {
            get { return this.docTraCodeField; }
            set { this.docTraCodeField = value; }
        }


        private decimal toleranceRateByItemField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal ToleranceRateByItem
        {
            get
            {
                return this.toleranceRateByItemField;
            }
            set
            {
                this.toleranceRateByItemField = value;
            }
        }

        [XmlElement(ElementName = "ToleranceRateByItem")]
        public string ToleranceRateByItemQtyString
        {
            get { return this.toleranceRateByItemField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.toleranceRateByItemField = StringUtil.ToDecimal(value); }
        }

        private string bwhItemNameField;
        [XmlElement(ElementName = "BwhItemName")]
        public string BwhItemName
        {
            get { return this.bwhItemNameField; }
            set { this.bwhItemNameField = value; }
        }

        private decimal qtyInvoicedField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal QtyInvoiced
        {
            get
            {
                return this.qtyInvoicedField;
            }
            set
            {
                this.qtyInvoicedField = value;
            }
        }

        [XmlElement(ElementName = "QtyInvoiced")]
        public string QtyInvoicedString
        {
            get { return this.qtyInvoicedField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyInvoicedField = StringUtil.ToDecimal(value); }
        }

        private string branchCodeField;
        [XmlElement(ElementName = "BranchCode")]
        public string BranchCode
        {
            get { return this.branchCodeField; }
            set { this.branchCodeField = value; }
        }

        private decimal balance1Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Balance1
        {
            get
            {
                return this.balance1Field;
            }
            set
            {
                this.balance1Field = value;
            }
        }

        [XmlElement(ElementName = "Balance1")]
        public string Balance1String
        {
            get { return this.balance1Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.balance1Field = StringUtil.ToDecimal(value); }
        }

        private decimal balance2Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Balance2
        {
            get
            {
                return this.balance2Field;
            }
            set
            {
                this.balance2Field = value;
            }
        }

        [XmlElement(ElementName = "Balance2")]
        public string Balance2String
        {
            get { return this.balance2Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.balance2Field = StringUtil.ToDecimal(value); }
        }

        private decimal balance3Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Balance3
        {
            get
            {
                return this.balance3Field;
            }
            set
            {
                this.balance3Field = value;
            }
        }

        [XmlElement(ElementName = "Balance3")]
        public string Balance3String
        {
            get { return this.balance3Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.balance3Field = StringUtil.ToDecimal(value); }
        }

        private string masterInvoiceStatusField;
        [XmlElement(ElementName = "MasterInvoiceStatus")]
        public string MasterInvoiceStatus
        {
            get { return this.masterInvoiceStatusField; }
            set { this.masterInvoiceStatusField = value; }
        }

        private DateTime receiptDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime ReceiptDate
        {
            get
            {
                return this.receiptDateField;
            }
            set
            {
                this.receiptDateField = value;
            }
        }

        [XmlElement(ElementName = "ReceiptDate")]
        public string ReceiptDateString
        {
            get { return this.receiptDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.receiptDateField = StringUtil.ToDatetime(value); }
        }

        private string eDespatchStatusField;
        [XmlElement(ElementName = "eDespatchStatus")]
        public string EDespatchStatus
        {
            get { return this.eDespatchStatusField; }
            set { this.eDespatchStatusField = value; }
        }

        private int itemMIdField;
        [XmlElement(ElementName = "ItemMId")]
        public int ItemMId
        {
            get { return this.itemMIdField; }
            set { this.itemMIdField = value; }
        }

        private int tPlusMinusField;
        [XmlElement(ElementName = "TPlusMinus")]
        public int TPlusMinus
        {
            get { return this.tPlusMinusField; }
            set { this.tPlusMinusField = value; }
        }

        private int coCodeField;
        [XmlElement(ElementName = "CoCode")]
        public int CoCode
        {
            get { return this.coCodeField; }
            set { this.coCodeField = value; }
        }

        private string whouse1DescField;
        [XmlElement(ElementName = "Whouse1Desc")]
        public string Whouse1Desc
        {
            get { return this.whouse1DescField; }
            set { this.whouse1DescField = value; }
        }

        private string coDescField;
        [XmlElement(ElementName = "CoDesc")]
        public string CoDesc
        {
            get { return this.coDescField; }
            set { this.coDescField = value; }
        }

        private int sourceMIdField;
        [XmlElement(ElementName = "SourceMId")]
        public int SourceMId
        {
            get { return this.sourceMIdField; }
            set { this.sourceMIdField = value; }
        }

        private int branchIdField;
        [XmlElement(ElementName = "BranchId")]
        public int BranchId
        {
            get { return this.branchIdField; }
            set { this.branchIdField = value; }
        }

        private string sourceAppField;
        [XmlElement(ElementName = "SourceApp")]
        public string SourceApp
        {
            get { return this.sourceAppField; }
            set { this.sourceAppField = value; }
        }

        private string sourceApp3Field;
        [XmlElement(ElementName = "SourceApp3")]
        public string SourceApp3
        {
            get { return this.sourceApp3Field; }
            set { this.sourceApp3Field = value; }
        }

        private int sourceDIdField;
        [XmlElement(ElementName = "SourceDId")]
        public int SourceDId
        {
            get { return this.sourceDIdField; }
            set { this.sourceDIdField = value; }
        }

        private decimal qtyScrapField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal QtyScrap
        {
            get
            {
                return this.qtyScrapField;
            }
            set
            {
                this.qtyScrapField = value;
            }
        }

        [XmlElement(ElementName = "QtyScrap")]
        public string QtyScrapString
        {
            get { return this.qtyScrapField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyScrapField = StringUtil.ToDecimal(value); }
        }

        private string stockMoveTypeField;
        [XmlElement(ElementName = "StockMoveType")]
        public string StockMoveType
        {
            get { return this.stockMoveTypeField; }
            set { this.stockMoveTypeField = value; }
        }

        private string propertyKeyField;
        [XmlElement(ElementName = "PropertyKey")]
        public string PropertyKey
        {
            get { return this.propertyKeyField; }
            set { this.propertyKeyField = value; }
        }

        private string docNoField;
        [XmlElement(ElementName = "DocNo")]
        public string DocNo
        {
            get { return this.docNoField; }
            set { this.docNoField = value; }
        }

        private string woOutsideTypeField;
        [XmlElement(ElementName = "WoOutsideType")]
        public string WoOutsideType
        {
            get { return this.woOutsideTypeField; }
            set { this.woOutsideTypeField = value; }
        }

        private decimal qtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Qty
        {
            get
            {
                return this.qtyField;
            }
            set
            {
                this.qtyField = value;
            }
        }

        [XmlElement(ElementName = "Qty")]
        public string QtyString
        {
            get { return this.qtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyField = StringUtil.ToDecimal(value); }
        }

        private int defaultAsortModeField;
        [XmlElement(ElementName = "DefaultAsortMode")]
        public int DefaultAsortMode
        {
            get { return this.defaultAsortModeField; }
            set { this.defaultAsortModeField = value; }
        }

        private decimal unitPriceCostField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal UnitPriceCost
        {
            get
            {
                return this.unitPriceCostField;
            }
            set
            {
                this.unitPriceCostField = value;
            }
        }

        [XmlElement(ElementName = "UnitPriceCost")]
        public string UnitPriceCostString
        {
            get { return this.unitPriceCostField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.unitPriceCostField = StringUtil.ToDecimal(value); }
        }

        private decimal deliveredQuantityField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal DeliveredQuantity
        {
            get
            {
                return this.deliveredQuantityField;
            }
            set
            {
                this.deliveredQuantityField = value;
            }
        }

        [XmlElement(ElementName = "DeliveredQuantity")]
        public string DeliveredQuantityString
        {
            get { return this.deliveredQuantityField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.deliveredQuantityField = StringUtil.ToDecimal(value); }
        }

        private decimal receivedQuantityField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal ReceivedQuantity
        {
            get
            {
                return this.receivedQuantityField;
            }
            set
            {
                this.receivedQuantityField = value;
            }
        }

        [XmlElement(ElementName = "ReceivedQuantity")]
        public string ReceivedQuantityString
        {
            get { return this.receivedQuantityField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.receivedQuantityField = StringUtil.ToDecimal(value); }
        }

        private decimal amtCostField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtCost
        {
            get
            {
                return this.amtCostField;
            }
            set
            {
                this.amtCostField = value;
            }
        }

        [XmlElement(ElementName = "AmtCost")]
        public string AmtCostString
        {
            get { return this.amtCostField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtCostField = StringUtil.ToDecimal(value); }
        }

        private decimal amtCost2Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtCost2
        {
            get
            {
                return this.amtCost2Field;
            }
            set
            {
                this.amtCost2Field = value;
            }
        }

        [XmlElement(ElementName = "AmtCost2")]
        public string AmtCost2String
        {
            get { return this.amtCost2Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtCost2Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtCostManualField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtCostManual
        {
            get
            {
                return this.amtCostManualField;
            }
            set
            {
                this.amtCostManualField = value;
            }
        }

        [XmlElement(ElementName = "AmtCostManual")]
        public string AmtCostManualString
        {
            get { return this.amtCostManualField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtCostManualField = StringUtil.ToDecimal(value); }
        }


        private decimal amtCostManual2Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtCostManual2
        {
            get
            {
                return this.amtCostManual2Field;
            }
            set
            {
                this.amtCostManual2Field = value;
            }
        }

        [XmlElement(ElementName = "AmtCostManual2")]
        public string AmtCostManual2String
        {
            get { return this.amtCostManual2Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtCostManual2Field = StringUtil.ToDecimal(value); }
        }

        private string plusMinusField;
        [XmlElement(ElementName = "PlusMinus")]
        public string PlusMinus
        {
            get { return this.plusMinusField; }
            set { this.plusMinusField = value; }
        }

        private int createUserIdField;
        [XmlElement(ElementName = "CreateUserId")]
        public int CreateUserId
        {
            get { return this.createUserIdField; }
            set { this.createUserIdField = value; }
        }

        private DateTime createDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime CreateDate
        {
            get
            {
                return this.createDateField;
            }
            set
            {
                this.createDateField = value;
            }
        }

        [XmlElement(ElementName = "CreateDate")]
        public string CreateDateString
        {
            get { return this.createDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.createDateField = StringUtil.ToDatetime(value); }
        }

        private decimal amtField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Amt
        {
            get
            {
                return this.amtField;
            }
            set
            {
                this.amtField = value;
            }
        }

        [XmlElement(ElementName = "Amt")]
        public string AmtString
        {
            get { return this.amtField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc0Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc0
        {
            get
            {
                return this.amtDisc0Field;
            }
            set
            {
                this.amtDisc0Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc0")]
        public string AmtDisc0String
        {
            get { return this.amtDisc0Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc0Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtDiscField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc
        {
            get
            {
                return this.amtDiscField;
            }
            set
            {
                this.amtDiscField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc")]
        public string AmtDiscString
        {
            get { return this.amtDiscField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDiscField = StringUtil.ToDecimal(value); }
        }

        private decimal amtWithDiscField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtWithDisc
        {
            get
            {
                return this.amtWithDiscField;
            }
            set
            {
                this.amtWithDiscField = value;
            }
        }

        [XmlElement(ElementName = "AmtWithDisc")]
        public string AmtWithDiscString
        {
            get { return this.amtWithDiscField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtWithDiscField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc1Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc1
        {
            get
            {
                return this.amtDisc1Field;
            }
            set
            {
                this.amtDisc1Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc1")]
        public string AmtDisc1String
        {
            get { return this.amtDisc1Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc1Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc2Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc2
        {
            get
            {
                return this.amtDisc2Field;
            }
            set
            {
                this.amtDisc2Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc2")]
        public string AmtDisc2String
        {
            get { return this.amtDisc2Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc2Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc3Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc3
        {
            get
            {
                return this.amtDisc3Field;
            }
            set
            {
                this.amtDisc3Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc3")]
        public string AmtDisc3String
        {
            get { return this.amtDisc3Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc3Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc4Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc4
        {
            get
            {
                return this.amtDisc4Field;
            }
            set
            {
                this.amtDisc4Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc4")]
        public string AmtDisc4String
        {
            get { return this.amtDisc4Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc4Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc5Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc5
        {
            get
            {
                return this.amtDisc5Field;
            }
            set
            {
                this.amtDisc5Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc5")]
        public string AmtDisc5String
        {
            get { return this.amtDisc5Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc5Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc6Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc6
        {
            get
            {
                return this.amtDisc6Field;
            }
            set
            {
                this.amtDisc6Field = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc6")]
        public string AmtDisc6String
        {
            get { return this.amtDisc6Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc6Field = StringUtil.ToDecimal(value); }
        }

        private decimal amtMaktuOtvField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtMaktuOtv
        {
            get
            {
                return this.amtMaktuOtvField;
            }
            set
            {
                this.amtMaktuOtvField = value;
            }
        }

        [XmlElement(ElementName = "AmtMaktuOtv")]
        public string AmtMaktuOtvString
        {
            get { return this.amtMaktuOtvField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtMaktuOtvField = StringUtil.ToDecimal(value); }
        }

        private decimal amtOtvField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOtv
        {
            get
            {
                return this.amtOtvField;
            }
            set
            {
                this.amtOtvField = value;
            }
        }

        [XmlElement(ElementName = "AmtOtv")]
        public string AmtOtvString
        {
            get { return this.amtOtvField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOtvField = StringUtil.ToDecimal(value); }
        }

        private decimal amtOivField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtOiv
        {
            get
            {
                return this.amtOivField;
            }
            set
            {
                this.amtOivField = value;
            }
        }

        [XmlElement(ElementName = "AmtOiv")]
        public string AmtOivString
        {
            get { return this.amtOivField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtOivField = StringUtil.ToDecimal(value); }
        }

        private decimal amtTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtTra
        {
            get
            {
                return this.amtTraField;
            }
            set
            {
                this.amtTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtTra")]
        public string AmtTraString
        {
            get { return this.amtTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtVatField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtVat
        {
            get
            {
                return this.amtVatField;
            }
            set
            {
                this.amtVatField = value;
            }
        }

        [XmlElement(ElementName = "AmtVat")]
        public string AmtVatString
        {
            get { return this.amtVatField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtVatField = StringUtil.ToDecimal(value); }
        }

        private decimal amtVatDiscField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtVatDisc
        {
            get
            {
                return this.amtVatDiscField;
            }
            set
            {
                this.amtVatDiscField = value;
            }
        }

        [XmlElement(ElementName = "AmtVatDisc")]
        public string AmtVatDiscString
        {
            get { return this.amtVatDiscField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtVatDiscField = StringUtil.ToDecimal(value); }
        }

        private string curTraCodeField;
        [XmlElement(ElementName = "CurTraCode")]
        public string CurTraCode
        {
            get { return this.curTraCodeField; }
            set { this.curTraCodeField = value; }
        }

        private decimal curRateTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal CurRateTra
        {
            get
            {
                return this.curRateTraField;
            }
            set
            {
                this.curRateTraField = value;
            }
        }

        [XmlElement(ElementName = "CurRateTra")]
        public string CurRateTraString
        {
            get { return this.curRateTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.curRateTraField = StringUtil.ToDecimal(value); }
        }

        private int curTraIdField;
        [XmlElement(ElementName = "CurTraId")]
        public int CurTraId
        {
            get { return this.curTraIdField; }
            set { this.curTraIdField = value; }
        }

        private decimal disc1RateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Disc1Rate
        {
            get
            {
                return this.disc1RateField;
            }
            set
            {
                this.disc1RateField = value;
            }
        }

        [XmlElement(ElementName = "Disc1Rate")]
        public string Disc1RateString
        {
            get { return this.disc1RateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.disc1RateField = StringUtil.ToDecimal(value); }
        }

        private decimal disc2RateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Disc2Rate
        {
            get
            {
                return this.disc2RateField;
            }
            set
            {
                this.disc2RateField = value;
            }
        }

        [XmlElement(ElementName = "Disc2Rate")]
        public string MDisc2RateString
        {
            get { return this.disc2RateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.disc2RateField = StringUtil.ToDecimal(value); }
        }

        private decimal disc3RateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Disc3Rate
        {
            get
            {
                return this.disc3RateField;
            }
            set
            {
                this.disc3RateField = value;
            }
        }

        [XmlElement(ElementName = "Disc3Rate")]
        public string Disc3RateString
        {
            get { return this.disc3RateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.disc3RateField = StringUtil.ToDecimal(value); }
        }

        private decimal qtyFreePrmField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal QtyFreePrm
        {
            get
            {
                return this.qtyFreePrmField;
            }
            set
            {
                this.qtyFreePrmField = value;
            }
        }

        [XmlElement(ElementName = "QtyFreePrm")]
        public string MQtyFreePrmString
        {
            get { return this.qtyFreePrmField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyFreePrmField = StringUtil.ToDecimal(value); }
        }

        private decimal qtyFreeSecField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal QtyFreeSec
        {
            get
            {
                return this.qtyFreeSecField;
            }
            set
            {
                this.qtyFreeSecField = value;
            }
        }

        [XmlElement(ElementName = "QtyFreeSec")]
        public string QtyFreeSecString
        {
            get { return this.qtyFreeSecField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyFreeSecField = StringUtil.ToDecimal(value); }
        }

        private decimal qtyPrmField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal QtyPrm
        {
            get
            {
                return this.qtyPrmField;
            }
            set
            {
                this.qtyPrmField = value;
            }
        }

        [XmlElement(ElementName = "QtyPrm")]
        public string QtyPrmString
        {
            get { return this.qtyPrmField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyPrmField = StringUtil.ToDecimal(value); }
        }

        private string vatCodeField;
        [XmlElement(ElementName = "VatCode")]
        public string VatCode
        {
            get { return this.vatCodeField; }
            set { this.vatCodeField = value; }
        }

        private string vatNameField;
        [XmlElement(ElementName = "VatName")]
        public string VatName
        {
            get { return this.vatNameField; }
            set { this.vatNameField = value; }
        }

        private decimal vatRateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal VatRate
        {
            get
            {
                return this.vatRateField;
            }
            set
            {
                this.vatRateField = value;
            }
        }

        [XmlElement(ElementName = "VatRate")]
        public string VatRateString
        {
            get { return this.vatRateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.vatRateField = StringUtil.ToDecimal(value); }
        }

        private decimal otvRateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal OtvRate
        {
            get
            {
                return this.otvRateField;
            }
            set
            {
                this.otvRateField = value;
            }
        }

        [XmlElement(ElementName = "OtvRate")]
        public string OtvRateString
        {
            get { return this.otvRateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.otvRateField = StringUtil.ToDecimal(value); }
        }

        private decimal oivRateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal OivRate
        {
            get
            {
                return this.oivRateField;
            }
            set
            {
                this.oivRateField = value;
            }
        }

        [XmlElement(ElementName = "OivRate")]
        public string OivRateString
        {
            get { return this.oivRateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.oivRateField = StringUtil.ToDecimal(value); }
        }

        private decimal unitPriceField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal UnitPrice
        {
            get
            {
                return this.unitPriceField;
            }
            set
            {
                this.unitPriceField = value;
            }
        }

        [XmlElement(ElementName = "UnitPrice")]
        public string UnitPriceString
        {
            get { return this.unitPriceField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.unitPriceField = StringUtil.ToDecimal(value); }
        }

        private decimal unitPriceTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal UnitPriceTra
        {
            get
            {
                return this.unitPriceTraField;
            }
            set
            {
                this.unitPriceTraField = value;
            }
        }

        [XmlElement(ElementName = "UnitPriceTra")]
        public string UnitPriceTraString
        {
            get { return this.unitPriceTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.unitPriceTraField = StringUtil.ToDecimal(value); }
        }

        private decimal vatDiscRateField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal VatDiscRate
        {
            get
            {
                return this.vatDiscRateField;
            }
            set
            {
                this.vatDiscRateField = value;
            }
        }

        [XmlElement(ElementName = "VatDiscRate")]
        public string VatDiscRateString
        {
            get { return this.vatDiscRateField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.vatDiscRateField = StringUtil.ToDecimal(value); }
        }

        private int vatIdField;
        [XmlElement(ElementName = "VatId")]
        public int VatId
        {
            get { return this.vatIdField; }
            set { this.vatIdField = value; }
        }

        private string vatStatusField;
        [XmlElement(ElementName = "VatStatus")]
        public string VatStatus
        {
            get { return this.vatStatusField; }
            set { this.vatStatusField = value; }
        }

        private int dueDayField;
        [XmlElement(ElementName = "DueDay")]
        public int DueDay
        {
            get { return this.dueDayField; }
            set { this.dueDayField = value; }
        }

        private string branchDescField;
        [XmlElement(ElementName = "BranchDesc")]
        public string BranchDesc
        {
            get { return this.branchDescField; }
            set { this.branchDescField = value; }
        }

        private string bwhDescField;
        [XmlElement(ElementName = "BwhDesc")]
        public string BwhDesc
        {
            get { return this.bwhDescField; }
            set { this.bwhDescField = value; }
        }

        private string whouseCodeField;
        [XmlElement(ElementName = "WhouseCode")]
        public string WhouseCode
        {
            get { return this.whouseCodeField; }
            set { this.whouseCodeField = value; }
        }

        private string dcardCodeField;
        [XmlElement(ElementName = "DcardCode")]
        public string DcardCode
        {
            get { return this.dcardCodeField; }
            set { this.dcardCodeField = value; }
        }

        private string dcardNameField;
        [XmlElement(ElementName = "DcardName")]
        public string DcardName
        {
            get { return this.dcardNameField; }
            set { this.dcardNameField = value; }
        }

        private int lineNoField;
        [XmlElement(ElementName = "LineNo")]
        public int LineNo
        {
            get { return this.lineNoField; }
            set { this.lineNoField = value; }
        }

        private int unitIdField;
        [XmlElement(ElementName = "UnitId")]
        public int UnitId
        {
            get { return this.unitIdField; }
            set { this.unitIdField = value; }
        }

        private string unitCodeField;
        [XmlElement(ElementName = "UnitCode")]
        public string UnitCode
        {
            get { return this.unitCodeField; }
            set { this.unitCodeField = value; }
        }

        private decimal amtDisc0TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc0Tra
        {
            get
            {
                return this.amtDisc0TraField;
            }
            set
            {
                this.amtDisc0TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc0Tra")]
        public string AmtDisc0TraString
        {
            get { return this.amtDisc0TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc0TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc1TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc1Tra
        {
            get
            {
                return this.amtDisc1TraField;
            }
            set
            {
                this.amtDisc1TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc1Tra")]
        public string AmtDisc1TraString
        {
            get { return this.amtDisc1TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc1TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc2TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc2Tra
        {
            get
            {
                return this.amtDisc2TraField;
            }
            set
            {
                this.amtDisc2TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc2Tra")]
        public string AmtDisc2TraString
        {
            get { return this.amtDisc2TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc2TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc3TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc3Tra
        {
            get
            {
                return this.amtDisc3TraField;
            }
            set
            {
                this.amtDisc3TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc3Tra")]
        public string AmtDisc3TraString
        {
            get { return this.amtDisc3TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc3TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc4TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc4Tra
        {
            get
            {
                return this.amtDisc4TraField;
            }
            set
            {
                this.amtDisc4TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc4Tra")]
        public string AmtDisc4TraString
        {
            get { return this.amtDisc4TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc4TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc5TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc5Tra
        {
            get
            {
                return this.amtDisc5TraField;
            }
            set
            {
                this.amtDisc5TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc5Tra")]
        public string AmtDisc5TraString
        {
            get { return this.amtDisc5TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc5TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDisc6TraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDisc6Tra
        {
            get
            {
                return this.amtDisc6TraField;
            }
            set
            {
                this.amtDisc6TraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDisc6Tra")]
        public string AmtDisc6TraString
        {
            get { return this.amtDisc6TraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDisc6TraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtDiscTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtDiscTra
        {
            get
            {
                return this.amtDiscTraField;
            }
            set
            {
                this.amtDiscTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtDiscTra")]
        public string AmtDiscTraString
        {
            get { return this.amtDiscTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtDiscTraField = StringUtil.ToDecimal(value); }
        }

        private decimal amtWithDiscTraField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal AmtWithDiscTra
        {
            get
            {
                return this.amtWithDiscTraField;
            }
            set
            {
                this.amtWithDiscTraField = value;
            }
        }

        [XmlElement(ElementName = "AmtWithDiscTra")]
        public string AmtWithDiscTraString
        {
            get { return this.amtWithDiscTraField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.amtWithDiscTraField = StringUtil.ToDecimal(value); }
        }

        private int amtWithDiscTraForUnitField;
        [XmlElement(ElementName = "AmtWithDiscTraForUnit")]
        public int AmtWithDiscTraForUnit
        {
            get { return this.amtWithDiscTraForUnitField; }
            set { this.amtWithDiscTraForUnitField = value; }
        }

        private decimal unitPriceTra0Field;
        [System.Xml.Serialization.XmlIgnore]
        public decimal UnitPriceTra0
        {
            get
            {
                return this.unitPriceTra0Field;
            }
            set
            {
                this.unitPriceTra0Field = value;
            }
        }

        [XmlElement(ElementName = "UnitPriceTra0")]
        public string UnitPriceTra0String
        {
            get { return this.unitPriceTra0Field.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.unitPriceTra0Field = StringUtil.ToDecimal(value); }
        }

        private string detailPropertyField = "ItemDCollection";
        [XmlAttribute(AttributeName = "DetailProperty")]
        public string DetailProperty
        {
            get { return this.detailPropertyField; }
            set { this.detailPropertyField = value; }
        }
    }

}

