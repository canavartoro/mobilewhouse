namespace MobileWhouse.Controls.PRD
{
    partial class DurusControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtaciklama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbvardiya = new MobileWhouse.GUI.ComboControl();
            this.cmddurusneden = new MobileWhouse.GUI.ComboControl();
            this.cmbpersonel = new MobileWhouse.GUI.ComboControl();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btntamam = new System.Windows.Forms.Button();
            this.txtistasyon = new MobileWhouse.GUI.ULookupEdit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "Duruş Nedeni";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.Text = "Açıklama";
            // 
            // txtaciklama
            // 
            this.txtaciklama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtaciklama.Location = new System.Drawing.Point(81, 164);
            this.txtaciklama.Multiline = true;
            this.txtaciklama.Name = "txtaciklama";
            this.txtaciklama.Size = new System.Drawing.Size(154, 68);
            this.txtaciklama.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "Vardiya Kod";
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "dd.MM.yy HH:mm";
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(81, 110);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(154, 22);
            this.dateStart.TabIndex = 52;
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "dd.MM.yy HH:mm";
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(81, 137);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(154, 22);
            this.dateEnd.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.Text = "Başlangıç:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.Text = "Bitiş:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.Text = "Personel ";
            // 
            // cmbvardiya
            // 
            this.cmbvardiya.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbvardiya.DataSourceType = MobileWhouse.Enums.DataSourceType.Vardiya;
            this.cmbvardiya.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbvardiya.FilterCondition = "";
            this.cmbvardiya.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbvardiya.Location = new System.Drawing.Point(81, 29);
            this.cmbvardiya.Name = "cmbvardiya";
            this.cmbvardiya.Size = new System.Drawing.Size(154, 22);
            this.cmbvardiya.TabIndex = 68;
            // 
            // cmddurusneden
            // 
            this.cmddurusneden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmddurusneden.DataSourceType = MobileWhouse.Enums.DataSourceType.Durus;
            this.cmddurusneden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmddurusneden.FilterCondition = "";
            this.cmddurusneden.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmddurusneden.Location = new System.Drawing.Point(81, 56);
            this.cmddurusneden.Name = "cmddurusneden";
            this.cmddurusneden.Size = new System.Drawing.Size(154, 22);
            this.cmddurusneden.TabIndex = 68;
            // 
            // cmbpersonel
            // 
            this.cmbpersonel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbpersonel.DataSourceType = MobileWhouse.Enums.DataSourceType.Personel;
            this.cmbpersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbpersonel.FilterCondition = "";
            this.cmbpersonel.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbpersonel.Location = new System.Drawing.Point(81, 83);
            this.cmbpersonel.Name = "cmbpersonel";
            this.cmbpersonel.Size = new System.Drawing.Size(154, 22);
            this.cmbpersonel.TabIndex = 76;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKapat.Location = new System.Drawing.Point(4, 247);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(116, 39);
            this.btnKapat.TabIndex = 84;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btntamam
            // 
            this.btntamam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btntamam.Location = new System.Drawing.Point(126, 247);
            this.btntamam.Name = "btntamam";
            this.btntamam.Size = new System.Drawing.Size(109, 39);
            this.btntamam.TabIndex = 85;
            this.btntamam.Text = "Kaydet";
            this.btntamam.Click += new System.EventHandler(this.btntamam_Click);
            // 
            // txtistasyon
            // 
            this.txtistasyon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtistasyon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtistasyon.Browsable = true;
            this.txtistasyon.DataFieldName = "";
            this.txtistasyon.DataType = MobileWhouse.Enums.DataSourceType.Uretim_IsEmri_Istasyon;
            this.txtistasyon.Description = "";
            this.txtistasyon.FilterCondition = "";
            this.txtistasyon.LabelText = "İstasyon";
            this.txtistasyon.LabelWidth = 76;
            this.txtistasyon.Location = new System.Drawing.Point(4, 0);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.PurchaseSales = -1;
            this.txtistasyon.RememberValue = false;
            this.txtistasyon.ShowDescription = false;
            this.txtistasyon.ShowLabelText = false;
            this.txtistasyon.Size = new System.Drawing.Size(231, 27);
            this.txtistasyon.SourceApplication = 0;
            this.txtistasyon.TabIndex = 93;
            this.txtistasyon.OnSelected += new MobileWhouse.OnSelectedObject(this.txtistasyon_OnSelected);
            // 
            // DurusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cmbvardiya);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btntamam);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.cmbpersonel);
            this.Controls.Add(this.cmddurusneden);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.txtaciklama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtistasyon);
            this.Name = "DurusControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.OnLoad += new System.EventHandler(this.DurusControl_OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtaciklama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private MobileWhouse.GUI.ComboControl cmbvardiya;
        private MobileWhouse.GUI.ComboControl cmddurusneden;
        private MobileWhouse.GUI.ComboControl cmbpersonel;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btntamam;
        private MobileWhouse.GUI.ULookupEdit txtistasyon;
    }
}
