using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using m2Mobile_c_v4.WebReference;
using m2Mobile_c_v4.Classes;

namespace m2Mobile_c_v4
{
    public partial class Frm_Ith_Gum_Detay : Form
    {
        private DateTime? _Belge_Tarihi = null;
        private string _BelNo = "";
        private string _docTraID;
        private string _HarKodu = "";
        private int _MaxSequence = 0;
        private string _MessageStr = "";
        private ServiceResultOfListOfTrmActualImpDOutParam _OrdLis;
        private int _Procces = 1;
        private DataRow _r;
        private int _TypeFilter = 0;
        private DateTimePicker Belge_Tarihi;
        private Button btn_delete;
        private Button btn_HareketKod;
        private Button btn_Ith_Depo_Gir;
        private Button button1;
        private CheckBox Chk_Delete;
        private IContainer components = null;
        private DataGrid dataGrid1;
        private DataSet2 dataSet2;
        public DataRow detay_row;
        private DataTable Dt = new DataTable();
        private BindingSource dTIthDetaylarBindingSource;
        private FormParameters FormParam = new FormParameters();
        private Label label1;
        private DateTime lastKeyPress = DateTime.Now;
        private Label Lbl_State;
        private Label Lbl_WaybillDate;
        private Label Lbl_WaybillSerialOrder;
        private MainMenu mainMenu1;
        private Panel Pnl_ith_gum;
        private TextBox textBox1;
        private TextBox Tx_BelNo;
        private TextBox Tx_HarKodu;
        private TextBox txt_Barcode;

        public Frm_Ith_Gum_Detay(DataRow r)
        {
            this.InitializeComponent();
            this.getIthalatCikisDetayData(r);
            this.SetGridColumns();
            this._r = r;
        }

        private void btn_Ith_Depo_Gir_Click(object sender, EventArgs e)
        {
            if (this.Tx_HarKodu.Text == "")
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Msg_SelectTras");
                MessageBox.Show(this._MessageStr);
            }
            else if (this.Tx_BelNo.Text == "")
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Lbl_DocNo");
                MessageBox.Show(this._MessageStr);
            }
            else if (this.Belge_Tarihi == null)
            {
                this._MessageStr = SysDefinitions.ResMan.GetString("Lbl_Date");
                MessageBox.Show(this._MessageStr);
            }
            else
            {
                List<TrmActualImpDOutParam> list = new List<TrmActualImpDOutParam>();
                foreach (TrmActualImpDOutParam param in this._OrdLis.Value)
                {
                    if (param.QtyBwh > 0M)
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
                    this._Belge_Tarihi = new DateTime?(DateTime.Parse(this.Belge_Tarihi.Text.ToString()));
                    this._BelNo = this.Tx_BelNo.Text;
                    this._HarKodu = this.Tx_HarKodu.Text;
                    SysDefinitions.CursorState("Wait");
                    try
                    {
                        ServiceRequestOfSaveBwhInMParam param2 = new ServiceRequestOfSaveBwhInMParam();
                        param2.Token = Data._Token.Token;
                        param2.Value = new SaveBwhInMParam();
                        param2.Value.ActualImpMId = int.Parse(this._r["Id"].ToString());
                        param2.Value.ActualDList = list.ToArray();
                        param2.Value.DocTraId = int.Parse(this._docTraID);
                        ServiceResultOfInt32 num = Data._UService.SaveBwhInM(param2);
                        if (num.Result)
                        {
                            this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WalbillCreate");
                            MessageBox.Show(this._MessageStr);
                            SysDefinitions.CursorState("Default");
                            base.Close();
                        }
                        else
                        {
                            this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WalbillNotCreate") + Environment.NewLine + num.Message.ToString();
                            MessageBox.Show(this._MessageStr);
                            SysDefinitions.CursorState("Default");
                        }
                    }
                    catch (Exception exception)
                    {
                        this._MessageStr = SysDefinitions.ResMan.GetString("Msg_SaveUnSucces");
                        MessageBox.Show(string.Format("Hata:{0} \n Erp Hata: {1}", this._MessageStr, exception.Message.ToString()));
                        SysDefinitions.CursorState("Default");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmArama arama = new FrmArama("DocTraIthGun", 0, 0, this._TypeFilter);
            arama.ShowDialog();
            if (arama.RetKey != null)
            {
                this._docTraID = arama.RetKey;
                this.Tx_HarKodu.Text = this._docTraID;
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

        private void Frm_Ith_Gum_Detay_Load(object sender, EventArgs e)
        {
            this.FormParam = Data.FParam("Frm_Ith_Gum_Detay");
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

        public void getIthalatCikisDetayData(DataRow r)
        {
            SysDefinitions.CursorState("Wait");
            ServiceRequestOfInt32 num = new ServiceRequestOfInt32();
            num.Token = Data._Token.Token;
            num.Value = int.Parse(r["Id"].ToString());
            ServiceResultOfListOfTrmActualImpDOutParam actualDImp = Data._UService.GetActualDImp(num);
            this._OrdLis = actualDImp;
            if (actualDImp.Result)
            {
                for (int i = 0; i < actualDImp.Value.Length; i++)
                {
                    this.detay_row = this.dataSet2.DT_Ith_Detaylar.NewRow();
                    this.detay_row["Depo_Kod"] = actualDImp.Value[i].WhouseCode;
                    this.detay_row["Depo_Adı"] = actualDImp.Value[i].WhouseDesc;
                    this.detay_row["Stok_Kod"] = actualDImp.Value[i].ItemCode;
                    this.detay_row["Stok_Adı"] = actualDImp.Value[i].ItemName;
                    this.detay_row["Gum_Cek_Mik"] = actualDImp.Value[i].QtyActual;
                    this.detay_row["Kalan_Mik"] = actualDImp.Value[i].QtyUncovered;
                    this.detay_row["Ok_Mik"] = "0";
                    this.detay_row["dId"] = actualDImp.Value[i].ActualImpDId;
                    this.detay_row["mId"] = actualDImp.Value[i].ActualImpMId;
                    this.dataSet2.DT_Ith_Detaylar.Rows.Add(this.detay_row);
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
            this.dTIthDetaylarBindingSource = new BindingSource(this.components);
            this.dataSet2 = new DataSet2();
            this.dataGrid1 = new DataGrid();
            this.btn_Ith_Depo_Gir = new Button();
            this.button1 = new Button();
            this.Lbl_State = new Label();
            this.Chk_Delete = new CheckBox();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.btn_delete = new Button();
            this.txt_Barcode = new TextBox();
            this.Pnl_ith_gum = new Panel();
            this.btn_HareketKod = new Button();
            this.Tx_BelNo = new TextBox();
            this.Tx_HarKodu = new TextBox();
            this.Lbl_WaybillSerialOrder = new Label();
            this.Belge_Tarihi = new DateTimePicker();
            this.Lbl_WaybillDate = new Label();
            ((ISupportInitialize)this.dTIthDetaylarBindingSource).BeginInit();
            this.dataSet2.BeginInit();
            this.Pnl_ith_gum.SuspendLayout();
            base.SuspendLayout();
            this.dTIthDetaylarBindingSource.DataMember = "DT_Ith_Detaylar";
            this.dTIthDetaylarBindingSource.DataSource = this.dataSet2;
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.Prefix = "";
            this.dataSet2.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.dataGrid1.BackgroundColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.dataGrid1.DataSource = this.dTIthDetaylarBindingSource;
            this.dataGrid1.Location = new Point(0, 0x1d);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new Size(240, 170);
            this.dataGrid1.TabIndex = 0;
            this.btn_Ith_Depo_Gir.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_Ith_Depo_Gir.Location = new Point(0x7e, 0x106);
            this.btn_Ith_Depo_Gir.Name = "btn_Ith_Depo_Gir";
            this.btn_Ith_Depo_Gir.Size = new Size(0x61, 0x1b);
            this.btn_Ith_Depo_Gir.TabIndex = 9;
            this.btn_Ith_Depo_Gir.Text = "İşyeri Depo Giriş";
            this.btn_Ith_Depo_Gir.Click += new EventHandler(this.btn_Ith_Depo_Gir_Click);
            this.button1.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.button1.Location = new Point(0x11, 0x106);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x61, 0x1b);
            this.button1.TabIndex = 8;
            this.button1.Text = "Vazge\x00e7";
            this.button1.Click += new EventHandler(this.button1_Click);
            this.Lbl_State.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_State.Location = new Point(0x61, 9);
            this.Lbl_State.Name = "Lbl_State";
            this.Lbl_State.Size = new Size(0x29, 0x11);
            this.Lbl_State.Text = "-";
            this.Lbl_State.TextAlign = ContentAlignment.TopCenter;
            this.Chk_Delete.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Chk_Delete.Location = new Point(0x2f, 6);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new Size(50, 0x12);
            this.Chk_Delete.TabIndex = 2;
            this.Chk_Delete.Text = "Silme";
            this.label1.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.label1.Location = new Point(0x15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1b, 0x11);
            this.label1.Text = "Adet";
            this.textBox1.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.textBox1.Location = new Point(2, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x11, 0x12);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.btn_delete.Location = new Point(0xdd, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new Size(0x10, 0x15);
            this.btn_delete.TabIndex = 0x10;
            this.btn_delete.Text = "X";
            this.txt_Barcode.ForeColor = SystemColors.InfoText;
            this.txt_Barcode.Location = new Point(0x8a, 5);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new Size(0x51, 0x15);
            this.txt_Barcode.TabIndex = 3;
            this.txt_Barcode.KeyDown += new KeyEventHandler(this.txt_Barcode_KeyDown);
            this.Pnl_ith_gum.Controls.Add(this.btn_HareketKod);
            this.Pnl_ith_gum.Controls.Add(this.Tx_BelNo);
            this.Pnl_ith_gum.Controls.Add(this.Tx_HarKodu);
            this.Pnl_ith_gum.Controls.Add(this.Lbl_WaybillSerialOrder);
            this.Pnl_ith_gum.Controls.Add(this.Belge_Tarihi);
            this.Pnl_ith_gum.Controls.Add(this.Lbl_WaybillDate);
            this.Pnl_ith_gum.Controls.Add(this.dataGrid1);
            this.Pnl_ith_gum.Controls.Add(this.btn_Ith_Depo_Gir);
            this.Pnl_ith_gum.Controls.Add(this.button1);
            this.Pnl_ith_gum.Controls.Add(this.Lbl_State);
            this.Pnl_ith_gum.Controls.Add(this.Chk_Delete);
            this.Pnl_ith_gum.Controls.Add(this.label1);
            this.Pnl_ith_gum.Controls.Add(this.textBox1);
            this.Pnl_ith_gum.Controls.Add(this.btn_delete);
            this.Pnl_ith_gum.Controls.Add(this.txt_Barcode);
            this.Pnl_ith_gum.Dock = DockStyle.Top;
            this.Pnl_ith_gum.Location = new Point(0, 0);
            this.Pnl_ith_gum.Name = "Pnl_ith_gum";
            this.Pnl_ith_gum.Size = new Size(240, 0x126);
            this.btn_HareketKod.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.btn_HareketKod.Location = new Point(0xd8, 0xe7);
            this.btn_HareketKod.Name = "btn_HareketKod";
            this.btn_HareketKod.Size = new Size(15, 0x12);
            this.btn_HareketKod.TabIndex = 7;
            this.btn_HareketKod.Text = "...";
            this.btn_HareketKod.Click += new EventHandler(this.button4_Click);
            this.Tx_BelNo.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Tx_BelNo.Location = new Point(0xba, 0xcd);
            this.Tx_BelNo.Name = "Tx_BelNo";
            this.Tx_BelNo.Size = new Size(0x2d, 0x13);
            this.Tx_BelNo.TabIndex = 5;
            this.Tx_BelNo.Tag = "";
            this.Tx_HarKodu.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Tx_HarKodu.Location = new Point(0x66, 0xe7);
            this.Tx_HarKodu.Name = "Tx_HarKodu";
            this.Tx_HarKodu.Size = new Size(0x68, 0x13);
            this.Tx_HarKodu.TabIndex = 6;
            this.Tx_HarKodu.Tag = "";
            this.Lbl_WaybillSerialOrder.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Lbl_WaybillSerialOrder.Location = new Point(9, 0xea);
            this.Lbl_WaybillSerialOrder.Name = "Lbl_WaybillSerialOrder";
            this.Lbl_WaybillSerialOrder.Size = new Size(0x52, 0x10);
            this.Lbl_WaybillSerialOrder.Text = "Hareket Kodu:";
            this.Belge_Tarihi.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Belge_Tarihi.Format = DateTimePickerFormat.Custom;
            this.Belge_Tarihi.CustomFormat = "dd/MM/yy";
            this.Belge_Tarihi.Location = new Point(0x66, 0xcd);
            this.Belge_Tarihi.Name = "Belge_Tarihi";
            this.Belge_Tarihi.Size = new Size(0x4d, 20);
            this.Belge_Tarihi.TabIndex = 4;
            this.Belge_Tarihi.Tag = "Lbl_WaybillDate";
            this.Lbl_WaybillDate.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Lbl_WaybillDate.Location = new Point(9, 0xd0);
            this.Lbl_WaybillDate.Name = "Lbl_WaybillDate";
            this.Lbl_WaybillDate.Size = new Size(90, 0x10);
            this.Lbl_WaybillDate.Text = "Belge Tarihi / No:";
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 0x126);
            base.Controls.Add(this.Pnl_ith_gum);
            base.Name = "Frm_Ith_Gum_Detay";
            this.Text = "Ithalat Depo Giriş Ekranı";
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Load += new EventHandler(this.Frm_Ith_Gum_Detay_Load);
            ((ISupportInitialize)this.dTIthDetaylarBindingSource).EndInit();
            this.dataSet2.EndInit();
            this.Pnl_ith_gum.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void Lbl_WaybillDate_ParentChanged(object sender, EventArgs e)
        {
        }

        private void ProccesDataBarcode(string _xCode)
        {
            try
            {
                IEnumerable<TrmActualImpDOutParam> enumerable2;
                Func<TrmActualImpDOutParam, bool> predicate = null;
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
                decimal num3 = 0M;
                decimal num4 = 0M;
                foreach (TrmActualImpDOutParam param in this._OrdLis.Value)
                {
                    if (param.ItemId == _itemIdMan)
                    {
                        num3 += param.QtyUncovered;
                        num4 += param.QtyBwh;
                    }
                }
                if (num2 > 0M)
                {
                    goto Label_0297;
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
            Label_01D6:
                if (predicate == null)
                {
                    predicate = p => p.ItemId == _itemIdMan;
                }
                IEnumerable<TrmActualImpDOutParam> enumerable = this._OrdLis.Value.Where<TrmActualImpDOutParam>(predicate);
                foreach (TrmActualImpDOutParam param2 in enumerable)
                {
                    if (param2.QtyBwh >= num2)
                    {
                        param2.QtyBwh -= num2;
                    }
                    else
                    {
                        num2 -= param2.QtyBwh;
                        param2.QtyBwh = 0M;
                        goto Label_01D6;
                    }
                }
                this.SetDataToGrid();
                return;
            Label_0297:
                enumerable2 = from p in this._OrdLis.Value
                              where p.ItemId == _itemIdMan
                              select p;
                foreach (TrmActualImpDOutParam param2 in enumerable2)
                {
                    if (param2.ItemId == _itemIdMan)
                    {
                        param2.QtyBwh += num2;
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
            this.dataSet2.DT_Ith_Detaylar.Rows.Clear();
            try
            {
                IOrderedEnumerable<TrmActualImpDOutParam> enumerable = from p in this._OrdLis.Value
                                                                       orderby p.ItemId
                                                                       select p;
                foreach (TrmActualImpDOutParam param in enumerable)
                {
                    DataRow row = this.dataSet2.DT_Ith_Detaylar.NewRow();
                    row["Depo_Kod"] = param.WhouseCode;
                    row["Depo_Adı"] = param.WhouseDesc;
                    row["Stok_Kod"] = param.ItemCode;
                    row["Stok_Adı"] = param.ItemName;
                    row["Gum_Cek_Mik"] = param.QtyActual;
                    row["Kalan_Mik"] = param.QtyUncovered;
                    row["Ok_Mik"] = param.QtyBwh;
                    row["dId"] = param.ActualImpDId;
                    row["mId"] = param.ActualImpMId;
                    this.dataSet2.DT_Ith_Detaylar.Rows.Add(row);
                }
            }
            catch (SystemException)
            {
            }
            this.dataGrid1.DataSource = this.dataSet2.DT_Ith_Detaylar;
            this.dataGrid1.Refresh();
        }

        private void SetGridColumns()
        {
            try
            {
                this.dataGrid1.TableStyles.Clear();
                DataGridTableStyle table = new DataGridTableStyle
                {
                    MappingName = "DT_Ith_Detaylar"
                };
                DataGridColumnStyle column = new DataGridTextBoxColumn
                {
                    MappingName = "Depo_Kod",
                    HeaderText = "Depo_Kod",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(column);
                DataGridColumnStyle style3 = new DataGridTextBoxColumn
                {
                    MappingName = "Depo_Adı",
                    HeaderText = "Depo_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.32))
                };
                table.GridColumnStyles.Add(style3);
                DataGridColumnStyle style4 = new DataGridTextBoxColumn
                {
                    MappingName = "Stok_Kod",
                    HeaderText = "Stok_Kod",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.26))
                };
                table.GridColumnStyles.Add(style4);
                DataGridColumnStyle style5 = new DataGridTextBoxColumn
                {
                    MappingName = "Stok_Adı",
                    HeaderText = "Stok_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.3))
                };
                table.GridColumnStyles.Add(style5);
                DataGridColumnStyle style6 = new DataGridTextBoxColumn
                {
                    MappingName = "Gum_Cek_Mik",
                    HeaderText = "Gum_Cek_Mik",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(style6);
                DataGridColumnStyle style7 = new DataGridTextBoxColumn
                {
                    MappingName = "Kalan_Mik",
                    HeaderText = "Kalan_Mik",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.29))
                };
                table.GridColumnStyles.Add(style7);
                DataGridColumnStyle style8 = new DataGridTextBoxColumn
                {
                    MappingName = "Ok_Mik",
                    HeaderText = "Ok_Mik",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.29))
                };
                table.GridColumnStyles.Add(style8);
                DataGridColumnStyle style9 = new DataGridTextBoxColumn
                {
                    MappingName = "dId",
                    HeaderText = "dId",
                    Width = -1
                };
                table.GridColumnStyles.Add(style9);
                DataGridColumnStyle style10 = new DataGridTextBoxColumn
                {
                    MappingName = "mId"
                };
                style9.HeaderText = "mId";
                style10.Width = -1;
                table.GridColumnStyles.Add(style10);
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
                    this._MessageStr = SysDefinitions.ResMan.GetString("Msg_MaxAmount");
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
            else
            {
                this.ProcessData(this.txt_Barcode.Text);
            }
        }
    }
}

