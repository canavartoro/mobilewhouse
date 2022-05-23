namespace MobileWhouse.Controls
{
    partial class Frm_PaletSevk
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
            this.PanelBody = new System.Windows.Forms.Panel();
            this.gridOrder = new System.Windows.Forms.DataGrid();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.Tx_ReadLocationId = new System.Windows.Forms.TextBox();
            this.Lbl_ReadLocationCode = new System.Windows.Forms.Label();
            this.Tx_ReadLocationCode = new System.Windows.Forms.TextBox();
            this.tx_BarcodeQty = new System.Windows.Forms.TextBox();
            this.Tx_Miktar = new System.Windows.Forms.TextBox();
            this.tx_SerialNo = new System.Windows.Forms.TextBox();
            this.Tx_Barcode = new System.Windows.Forms.TextBox();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.Chk_Delete = new System.Windows.Forms.CheckBox();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.labelAck = new System.Windows.Forms.Label();
            this.Tx_Note1 = new System.Windows.Forms.TextBox();
            this.Tx_SalesPerson = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSalesPerson = new System.Windows.Forms.Button();
            this.TxTransporterDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxOrderNo = new System.Windows.Forms.TextBox();
            this.Lbl_ShippingOrder = new System.Windows.Forms.Label();
            this.btnSevkSec = new System.Windows.Forms.Button();
            this.btnIrsaliyeOlustur = new System.Windows.Forms.Button();
            this.Lbl_PackageTransfer = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPackage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridPackage = new System.Windows.Forms.DataGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbSelectOrderInfo = new System.Windows.Forms.Label();
            this.TabPackageItem = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gridPackageItem = new System.Windows.Forms.DataGrid();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbSelectPackageInfo = new System.Windows.Forms.Label();
            this.tabPagePackageRevort = new System.Windows.Forms.TabPage();
            this.Tx_PackageMId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_PackRelease = new System.Windows.Forms.Button();
            this.Tx_PackageNoRevort = new System.Windows.Forms.TextBox();
            this.Lbl_PackageCode = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PanelBody.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabOrder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPackage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TabPackageItem.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPagePackageRevort.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelBody
            // 
            this.PanelBody.Controls.Add(this.gridOrder);
            this.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBody.Location = new System.Drawing.Point(0, 89);
            this.PanelBody.Name = "PanelBody";
            this.PanelBody.Size = new System.Drawing.Size(240, 129);
            // 
            // gridOrder
            // 
            this.gridOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrder.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.gridOrder.Location = new System.Drawing.Point(0, 0);
            this.gridOrder.Name = "gridOrder";
            this.gridOrder.RowHeadersVisible = false;
            this.gridOrder.Size = new System.Drawing.Size(240, 129);
            this.gridOrder.TabIndex = 10;
            this.gridOrder.DoubleClick += new System.EventHandler(this.gridOrder_DoubleClick);
            this.gridOrder.CurrentCellChanged += new System.EventHandler(this.gridOrder_CurrentCellChanged);
            // 
            // PanelFooter
            // 
            this.PanelFooter.Controls.Add(this.Tx_ReadLocationId);
            this.PanelFooter.Controls.Add(this.Lbl_ReadLocationCode);
            this.PanelFooter.Controls.Add(this.Tx_ReadLocationCode);
            this.PanelFooter.Controls.Add(this.tx_BarcodeQty);
            this.PanelFooter.Controls.Add(this.Tx_Miktar);
            this.PanelFooter.Controls.Add(this.tx_SerialNo);
            this.PanelFooter.Controls.Add(this.Tx_Barcode);
            this.PanelFooter.Controls.Add(this.Btn_Exit);
            this.PanelFooter.Controls.Add(this.Chk_Delete);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(0, 218);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(240, 64);
            // 
            // Tx_ReadLocationId
            // 
            this.Tx_ReadLocationId.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_ReadLocationId.Location = new System.Drawing.Point(184, 0);
            this.Tx_ReadLocationId.Name = "Tx_ReadLocationId";
            this.Tx_ReadLocationId.ReadOnly = true;
            this.Tx_ReadLocationId.Size = new System.Drawing.Size(54, 18);
            this.Tx_ReadLocationId.TabIndex = 34;
            // 
            // Lbl_ReadLocationCode
            // 
            this.Lbl_ReadLocationCode.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_ReadLocationCode.Location = new System.Drawing.Point(3, 0);
            this.Lbl_ReadLocationCode.Name = "Lbl_ReadLocationCode";
            this.Lbl_ReadLocationCode.Size = new System.Drawing.Size(30, 19);
            this.Lbl_ReadLocationCode.Text = "Raf";
            // 
            // Tx_ReadLocationCode
            // 
            this.Tx_ReadLocationCode.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_ReadLocationCode.Location = new System.Drawing.Point(39, 0);
            this.Tx_ReadLocationCode.Name = "Tx_ReadLocationCode";
            this.Tx_ReadLocationCode.Size = new System.Drawing.Size(144, 18);
            this.Tx_ReadLocationCode.TabIndex = 33;
            this.Tx_ReadLocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_ReadLocationCode_KeyDown);
            // 
            // tx_BarcodeQty
            // 
            this.tx_BarcodeQty.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.tx_BarcodeQty.Location = new System.Drawing.Point(3, 42);
            this.tx_BarcodeQty.Name = "tx_BarcodeQty";
            this.tx_BarcodeQty.ReadOnly = true;
            this.tx_BarcodeQty.Size = new System.Drawing.Size(30, 18);
            this.tx_BarcodeQty.TabIndex = 32;
            this.tx_BarcodeQty.Text = "1";
            // 
            // Tx_Miktar
            // 
            this.Tx_Miktar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_Miktar.Location = new System.Drawing.Point(3, 21);
            this.Tx_Miktar.Name = "Tx_Miktar";
            this.Tx_Miktar.Size = new System.Drawing.Size(30, 18);
            this.Tx_Miktar.TabIndex = 31;
            this.Tx_Miktar.Text = "1";
            // 
            // tx_SerialNo
            // 
            this.tx_SerialNo.Enabled = false;
            this.tx_SerialNo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.tx_SerialNo.Location = new System.Drawing.Point(39, 42);
            this.tx_SerialNo.Name = "tx_SerialNo";
            this.tx_SerialNo.Size = new System.Drawing.Size(144, 18);
            this.tx_SerialNo.TabIndex = 29;
            this.tx_SerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_Barcode_KeyDown);
            // 
            // Tx_Barcode
            // 
            this.Tx_Barcode.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_Barcode.Location = new System.Drawing.Point(39, 21);
            this.Tx_Barcode.Name = "Tx_Barcode";
            this.Tx_Barcode.Size = new System.Drawing.Size(144, 18);
            this.Tx_Barcode.TabIndex = 15;
            this.Tx_Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_Barcode_KeyDown);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Btn_Exit.Location = new System.Drawing.Point(184, 42);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(51, 19);
            this.Btn_Exit.TabIndex = 28;
            this.Btn_Exit.Text = "Çıkış";
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Chk_Delete
            // 
            this.Chk_Delete.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Chk_Delete.Location = new System.Drawing.Point(184, 21);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new System.Drawing.Size(48, 18);
            this.Chk_Delete.TabIndex = 17;
            this.Chk_Delete.Text = "Sil";
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.labelAck);
            this.PanelHeader.Controls.Add(this.Tx_Note1);
            this.PanelHeader.Controls.Add(this.Tx_SalesPerson);
            this.PanelHeader.Controls.Add(this.label4);
            this.PanelHeader.Controls.Add(this.BtnSalesPerson);
            this.PanelHeader.Controls.Add(this.TxTransporterDesc);
            this.PanelHeader.Controls.Add(this.label1);
            this.PanelHeader.Controls.Add(this.TxOrderNo);
            this.PanelHeader.Controls.Add(this.Lbl_ShippingOrder);
            this.PanelHeader.Controls.Add(this.btnSevkSec);
            this.PanelHeader.Controls.Add(this.btnIrsaliyeOlustur);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(240, 89);
            // 
            // labelAck
            // 
            this.labelAck.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.labelAck.ForeColor = System.Drawing.Color.Black;
            this.labelAck.Location = new System.Drawing.Point(7, 62);
            this.labelAck.Name = "labelAck";
            this.labelAck.Size = new System.Drawing.Size(41, 18);
            this.labelAck.Text = "Açk.";
            // 
            // Tx_Note1
            // 
            this.Tx_Note1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_Note1.Location = new System.Drawing.Point(51, 62);
            this.Tx_Note1.MaxLength = 100;
            this.Tx_Note1.Name = "Tx_Note1";
            this.Tx_Note1.Size = new System.Drawing.Size(184, 18);
            this.Tx_Note1.TabIndex = 78;
            // 
            // Tx_SalesPerson
            // 
            this.Tx_SalesPerson.Enabled = false;
            this.Tx_SalesPerson.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Tx_SalesPerson.Location = new System.Drawing.Point(51, 44);
            this.Tx_SalesPerson.Name = "Tx_SalesPerson";
            this.Tx_SalesPerson.Size = new System.Drawing.Size(87, 18);
            this.Tx_SalesPerson.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.Text = "Satıcı";
            // 
            // BtnSalesPerson
            // 
            this.BtnSalesPerson.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.BtnSalesPerson.Location = new System.Drawing.Point(138, 44);
            this.BtnSalesPerson.Name = "BtnSalesPerson";
            this.BtnSalesPerson.Size = new System.Drawing.Size(19, 18);
            this.BtnSalesPerson.TabIndex = 74;
            this.BtnSalesPerson.Text = "...";
            this.BtnSalesPerson.Click += new System.EventHandler(this.BtnSalesPerson_Click);
            // 
            // TxTransporterDesc
            // 
            this.TxTransporterDesc.Enabled = false;
            this.TxTransporterDesc.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.TxTransporterDesc.Location = new System.Drawing.Point(51, 26);
            this.TxTransporterDesc.Name = "TxTransporterDesc";
            this.TxTransporterDesc.Size = new System.Drawing.Size(185, 18);
            this.TxTransporterDesc.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.Text = "Nak.Şekli";
            // 
            // TxOrderNo
            // 
            this.TxOrderNo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.TxOrderNo.Location = new System.Drawing.Point(51, 4);
            this.TxOrderNo.Name = "TxOrderNo";
            this.TxOrderNo.Size = new System.Drawing.Size(87, 18);
            this.TxOrderNo.TabIndex = 59;
            this.TxOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxOrderNo_KeyDown);
            // 
            // Lbl_ShippingOrder
            // 
            this.Lbl_ShippingOrder.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_ShippingOrder.ForeColor = System.Drawing.Color.Black;
            this.Lbl_ShippingOrder.Location = new System.Drawing.Point(1, 4);
            this.Lbl_ShippingOrder.Name = "Lbl_ShippingOrder";
            this.Lbl_ShippingOrder.Size = new System.Drawing.Size(47, 21);
            this.Lbl_ShippingOrder.Text = "Sevk Emri";
            // 
            // btnSevkSec
            // 
            this.btnSevkSec.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.btnSevkSec.Location = new System.Drawing.Point(138, 4);
            this.btnSevkSec.Name = "btnSevkSec";
            this.btnSevkSec.Size = new System.Drawing.Size(21, 21);
            this.btnSevkSec.TabIndex = 60;
            this.btnSevkSec.Text = "...";
            this.btnSevkSec.Click += new System.EventHandler(this.btnSevkSec_Click);
            // 
            // btnIrsaliyeOlustur
            // 
            this.btnIrsaliyeOlustur.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btnIrsaliyeOlustur.Location = new System.Drawing.Point(160, 4);
            this.btnIrsaliyeOlustur.Name = "btnIrsaliyeOlustur";
            this.btnIrsaliyeOlustur.Size = new System.Drawing.Size(76, 21);
            this.btnIrsaliyeOlustur.TabIndex = 49;
            this.btnIrsaliyeOlustur.Text = "İrsaliye Yap";
            this.btnIrsaliyeOlustur.Click += new System.EventHandler(this.btnIrsaliyeOlustur_Click);
            // 
            // Lbl_PackageTransfer
            // 
            this.Lbl_PackageTransfer.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_PackageTransfer.Location = new System.Drawing.Point(0, 0);
            this.Lbl_PackageTransfer.Name = "Lbl_PackageTransfer";
            this.Lbl_PackageTransfer.Size = new System.Drawing.Size(232, 12);
            this.Lbl_PackageTransfer.Text = "Palet Sevk";
            this.Lbl_PackageTransfer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabOrder);
            this.tabControl.Controls.Add(this.tabPackage);
            this.tabControl.Controls.Add(this.TabPackageItem);
            this.tabControl.Controls.Add(this.tabPagePackageRevort);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 15);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 305);
            this.tabControl.TabIndex = 29;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.panel1);
            this.tabOrder.Location = new System.Drawing.Point(0, 0);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Size = new System.Drawing.Size(240, 282);
            this.tabOrder.Text = "Sevk";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelBody);
            this.panel1.Controls.Add(this.PanelFooter);
            this.panel1.Controls.Add(this.PanelHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 282);
            // 
            // tabPackage
            // 
            this.tabPackage.Controls.Add(this.panel2);
            this.tabPackage.Location = new System.Drawing.Point(0, 0);
            this.tabPackage.Name = "tabPackage";
            this.tabPackage.Size = new System.Drawing.Size(240, 282);
            this.tabPackage.Text = "Paket Detay";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridPackage);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 279);
            // 
            // gridPackage
            // 
            this.gridPackage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPackage.Location = new System.Drawing.Point(0, 22);
            this.gridPackage.Name = "gridPackage";
            this.gridPackage.Size = new System.Drawing.Size(232, 257);
            this.gridPackage.TabIndex = 1;
            this.gridPackage.CurrentCellChanged += new System.EventHandler(this.gridPackage_CurrentCellChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbSelectOrderInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 22);
            // 
            // lbSelectOrderInfo
            // 
            this.lbSelectOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSelectOrderInfo.Location = new System.Drawing.Point(0, 0);
            this.lbSelectOrderInfo.Name = "lbSelectOrderInfo";
            this.lbSelectOrderInfo.Size = new System.Drawing.Size(232, 20);
            this.lbSelectOrderInfo.Text = "lbSelectOrderInfo";
            // 
            // TabPackageItem
            // 
            this.TabPackageItem.Controls.Add(this.panel5);
            this.TabPackageItem.Location = new System.Drawing.Point(0, 0);
            this.TabPackageItem.Name = "TabPackageItem";
            this.TabPackageItem.Size = new System.Drawing.Size(240, 282);
            this.TabPackageItem.Text = "Paket Stokları";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gridPackageItem);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 282);
            // 
            // gridPackageItem
            // 
            this.gridPackageItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridPackageItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPackageItem.Location = new System.Drawing.Point(0, 22);
            this.gridPackageItem.Name = "gridPackageItem";
            this.gridPackageItem.Size = new System.Drawing.Size(240, 260);
            this.gridPackageItem.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbSelectPackageInfo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(240, 22);
            // 
            // lbSelectPackageInfo
            // 
            this.lbSelectPackageInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSelectPackageInfo.Location = new System.Drawing.Point(0, 0);
            this.lbSelectPackageInfo.Name = "lbSelectPackageInfo";
            this.lbSelectPackageInfo.Size = new System.Drawing.Size(240, 20);
            this.lbSelectPackageInfo.Text = "label1";
            // 
            // tabPagePackageRevort
            // 
            this.tabPagePackageRevort.Controls.Add(this.Tx_PackageMId);
            this.tabPagePackageRevort.Controls.Add(this.button1);
            this.tabPagePackageRevort.Controls.Add(this.Btn_PackRelease);
            this.tabPagePackageRevort.Controls.Add(this.Tx_PackageNoRevort);
            this.tabPagePackageRevort.Controls.Add(this.Lbl_PackageCode);
            this.tabPagePackageRevort.Location = new System.Drawing.Point(0, 0);
            this.tabPagePackageRevort.Name = "tabPagePackageRevort";
            this.tabPagePackageRevort.Size = new System.Drawing.Size(232, 279);
            this.tabPagePackageRevort.Text = "Ambalaj Çöz";
            // 
            // Tx_PackageMId
            // 
            this.Tx_PackageMId.Location = new System.Drawing.Point(123, 120);
            this.Tx_PackageMId.Name = "Tx_PackageMId";
            this.Tx_PackageMId.ReadOnly = true;
            this.Tx_PackageMId.Size = new System.Drawing.Size(94, 21);
            this.Tx_PackageMId.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(220, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 18);
            this.button1.TabIndex = 27;
            this.button1.Text = "X";
            // 
            // Btn_PackRelease
            // 
            this.Btn_PackRelease.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Btn_PackRelease.Location = new System.Drawing.Point(78, 145);
            this.Btn_PackRelease.Name = "Btn_PackRelease";
            this.Btn_PackRelease.Size = new System.Drawing.Size(157, 40);
            this.Btn_PackRelease.TabIndex = 26;
            this.Btn_PackRelease.Text = "Ambalaj Çöz";
            this.Btn_PackRelease.Click += new System.EventHandler(this.Btn_PackRelease_Click);
            // 
            // Tx_PackageNoRevort
            // 
            this.Tx_PackageNoRevort.Location = new System.Drawing.Point(78, 97);
            this.Tx_PackageNoRevort.Name = "Tx_PackageNoRevort";
            this.Tx_PackageNoRevort.Size = new System.Drawing.Size(139, 21);
            this.Tx_PackageNoRevort.TabIndex = 25;
            this.Tx_PackageNoRevort.TextChanged += new System.EventHandler(this.Tx_PackageNoRevort_TextChanged);
            this.Tx_PackageNoRevort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tx_PackageNoRevort_KeyDown);
            // 
            // Lbl_PackageCode
            // 
            this.Lbl_PackageCode.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Lbl_PackageCode.Location = new System.Drawing.Point(5, 100);
            this.Lbl_PackageCode.Name = "Lbl_PackageCode";
            this.Lbl_PackageCode.Size = new System.Drawing.Size(67, 15);
            this.Lbl_PackageCode.Text = "Ambalaj Kodu";
            this.Lbl_PackageCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Lbl_PackageTransfer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 15);
            // 
            // Frm_PaletSevk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm_PaletSevk";
            this.Text = "Frm_PaletSevk";
            this.OnLoad += new System.EventHandler(this.Frm_PaletSevk_Load);
            this.PanelBody.ResumeLayout(false);
            this.PanelFooter.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabOrder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPackage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.TabPackageItem.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPagePackageRevort.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBody;
        private System.Windows.Forms.DataGrid gridOrder;
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.TextBox Tx_Barcode;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.CheckBox Chk_Delete;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Button btnIrsaliyeOlustur;
        private System.Windows.Forms.Label Lbl_PackageTransfer;
        private System.Windows.Forms.TextBox TxOrderNo;
        private System.Windows.Forms.Label Lbl_ShippingOrder;
        private System.Windows.Forms.Button btnSevkSec;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPackage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGrid gridPackage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbSelectOrderInfo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabPage TabPackageItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGrid gridPackageItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbSelectPackageInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxTransporterDesc;
        private System.Windows.Forms.TextBox Tx_SalesPerson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSalesPerson;
        private System.Windows.Forms.TextBox tx_SerialNo;
        private System.Windows.Forms.TextBox tx_BarcodeQty;
        private System.Windows.Forms.TextBox Tx_Miktar;
        private System.Windows.Forms.TabPage tabPagePackageRevort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_PackRelease;
        private System.Windows.Forms.TextBox Tx_PackageNoRevort;
        private System.Windows.Forms.Label Lbl_PackageCode;
        private System.Windows.Forms.Label labelAck;
        private System.Windows.Forms.TextBox Tx_Note1;
        private System.Windows.Forms.TextBox Tx_PackageMId;
        private System.Windows.Forms.TextBox Tx_ReadLocationCode;
        private System.Windows.Forms.Label Lbl_ReadLocationCode;
        private System.Windows.Forms.TextBox Tx_ReadLocationId;
    }
}