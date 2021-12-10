namespace uTerminal.Forms
{
    partial class Frm_StokHareket
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
            this.Lbl_TransCode = new System.Windows.Forms.Label();
            this.TxTransCode = new System.Windows.Forms.TextBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.Lbl_State = new System.Windows.Forms.Label();
            this.Tx_Barcode = new System.Windows.Forms.TextBox();
            this.Chk_Delete = new System.Windows.Forms.CheckBox();
            this.Tx_Miktar = new System.Windows.Forms.TextBox();
            this.Lbl_Amount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.buttonIptal = new System.Windows.Forms.Button();
            this.labelAck = new System.Windows.Forms.Label();
            this.buttonSiparisDetay = new System.Windows.Forms.Button();
            this.txSiparisDetay = new System.Windows.Forms.TextBox();
            this.Tx_Note1 = new System.Windows.Forms.TextBox();
            this.labelSiparisDetay = new System.Windows.Forms.Label();
            this.TxTargetDepot = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Lbl_SourceWh = new System.Windows.Forms.Label();
            this.Tx_DocNo = new System.Windows.Forms.TextBox();
            this.Lbl_DocNo = new System.Windows.Forms.Label();
            this.Lbl_TransDate = new System.Windows.Forms.Label();
            this.Dt_DocDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_StockMovements = new System.Windows.Forms.Label();
            this.PanelBody = new System.Windows.Forms.Panel();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.PanelHeader.SuspendLayout();
            this.PanelBody.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_TransCode
            // 
            this.Lbl_TransCode.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_TransCode.ForeColor = System.Drawing.Color.Black;
            this.Lbl_TransCode.Location = new System.Drawing.Point(3, 32);
            this.Lbl_TransCode.Name = "Lbl_TransCode";
            this.Lbl_TransCode.Size = new System.Drawing.Size(40, 10);
            this.Lbl_TransCode.Text = "Har.Kodu";
            this.Lbl_TransCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Lbl_TransCode.ParentChanged += new System.EventHandler(this.Lbl_TransCode_ParentChanged);
            // 
            // TxTransCode
            // 
            this.TxTransCode.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.TxTransCode.Location = new System.Drawing.Point(45, 32);
            this.TxTransCode.Name = "TxTransCode";
            this.TxTransCode.Size = new System.Drawing.Size(68, 18);
            this.TxTransCode.TabIndex = 6;
            this.TxTransCode.TextChanged += new System.EventHandler(this.TxTransCode_TextChanged);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Btn_Save.Location = new System.Drawing.Point(151, 32);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(65, 18);
            this.Btn_Save.TabIndex = 8;
            this.Btn_Save.Text = "Kaydet";
            this.Btn_Save.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.button4.Location = new System.Drawing.Point(114, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(15, 18);
            this.button4.TabIndex = 9;
            this.button4.Text = "...";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 5F, System.Drawing.FontStyle.Regular);
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(240, 175);
            this.dataGrid1.TabIndex = 10;
            // 
            // Lbl_State
            // 
            this.Lbl_State.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_State.Location = new System.Drawing.Point(4, 2);
            this.Lbl_State.Name = "Lbl_State";
            this.Lbl_State.Size = new System.Drawing.Size(96, 19);
            this.Lbl_State.Text = "-";
            this.Lbl_State.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Tx_Barcode
            // 
            this.Tx_Barcode.Location = new System.Drawing.Point(104, 2);
            this.Tx_Barcode.Name = "Tx_Barcode";
            this.Tx_Barcode.Size = new System.Drawing.Size(112, 21);
            this.Tx_Barcode.TabIndex = 15;
            // 
            // Chk_Delete
            // 
            this.Chk_Delete.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Chk_Delete.Location = new System.Drawing.Point(101, 27);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new System.Drawing.Size(50, 15);
            this.Chk_Delete.TabIndex = 17;
            this.Chk_Delete.Text = "Silme";
            // 
            // Tx_Miktar
            // 
            this.Tx_Miktar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_Miktar.Location = new System.Drawing.Point(3, 27);
            this.Tx_Miktar.Name = "Tx_Miktar";
            this.Tx_Miktar.Size = new System.Drawing.Size(30, 18);
            this.Tx_Miktar.TabIndex = 18;
            this.Tx_Miktar.Text = "1";
            this.Tx_Miktar.TextChanged += new System.EventHandler(this.Tx_Miktar_TextChanged);
            // 
            // Lbl_Amount
            // 
            this.Lbl_Amount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_Amount.Location = new System.Drawing.Point(41, 27);
            this.Lbl_Amount.Name = "Lbl_Amount";
            this.Lbl_Amount.Size = new System.Drawing.Size(59, 15);
            this.Lbl_Amount.Text = "Adet";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(219, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 18);
            this.button1.TabIndex = 22;
            this.button1.Text = "X";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Btn_Exit.Location = new System.Drawing.Point(176, 27);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(57, 15);
            this.Btn_Exit.TabIndex = 28;
            this.Btn_Exit.Text = "Çıkış";
            this.Btn_Exit.Click += new System.EventHandler(this.button5_Click);
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.buttonIptal);
            this.PanelHeader.Controls.Add(this.labelAck);
            this.PanelHeader.Controls.Add(this.buttonSiparisDetay);
            this.PanelHeader.Controls.Add(this.txSiparisDetay);
            this.PanelHeader.Controls.Add(this.Tx_Note1);
            this.PanelHeader.Controls.Add(this.labelSiparisDetay);
            this.PanelHeader.Controls.Add(this.TxTargetDepot);
            this.PanelHeader.Controls.Add(this.button2);
            this.PanelHeader.Controls.Add(this.Lbl_SourceWh);
            this.PanelHeader.Controls.Add(this.Tx_DocNo);
            this.PanelHeader.Controls.Add(this.Lbl_DocNo);
            this.PanelHeader.Controls.Add(this.Lbl_TransDate);
            this.PanelHeader.Controls.Add(this.Dt_DocDate);
            this.PanelHeader.Controls.Add(this.Lbl_StockMovements);
            this.PanelHeader.Controls.Add(this.TxTransCode);
            this.PanelHeader.Controls.Add(this.Lbl_TransCode);
            this.PanelHeader.Controls.Add(this.button4);
            this.PanelHeader.Controls.Add(this.Btn_Save);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(240, 89);
            // 
            // buttonIptal
            // 
            this.buttonIptal.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.buttonIptal.Location = new System.Drawing.Point(217, 32);
            this.buttonIptal.Name = "buttonIptal";
            this.buttonIptal.Size = new System.Drawing.Size(17, 18);
            this.buttonIptal.TabIndex = 46;
            this.buttonIptal.Text = "Sil";
            this.buttonIptal.Click += new System.EventHandler(this.buttonIptal_Click);
            // 
            // labelAck
            // 
            this.labelAck.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.labelAck.ForeColor = System.Drawing.Color.Black;
            this.labelAck.Location = new System.Drawing.Point(3, 68);
            this.labelAck.Name = "labelAck";
            this.labelAck.Size = new System.Drawing.Size(42, 18);
            this.labelAck.Text = "Açıklama";
            // 
            // buttonSiparisDetay
            // 
            this.buttonSiparisDetay.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.buttonSiparisDetay.Location = new System.Drawing.Point(217, 50);
            this.buttonSiparisDetay.Name = "buttonSiparisDetay";
            this.buttonSiparisDetay.Size = new System.Drawing.Size(17, 18);
            this.buttonSiparisDetay.TabIndex = 39;
            this.buttonSiparisDetay.Text = "...";
            this.buttonSiparisDetay.Visible = false;
            this.buttonSiparisDetay.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // txSiparisDetay
            // 
            this.txSiparisDetay.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.txSiparisDetay.Location = new System.Drawing.Point(151, 50);
            this.txSiparisDetay.Name = "txSiparisDetay";
            this.txSiparisDetay.Size = new System.Drawing.Size(65, 18);
            this.txSiparisDetay.TabIndex = 37;
            this.txSiparisDetay.Visible = false;
            // 
            // Tx_Note1
            // 
            this.Tx_Note1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_Note1.Location = new System.Drawing.Point(45, 68);
            this.Tx_Note1.MaxLength = 50;
            this.Tx_Note1.Name = "Tx_Note1";
            this.Tx_Note1.Size = new System.Drawing.Size(188, 18);
            this.Tx_Note1.TabIndex = 38;
            // 
            // labelSiparisDetay
            // 
            this.labelSiparisDetay.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.labelSiparisDetay.Location = new System.Drawing.Point(131, 50);
            this.labelSiparisDetay.Name = "labelSiparisDetay";
            this.labelSiparisDetay.Size = new System.Drawing.Size(17, 18);
            this.labelSiparisDetay.Text = "Sip";
            // 
            // TxTargetDepot
            // 
            this.TxTargetDepot.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.TxTargetDepot.Location = new System.Drawing.Point(45, 50);
            this.TxTargetDepot.Name = "TxTargetDepot";
            this.TxTargetDepot.Size = new System.Drawing.Size(68, 18);
            this.TxTargetDepot.TabIndex = 21;
            this.TxTargetDepot.Visible = false;
            this.TxTargetDepot.TextChanged += new System.EventHandler(this.TxTargetDepot_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(114, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(15, 18);
            this.button2.TabIndex = 22;
            this.button2.Text = "...";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Lbl_SourceWh
            // 
            this.Lbl_SourceWh.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_SourceWh.ForeColor = System.Drawing.Color.Black;
            this.Lbl_SourceWh.Location = new System.Drawing.Point(3, 50);
            this.Lbl_SourceWh.Name = "Lbl_SourceWh";
            this.Lbl_SourceWh.Size = new System.Drawing.Size(40, 18);
            this.Lbl_SourceWh.Text = "Depo";
            this.Lbl_SourceWh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Lbl_SourceWh.Visible = false;
            this.Lbl_SourceWh.ParentChanged += new System.EventHandler(this.Lbl_SourceWh_ParentChanged);
            // 
            // Tx_DocNo
            // 
            this.Tx_DocNo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_DocNo.Location = new System.Drawing.Point(151, 14);
            this.Tx_DocNo.Name = "Tx_DocNo";
            this.Tx_DocNo.Size = new System.Drawing.Size(83, 18);
            this.Tx_DocNo.TabIndex = 14;
            this.Tx_DocNo.TextChanged += new System.EventHandler(this.Tx_DocNo_TextChanged);
            // 
            // Lbl_DocNo
            // 
            this.Lbl_DocNo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_DocNo.ForeColor = System.Drawing.Color.Black;
            this.Lbl_DocNo.Location = new System.Drawing.Point(104, 15);
            this.Lbl_DocNo.Name = "Lbl_DocNo";
            this.Lbl_DocNo.Size = new System.Drawing.Size(44, 15);
            this.Lbl_DocNo.Text = "Belge No";
            this.Lbl_DocNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Lbl_DocNo.ParentChanged += new System.EventHandler(this.Lbl_DocNo_ParentChanged);
            // 
            // Lbl_TransDate
            // 
            this.Lbl_TransDate.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_TransDate.ForeColor = System.Drawing.Color.Black;
            this.Lbl_TransDate.Location = new System.Drawing.Point(2, 15);
            this.Lbl_TransDate.Name = "Lbl_TransDate";
            this.Lbl_TransDate.Size = new System.Drawing.Size(30, 15);
            this.Lbl_TransDate.Text = "Tarih";
            this.Lbl_TransDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Lbl_TransDate.ParentChanged += new System.EventHandler(this.Lbl_TransDate_ParentChanged);
            // 
            // Dt_DocDate
            // 
            this.Dt_DocDate.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Dt_DocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_DocDate.Location = new System.Drawing.Point(34, 12);
            this.Dt_DocDate.Name = "Dt_DocDate";
            this.Dt_DocDate.Size = new System.Drawing.Size(66, 19);
            this.Dt_DocDate.TabIndex = 10;
            this.Dt_DocDate.ValueChanged += new System.EventHandler(this.Dt_DocDate_ValueChanged);
            // 
            // Lbl_StockMovements
            // 
            this.Lbl_StockMovements.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_StockMovements.Location = new System.Drawing.Point(4, 0);
            this.Lbl_StockMovements.Name = "Lbl_StockMovements";
            this.Lbl_StockMovements.Size = new System.Drawing.Size(232, 12);
            this.Lbl_StockMovements.Text = "Stok Hareketleri";
            this.Lbl_StockMovements.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelBody
            // 
            this.PanelBody.Controls.Add(this.dataGrid1);
            this.PanelBody.Location = new System.Drawing.Point(0, 92);
            this.PanelBody.Name = "PanelBody";
            this.PanelBody.Size = new System.Drawing.Size(240, 175);
            // 
            // PanelFooter
            // 
            this.PanelFooter.Controls.Add(this.Tx_Barcode);
            this.PanelFooter.Controls.Add(this.Lbl_State);
            this.PanelFooter.Controls.Add(this.button1);
            this.PanelFooter.Controls.Add(this.Btn_Exit);
            this.PanelFooter.Controls.Add(this.Lbl_Amount);
            this.PanelFooter.Controls.Add(this.Tx_Miktar);
            this.PanelFooter.Controls.Add(this.Chk_Delete);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 267);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(240, 51);
            // 
            // Frm_StokHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(237, 320);
            this.ControlBox = false;
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PanelBody);
            this.Controls.Add(this.PanelHeader);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm_StokHareket";
            this.Text = "Mal Sevk İşlemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_MalKabul_Load);
            this.Closed += new System.EventHandler(this.Frm_MalKabul_Closed);
            this.PanelHeader.ResumeLayout(false);
            this.PanelBody.ResumeLayout(false);
            this.PanelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_TransCode;
        private System.Windows.Forms.TextBox TxTransCode;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label Lbl_State;
        private System.Windows.Forms.TextBox Tx_Barcode;
        private System.Windows.Forms.CheckBox Chk_Delete;
        private System.Windows.Forms.TextBox Tx_Miktar;
        private System.Windows.Forms.Label Lbl_Amount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Panel PanelBody;
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Label Lbl_StockMovements;
        private System.Windows.Forms.DateTimePicker Dt_DocDate;
        private System.Windows.Forms.Label Lbl_TransDate;
        private System.Windows.Forms.TextBox Tx_DocNo;
        private System.Windows.Forms.Label Lbl_DocNo;
        private System.Windows.Forms.Label Lbl_SourceWh;
        private System.Windows.Forms.TextBox TxTargetDepot;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelSiparisDetay;
        private System.Windows.Forms.TextBox txSiparisDetay;
        private System.Windows.Forms.TextBox Tx_Note1;
        private System.Windows.Forms.Button buttonSiparisDetay;
        private System.Windows.Forms.Label labelAck;
        private System.Windows.Forms.Button buttonIptal;
    }
}