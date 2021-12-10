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
    public partial class Frm_StnSiparisi : Form
    {
        private Button btn_stnSip_vazgec;
        private IContainer components = null;
        private DataGrid dataGrid1;
        private DataSet1 dataSet1;
        private BindingSource dataSet1BindingSource;
        private MainMenu mainMenu1;
        private Panel panel1;
        private DataSet dataSet2;
        public DataRow row;

        public Frm_StnSiparisi()
        {
            this.InitializeComponent();
        }

        private void btn_stnSip_vazgec_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGrid1.CurrentRowIndex >= 0)
            {
                DataRow r = this.dataSet1.Dt_SatinAlma.Rows[this.dataGrid1.CurrentRowIndex];
                new Frm_StnSiparisi_Detay(r).Show();
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

        private void Frm_StnSiparisi_Load(object sender, EventArgs e)
        {
            this.getSatisData();
            this.SetGridColumns();
        }

        public void getSatisData()
        {
            SysDefinitions.CursorState("Wait");
            ServiceRequestOfOrderMParam param = new ServiceRequestOfOrderMParam();
            param.Token = Data._Token.Token;
            param.Value = new OrderMParam();
            param.Value.PurchaseSales = 1;
            param.Value.WhouseId = Data._SelectedWareHouse;
            param.Value.PageSize = 500;
            ServiceResultOfListOfOrderMInfo orderMInfo = Data._UService.GetOrderMInfo(param);
            if (orderMInfo.Result)
            {
                for (int i = 0; i < orderMInfo.Value.Length; i++)
                {
                    this.row = this.dataSet1.Dt_SatinAlma.NewRow();
                    this.row["Sip_tar"] = orderMInfo.Value[i].DocDate.ToString("dd/MM/yy");
                    this.row["Sip_no"] = orderMInfo.Value[i].DocNo;
                    this.row["Cari_Adı"] = orderMInfo.Value[i].EntityName;
                    this.row["Hareket_Tar"] = orderMInfo.Value[i].DeliveryDate;
                    this.row["Sat_Temsilcisi"] = orderMInfo.Value[i].SalesPersonName;
                    this.row["Teslim_Tar"] = orderMInfo.Value[i].DeliveryDate;
                    this.row["RefNo"] = orderMInfo.Value[i].Id;
                    this.row["DocTraId"] = orderMInfo.Value[i].DocTraId;
                    this.dataSet1.Dt_SatinAlma.Rows.Add(this.row);
                }
                DataView view = this.dataSet1.Dt_SatinAlma.AsDataView();
                view.Sort = "Cari_Adı asc";
                this.dataSet1BindingSource.DataSource = view;
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btn_stnSip_vazgec = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataSet1 = new DataSet1();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 246);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            // 
            // btn_stnSip_vazgec
            // 
            this.btn_stnSip_vazgec.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_stnSip_vazgec.Location = new System.Drawing.Point(9, 253);
            this.btn_stnSip_vazgec.Name = "btn_stnSip_vazgec";
            this.btn_stnSip_vazgec.Size = new System.Drawing.Size(85, 34);
            this.btn_stnSip_vazgec.TabIndex = 1;
            this.btn_stnSip_vazgec.Text = "Vazgeç";
            this.btn_stnSip_vazgec.Click += new System.EventHandler(this.btn_stnSip_vazgec_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_stnSip_vazgec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 300);
            // 
            // dataSet2
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Namespace = "";
            this.dataSet1.Prefix = "";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_StnSiparisi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 300);
            this.ControlBox = false;
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_StnSiparisi";
            this.Text = "Satın Alma Siparişi";
            this.Load += new System.EventHandler(this.Frm_StnSiparisi_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        private void SetGridColumns()
        {
            try
            {
                this.dataGrid1.TableStyles.Clear();
                DataGridTableStyle table = new DataGridTableStyle
                {
                    MappingName = "Dt_SatinAlma"
                };
                DataGridColumnStyle column = new DataGridTextBoxColumn
                {
                    MappingName = "Sip_Tar",
                    HeaderText = "Sip Tar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.25))
                };
                table.GridColumnStyles.Add(column);
                DataGridColumnStyle style3 = new DataGridTextBoxColumn
                {
                    MappingName = "Sip_No",
                    HeaderText = "Sip No",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.25))
                };
                table.GridColumnStyles.Add(style3);
                DataGridColumnStyle style4 = new DataGridTextBoxColumn
                {
                    MappingName = "Cari_Adı",
                    HeaderText = "Cari Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.22))
                };
                table.GridColumnStyles.Add(style4);
                DataGridColumnStyle style5 = new DataGridTextBoxColumn
                {
                    MappingName = "Hareket_Tar",
                    HeaderText = "Hareket_Tar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.32))
                };
                table.GridColumnStyles.Add(style5);
                DataGridColumnStyle style6 = new DataGridTextBoxColumn
                {
                    MappingName = "Sat_Temsilcisi",
                    HeaderText = "Sat_Temsilcisi",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.35))
                };
                table.GridColumnStyles.Add(style6);
                DataGridColumnStyle style7 = new DataGridTextBoxColumn
                {
                    MappingName = "Teslim_Tar",
                    HeaderText = "Teslim_Tar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.32))
                };
                table.GridColumnStyles.Add(style7);
                DataGridColumnStyle style8 = new DataGridTextBoxColumn
                {
                    MappingName = "RefNo",
                    HeaderText = "RefNo",
                    Width = -1
                };
                table.GridColumnStyles.Add(style8);
                DataGridColumnStyle style9 = new DataGridTextBoxColumn
                {
                    MappingName = "Teslim_Tar",
                    HeaderText = "Teslim_Tar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.32))
                };
                table.GridColumnStyles.Add(style9);
                this.dataGrid1.TableStyles.Add(table);
            }
            catch (SystemException)
            {
            }
        }
    }
}

