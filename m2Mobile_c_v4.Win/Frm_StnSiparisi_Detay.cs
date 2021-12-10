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

    public class Frm_StnSiparisi_Detay : Form
    {
        private int _MaxSequence = 0;
        private string _MessageStr = "";
        private bool _Multi = false;
        private bool _MultiSelect = false;
        private ServiceResultOfListOfOrderDInfo _OrdList;
        private int _Procces = 1;
        private DataRow _r;
        private int _TypeFilter = 0;
        private string _xIrsaliyeNo = "";
        private string _xIrsaliyeSeri = "";
        private string _xIrsaliyeSira = "";
        private DateTime? _xIrsaliyeTarihi = null;
        private Button btn_delete;
        private Button btn_Detay_cancel;
        private Button btn_IrsaliyeOlustur;
        private CheckBox Chk_Delete;
        private IContainer components = null;
        private DataGrid dataGrid1;
        private DataSet1 dataSet1;
        private DateTimePicker Dt_IrsaliyeTarihi;
        private BindingSource dtDetaylarBindingSource;
        public DataRow dty_row;
        private FormParameters FormParam = new FormParameters();
        private Label label1;
        private DateTime lastKeyPress = DateTime.Now;
        private Label Lbl_State;
        private Label Lbl_WaybillDate;
        private Label Lbl_WaybillNumber;
        private Label Lbl_WaybillSerialOrder;
        private MainMenu mainMenu1;
        private System.Windows.Forms.Panel Panel;
        private TextBox textBox1;
        private TextBox Tx_IrsaliyeNo;
        private TextBox Tx_IrsaliyeSeri;
        private TextBox Tx_IrsaliyeSira;
        private TextBox txt_Barcode;

        public Frm_StnSiparisi_Detay(DataRow r)
        {
            this.InitializeComponent();
            //this.SetGridColumns();
            //this.getSatisDetayData(r);
            //this._r = r;
            //this._Multi = this._MultiSelect;
            //this._TypeFilter = 1;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this._Procces = 1;
            this.textBox1.Text = "";
            this.txt_Barcode.Text = "";
            this.textBox1.Focus();
            this.SetSquence();
        }

        private void btn_Detay_cancel_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void btn_IrsaliyeOlustur_Click(object sender, EventArgs e)
        {
            string str = "";
            string str2 = "";
            bool flag = false;
            foreach (DataRow row in this.dataSet1.Dt_Detaylar.Rows)
            {
                if (int.Parse(row["Ok_Miktarı"].ToString()) > 0)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                MessageBox.Show("Okuma Yoktur İrsaliye Oluşturulamaz");
            }
            else
            {
                try
                {
                    this._xIrsaliyeTarihi = new DateTime?(DateTime.Parse(this.Dt_IrsaliyeTarihi.Text.ToString()));
                    this._xIrsaliyeSira = this.Tx_IrsaliyeSira.Text.ToString();
                    this._xIrsaliyeSeri = this.Tx_IrsaliyeSeri.Text.ToString();
                    this._xIrsaliyeNo = this.Tx_IrsaliyeNo.Text.ToString();
                    if (this._xIrsaliyeSira == null)
                    {
                        this._xIrsaliyeSira = "";
                    }
                    if (this._xIrsaliyeNo == null)
                    {
                        this._xIrsaliyeNo = "";
                    }
                    if (!this._MultiSelect)
                    {
                        str = this.Tx_IrsaliyeSeri.Text.ToString();
                        str2 = this.Tx_IrsaliyeSira.Text.ToString();
                    }
                    SysDefinitions.CursorState("Wait");
                    ServiceRequestOfCoDocTraInSelectTemp param = new ServiceRequestOfCoDocTraInSelectTemp();
                    param.Token = Data._Token.Token;
                    param.Value = new CoDocTraInSelectTemp();
                    param.Value.SourceOrderDocTraId = int.Parse(this._r["DocTraId"].ToString());
                    param.Value.SourceAppLication = 0x66;
                    param.Value.SourceAppLication2 = 0x3e8;
                    ServiceResultOfInt32 coDocTraTemp = Data._UService.GetCoDocTraTemp(param);
                    if (!coDocTraTemp.Result)
                    {
                        throw new Exception(string.Format("Satınmalma Sipariş Hareket Koduna Ait İrsaliye Hareket Kodu Bulunamadı\n Stn.Sip.Hareket Ref.No:{0}", param.Value.SourceOrderDocTraId));
                    }
                    ServiceRequestOfWaybillInfo context = new ServiceRequestOfWaybillInfo();
                    context.Token = Data._Token.Token;
                    context.Value = new WaybillInfo();
                    context.Value.BelgeNo = this._xIrsaliyeNo;
                    context.Value.Date = Convert.ToDateTime(this._xIrsaliyeTarihi);
                    context.Value.DocTraId = int.Parse(coDocTraTemp.Value.ToString());
                    List<OrderDetailInfo> list = new List<OrderDetailInfo>();
                    foreach (OrderDInfo info2 in this._OrdList.Value)
                    {
                        OrderDetailInfo item = new OrderDetailInfo
                        {
                            ItemId = info2.DcardId,
                            LotId = info2.LotId,
                            PackageTypeId = info2.PackageTypeId,
                            QualityId = info2.QualityId,
                            WhouseId = Data._SelectedWareHouse,
                            Qty = info2.Qty,
                            OrderDetailId = info2.Id,
                            OrderMId = info2.MId
                        };
                        list.Add(item);
                    }
                    context.Value.OrderDetails = list.ToArray();
                    ServiceResultOfBoolean flag2 = Data._UService.SavePurchaseWaybill(context);
                    if (flag2.Result)
                    {
                        this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WalbillCreate");
                        MessageBox.Show(this._MessageStr);
                        SysDefinitions.CursorState("Default");
                        base.Close();
                    }
                    else
                    {
                        this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WalbillNotCreate") + Environment.NewLine + flag2.Message.ToString();
                        MessageBox.Show(this._MessageStr);
                        SysDefinitions.CursorState("Default");
                    }
                }
                catch (SystemException exception)
                {
                    this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WalbillNotCreate") + " " + Environment.NewLine + " " + exception.Message.ToString();
                    MessageBox.Show(this._MessageStr);
                    SysDefinitions.CursorState("Default");
                }
            }
        }

        private void ClearValues()
        {
            this.dataSet1.Dt_SatinAlma.Clear();
            this.dataGrid1.DataSource = null;
            this.dataGrid1.Refresh();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Frm_StnSiparisi_Detay_Load(object sender, EventArgs e)
        {

            #region MyRegion
            this.dataSet1 = new DataSet1();
           
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.Prefix = "";
            this.dataSet1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            
            this.dtDetaylarBindingSource.DataMember = "Dt_Detaylar";
            this.dtDetaylarBindingSource.DataSource = this.dataSet1;
            
            #endregion

            this.FormParam = Data.FParam("Frm_StnSiparisi_Detay");
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

        public void getSatisDetayData(DataRow r)
        {
            SysDefinitions.CursorState("Wait");
            ServiceRequestOfOrderDParam param = new ServiceRequestOfOrderDParam();
            param.Token = Data._Token.Token;
            param.Value = new OrderDParam();
            param.Value.PurchaseSales = 1;
            param.Value.OrderMId = int.Parse(r["RefNo"].ToString());
            param.Value.PageSize = 500;
            ServiceResultOfListOfOrderDInfo orderDInfo = Data._UService.GetOrderDInfo(param);
            this._OrdList = orderDInfo;
            if (orderDInfo.Result)
            {
                for (int i = 0; i < orderDInfo.Value.Length; i++)
                {
                    DataRow row = this.dataSet1.Dt_Detaylar.NewRow();
                    row["Dty_Kod"] = orderDInfo.Value[i].WhouseCode;
                    row["Dty_Adı"] = orderDInfo.Value[i].WhouseDesc;
                    row["Stk_Kod"] = orderDInfo.Value[i].DcardCode;
                    row["Stk_Adı"] = orderDInfo.Value[i].DcardName;
                    row["Sip_Sevk_Miktarı"] = orderDInfo.Value[i].QtyShipping;
                    row["Sip_Kal_Mik"] = orderDInfo.Value[i].QtyRemaining;
                    row["Ok_Miktarı"] = "0";
                    row["Dty_RefNo"] = orderDInfo.Value[i].Id;
                    row["DcardId"] = orderDInfo.Value[i].DcardId;
                    this.dataSet1.Dt_Detaylar.Rows.Add(row);
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
            this.dtDetaylarBindingSource = new BindingSource(this.components);
            this.dataGrid1 = new DataGrid();
            this.btn_IrsaliyeOlustur = new Button();
            this.btn_Detay_cancel = new Button();
            this.txt_Barcode = new TextBox();
            this.btn_delete = new Button();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.Chk_Delete = new CheckBox();
            this.Lbl_State = new Label();
            this.Panel = new Panel();
            this.Tx_IrsaliyeSira = new TextBox();
            this.Tx_IrsaliyeSeri = new TextBox();
            this.Tx_IrsaliyeNo = new TextBox();
            this.Dt_IrsaliyeTarihi = new DateTimePicker();
            this.Lbl_WaybillSerialOrder = new Label();
            this.Lbl_WaybillNumber = new Label();
            this.Lbl_WaybillDate = new Label();
            ((ISupportInitialize)this.dtDetaylarBindingSource).BeginInit();
           
            this.Panel.SuspendLayout();
            base.SuspendLayout();

            this.dataGrid1.BackgroundColor = Color.FromArgb(0x80, 0x80, 0x80);
            this.dataGrid1.DataSource = this.dtDetaylarBindingSource;
            this.dataGrid1.Location = new Point(0, 0x1d);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new Size(240, 170);
            this.dataGrid1.TabIndex = 0;
           
            this.btn_IrsaliyeOlustur.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_IrsaliyeOlustur.Location = new Point(0x84, 0xf6);
            this.btn_IrsaliyeOlustur.Name = "btn_IrsaliyeOlustur";
            this.btn_IrsaliyeOlustur.Size = new Size(0x5f, 0x26);
            this.btn_IrsaliyeOlustur.TabIndex = 9;
            this.btn_IrsaliyeOlustur.Text = "İrsaliye Oluştur";
            this.btn_IrsaliyeOlustur.Click += new EventHandler(this.btn_IrsaliyeOlustur_Click);
            this.btn_Detay_cancel.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_Detay_cancel.Location = new Point(9, 0xf6);
            this.btn_Detay_cancel.Name = "btn_Detay_cancel";
            this.btn_Detay_cancel.Size = new Size(0x3d, 0x26);
            this.btn_Detay_cancel.TabIndex = 8;
            this.btn_Detay_cancel.Text = "Vazge\x00e7";
            this.btn_Detay_cancel.Click += new EventHandler(this.btn_Detay_cancel_Click);
            this.txt_Barcode.ForeColor = SystemColors.InfoText;
            this.txt_Barcode.Location = new Point(0x8a, 5);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new Size(0x51, 0x15);
            this.txt_Barcode.TabIndex = 3;
            this.txt_Barcode.KeyDown += new KeyEventHandler(this.txt_Barcode_KeyDown);
            this.btn_delete.Location = new Point(0xdd, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new Size(0x10, 0x15);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "X";
            this.btn_delete.Click += new EventHandler(this.btn_delete_Click);
            this.textBox1.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.textBox1.Location = new Point(2, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0x11, 0x12);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.label1.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.label1.Location = new Point(0x15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1b, 0x11);
            this.label1.Text = "Adet";
            this.Chk_Delete.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Chk_Delete.Location = new Point(0x2f, 6);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new Size(50, 0x12);
            this.Chk_Delete.TabIndex = 2;
            this.Chk_Delete.Text = "Silme";
            this.Lbl_State.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_State.Location = new Point(0x61, 9);
            this.Lbl_State.Name = "Lbl_State";
            this.Lbl_State.Size = new Size(0x29, 0x11);
            this.Lbl_State.Text = "Barcode";
            this.Lbl_State.TextAlign = ContentAlignment.TopCenter;
            this.Panel.Controls.Add(this.Tx_IrsaliyeSira);
           
            this.Panel.Controls.Add(this.Tx_IrsaliyeSeri);
            this.Panel.Controls.Add(this.Lbl_State);
            this.Panel.Controls.Add(this.Tx_IrsaliyeNo);
            this.Panel.Controls.Add(this.Dt_IrsaliyeTarihi);
            this.Panel.Controls.Add(this.Chk_Delete);
            this.Panel.Controls.Add(this.Lbl_WaybillSerialOrder);
            this.Panel.Controls.Add(this.label1);
            this.Panel.Controls.Add(this.Lbl_WaybillNumber);
            this.Panel.Controls.Add(this.textBox1);
            this.Panel.Controls.Add(this.Lbl_WaybillDate);
            this.Panel.Controls.Add(this.btn_delete);
            this.Panel.Controls.Add(this.txt_Barcode);
            this.Panel.Controls.Add(this.btn_Detay_cancel);
            this.Panel.Controls.Add(this.btn_IrsaliyeOlustur);
            this.Panel.Controls.Add(this.dataGrid1);
            this.Panel.Dock = DockStyle.Top;
            this.Panel.Location = new Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new Size(240, 0x123);
            this.Tx_IrsaliyeSira.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Tx_IrsaliyeSira.Location = new Point(150, 0xe0);
            this.Tx_IrsaliyeSira.Name = "Tx_IrsaliyeSira";
            this.Tx_IrsaliyeSira.Size = new Size(0x4d, 0x13);
            this.Tx_IrsaliyeSira.TabIndex = 7;
            this.Tx_IrsaliyeSira.Tag = "";
            this.Tx_IrsaliyeSeri.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Tx_IrsaliyeSeri.Location = new Point(110, 0xe0);
            this.Tx_IrsaliyeSeri.Name = "Tx_IrsaliyeSeri";
            this.Tx_IrsaliyeSeri.Size = new Size(0x1f, 0x13);
            this.Tx_IrsaliyeSeri.TabIndex = 6;
            this.Tx_IrsaliyeSeri.Tag = "";
            this.Tx_IrsaliyeNo.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Tx_IrsaliyeNo.Location = new Point(0x35, 0xca);
            this.Tx_IrsaliyeNo.Name = "Tx_IrsaliyeNo";
            this.Tx_IrsaliyeNo.Size = new Size(0x35, 0x13);
            this.Tx_IrsaliyeNo.TabIndex = 4;
            this.Tx_IrsaliyeNo.Tag = "Lbl_WaybillNumber";
            this.Dt_IrsaliyeTarihi.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Dt_IrsaliyeTarihi.Format = DateTimePickerFormat.Custom;
            this.Dt_IrsaliyeTarihi.CustomFormat = "dd/MM/yy";
            this.Dt_IrsaliyeTarihi.Location = new Point(150, 0xca);
            this.Dt_IrsaliyeTarihi.Name = "Dt_IrsaliyeTarihi";
            this.Dt_IrsaliyeTarihi.Size = new Size(0x4d, 20);
            this.Dt_IrsaliyeTarihi.TabIndex = 5;
            this.Dt_IrsaliyeTarihi.Tag = "Lbl_WaybillDate";
            this.Lbl_WaybillSerialOrder.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_WaybillSerialOrder.Location = new Point(0x2b, 0xe3);
            this.Lbl_WaybillSerialOrder.Name = "Lbl_WaybillSerialOrder";
            this.Lbl_WaybillSerialOrder.Size = new Size(0x40, 0x10);
            this.Lbl_WaybillSerialOrder.Text = "Seri - Sıra No";
            this.Lbl_WaybillNumber.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Lbl_WaybillNumber.Location = new Point(9, 0xcd);
            this.Lbl_WaybillNumber.Name = "Lbl_WaybillNumber";
            this.Lbl_WaybillNumber.Size = new Size(0x27, 0x10);
            this.Lbl_WaybillNumber.Text = "İrs.No";
            this.Lbl_WaybillDate.Font = new Font("Tahoma", 8f, FontStyle.Regular);
            this.Lbl_WaybillDate.Location = new Point(0x71, 0xcd);
            this.Lbl_WaybillDate.Name = "Lbl_WaybillDate";
            this.Lbl_WaybillDate.Size = new Size(0x21, 0x10);
            this.Lbl_WaybillDate.Text = "Tarih";
            base.AutoScaleDimensions = new SizeF(0x60f, 0x60f);
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 0x123);
            base.ControlBox = false;
            base.Controls.Add(this.Panel);
            base.Name = "Frm_StnSiparisi_Detay";
            this.Text = "Satın Alma Sipariş Detayları";
            base.Location = new Point(0, 0);
            base.Load += new EventHandler(this.Frm_StnSiparisi_Detay_Load);
            ((ISupportInitialize)this.dtDetaylarBindingSource).EndInit();
            
            this.Panel.ResumeLayout(false);
            base.ResumeLayout(false);

           
        }

        private void ProccesDataBarcode(string _xCode)
        {
            try
            {
                IEnumerable<OrderDInfo> enumerable2;
                Func<OrderDInfo, bool> predicate = null;
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
                foreach (OrderDInfo info2 in this._OrdList.Value)
                {
                    if (info2.DcardId == _itemIdMan)
                    {
                        num3 += info2.QtyRemaining;
                        num4 += info2.Qty;
                    }
                }
                if (num2 > 0M)
                {
                    goto Label_029B;
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
            Label_01DA:
                if (predicate == null)
                {
                    predicate = p => p.DcardId == _itemIdMan;
                }
                IEnumerable<OrderDInfo> enumerable = this._OrdList.Value.Where<OrderDInfo>(predicate);
                foreach (OrderDInfo info3 in enumerable)
                {
                    if (info3.Qty >= num2)
                    {
                        info3.Qty -= num2;
                    }
                    else
                    {
                        num2 -= info3.Qty;
                        info3.Qty = 0M;
                        goto Label_01DA;
                    }
                }
                this.SetDataToGrid();
                return;
            Label_029B:
                enumerable2 = from p in this._OrdList.Value
                              where p.DcardId == _itemIdMan
                              select p;
                foreach (OrderDInfo info3 in enumerable2)
                {
                    if ((info3.DcardId == _itemIdMan) && (info3.Qty < info3.QtyRemaining))
                    {
                        if ((info3.Qty + num2) > info3.QtyRemaining)
                        {
                            num2 -= info3.QtyRemaining - info3.Qty;
                            info3.Qty += info3.QtyRemaining - info3.Qty;
                            goto Label_029B;
                        }
                        info3.Qty += num2;
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
            this.dataSet1.Dt_Detaylar.Rows.Clear();
            try
            {
                IOrderedEnumerable<OrderDInfo> enumerable = from p in this._OrdList.Value
                                                            orderby p.DcardId
                                                            select p;
                foreach (OrderDInfo info in enumerable)
                {
                    DataRow row = this.dataSet1.Dt_Detaylar.NewRow();
                    row["Dty_Kod"] = info.WhouseCode;
                    row["Dty_Adı"] = info.WhouseDesc;
                    row["Stk_Kod"] = info.DcardCode;
                    row["Stk_Adı"] = info.DcardName;
                    row["Sip_Sevk_Miktarı"] = info.QtyShipping;
                    row["Sip_Kal_Mik"] = info.QtyRemaining;
                    row["Ok_Miktarı"] = info.Qty;
                    row["Dty_RefNo"] = info.Id;
                    row["DcardId"] = info.DcardId;
                    this.dataSet1.Dt_Detaylar.Rows.Add(row);
                }
            }
            catch (SystemException)
            {
            }
            this.dataGrid1.DataSource = this.dataSet1.Dt_Detaylar;
            this.dataGrid1.Refresh();
        }

        private void SetGridColumns()
        {
            try
            {
                this.dataGrid1.TableStyles.Clear();
                DataGridTableStyle table = new DataGridTableStyle
                {
                    MappingName = "Dt_Detaylar"
                };
                DataGridColumnStyle column = new DataGridTextBoxColumn
                {
                    MappingName = "Dty_Kod",
                    HeaderText = "Dty Kod",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(column);
                DataGridColumnStyle style3 = new DataGridTextBoxColumn
                {
                    MappingName = "Dty_Adı",
                    HeaderText = "Dty_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(style3);
                DataGridColumnStyle style4 = new DataGridTextBoxColumn
                {
                    MappingName = "Stk_Kod",
                    HeaderText = "Stk_Kod",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.32))
                };
                table.GridColumnStyles.Add(style4);
                DataGridColumnStyle style5 = new DataGridTextBoxColumn
                {
                    MappingName = "Stk_Adı",
                    HeaderText = "Stk_Adı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.26))
                };
                table.GridColumnStyles.Add(style5);
                DataGridColumnStyle style6 = new DataGridTextBoxColumn
                {
                    MappingName = "Sip_Sevk_Miktarı",
                    HeaderText = "Sip_Sevk_Miktarı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.3))
                };
                table.GridColumnStyles.Add(style6);
                DataGridColumnStyle style7 = new DataGridTextBoxColumn
                {
                    MappingName = "Sip_Kal_Mik",
                    HeaderText = "Sip_Kal_Mik",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.31))
                };
                table.GridColumnStyles.Add(style7);
                DataGridColumnStyle style8 = new DataGridTextBoxColumn
                {
                    MappingName = "Ok_Miktarı",
                    HeaderText = "Ok_Miktarı",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.29))
                };
                table.GridColumnStyles.Add(style8);
                DataGridColumnStyle style9 = new DataGridTextBoxColumn
                {
                    MappingName = "Dty_RefNo",
                    HeaderText = "Dty_RefNo",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.28))
                };
                table.GridColumnStyles.Add(style9);
                DataGridColumnStyle style10 = new DataGridTextBoxColumn
                {
                    MappingName = "DcardId",
                    HeaderText = "DcardId",
                    Width = Convert.ToInt32((double)(this.dataGrid1.Width * 0.28))
                };
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
                if (this.textBox1.Text.ToString() != "")
                {
                    if (int.Parse(this.textBox1.Text.ToString()) <= 0)
                    {
                        this._MessageStr = SysDefinitions.ResMan.GetString("Msg_WrongValue");
                        MessageBox.Show(this._MessageStr);
                        this.textBox1.Text = "1";
                    }
                    if (int.Parse(this.textBox1.Text.ToString()) > int.Parse(this.FormParam.PRM_MAXAMOUNT.ToString()))
                    {
                        this._MessageStr = SysDefinitions.ResMan.GetString("Msg_MaxAmount");
                        MessageBox.Show(this._MessageStr);
                        this.textBox1.Text = "1";
                    }
                }
            }
            catch (SystemException exception)
            {
                throw new Exception(exception.Message);
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
            else if (this.dataSet1.Tables.Count == 0)
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

