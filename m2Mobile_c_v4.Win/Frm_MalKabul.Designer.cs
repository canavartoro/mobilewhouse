namespace uTerminal.Forms
{
    partial class Frm_MalKabul
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
            this.Lbl_OrderNumber = new System.Windows.Forms.Label();
            this.TxOrderNo = new System.Windows.Forms.TextBox();
            this.Btn_WayBill = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.Tx_Raf = new System.Windows.Forms.TextBox();
            this.Lbl_Rack = new System.Windows.Forms.Label();
            this.Lbl_State = new System.Windows.Forms.Label();
            this.Tx_Barcode = new System.Windows.Forms.TextBox();
            this.Chk_Delete = new System.Windows.Forms.CheckBox();
            this.Tx_Miktar = new System.Windows.Forms.TextBox();
            this.Lbl_Amount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.Lbl_GoodsAcceptanceHeader = new System.Windows.Forms.Label();
            this.PanelBody = new System.Windows.Forms.Panel();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.PanelHeader.SuspendLayout();
            this.PanelBody.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_OrderNumber
            // 
            this.Lbl_OrderNumber.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_OrderNumber.Location = new System.Drawing.Point(2, 21);
            this.Lbl_OrderNumber.Name = "Lbl_OrderNumber";
            this.Lbl_OrderNumber.Size = new System.Drawing.Size(47, 15);
            this.Lbl_OrderNumber.Text = "Sipariş No";
            this.Lbl_OrderNumber.ParentChanged += new System.EventHandler(this.Lbl_OrderNumber_ParentChanged);
            // 
            // TxOrderNo
            // 
            this.TxOrderNo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.TxOrderNo.Location = new System.Drawing.Point(49, 18);
            this.TxOrderNo.Name = "TxOrderNo";
            this.TxOrderNo.Size = new System.Drawing.Size(106, 18);
            this.TxOrderNo.TabIndex = 1;
            this.TxOrderNo.TextChanged += new System.EventHandler(this.TxOrderNo_TextChanged);
            // 
            // Btn_WayBill
            // 
            this.Btn_WayBill.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Btn_WayBill.Location = new System.Drawing.Point(179, 18);
            this.Btn_WayBill.Name = "Btn_WayBill";
            this.Btn_WayBill.Size = new System.Drawing.Size(57, 18);
            this.Btn_WayBill.TabIndex = 7;
            this.Btn_WayBill.Text = "İrsaliye Yap";
            this.Btn_WayBill.Click += new System.EventHandler(this.button2_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Btn_Save.Location = new System.Drawing.Point(99, 56);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(55, 18);
            this.Btn_Save.TabIndex = 8;
            this.Btn_Save.Text = "Kaydet";
            this.Btn_Save.Visible = false;
            this.Btn_Save.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.button4.Location = new System.Drawing.Point(161, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(15, 18);
            this.button4.TabIndex = 2;
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
            this.dataGrid1.Size = new System.Drawing.Size(240, 203);
            this.dataGrid1.TabIndex = 10;
            // 
            // Tx_Raf
            // 
            this.Tx_Raf.Location = new System.Drawing.Point(99, 29);
            this.Tx_Raf.Name = "Tx_Raf";
            this.Tx_Raf.ReadOnly = true;
            this.Tx_Raf.Size = new System.Drawing.Size(137, 21);
            this.Tx_Raf.TabIndex = 11;
            // 
            // Lbl_Rack
            // 
            this.Lbl_Rack.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_Rack.Location = new System.Drawing.Point(75, 39);
            this.Lbl_Rack.Name = "Lbl_Rack";
            this.Lbl_Rack.Size = new System.Drawing.Size(21, 19);
            this.Lbl_Rack.Text = "Raf";
            // 
            // Lbl_State
            // 
            this.Lbl_State.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_State.Location = new System.Drawing.Point(4, 5);
            this.Lbl_State.Name = "Lbl_State";
            this.Lbl_State.Size = new System.Drawing.Size(84, 19);
            this.Lbl_State.Text = "-";
            this.Lbl_State.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Tx_Barcode
            // 
            this.Tx_Barcode.Location = new System.Drawing.Point(99, 5);
            this.Tx_Barcode.Name = "Tx_Barcode";
            this.Tx_Barcode.Size = new System.Drawing.Size(118, 21);
            this.Tx_Barcode.TabIndex = 4;
            // 
            // Chk_Delete
            // 
            this.Chk_Delete.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Chk_Delete.Location = new System.Drawing.Point(1, 35);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new System.Drawing.Size(50, 20);
            this.Chk_Delete.TabIndex = 17;
            this.Chk_Delete.Text = "Silme";
            // 
            // Tx_Miktar
            // 
            this.Tx_Miktar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_Miktar.Location = new System.Drawing.Point(3, 55);
            this.Tx_Miktar.Name = "Tx_Miktar";
            this.Tx_Miktar.Size = new System.Drawing.Size(30, 18);
            this.Tx_Miktar.TabIndex = 3;
            this.Tx_Miktar.Text = "1";
            this.Tx_Miktar.TextChanged += new System.EventHandler(this.Tx_Miktar_TextChanged);
            // 
            // Lbl_Amount
            // 
            this.Lbl_Amount.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_Amount.Location = new System.Drawing.Point(35, 56);
            this.Lbl_Amount.Name = "Lbl_Amount";
            this.Lbl_Amount.Size = new System.Drawing.Size(58, 15);
            this.Lbl_Amount.Text = "Adet";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(221, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 18);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Btn_Exit.Location = new System.Drawing.Point(179, 53);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(57, 20);
            this.Btn_Exit.TabIndex = 28;
            this.Btn_Exit.TabStop = false;
            this.Btn_Exit.Text = "Çıkış";
            this.Btn_Exit.Click += new System.EventHandler(this.button5_Click);
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.Lbl_GoodsAcceptanceHeader);
            this.PanelHeader.Controls.Add(this.TxOrderNo);
            this.PanelHeader.Controls.Add(this.Lbl_OrderNumber);
            this.PanelHeader.Controls.Add(this.button4);
            this.PanelHeader.Controls.Add(this.Btn_WayBill);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(240, 39);
            // 
            // Lbl_GoodsAcceptanceHeader
            // 
            this.Lbl_GoodsAcceptanceHeader.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_GoodsAcceptanceHeader.Location = new System.Drawing.Point(4, 0);
            this.Lbl_GoodsAcceptanceHeader.Name = "Lbl_GoodsAcceptanceHeader";
            this.Lbl_GoodsAcceptanceHeader.Size = new System.Drawing.Size(232, 12);
            this.Lbl_GoodsAcceptanceHeader.Text = "Mal Kabul İşlemleri";
            this.Lbl_GoodsAcceptanceHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelBody
            // 
            this.PanelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBody.Controls.Add(this.dataGrid1);
            this.PanelBody.Location = new System.Drawing.Point(-1, 39);
            this.PanelBody.Name = "PanelBody";
            this.PanelBody.Size = new System.Drawing.Size(240, 203);
            // 
            // PanelFooter
            // 
            this.PanelFooter.Controls.Add(this.Tx_Barcode);
            this.PanelFooter.Controls.Add(this.Lbl_State);
            this.PanelFooter.Controls.Add(this.button1);
            this.PanelFooter.Controls.Add(this.Btn_Exit);
            this.PanelFooter.Controls.Add(this.Lbl_Amount);
            this.PanelFooter.Controls.Add(this.Btn_Save);
            this.PanelFooter.Controls.Add(this.Tx_Raf);
            this.PanelFooter.Controls.Add(this.Tx_Miktar);
            this.PanelFooter.Controls.Add(this.Lbl_Rack);
            this.PanelFooter.Controls.Add(this.Chk_Delete);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 243);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(240, 77);
            // 
            // Frm_MalKabul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.PanelFooter);
            this.Controls.Add(this.PanelBody);
            this.Controls.Add(this.PanelHeader);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm_MalKabul";
            this.Text = "Mal Kabul İşlemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_MalKabul_Load);
            this.Closed += new System.EventHandler(this.Frm_MalKabul_Closed);
            this.PanelHeader.ResumeLayout(false);
            this.PanelBody.ResumeLayout(false);
            this.PanelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_OrderNumber;
        private System.Windows.Forms.TextBox TxOrderNo;
        private System.Windows.Forms.Button Btn_WayBill;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox Tx_Raf;
        private System.Windows.Forms.Label Lbl_Rack;
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
        private System.Windows.Forms.Label Lbl_GoodsAcceptanceHeader;
    }
}