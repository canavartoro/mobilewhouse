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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.dtOnaylıIsEmriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_Is_Emri = new m2Mobile_c_v4.DS_Is_Emri();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btn_vazgec = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtOnaylıIsEmriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Is_Emri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtOnaylıIsEmriBindingSource
            // 
            this.dtOnaylıIsEmriBindingSource.DataMember = "Dt_Onaylı_Is_Emri";
            this.dtOnaylıIsEmriBindingSource.DataSource = this.dS_Is_Emri;
            // 
            // dS_Is_Emri
            // 
            this.dS_Is_Emri.DataSetName = "DS_Is_Emri";
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.DataSource = this.dtOnaylıIsEmriBindingSource;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 252);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            // 
            // btn_vazgec
            // 
            this.btn_vazgec.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_vazgec.Location = new System.Drawing.Point(13, 258);
            this.btn_vazgec.Name = "btn_vazgec";
            this.btn_vazgec.Size = new System.Drawing.Size(78, 28);
            this.btn_vazgec.TabIndex = 1;
            this.btn_vazgec.Text = "Vazgeç";
            this.btn_vazgec.Click += new System.EventHandler(this.btn_vazgec_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_vazgec);
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 294);
            this.panel1.TabIndex = 0;
            // 
            // Frm_Isemri_Malz_Cikis
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_Isemri_Malz_Cikis";
            this.Text = "İş Emrine Bağlı Malzeme Çıkışı";
            this.Load += new System.EventHandler(this.Frm_Isemri_Malz_Cikis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtOnaylıIsEmriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Is_Emri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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

