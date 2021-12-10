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

    [XmlRoot("DataSet2"), XmlSchemaProvider("GetTypedDataSetSchema"), DesignerCategory("code")]
    public class DataSet2 : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        private DT_Ith_DetaylarDataTable tableDT_Ith_Detaylar;
        private Dt_Ithalat_Gum_CikisDataTable tableDt_Ithalat_Gum_Cikis;

        [DebuggerNonUserCode]
        public DataSet2()
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
            DataSet2 set = (DataSet2) base.Clone();
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
            DataSet2 set = new DataSet2();
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
            base.DataSetName = "DataSet2";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/DataSet2.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableDt_Ithalat_Gum_Cikis = new Dt_Ithalat_Gum_CikisDataTable();
            base.Tables.Add(this.tableDt_Ithalat_Gum_Cikis);
            this.tableDT_Ith_Detaylar = new DT_Ith_DetaylarDataTable();
            base.Tables.Add(this.tableDT_Ith_Detaylar);
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
            this.tableDt_Ithalat_Gum_Cikis = (Dt_Ithalat_Gum_CikisDataTable) base.Tables["Dt_Ithalat_Gum_Cikis"];
            if (initTable && (this.tableDt_Ithalat_Gum_Cikis != null))
            {
                this.tableDt_Ithalat_Gum_Cikis.InitVars();
            }
            this.tableDT_Ith_Detaylar = (DT_Ith_DetaylarDataTable) base.Tables["DT_Ith_Detaylar"];
            if (initTable && (this.tableDT_Ith_Detaylar != null))
            {
                this.tableDT_Ith_Detaylar.InitVars();
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
                if (dataSet.Tables["Dt_Ithalat_Gum_Cikis"] != null)
                {
                    base.Tables.Add(new Dt_Ithalat_Gum_CikisDataTable(dataSet.Tables["Dt_Ithalat_Gum_Cikis"]));
                }
                if (dataSet.Tables["DT_Ith_Detaylar"] != null)
                {
                    base.Tables.Add(new DT_Ith_DetaylarDataTable(dataSet.Tables["DT_Ith_Detaylar"]));
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
        private bool ShouldSerializeDT_Ith_Detaylar()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeDt_Ithalat_Gum_Cikis()
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
        public DT_Ith_DetaylarDataTable DT_Ith_Detaylar
        {
            get
            {
                return this.tableDT_Ith_Detaylar;
            }
        }

        [DebuggerNonUserCode]
        public Dt_Ithalat_Gum_CikisDataTable Dt_Ithalat_Gum_Cikis
        {
            get
            {
                return this.tableDt_Ithalat_Gum_Cikis;
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
        public class DT_Ith_DetaylarDataTable : TypedTableBase<DataSet2.DT_Ith_DetaylarRow>
        {
            private DataColumn columnDepo_Adı;
            private DataColumn columnDepo_Kod;
            private DataColumn columndId;
            private DataColumn columnGum_Cek_Mik;
            private DataColumn columnKalan_Mik;
            private DataColumn columnmId;
            private DataColumn columnOk_Mik;
            private DataColumn columnStok_Adı;
            private DataColumn columnStok_Kod;

            public event DataSet2.DT_Ith_DetaylarRowChangeEventHandler DT_Ith_DetaylarRowChanged;

            public event DataSet2.DT_Ith_DetaylarRowChangeEventHandler DT_Ith_DetaylarRowChanging;

            public event DataSet2.DT_Ith_DetaylarRowChangeEventHandler DT_Ith_DetaylarRowDeleted;

            public event DataSet2.DT_Ith_DetaylarRowChangeEventHandler DT_Ith_DetaylarRowDeleting;

            [DebuggerNonUserCode]
            public DT_Ith_DetaylarDataTable()
            {
                base.TableName = "DT_Ith_Detaylar";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal DT_Ith_DetaylarDataTable(DataTable table)
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
            public void AddDT_Ith_DetaylarRow(DataSet2.DT_Ith_DetaylarRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public DataSet2.DT_Ith_DetaylarRow AddDT_Ith_DetaylarRow(string Depo_Kod, string Depo_Adı, string Stok_Kod, string Stok_Adı, string Gum_Cek_Mik, string Kalan_Mik, string Ok_Mik, string mId, string dId)
            {
                DataSet2.DT_Ith_DetaylarRow row = (DataSet2.DT_Ith_DetaylarRow) base.NewRow();
                row.ItemArray = new object[] { Depo_Kod, Depo_Adı, Stok_Kod, Stok_Adı, Gum_Cek_Mik, Kalan_Mik, Ok_Mik, mId, dId };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DataSet2.DT_Ith_DetaylarDataTable table = (DataSet2.DT_Ith_DetaylarDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DataSet2.DT_Ith_DetaylarDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DataSet2.DT_Ith_DetaylarRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DataSet2 set = new DataSet2();
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
                    FixedValue = "DT_Ith_DetaylarDataTable"
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
                this.columnDepo_Kod = new DataColumn("Depo_Kod", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDepo_Kod);
                this.columnDepo_Adı = new DataColumn("Depo_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDepo_Adı);
                this.columnStok_Kod = new DataColumn("Stok_Kod", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStok_Kod);
                this.columnStok_Adı = new DataColumn("Stok_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStok_Adı);
                this.columnGum_Cek_Mik = new DataColumn("Gum_Cek_Mik", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGum_Cek_Mik);
                this.columnKalan_Mik = new DataColumn("Kalan_Mik", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnKalan_Mik);
                this.columnOk_Mik = new DataColumn("Ok_Mik", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOk_Mik);
                this.columnmId = new DataColumn("mId", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnmId);
                this.columndId = new DataColumn("dId", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columndId);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnDepo_Kod = base.Columns["Depo_Kod"];
                this.columnDepo_Adı = base.Columns["Depo_Adı"];
                this.columnStok_Kod = base.Columns["Stok_Kod"];
                this.columnStok_Adı = base.Columns["Stok_Adı"];
                this.columnGum_Cek_Mik = base.Columns["Gum_Cek_Mik"];
                this.columnKalan_Mik = base.Columns["Kalan_Mik"];
                this.columnOk_Mik = base.Columns["Ok_Mik"];
                this.columnmId = base.Columns["mId"];
                this.columndId = base.Columns["dId"];
            }

            [DebuggerNonUserCode]
            public DataSet2.DT_Ith_DetaylarRow NewDT_Ith_DetaylarRow()
            {
                return (DataSet2.DT_Ith_DetaylarRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataSet2.DT_Ith_DetaylarRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DT_Ith_DetaylarRowChanged != null)
                {
                    this.DT_Ith_DetaylarRowChanged(this, new DataSet2.DT_Ith_DetaylarRowChangeEvent((DataSet2.DT_Ith_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DT_Ith_DetaylarRowChanging != null)
                {
                    this.DT_Ith_DetaylarRowChanging(this, new DataSet2.DT_Ith_DetaylarRowChangeEvent((DataSet2.DT_Ith_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DT_Ith_DetaylarRowDeleted != null)
                {
                    this.DT_Ith_DetaylarRowDeleted(this, new DataSet2.DT_Ith_DetaylarRowChangeEvent((DataSet2.DT_Ith_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DT_Ith_DetaylarRowDeleting != null)
                {
                    this.DT_Ith_DetaylarRowDeleting(this, new DataSet2.DT_Ith_DetaylarRowChangeEvent((DataSet2.DT_Ith_DetaylarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveDT_Ith_DetaylarRow(DataSet2.DT_Ith_DetaylarRow row)
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
            public DataColumn Depo_KodColumn
            {
                get
                {
                    return this.columnDepo_Kod;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn dIdColumn
            {
                get
                {
                    return this.columndId;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Gum_Cek_MikColumn
            {
                get
                {
                    return this.columnGum_Cek_Mik;
                }
            }

            [DebuggerNonUserCode]
            public DataSet2.DT_Ith_DetaylarRow this[int index]
            {
                get
                {
                    return (DataSet2.DT_Ith_DetaylarRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Kalan_MikColumn
            {
                get
                {
                    return this.columnKalan_Mik;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn mIdColumn
            {
                get
                {
                    return this.columnmId;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Ok_MikColumn
            {
                get
                {
                    return this.columnOk_Mik;
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
            public DataColumn Stok_KodColumn
            {
                get
                {
                    return this.columnStok_Kod;
                }
            }
        }

        public class DT_Ith_DetaylarRow : DataRow
        {
            private DataSet2.DT_Ith_DetaylarDataTable tableDT_Ith_Detaylar;

            [DebuggerNonUserCode]
            internal DT_Ith_DetaylarRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDT_Ith_Detaylar = (DataSet2.DT_Ith_DetaylarDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsDepo_AdıNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.Depo_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDepo_KodNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.Depo_KodColumn);
            }

            [DebuggerNonUserCode]
            public bool IsdIdNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.dIdColumn);
            }

            [DebuggerNonUserCode]
            public bool IsGum_Cek_MikNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.Gum_Cek_MikColumn);
            }

            [DebuggerNonUserCode]
            public bool IsKalan_MikNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.Kalan_MikColumn);
            }

            [DebuggerNonUserCode]
            public bool IsmIdNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.mIdColumn);
            }

            [DebuggerNonUserCode]
            public bool IsOk_MikNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.Ok_MikColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStok_AdıNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.Stok_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsStok_KodNull()
            {
                return base.IsNull(this.tableDT_Ith_Detaylar.Stok_KodColumn);
            }

            [DebuggerNonUserCode]
            public void SetDepo_AdıNull()
            {
                base[this.tableDT_Ith_Detaylar.Depo_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDepo_KodNull()
            {
                base[this.tableDT_Ith_Detaylar.Depo_KodColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetdIdNull()
            {
                base[this.tableDT_Ith_Detaylar.dIdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetGum_Cek_MikNull()
            {
                base[this.tableDT_Ith_Detaylar.Gum_Cek_MikColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetKalan_MikNull()
            {
                base[this.tableDT_Ith_Detaylar.Kalan_MikColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetmIdNull()
            {
                base[this.tableDT_Ith_Detaylar.mIdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetOk_MikNull()
            {
                base[this.tableDT_Ith_Detaylar.Ok_MikColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStok_AdıNull()
            {
                base[this.tableDT_Ith_Detaylar.Stok_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetStok_KodNull()
            {
                base[this.tableDT_Ith_Detaylar.Stok_KodColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Depo_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.Depo_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Depo_Adı' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.Depo_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Depo_Kod
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.Depo_KodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Depo_Kod' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.Depo_KodColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string dId
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.dIdColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'dId' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.dIdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Gum_Cek_Mik
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.Gum_Cek_MikColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Gum_Cek_Mik' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.Gum_Cek_MikColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Kalan_Mik
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.Kalan_MikColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Kalan_Mik' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.Kalan_MikColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string mId
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.mIdColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'mId' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.mIdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Ok_Mik
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.Ok_MikColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Ok_Mik' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.Ok_MikColumn] = value;
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
                        str = (string) base[this.tableDT_Ith_Detaylar.Stok_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stok_Adı' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.Stok_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Stok_Kod
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDT_Ith_Detaylar.Stok_KodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Stok_Kod' in table 'DT_Ith_Detaylar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDT_Ith_Detaylar.Stok_KodColumn] = value;
                }
            }
        }

        public class DT_Ith_DetaylarRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataSet2.DT_Ith_DetaylarRow eventRow;

            [DebuggerNonUserCode]
            public DT_Ith_DetaylarRowChangeEvent(DataSet2.DT_Ith_DetaylarRow row, DataRowAction action)
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
            public DataSet2.DT_Ith_DetaylarRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void DT_Ith_DetaylarRowChangeEventHandler(object sender, DataSet2.DT_Ith_DetaylarRowChangeEvent e);

        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Dt_Ithalat_Gum_CikisDataTable : TypedTableBase<DataSet2.Dt_Ithalat_Gum_CikisRow>
        {
            private DataColumn columnBeyan_No;
            private DataColumn columnCari_Adı;
            private DataColumn columnDosya_No;
            private DataColumn columnFiili_Ith_Tar;
            private DataColumn columnId;
            private DataColumn columnYukleme_No;

            public event DataSet2.Dt_Ithalat_Gum_CikisRowChangeEventHandler Dt_Ithalat_Gum_CikisRowChanged;

            public event DataSet2.Dt_Ithalat_Gum_CikisRowChangeEventHandler Dt_Ithalat_Gum_CikisRowChanging;

            public event DataSet2.Dt_Ithalat_Gum_CikisRowChangeEventHandler Dt_Ithalat_Gum_CikisRowDeleted;

            public event DataSet2.Dt_Ithalat_Gum_CikisRowChangeEventHandler Dt_Ithalat_Gum_CikisRowDeleting;

            [DebuggerNonUserCode]
            public Dt_Ithalat_Gum_CikisDataTable()
            {
                base.TableName = "Dt_Ithalat_Gum_Cikis";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal Dt_Ithalat_Gum_CikisDataTable(DataTable table)
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
            public void AddDt_Ithalat_Gum_CikisRow(DataSet2.Dt_Ithalat_Gum_CikisRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public DataSet2.Dt_Ithalat_Gum_CikisRow AddDt_Ithalat_Gum_CikisRow(string Fiili_Ith_Tar, string Yukleme_No, string Dosya_No, string Cari_Adı, string Beyan_No, string Id)
            {
                DataSet2.Dt_Ithalat_Gum_CikisRow row = (DataSet2.Dt_Ithalat_Gum_CikisRow) base.NewRow();
                row.ItemArray = new object[] { Fiili_Ith_Tar, Yukleme_No, Dosya_No, Cari_Adı, Beyan_No, Id };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DataSet2.Dt_Ithalat_Gum_CikisDataTable table = (DataSet2.Dt_Ithalat_Gum_CikisDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DataSet2.Dt_Ithalat_Gum_CikisDataTable();
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DataSet2.Dt_Ithalat_Gum_CikisRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DataSet2 set = new DataSet2();
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
                    FixedValue = "Dt_Ithalat_Gum_CikisDataTable"
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
                this.columnFiili_Ith_Tar = new DataColumn("Fiili_Ith_Tar", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFiili_Ith_Tar);
                this.columnYukleme_No = new DataColumn("Yukleme_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYukleme_No);
                this.columnDosya_No = new DataColumn("Dosya_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDosya_No);
                this.columnCari_Adı = new DataColumn("Cari_Adı", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCari_Adı);
                this.columnBeyan_No = new DataColumn("Beyan_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBeyan_No);
                this.columnId = new DataColumn("Id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnId);
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnFiili_Ith_Tar = base.Columns["Fiili_Ith_Tar"];
                this.columnYukleme_No = base.Columns["Yukleme_No"];
                this.columnDosya_No = base.Columns["Dosya_No"];
                this.columnCari_Adı = base.Columns["Cari_Adı"];
                this.columnBeyan_No = base.Columns["Beyan_No"];
                this.columnId = base.Columns["Id"];
            }

            [DebuggerNonUserCode]
            public DataSet2.Dt_Ithalat_Gum_CikisRow NewDt_Ithalat_Gum_CikisRow()
            {
                return (DataSet2.Dt_Ithalat_Gum_CikisRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataSet2.Dt_Ithalat_Gum_CikisRow(builder);
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Dt_Ithalat_Gum_CikisRowChanged != null)
                {
                    this.Dt_Ithalat_Gum_CikisRowChanged(this, new DataSet2.Dt_Ithalat_Gum_CikisRowChangeEvent((DataSet2.Dt_Ithalat_Gum_CikisRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Dt_Ithalat_Gum_CikisRowChanging != null)
                {
                    this.Dt_Ithalat_Gum_CikisRowChanging(this, new DataSet2.Dt_Ithalat_Gum_CikisRowChangeEvent((DataSet2.Dt_Ithalat_Gum_CikisRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Dt_Ithalat_Gum_CikisRowDeleted != null)
                {
                    this.Dt_Ithalat_Gum_CikisRowDeleted(this, new DataSet2.Dt_Ithalat_Gum_CikisRowChangeEvent((DataSet2.Dt_Ithalat_Gum_CikisRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Dt_Ithalat_Gum_CikisRowDeleting != null)
                {
                    this.Dt_Ithalat_Gum_CikisRowDeleting(this, new DataSet2.Dt_Ithalat_Gum_CikisRowChangeEvent((DataSet2.Dt_Ithalat_Gum_CikisRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveDt_Ithalat_Gum_CikisRow(DataSet2.Dt_Ithalat_Gum_CikisRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn Beyan_NoColumn
            {
                get
                {
                    return this.columnBeyan_No;
                }
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
            public DataColumn Dosya_NoColumn
            {
                get
                {
                    return this.columnDosya_No;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Fiili_Ith_TarColumn
            {
                get
                {
                    return this.columnFiili_Ith_Tar;
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
            public DataSet2.Dt_Ithalat_Gum_CikisRow this[int index]
            {
                get
                {
                    return (DataSet2.Dt_Ithalat_Gum_CikisRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn Yukleme_NoColumn
            {
                get
                {
                    return this.columnYukleme_No;
                }
            }
        }

        public class Dt_Ithalat_Gum_CikisRow : DataRow
        {
            private DataSet2.Dt_Ithalat_Gum_CikisDataTable tableDt_Ithalat_Gum_Cikis;

            [DebuggerNonUserCode]
            internal Dt_Ithalat_Gum_CikisRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDt_Ithalat_Gum_Cikis = (DataSet2.Dt_Ithalat_Gum_CikisDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsBeyan_NoNull()
            {
                return base.IsNull(this.tableDt_Ithalat_Gum_Cikis.Beyan_NoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsCari_AdıNull()
            {
                return base.IsNull(this.tableDt_Ithalat_Gum_Cikis.Cari_AdıColumn);
            }

            [DebuggerNonUserCode]
            public bool IsDosya_NoNull()
            {
                return base.IsNull(this.tableDt_Ithalat_Gum_Cikis.Dosya_NoColumn);
            }

            [DebuggerNonUserCode]
            public bool IsFiili_Ith_TarNull()
            {
                return base.IsNull(this.tableDt_Ithalat_Gum_Cikis.Fiili_Ith_TarColumn);
            }

            [DebuggerNonUserCode]
            public bool IsIdNull()
            {
                return base.IsNull(this.tableDt_Ithalat_Gum_Cikis.IdColumn);
            }

            [DebuggerNonUserCode]
            public bool IsYukleme_NoNull()
            {
                return base.IsNull(this.tableDt_Ithalat_Gum_Cikis.Yukleme_NoColumn);
            }

            [DebuggerNonUserCode]
            public void SetBeyan_NoNull()
            {
                base[this.tableDt_Ithalat_Gum_Cikis.Beyan_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetCari_AdıNull()
            {
                base[this.tableDt_Ithalat_Gum_Cikis.Cari_AdıColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetDosya_NoNull()
            {
                base[this.tableDt_Ithalat_Gum_Cikis.Dosya_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetFiili_Ith_TarNull()
            {
                base[this.tableDt_Ithalat_Gum_Cikis.Fiili_Ith_TarColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetIdNull()
            {
                base[this.tableDt_Ithalat_Gum_Cikis.IdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetYukleme_NoNull()
            {
                base[this.tableDt_Ithalat_Gum_Cikis.Yukleme_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Beyan_No
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Ithalat_Gum_Cikis.Beyan_NoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Beyan_No' in table 'Dt_Ithalat_Gum_Cikis' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Ithalat_Gum_Cikis.Beyan_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Cari_Adı
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Ithalat_Gum_Cikis.Cari_AdıColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Cari_Adı' in table 'Dt_Ithalat_Gum_Cikis' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Ithalat_Gum_Cikis.Cari_AdıColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Dosya_No
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Ithalat_Gum_Cikis.Dosya_NoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Dosya_No' in table 'Dt_Ithalat_Gum_Cikis' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Ithalat_Gum_Cikis.Dosya_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Fiili_Ith_Tar
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Ithalat_Gum_Cikis.Fiili_Ith_TarColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Fiili_Ith_Tar' in table 'Dt_Ithalat_Gum_Cikis' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Ithalat_Gum_Cikis.Fiili_Ith_TarColumn] = value;
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
                        str = (string) base[this.tableDt_Ithalat_Gum_Cikis.IdColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Id' in table 'Dt_Ithalat_Gum_Cikis' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Ithalat_Gum_Cikis.IdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Yukleme_No
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableDt_Ithalat_Gum_Cikis.Yukleme_NoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Yukleme_No' in table 'Dt_Ithalat_Gum_Cikis' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableDt_Ithalat_Gum_Cikis.Yukleme_NoColumn] = value;
                }
            }
        }

        public class Dt_Ithalat_Gum_CikisRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataSet2.Dt_Ithalat_Gum_CikisRow eventRow;

            [DebuggerNonUserCode]
            public Dt_Ithalat_Gum_CikisRowChangeEvent(DataSet2.Dt_Ithalat_Gum_CikisRow row, DataRowAction action)
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
            public DataSet2.Dt_Ithalat_Gum_CikisRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void Dt_Ithalat_Gum_CikisRowChangeEventHandler(object sender, DataSet2.Dt_Ithalat_Gum_CikisRowChangeEvent e);
    }
}

