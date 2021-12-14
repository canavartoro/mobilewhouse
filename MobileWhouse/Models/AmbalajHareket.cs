using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MobileWhouse.Util;

namespace MobileWhouse.Models
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "Uyum", IsNullable = false)]
    public class AmbalajHareket : BaseModel
    {
        private AmbalajHareketDetail[] uyumDetailItemField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UyumDetailItem")]
        public AmbalajHareketDetail[] UyumDetailItem
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

        private int idField;
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

        private string coCodeField;
        /// <remarks/>
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

        private string coDescField;
        /// <remarks/>
        public string CoDesc
        {
            get
            {
                return this.coDescField;
            }
            set
            {
                this.coDescField = value;
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

        private string whouseDescField;
        /// <remarks/>
        public string WhouseDesc
        {
            get
            {
                return this.whouseDescField;
            }
            set
            {
                this.whouseDescField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public DateTime DocDate { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("DocDate")]
        public string DocDateString
        {
            get { return this.DocDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.DocDate = StringUtil.ToDatetime(value); }
        }

        private string docNoField;
        /// <remarks/>
        public string DocNo
        {
            get
            {
                return this.docNoField;
            }
            set
            {
                this.docNoField = value;
            }
        }

        private string packageNoField;
        /// <remarks/>
        public string PackageNo
        {
            get
            {
                return this.packageNoField;
            }
            set
            {
                this.packageNoField = value;
            }
        }

        private string docTraCodeField;
        /// <remarks/>
        public string DocTraCode
        {
            get
            {
                return this.docTraCodeField;
            }
            set
            {
                this.docTraCodeField = value;
            }
        }

        private int docTraIdField;
        /// <remarks/>
        public int DocTraId
        {
            get
            {
                return this.docTraIdField;
            }
            set
            {
                this.docTraIdField = value;
            }
        }

        private string docTraDescField;
        /// <remarks/>
        public string DocTraDesc
        {
            get
            {
                return this.docTraDescField;
            }
            set
            {
                this.docTraDescField = value;
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

        private string whouseCodeField;
        /// <remarks/>
        public string WhouseCode
        {
            get
            {
                return this.whouseCodeField;
            }
            set
            {
                this.whouseCodeField = value;
            }
        }

        private int whouseIdField;
        /// <remarks/>
        public int WhouseId
        {
            get
            {
                return this.whouseIdField;
            }
            set
            {
                this.whouseIdField = value;
            }
        }

        private string whouse2CodeField;
        /// <remarks/>
        public string Whouse2Code
        {
            get
            {
                return this.whouse2CodeField;
            }
            set
            {
                this.whouse2CodeField = value;
            }
        }

        private int whouse2IdField;
        /// <remarks/>
        public int Whouse2Id
        {
            get
            {
                return this.whouse2IdField;
            }
            set
            {
                this.whouse2IdField = value;
            }
        }

        private string entityCodeField;
        /// <remarks/>
        public string EntityCode
        {
            get
            {
                return this.entityCodeField;
            }
            set
            {
                this.entityCodeField = value;
            }
        }

        private int entityIdField;
        /// <remarks/>
        public int EntityId
        {
            get
            {
                return this.entityIdField;
            }
            set
            {
                this.entityIdField = value;
            }
        }

        private string packageOperationTypeField;
        /// <remarks/>
        public string PackageOperationType
        {
            get
            {
                return this.packageOperationTypeField;
            }
            set
            {
                this.packageOperationTypeField = value;
            }
        }

        private string inventoryStatusField;
        /// <remarks/>
        public string InventoryStatus
        {
            get
            {
                return this.inventoryStatusField;
            }
            set
            {
                this.inventoryStatusField = value;
            }
        }

        private string sourceAppField;
        /// <remarks/>
        public string SourceApp
        {
            get
            {
                return this.sourceAppField;
            }
            set
            {
                this.sourceAppField = value;
            }
        }

        private string pTypesField;
        /// <remarks/>
        public string PTypes
        {
            get
            {
                return this.pTypesField;
            }
            set
            {
                this.pTypesField = value;
            }
        }

        private decimal heightField;
        /// <remarks/>
        public decimal Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        private decimal weightField;
        /// <remarks/>
        public decimal Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        private decimal widthField;
        /// <remarks/>
        public decimal Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        private decimal depthField;
        /// <remarks/>
        public decimal Depth
        {
            get
            {
                return this.depthField;
            }
            set
            {
                this.depthField = value;
            }
        }

        private int sourceMIdField;
        /// <remarks/>
        public int SourceMId
        {
            get
            {
                return this.sourceMIdField;
            }
            set
            {
                this.sourceMIdField = value;
            }
        }

        private decimal tareField;
        /// <remarks/>
        public decimal Tare
        {
            get
            {
                return this.tareField;
            }
            set
            {
                this.tareField = value;
            }
        }

        private string typeField = "INV.PackageTraM, INV";
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        [System.Xml.Serialization.XmlAttribute(AttributeName = "Type")]
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
    public partial class AmbalajHareketDetail
    {
        private string addString01Field;
        /// <remarks/>
        public string AddString01
        {
            get
            {
                return this.addString01Field;
            }
            set
            {
                this.addString01Field = value;
            }
        }

        private int idField;
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

        private string itemCode2Field;
        /// <remarks/>
        public string ItemCode2
        {
            get
            {
                return this.itemCode2Field;
            }
            set
            {
                this.itemCode2Field = value;
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

        private int packageTraMIdField;
        /// <remarks/>
        public int PackageTraMId
        {
            get
            {
                return this.packageTraMIdField;
            }
            set
            {
                this.packageTraMIdField = value;
            }
        }

        private string packageNoField;
        /// <remarks/>
        public string PackageNo
        {
            get
            {
                return this.packageNoField;
            }
            set
            {
                this.packageNoField = value;
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

        private string packageDetailTypeField;
        /// <remarks/>
        public string PackageDetailType
        {
            get
            {
                return this.packageDetailTypeField;
            }
            set
            {
                this.packageDetailTypeField = value;
            }
        }

        private int packageMIdField;
        /// <remarks/>
        public int PackageMId
        {
            get
            {
                return this.packageMIdField;
            }
            set
            {
                this.packageMIdField = value;
            }
        }

        private string packageMNoField;
        /// <remarks/>
        public string PackageMNo
        {
            get
            {
                return this.packageMNoField;
            }
            set
            {
                this.packageMNoField = value;
            }
        }

        private int dcardIdField;
        /// <remarks/>
        public int DcardId
        {
            get
            {
                return this.dcardIdField;
            }
            set
            {
                this.dcardIdField = value;
            }
        }

        private string dcardCodeField;
        /// <remarks/>
        public string DcardCode
        {
            get
            {
                return this.dcardCodeField;
            }
            set
            {
                this.dcardCodeField = value;
            }
        }

        private string dcardNameField;
        /// <remarks/>
        public string DcardName
        {
            get
            {
                return this.dcardNameField;
            }
            set
            {
                this.dcardNameField = value;
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

        private int bwhLocationIdField;
        /// <remarks/>
        public int BwhLocationId
        {
            get
            {
                return this.bwhLocationIdField;
            }
            set
            {
                this.bwhLocationIdField = value;
            }
        }

        private string locationCodeField;
        /// <remarks/>
        public string LocationCode
        {
            get
            {
                return this.locationCodeField;
            }
            set
            {
                this.locationCodeField = value;
            }
        }

        private decimal volumeField;
        /// <remarks/>
        public decimal Volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }

        private decimal weightField;
        /// <remarks/>
        public decimal Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        private decimal widthField;
        /// <remarks/>
        public decimal Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        private decimal depthField;
        /// <remarks/>
        public decimal Depth
        {
            get
            {
                return this.depthField;
            }
            set
            {
                this.depthField = value;
            }
        }

        private decimal heightField;
        /// <remarks/>
        public decimal Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        private decimal tareField;
        /// <remarks/>
        public decimal Tare
        {
            get
            {
                return this.tareField;
            }
            set
            {
                this.tareField = value;
            }
        }

        private decimal netWeightField;
        /// <remarks/>
        public decimal NetWeight
        {
            get
            {
                return this.netWeightField;
            }
            set
            {
                this.netWeightField = value;
            }
        }

        private string packageOperationTypeField;
        /// <remarks/>
        public string PackageOperationType
        {
            get
            {
                return this.packageOperationTypeField;
            }
            set
            {
                this.packageOperationTypeField = value;
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

        private string detailPropertyField = "PackageTraDCollection";
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
