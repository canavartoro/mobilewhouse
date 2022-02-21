using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using MobileWhouse.Util;
using MobileWhouse.Enums;

namespace MobileWhouse.Models
{
    [XmlRoot(ElementName = "Uyum")]
    public class PqcMaster : BaseModel
    {
        private int idField;
        [XmlElement(ElementName = "Id")]
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

        [XmlElement(ElementName = "MeasurementOk")]
        public string MeasurementOkString
        {
            get { return measurementOkField == true ? "True" : "False"; }
            set { this.measurementOkField = "True".Equals(value, StringComparison.OrdinalIgnoreCase); }
        }

        private bool measurementOkField;
        [System.Xml.Serialization.XmlIgnore]
        public bool MeasurementOk
        {
            get
            {
                return this.measurementOkField;
            }
            set
            {
                this.measurementOkField = value;
            }
        }

        private int createUserIdField;
        [XmlElement(ElementName = "CreateUserId")]
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
        [XmlElement(ElementName = "UpdateUserId")]
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

        private string branchCodeField;
        [XmlElement(ElementName = "BranchCode")]
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

        //[XmlElement(ElementName = "BranchDesc")]
        //public string BranchDesc { get; set; }

        private int branchIdField;
        [XmlElement(ElementName = "BranchId")]
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

        private int afterMinuteField;
        [XmlElement(ElementName = "AfterMinute")]
        public int AfterMinute
        {
            get
            {
                return this.afterMinuteField;
            }
            set
            {
                this.afterMinuteField = value;
            }
        }

        [XmlElement(ElementName = "ControlQty")]
        public string ControlQtyString
        {
            get { return controlQtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.controlQtyField = StringUtil.ToDecimal(value); }
        }

        private decimal controlQtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal ControlQty
        {
            get
            {
                return this.controlQtyField;
            }
            set
            {
                this.controlQtyField = value;
            }
        }

        private ControlReason controlReasonField = ControlReason.ÜretimBaşlangıcı;
        [XmlElement(ElementName = "ControlReason")]
        public ControlReason ControlReason
        {
            get
            {
                return this.controlReasonField;
            }
            set
            {
                this.controlReasonField = value;
            }
        }

        private ControlType controlTypeField = ControlType.SıkıKontrol;
        [XmlElement(ElementName = "ControlType")]
        public ControlType ControlType
        {
            get
            {
                return this.controlTypeField;
            }
            set
            {
                this.controlTypeField = value;
            }
        }

        private int controlUserIdField;
        [XmlElement(ElementName = "ControlUserId")]
        public int ControlUserId
        {
            get
            {
                return this.controlUserIdField;
            }
            set
            {
                this.controlUserIdField = value;
            }
        }

        private string coCodeField;
        [XmlElement(ElementName = "CoCode")]
        public string CoCode
        {
            get
            {
                return this.coCodeField;
            }
            set
            {
                this.coCodeField = value;
            }
        }

        //[XmlElement(ElementName = "CoDesc")]
        //public string CoDesc { get; set; }

        private int coIdField;
        [XmlElement(ElementName = "CoId")]
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

        private string caliberCodeField;
        [XmlElement(ElementName = "CaliberCode")]
        public string CaliberCode
        {
            get
            {
                return this.caliberCodeField;
            }
            set
            {
                this.caliberCodeField = value;
            }
        }

        private string itemLotNoField;
        [XmlElement(ElementName = "ItemLotNo")]
        public string ItemLotNo
        {
            get
            {
                return this.itemLotNoField;
            }
            set
            {
                this.itemLotNoField = value;
            }
        }

        //private string description33Field;
        //[XmlElement(ElementName = "Description33")]
        //public string Description33
        //{
        //    get
        //    {
        //        return this.description33Field;
        //    }
        //    set
        //    {
        //        this.description33Field = value;
        //    }
        //}

        //private string description44Field;
        //[XmlElement(ElementName = "Description44")]
        //public string Description44
        //{
        //    get
        //    {
        //        return this.description44Field;
        //    }
        //    set
        //    {
        //        this.description44Field = value;
        //    }
        //}

        private string description4Field;
        [XmlElement(ElementName = "Description4")]
        public string Description4
        {
            get
            {
                return this.description4Field;
            }
            set
            {
                this.description4Field = value;
            }
        }

        [XmlElement(ElementName = "Humidity")]
        public string HumidityString
        {
            get { return humidityField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.humidityField = StringUtil.ToDecimal(value); }
        }

        private decimal humidityField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal Humidity
        {
            get
            {
                return this.humidityField;
            }
            set
            {
                this.humidityField = value;
            }
        }

        private string itemCodeField;
        [XmlElement(ElementName = "ItemCode")]
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

        private int itemIdField;
        [XmlElement(ElementName = "ItemId")]
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

        private int operatorIdField;
        [XmlElement(ElementName = "OperatorId")]
        public int OperatorId
        {
            get
            {
                return this.operatorIdField;
            }
            set
            {
                this.operatorIdField = value;
            }
        }

        //[XmlElement(ElementName = "ItemName")]
        //public string ItemName { get; set; }

        private int operationNoField;
        [XmlElement(ElementName = "OperationNo")]
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

        private string operationCodeField;
        [XmlElement(ElementName = "OperationCode")]
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

        private int operationIdField;
        [XmlElement(ElementName = "OperationId")]
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

        private DateTime pqcDateField;
        [System.Xml.Serialization.XmlIgnore]
        public DateTime PqcDate
        {
            get
            {
                return this.pqcDateField;
            }
            set
            {
                this.pqcDateField = value;
            }
        }

        [XmlElement(ElementName = "PqcDate")]
        public string PqcDateString
        {
            get { return this.PqcDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.PqcDate = StringUtil.ToDatetime(value); }
        }

        private string pqcNoField;
        [XmlElement(ElementName = "PqcNo")]
        public string PqcNo
        {
            get
            {
                return this.pqcNoField;
            }
            set
            {
                this.pqcNoField = value;
            }
        }

        //[XmlElement(ElementName = "Temperature")]
        //public string Temperature { get; set; }

        private string unitCodeField;
        [XmlElement(ElementName = "UnitCode")]
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

        private int unitIdField;
        [XmlElement(ElementName = "UnitId")]
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

        private int worderMIdField;
        [XmlElement(ElementName = "WorderMId")]
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
        [XmlElement(ElementName = "WorderNo")]
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

        private string nameField;
        [XmlElement(ElementName = "Name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        private string surnameField;
        [XmlElement(ElementName = "Surname")]
        public string Surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }

        private string useMan2Field = "True";
        [XmlElement(ElementName = "UseMan2")]
        public string UseMan2
        {
            get
            {
                return this.useMan2Field;
            }
            set
            {
                this.useMan2Field = value;
            }
        }

        private ActionState openCloseField = ActionState.Açık;
        [XmlElement(ElementName = "OpenClose")]
        public ActionState OpenClose
        {
            get
            {
                return this.openCloseField;
            }
            set
            {
                this.openCloseField = value;
            }
        }

        private int bomMIdField;
        [XmlElement(ElementName = "BomMId")]
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

        private string alternativeNoField;
        [XmlElement(ElementName = "AlternativeNo")]
        public string AlternativeNo
        {
            get
            {
                return this.alternativeNoField;
            }
            set
            {
                this.alternativeNoField = value;
            }
        }

        private string measurementTimeField;
        [XmlElement(ElementName = "MeasurementTime")]
        public string MeasurementTime
        {
            get
            {
                return this.measurementTimeField;
            }
            set
            {
                this.measurementTimeField = value;
            }
        }

        private List<PqcDetail> uyumDetailItemField;
        [XmlElement(ElementName = "UyumDetailItem")]
        public List<PqcDetail> UyumDetailItem
        {
            get
            {
                return this.uyumDetailItemField;
            }
            set
            {
                this.uyumDetailItemField = value;
            }
        }

        private string typeField = "QLT.PqcMaster, QLT";
        [XmlAttribute(AttributeName = "Type")]
        public string Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }
    }

    [XmlRoot(ElementName = "UyumDetailItem")]
    public class PqcDetail
    {
        private int idField;
        [XmlElement(ElementName = "Id")]
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
        [XmlElement(ElementName = "CreateUserId")]
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

        //[XmlElement(ElementName = "CreateDate")]
        //public string CreateDate { get; set; }

        private string controlPointCodeField;
        [XmlElement(ElementName = "ControlPointCode")]
        public string ControlPointCode
        {
            get
            {
                return this.controlPointCodeField;
            }
            set
            {
                this.controlPointCodeField = value;
            }
        }

        //[XmlElement(ElementName = "ControlPointDesc")]
        //public string ControlPointDesc { get; set; }

        private int controlPointIdField;
        [XmlElement(ElementName = "ControlPointId")]
        public int ControlPointId
        {
            get
            {
                return this.controlPointIdField;
            }
            set
            {
                this.controlPointIdField = value;
            }
        }

        private decimal maxPointQtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal MaxPointQty
        {
            get
            {
                return this.maxPointQtyField;
            }
            set
            {
                this.maxPointQtyField = value;
            }
        }

        [XmlElement(ElementName = "MaxPointQty")]
        public string MaxPointQtyString
        {
            get { return this.maxPointQtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.maxPointQtyField = StringUtil.ToDecimal(value); }
        }

        private decimal maxPointTqtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal MaxPointTqty
        {
            get
            {
                return this.maxPointTqtyField;
            }
            set
            {
                this.maxPointTqtyField = value;
            }
        }

        [XmlElement(ElementName = "MaxPointTqty")]
        public string MaxPointTqtyString
        {
            get { return this.maxPointTqtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.maxPointTqtyField = StringUtil.ToDecimal(value); }
        }

        private decimal minPointQtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal MinPointQty
        {
            get
            {
                return this.minPointQtyField;
            }
            set
            {
                this.minPointQtyField = value;
            }
        }

        [XmlElement(ElementName = "MinPointQty")]
        public string MinPointQtyString
        {
            get { return this.minPointQtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.minPointQtyField = StringUtil.ToDecimal(value); }
        }

        private decimal pointQtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal PointQty
        {
            get
            {
                return this.pointQtyField;
            }
            set
            {
                this.pointQtyField = value;
            }
        }

        [XmlElement(ElementName = "PointQty")]
        public string PointQtyString
        {
            get { return this.pointQtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.pointQtyField = StringUtil.ToDecimal(value); }
        }

        private int pointResultField;
        [XmlElement(ElementName = "PointResult")]
        public int PointResult
        {
            get
            {
                return this.pointResultField;
            }
            set
            {
                this.pointResultField = value;
            }
        }

        //[XmlElement(ElementName = "PqcMasterId")]
        //public int PqcMasterId { get; set; }

        private int sampleNoField;
        [XmlElement(ElementName = "SampleNo")]
        public int SampleNo
        {
            get
            {
                return this.sampleNoField;
            }
            set
            {
                this.sampleNoField = value;
            }
        }

        private decimal nominalPointQtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal NominalPointQty
        {
            get
            {
                return this.nominalPointQtyField;
            }
            set
            {
                this.nominalPointQtyField = value;
            }
        }

        [XmlElement(ElementName = "NominalPointQty")]
        public string NominalPointQtyString
        {
            get { return this.nominalPointQtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.nominalPointQtyField = StringUtil.ToDecimal(value); }
        }

        private decimal utoleranceQtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal UtoleranceQty
        {
            get
            {
                return this.utoleranceQtyField;
            }
            set
            {
                this.utoleranceQtyField = value;
            }
        }

        [XmlElement(ElementName = "UtoleranceQty")]
        public string UtoleranceQtyString
        {
            get { return this.utoleranceQtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.utoleranceQtyField = StringUtil.ToDecimal(value); }
        }

        private decimal dtoleranceQtyField;
        [System.Xml.Serialization.XmlIgnore]
        public decimal DtoleranceQty
        {
            get
            {
                return this.dtoleranceQtyField;
            }
            set
            {
                this.dtoleranceQtyField = value;
            }
        }

        [XmlElement(ElementName = "DtoleranceQty")]
        public string DtoleranceQtyString
        {
            get { return this.dtoleranceQtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.dtoleranceQtyField = StringUtil.ToDecimal(value); }
        }

        private int lineNoField;
        [XmlElement(ElementName = "LineNo")]
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

        private string detailPropertyField = "PqcDCollection";
        [XmlAttribute(AttributeName = "DetailProperty")]
        public string DetailProperty
        {
            get { return this.detailPropertyField; }
            set { this.detailPropertyField = value; }
        }
    }
}
