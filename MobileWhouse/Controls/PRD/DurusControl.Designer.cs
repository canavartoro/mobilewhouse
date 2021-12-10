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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DurusControl));
            this.btnistasyon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtistasyon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnKapat = new MobileWhouse.GUI.ColourButton();
            this.btntamam = new MobileWhouse.GUI.ColourButton();
            this.SuspendLayout();
            // 
            // btnistasyon
            // 
            this.btnistasyon.Location = new System.Drawing.Point(198, 3);
            this.btnistasyon.Name = "btnistasyon";
            this.btnistasyon.Size = new System.Drawing.Size(37, 20);
            this.btnistasyon.TabIndex = 32;
            this.btnistasyon.Text = "...";
            this.btnistasyon.Click += new System.EventHandler(this.btnistasyon_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.Text = "Duruş Nedeni";
            // 
            // txtistasyon
            // 
            this.txtistasyon.Location = new System.Drawing.Point(81, 3);
            this.txtistasyon.Name = "txtistasyon";
            this.txtistasyon.Size = new System.Drawing.Size(116, 21);
            this.txtistasyon.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.Text = "İstasyon Kod";
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
            this.cmbvardiya.DataSourceType = MobileWhouse.Models.DataSourceType.Vardiya;
            this.cmbvardiya.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbvardiya.Location = new System.Drawing.Point(81, 29);
            this.cmbvardiya.Name = "cmbvardiya";
            this.cmbvardiya.Size = new System.Drawing.Size(154, 22);
            this.cmbvardiya.TabIndex = 68;
            // 
            // cmddurusneden
            // 
            this.cmddurusneden.DataSourceType = MobileWhouse.Models.DataSourceType.Durus;
            this.cmddurusneden.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmddurusneden.Location = new System.Drawing.Point(81, 56);
            this.cmddurusneden.Name = "cmddurusneden";
            this.cmddurusneden.Size = new System.Drawing.Size(154, 22);
            this.cmddurusneden.TabIndex = 68;
            // 
            // cmbpersonel
            // 
            this.cmbpersonel.DataSourceType = MobileWhouse.Models.DataSourceType.Personel;
            this.cmbpersonel.HurdaTip = MobileWhouse.Enums.ScrapType.Tumu;
            this.cmbpersonel.Location = new System.Drawing.Point(81, 83);
            this.cmbpersonel.Name = "cmbpersonel";
            this.cmbpersonel.Size = new System.Drawing.Size(154, 22);
            this.cmbpersonel.TabIndex = 76;
            // 
            // btnKapat
            // 
            this.btnKapat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnKapat.BackColor = System.Drawing.Color.Empty;
            this.btnKapat.ForeColor = System.Drawing.Color.Empty;
            this.btnKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.Image")));
            this.btnKapat.Location = new System.Drawing.Point(4, 247);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnKapat.NormalTxtColour = System.Drawing.Color.Black;
            this.btnKapat.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnKapat.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnKapat.Size = new System.Drawing.Size(116, 39);
            this.btnKapat.TabIndex = 84;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btntamam
            // 
            this.btntamam.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btntamam.BackColor = System.Drawing.Color.Empty;
            this.btntamam.ForeColor = System.Drawing.Color.Empty;
            this.btntamam.Image = ((System.Drawing.Image)(resources.GetObject("btntamam.Image")));
            this.btntamam.Location = new System.Drawing.Point(126, 247);
            this.btntamam.Name = "btntamam";
            this.btntamam.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btntamam.NormalTxtColour = System.Drawing.Color.Blue;
            this.btntamam.PushedBtnColour = System.Drawing.Color.Blue;
            this.btntamam.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btntamam.Size = new System.Drawing.Size(109, 39);
            this.btntamam.TabIndex = 85;
            this.btntamam.Text = "Kaydet";
            this.btntamam.Click += new System.EventHandler(this.btntamam_Click);
            // 
            // DurusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btntamam);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.cmbpersonel);
            this.Controls.Add(this.cmddurusneden);
            this.Controls.Add(this.cmbvardiya);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.txtaciklama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnistasyon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtistasyon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Name = "DurusControl";
            this.Size = new System.Drawing.Size(240, 315);
            this.OnLoad += new System.EventHandler(this.DurusControl_OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnistasyon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtistasyon;
        private System.Windows.Forms.Label label1;
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
        private MobileWhouse.GUI.ColourButton btnKapat;
        private MobileWhouse.GUI.ColourButton btntamam;
    }
}
