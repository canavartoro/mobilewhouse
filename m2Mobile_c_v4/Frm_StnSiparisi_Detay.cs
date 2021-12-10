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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.dtDetaylarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btn_IrsaliyeOlustur = new System.Windows.Forms.Button();
            this.btn_Detay_cancel = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Chk_Delete = new System.Windows.Forms.CheckBox();
            this.Lbl_State = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.Tx_IrsaliyeSira = new System.Windows.Forms.TextBox();
            this.Tx_IrsaliyeSeri = new System.Windows.Forms.TextBox();
            this.Tx_IrsaliyeNo = new System.Windows.Forms.TextBox();
            this.Dt_IrsaliyeTarihi = new System.Windows.Forms.DateTimePicker();
            this.Lbl_WaybillSerialOrder = new System.Windows.Forms.Label();
            this.Lbl_WaybillNumber = new System.Windows.Forms.Label();
            this.Lbl_WaybillDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtDetaylarBindingSource)).BeginInit();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataSource = this.dtDetaylarBindingSource;
            this.dataGrid1.Location = new System.Drawing.Point(0, 29);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 170);
            this.dataGrid1.TabIndex = 0;
            // 
            // btn_IrsaliyeOlustur
            // 
            this.btn_IrsaliyeOlustur.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_IrsaliyeOlustur.Location = new System.Drawing.Point(132, 246);
            this.btn_IrsaliyeOlustur.Name = "btn_IrsaliyeOlustur";
            this.btn_IrsaliyeOlustur.Size = new System.Drawing.Size(95, 38);
            this.btn_IrsaliyeOlustur.TabIndex = 9;
            this.btn_IrsaliyeOlustur.Text = "İrsaliye Oluştur";
            this.btn_IrsaliyeOlustur.Click += new System.EventHandler(this.btn_IrsaliyeOlustur_Click);
            // 
            // btn_Detay_cancel
            // 
            this.btn_Detay_cancel.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btn_Detay_cancel.Location = new System.Drawing.Point(9, 246);
            this.btn_Detay_cancel.Name = "btn_Detay_cancel";
            this.btn_Detay_cancel.Size = new System.Drawing.Size(61, 38);
            this.btn_Detay_cancel.TabIndex = 8;
            this.btn_Detay_cancel.Text = "Vazgeç";
            this.btn_Detay_cancel.Click += new System.EventHandler(this.btn_Detay_cancel_Click);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txt_Barcode.Location = new System.Drawing.Point(138, 5);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(81, 21);
            this.txt_Barcode.TabIndex = 3;
            this.txt_Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Barcode_KeyDown);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(221, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(16, 21);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "X";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(2, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(17, 18);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.Text = "Adet";
            // 
            // Chk_Delete
            // 
            this.Chk_Delete.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Chk_Delete.Location = new System.Drawing.Point(47, 6);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new System.Drawing.Size(50, 18);
            this.Chk_Delete.TabIndex = 2;
            this.Chk_Delete.Text = "Silme";
            // 
            // Lbl_State
            // 
            this.Lbl_State.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_State.Location = new System.Drawing.Point(97, 9);
            this.Lbl_State.Name = "Lbl_State";
            this.Lbl_State.Size = new System.Drawing.Size(41, 17);
            this.Lbl_State.Text = "Barcode";
            this.Lbl_State.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Panel
            // 
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
            this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(240, 291);
            // 
            // Tx_IrsaliyeSira
            // 
            this.Tx_IrsaliyeSira.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Tx_IrsaliyeSira.Location = new System.Drawing.Point(150, 224);
            this.Tx_IrsaliyeSira.Name = "Tx_IrsaliyeSira";
            this.Tx_IrsaliyeSira.Size = new System.Drawing.Size(77, 19);
            this.Tx_IrsaliyeSira.TabIndex = 7;
            this.Tx_IrsaliyeSira.Tag = "";
            // 
            // Tx_IrsaliyeSeri
            // 
            this.Tx_IrsaliyeSeri.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Tx_IrsaliyeSeri.Location = new System.Drawing.Point(110, 224);
            this.Tx_IrsaliyeSeri.Name = "Tx_IrsaliyeSeri";
            this.Tx_IrsaliyeSeri.Size = new System.Drawing.Size(31, 19);
            this.Tx_IrsaliyeSeri.TabIndex = 6;
            this.Tx_IrsaliyeSeri.Tag = "";
            // 
            // Tx_IrsaliyeNo
            // 
            this.Tx_IrsaliyeNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Tx_IrsaliyeNo.Location = new System.Drawing.Point(53, 202);
            this.Tx_IrsaliyeNo.Name = "Tx_IrsaliyeNo";
            this.Tx_IrsaliyeNo.Size = new System.Drawing.Size(53, 19);
            this.Tx_IrsaliyeNo.TabIndex = 4;
            this.Tx_IrsaliyeNo.Tag = "Lbl_WaybillNumber";
            // 
            // Dt_IrsaliyeTarihi
            // 
            this.Dt_IrsaliyeTarihi.CustomFormat = "dd/MM/yy";
            this.Dt_IrsaliyeTarihi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Dt_IrsaliyeTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dt_IrsaliyeTarihi.Location = new System.Drawing.Point(150, 202);
            this.Dt_IrsaliyeTarihi.Name = "Dt_IrsaliyeTarihi";
            this.Dt_IrsaliyeTarihi.Size = new System.Drawing.Size(77, 20);
            this.Dt_IrsaliyeTarihi.TabIndex = 5;
            this.Dt_IrsaliyeTarihi.Tag = "Lbl_WaybillDate";
            // 
            // Lbl_WaybillSerialOrder
            // 
            this.Lbl_WaybillSerialOrder.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_WaybillSerialOrder.Location = new System.Drawing.Point(43, 227);
            this.Lbl_WaybillSerialOrder.Name = "Lbl_WaybillSerialOrder";
            this.Lbl_WaybillSerialOrder.Size = new System.Drawing.Size(64, 16);
            this.Lbl_WaybillSerialOrder.Text = "Seri - Sıra No";
            // 
            // Lbl_WaybillNumber
            // 
            this.Lbl_WaybillNumber.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_WaybillNumber.Location = new System.Drawing.Point(9, 205);
            this.Lbl_WaybillNumber.Name = "Lbl_WaybillNumber";
            this.Lbl_WaybillNumber.Size = new System.Drawing.Size(39, 16);
            this.Lbl_WaybillNumber.Text = "İrs.No";
            // 
            // Lbl_WaybillDate
            // 
            this.Lbl_WaybillDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Lbl_WaybillDate.Location = new System.Drawing.Point(113, 205);
            this.Lbl_WaybillDate.Name = "Lbl_WaybillDate";
            this.Lbl_WaybillDate.Size = new System.Drawing.Size(33, 16);
            this.Lbl_WaybillDate.Text = "Tarih";
            // 
            // Frm_StnSiparisi_Detay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 291);
            this.ControlBox = false;
            this.Controls.Add(this.Panel);
            this.Name = "Frm_StnSiparisi_Detay";
            this.Text = "Satın Alma Sipariş Detayları";
            this.Load += new System.EventHandler(this.Frm_StnSiparisi_Detay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtDetaylarBindingSource)).EndInit();
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);

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

