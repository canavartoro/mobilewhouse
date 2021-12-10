namespace m2Mobile_c_v4
{
    partial class Frm_Irsaliye
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_Waybill = new System.Windows.Forms.Label();
            this.Lbl_ShippingType = new System.Windows.Forms.Label();
            this.Lbl_ShippingCode = new System.Windows.Forms.Label();
            this.Lbl_WaybillCode = new System.Windows.Forms.Label();
            this.Lbl_WaybillDate = new System.Windows.Forms.Label();
            this.Lbl_WaybillNumber = new System.Windows.Forms.Label();
            this.Lbl_WaybillSerialOrder = new System.Windows.Forms.Label();
            this.Cbo_Nakliye = new System.Windows.Forms.ComboBox();
            this.Tx_IrsaliyeKodu = new System.Windows.Forms.TextBox();
            this.Dt_IrsaliyeTarihi = new System.Windows.Forms.DateTimePicker();
            this.Tx_IrsaliyeNo = new System.Windows.Forms.TextBox();
            this.Tx_IrsaliyeSeri = new System.Windows.Forms.TextBox();
            this.Tx_IrsaliyeSira = new System.Windows.Forms.TextBox();
            this.Btn_MakeWayBill = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Cbo_NakliyeKod = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Waybill
            // 
            this.Lbl_Waybill.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.Lbl_Waybill.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Waybill.Location = new System.Drawing.Point(73, 22);
            this.Lbl_Waybill.Name = "Lbl_Waybill";
            this.Lbl_Waybill.Size = new System.Drawing.Size(100, 20);
            this.Lbl_Waybill.Text = "İrsaliye Yapma";
            this.Lbl_Waybill.ParentChanged += new System.EventHandler(this.Lbl_Waybill_ParentChanged);
            // 
            // Lbl_ShippingType
            // 
            this.Lbl_ShippingType.Location = new System.Drawing.Point(3, 51);
            this.Lbl_ShippingType.Name = "Lbl_ShippingType";
            this.Lbl_ShippingType.Size = new System.Drawing.Size(83, 20);
            this.Lbl_ShippingType.Text = "Nakliye Şekli";
            // 
            // Lbl_ShippingCode
            // 
            this.Lbl_ShippingCode.Location = new System.Drawing.Point(3, 79);
            this.Lbl_ShippingCode.Name = "Lbl_ShippingCode";
            this.Lbl_ShippingCode.Size = new System.Drawing.Size(83, 20);
            this.Lbl_ShippingCode.Text = "Nakliye Kodu";
            // 
            // Lbl_WaybillCode
            // 
            this.Lbl_WaybillCode.Location = new System.Drawing.Point(3, 107);
            this.Lbl_WaybillCode.Name = "Lbl_WaybillCode";
            this.Lbl_WaybillCode.Size = new System.Drawing.Size(83, 20);
            this.Lbl_WaybillCode.Text = "İrsaliye Kodu";
            // 
            // Lbl_WaybillDate
            // 
            this.Lbl_WaybillDate.Location = new System.Drawing.Point(3, 139);
            this.Lbl_WaybillDate.Name = "Lbl_WaybillDate";
            this.Lbl_WaybillDate.Size = new System.Drawing.Size(83, 20);
            this.Lbl_WaybillDate.Text = "İrsaliye Tarihi";
            this.Lbl_WaybillDate.ParentChanged += new System.EventHandler(this.Lbl_WaybillDate_ParentChanged);
            // 
            // Lbl_WaybillNumber
            // 
            this.Lbl_WaybillNumber.Location = new System.Drawing.Point(2, 168);
            this.Lbl_WaybillNumber.Name = "Lbl_WaybillNumber";
            this.Lbl_WaybillNumber.Size = new System.Drawing.Size(83, 20);
            this.Lbl_WaybillNumber.Text = "İrsaliye No";
            this.Lbl_WaybillNumber.ParentChanged += new System.EventHandler(this.Lbl_WaybillNumber_ParentChanged);
            // 
            // Lbl_WaybillSerialOrder
            // 
            this.Lbl_WaybillSerialOrder.Location = new System.Drawing.Point(3, 196);
            this.Lbl_WaybillSerialOrder.Name = "Lbl_WaybillSerialOrder";
            this.Lbl_WaybillSerialOrder.Size = new System.Drawing.Size(83, 20);
            this.Lbl_WaybillSerialOrder.Text = "Seri - Sıra No";
            this.Lbl_WaybillSerialOrder.ParentChanged += new System.EventHandler(this.Lbl_WaybillSerialOrder_ParentChanged);
            // 
            // Cbo_Nakliye
            // 
            this.Cbo_Nakliye.Location = new System.Drawing.Point(92, 49);
            this.Cbo_Nakliye.Name = "Cbo_Nakliye";
            this.Cbo_Nakliye.Size = new System.Drawing.Size(145, 22);
            this.Cbo_Nakliye.TabIndex = 12;
            this.Cbo_Nakliye.Tag = "Lbl_ShippingType";
            this.Cbo_Nakliye.Visible = false;
            this.Cbo_Nakliye.SelectedIndexChanged += new System.EventHandler(this.Cbo_Nakliye_SelectedIndexChanged);
            // 
            // Tx_IrsaliyeKodu
            // 
            this.Tx_IrsaliyeKodu.Location = new System.Drawing.Point(92, 107);
            this.Tx_IrsaliyeKodu.Name = "Tx_IrsaliyeKodu";
            this.Tx_IrsaliyeKodu.Size = new System.Drawing.Size(115, 21);
            this.Tx_IrsaliyeKodu.TabIndex = 14;
            this.Tx_IrsaliyeKodu.Tag = "Lbl_WaybillCode";
            this.Tx_IrsaliyeKodu.Visible = false;
            // 
            // Dt_IrsaliyeTarihi
            // 
            this.Dt_IrsaliyeTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_IrsaliyeTarihi.Location = new System.Drawing.Point(92, 137);
            this.Dt_IrsaliyeTarihi.Name = "Dt_IrsaliyeTarihi";
            this.Dt_IrsaliyeTarihi.Size = new System.Drawing.Size(145, 22);
            this.Dt_IrsaliyeTarihi.TabIndex = 15;
            this.Dt_IrsaliyeTarihi.Tag = "Lbl_WaybillDate";
            this.Dt_IrsaliyeTarihi.ValueChanged += new System.EventHandler(this.Dt_IrsaliyeTarihi_ValueChanged);
            // 
            // Tx_IrsaliyeNo
            // 
            this.Tx_IrsaliyeNo.Location = new System.Drawing.Point(92, 168);
            this.Tx_IrsaliyeNo.Name = "Tx_IrsaliyeNo";
            this.Tx_IrsaliyeNo.Size = new System.Drawing.Size(145, 21);
            this.Tx_IrsaliyeNo.TabIndex = 16;
            this.Tx_IrsaliyeNo.Tag = "Lbl_WaybillNumber";
            this.Tx_IrsaliyeNo.TextChanged += new System.EventHandler(this.Tx_IrsaliyeNo_TextChanged);
            // 
            // Tx_IrsaliyeSeri
            // 
            this.Tx_IrsaliyeSeri.Location = new System.Drawing.Point(92, 196);
            this.Tx_IrsaliyeSeri.Name = "Tx_IrsaliyeSeri";
            this.Tx_IrsaliyeSeri.Size = new System.Drawing.Size(45, 21);
            this.Tx_IrsaliyeSeri.TabIndex = 17;
            this.Tx_IrsaliyeSeri.Tag = "";
            this.Tx_IrsaliyeSeri.TextChanged += new System.EventHandler(this.Tx_IrsaliyeSeri_TextChanged);
            // 
            // Tx_IrsaliyeSira
            // 
            this.Tx_IrsaliyeSira.Location = new System.Drawing.Point(143, 196);
            this.Tx_IrsaliyeSira.Name = "Tx_IrsaliyeSira";
            this.Tx_IrsaliyeSira.Size = new System.Drawing.Size(94, 21);
            this.Tx_IrsaliyeSira.TabIndex = 18;
            this.Tx_IrsaliyeSira.Tag = "";
            this.Tx_IrsaliyeSira.TextChanged += new System.EventHandler(this.Tx_IrsaliyeSira_TextChanged);
            // 
            // Btn_MakeWayBill
            // 
            this.Btn_MakeWayBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_MakeWayBill.Location = new System.Drawing.Point(0, 0);
            this.Btn_MakeWayBill.Name = "Btn_MakeWayBill";
            this.Btn_MakeWayBill.Size = new System.Drawing.Size(240, 43);
            this.Btn_MakeWayBill.TabIndex = 19;
            this.Btn_MakeWayBill.Text = "İrsaliye Oluştur";
            this.Btn_MakeWayBill.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cancel.Location = new System.Drawing.Point(0, 0);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(240, 43);
            this.Btn_Cancel.TabIndex = 20;
            this.Btn_Cancel.Text = "Vazgeç";
            this.Btn_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 43);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Btn_MakeWayBill);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 43);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 20);
            this.button1.TabIndex = 26;
            this.button1.Text = "...";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Cbo_NakliyeKod
            // 
            this.Cbo_NakliyeKod.Location = new System.Drawing.Point(92, 79);
            this.Cbo_NakliyeKod.Name = "Cbo_NakliyeKod";
            this.Cbo_NakliyeKod.Size = new System.Drawing.Size(145, 22);
            this.Cbo_NakliyeKod.TabIndex = 27;
            this.Cbo_NakliyeKod.Visible = false;
            this.Cbo_NakliyeKod.SelectedIndexChanged += new System.EventHandler(this.Cbo_NakliyeKod_SelectedIndexChanged);
            // 
            // Frm_Irsaliye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.Cbo_NakliyeKod);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tx_IrsaliyeSira);
            this.Controls.Add(this.Tx_IrsaliyeSeri);
            this.Controls.Add(this.Tx_IrsaliyeNo);
            this.Controls.Add(this.Dt_IrsaliyeTarihi);
            this.Controls.Add(this.Tx_IrsaliyeKodu);
            this.Controls.Add(this.Cbo_Nakliye);
            this.Controls.Add(this.Lbl_WaybillSerialOrder);
            this.Controls.Add(this.Lbl_WaybillNumber);
            this.Controls.Add(this.Lbl_WaybillDate);
            this.Controls.Add(this.Lbl_WaybillCode);
            this.Controls.Add(this.Lbl_ShippingCode);
            this.Controls.Add(this.Lbl_ShippingType);
            this.Controls.Add(this.Lbl_Waybill);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Frm_Irsaliye";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmIrsaliye_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Waybill;
        private System.Windows.Forms.Label Lbl_ShippingType;
        private System.Windows.Forms.Label Lbl_ShippingCode;
        private System.Windows.Forms.Label Lbl_WaybillCode;
        private System.Windows.Forms.Label Lbl_WaybillDate;
        private System.Windows.Forms.Label Lbl_WaybillNumber;
        private System.Windows.Forms.Label Lbl_WaybillSerialOrder;
        private System.Windows.Forms.ComboBox Cbo_Nakliye;
        private System.Windows.Forms.TextBox Tx_IrsaliyeKodu;
        private System.Windows.Forms.DateTimePicker Dt_IrsaliyeTarihi;
        private System.Windows.Forms.TextBox Tx_IrsaliyeNo;
        private System.Windows.Forms.TextBox Tx_IrsaliyeSeri;
        private System.Windows.Forms.TextBox Tx_IrsaliyeSira;
        private System.Windows.Forms.Button Btn_MakeWayBill;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Cbo_NakliyeKod;
    }
}