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
    public class FreeBreakWorder : BaseModel
    {
        public FreeBreakWorder() { }

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
            get { return this.startDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.startDateField = StringUtil.ToDatetime(value); }
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
            get { return this.endDateField.ToString("dd.MM.yyyy HH:mm:ss"); }
            set { this.endDateField = StringUtil.ToDatetime(value); }
        }

        private int netTimeField;
        /// <remarks/>
        public int NetTime
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

        private string noteLarge1Field;
        /// <remarks/>
        public string NoteLarge1
        {
            get
            {
                return this.noteLarge1Field;
            }
            set
            {
                this.noteLarge1Field = value;
            }
        }

        private string noteLarge2Field;
        /// <remarks/>
        public string NoteLarge2
        {
            get
            {
                return this.noteLarge2Field;
            }
            set
            {
                this.noteLarge2Field = value;
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

        private int shiftsIdField;
        /// <remarks/>
        public int ShiftsId
        {
            get
            {
                return this.shiftsIdField;
            }
            set
            {
                this.shiftsIdField = value;
            }
        }

        private string shiftCodeField;
        /// <remarks/>
        public string ShiftCode
        {
            get
            {
                return this.shiftCodeField;
            }
            set
            {
                this.shiftCodeField = value;
            }
        }

        private int breakReasonIdField;
        /// <remarks/>
        public int BreakReasonId
        {
            get
            {
                return this.breakReasonIdField;
            }
            set
            {
                this.breakReasonIdField = value;
            }
        }

        private string breakReasonCodeField;
        /// <remarks/>
        public string BreakReasonCode
        {
            get
            {
                return this.breakReasonCodeField;
            }
            set
            {
                this.breakReasonCodeField = value;
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

        private string typeField = "PRD.FreeBreakWorder, PRD";
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
