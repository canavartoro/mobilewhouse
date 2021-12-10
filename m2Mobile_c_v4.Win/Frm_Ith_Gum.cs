using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using m2Mobile_c_v4.Classes;
using m2Mobile_c_v4.WebReference;

namespace m2Mobile_c_v4
{
    public partial class Frm_Ith_Gum : Form
    {
        private Button btn_ith_vazgec;
        private IContainer components = null;
        private DataGrid dataGrid1;
        private DataSet2 dataSet2;
        private BindingSource dtIthalatGumCikisBindingSource;
        public DataRow ith_row;
        private MainMenu mainMenu1;
        private Panel panel1;

        public Frm_Ith_Gum()
        {
            this.InitializeComponent();
        }

        private void btn_ith_vazgec_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGrid1.CurrentRowIndex >= 0)
            {
                DataRow r = this.dataSet2.Dt_Ithalat_Gum_Cikis.Rows[this.dataGrid1.CurrentRowIndex];
                new Frm_Ith_Gum_Detay(r).Show();
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

        private void Frm_Ith_Gum_Load(object sender, EventArgs e)
        {
            this.getIthalatData();
            this.SetGridColumns();
        }

        public void getIthalatData()
        {
            SysDefinitions.CursorState("Wait");
            ServiceRequestOfTrmActualImpMInParam param = new ServiceRequestOfTrmActualImpMInParam();
            param.Token = Data._Token.Token;
            param.Value = new TrmActualImpMInParam();
            param.Value.PageSize = 0x3e8;
            ServiceResultOfListOfTrmActualImpMOutParam actualMImp = Data._UService.GetActualMImp(param);
            if (actualMImp.Result)
            {
                for (int i = 0; i < actualMImp.Value.Length; i++)
                {
                    this.ith_row = this.dataSet2.Dt_Ithalat_Gum_Cikis.NewRow();
                    this.ith_row["Fiili_Ith_Tar"] = actualMImp.Value[i].ActualImpExpDate.ToString("dd/MM/yy");
                    this.ith_row["Yukleme_No"] = actualMImp.Value[i].ShipmentNo;
                    this.ith_row["Dosya_No"] = actualMImp.Value[i].FileNo;
                    this.ith_row["Cari_Adı"] = actualMImp.Value[i].EntityName;
                    this.ith_row["Beyan_No"] = actualMImp.Value[i].CustomsNo;
                    this.ith_row["Id"] = actualMImp.Value[i].ActualImpMId;
                    this.dataSet2.Dt_Ithalat_Gum_Cikis.Rows.Add(this.ith_row);
                }
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
            this.dtIthalatGumCikisBindingSource = new BindingSource(this.components);
            this.dataSet2 = new DataSet2();
            this.dataGrid1 = new DataGrid();
            this.btn_ith_vazgec = new Button();
            this.panel1 = new Panel();
            ((ISupportInitialize)this.dtIthalatGumCikisBindingSource).BeginInit();
            this.dataSet2.BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dtIthalatGumCikisBindingSource.DataMember = "Dt_Ithalat_Gum_Cikis";
            this.dtIthalatGumCikisBindingSource.DataSource = this.dataSet2;
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.Prefix = "";
            this.dataSet2.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.dataGrid1.BackgroundColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.dataGrid1.DataSource = this.dtIthalatGumCikisBindingSource;
            this.dataGrid1.Location = new Point(0, -1);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new Size(240, 0xf8);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.DoubleClick += new EventHandler(this.dataGrid1_DoubleClick);
            this.btn_ith_vazgec.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_ith_vazgec.Location = new Point(12, 0xfd);
            this.btn_ith_vazgec.Name = "btn_ith_vazgec";
            this.btn_ith_vazgec.Size = new Size(80, 0x22);
            this.btn_ith_vazgec.TabIndex = 1;
            this.btn_ith_vazgec.Text = "Vazge\x00e7";
            this.btn_ith_vazgec.Click += new EventHandler(this.btn_ith_vazgec_Click);
            this.panel1.Controls.Add(this.btn_ith_vazgec);
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(240, 0x126);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 0x126);
            base.ControlBox = false;
            base.Controls.Add(this.panel1);
            base.Name = "Frm_Ith_Gum";
            this.Text = "İthalat G\x00fcmr\x00fck \x00c7ıkış Fatura ";
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Load += new EventHandler(this.Frm_Ith_Gum_Load);
            ((ISupportInitialize)this.dtIthalatGumCikisBindingSource).EndInit();
            this.dataSet2.EndInit();
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
                    MappingName = "Dt_Ithalat_Gum_Cikis"
                };
                DataGridColumnStyle column = new DataGridTextBoxColumn
                {
                    MappingName = "Fiili_Ith_Tar",
                    HeaderText = "Fiili_Ith_Tar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.5))
                };
                table.GridColumnStyles.Add(column);
                DataGridColumnStyle style3 = new DataGridTextBoxColumn
                {
                    MappingName = "Yukleme_No",
                    HeaderText = "Yukleme_No",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.35))
                };
                table.GridColumnStyles.Add(style3);
                DataGridColumnStyle style4 = new DataGridTextBoxColumn
                {
                    MappingName = "Dosya_No",
                    HeaderText = "Dosya_No",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.3))
                };
                table.GridColumnStyles.Add(style4);
                DataGridColumnStyle style5 = new DataGridTextBoxColumn
                {
                    MappingName = "Cari_Adı",
                    HeaderText = "Cari_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.3))
                };
                table.GridColumnStyles.Add(style5);
                DataGridColumnStyle style6 = new DataGridTextBoxColumn
                {
                    MappingName = "Beyan_No",
                    HeaderText = "Beyan_No",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.35))
                };
                table.GridColumnStyles.Add(style6);
                DataGridColumnStyle style7 = new DataGridTextBoxColumn
                {
                    MappingName = "Id",
                    HeaderText = "Id",
                    Width = -1
                };
                table.GridColumnStyles.Add(style7);
                this.dataGrid1.TableStyles.Add(table);
            }
            catch (SystemException)
            {
            }
        }
    }
}

