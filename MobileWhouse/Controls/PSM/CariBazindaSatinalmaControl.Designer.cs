namespace MobileWhouse.Controls.PSM
{
    partial class CariBazindaSatinalmaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKapat = new MobileWhouse.GUI.UButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.t1 = new System.Windows.Forms.Button();
            this.t2 = new System.Windows.Forms.Button();
            this.btnparti = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.textBox1 = new MobileWhouse.GUI.TextBoxNumeric();
            this.Chk_Delete = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lookupdoctra = new MobileWhouse.GUI.ULookupEdit();
            this.Tx_IrsaliyeSeri = new System.Windows.Forms.TextBox();
            this.Tx_IrsaliyeSira = new MobileWhouse.GUI.TextBoxNumeric();
            this.label4 = new System.Windows.Forms.Label();
            this.Tx_IrsaliyeNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Dt_IrsaliyeTarihi = new System.Windows.Forms.DateTimePicker();
            this.btn_IrsaliyeOlustur = new MobileWhouse.GUI.UButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKapat
            // 
            this.btnKapat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnKapat.BackColor = System.Drawing.Color.Empty;
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKapat.ForeColor = System.Drawing.Color.Empty;
            this.btnKapat.Location = new System.Drawing.Point(0, 278);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnKapat.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnKapat.Size = new System.Drawing.Size(240, 42);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 278);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.t1);
            this.tabPage1.Controls.Add(this.t2);
            this.tabPage1.Controls.Add(this.btnparti);
            this.tabPage1.Controls.Add(this.txt_Barcode);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.Chk_Delete);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 255);
            this.tabPage1.Text = "Detaylar";
            // 
            // t1
            // 
            this.t1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.t1.Location = new System.Drawing.Point(174, 7);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(22, 21);
            this.t1.TabIndex = 15;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(135, 34);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(22, 21);
            this.t2.TabIndex = 14;
            this.t2.Text = "T";
            this.t2.Click += new System.EventHandler(this.t2_Click);
            // 
            // btnparti
            // 
            this.btnparti.Location = new System.Drawing.Point(158, 34);
            this.btnparti.Name = "btnparti";
            this.btnparti.Size = new System.Drawing.Size(75, 21);
            this.btnparti.TabIndex = 13;
            this.btnparti.Text = "Parti Kodu";
            this.btnparti.Click += new System.EventHandler(this.btnparti_Click);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Barcode.BackColor = System.Drawing.Color.Yellow;
            this.txt_Barcode.Location = new System.Drawing.Point(49, 7);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(124, 21);
            this.txt_Barcode.TabIndex = 7;
            this.txt_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Barcode_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.AllowSpace = false;
            this.textBox1.BackColor = System.Drawing.Color.LightCyan;
            this.textBox1.Location = new System.Drawing.Point(49, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "1";
            // 
            // Chk_Delete
            // 
            this.Chk_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Chk_Delete.Location = new System.Drawing.Point(196, 7);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new System.Drawing.Size(44, 20);
            this.Chk_Delete.TabIndex = 3;
            this.Chk_Delete.Text = "Sil";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.Text = "Barkod";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Columns.Add(this.columnHeader7);
            this.listView1.Columns.Add(this.columnHeader6);
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader5);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 195);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stok Kod";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Stok Ad";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Okunan";
            this.columnHeader7.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Sip Miktar";
            this.columnHeader6.Width = 60;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dty Kod";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dty_Adı";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Parti Kodu";
            this.columnHeader5.Width = 60;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.Text = "Miktar";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lookupdoctra);
            this.tabPage2.Controls.Add(this.Tx_IrsaliyeSeri);
            this.tabPage2.Controls.Add(this.Tx_IrsaliyeSira);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.Tx_IrsaliyeNo);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Dt_IrsaliyeTarihi);
            this.tabPage2.Controls.Add(this.btn_IrsaliyeOlustur);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 252);
            this.tabPage2.Text = "İrsaliye";
            // 
            // lookupdoctra
            // 
            this.lookupdoctra.BackColor = System.Drawing.Color.White;
            this.lookupdoctra.Browsable = true;
            this.lookupdoctra.DataFieldName = "";
            this.lookupdoctra.DataType = MobileWhouse.Enums.DataSourceType.Hareket;
            this.lookupdoctra.Description = "";
            this.lookupdoctra.FilterCondition = "";
            this.lookupdoctra.LabelText = "H. Kodu";
            this.lookupdoctra.LabelWidth = 70;
            this.lookupdoctra.Location = new System.Drawing.Point(7, 3);
            this.lookupdoctra.Name = "lookupdoctra";
            this.lookupdoctra.PurchaseSales = 1;
            this.lookupdoctra.RememberValue = true;
            this.lookupdoctra.ShowDescription = false;
            this.lookupdoctra.ShowLabelText = false;
            this.lookupdoctra.Size = new System.Drawing.Size(226, 27);
            this.lookupdoctra.SourceApplication = 1000;
            this.lookupdoctra.TabIndex = 16;
            // 
            // Tx_IrsaliyeSeri
            // 
            this.Tx_IrsaliyeSeri.Location = new System.Drawing.Point(91, 86);
            this.Tx_IrsaliyeSeri.Name = "Tx_IrsaliyeSeri";
            this.Tx_IrsaliyeSeri.Size = new System.Drawing.Size(51, 21);
            this.Tx_IrsaliyeSeri.TabIndex = 12;
            // 
            // Tx_IrsaliyeSira
            // 
            this.Tx_IrsaliyeSira.AllowSpace = false;
            this.Tx_IrsaliyeSira.BackColor = System.Drawing.Color.Azure;
            this.Tx_IrsaliyeSira.Location = new System.Drawing.Point(148, 86);
            this.Tx_IrsaliyeSira.Name = "Tx_IrsaliyeSira";
            this.Tx_IrsaliyeSira.Size = new System.Drawing.Size(61, 21);
            this.Tx_IrsaliyeSira.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.Text = "Seri - Sıra No";
            // 
            // Tx_IrsaliyeNo
            // 
            this.Tx_IrsaliyeNo.Location = new System.Drawing.Point(91, 59);
            this.Tx_IrsaliyeNo.Name = "Tx_IrsaliyeNo";
            this.Tx_IrsaliyeNo.Size = new System.Drawing.Size(118, 21);
            this.Tx_IrsaliyeNo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.Text = "İrsaliye No";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.Text = "Tarih";
            // 
            // Dt_IrsaliyeTarihi
            // 
            this.Dt_IrsaliyeTarihi.CustomFormat = "dd.MM.yyyy";
            this.Dt_IrsaliyeTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dt_IrsaliyeTarihi.Location = new System.Drawing.Point(91, 31);
            this.Dt_IrsaliyeTarihi.Name = "Dt_IrsaliyeTarihi";
            this.Dt_IrsaliyeTarihi.Size = new System.Drawing.Size(118, 22);
            this.Dt_IrsaliyeTarihi.TabIndex = 1;
            // 
            // btn_IrsaliyeOlustur
            // 
            this.btn_IrsaliyeOlustur.Alignment = MobileWhouse.GUI.ImageAlignment.Right;
            this.btn_IrsaliyeOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_IrsaliyeOlustur.BackColor = System.Drawing.Color.Empty;
            this.btn_IrsaliyeOlustur.ForeColor = System.Drawing.Color.Empty;
            this.btn_IrsaliyeOlustur.Location = new System.Drawing.Point(37, 206);
            this.btn_IrsaliyeOlustur.Name = "btn_IrsaliyeOlustur";
            this.btn_IrsaliyeOlustur.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btn_IrsaliyeOlustur.NormalTxtColour = System.Drawing.Color.Blue;
            this.btn_IrsaliyeOlustur.PushedBtnColour = System.Drawing.Color.Blue;
            this.btn_IrsaliyeOlustur.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btn_IrsaliyeOlustur.Size = new System.Drawing.Size(172, 34);
            this.btn_IrsaliyeOlustur.TabIndex = 0;
            this.btn_IrsaliyeOlustur.Text = "İrsaliye Oluştur";
            this.btn_IrsaliyeOlustur.Click += new System.EventHandler(this.btn_IrsaliyeOlustur_Click);
            // 
            // CariBazindaSatinalmaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnKapat);
            this.Name = "CariBazindaSatinalmaControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.OnLoad += new System.EventHandler(this.SatinalmaMalKabulControl_OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.UButton btnKapat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.CheckBox Chk_Delete;
        private System.Windows.Forms.Label label1;
        private MobileWhouse.GUI.TextBoxNumeric textBox1;
        private System.Windows.Forms.TextBox txt_Barcode;
        private GUI.UButton btn_IrsaliyeOlustur;
        private System.Windows.Forms.DateTimePicker Dt_IrsaliyeTarihi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tx_IrsaliyeNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MobileWhouse.GUI.TextBoxNumeric Tx_IrsaliyeSira;
        private System.Windows.Forms.TextBox Tx_IrsaliyeSeri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button t1;
        private System.Windows.Forms.Button t2;
        private System.Windows.Forms.Button btnparti;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private MobileWhouse.GUI.ULookupEdit lookupdoctra;
    }
}
