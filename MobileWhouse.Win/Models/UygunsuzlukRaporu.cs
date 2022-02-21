using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using MobileWhouse.Util;

namespace MobileWhouse.Models
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "Uyum", IsNullable = false)]
    public class UygunsuzlukRaporu : BaseModel
    {
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

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public DateTime DeadlineDate { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("DeadlineDate")]
        public string DeadlineDateString
        {
            get { return this.DeadlineDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.DeadlineDate = StringUtil.ToDatetime(value); }
        }

        private string discordDescField;
        /// <remarks/>
        public string DiscordDesc
        {
            get
            {
                return this.discordDescField;
            }
            set
            {
                this.discordDescField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnore]
        public DateTime DiscordReportDate { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("DiscordReportDate")]
        public string DiscordReportDateString
        {
            get { return this.DiscordReportDate.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.DiscordReportDate = StringUtil.ToDatetime(value); }
        }

        private string discordReportNoField;
        /// <remarks/>
        public string DiscordReportNo
        {
            get
            {
                return this.discordReportNoField;
            }
            set
            {
                this.discordReportNoField = value;
            }
        }

        private int discordReportOptionsField;
        /// <remarks/>
        public int DiscordReportOptions
        {
            get
            {
                return this.discordReportOptionsField;
            }
            set
            {
                this.discordReportOptionsField = value;
            }
        }

        private int discordReportSourceField;
        /// <remarks/>
        public int DiscordReportSource
        {
            get
            {
                return this.discordReportSourceField;
            }
            set
            {
                this.discordReportSourceField = value;
            }
        }

        private int discordReportStateField;
        /// <remarks/>
        public int DiscordReportState
        {
            get
            {
                return this.discordReportStateField;
            }
            set
            {
                this.discordReportStateField = value;
            }
        }

        private string discordSubjectField;
        /// <remarks/>
        public string DiscordSubject
        {
            get
            {
                return this.discordSubjectField;
            }
            set
            {
                this.discordSubjectField = value;
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

        private string dutyGruopCodeField;
        /// <remarks/>
        public string DutyGruopCode
        {
            get
            {
                return this.dutyGruopCodeField;
            }
            set
            {
                this.dutyGruopCodeField = value;
            }
        }

        private string dutyGruopDescField;
        /// <remarks/>
        public string DutyGruopDesc
        {
            get
            {
                return this.dutyGruopDescField;
            }
            set
            {
                this.dutyGruopDescField = value;
            }
        }

        private int dutyGruopIdField;
        /// <remarks/>
        public int DutyGruopId
        {
            get
            {
                return this.dutyGruopIdField;
            }
            set
            {
                this.dutyGruopIdField = value;
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

        private int ownerIdField;
        /// <remarks/>
        public int OwnerId
        {
            get
            {
                return this.ownerIdField;
            }
            set
            {
                this.ownerIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Qty")]
        public string QtyString
        {
            get { return qtyField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyField = StringUtil.ToDecimal(value); }
        }

        private decimal qtyField;
        [System.Xml.Serialization.XmlIgnore]
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

        private string subjectCodeField;
        /// <remarks/>
        public string SubjectCode
        {
            get
            {
                return this.subjectCodeField;
            }
            set
            {
                this.subjectCodeField = value;
            }
        }

        private int subjectIdField;
        /// <remarks/>
        public int SubjectId
        {
            get
            {
                return this.subjectIdField;
            }
            set
            {
                this.subjectIdField = value;
            }
        }

        private string nameField;
        /// <remarks/>
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

        private int departmentIdField;
        /// <remarks/>
        public int DepartmentId
        {
            get
            {
                return this.departmentIdField;
            }
            set
            {
                this.departmentIdField = value;
            }
        }

        private string departmentCodeField;
        /// <remarks/>
        public string DepartmentCode
        {
            get
            {
                return this.departmentCodeField;
            }
            set
            {
                this.departmentCodeField = value;
            }
        }

        private int department2IdField;
        /// <remarks/>
        public int Department2Id
        {
            get
            {
                return this.department2IdField;
            }
            set
            {
                this.department2IdField = value;
            }
        }

        private string departmentCode2Field;
        /// <remarks/>
        public string DepartmentCode2
        {
            get
            {
                return this.departmentCode2Field;
            }
            set
            {
                this.departmentCode2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("QtyScrap")]
        public string QtyScrapString
        {
            get { return qtyScrapField.ToString(Statics.DECIMAL_STRING_FORMAT); }
            set { this.qtyScrapField = StringUtil.ToDecimal(value); }
        }

        private decimal qtyScrapField;
        [System.Xml.Serialization.XmlIgnore]
        /// <remarks/>
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

        private string wstationCodeField;
        /// <remarks/>
        public string WstationCode
        {
            get
            {
                return this.wstationCodeField;
            }
            set
            {
                this.wstationCodeField = value;
            }
        }

        private int wstationIdField;
        /// <remarks/>
        public int WstationId
        {
            get
            {
                return this.wstationIdField;
            }
            set
            {
                this.wstationIdField = value;
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

        private string personelNameField;
        /// <remarks/>
        public string PersonelName
        {
            get
            {
                return this.personelNameField;
            }
            set
            {
                this.personelNameField = value;
            }
        }

        private string personnelSurnameField;
        /// <remarks/>
        public string PersonnelSurname
        {
            get
            {
                return this.personnelSurnameField;
            }
            set
            {
                this.personnelSurnameField = value;
            }
        }

        private string descriptionField;
        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        private string description2Field;
        /// <remarks/>
        public string Description2
        {
            get
            {
                return this.description2Field;
            }
            set
            {
                this.description2Field = value;
            }
        }

        private string typeField = "QLT.DiscordReports, QLT";
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
}
