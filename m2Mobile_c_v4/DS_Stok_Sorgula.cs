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

    [XmlRoot("DS_Stok_Sorgula"), XmlSchemaProvider("GetTypedDataSetSchema"), DesignerCategory("code")]
    public class DS_Stok_Sorgula : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        private Dt_Stok_MDataTable tableDt_Stok_M;

        [DebuggerNonUserCode]
        public DS_Stok_Sorgula()
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
            DS_Stok_Sorgula sorgula = (DS_Stok_Sorgula) base.Clone();
            sorgula.InitVars();
            sorgula.SchemaSerializationMode = this.SchemaSerializationMode;
            return sorgula;
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
            DS_Stok_Sorgula sorgula = new DS_Stok_Sorgula();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = sorgula.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = sorgula.GetSchemaSerializable();
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
            base.DataSetName = "DS_Stok_Sorgula";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/DS_Stok_Sorgula.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableDt_Stok_M = new Dt_Stok_MDataTable();
            base.Tables.Add(this.tableDt_Stok_M);
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
            this.tableDt_Stok_M = (Dt_Stok_MDataTable) base.Tables["Dt_Stok_M"];
            if (initTable && (this.tableDt_Stok_M != null))
            {
                this.tableDt_Stok_M.InitVars();
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
                if (dataSet.Tables["Dt_Stok_M"] != null)
                {
                    base.Tables.Add(new Dt_Stok_MDataTable(dataSet.Tables["Dt_Stok_M"]));
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
        private bool ShouldSerializeDt_Stok_M()
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
        public Dt_Stok_MDataTable Dt_Stok_M
        {
            get
            {
                return this.tableDt_Stok_M;
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
        public class Dt_Stok_MDataTable : TypedTableBase<DS_Stok_Sorgula.Dt_Stok_MRow>
        {
            private DataColumn columnDepo_Adı;
            private DataColumn columnDepo_Kodu;
            private DataColumn columnStok_Adı;
            private DataColumn columnStok_Kodu;
            private DataColumn columnStok_Miktarı;

            public event DS_Stok_Sorgula.Dt_Stok_MRowChangeEventHandler Dt_Stok_MRowChanged;

            public event DS_Stok_Sorgula.Dt_Stok_MRowChangeEventHandler Dt_Stok_MRowChanging;

            public event DS_Stok_Sorgula.Dt_Stok_MRowChangeEventHandler Dt_Stok_MRowDeleted;

            public event DS_Stok_Sorgula.Dt_Stok_MRowChangeEventHandler Dt_Stok_MRowDeleting;

            [DebuggerNonUserCode]
            public Dt_Stok_MDataTable()
            {
                base.TableName = "Dt_Stok_M";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal Dt_Stok_MDataTable(DataTable table)
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
            public void AddDt_Stok_MRow(DS_Stok_Sorgula.Dt_Stok_MRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public DS_Stok_Sorgula.Dt_Stok_MRow AddDt_Stok_MRow(string Stok_Kodu, string Depo_Kodu, string Depo_Adı, string Stok_Miktarı, string Stok_Adı)
            {
                DS_Stok_Sorgula.Dt_Stok_MRow row = (DS_Stok_Sorgula.Dt_Stok_MRow) base.NewRow();
                row.ItemArray = new object[] { Stok_Kodu, Depo_Kodu, Depo_Adı, Stok_Miktarı, Stok_Adı };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DS_Stok_Sorgula.Dt_Stok_MDataTable table = (DS_Stok_Sorgula.Dt_Stok_MDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DS_Stok_Sorgula.Dt_Stok_MDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DS_Stok_Sorgula.Dt_Stok_MRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DS_Stok_Sorgula sorgula = new DS_Stok_Sorgula();
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
                    FixedValue = sorgula.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "Dt_Stok_MDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sorgula.GetSchemaSerializable();
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
                this.columnStok_Kodu = new DataColumn("Stok_Kodu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStok_Kodu);
                this.columnDepo_Kodu = new DataColumn("Depo_Kodu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDepo_Kodu);
                this.columnDepo_Adı = new DataColumn("Depo_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDepo_Adı);
                this.columnStok_Miktarı = new DataColumn("Stok_Miktarı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStok_Miktarı);
                this.columnStok_Adı = new DataColumn("Stok_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStok_Adı);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnStok_Kodu = base.Columns["Stok_Kodu"];
                this.columnDepo_Kodu = base.Columns["Depo_Kodu"];
                this.columnDepo_Adı = base.Columns["Depo_Adı"];
                this.columnStok_Miktarı = base.Columns["Stok_Miktarı"];
                this.columnStok_Adı = base.Columns["Stok_Adı"];
            }

            [DebuggerNonUserCode]
            public DS_Stok_Sorgula.Dt_Stok_MRow NewDt_Stok_MRow()
            {
                return (DS_Stok_Sorgula.Dt_Stok_MRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DS_Stok_Sorgula.Dt_Stok_MRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Dt_Stok_MRowChanged != null)
                {
                    this.Dt_Stok_MRowChanged(this, new DS_Stok_Sorgula.Dt_Stok_MRowChangeEvent((DS_Stok_Sorgula.Dt_Stok_MRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Dt_Stok_MRowChanging != null)
                {
                    this.Dt_Stok_MRowChanging(this, new DS_Stok_Sorgula.Dt_Stok_MRowChangeEvent((DS_Stok_Sorgula.Dt_Stok_MRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Dt_Stok_MRowDeleted != null)
                {
                    this.Dt_Stok_MRowDeleted(this, new DS_Stok_Sorgula.Dt_Stok_MRowChangeEvent((DS_Stok_Sorgula.Dt_Stok_MRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Dt_Stok_MRowDeleting != null)
                {
                    this.Dt_Stok_MRowDeleting(this, new DS_Stok_Sorgula.Dt_Stok_MRowChangeEvent((DS_Stok_Sorgula.Dt_Stok_MRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveDt_Stok_MRow(DS_Stok_Sorgula.Dt_Stok_MRow row)
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
            public DataColumn Depo_AdıColumn
            {
                get
                {
                    return this.columnDepo_Adı;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Depo_KoduColumn
            {
                get
                {
                    return this.columnDepo_Kodu;
                }
            }

            [DebuggerNonUserCode]
            public DS_Stok_Sorgula.Dt_Stok_MRow this[int index]
            {
                get
                {
                    return (DS_Stok_Sorgula.Dt_Stok_MRow) base.Rows[index];
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
            public DataColumn Stok_MiktarıColumn
            {
                get
                {
                    return this.columnStok_Miktarı;
                }
            }
        }

        public class Dt_Stok_MRow : DataRow
        {
            private DS_Stok_Sorgula.Dt_Stok_MDataTable tableDt_Stok_M;

            [DebuggerNonUserCode]
            internal Dt_Stok_MRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDt_Stok_M = (DS_Stok_Sorgula.Dt_Stok_MDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsDepo_AdıNull()
            {
                return base.IsNull(this.tableDt_Stok_M.Depo_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDepo_KoduNull()
            {
                return base.IsNull(this.tableDt_Stok_M.Depo_KoduColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStok_AdıNull()
            {
                return base.IsNull(this.tableDt_Stok_M.Stok_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStok_KoduNull()
            {
                return base.IsNull(this.tableDt_Stok_M.Stok_KoduColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStok_MiktarıNull()
            {
                return base.IsNull(this.tableDt_Stok_M.Stok_MiktarıColumn);
            }

            [DebuggerNonUserCode]
            public void SetDepo_AdıNull()
            {
                base[this.tableDt_Stok_M.Depo_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDepo_KoduNull()
            {
                base[this.tableDt_Stok_M.Depo_KoduColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStok_AdıNull()
            {
                base[this.tableDt_Stok_M.Stok_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStok_KoduNull()
            {
                base[this.tableDt_Stok_M.Stok_KoduColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStok_MiktarıNull()
            {
                base[this.tableDt_Stok_M.Stok_MiktarıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Depo_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Stok_M.Depo_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Depo_Adı' in table 'Dt_Stok_M' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Stok_M.Depo_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Depo_Kodu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Stok_M.Depo_KoduColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Depo_Kodu' in table 'Dt_Stok_M' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Stok_M.Depo_KoduColumn] = value;
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
                        str = (string) base[this.tableDt_Stok_M.Stok_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stok_Adı' in table 'Dt_Stok_M' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Stok_M.Stok_AdıColumn] = value;
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
                        str = (string) base[this.tableDt_Stok_M.Stok_KoduColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stok_Kodu' in table 'Dt_Stok_M' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Stok_M.Stok_KoduColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Stok_Miktarı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Stok_M.Stok_MiktarıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stok_Miktarı' in table 'Dt_Stok_M' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Stok_M.Stok_MiktarıColumn] = value;
                }
            }
        }

        public class Dt_Stok_MRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DS_Stok_Sorgula.Dt_Stok_MRow eventRow;

            [DebuggerNonUserCode]
            public Dt_Stok_MRowChangeEvent(DS_Stok_Sorgula.Dt_Stok_MRow row, DataRowAction action)
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
            public DS_Stok_Sorgula.Dt_Stok_MRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void Dt_Stok_MRowChangeEventHandler(object sender, DS_Stok_Sorgula.Dt_Stok_MRowChangeEvent e);

        private class Dt_Stok_SorgulaDataTable
        {
        }
    }
}

