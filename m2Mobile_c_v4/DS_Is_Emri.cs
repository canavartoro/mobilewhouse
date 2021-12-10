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

    [XmlRoot("DS_Is_Emri"), XmlSchemaProvider("GetTypedDataSetSchema"), DesignerCategory("code")]
    public class DS_Is_Emri : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        private Dt_Isemri_DetaylarıDataTable tableDt_Isemri_Detayları;
        private Dt_Onaylı_Is_EmriDataTable tableDt_Onaylı_Is_Emri;

        [DebuggerNonUserCode]
        public DS_Is_Emri()
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
            DS_Is_Emri emri = (DS_Is_Emri) base.Clone();
            emri.InitVars();
            emri.SchemaSerializationMode = this.SchemaSerializationMode;
            return emri;
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
            DS_Is_Emri emri = new DS_Is_Emri();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = emri.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = emri.GetSchemaSerializable();
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
            base.DataSetName = "DS_Is_Emri";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/DS_Is_Emri.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableDt_Onaylı_Is_Emri = new Dt_Onaylı_Is_EmriDataTable();
            base.Tables.Add(this.tableDt_Onaylı_Is_Emri);
            this.tableDt_Isemri_Detayları = new Dt_Isemri_DetaylarıDataTable();
            base.Tables.Add(this.tableDt_Isemri_Detayları);
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
            this.tableDt_Onaylı_Is_Emri = (Dt_Onaylı_Is_EmriDataTable) base.Tables["Dt_Onaylı_Is_Emri"];
            if (initTable && (this.tableDt_Onaylı_Is_Emri != null))
            {
                this.tableDt_Onaylı_Is_Emri.InitVars();
            }
            this.tableDt_Isemri_Detayları = (Dt_Isemri_DetaylarıDataTable) base.Tables["Dt_Isemri_Detayları"];
            if (initTable && (this.tableDt_Isemri_Detayları != null))
            {
                this.tableDt_Isemri_Detayları.InitVars();
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
                if (dataSet.Tables["Dt_Onaylı_Is_Emri"] != null)
                {
                    base.Tables.Add(new Dt_Onaylı_Is_EmriDataTable(dataSet.Tables["Dt_Onaylı_Is_Emri"]));
                }
                if (dataSet.Tables["Dt_Isemri_Detayları"] != null)
                {
                    base.Tables.Add(new Dt_Isemri_DetaylarıDataTable(dataSet.Tables["Dt_Isemri_Detayları"]));
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
        private bool ShouldSerializeDt_Isemri_Detayları()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeDt_Onaylı_Is_Emri()
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
        public Dt_Isemri_DetaylarıDataTable Dt_Isemri_Detayları
        {
            get
            {
                return this.tableDt_Isemri_Detayları;
            }
        }

        [DebuggerNonUserCode]
        public Dt_Onaylı_Is_EmriDataTable Dt_Onaylı_Is_Emri
        {
            get
            {
                return this.tableDt_Onaylı_Is_Emri;
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
        public class Dt_Isemri_DetaylarıDataTable : TypedTableBase<DS_Is_Emri.Dt_Isemri_DetaylarıRow>
        {
            private DataColumn columnNet_Miktar;
            private DataColumn columnOk_Miktar;
            private DataColumn columnStok_Adı;
            private DataColumn columnStok_Kodu;
            private DataColumn columnTip;

            public event DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEventHandler Dt_Isemri_DetaylarıRowChanged;

            public event DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEventHandler Dt_Isemri_DetaylarıRowChanging;

            public event DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEventHandler Dt_Isemri_DetaylarıRowDeleted;

            public event DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEventHandler Dt_Isemri_DetaylarıRowDeleting;

            [DebuggerNonUserCode]
            public Dt_Isemri_DetaylarıDataTable()
            {
                base.TableName = "Dt_Isemri_Detayları";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal Dt_Isemri_DetaylarıDataTable(DataTable table)
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
            public void AddDt_Isemri_DetaylarıRow(DS_Is_Emri.Dt_Isemri_DetaylarıRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public DS_Is_Emri.Dt_Isemri_DetaylarıRow AddDt_Isemri_DetaylarıRow(string Stok_Adı, string Stok_Kodu, string Net_Miktar, string Ok_Miktar, string Tip)
            {
                DS_Is_Emri.Dt_Isemri_DetaylarıRow row = (DS_Is_Emri.Dt_Isemri_DetaylarıRow) base.NewRow();
                row.ItemArray = new object[] { Stok_Adı, Stok_Kodu, Net_Miktar, Ok_Miktar, Tip };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DS_Is_Emri.Dt_Isemri_DetaylarıDataTable table = (DS_Is_Emri.Dt_Isemri_DetaylarıDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DS_Is_Emri.Dt_Isemri_DetaylarıDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DS_Is_Emri.Dt_Isemri_DetaylarıRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DS_Is_Emri emri = new DS_Is_Emri();
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
                    FixedValue = emri.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "Dt_Isemri_DetaylarıDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = emri.GetSchemaSerializable();
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
                this.columnStok_Adı = new DataColumn("Stok_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStok_Adı);
                this.columnStok_Kodu = new DataColumn("Stok_Kodu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStok_Kodu);
                this.columnNet_Miktar = new DataColumn("Net_Miktar", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNet_Miktar);
                this.columnOk_Miktar = new DataColumn("Ok_Miktar", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOk_Miktar);
                this.columnTip = new DataColumn("Tip", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTip);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnStok_Adı = base.Columns["Stok_Adı"];
                this.columnStok_Kodu = base.Columns["Stok_Kodu"];
                this.columnNet_Miktar = base.Columns["Net_Miktar"];
                this.columnOk_Miktar = base.Columns["Ok_Miktar"];
                this.columnTip = base.Columns["Tip"];
            }

            [DebuggerNonUserCode]
            public DS_Is_Emri.Dt_Isemri_DetaylarıRow NewDt_Isemri_DetaylarıRow()
            {
                return (DS_Is_Emri.Dt_Isemri_DetaylarıRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DS_Is_Emri.Dt_Isemri_DetaylarıRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Dt_Isemri_DetaylarıRowChanged != null)
                {
                    this.Dt_Isemri_DetaylarıRowChanged(this, new DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEvent((DS_Is_Emri.Dt_Isemri_DetaylarıRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Dt_Isemri_DetaylarıRowChanging != null)
                {
                    this.Dt_Isemri_DetaylarıRowChanging(this, new DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEvent((DS_Is_Emri.Dt_Isemri_DetaylarıRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Dt_Isemri_DetaylarıRowDeleted != null)
                {
                    this.Dt_Isemri_DetaylarıRowDeleted(this, new DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEvent((DS_Is_Emri.Dt_Isemri_DetaylarıRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Dt_Isemri_DetaylarıRowDeleting != null)
                {
                    this.Dt_Isemri_DetaylarıRowDeleting(this, new DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEvent((DS_Is_Emri.Dt_Isemri_DetaylarıRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveDt_Isemri_DetaylarıRow(DS_Is_Emri.Dt_Isemri_DetaylarıRow row)
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
            public DS_Is_Emri.Dt_Isemri_DetaylarıRow this[int index]
            {
                get
                {
                    return (DS_Is_Emri.Dt_Isemri_DetaylarıRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Net_MiktarColumn
            {
                get
                {
                    return this.columnNet_Miktar;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Ok_MiktarColumn
            {
                get
                {
                    return this.columnOk_Miktar;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Stok_AdıColumn
            {
                get
                {
                    return this.columnStok_Adı;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Stok_KoduColumn
            {
                get
                {
                    return this.columnStok_Kodu;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn TipColumn
            {
                get
                {
                    return this.columnTip;
                }
            }
        }

        public class Dt_Isemri_DetaylarıRow : DataRow
        {
            private DS_Is_Emri.Dt_Isemri_DetaylarıDataTable tableDt_Isemri_Detayları;

            [DebuggerNonUserCode]
            internal Dt_Isemri_DetaylarıRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDt_Isemri_Detayları = (DS_Is_Emri.Dt_Isemri_DetaylarıDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsNet_MiktarNull()
            {
                return base.IsNull(this.tableDt_Isemri_Detayları.Net_MiktarColumn);
            }

            [DebuggerNonUserCode]
            public bool IsOk_MiktarNull()
            {
                return base.IsNull(this.tableDt_Isemri_Detayları.Ok_MiktarColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStok_AdıNull()
            {
                return base.IsNull(this.tableDt_Isemri_Detayları.Stok_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStok_KoduNull()
            {
                return base.IsNull(this.tableDt_Isemri_Detayları.Stok_KoduColumn);
            }

            [DebuggerNonUserCode]
            public bool IsTipNull()
            {
                return base.IsNull(this.tableDt_Isemri_Detayları.TipColumn);
            }

            [DebuggerNonUserCode]
            public void SetNet_MiktarNull()
            {
                base[this.tableDt_Isemri_Detayları.Net_MiktarColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetOk_MiktarNull()
            {
                base[this.tableDt_Isemri_Detayları.Ok_MiktarColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStok_AdıNull()
            {
                base[this.tableDt_Isemri_Detayları.Stok_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStok_KoduNull()
            {
                base[this.tableDt_Isemri_Detayları.Stok_KoduColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetTipNull()
            {
                base[this.tableDt_Isemri_Detayları.TipColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Net_Miktar
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Isemri_Detayları.Net_MiktarColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Net_Miktar' in table 'Dt_Isemri_Detayları' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Isemri_Detayları.Net_MiktarColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Ok_Miktar
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Isemri_Detayları.Ok_MiktarColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Ok_Miktar' in table 'Dt_Isemri_Detayları' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Isemri_Detayları.Ok_MiktarColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Stok_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Isemri_Detayları.Stok_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stok_Adı' in table 'Dt_Isemri_Detayları' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Isemri_Detayları.Stok_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Stok_Kodu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Isemri_Detayları.Stok_KoduColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stok_Kodu' in table 'Dt_Isemri_Detayları' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Isemri_Detayları.Stok_KoduColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Tip
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Isemri_Detayları.TipColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Tip' in table 'Dt_Isemri_Detayları' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Isemri_Detayları.TipColumn] = value;
                }
            }
        }

        public class Dt_Isemri_DetaylarıRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DS_Is_Emri.Dt_Isemri_DetaylarıRow eventRow;

            [DebuggerNonUserCode]
            public Dt_Isemri_DetaylarıRowChangeEvent(DS_Is_Emri.Dt_Isemri_DetaylarıRow row, DataRowAction action)
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
            public DS_Is_Emri.Dt_Isemri_DetaylarıRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void Dt_Isemri_DetaylarıRowChangeEventHandler(object sender, DS_Is_Emri.Dt_Isemri_DetaylarıRowChangeEvent e);

        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Dt_Onaylı_Is_EmriDataTable : TypedTableBase<DS_Is_Emri.Dt_Onaylı_Is_EmriRow>
        {
            private DataColumn columnDataColumn2;
            private DataColumn columnDataColumn3;
            private DataColumn columnDataColumn4;
            private DataColumn columnDataColumn5;
            private DataColumn columnId;
            private DataColumn columnIsEmri_No;
            private DataColumn columnIsEmri_Tar;
            private DataColumn columnIsEmri_Tipi;
            private DataColumn columnRota_Op_Adı;
            private DataColumn columnStk_Adı;
            private DataColumn columnStk_Kod;

            public event DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEventHandler Dt_Onaylı_Is_EmriRowChanged;

            public event DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEventHandler Dt_Onaylı_Is_EmriRowChanging;

            public event DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEventHandler Dt_Onaylı_Is_EmriRowDeleted;

            public event DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEventHandler Dt_Onaylı_Is_EmriRowDeleting;

            [DebuggerNonUserCode]
            public Dt_Onaylı_Is_EmriDataTable()
            {
                base.TableName = "Dt_Onaylı_Is_Emri";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal Dt_Onaylı_Is_EmriDataTable(DataTable table)
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
            public void AddDt_Onaylı_Is_EmriRow(DS_Is_Emri.Dt_Onaylı_Is_EmriRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public DS_Is_Emri.Dt_Onaylı_Is_EmriRow AddDt_Onaylı_Is_EmriRow(string IsEmri_Tar, string IsEmri_No, string IsEmri_Tipi, string Stk_Kod, string Stk_Adı, string Rota_Op_Adı, string Id, string DataColumn2, string DataColumn3, string DataColumn4, string DataColumn5)
            {
                DS_Is_Emri.Dt_Onaylı_Is_EmriRow row = (DS_Is_Emri.Dt_Onaylı_Is_EmriRow) base.NewRow();
                row.ItemArray = new object[] { IsEmri_Tar, IsEmri_No, IsEmri_Tipi, Stk_Kod, Stk_Adı, Rota_Op_Adı, Id, DataColumn2, DataColumn3, DataColumn4, DataColumn5 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DS_Is_Emri.Dt_Onaylı_Is_EmriDataTable table = (DS_Is_Emri.Dt_Onaylı_Is_EmriDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DS_Is_Emri.Dt_Onaylı_Is_EmriDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DS_Is_Emri.Dt_Onaylı_Is_EmriRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DS_Is_Emri emri = new DS_Is_Emri();
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
                    FixedValue = emri.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "Dt_Onaylı_Is_EmriDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = emri.GetSchemaSerializable();
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
                this.columnIsEmri_Tar = new DataColumn("IsEmri_Tar", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIsEmri_Tar);
                this.columnIsEmri_No = new DataColumn("IsEmri_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIsEmri_No);
                this.columnIsEmri_Tipi = new DataColumn("IsEmri_Tipi", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIsEmri_Tipi);
                this.columnStk_Kod = new DataColumn("Stk_Kod", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStk_Kod);
                this.columnStk_Adı = new DataColumn("Stk_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStk_Adı);
                this.columnRota_Op_Adı = new DataColumn("Rota_Op_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRota_Op_Adı);
                this.columnId = new DataColumn("Id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnId);
                this.columnDataColumn2 = new DataColumn("DataColumn2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDataColumn2);
                this.columnDataColumn3 = new DataColumn("DataColumn3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDataColumn3);
                this.columnDataColumn4 = new DataColumn("DataColumn4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDataColumn4);
                this.columnDataColumn5 = new DataColumn("DataColumn5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDataColumn5);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnIsEmri_Tar = base.Columns["IsEmri_Tar"];
                this.columnIsEmri_No = base.Columns["IsEmri_No"];
                this.columnIsEmri_Tipi = base.Columns["IsEmri_Tipi"];
                this.columnStk_Kod = base.Columns["Stk_Kod"];
                this.columnStk_Adı = base.Columns["Stk_Adı"];
                this.columnRota_Op_Adı = base.Columns["Rota_Op_Adı"];
                this.columnId = base.Columns["Id"];
                this.columnDataColumn2 = base.Columns["DataColumn2"];
                this.columnDataColumn3 = base.Columns["DataColumn3"];
                this.columnDataColumn4 = base.Columns["DataColumn4"];
                this.columnDataColumn5 = base.Columns["DataColumn5"];
            }

            [DebuggerNonUserCode]
            public DS_Is_Emri.Dt_Onaylı_Is_EmriRow NewDt_Onaylı_Is_EmriRow()
            {
                return (DS_Is_Emri.Dt_Onaylı_Is_EmriRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DS_Is_Emri.Dt_Onaylı_Is_EmriRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Dt_Onaylı_Is_EmriRowChanged != null)
                {
                    this.Dt_Onaylı_Is_EmriRowChanged(this, new DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEvent((DS_Is_Emri.Dt_Onaylı_Is_EmriRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Dt_Onaylı_Is_EmriRowChanging != null)
                {
                    this.Dt_Onaylı_Is_EmriRowChanging(this, new DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEvent((DS_Is_Emri.Dt_Onaylı_Is_EmriRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Dt_Onaylı_Is_EmriRowDeleted != null)
                {
                    this.Dt_Onaylı_Is_EmriRowDeleted(this, new DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEvent((DS_Is_Emri.Dt_Onaylı_Is_EmriRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Dt_Onaylı_Is_EmriRowDeleting != null)
                {
                    this.Dt_Onaylı_Is_EmriRowDeleting(this, new DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEvent((DS_Is_Emri.Dt_Onaylı_Is_EmriRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveDt_Onaylı_Is_EmriRow(DS_Is_Emri.Dt_Onaylı_Is_EmriRow row)
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
            public DataColumn DataColumn2Column
            {
                get
                {
                    return this.columnDataColumn2;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DataColumn3Column
            {
                get
                {
                    return this.columnDataColumn3;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DataColumn4Column
            {
                get
                {
                    return this.columnDataColumn4;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn DataColumn5Column
            {
                get
                {
                    return this.columnDataColumn5;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IdColumn
            {
                get
                {
                    return this.columnId;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsEmri_NoColumn
            {
                get
                {
                    return this.columnIsEmri_No;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsEmri_TarColumn
            {
                get
                {
                    return this.columnIsEmri_Tar;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsEmri_TipiColumn
            {
                get
                {
                    return this.columnIsEmri_Tipi;
                }
            }

            [DebuggerNonUserCode]
            public DS_Is_Emri.Dt_Onaylı_Is_EmriRow this[int index]
            {
                get
                {
                    return (DS_Is_Emri.Dt_Onaylı_Is_EmriRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Rota_Op_AdıColumn
            {
                get
                {
                    return this.columnRota_Op_Adı;
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

        public class Dt_Onaylı_Is_EmriRow : DataRow
        {
            private DS_Is_Emri.Dt_Onaylı_Is_EmriDataTable tableDt_Onaylı_Is_Emri;

            [DebuggerNonUserCode]
            internal Dt_Onaylı_Is_EmriRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDt_Onaylı_Is_Emri = (DS_Is_Emri.Dt_Onaylı_Is_EmriDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsDataColumn2Null()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.DataColumn2Column);
            }

            [DebuggerNonUserCode]
            public bool IsDataColumn3Null()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.DataColumn3Column);
            }

            [DebuggerNonUserCode]
            public bool IsDataColumn4Null()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.DataColumn4Column);
            }

            [DebuggerNonUserCode]
            public bool IsDataColumn5Null()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.DataColumn5Column);
            }

            [DebuggerNonUserCode]
            public bool IsIdNull()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.IdColumn);
            }

            [DebuggerNonUserCode]
            public bool IsIsEmri_NoNull()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.IsEmri_NoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsIsEmri_TarNull()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.IsEmri_TarColumn);
            }

            [DebuggerNonUserCode]
            public bool IsIsEmri_TipiNull()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.IsEmri_TipiColumn);
            }

            [DebuggerNonUserCode]
            public bool IsRota_Op_AdıNull()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.Rota_Op_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStk_AdıNull()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.Stk_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStk_KodNull()
            {
                return base.IsNull(this.tableDt_Onaylı_Is_Emri.Stk_KodColumn);
            }

            [DebuggerNonUserCode]
            public void SetDataColumn2Null()
            {
                base[this.tableDt_Onaylı_Is_Emri.DataColumn2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDataColumn3Null()
            {
                base[this.tableDt_Onaylı_Is_Emri.DataColumn3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDataColumn4Null()
            {
                base[this.tableDt_Onaylı_Is_Emri.DataColumn4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDataColumn5Null()
            {
                base[this.tableDt_Onaylı_Is_Emri.DataColumn5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetIdNull()
            {
                base[this.tableDt_Onaylı_Is_Emri.IdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetIsEmri_NoNull()
            {
                base[this.tableDt_Onaylı_Is_Emri.IsEmri_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetIsEmri_TarNull()
            {
                base[this.tableDt_Onaylı_Is_Emri.IsEmri_TarColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetIsEmri_TipiNull()
            {
                base[this.tableDt_Onaylı_Is_Emri.IsEmri_TipiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetRota_Op_AdıNull()
            {
                base[this.tableDt_Onaylı_Is_Emri.Rota_Op_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStk_AdıNull()
            {
                base[this.tableDt_Onaylı_Is_Emri.Stk_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStk_KodNull()
            {
                base[this.tableDt_Onaylı_Is_Emri.Stk_KodColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string DataColumn2
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.DataColumn2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DataColumn2' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.DataColumn2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string DataColumn3
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.DataColumn3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DataColumn3' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.DataColumn3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string DataColumn4
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.DataColumn4Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DataColumn4' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.DataColumn4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string DataColumn5
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.DataColumn5Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DataColumn5' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.DataColumn5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Id
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.IdColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Id' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.IdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IsEmri_No
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.IsEmri_NoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'IsEmri_No' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.IsEmri_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IsEmri_Tar
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.IsEmri_TarColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'IsEmri_Tar' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.IsEmri_TarColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string IsEmri_Tipi
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.IsEmri_TipiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'IsEmri_Tipi' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.IsEmri_TipiColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Rota_Op_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.Rota_Op_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Rota_Op_Adı' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.Rota_Op_AdıColumn] = value;
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
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.Stk_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stk_Adı' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.Stk_AdıColumn] = value;
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
                        str = (string) base[this.tableDt_Onaylı_Is_Emri.Stk_KodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stk_Kod' in table 'Dt_Onaylı_Is_Emri' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Onaylı_Is_Emri.Stk_KodColumn] = value;
                }
            }
        }

        public class Dt_Onaylı_Is_EmriRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DS_Is_Emri.Dt_Onaylı_Is_EmriRow eventRow;

            [DebuggerNonUserCode]
            public Dt_Onaylı_Is_EmriRowChangeEvent(DS_Is_Emri.Dt_Onaylı_Is_EmriRow row, DataRowAction action)
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
            public DS_Is_Emri.Dt_Onaylı_Is_EmriRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void Dt_Onaylı_Is_EmriRowChangeEventHandler(object sender, DS_Is_Emri.Dt_Onaylı_Is_EmriRowChangeEvent e);
    }
}

