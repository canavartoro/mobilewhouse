namespace MobileWhouse.Controls
{
    partial class FrmAracBilgi
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
            this.Lbl_VehicleCode = new System.Windows.Forms.Label();
            this.Lbl_LicencePlate = new System.Windows.Forms.Label();
            this.Tx_VehicleCode = new System.Windows.Forms.TextBox();
            this.Tx_LicencePlate = new System.Windows.Forms.TextBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_VehicleCode = new System.Windows.Forms.Button();
            this.Tx_DriverName = new System.Windows.Forms.TextBox();
            this.Lbl_DriverName = new System.Windows.Forms.Label();
            this.Tx_DriverFamilyName = new System.Windows.Forms.TextBox();
            this.Lbl_DriverFamilyName = new System.Windows.Forms.Label();
            this.Tx_DriverGsmNo = new System.Windows.Forms.TextBox();
            this.Lbl_DriverGsmNo = new System.Windows.Forms.Label();
            this.Tx_TransportEquipment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_ShippingDesc1 = new System.Windows.Forms.TextBox();
            this.Lbl_ShippingDesc1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lbl_Trans = new System.Windows.Forms.Label();
            this.Lbl_DriverIdentifyNo = new System.Windows.Forms.Label();
            this.Tx_DriverIdentifyNo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_VehicleCode
            // 
            this.Lbl_VehicleCode.Location = new System.Drawing.Point(1, 29);
            this.Lbl_VehicleCode.Name = "Lbl_VehicleCode";
            this.Lbl_VehicleCode.Size = new System.Drawing.Size(92, 24);
            this.Lbl_VehicleCode.Text = "Araç Kodu";
            // 
            // Lbl_LicencePlate
            // 
            this.Lbl_LicencePlate.Location = new System.Drawing.Point(1, 53);
            this.Lbl_LicencePlate.Name = "Lbl_LicencePlate";
            this.Lbl_LicencePlate.Size = new System.Drawing.Size(92, 25);
            this.Lbl_LicencePlate.Text = "Plaka";
            // 
            // Tx_VehicleCode
            // 
            this.Tx_VehicleCode.Location = new System.Drawing.Point(99, 29);
            this.Tx_VehicleCode.Name = "Tx_VehicleCode";
            this.Tx_VehicleCode.ReadOnly = true;
            this.Tx_VehicleCode.Size = new System.Drawing.Size(106, 21);
            this.Tx_VehicleCode.TabIndex = 14;
            this.Tx_VehicleCode.Tag = "Lbl_VehicleCode";
            // 
            // Tx_LicencePlate
            // 
            this.Tx_LicencePlate.Location = new System.Drawing.Point(99, 54);
            this.Tx_LicencePlate.Name = "Tx_LicencePlate";
            this.Tx_LicencePlate.Size = new System.Drawing.Size(138, 21);
            this.Tx_LicencePlate.TabIndex = 16;
            this.Tx_LicencePlate.Tag = "Lbl_LicencePlate";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Save.Location = new System.Drawing.Point(0, 0);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(240, 36);
            this.Btn_Save.TabIndex = 19;
            this.Btn_Save.Text = "Kaydet";
            this.Btn_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Cancel.Location = new System.Drawing.Point(0, 0);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(240, 43);
            this.Btn_Cancel.TabIndex = 20;
            this.Btn_Cancel.Text = "Vazgeç";
            this.Btn_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 43);
            // 
            // button_VehicleCode
            // 
            this.button_VehicleCode.Location = new System.Drawing.Point(208, 31);
            this.button_VehicleCode.Name = "button_VehicleCode";
            this.button_VehicleCode.Size = new System.Drawing.Size(24, 20);
            this.button_VehicleCode.TabIndex = 26;
            this.button_VehicleCode.Text = "...";
            this.button_VehicleCode.Click += new System.EventHandler(this.button_VehicleCode_Click);
            // 
            // Tx_DriverName
            // 
            this.Tx_DriverName.Location = new System.Drawing.Point(99, 79);
            this.Tx_DriverName.Name = "Tx_DriverName";
            this.Tx_DriverName.Size = new System.Drawing.Size(138, 21);
            this.Tx_DriverName.TabIndex = 67;
            this.Tx_DriverName.Tag = "Lbl_DriverName";
            // 
            // Lbl_DriverName
            // 
            this.Lbl_DriverName.Location = new System.Drawing.Point(2, 78);
            this.Lbl_DriverName.Name = "Lbl_DriverName";
            this.Lbl_DriverName.Size = new System.Drawing.Size(92, 25);
            this.Lbl_DriverName.Text = "Şöför Adı";
            // 
            // Tx_DriverFamilyName
            // 
            this.Tx_DriverFamilyName.Location = new System.Drawing.Point(99, 104);
            this.Tx_DriverFamilyName.Name = "Tx_DriverFamilyName";
            this.Tx_DriverFamilyName.Size = new System.Drawing.Size(138, 21);
            this.Tx_DriverFamilyName.TabIndex = 70;
            this.Tx_DriverFamilyName.Tag = "Lbl_DriverFamilyName";
            // 
            // Lbl_DriverFamilyName
            // 
            this.Lbl_DriverFamilyName.Location = new System.Drawing.Point(2, 103);
            this.Lbl_DriverFamilyName.Name = "Lbl_DriverFamilyName";
            this.Lbl_DriverFamilyName.Size = new System.Drawing.Size(92, 25);
            this.Lbl_DriverFamilyName.Text = "Şoför Soyadı";
            // 
            // Tx_DriverGsmNo
            // 
            this.Tx_DriverGsmNo.Location = new System.Drawing.Point(99, 154);
            this.Tx_DriverGsmNo.Name = "Tx_DriverGsmNo";
            this.Tx_DriverGsmNo.Size = new System.Drawing.Size(138, 21);
            this.Tx_DriverGsmNo.TabIndex = 73;
            this.Tx_DriverGsmNo.Tag = "Lbl_DriverGsmNo";
            // 
            // Lbl_DriverGsmNo
            // 
            this.Lbl_DriverGsmNo.Location = new System.Drawing.Point(2, 153);
            this.Lbl_DriverGsmNo.Name = "Lbl_DriverGsmNo";
            this.Lbl_DriverGsmNo.Size = new System.Drawing.Size(92, 25);
            this.Lbl_DriverGsmNo.Text = "Cep No";
            // 
            // Tx_TransportEquipment
            // 
            this.Tx_TransportEquipment.Location = new System.Drawing.Point(99, 179);
            this.Tx_TransportEquipment.Name = "Tx_TransportEquipment";
            this.Tx_TransportEquipment.Size = new System.Drawing.Size(138, 21);
            this.Tx_TransportEquipment.TabIndex = 76;
            this.Tx_TransportEquipment.Tag = "Lbl_TransportEquipment";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.Text = "DorsePlaka";
            // 
            // Tx_ShippingDesc1
            // 
            this.Tx_ShippingDesc1.Location = new System.Drawing.Point(99, 204);
            this.Tx_ShippingDesc1.Name = "Tx_ShippingDesc1";
            this.Tx_ShippingDesc1.Size = new System.Drawing.Size(138, 21);
            this.Tx_ShippingDesc1.TabIndex = 79;
            this.Tx_ShippingDesc1.Tag = "Lbl_ShippingDesc1";
            // 
            // Lbl_ShippingDesc1
            // 
            this.Lbl_ShippingDesc1.Location = new System.Drawing.Point(2, 203);
            this.Lbl_ShippingDesc1.Name = "Lbl_ShippingDesc1";
            this.Lbl_ShippingDesc1.Size = new System.Drawing.Size(92, 25);
            this.Lbl_ShippingDesc1.Text = "Araç Açık.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Btn_Save);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 36);
            // 
            // Lbl_Trans
            // 
            this.Lbl_Trans.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.Lbl_Trans.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Trans.Location = new System.Drawing.Point(64, 0);
            this.Lbl_Trans.Name = "Lbl_Trans";
            this.Lbl_Trans.Size = new System.Drawing.Size(106, 20);
            this.Lbl_Trans.Text = "Araç Bilgileri";
            // 
            // Lbl_DriverIdentifyNo
            // 
            this.Lbl_DriverIdentifyNo.Location = new System.Drawing.Point(1, 128);
            this.Lbl_DriverIdentifyNo.Name = "Lbl_DriverIdentifyNo";
            this.Lbl_DriverIdentifyNo.Size = new System.Drawing.Size(92, 25);
            this.Lbl_DriverIdentifyNo.Text = "TCKN";
            // 
            // Tx_DriverIdentifyNo
            // 
            this.Tx_DriverIdentifyNo.Location = new System.Drawing.Point(99, 129);
            this.Tx_DriverIdentifyNo.Name = "Tx_DriverIdentifyNo";
            this.Tx_DriverIdentifyNo.Size = new System.Drawing.Size(138, 21);
            this.Tx_DriverIdentifyNo.TabIndex = 82;
            this.Tx_DriverIdentifyNo.Tag = "Lbl_DriverIdentifyNo";
            // 
            // FrmAracBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Lbl_Trans);
            this.Controls.Add(this.Tx_DriverIdentifyNo);
            this.Controls.Add(this.Lbl_DriverIdentifyNo);
            this.Controls.Add(this.Tx_ShippingDesc1);
            this.Controls.Add(this.Lbl_ShippingDesc1);
            this.Controls.Add(this.Tx_TransportEquipment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tx_DriverGsmNo);
            this.Controls.Add(this.Lbl_DriverGsmNo);
            this.Controls.Add(this.Tx_DriverFamilyName);
            this.Controls.Add(this.Lbl_DriverFamilyName);
            this.Controls.Add(this.Tx_DriverName);
            this.Controls.Add(this.Lbl_DriverName);
            this.Controls.Add(this.button_VehicleCode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tx_LicencePlate);
            this.Controls.Add(this.Tx_VehicleCode);
            this.Controls.Add(this.Lbl_LicencePlate);
            this.Controls.Add(this.Lbl_VehicleCode);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "FrmAracBilgi";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_VehicleCode;
        private System.Windows.Forms.Label Lbl_LicencePlate;
        private System.Windows.Forms.TextBox Tx_VehicleCode;
        private System.Windows.Forms.TextBox Tx_LicencePlate;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_VehicleCode;
        private System.Windows.Forms.TextBox Tx_DriverName;
        private System.Windows.Forms.Label Lbl_DriverName;
        private System.Windows.Forms.TextBox Tx_DriverFamilyName;
        private System.Windows.Forms.Label Lbl_DriverFamilyName;
        private System.Windows.Forms.TextBox Tx_DriverGsmNo;
        private System.Windows.Forms.Label Lbl_DriverGsmNo;
        private System.Windows.Forms.TextBox Tx_TransportEquipment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tx_ShippingDesc1;
        private System.Windows.Forms.Label Lbl_ShippingDesc1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lbl_Trans;
        private System.Windows.Forms.Label Lbl_DriverIdentifyNo;
        private System.Windows.Forms.TextBox Tx_DriverIdentifyNo;
    }
}