namespace m2Mobile_c_v4
{
    using m2Mobile_c_v4.Classes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using WebReference;

    public class Frm_Isemri_Malz_Cikis_Detayi : Form
    {
        private string _docIthDepo;
        private string _docIthHarKodu;
        private int _MaxSequence = 0;
        private string _MessageStr = "";
        private ServiceResultOfListOfTrmTransferDOutParam _OrdList;
        private int _Procces = 1;
        private DataRow _r;
        private int _TypeFilter = 0;
        private Button btn_delete;
        private Button btn_Isemri_TransferEt;
        private Button btn_Isemri_Vazgec;
        private Button button2;
        private Button button4;
        private CheckBox Chk_Delete;
        private IContainer components = null;
        private DataGrid dataGrid1;
        private DS_Is_Emri dS_Is_Emri;
        private DataTable Dt = new DataTable();
        private DateTimePicker Dt_DocDate;
        private BindingSource dtIsemriDetaylarıBindingSource;
        public DataRow dty_row;
        private FormParameters FormParam = new FormParameters();
        private Label label1;
        private DateTime lastKeyPress = DateTime.Now;
        private Label Lbl_SourceWh;
        private Label Lbl_State;
        private Label Lbl_TransCode;
        private Label Lbl_TransDate;
        private Panel panel1;
        private TextBox textBox1;
        private TextBox Tx_DocNo;
        private TextBox txt_Barcode;
        private TextBox TxTargetDepot;
        private TextBox TxTransCode;

        public Frm_Isemri_Malz_Cikis_Detayi(DataRow current_Row)
        {
            this.InitializeComponent();
            this.getIsEmriMalzemeDetayData(current_Row);
            this._r = current_Row;
            this.Tx_DocNo.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this._Procces = 1;
            this.textBox1.Text = "";
            this.txt_Barcode.Text = "";
            this.SetSquence();
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            this._Procces = 1;
            this.textBox1.Text = "1";
            this.txt_Barcode.Text = "";
            this.SetSquence();
        }

        private void btn_Isemri_TransferEt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TxTransCode.Text.ToString()))
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Msg_SelectTras");
                MessageBox.Show(this._MessageStr);
            }
            else if (string.IsNullOrEmpty(this.Tx_DocNo.Text.ToString()))
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Lbl_DocNo");
                MessageBox.Show(this._MessageStr);
            }
            else if (this.Dt_DocDate == null)
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Lbl_Date");
                MessageBox.Show(this._MessageStr);
            }
            else if (string.IsNullOrEmpty(this.TxTargetDepot.Text.ToString()))
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Msg_TargetDepot");
                MessageBox.Show(this._MessageStr);
            }
            else
            {
                List<TrmTransferDOutParam> list = new List<TrmTransferDOutParam>();
                foreach (TrmTransferDOutParam param in this._OrdList.Value)
                {
                    if (param.QtyTrailing > 0M)
                    {
                        list.Add(param);
                    }
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("Hi\x00e7 Barkod Okutmadınız");
                }
                else
                {
                    SysDefinitions.CursorState("Wait");
                    try
                    {
                        ServiceRequestOfTrmTransferMInParam param2 = new ServiceRequestOfTrmTransferMInParam();
                        param2.Token = Data._Token.Token;
                        param2.Value = new TrmTransferMInParam();
                        param2.Value.DocDate = DateTime.Parse(this.Dt_DocDate.Text.ToString());
                        param2.Value.DocNo = this.Tx_DocNo.Text.ToString();
                        param2.Value.WhouseId = Data._SelectedWareHouse;
                        param2.Value.TransferWhouseId = int.Parse(this.TxTargetDepot.Text.ToString());
                        param2.Value.DocTraId = int.Parse(this.TxTransCode.Text.ToString());
                        param2.Value.TransferD = list.ToArray();
                        param2.Value.WorderMId = int.Parse(this._r["Id"].ToString());
                        ServiceResultOfTrmTransferMOutParam param3 = Data._UService.TransferMCreate(param2);
                        if (param3.Result)
                        {
                            this._MessageStr = SysDefinitions.ResMan.GetString("Msg_SaveSucces");
                            MessageBox.Show(this._MessageStr);
                            SysDefinitions.CursorState("Default");
                            base.Close();
                        }
                        else
                        {
                            MessageBox.Show(param3.Message.ToString());
                            SysDefinitions.CursorState("Default");
                        }
                    }
                    catch (SystemException exception)
                    {
                        this._MessageStr = SysDefinitions.ResMan.GetString("Msg_SaveUnSucces");
                        MessageBox.Show(string.Format("Hata:{0} \n Erp Hata: {1}", this._MessageStr, exception.Message.ToString()));
                        SysDefinitions.CursorState("Default");
                    }
                }
            }
        }

        private void btn_Isemri_Vazgec_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmArama arama = new FrmArama("DocTraIsEmri_Depo", 0, 0, this._TypeFilter);
            arama.ShowDialog();
            if (arama.RetKey != null)
            {
                this._docIthDepo = arama.RetKey;
                this.TxTargetDepot.Text = this._docIthDepo;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FrmArama arama = new FrmArama("DocTraIsEmri_HarketKodu", 0, 0, this._TypeFilter);
            arama.ShowDialog();
            if (arama.RetKey != null)
            {
                this._docIthHarKodu = arama.RetKey;
                this.TxTransCode.Text = this._docIthHarKodu;
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

        private void Frm_Isemri_Malz_Cikis_Detayi_Load(object sender, EventArgs e)
        {
            this.FormParam = Data.FParam("Frm_Isemri_Malz_Cikis_Detayi");
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
            this.textBox1.Text = this.FormParam.PRM_DEFAULTAMOUNT.ToString();
            this.SetSquence();
            this.txt_Barcode.Focus();
        }

        public void getIsEmriMalzemeDetayData(DataRow r)
        {
            SysDefinitions.CursorState("Wait");
            ServiceRequestOfTrmTransferDInParam param = new ServiceRequestOfTrmTransferDInParam();
            param.Token = Data._Token.Token;
            param.Value = new TrmTransferDInParam();
            param.Value.PageSize = 0x3e8;
            param.Value.WhouseId = Data._SelectedWareHouse;
            param.Value.WorderMId = int.Parse(r["Id"].ToString());
            ServiceResultOfListOfTrmTransferDOutParam transferDMaterials = Data._UService.GetTransferDMaterials(param);
            this._OrdList = transferDMaterials;
            if (transferDMaterials.Result)
            {
                for (int i = 0; i < transferDMaterials.Value.Length; i++)
                {
                    DataRow row = this.dS_Is_Emri.Dt_Isemri_Detayları.NewRow();
                    row["Stok_Adı"] = transferDMaterials.Value[i].ItemName;
                    row["Stok_Kodu"] = transferDMaterials.Value[i].ItemCode;
                    row["Net_Miktar"] = transferDMaterials.Value[i].QtyNeeded;
                    row["Ok_Miktar"] = "0";
                    row["Tip"] = transferDMaterials.Value[i].BomLineTypeName;
                    this.dS_Is_Emri.Dt_Isemri_Detayları.Rows.Add(row);
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
            this.dtIsemriDetaylarıBindingSource = new BindingSource(this.components);
            this.dS_Is_Emri = new DS_Is_Emri();
            this.dataGrid1 = new DataGrid();
            this.btn_Isemri_TransferEt = new Button();
            this.btn_Isemri_Vazgec = new Button();
            this.Chk_Delete = new CheckBox();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.btn_delete = new Button();
            this.txt_Barcode = new TextBox();
            this.Lbl_State = new Label();
            this.panel1 = new Panel();
            this.TxTargetDepot = new TextBox();
            this.button2 = new Button();
            this.Lbl_SourceWh = new Label();
            this.Tx_DocNo = new TextBox();
            this.Lbl_TransDate = new Label();
            this.Dt_DocDate = new DateTimePicker();
            this.TxTransCode = new TextBox();
            this.Lbl_TransCode = new Label();
            this.button4 = new Button();
            MainMenu menu = new MainMenu();
            ((ISupportInitialize)this.dtIsemriDetaylarıBindingSource).BeginInit();
            this.dS_Is_Emri.BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dtIsemriDetaylarıBindingSource.DataMember = "Dt_Isemri_Detayları";
            this.dtIsemriDetaylarıBindingSource.DataSource = this.dS_Is_Emri;
            this.dS_Is_Emri.DataSetName = "DS_Is_Emri";
            this.dS_Is_Emri.Prefix = "";
            this.dS_Is_Emri.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.dataGrid1.BackgroundColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.dataGrid1.DataSource = this.dtIsemriDetaylarıBindingSource;
            this.dataGrid1.Location = new Point(0, 0x1d);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new Size(240, 170);
            this.dataGrid1.TabIndex = 0;
            this.btn_Isemri_TransferEt.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_Isemri_TransferEt.Location = new Point(0xa2, 0xf9);
            this.btn_Isemri_TransferEt.Name = "btn_Isemri_TransferEt";
            this.btn_Isemri_TransferEt.Size = new Size(0x42, 0x1f);
            this.btn_Isemri_TransferEt.TabIndex = 11;
            this.btn_Isemri_TransferEt.Text = "Transfer Et";
            this.btn_Isemri_TransferEt.Click += new EventHandler(this.btn_Isemri_TransferEt_Click);
            this.btn_Isemri_Vazgec.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_Isemri_Vazgec.Location = new Point(11, 0xf9);
            this.btn_Isemri_Vazgec.Name = "btn_Isemri_Vazgec";
            this.btn_Isemri_Vazgec.Size = new Size(0x42, 0x1f);
            this.btn_Isemri_Vazgec.TabIndex = 10;
            this.btn_Isemri_Vazgec.Text = "Vazge\x00e7";
            this.btn_Isemri_Vazgec.Click += new EventHandler(this.btn_Isemri_Vazgec_Click);
            this.Chk_Delete.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Chk_Delete.Location = new Point(0x2f, 6);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new Size(50, 0x12);
            this.Chk_Delete.TabIndex = 2;
            this.Chk_Delete.Text = "Silme";
            this.label1.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.label1.Location = new Point(0x15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x17, 0x11);
            this.label1.Text = "Adet";
            this.textBox1.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.textBox1.Location = new Point(2, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x11, 0x12);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            this.btn_delete.Location = new Point(0xdd, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new Size(0x10, 0x15);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "X";
            this.btn_delete.Click += new EventHandler(this.btn_delete_Click_1);
            this.txt_Barcode.ForeColor = SystemColors.InfoText;
            this.txt_Barcode.Location = new Point(0x8a, 5);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new Size(0x51, 0x15);
            this.txt_Barcode.TabIndex = 3;
            this.txt_Barcode.KeyDown += new KeyEventHandler(this.txt_Barcode_KeyDown);
            this.Lbl_State.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_State.Location = new Point(0x61, 9);
            this.Lbl_State.Name = "Lbl_State";
            this.Lbl_State.Size = new Size(0x29, 0x11);
            this.Lbl_State.Text = "-";
            this.Lbl_State.TextAlign = ContentAlignment.TopCenter;
            this.panel1.Controls.Add(this.TxTargetDepot);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Lbl_SourceWh);
            this.panel1.Controls.Add(this.Tx_DocNo);
            this.panel1.Controls.Add(this.Lbl_TransDate);
            this.panel1.Controls.Add(this.Dt_DocDate);
            this.panel1.Controls.Add(this.TxTransCode);
            this.panel1.Controls.Add(this.Lbl_TransCode);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.Lbl_State);
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Controls.Add(this.Chk_Delete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.txt_Barcode);
            this.panel1.Controls.Add(this.btn_Isemri_Vazgec);
            this.panel1.Controls.Add(this.btn_Isemri_TransferEt);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(240, 0x126);
            this.TxTargetDepot.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.TxTargetDepot.Location = new Point(0xa3, 0xdf);
            this.TxTargetDepot.Name = "TxTargetDepot";
            this.TxTargetDepot.Size = new Size(0x30, 0x12);
            this.TxTargetDepot.TabIndex = 8;
            this.button2.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.button2.Location = new Point(0xd5, 0xdf);
            this.button2.Name = "button2";
            this.button2.Size = new Size(15, 0x12);
            this.button2.TabIndex = 9;
            this.button2.Text = "...";
            this.button2.Click += new EventHandler(this.button2_Click_1);
            this.Lbl_SourceWh.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_SourceWh.ForeColor = Color.Black;
            this.Lbl_SourceWh.Location = new Point(0x86, 0xe2);
            this.Lbl_SourceWh.Name = "Lbl_SourceWh";
            this.Lbl_SourceWh.Size = new Size(0x1b, 0x12);
            this.Lbl_SourceWh.Text = "Depo";
            this.Lbl_SourceWh.TextAlign = ContentAlignment.TopRight;
            this.Tx_DocNo.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Tx_DocNo.Location = new Point(0x84, 0xca);
            this.Tx_DocNo.Name = "Tx_DocNo";
            this.Tx_DocNo.Size = new Size(0x60, 0x12);
            this.Tx_DocNo.TabIndex = 5;
            this.Lbl_TransDate.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_TransDate.ForeColor = Color.Black;
            this.Lbl_TransDate.Location = new Point(11, 0xcd);
            this.Lbl_TransDate.Name = "Lbl_TransDate";
            this.Lbl_TransDate.Size = new Size(0x29, 15);
            this.Lbl_TransDate.Text = "Tarih/No";
            this.Lbl_TransDate.TextAlign = ContentAlignment.TopRight;
            this.Dt_DocDate.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Dt_DocDate.Format = DateTimePickerFormat.Custom;
            this.Dt_DocDate.CustomFormat = "dd/MM/yy";
            this.Dt_DocDate.Location = new Point(0x3b, 0xca);
            this.Dt_DocDate.Name = "Dt_DocDate";
            this.Dt_DocDate.Size = new Size(0x42, 0x13);
            this.Dt_DocDate.TabIndex = 4;
            this.TxTransCode.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.TxTransCode.Location = new Point(0x3e, 0xdf);
            this.TxTransCode.Name = "TxTransCode";
            this.TxTransCode.Size = new Size(0x30, 0x12);
            this.TxTransCode.TabIndex = 6;
            this.Lbl_TransCode.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_TransCode.ForeColor = Color.Black;
            this.Lbl_TransCode.Location = new Point(11, 0xe2);
            this.Lbl_TransCode.Name = "Lbl_TransCode";
            this.Lbl_TransCode.Size = new Size(0x2b, 0x12);
            this.Lbl_TransCode.Text = "Har.Kodu";
            this.Lbl_TransCode.TextAlign = ContentAlignment.TopRight;
            this.button4.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.button4.Location = new Point(0x71, 0xdf);
            this.button4.Name = "button4";
            this.button4.Size = new Size(15, 0x12);
            this.button4.TabIndex = 7;
            this.button4.Text = "...";
            this.button4.Click += new EventHandler(this.button4_Click_1);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 0x126);
            base.ControlBox = false;
            base.Controls.Add(this.panel1);
            base.Name = "Frm_Isemri_Malz_Cikis_Detayi";
            this.Text = "İşemrine Bağlı Malz. Detayları";
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Load += new EventHandler(this.Frm_Isemri_Malz_Cikis_Detayi_Load);
            ((ISupportInitialize)this.dtIsemriDetaylarıBindingSource).EndInit();
            this.dS_Is_Emri.EndInit();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void ProccesDataBarcode(string _xCode)
        {
            try
            {
                IEnumerable<TrmTransferDOutParam> enumerable3;
                Func<TrmTransferDOutParam, bool> predicate = null;
                int _itemIdMan = 0;
                ServiceResultOfItemInfo info = Data._SrvcItemInfo(_xCode);
                if (!info.Result)
                {
                    ServiceResultOfInt32 num = Data._SrvcItemInfoUseItemID(_xCode);
                    if (!num.Result)
                    {
                        MessageBox.Show(info.Message.ToString());
                        return;
                    }
                    _itemIdMan = num.Value;
                }
                else
                {
                    _itemIdMan = info.Value.Id;
                }
                decimal num2 = int.Parse(this.textBox1.Text.ToString()) * ((this.Chk_Delete.CheckState == CheckState.Checked) ? -1 : 1);
                IEnumerable<TrmTransferDOutParam> source = from t in this._OrdList.Value
                                                           where t.ItemId == _itemIdMan
                                                           select t;
                decimal num3 = source.Sum<TrmTransferDOutParam>((Func<TrmTransferDOutParam, decimal>)(t => t.QtyNeeded));
                decimal num4 = source.Sum<TrmTransferDOutParam>((Func<TrmTransferDOutParam, decimal>)(t => t.QtyTrailing));
                if (num2 > 0M)
                {
                    goto Label_028F;
                }
                if (decimal.Parse(num4.ToString()) == 0M)
                {
                    this._MessageStr = SysDefinitions.ResMan.GetString("Msg_NoRecordDelete");
                    MessageBox.Show(this._MessageStr);
                    return;
                }
                if (decimal.Parse(num4.ToString()) < (num2 * -1M))
                {
                    this._MessageStr = SysDefinitions.ResMan.GetString("Msg_MorePieces");
                    MessageBox.Show(this._MessageStr);
                    return;
                }
                num2 *= -1M;
            Label_01CE:
                if (predicate == null)
                {
                    predicate = p => p.ItemId == _itemIdMan;
                }
                IEnumerable<TrmTransferDOutParam> enumerable2 = this._OrdList.Value.Where<TrmTransferDOutParam>(predicate);
                foreach (TrmTransferDOutParam param in enumerable2)
                {
                    if (param.QtyTrailing >= num2)
                    {
                        param.QtyTrailing -= num2;
                    }
                    else
                    {
                        num2 -= param.QtyTrailing;
                        param.QtyTrailing = 0M;
                        goto Label_01CE;
                    }
                }
                this.SetDataToGrid();
                return;
            Label_028F:
                enumerable3 = from p in this._OrdList.Value
                              where p.ItemId == _itemIdMan
                              select p;
                foreach (TrmTransferDOutParam param in enumerable3)
                {
                    if (param.ItemId == _itemIdMan)
                    {
                        if ((param.QtyTrailing + num2) > param.QtyNeeded)
                        {
                            num2 -= param.QtyNeeded - param.QtyTrailing;
                            param.QtyTrailing += param.QtyTrailing - param.QtyTrailing;
                            goto Label_028F;
                        }
                        param.QtyTrailing += num2;
                        break;
                    }
                }
                this.SetDataToGrid();
            }
            catch (SystemException)
            {
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

        private void SetDataToGrid()
        {
            this.dS_Is_Emri.Dt_Isemri_Detayları.Rows.Clear();
            try
            {
                IOrderedEnumerable<TrmTransferDOutParam> enumerable = from p in this._OrdList.Value
                                                                      orderby p.ItemId
                                                                      select p;
                foreach (TrmTransferDOutParam param in enumerable)
                {
                    DataRow row = this.dS_Is_Emri.Dt_Isemri_Detayları.NewRow();
                    row["Tip"] = param.BomLineTypeName;
                    row["Stok_Adı"] = param.ItemName;
                    row["Stok_Kodu"] = param.ItemCode;
                    row["Net_Miktar"] = param.QtyNeeded;
                    row["Ok_Miktar"] = param.QtyTrailing;
                    this.dS_Is_Emri.Dt_Isemri_Detayları.Rows.Add(row);
                }
            }
            catch (SystemException)
            {
            }
            this.dataGrid1.DataSource = this.dS_Is_Emri.Dt_Isemri_Detayları;
            this.dataGrid1.Refresh();
        }

        private void SetGridColumns()
        {
            try
            {
                this.dataGrid1.TableStyles.Clear();
                DataGridTableStyle table = new DataGridTableStyle
                {
                    MappingName = "Dt_Isemri_Detayları"
                };
                DataGridColumnStyle column = new DataGridTextBoxColumn
                {
                    MappingName = "Stok_Adı",
                    HeaderText = "Stok_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.32))
                };
                table.GridColumnStyles.Add(column);
                DataGridColumnStyle style3 = new DataGridTextBoxColumn
                {
                    MappingName = "Stok_Kodu",
                    HeaderText = "Stok_Kodu",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.26))
                };
                table.GridColumnStyles.Add(style3);
                DataGridColumnStyle style4 = new DataGridTextBoxColumn
                {
                    MappingName = "Net_Miktar",
                    HeaderText = "Net_Miktar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.3))
                };
                table.GridColumnStyles.Add(style4);
                DataGridColumnStyle style5 = new DataGridTextBoxColumn
                {
                    MappingName = "Ok_Miktar",
                    HeaderText = "Ok_Miktar",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(style5);
                DataGridColumnStyle style6 = new DataGridTextBoxColumn
                {
                    MappingName = "Tip",
                    HeaderText = "Tip",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(style6);
                this.dataGrid1.TableStyles.Add(table);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((this.textBox1.Text.ToString() != "") && (int.Parse(this.textBox1.Text.ToString()) > 0)) && (int.Parse(this.textBox1.Text.ToString()) > int.Parse(this.FormParam.PRM_MAXAMOUNT.ToString())))
                {
                    SysDefinitions.CursorState("Default");
                    MessageBox.Show(this._MessageStr);
                    this.textBox1.Text = "1";
                }
            }
            catch (SystemException)
            {
            }
        }

        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                if (!this.FormParam.PRM_ALLOWMANUELENTRY)
                {
                    TimeSpan span = (TimeSpan)(DateTime.Now - this.lastKeyPress);
                    if (span.TotalMilliseconds > Data._BarcodeDelay)
                    {
                        this.txt_Barcode.Text = "";
                        e.Handled = true;
                    }
                    this.lastKeyPress = DateTime.Now;
                }
            }
            else if (this.dS_Is_Emri.Tables.Count == 0)
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Msg_SelectOrder");
                MessageBox.Show(this._MessageStr);
                this.txt_Barcode.Text = "";
            }
            else
            {
                this.ProcessData(this.txt_Barcode.Text);
            }
        }
    }
}

