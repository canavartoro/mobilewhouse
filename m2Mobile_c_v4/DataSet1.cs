namespace m2Mobile_c_v4
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("DataSet1"), DesignerCategory("code")]
    public class DataSet1 : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        private Dt_DetaylarDataTable tableDt_Detaylar;
        private Dt_SatinAlmaDataTable tableDt_SatinAlma;

        [DebuggerNonUserCode]
        public DataSet1()
        {
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode]
        public override DataSet Clone()
        {
            DataSet1 set = (DataSet1) base.Clone();
            set.InitVars();
            set.SchemaSerializationMode = this.SchemaSerializationMode;
            return set;
        }

        [DebuggerNonUserCode]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            DataSet1 set = new DataSet1();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = set.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = set.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema) enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [DebuggerNonUserCode]
        private void InitClass()
        {
            base.DataSetName = "DataSet1";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/DataSet1.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableDt_SatinAlma = new Dt_SatinAlmaDataTable();
            base.Tables.Add(this.tableDt_SatinAlma);
            this.tableDt_Detaylar = new Dt_DetaylarDataTable();
            base.Tables.Add(this.tableDt_Detaylar);
        }

        [DebuggerNonUserCode]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tableDt_SatinAlma = (Dt_SatinAlmaDataTable) base.Tables["Dt_SatinAlma"];
            if (initTable && (this.tableDt_SatinAlma != null))
            {
                this.tableDt_SatinAlma.InitVars();
            }
            this.tableDt_Detaylar = (Dt_DetaylarDataTable) base.Tables["Dt_Detaylar"];
            if (initTable && (this.tableDt_Detaylar != null))
            {
                this.tableDt_Detaylar.InitVars();
            }
        }

        [DebuggerNonUserCode]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["Dt_SatinAlma"] != null)
                {
                    base.Tables.Add(new Dt_SatinAlmaDataTable(dataSet.Tables["Dt_SatinAlma"]));
                }
                if (dataSet.Tables["Dt_Detaylar"] != null)
                {
                    base.Tables.Add(new Dt_DetaylarDataTable(dataSet.Tables["Dt_Detaylar"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeDt_Detaylar()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeDt_SatinAlma()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode]
        public Dt_DetaylarDataTable Dt_Detaylar
        {
            get
            {
                return this.tableDt_Detaylar;
            }
        }

        [DebuggerNonUserCode]
        public Dt_SatinAlmaDataTable Dt_SatinAlma
        {
            get
            {
                return this.tableDt_SatinAlma;
            }
        }

        [DebuggerNonUserCode]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DebuggerNonUserCode]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DebuggerNonUserCode]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Dt_DetaylarDataTable : TypedTableBase<DataSet1.Dt_DetaylarRow>
        {
            private DataColumn columnDcardId;
            private DataColumn columnDty_Adı;
            private DataColumn columnDty_Kod;
            private DataColumn columnDty_RefNo;
            private DataColumn columnOk_Miktarı;
            private DataColumn columnSip_Kal_Mik;
            private DataColumn columnSip_Sevk_Miktarı;
            private DataColumn columnStk_Adı;
            private DataColumn columnStk_Kod;

            public event DataSet1.Dt_DetaylarRowChangeEventHandler Dt_DetaylarRowChanged;

            public event DataSet1.Dt_DetaylarRowChangeEventHandler Dt_DetaylarRowChanging;

            public event DataSet1.Dt_DetaylarRowChangeEventHandler Dt_DetaylarRowDeleted;

            public event DataSet1.Dt_DetaylarRowChangeEventHandler Dt_DetaylarRowDeleting;

            [DebuggerNonUserCode]
            public Dt_DetaylarDataTable()
            {
                base.TableName = "Dt_Detaylar";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal Dt_DetaylarDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            public void AddDt_DetaylarRow(DataSet1.Dt_DetaylarRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_DetaylarRow AddDt_DetaylarRow(string Dty_Kod, string Stk_Kod, string Stk_Adı, string Sip_Sevk_Miktarı, string Sip_Kal_Mik, string Ok_Miktarı, string Dty_RefNo, string DcardId, string Dty_Adı)
            {
                DataSet1.Dt_DetaylarRow row = (DataSet1.Dt_DetaylarRow) base.NewRow();
                row.ItemArray = new object[] { Dty_Kod, Stk_Kod, Stk_Adı, Sip_Sevk_Miktarı, Sip_Kal_Mik, Ok_Miktarı, Dty_RefNo, DcardId, Dty_Adı };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DataSet1.Dt_DetaylarDataTable table = (DataSet1.Dt_DetaylarDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DataSet1.Dt_DetaylarDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DataSet1.Dt_DetaylarRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DataSet1 set = new DataSet1();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "Dt_DetaylarDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnDty_Kod = new DataColumn("Dty_Kod", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDty_Kod);
                this.columnStk_Kod = new DataColumn("Stk_Kod", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStk_Kod);
                this.columnStk_Adı = new DataColumn("Stk_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStk_Adı);
                this.columnSip_Sevk_Miktarı = new DataColumn("Sip_Sevk_Miktarı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSip_Sevk_Miktarı);
                this.columnSip_Kal_Mik = new DataColumn("Sip_Kal_Mik", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSip_Kal_Mik);
                this.columnOk_Miktarı = new DataColumn("Ok_Miktarı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOk_Miktarı);
                this.columnDty_RefNo = new DataColumn("Dty_RefNo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDty_RefNo);
                this.columnDcardId = new DataColumn("DcardId", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDcardId);
                this.columnDty_Adı = new DataColumn("Dty_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDty_Adı);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnDty_Kod = base.Columns["Dty_Kod"];
                this.columnStk_Kod = base.Columns["Stk_Kod"];
                this.columnStk_Adı = base.Columns["Stk_Adı"];
                this.columnSip_Sevk_Miktarı = base.Columns["Sip_Sevk_Miktarı"];
                this.columnSip_Kal_Mik = base.Columns["Sip_Kal_Mik"];
                this.columnOk_Miktarı = base.Columns["Ok_Miktarı"];
                this.columnDty_RefNo = base.Columns["Dty_RefNo"];
                this.columnDcardId = base.Columns["DcardId"];
                this.columnDty_Adı = base.Columns["Dty_Adı"];
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_DetaylarRow NewDt_DetaylarRow()
            {
                return (DataSet1.Dt_DetaylarRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataSet1.Dt_DetaylarRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Dt_DetaylarRowChanged != null)
                {
                    this.Dt_DetaylarRowChanged(this, new DataSet1.Dt_DetaylarRowChangeEvent((DataSet1.Dt_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Dt_DetaylarRowChanging != null)
                {
                    this.Dt_DetaylarRowChanging(this, new DataSet1.Dt_DetaylarRowChangeEvent((DataSet1.Dt_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Dt_DetaylarRowDeleted != null)
                {
                    this.Dt_DetaylarRowDeleted(this, new DataSet1.Dt_DetaylarRowChangeEvent((DataSet1.Dt_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Dt_DetaylarRowDeleting != null)
                {
                    this.Dt_DetaylarRowDeleting(this, new DataSet1.Dt_DetaylarRowChangeEvent((DataSet1.Dt_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveDt_DetaylarRow(DataSet1.Dt_DetaylarRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DcardIdColumn
            {
                get
                {
                    return this.columnDcardId;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Dty_AdıColumn
            {
                get
                {
                    return this.columnDty_Adı;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Dty_KodColumn
            {
                get
                {
                    return this.columnDty_Kod;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Dty_RefNoColumn
            {
                get
                {
                    return this.columnDty_RefNo;
                }
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_DetaylarRow this[int index]
            {
                get
                {
                    return (DataSet1.Dt_DetaylarRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Ok_MiktarıColumn
            {
                get
                {
                    return this.columnOk_Miktarı;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Sip_Kal_MikColumn
            {
                get
                {
                    return this.columnSip_Kal_Mik;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Sip_Sevk_MiktarıColumn
            {
                get
                {
                    return this.columnSip_Sevk_Miktarı;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Stk_AdıColumn
            {
                get
                {
                    return this.columnStk_Adı;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Stk_KodColumn
            {
                get
                {
                    return this.columnStk_Kod;
                }
            }
        }

        public class Dt_DetaylarRow : DataRow
        {
            private DataSet1.Dt_DetaylarDataTable tableDt_Detaylar;

            [DebuggerNonUserCode]
            internal Dt_DetaylarRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDt_Detaylar = (DataSet1.Dt_DetaylarDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsDcardIdNull()
            {
                return base.IsNull(this.tableDt_Detaylar.DcardIdColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDty_AdıNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Dty_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDty_KodNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Dty_KodColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDty_RefNoNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Dty_RefNoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsOk_MiktarıNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Ok_MiktarıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsSip_Kal_MikNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Sip_Kal_MikColumn);
            }

            [DebuggerNonUserCode]
            public bool IsSip_Sevk_MiktarıNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Sip_Sevk_MiktarıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStk_AdıNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Stk_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStk_KodNull()
            {
                return base.IsNull(this.tableDt_Detaylar.Stk_KodColumn);
            }

            [DebuggerNonUserCode]
            public void SetDcardIdNull()
            {
                base[this.tableDt_Detaylar.DcardIdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDty_AdıNull()
            {
                base[this.tableDt_Detaylar.Dty_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDty_KodNull()
            {
                base[this.tableDt_Detaylar.Dty_KodColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDty_RefNoNull()
            {
                base[this.tableDt_Detaylar.Dty_RefNoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetOk_MiktarıNull()
            {
                base[this.tableDt_Detaylar.Ok_MiktarıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetSip_Kal_MikNull()
            {
                base[this.tableDt_Detaylar.Sip_Kal_MikColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetSip_Sevk_MiktarıNull()
            {
                base[this.tableDt_Detaylar.Sip_Sevk_MiktarıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStk_AdıNull()
            {
                base[this.tableDt_Detaylar.Stk_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStk_KodNull()
            {
                base[this.tableDt_Detaylar.Stk_KodColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string DcardId
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.DcardIdColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DcardId' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.DcardIdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Dty_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Dty_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Dty_Adı' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Dty_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Dty_Kod
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Dty_KodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Dty_Kod' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Dty_KodColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Dty_RefNo
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Dty_RefNoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Dty_RefNo' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Dty_RefNoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Ok_Miktarı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Ok_MiktarıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Ok_Miktarı' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Ok_MiktarıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Sip_Kal_Mik
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Sip_Kal_MikColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sip_Kal_Mik' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Sip_Kal_MikColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Sip_Sevk_Miktarı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Sip_Sevk_MiktarıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sip_Sevk_Miktarı' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Sip_Sevk_MiktarıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Stk_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Stk_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stk_Adı' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Stk_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Stk_Kod
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Detaylar.Stk_KodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stk_Kod' in table 'Dt_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Detaylar.Stk_KodColumn] = value;
                }
            }
        }

        public class Dt_DetaylarRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataSet1.Dt_DetaylarRow eventRow;

            [DebuggerNonUserCode]
            public Dt_DetaylarRowChangeEvent(DataSet1.Dt_DetaylarRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_DetaylarRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void Dt_DetaylarRowChangeEventHandler(object sender, DataSet1.Dt_DetaylarRowChangeEvent e);

        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Dt_SatinAlmaDataTable : TypedTableBase<DataSet1.Dt_SatinAlmaRow>
        {
            private DataColumn columnCari_Adı;
            private DataColumn columnDocTraId;
            private DataColumn columnHareket_Tar;
            private DataColumn columnRefNo;
            private DataColumn columnSat_Temsilcisi;
            private DataColumn columnSip_No;
            private DataColumn columnSip_Tar;
            private DataColumn columnTeslim_Tar;

            public event DataSet1.Dt_SatinAlmaRowChangeEventHandler Dt_SatinAlmaRowChanged;

            public event DataSet1.Dt_SatinAlmaRowChangeEventHandler Dt_SatinAlmaRowChanging;

            public event DataSet1.Dt_SatinAlmaRowChangeEventHandler Dt_SatinAlmaRowDeleted;

            public event DataSet1.Dt_SatinAlmaRowChangeEventHandler Dt_SatinAlmaRowDeleting;

            [DebuggerNonUserCode]
            public Dt_SatinAlmaDataTable()
            {
                base.TableName = "Dt_SatinAlma";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal Dt_SatinAlmaDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            public void AddDt_SatinAlmaRow(DataSet1.Dt_SatinAlmaRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_SatinAlmaRow AddDt_SatinAlmaRow(string Sip_Tar, string Sip_No, string Cari_Adı, string Hareket_Tar, string Sat_Temsilcisi, string Teslim_Tar, string RefNo, string DocTraId)
            {
                DataSet1.Dt_SatinAlmaRow row = (DataSet1.Dt_SatinAlmaRow) base.NewRow();
                row.ItemArray = new object[] { Sip_Tar, Sip_No, Cari_Adı, Hareket_Tar, Sat_Temsilcisi, Teslim_Tar, RefNo, DocTraId };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DataSet1.Dt_SatinAlmaDataTable table = (DataSet1.Dt_SatinAlmaDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DataSet1.Dt_SatinAlmaDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DataSet1.Dt_SatinAlmaRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DataSet1 set = new DataSet1();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "Dt_SatinAlmaDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnSip_Tar = new DataColumn("Sip_Tar", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSip_Tar);
                this.columnSip_No = new DataColumn("Sip_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSip_No);
                this.columnCari_Adı = new DataColumn("Cari_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCari_Adı);
                this.columnHareket_Tar = new DataColumn("Hareket_Tar", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnHareket_Tar);
                this.columnSat_Temsilcisi = new DataColumn("Sat_Temsilcisi", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSat_Temsilcisi);
                this.columnTeslim_Tar = new DataColumn("Teslim_Tar", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTeslim_Tar);
                this.columnRefNo = new DataColumn("RefNo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRefNo);
                this.columnDocTraId = new DataColumn("DocTraId", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDocTraId);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnSip_Tar = base.Columns["Sip_Tar"];
                this.columnSip_No = base.Columns["Sip_No"];
                this.columnCari_Adı = base.Columns["Cari_Adı"];
                this.columnHareket_Tar = base.Columns["Hareket_Tar"];
                this.columnSat_Temsilcisi = base.Columns["Sat_Temsilcisi"];
                this.columnTeslim_Tar = base.Columns["Teslim_Tar"];
                this.columnRefNo = base.Columns["RefNo"];
                this.columnDocTraId = base.Columns["DocTraId"];
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_SatinAlmaRow NewDt_SatinAlmaRow()
            {
                return (DataSet1.Dt_SatinAlmaRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataSet1.Dt_SatinAlmaRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Dt_SatinAlmaRowChanged != null)
                {
                    this.Dt_SatinAlmaRowChanged(this, new DataSet1.Dt_SatinAlmaRowChangeEvent((DataSet1.Dt_SatinAlmaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Dt_SatinAlmaRowChanging != null)
                {
                    this.Dt_SatinAlmaRowChanging(this, new DataSet1.Dt_SatinAlmaRowChangeEvent((DataSet1.Dt_SatinAlmaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Dt_SatinAlmaRowDeleted != null)
                {
                    this.Dt_SatinAlmaRowDeleted(this, new DataSet1.Dt_SatinAlmaRowChangeEvent((DataSet1.Dt_SatinAlmaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Dt_SatinAlmaRowDeleting != null)
                {
                    this.Dt_SatinAlmaRowDeleting(this, new DataSet1.Dt_SatinAlmaRowChangeEvent((DataSet1.Dt_SatinAlmaRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveDt_SatinAlmaRow(DataSet1.Dt_SatinAlmaRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn Cari_AdıColumn
            {
                get
                {
                    return this.columnCari_Adı;
                }
            }

            [DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DocTraIdColumn
            {
                get
                {
                    return this.columnDocTraId;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Hareket_TarColumn
            {
                get
                {
                    return this.columnHareket_Tar;
                }
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_SatinAlmaRow this[int index]
            {
                get
                {
                    return (DataSet1.Dt_SatinAlmaRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn RefNoColumn
            {
                get
                {
                    return this.columnRefNo;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Sat_TemsilcisiColumn
            {
                get
                {
                    return this.columnSat_Temsilcisi;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Sip_NoColumn
            {
                get
                {
                    return this.columnSip_No;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Sip_TarColumn
            {
                get
                {
                    return this.columnSip_Tar;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Teslim_TarColumn
            {
                get
                {
                    return this.columnTeslim_Tar;
                }
            }
        }

        public class Dt_SatinAlmaRow : DataRow
        {
            private DataSet1.Dt_SatinAlmaDataTable tableDt_SatinAlma;

            [DebuggerNonUserCode]
            internal Dt_SatinAlmaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDt_SatinAlma = (DataSet1.Dt_SatinAlmaDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsCari_AdıNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.Cari_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDocTraIdNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.DocTraIdColumn);
            }

            [DebuggerNonUserCode]
            public bool IsHareket_TarNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.Hareket_TarColumn);
            }

            [DebuggerNonUserCode]
            public bool IsRefNoNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.RefNoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsSat_TemsilcisiNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.Sat_TemsilcisiColumn);
            }

            [DebuggerNonUserCode]
            public bool IsSip_NoNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.Sip_NoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsSip_TarNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.Sip_TarColumn);
            }

            [DebuggerNonUserCode]
            public bool IsTeslim_TarNull()
            {
                return base.IsNull(this.tableDt_SatinAlma.Teslim_TarColumn);
            }

            [DebuggerNonUserCode]
            public void SetCari_AdıNull()
            {
                base[this.tableDt_SatinAlma.Cari_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDocTraIdNull()
            {
                base[this.tableDt_SatinAlma.DocTraIdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetHareket_TarNull()
            {
                base[this.tableDt_SatinAlma.Hareket_TarColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetRefNoNull()
            {
                base[this.tableDt_SatinAlma.RefNoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetSat_TemsilcisiNull()
            {
                base[this.tableDt_SatinAlma.Sat_TemsilcisiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetSip_NoNull()
            {
                base[this.tableDt_SatinAlma.Sip_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetSip_TarNull()
            {
                base[this.tableDt_SatinAlma.Sip_TarColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetTeslim_TarNull()
            {
                base[this.tableDt_SatinAlma.Teslim_TarColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Cari_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.Cari_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Cari_Adı' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.Cari_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string DocTraId
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.DocTraIdColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DocTraId' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.DocTraIdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Hareket_Tar
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.Hareket_TarColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Hareket_Tar' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.Hareket_TarColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string RefNo
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.RefNoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'RefNo' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.RefNoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Sat_Temsilcisi
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.Sat_TemsilcisiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sat_Temsilcisi' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.Sat_TemsilcisiColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Sip_No
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.Sip_NoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sip_No' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.Sip_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Sip_Tar
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.Sip_TarColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sip_Tar' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.Sip_TarColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Teslim_Tar
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_SatinAlma.Teslim_TarColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Teslim_Tar' in table 'Dt_SatinAlma' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_SatinAlma.Teslim_TarColumn] = value;
                }
            }
        }

        public class Dt_SatinAlmaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataSet1.Dt_SatinAlmaRow eventRow;

            [DebuggerNonUserCode]
            public Dt_SatinAlmaRowChangeEvent(DataSet1.Dt_SatinAlmaRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode]
            public DataSet1.Dt_SatinAlmaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void Dt_SatinAlmaRowChangeEventHandler(object sender, DataSet1.Dt_SatinAlmaRowChangeEvent e);
    }
}

