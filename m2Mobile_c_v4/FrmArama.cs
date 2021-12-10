namespace m2Mobile_c_v4
{
    using m2Mobile_c_v4.Classes;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WebReference;

    public class FrmArama : Form, IDisposable
    {
        private int _id = 0;
        private int _id2 = 0;
        private string _Type = "";
        private int _TypeFilter = 0;
        private Button Btn_Cancel;
        private Button Btn_Ok;
        private IContainer components = null;
        private DataGrid GridSearch;
        private Panel panel1;
        private Panel panel2;
        private string Pkey = "";
        private string Pkey2 = "";
        private string Pkey3 = "";
        private string Pkey4 = "";

        public FrmArama(string _Ptype, int _Pid, int _Pid2, int _pTypeFilter)
        {
            this.InitializeComponent();
            this._Type = _Ptype;
            this._id = _Pid;
            this._id2 = _Pid2;
            this._TypeFilter = _pTypeFilter;
            this.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Pkey = this.GridSearch[this.GridSearch.CurrentCell.RowNumber, 0].ToString();
            try
            {
                this.Pkey2 = this.GridSearch[this.GridSearch.CurrentCell.RowNumber, 1].ToString();
                this.Pkey3 = this.GridSearch[this.GridSearch.CurrentCell.RowNumber, 2].ToString();
            }
            catch (SystemException)
            {
            }
            try
            {
                this.Pkey3 = this.GridSearch[this.GridSearch.CurrentCell.RowNumber, 2].ToString();
            }
            catch (SystemException)
            {
            }
            try
            {
                this.Pkey4 = this.GridSearch[this.GridSearch.CurrentCell.RowNumber, 3].ToString();
            }
            catch (SystemException)
            {
            }
            if (this._Type == "WorderM")
            {
                this.Pkey4 = this.GridSearch[this.GridSearch.CurrentCell.RowNumber, 7].ToString();
            }
            if (this._Type == "DocTra4")
            {
                this.Pkey3 = this.GridSearch[this.GridSearch.CurrentCell.RowNumber, 5].ToString();
            }
            base.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Pkey = "";
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmArama_Load(object sender, EventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (SysDefinitions.ResMan.GetString(control.Name.ToString()) != null)
                {
                    control.Text = SysDefinitions.ResMan.GetString(control.Name.ToString());
                }
            }
            foreach (Control control in this.panel1.Controls)
            {
                if (SysDefinitions.ResMan.GetString(control.Name.ToString()) != null)
                {
                    control.Text = SysDefinitions.ResMan.GetString(control.Name.ToString());
                }
            }
            foreach (Control control in this.panel2.Controls)
            {
                if (SysDefinitions.ResMan.GetString(control.Name.ToString()) != null)
                {
                    control.Text = SysDefinitions.ResMan.GetString(control.Name.ToString());
                }
            }
        }

        private void GetData()
        {
            ServiceRequestOfDocTraSelectParam param;
            ServiceResultOfListOfDocTra docTra;
            BindingList<DocTra> list;
            int num;
            DocTra tra2;
            SysDefinitions.CursorState("Wait");
            DataSet set = new DataSet();
            if (this._Type == "DocTra2")
            {
                param = new ServiceRequestOfDocTraSelectParam {
                    Token = Data._Token.Token,
                    Value = new DocTraSelectParam()
                };
                param.Value.SourceApplication = 0x3e8;
                param.Value.CoId = Data._Token.Token.CoId;
                docTra = Data._UService.GetDocTra(param);
                if (!docTra.Result)
                {
                    goto Label_063D;
                }
                if (this._TypeFilter != 0)
                {
                    list = new BindingList<DocTra>();
                    for (num = 0; num < docTra.Value.Length; num++)
                    {
                        if (docTra.Value[num].PurchaseSales == this._TypeFilter)
                        {
                            tra2 = new DocTra {
                                DocTraCode = docTra.Value[num].DocTraCode,
                                DocTraDesc = docTra.Value[num].DocTraDesc,
                                Status = docTra.Value[num].Status,
                                PurchaseSales = docTra.Value[num].PurchaseSales,
                                Id = docTra.Value[num].Id
                            };
                            list.Add(tra2);
                        }
                    }
                    this.GridSearch.DataSource = list;
                    this.GridSearch.Refresh();
                }
                else
                {
                    this.GridSearch.DataSource = docTra.Value;
                    this.GridSearch.Refresh();
                }
            }
            if (this._Type == "DocTraIthGun")
            {
                param = new ServiceRequestOfDocTraSelectParam {
                    Token = Data._Token.Token,
                    Value = new DocTraSelectParam()
                };
                param.Value.SourceApplication = 210;
                param.Value.InventoryStatus = 1;
                param.Value.InvoiceType = 2;
                param.Value.CoId = Data._Token.Token.CoId;
                docTra = Data._UService.GetDocTra(param);
                if (!docTra.Result)
                {
                    goto Label_063D;
                }
                if (this._TypeFilter != 0)
                {
                    list = new BindingList<DocTra>();
                    for (num = 0; num < docTra.Value.Length; num++)
                    {
                        tra2 = new DocTra {
                            DocTraCode = docTra.Value[num].DocTraCode,
                            DocTraDesc = docTra.Value[num].DocTraDesc,
                            Status = docTra.Value[num].Status,
                            PurchaseSales = docTra.Value[num].PurchaseSales,
                            Id = docTra.Value[num].Id
                        };
                        list.Add(tra2);
                    }
                    this.GridSearch.DataSource = list;
                    this.GridSearch.Refresh();
                }
                else
                {
                    this.GridSearch.DataSource = docTra.Value;
                    this.GridSearch.Refresh();
                }
            }
            if (this._Type == "DocTraIsEmri_HarketKodu")
            {
                param = new ServiceRequestOfDocTraSelectParam {
                    Token = Data._Token.Token,
                    Value = new DocTraSelectParam()
                };
                param.Value.SourceApplication = 210;
                param.Value.InventoryStatus = 3;
                param.Value.IsreasonMondatory = true;
                param.Value.GetIsreasonMondatory = false;
                param.Value.CoId = Data._Token.Token.CoId;
                docTra = Data._UService.GetDocTra(param);
                if (!docTra.Result)
                {
                    goto Label_063D;
                }
                if (this._TypeFilter != 0)
                {
                    list = new BindingList<DocTra>();
                    for (num = 0; num < docTra.Value.Length; num++)
                    {
                        tra2 = new DocTra {
                            DocTraCode = docTra.Value[num].DocTraCode,
                            DocTraDesc = docTra.Value[num].DocTraDesc,
                            Status = docTra.Value[num].Status,
                            PurchaseSales = docTra.Value[num].PurchaseSales,
                            Id = docTra.Value[num].Id
                        };
                        list.Add(tra2);
                    }
                    this.GridSearch.DataSource = list;
                    this.GridSearch.Refresh();
                }
                else
                {
                    this.GridSearch.DataSource = docTra.Value;
                    this.GridSearch.Refresh();
                }
            }
            if (this._Type == "DocTraIsEmri_Depo")
            {
                ServiceRequestOfDepotSelectParam param2 = new ServiceRequestOfDepotSelectParam {
                    Token = Data._Token.Token,
                    Value = new DepotSelectParam()
                };
                param2.Value.IsscraptIsRework = true;
                ServiceResultOfListOfDepot wareHouses = Data._UService.GetWareHouses(param2);
                if (wareHouses.Result)
                {
                    if (this._TypeFilter != 0)
                    {
                        BindingList<Depot> list2 = new BindingList<Depot>();
                        for (num = 0; num < wareHouses.Value.Length; num++)
                        {
                            Depot item = new Depot {
                                Code = wareHouses.Value[num].Code,
                                Id = wareHouses.Value[num].Id,
                                Name = wareHouses.Value[num].Name
                            };
                            list2.Add(item);
                        }
                        this.GridSearch.DataSource = list2;
                        this.GridSearch.Refresh();
                    }
                    else
                    {
                        this.GridSearch.DataSource = wareHouses.Value;
                        this.GridSearch.Refresh();
                    }
                }
            }
        Label_063D:
            this.GridSearch.Refresh();
            SysDefinitions.CursorState("Default");
        }

        private void GridSearch_DoubleClick(object sender, EventArgs e)
        {
            this.button1_Click(null, null);
        }

        private void InitializeComponent()
        {
            this.GridSearch = new System.Windows.Forms.DataGrid();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridSearch
            // 
            this.GridSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.GridSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridSearch.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.GridSearch.Location = new System.Drawing.Point(0, 0);
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.PreferredRowHeight = 13;
            this.GridSearch.Size = new System.Drawing.Size(240, 254);
            this.GridSearch.TabIndex = 0;
            this.GridSearch.DoubleClick += new System.EventHandler(this.GridSearch_DoubleClick);
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Location = new System.Drawing.Point(3, 3);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(102, 33);
            this.Btn_Ok.TabIndex = 1;
            this.Btn_Ok.Text = "Tamam";
            this.Btn_Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(129, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(108, 33);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "Vazgeç";
            this.Btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Ok);
            this.panel1.Controls.Add(this.Btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 40);
            this.panel1.GotFocus += new System.EventHandler(this.panel1_GotFocus);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GridSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 254);
            // 
            // FrmArama
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmArama";
            this.Text = "FrmArama";
            this.Load += new System.EventHandler(this.FrmArama_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void panel1_GotFocus(object sender, EventArgs e)
        {
        }

        public string RetKey
        {
            get
            {
                return this.Pkey;
            }
        }

        public string RetKey2
        {
            get
            {
                return this.Pkey2;
            }
        }

        public string RetKey3
        {
            get
            {
                return this.Pkey3;
            }
        }

        public string RetKey4
        {
            get
            {
                return this.Pkey4;
            }
        }
    }
}

