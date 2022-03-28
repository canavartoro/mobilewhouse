namespace MobileWhouse
{
    partial class FormParametreler
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numetiketsurelimit = new System.Windows.Forms.NumericUpDown();
            this.numetiketadetlimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.secblokehareket = new MobileWhouse.GUI.ULookupEdit();
            this.secblokedepo = new MobileWhouse.GUI.ULookupEdit();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.btnkapat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textAmbPrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPltPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textMalPrefix = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 257);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textMalPrefix);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textPltPrefix);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textAmbPrefix);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.numetiketsurelimit);
            this.tabPage1.Controls.Add(this.numetiketadetlimit);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 234);
            this.tabPage1.Text = "Genel";
            // 
            // numetiketsurelimit
            // 
            this.numetiketsurelimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numetiketsurelimit.Location = new System.Drawing.Point(109, 4);
            this.numetiketsurelimit.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numetiketsurelimit.Name = "numetiketsurelimit";
            this.numetiketsurelimit.Size = new System.Drawing.Size(124, 22);
            this.numetiketsurelimit.TabIndex = 2;
            // 
            // numetiketadetlimit
            // 
            this.numetiketadetlimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numetiketadetlimit.Location = new System.Drawing.Point(109, 32);
            this.numetiketadetlimit.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numetiketadetlimit.Name = "numetiketadetlimit";
            this.numetiketadetlimit.Size = new System.Drawing.Size(124, 22);
            this.numetiketadetlimit.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Etiket Adet Limit";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.Text = "Etiket Süre Limit";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.secblokehareket);
            this.tabPage2.Controls.Add(this.secblokedepo);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 231);
            this.tabPage2.Text = "Kalite";
            // 
            // secblokehareket
            // 
            this.secblokehareket.Browsable = true;
            this.secblokehareket.DataFieldName = "";
            this.secblokehareket.DataType = MobileWhouse.Enums.DataSourceType.Hareket;
            this.secblokehareket.Description = "";
            this.secblokehareket.FilterCondition = "";
            this.secblokehareket.LabelText = "Bloke Hareket";
            this.secblokehareket.LabelWidth = 80;
            this.secblokehareket.Location = new System.Drawing.Point(2, 35);
            this.secblokehareket.Name = "secblokehareket";
            this.secblokehareket.PurchaseSales = -1;
            this.secblokehareket.RememberValue = false;
            this.secblokehareket.ShowDescription = false;
            this.secblokehareket.ShowLabelText = false;
            this.secblokehareket.Size = new System.Drawing.Size(238, 27);
            this.secblokehareket.SourceApplication = 212;
            this.secblokehareket.TabIndex = 1;
            // 
            // secblokedepo
            // 
            this.secblokedepo.Browsable = true;
            this.secblokedepo.DataFieldName = "";
            this.secblokedepo.DataType = MobileWhouse.Enums.DataSourceType.Depo;
            this.secblokedepo.Description = "";
            this.secblokedepo.FilterCondition = "";
            this.secblokedepo.LabelText = "Bloke Depo";
            this.secblokedepo.LabelWidth = 80;
            this.secblokedepo.Location = new System.Drawing.Point(2, 2);
            this.secblokedepo.Name = "secblokedepo";
            this.secblokedepo.PurchaseSales = -1;
            this.secblokedepo.RememberValue = false;
            this.secblokedepo.ShowDescription = false;
            this.secblokedepo.ShowLabelText = false;
            this.secblokedepo.Size = new System.Drawing.Size(238, 27);
            this.secblokedepo.SourceApplication = 0;
            this.secblokedepo.TabIndex = 0;
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(121, 258);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(117, 33);
            this.btnkaydet.TabIndex = 21;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.Location = new System.Drawing.Point(3, 258);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(112, 33);
            this.btnkapat.TabIndex = 20;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Ambalaj Prefix";
            // 
            // textAmbPrefix
            // 
            this.textAmbPrefix.Location = new System.Drawing.Point(109, 60);
            this.textAmbPrefix.MaxLength = 3;
            this.textAmbPrefix.Name = "textAmbPrefix";
            this.textAmbPrefix.Size = new System.Drawing.Size(100, 21);
            this.textAmbPrefix.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Palet Prefix";
            // 
            // textPltPrefix
            // 
            this.textPltPrefix.Location = new System.Drawing.Point(109, 87);
            this.textPltPrefix.MaxLength = 3;
            this.textPltPrefix.Name = "textPltPrefix";
            this.textPltPrefix.Size = new System.Drawing.Size(100, 21);
            this.textPltPrefix.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "Mal Kabul Prefix";
            // 
            // textMalPrefix
            // 
            this.textMalPrefix.Location = new System.Drawing.Point(109, 114);
            this.textMalPrefix.MaxLength = 3;
            this.textMalPrefix.Name = "textMalPrefix";
            this.textMalPrefix.Size = new System.Drawing.Size(100, 21);
            this.textMalPrefix.TabIndex = 6;
            // 
            // FormParametreler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.btnkapat);
            this.Name = "FormParametreler";
            this.Text = "Parametreler";
            this.Load += new System.EventHandler(this.FormParametreler_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MobileWhouse.GUI.ULookupEdit secblokedepo;
        private MobileWhouse.GUI.ULookupEdit secblokehareket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numetiketsurelimit;
        private System.Windows.Forms.NumericUpDown numetiketadetlimit;
        private System.Windows.Forms.TextBox textAmbPrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textMalPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPltPrefix;
        private System.Windows.Forms.Label label4;

    }
}