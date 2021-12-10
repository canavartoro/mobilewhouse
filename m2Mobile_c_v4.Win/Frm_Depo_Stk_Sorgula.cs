namespace m2Mobile_c_v4
{
    using m2Mobile_c_v4.Classes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WebReference;

    public class Frm_Depo_Stk_Sorgula : Form
    {
        private List<DepoStokOutParam> _cacheTable = new List<DepoStokOutParam>();
        private int _MaxSequence = 0;
        private string _MessageStr = "";
        private int _Procces = 1;
        private Button btn_delete;
        private Button btn_Stk_vazgec;
        private CheckBox checkBoxDepoStok;
        private IContainer components = null;
        private DataGrid dataGrid2;
        private DS_Stok_Sorgula dS_Stok_Sorgula;
        private BindingSource dtStokMBindingSource;
        private FormParameters FormParam = new FormParameters();
        private DateTime lastKeyPress = DateTime.Now;
        private Label Lbl_State;
        private MainMenu mainMenu1;
        private Panel panel1;
        private TextBox txt_Barcode;

        public Frm_Depo_Stk_Sorgula()
        {
            this.InitializeComponent();
            //this.dS_Stok_Sorgula.Dt_Stok_M.Columns["Stok_Miktarı"].DataType = Type.GetType("System.Int64");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this._Procces = 1;
            this.txt_Barcode.Text = "";
            this.SetSquence();
        }

        private void btn_Stk_vazgec_Click(object sender, EventArgs e)
        {
            base.Visible = false;
            Frm_Menu menu = new Frm_Menu {
                Visible = true
            };
        }

        private void checkBoxDepoStok_CheckStateChanged(object sender, EventArgs e)
        {
            this.DepoStokRefresh();
        }

        private void DepoStokRefresh()
        {
            this.dS_Stok_Sorgula.Dt_Stok_M.Clear();
            foreach (DepoStokOutParam param in this._cacheTable)
            {
                if (!this.checkBoxDepoStok.Checked || (param.QtyPrm > 0M))
                {
                    DataRow row = this.dS_Stok_Sorgula.Dt_Stok_M.NewRow();
                    row["Stok_Kodu"] = param.ItemCode;
                    row["Depo_Kodu"] = param.WhouseCode;
                    row["Depo_Adı"] = param.WhouseDesc;
                    row["Stok_Miktarı"] = int.Parse(param.QtyPrm.ToString());
                    row["Stok_Adı"] = param.ItemName;
                    this.dS_Stok_Sorgula.Dt_Stok_M.Rows.Add(row);
                }
            }
            DataView view = this.dS_Stok_Sorgula.Dt_Stok_M.AsDataView();
            view.Sort = "Stok_Miktarı asc";
            this.dtStokMBindingSource.DataSource = view;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Frm_Depo_Stk_Sorgula_Load(object sender, EventArgs e)
        {
            this.SetGridColumns();
            this.FormParam = Data.FParam("Frm_Depo_Stk_Sorgula");
            this._Procces = 1;
            this._MaxSequence = 1;
            if (this.FormParam.PRM_READSQUENCE1 == "")
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Msg_ReadSequence");
                MessageBox.Show(this._MessageStr);
                base.Close();
            }
            this._MaxSequence = 1;
            if (this.FormParam.PRM_READSQUENCE1 != "")
            {
                this._MaxSequence = 1;
            }
            if (this.FormParam.PRM_READSQUENCE2 != "")
            {
                this._MaxSequence = 2;
            }
            if (this.FormParam.PRM_READSQUENCE3 != "")
            {
                this._MaxSequence = 3;
            }
            if (this.FormParam.PRM_READSQUENCE4 != "")
            {
                this._MaxSequence = 4;
            }
            if (this.FormParam.PRM_READSQUENCE5 != "")
            {
                this._MaxSequence = 5;
            }
            this.SetSquence();
            this.txt_Barcode.Focus();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.mainMenu1 = new MainMenu();
            this.dS_Stok_Sorgula = new DS_Stok_Sorgula();
            this.btn_Stk_vazgec = new Button();
            this.panel1 = new Panel();
            this.checkBoxDepoStok = new CheckBox();
            this.Lbl_State = new Label();
            this.btn_delete = new Button();
            this.txt_Barcode = new TextBox();
            this.dtStokMBindingSource = new BindingSource(this.components);
            this.dataGrid2 = new DataGrid();
            //this.dS_Stok_Sorgula.BeginInit();
            //this.panel1.SuspendLayout();
            //((ISupportInitialize) this.dtStokMBindingSource).BeginInit();
            //base.SuspendLayout();
            this.dS_Stok_Sorgula.DataSetName = "DS_Stok_Sorgula";
            this.dS_Stok_Sorgula.Prefix = "";
            //this.dS_Stok_Sorgula.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.btn_Stk_vazgec.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_Stk_vazgec.Location = new Point(11, 0x101);
            this.btn_Stk_vazgec.Name = "btn_Stk_vazgec";
            this.btn_Stk_vazgec.Size = new Size(0x43, 0x1c);
            this.btn_Stk_vazgec.TabIndex = 4;
            this.btn_Stk_vazgec.Text = "Vazge\x00e7";
            this.btn_Stk_vazgec.Click += new EventHandler(this.btn_Stk_vazgec_Click);
            this.panel1.Controls.Add(this.checkBoxDepoStok);
            this.panel1.Controls.Add(this.Lbl_State);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.txt_Barcode);
            this.panel1.Controls.Add(this.dataGrid2);
            this.panel1.Controls.Add(this.btn_Stk_vazgec);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(240, 0x123);
            this.checkBoxDepoStok.Checked = true;
            this.checkBoxDepoStok.CheckState = CheckState.Checked;
            this.checkBoxDepoStok.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.checkBoxDepoStok.Location = new Point(0x54, 260);
            this.checkBoxDepoStok.Name = "checkBoxDepoStok";
            this.checkBoxDepoStok.Size = new Size(0x99, 0x18);
            this.checkBoxDepoStok.TabIndex = 3;
            this.checkBoxDepoStok.Text = "Sadece Stokta Olanları G\x00f6ster";
            this.checkBoxDepoStok.CheckStateChanged += new EventHandler(this.checkBoxDepoStok_CheckStateChanged);
            this.Lbl_State.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_State.Location = new Point(11, 5);
            this.Lbl_State.Name = "Lbl_State";
            this.Lbl_State.Size = new Size(0x52, 20);
            this.Lbl_State.Text = "-";
            this.Lbl_State.TextAlign = ContentAlignment.TopCenter;
            this.btn_delete.Location = new Point(210, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new Size(0x19, 20);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "X";
            this.btn_delete.Click += new EventHandler(this.btn_delete_Click);
            this.txt_Barcode.ForeColor = SystemColors.InfoText;
            this.txt_Barcode.Location = new Point(0x63, 5);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new Size(0x6a, 0x15);
            this.txt_Barcode.TabIndex = 1;
            this.txt_Barcode.TextChanged += new EventHandler(this.txt_Barcode_TextChanged);
            this.txt_Barcode.KeyDown += new KeyEventHandler(this.txt_Barcode_KeyDown);
            this.dtStokMBindingSource.DataMember = "Dt_Stok_M";
            //this.dtStokMBindingSource.DataSource = this.dS_Stok_Sorgula;
            this.dataGrid2.BackgroundColor = Color.FromArgb(0x80, 0x80, 0x80);
            //this.dataGrid2.DataSource = this.dtStokMBindingSource;
            this.dataGrid2.Location = new Point(0, 0x1d);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new Size(240, 0xde);
            this.dataGrid2.TabIndex = 6;
            //base.AutoScaleDimensions = new SizeF(96f, 96f);
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 0x126);
            base.Controls.Add(this.panel1);
            base.Name = "Frm_Depo_Stk_Sorgula";
            this.Text = "Depo Stok Sorgula";
            base.Location = new Point(0, 0);
            base.Load += new EventHandler(this.Frm_Depo_Stk_Sorgula_Load);
            //this.dS_Stok_Sorgula.EndInit();
            //this.panel1.ResumeLayout(false);
            //((ISupportInitialize) this.dtStokMBindingSource).EndInit();
            //base.ResumeLayout(false);
        }

        private void ProccesDataBarcode(string _xCode)
        {
            try
            {
                int num = 0;
                ServiceResultOfItemInfo info = Data._SrvcItemInfo(_xCode);
                if (!info.Result)
                {
                    ServiceResultOfInt32 num2 = Data._SrvcItemInfoUseItemID(_xCode);
                    if (!num2.Result)
                    {
                        MessageBox.Show(info.Message.ToString());
                        return;
                    }
                    num = num2.Value;
                }
                else
                {
                    num = info.Value.Id;
                }
                if (num != 0)
                {
                    SysDefinitions.CursorState("Wait");
                    ServiceRequestOfDepoStokInParam param = new ServiceRequestOfDepoStokInParam ();
                    param.Token = Data._Token.Token;
                    param.Value = new DepoStokInParam();
                    param.Value.ItemId = num;
                    ServiceResultOfListOfDepoStokOutParam bwhItem = Data._UService.GetBwhItem(param);
                    if (bwhItem.Result)
                    {
                        for (int i = 0; i < bwhItem.Value.Length; i++)
                        {
                            DepoStokOutParam item = new DepoStokOutParam {
                                ItemCode = bwhItem.Value[i].ItemCode,
                                ItemName = bwhItem.Value[i].ItemName,
                                WhouseCode = bwhItem.Value[i].WhouseCode,
                                WhouseId = bwhItem.Value[i].WhouseId,
                                WhouseDesc = bwhItem.Value[i].WhouseDesc,
                                QtyPrm = bwhItem.Value[i].QtyPrm
                            };
                            this._cacheTable.Add(item);
                        }
                    }
                    this.DepoStokRefresh();
                    SysDefinitions.CursorState("Default");
                }
            }
            catch (SystemException exception)
            {
                MessageBox.Show("hata : " + exception.Message);
            }
        }

        private void ProcessData(string _xCode)
        {
            try
            {
                object obj2 = new object();
                if (this._Procces == 1)
                {
                    obj2 = this.FormParam.PRM_READSQUENCE1;
                }
                if (this._Procces == 2)
                {
                    obj2 = this.FormParam.PRM_READSQUENCE2;
                }
                if (this._Procces == 3)
                {
                    obj2 = this.FormParam.PRM_READSQUENCE3;
                }
                if (this._Procces == 4)
                {
                    obj2 = this.FormParam.PRM_READSQUENCE4;
                }
                if (this._Procces == 5)
                {
                    obj2 = this.FormParam.PRM_READSQUENCE5;
                }
                object obj3 = new object();
                if (obj2.ToString() == this.FormParam.PRM_BARCODELABEL)
                {
                    obj3 = this.FormParam.PRM_BARCODEPREVALUE;
                }
                if (this._Procces == this._MaxSequence)
                {
                    this.ProccesDataBarcode(_xCode);
                    this._Procces = 1;
                    this.txt_Barcode.Text = "";
                }
                else
                {
                    this._Procces++;
                }
                this.SetSquence();
                this.txt_Barcode.Text = "";
                this.txt_Barcode.Focus();
            }
            catch (SystemException)
            {
            }
        }

        private void SetGridColumns()
        {
            try
            {
                this.dataGrid2.TableStyles.Clear();
                DataGridTableStyle table = new DataGridTableStyle();
                DataGridColumnStyle column = new DataGridTextBoxColumn {
                    MappingName = "Stok_Kodu",
                    HeaderText = "Stok_Kodu",
                    Width = Convert.ToInt32((int) (this.dataGrid2.Width * 50))
                };
                table.GridColumnStyles.Add(column);
                DataGridColumnStyle style3 = new DataGridTextBoxColumn {
                    MappingName = "Depo_Kodu",
                    HeaderText = "Depo_Kodu",
                    Width = Convert.ToInt32((int) (this.dataGrid2.Width * 50))
                };
                table.GridColumnStyles.Add(style3);
                DataGridColumnStyle style4 = new DataGridTextBoxColumn {
                    MappingName = "Depo_Adı",
                    HeaderText = "Depo_Adı",
                    Width = Convert.ToInt32((double) (this.dataGrid2.Width * 0.8))
                };
                table.GridColumnStyles.Add(style4);
                DataGridColumnStyle style5 = new DataGridTextBoxColumn {
                    MappingName = "Stok_Miktarı",
                    HeaderText = "Stok_Miktarı",
                    Width = Convert.ToInt32((double) (this.dataGrid2.Width * 0.8))
                };
                table.GridColumnStyles.Add(style5);
                DataGridColumnStyle style6 = new DataGridTextBoxColumn {
                    MappingName = "Stok_Adı",
                    HeaderText = "Stok_Adı",
                    Width = Convert.ToInt32((double) (this.dataGrid2.Width * 0.8))
                };
                table.GridColumnStyles.Add(style6);
                this.dataGrid2.TableStyles.Add(table);
            }
            catch (SystemException)
            {
            }
        }

        private void SetSquence()
        {
            if (this._Procces == 1)
            {
                this.Lbl_State.Text = this.FormParam.PRM_READSQUENCE1;
            }
            if (this._Procces == 2)
            {
                this.Lbl_State.Text = this.FormParam.PRM_READSQUENCE2;
            }
            if (this._Procces == 3)
            {
                this.Lbl_State.Text = this.FormParam.PRM_READSQUENCE3;
            }
            if (this._Procces == 4)
            {
                this.Lbl_State.Text = this.FormParam.PRM_READSQUENCE4;
            }
            if (this._Procces == 5)
            {
                this.Lbl_State.Text = this.FormParam.PRM_READSQUENCE5;
                this.txt_Barcode.Text = "";
            }
        }

        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                if (!this.FormParam.PRM_ALLOWMANUELENTRY)
                {
                    TimeSpan span = (TimeSpan) (DateTime.Now - this.lastKeyPress);
                    if (span.TotalMilliseconds > Data._BarcodeDelay)
                    {
                        this.txt_Barcode.Text = "";
                        e.Handled = true;
                    }
                    this.lastKeyPress = DateTime.Now;
                }
            }
            else
            {
                this.ProcessData(this.txt_Barcode.Text);
            }
        }

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

