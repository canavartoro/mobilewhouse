using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MobileWhouse.Models
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "Uyum", IsNullable = false)]
    public class UretimGiris : BaseModel
    {
        private int idField = Convert.ToInt32(DateTime.Now.ToString("hmsfff")) * -1;
        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        private int createUserIdField;
        /// <remarks/>
        public int CreateUserId
        {
            get
            {
                return this.createUserIdField;
            }
            set
            {
                this.createUserIdField = value;
            }
        }

        private int updateUserIdField;
        /// <remarks/>
        public int UpdateUserId
        {
            get
            {
                return this.updateUserIdField;
            }
            set
            {
                this.updateUserIdField = value;
            }
        }

        private string createDateField;
        /// <remarks/>
        public string CreateDate
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

        private string updateDateField;
        /// <remarks/>
        public string UpdateDate
        {
            get
            {
                return this.updateDateField;
            }
            set
            {
                this.updateDateField = value;
            }
        }

        private int coIdField;
        /// <remarks/>
        public int CoId
        {
            get
            {
                return this.coIdField;
            }
            set
            {
                this.coIdField = value;
            }
        }

        private int branchIdField;
        /// <remarks/>
        public int BranchId
        {
            get
            {
                return this.branchIdField;
            }
            set
            {
                this.branchIdField = value;
            }
        }

        private string branchCodeField;
        /// <remarks/>
        public string BranchCode
        {
            get
            {
                return this.branchCodeField;
            }
            set
            {
                this.branchCodeField = value;
            }
        }

        private string branchDescField;
        /// <remarks/>
        public string BranchDesc
        {
            get
            {
                return this.branchDescField;
            }
            set
            {
                this.branchDescField = value;
            }
        }

        private int worderMIdField;
        /// <remarks/>
        public int WorderMId
        {
            get
            {
                return this.worderMIdField;
            }
            set
            {
                this.worderMIdField = value;
            }
        }

        private string worderNoField;
        /// <remarks/>
        public string WorderNo
        {
            get
            {
                return this.worderNoField;
            }
            set
            {
                this.worderNoField = value;
            }
        }

        private decimal worderMQtyField;
        /// <remarks/>
        public decimal WorderMQty
        {
            get
            {
                return this.worderMQtyField;
            }
            set
            {
                this.worderMQtyField = value;
            }
        }

        private decimal worderMQtyManField;
        /// <remarks/>
        public decimal WorderMQtyMan
        {
            get
            {
                return this.worderMQtyManField;
            }
            set
            {
                this.worderMQtyManField = value;
            }
        }

        private decimal worderOpQtyManField;
        /// <remarks/>
        public decimal WorderOpQtyMan
        {
            get
            {
                return this.worderOpQtyManField;
            }
            set
            {
                this.worderOpQtyManField = value;
            }
        }

        private bool isWorderOpConfField;
        /// <remarks/>
        public bool IsWorderOpConf
        {
            get
            {
                return this.isWorderOpConfField;
            }
            set
            {
                this.isWorderOpConfField = value;
            }
        }

        private bool isWorderOpPartialField;
        /// <remarks/>
        public bool IsWorderOpPartial
        {
            get
            {
                return this.isWorderOpPartialField;
            }
            set
            {
                this.isWorderOpPartialField = value;
            }
        }

        private int worderMUnitIdField;
        /// <remarks/>
        public int WorderMUnitId
        {
            get
            {
                return this.worderMUnitIdField;
            }
            set
            {
                this.worderMUnitIdField = value;
            }
        }

        private string worderMUnitCodeField;
        /// <remarks/>
        public string WorderMUnitCode
        {
            get
            {
                return this.worderMUnitCodeField;
            }
            set
            {
                this.worderMUnitCodeField = value;
            }
        }

        private int woTypeIdField;
        /// <remarks/>
        public int WoTypeId
        {
            get
            {
                return this.woTypeIdField;
            }
            set
            {
                this.woTypeIdField = value;
            }
        }

        private string worderTypeField;
        /// <remarks/>
        public string WorderType
        {
            get
            {
                return this.worderTypeField;
            }
            set
            {
                this.worderTypeField = value;
            }
        }

        private string worderClassField;
        /// <remarks/>
        public string WorderClass
        {
            get
            {
                return this.worderClassField;
            }
            set
            {
                this.worderClassField = value;
            }
        }

        private string woSchedulingTypeField;
        /// <remarks/>
        public string WoSchedulingType
        {
            get
            {
                return this.woSchedulingTypeField;
            }
            set
            {
                this.woSchedulingTypeField = value;
            }
        }

        private int itemIdField;
        /// <remarks/>
        public int ItemId
        {
            get
            {
                return this.itemIdField;
            }
            set
            {
                this.itemIdField = value;
            }
        }

        private string itemCodeField;
        /// <remarks/>
        public string ItemCode
        {
            get
            {
                return this.itemCodeField;
            }
            set
            {
                this.itemCodeField = value;
            }
        }

        private string itemNameField;
        /// <remarks/>
        public string ItemName
        {
            get
            {
                return this.itemNameField;
            }
            set
            {
                this.itemNameField = value;
            }
        }

        private int itemUnitIdField;
        /// <remarks/>
        public int ItemUnitId
        {
            get
            {
                return this.itemUnitIdField;
            }
            set
            {
                this.itemUnitIdField = value;
            }
        }

        private string itemUnitCodeField;
        /// <remarks/>
        public string ItemUnitCode
        {
            get
            {
                return this.itemUnitCodeField;
            }
            set
            {
                this.itemUnitCodeField = value;
            }
        }

        private int bomMIdField;
        /// <remarks/>
        public int BomMId
        {
            get
            {
                return this.bomMIdField;
            }
            set
            {
                this.bomMIdField = value;
            }
        }

        private decimal qtyField;
        /// <remarks/>
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

        private decimal qtyNetField;
        /// <remarks/>
        public decimal QtyNet
        {
            get
            {
                return this.qtyNetField;
            }
            set
            {
                this.qtyNetField = value;
            }
        }

        private decimal qtyGrossField;
        /// <remarks/>
        public decimal QtyGross
        {
            get
            {
                return this.qtyGrossField;
            }
            set
            {
                this.qtyGrossField = value;
            }
        }

        private decimal qtyPrmField;
        /// <remarks/>
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

        private decimal qtyTotalScrapField;
        /// <remarks/>
        public decimal QtyTotalScrap
        {
            get
            {
                return this.qtyTotalScrapField;
            }
            set
            {
                this.qtyTotalScrapField = value;
            }
        }

        private decimal qtyTotalReworkField;
        /// <remarks/>
        public decimal QtyTotalRework
        {
            get
            {
                return this.qtyTotalReworkField;
            }
            set
            {
                this.qtyTotalReworkField = value;
            }
        }

        private int unitIdField;
        /// <remarks/>
        public int UnitId
        {
            get
            {
                return this.unitIdField;
            }
            set
            {
                this.unitIdField = value;
            }
        }

        private string unitCodeField;
        /// <remarks/>
        public string UnitCode
        {
            get
            {
                return this.unitCodeField;
            }
            set
            {
                this.unitCodeField = value;
            }
        }

        private decimal qtyFreePrmField;
        /// <remarks/>
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

        private decimal qtyFreeSecField;
        /// <remarks/>
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

        private int worderOpDIdField;
        /// <remarks/>
        public int WorderOpDId
        {
            get
            {
                return this.worderOpDIdField;
            }
            set
            {
                this.worderOpDIdField = value;
            }
        }

        private int operationIdField;
        /// <remarks/>
        public int OperationId
        {
            get
            {
                return this.operationIdField;
            }
            set
            {
                this.operationIdField = value;
            }
        }

        private string operationCodeField;
        /// <remarks/>
        public string OperationCode
        {
            get
            {
                return this.operationCodeField;
            }
            set
            {
                this.operationCodeField = value;
            }
        }

        private string operationDescriptionField;
        /// <remarks/>
        public string OperationDescription
        {
            get
            {
                return this.operationDescriptionField;
            }
            set
            {
                this.operationDescriptionField = value;
            }
        }

        private int operationNoField;
        /// <remarks/>
        public int OperationNo
        {
            get
            {
                return this.operationNoField;
            }
            set
            {
                this.operationNoField = value;
            }
        }

        private bool isFirstOprField;
        /// <remarks/>
        public bool IsFirstOpr
        {
            get
            {
                return this.isFirstOprField;
            }
            set
            {
                this.isFirstOprField = value;
            }
        }

        private bool isLastOprField;
        /// <remarks/>
        public bool IsLastOpr
        {
            get
            {
                return this.isLastOprField;
            }
            set
            {
                this.isLastOprField = value;
            }
        }

        private int aWstationIdField;
        /// <remarks/>
        public int AWstationId
        {
            get
            {
                return this.aWstationIdField;
            }
            set
            {
                this.aWstationIdField = value;
            }
        }

        private string aWstationCodeField;
        /// <remarks/>
        public string AWstationCode
        {
            get
            {
                return this.aWstationCodeField;
            }
            set
            {
                this.aWstationCodeField = value;
            }
        }

        private string aWstationDescField;
        /// <remarks/>
        public string AWstationDesc
        {
            get
            {
                return this.aWstationDescField;
            }
            set
            {
                this.aWstationDescField = value;
            }
        }

        private DateTime startDateField;
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public DateTime StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("StartDate")]
        public string StartDateString
        {
            get { return this.StartDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.StartDate = DateTime.Parse(value); }
        }

        private DateTime endDateField;
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public DateTime EndDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("EndDate")]
        public string EndDateString
        {
            get { return this.EndDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.EndDate = DateTime.Parse(value); }
        }

        private decimal opDurationField;
        /// <remarks/>
        public decimal OpDuration
        {
            get
            {
                return this.opDurationField;
            }
            set
            {
                this.opDurationField = value;
            }
        }

        private decimal machineDurationField;
        /// <remarks/>
        public decimal MachineDuration
        {
            get
            {
                return this.machineDurationField;
            }
            set
            {
                this.machineDurationField = value;
            }
        }

        private decimal breakDurationField;
        /// <remarks/>
        public decimal BreakDuration
        {
            get
            {
                return this.breakDurationField;
            }
            set
            {
                this.breakDurationField = value;
            }
        }

        private decimal woBreakDurationField;
        /// <remarks/>
        public decimal WoBreakDuration
        {
            get
            {
                return this.woBreakDurationField;
            }
            set
            {
                this.woBreakDurationField = value;
            }
        }

        private decimal costBreakDurationField;
        /// <remarks/>
        public decimal CostBreakDuration
        {
            get
            {
                return this.costBreakDurationField;
            }
            set
            {
                this.costBreakDurationField = value;
            }
        }

        private int durationUnitIdField = 168;
        /// <remarks/>
        public int DurationUnitId
        {
            get
            {
                return this.durationUnitIdField;
            }
            set
            {
                this.durationUnitIdField = value;
            }
        }

        private string durationUnitCodeField;
        /// <remarks/>
        public string DurationUnitCode
        {
            get
            {
                return this.durationUnitCodeField;
            }
            set
            {
                this.durationUnitCodeField = value;
            }
        }

        private string durationUnitTypeField = "Minute";
        /// <remarks/>
        public string DurationUnitType
        {
            get
            {
                return this.durationUnitTypeField;
            }
            set
            {
                this.durationUnitTypeField = value;
            }
        }

        private decimal costMultiplier1Field;
        /// <remarks/>
        public decimal CostMultiplier1
        {
            get
            {
                return this.costMultiplier1Field;
            }
            set
            {
                this.costMultiplier1Field = value;
            }
        }

        private decimal costMultiplier2Field;
        /// <remarks/>
        public decimal CostMultiplier2
        {
            get
            {
                return this.costMultiplier2Field;
            }
            set
            {
                this.costMultiplier2Field = value;
            }
        }

        private decimal startMoveQtyField;
        /// <remarks/>
        public decimal StartMoveQty
        {
            get
            {
                return this.startMoveQtyField;
            }
            set
            {
                this.startMoveQtyField = value;
            }
        }

        private int startMoveUnitIdField;
        /// <remarks/>
        public int StartMoveUnitId
        {
            get
            {
                return this.startMoveUnitIdField;
            }
            set
            {
                this.startMoveUnitIdField = value;
            }
        }

        private string startMoveUnitCodeField;
        /// <remarks/>
        public string StartMoveUnitCode
        {
            get
            {
                return this.startMoveUnitCodeField;
            }
            set
            {
                this.startMoveUnitCodeField = value;
            }
        }

        private decimal startWaitingQtyField;
        /// <remarks/>
        public decimal StartWaitingQty
        {
            get
            {
                return this.startWaitingQtyField;
            }
            set
            {
                this.startWaitingQtyField = value;
            }
        }

        private int startWaitingUnitIdField;
        /// <remarks/>
        public int StartWaitingUnitId
        {
            get
            {
                return this.startWaitingUnitIdField;
            }
            set
            {
                this.startWaitingUnitIdField = value;
            }
        }

        private string startWaitingUnitCodeField;
        /// <remarks/>
        public string StartWaitingUnitCode
        {
            get
            {
                return this.startWaitingUnitCodeField;
            }
            set
            {
                this.startWaitingUnitCodeField = value;
            }
        }

        private decimal endMoveQtyField;
        /// <remarks/>
        public decimal EndMoveQty
        {
            get
            {
                return this.endMoveQtyField;
            }
            set
            {
                this.endMoveQtyField = value;
            }
        }

        private int endMoveUnitIdField;
        /// <remarks/>
        public int EndMoveUnitId
        {
            get
            {
                return this.endMoveUnitIdField;
            }
            set
            {
                this.endMoveUnitIdField = value;
            }
        }

        private string endMoveUnitCodeField;
        /// <remarks/>
        public string EndMoveUnitCode
        {
            get
            {
                return this.endMoveUnitCodeField;
            }
            set
            {
                this.endMoveUnitCodeField = value;
            }
        }

        private decimal endWaitingQtyField;
        /// <remarks/>
        public decimal EndWaitingQty
        {
            get
            {
                return this.endWaitingQtyField;
            }
            set
            {
                this.endWaitingQtyField = value;
            }
        }

        private int endWaitingUnitIdField;
        /// <remarks/>
        public int EndWaitingUnitId
        {
            get
            {
                return this.endWaitingUnitIdField;
            }
            set
            {
                this.endWaitingUnitIdField = value;
            }
        }

        private string endWaitingUnitCodeField;
        /// <remarks/>
        public string EndWaitingUnitCode
        {
            get
            {
                return this.endWaitingUnitCodeField;
            }
            set
            {
                this.endWaitingUnitCodeField = value;
            }
        }

        #region Depo Gonderme
        private int productInputWhouseIdField = 3680;
        /// <remarks/>
        public int ProductInputWhouseId
        {
            get
            {
                return this.productInputWhouseIdField;
            }
            set
            {
                this.productInputWhouseIdField = value;
            }
        }

        private string productInputWhouseCodeField;
        /// <remarks/>
        public string ProductInputWhouseCode
        {
            get
            {
                return this.productInputWhouseCodeField;
            }
            set
            {
                this.productInputWhouseCodeField = value;
            }
        }

        private string productInputWhouseDescField;
        /// <remarks/>
        public string ProductInputWhouseDesc
        {
            get
            {
                return this.productInputWhouseDescField;
            }
            set
            {
                this.productInputWhouseDescField = value;
            }
        }

        private int productScrapInputWhouseIdField = 3696;
        /// <remarks/>
        public int ProductScrapInputWhouseId
        {
            get
            {
                return this.productScrapInputWhouseIdField;
            }
            set
            {
                this.productScrapInputWhouseIdField = value;
            }
        }

        private string productScrapInputWhouseCodeField;
        /// <remarks/>
        public string ProductScrapInputWhouseCode
        {
            get
            {
                return this.productScrapInputWhouseCodeField;
            }
            set
            {
                this.productScrapInputWhouseCodeField = value;
            }
        }

        private string productScrapInputWhouseDescField;
        /// <remarks/>
        public string ProductScrapInputWhouseDesc
        {
            get
            {
                return this.productScrapInputWhouseDescField;
            }
            set
            {
                this.productScrapInputWhouseDescField = value;
            }
        }

        private int materialScrapInputWhouseIdField = 3696;
        /// <remarks/>
        public int MaterialScrapInputWhouseId
        {
            get
            {
                return this.materialScrapInputWhouseIdField;
            }
            set
            {
                this.materialScrapInputWhouseIdField = value;
            }
        }

        private string materialScrapInputWhouseCodeField;
        /// <remarks/>
        public string MaterialScrapInputWhouseCode
        {
            get
            {
                return this.materialScrapInputWhouseCodeField;
            }
            set
            {
                this.materialScrapInputWhouseCodeField = value;
            }
        }

        private string materialScrapInputWhouseDescField;
        /// <remarks/>
        public string MaterialScrapInputWhouseDesc
        {
            get
            {
                return this.materialScrapInputWhouseDescField;
            }
            set
            {
                this.materialScrapInputWhouseDescField = value;
            }
        } 
        #endregion

        private string prdSourceAppField = "WebServisUretimGirisi";
        /// <remarks/>
        public string PrdSourceApp
        {
            get
            {
                return this.prdSourceAppField;
            }
            set
            {
                this.prdSourceAppField = value;
            }
        }

        private int acOpNumberField;
        /// <remarks/>
        public int AcOpNumber
        {
            get
            {
                return this.acOpNumberField;
            }
            set
            {
                this.acOpNumberField = value;
            }
        }

        private decimal amtAdditionalCostField;
        /// <remarks/>
        public decimal AmtAdditionalCost
        {
            get
            {
                return this.amtAdditionalCostField;
            }
            set
            {
                this.amtAdditionalCostField = value;
            }
        }

        private decimal qtyInWoUnitField;
        /// <remarks/>
        public decimal QtyInWoUnit
        {
            get
            {
                return this.qtyInWoUnitField;
            }
            set
            {
                this.qtyInWoUnitField = value;
            }
        }

        private decimal qtyNetInWoUnitField;
        /// <remarks/>
        public decimal QtyNetInWoUnit
        {
            get
            {
                return this.qtyNetInWoUnitField;
            }
            set
            {
                this.qtyNetInWoUnitField = value;
            }
        }

        private decimal qtyGrossInWoUnitField;
        /// <remarks/>
        public decimal QtyGrossInWoUnit
        {
            get
            {
                return this.qtyGrossInWoUnitField;
            }
            set
            {
                this.qtyGrossInWoUnitField = value;
            }
        }

        private bool updateControlWorderAcOpField;
        /// <remarks/>
        public bool UpdateControlWorderAcOp
        {
            get
            {
                return this.updateControlWorderAcOpField;
            }
            set
            {
                this.updateControlWorderAcOpField = value;
            }
        }

        private UretimIscilik[] iscilikField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UyumDetailItem")]
        public UretimIscilik[] Iscilik
        {
            get
            {
                return this.iscilikField;
            }
            set
            {
                this.iscilikField = value;
            }
        }

        private string typeField = "PRD.PrdWorderAcOp, PRD";
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRoot(ElementName = "UyumDetailItem", Namespace = "")]
    public class UretimIscilik
    {
        private int idField = Convert.ToInt32(DateTime.Now.ToString("hmsfff")) * -1;
        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        private int createUserIdField;
        /// <remarks/>
        public int CreateUserId
        {
            get
            {
                return this.createUserIdField;
            }
            set
            {
                this.createUserIdField = value;
            }
        }

        private string createDateField;
        /// <remarks/>
        public string CreateDate
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

        private int coIdField;
        /// <remarks/>
        public int CoId
        {
            get
            {
                return this.coIdField;
            }
            set
            {
                this.coIdField = value;
            }
        }

        private int worderMIdField;
        /// <remarks/>
        public int WorderMId
        {
            get
            {
                return this.worderMIdField;
            }
            set
            {
                this.worderMIdField = value;
            }
        }

        private int worderOpDIdField;
        /// <remarks/>
        public int WorderOpDId
        {
            get
            {
                return this.worderOpDIdField;
            }
            set
            {
                this.worderOpDIdField = value;
            }
        }

        private int branchIdField;
        /// <remarks/>
        public int BranchId
        {
            get
            {
                return this.branchIdField;
            }
            set
            {
                this.branchIdField = value;
            }
        }

        private int worderAcOpIdField;
        /// <remarks/>
        public int WorderAcOpId
        {
            get
            {
                return this.worderAcOpIdField;
            }
            set
            {
                this.worderAcOpIdField = value;
            }
        }

        private int lineNoField;
        /// <remarks/>
        public int LineNo
        {
            get
            {
                return this.lineNoField;
            }
            set
            {
                this.lineNoField = value;
            }
        }

        private int prdEmployeeIdField;
        /// <remarks/>
        public int PrdEmployeeId
        {
            get
            {
                return this.prdEmployeeIdField;
            }
            set
            {
                this.prdEmployeeIdField = value;
            }
        }

        private string citizenshipNoField;
        /// <remarks/>
        public string CitizenshipNo
        {
            get
            {
                return this.citizenshipNoField;
            }
            set
            {
                this.citizenshipNoField = value;
            }
        }

        private string empNameField;
        /// <remarks/>
        public string EmpName
        {
            get
            {
                return this.empNameField;
            }
            set
            {
                this.empNameField = value;
            }
        }

        private string empSurnameField;
        /// <remarks/>
        public string EmpSurname
        {
            get
            {
                return this.empSurnameField;
            }
            set
            {
                this.empSurnameField = value;
            }
        }

        private DateTime startDateField;
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public DateTime StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("StartDate")]
        public string StartDateString
        {
            get { return this.StartDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.StartDate = DateTime.Parse(value); }
        }

        private DateTime endDateField;
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public DateTime EndDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("EndDate")]
        public string EndDateString
        {
            get { return this.EndDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.EndDate = DateTime.Parse(value); }
        }

        private decimal netTimeField;
        /// <remarks/>
        public decimal NetTime
        {
            get
            {
                return this.netTimeField;
            }
            set
            {
                this.netTimeField = value;
            }
        }

        private string employeeSlcTypeField = "EmployeeSlc";
        /// <remarks/>
        public string EmployeeSlcType
        {
            get
            {
                return this.employeeSlcTypeField;
            }
            set
            {
                this.employeeSlcTypeField = value;
            }
        }

        private string detailPropertyField = "WorderEmployeeCollection";
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        [System.Xml.Serialization.XmlAttribute(AttributeName = "DetailProperty")]
        public string DetailProperty
        {
            get
            {
                return this.detailPropertyField;
            }
            set
            {
                this.detailPropertyField = value;
            }
        }
    }


}

/*
 UretimGiris uretim = new UretimGiris();
                    uretim.BranchId = ClientApplication.Instance.Token.BranchId;
                    uretim.CoId = ClientApplication.Instance.Token.CoId;
                    uretim.StartDate = worderacops[i].start_date.Date;
                    uretim.EndDate = worderacops[i].create_date.Date;
                    uretim.WorderMId = worderacops[i].worder_m_id;
                    uretim.ItemId = worderacops[i].item_id;
                    uretim.WorderOpDId = worderacops[i].worder_op_d_id;
                    uretim.AWstationId = wstation.PrdGobalId;
                    uretim.Qty = worderacops[i].qty_net;
                    uretim.QtyNet = worderacops[i].qty_net;
                    uretim.UnitId = worderacops[i].unit_id;
                    if (worderacops[i].Employee != null && worderacops[i].Employee.Count > 0)
                    {
                        uretim.Iscilik = new UretimIscilik[worderacops[i].Employee.Count];
                        for (int l = 0; l < worderacops[i].Employee.Count; l++)
                        {
                            uretim.Iscilik[l] = new UretimIscilik();
                            uretim.Iscilik[l].PrdEmployeeId = worderacops[i].Employee[l].prd_employee_id;
                            uretim.Iscilik[l].StartDate = worderacops[i].start_date.Date;
                            uretim.Iscilik[l].EndDate = worderacops[i].create_date.Date;
                            uretim.Iscilik[l].LineNo = (l + 1) * 10;
                        }
                    }

                    MobileWhouse.UyumSave.UyumServiceRequestOfString Context = new MobileWhouse.UyumSave.UyumServiceRequestOfString();
                    Context.Token = new MobileWhouse.UyumSave.UyumToken();
                    Context.Token.UserName = ClientApplication.Instance.Token.UserName;
                    Context.Token.Password = ClientApplication.Instance.Token.Password;
                    Context.Value = uretim.ToXml();

                    MobileWhouse.UyumSave.UyumServiceResponseOfString resp = ClientApplication.Instance.SaveServ.SaveUyumObjectFromXML(Context);
                    if (!resp.Success)
                    {
                        Screens.Error(resp.Message);
                        break;
                    }
                    else
                    {
                        UretimGiris giris = (UretimGiris)BaseModel.FromXml(typeof(UretimGiris), resp.Value);
                        Screens.Info(giris.Id.ToString());
                    }
 */


