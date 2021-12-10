namespace m2Mobile_c_v4
{
    using m2Mobile_c_v4.Classes;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WebReference;

    public class Frm_Isemri_Malz_Cikis : Form
    {
        private Button btn_vazgec;
        private IContainer components = null;
        private DataGrid dataGrid1;
        private DS_Is_Emri dS_Is_Emri;
        private BindingSource dtOnaylıIsEmriBindingSource;
        private MainMenu mainMenu1;
        private Panel panel1;
        public DataRow row;

        public Frm_Isemri_Malz_Cikis()
        {
            this.InitializeComponent();
        }

        private void btn_vazgec_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGrid1.CurrentRowIndex >= 0)
            {
                DataRow row = this.dS_Is_Emri.Dt_Onaylı_Is_Emri.Rows[this.dataGrid1.CurrentRowIndex];
                new Frm_Isemri_Malz_Cikis_Detayi(row).Show();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Frm_Isemri_Malz_Cikis_Load(object sender, EventArgs e)
        {
            this.getIsEmriMalzemeData();
            this.SetGridColumns();
        }

        public void getIsEmriMalzemeData()
        {
            SysDefinitions.CursorState("Wait");
            ServiceRequestOfTrmWorderMInParam param = new ServiceRequestOfTrmWorderMInParam();
            param.Token = Data._Token.Token;
            param.Value = new TrmWorderMInParam();
            param.Value.WorderMatrlTrnType = 0;
            param.Value.PageSize = 0x2710;
            ServiceResultOfListOfTrmWorderMOutParam worderMInfo = Data._UService.GetWorderMInfo(param);
            if (worderMInfo.Result)
            {
                for (int i = 0; i < worderMInfo.Value.Length; i++)
                {
                    DataRow row = this.dS_Is_Emri.Dt_Onaylı_Is_Emri.NewRow();
                    row["IsEmri_Tar"] = worderMInfo.Value[i].WoOpenDate.ToString("dd/MM/yy");
                    row["IsEmri_No"] = worderMInfo.Value[i].WorderNo;
                    row["IsEmri_Tipi"] = worderMInfo.Value[i].WoTypeDescription;
                    row["Stk_Kod"] = worderMInfo.Value[i].ItemCode;
                    row["Stk_Adı"] = worderMInfo.Value[i].ItemName;
                    row["Rota_Op_Adı"] = worderMInfo.Value[i].RouteMId;
                    row["Id"] = worderMInfo.Value[i].WorderMId;
                    this.dS_Is_Emri.Dt_Onaylı_Is_Emri.Rows.Add(row);
                }
                DataView view = this.dS_Is_Emri.Dt_Onaylı_Is_Emri.AsDataView();
                view.Sort = "Stk_Kod asc";
                this.dtOnaylıIsEmriBindingSource.DataSource = view;
            }
            else
            {
                this.dataGrid1.DataSource = null;
            }
            this.dataGrid1.Refresh();
            SysDefinitions.CursorState("Default");
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.mainMenu1 = new MainMenu();
            this.dtOnaylıIsEmriBindingSource = new BindingSource(this.components);
            this.dS_Is_Emri = new DS_Is_Emri();
            this.dataGrid1 = new DataGrid();
            this.btn_vazgec = new Button();
            this.panel1 = new Panel();
            ((ISupportInitialize)this.dtOnaylıIsEmriBindingSource).BeginInit();
            this.dS_Is_Emri.BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dtOnaylıIsEmriBindingSource.DataMember = "Dt_Onaylı_Is_Emri";
            this.dtOnaylıIsEmriBindingSource.DataSource = this.dS_Is_Emri;
            this.dS_Is_Emri.DataSetName = "DS_Is_Emri";
            this.dS_Is_Emri.Prefix = "";
            this.dS_Is_Emri.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.dataGrid1.BackgroundColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.dataGrid1.DataSource = this.dtOnaylıIsEmriBindingSource;
            this.dataGrid1.Location = new Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new Size(240, 0xfc);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.DoubleClick += new EventHandler(this.dataGrid1_DoubleClick);
            this.btn_vazgec.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_vazgec.Location = new Point(13, 0x102);
            this.btn_vazgec.Name = "btn_vazgec";
            this.btn_vazgec.Size = new Size(0x4e, 0x1c);
            this.btn_vazgec.TabIndex = 1;
            this.btn_vazgec.Text = "Vazge\x00e7";
            this.btn_vazgec.Click += new EventHandler(this.btn_vazgec_Click);
            this.panel1.Controls.Add(this.btn_vazgec);
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(240, 0x126);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 0x126);
            base.Controls.Add(this.panel1);
            base.Name = "Frm_Isemri_Malz_Cikis";
            this.Text = "İş Emrine Bağlı Malzeme \x00c7ıkışı";
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Load += new EventHandler(this.Frm_Isemri_Malz_Cikis_Load);
            ((ISupportInitialize)this.dtOnaylıIsEmriBindingSource).EndInit();
            this.dS_Is_Emri.EndInit();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void SetGridColumns()
        {
            try
            {
                this.dataGrid1.TableStyles.Clear();
                DataGridTableStyle table = new DataGridTableStyle
                {
                    MappingName = "Dt_Onaylı_Is_Emri"
                };
                DataGridColumnStyle column = new DataGridTextBoxColumn
                {
                    MappingName = "IsEmri_Tar",
                    HeaderText = "IsEmri_Tar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(column);
                DataGridColumnStyle style3 = new DataGridTextBoxColumn
                {
                    MappingName = "IsEmri_No",
                    HeaderText = "IsEmri_No",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.32))
                };
                table.GridColumnStyles.Add(style3);
                DataGridColumnStyle style4 = new DataGridTextBoxColumn
                {
                    MappingName = "IsEmri_Tipi",
                    HeaderText = "IsEmri_Tipi",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.26))
                };
                table.GridColumnStyles.Add(style4);
                DataGridColumnStyle style5 = new DataGridTextBoxColumn
                {
                    MappingName = "Stk_Kod",
                    HeaderText = "Stk_Kod",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.3))
                };
                table.GridColumnStyles.Add(style5);
                DataGridColumnStyle style6 = new DataGridTextBoxColumn
                {
                    MappingName = "Stk_Adı",
                    HeaderText = "Stk_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(style6);
                DataGridColumnStyle style7 = new DataGridTextBoxColumn
                {
                    MappingName = "Rota_Op_Adı",
                    HeaderText = "Rota_Op_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.29))
                };
                table.GridColumnStyles.Add(style7);
                DataGridColumnStyle style8 = new DataGridTextBoxColumn
                {
                    MappingName = "Id",
                    HeaderText = "Id",
                    Width = -1
                };
                table.GridColumnStyles.Add(style8);
                this.dataGrid1.TableStyles.Add(table);
            }
            catch (SystemException)
            {
            }
        }
    }
}

