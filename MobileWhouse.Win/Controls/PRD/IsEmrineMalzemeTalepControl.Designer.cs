namespace MobileWhouse.Controls.PRD
{
    partial class IsEmrineMalzemeTalepControl
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
            this.btnkapat = new System.Windows.Forms.Button();
            this.listisemri = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.txtmiktar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnekle = new System.Windows.Forms.Button();
            this.txtisemrino = new MobileWhouse.GUI.ULookupEdit();
            this.txtdepo = new MobileWhouse.GUI.ULookupEdit();
            this.SuspendLayout();
            // 
            // btnkapat
            // 
            this.btnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnkapat.Location = new System.Drawing.Point(3, 292);
            this.btnkapat.Name = "btnkapat";
            this.btnkapat.Size = new System.Drawing.Size(62, 20);
            this.btnkapat.TabIndex = 4;
            this.btnkapat.Text = "Kapat";
            this.btnkapat.Click += new System.EventHandler(this.btnkapat_Click);
            // 
            // listisemri
            // 
            this.listisemri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listisemri.Columns.Add(this.columnHeader1);
            this.listisemri.Columns.Add(this.columnHeader2);
            this.listisemri.Columns.Add(this.columnHeader5);
            this.listisemri.Columns.Add(this.columnHeader3);
            this.listisemri.Columns.Add(this.columnHeader4);
            this.listisemri.FullRowSelect = true;
            this.listisemri.Location = new System.Drawing.Point(3, 110);
            this.listisemri.Name = "listisemri";
            this.listisemri.Size = new System.Drawing.Size(234, 179);
            this.listisemri.TabIndex = 7;
            this.listisemri.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stok Kodu";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stok Adı";
            this.columnHeader2.Width = 190;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Birim";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mevcut";
            this.columnHeader4.Width = 60;
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.Location = new System.Drawing.Point(174, 292);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(63, 20);
            this.btnkaydet.TabIndex = 8;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // txtmiktar
            // 
            this.txtmiktar.BackColor = System.Drawing.Color.SkyBlue;
            this.txtmiktar.Location = new System.Drawing.Point(52, 83);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(83, 21);
            this.txtmiktar.TabIndex = 15;
            this.txtmiktar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmiktar_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.Text = "Miktar:";
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(157, 83);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(83, 21);
            this.btnsil.TabIndex = 17;
            this.btnsil.Text = "Satır Sil";
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnekle
            // 
            this.btnekle.Location = new System.Drawing.Point(134, 82);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(20, 22);
            this.btnekle.TabIndex = 3;
            this.btnekle.Text = "...";
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // txtisemrino
            // 
            this.txtisemrino.Browsable = false;
            this.txtisemrino.DataFieldName = "";
            this.txtisemrino.DataType = MobileWhouse.Enums.DataSourceType.IsEmri;
            this.txtisemrino.Description = "";
            this.txtisemrino.FilterCondition = "";
            this.txtisemrino.LabelText = "İş Emri";
            this.txtisemrino.LabelWidth = 70;
            this.txtisemrino.Location = new System.Drawing.Point(3, 3);
            this.txtisemrino.Name = "txtisemrino";
            this.txtisemrino.PurchaseSales = -1;
            this.txtisemrino.RememberValue = false;
            this.txtisemrino.ShowDescription = false;
            this.txtisemrino.ShowLabelText = false;
            this.txtisemrino.Size = new System.Drawing.Size(234, 27);
            this.txtisemrino.SourceApplication = 0;
            this.txtisemrino.TabIndex = 19;
            this.txtisemrino.OnSelected += new MobileWhouse.OnSelectedObject(this.txtisemrino_OnSelected);
            // 
            // txtdepo
            // 
            this.txtdepo.Browsable = true;
            this.txtdepo.DataFieldName = "";
            this.txtdepo.DataType = MobileWhouse.Enums.DataSourceType.Depo;
            this.txtdepo.Description = "";
            this.txtdepo.FilterCondition = "";
            this.txtdepo.LabelText = "Depo";
            this.txtdepo.LabelWidth = 70;
            this.txtdepo.Location = new System.Drawing.Point(3, 28);
            this.txtdepo.Name = "txtdepo";
            this.txtdepo.PurchaseSales = -1;
            this.txtdepo.RememberValue = false;
            this.txtdepo.ShowDescription = false;
            this.txtdepo.ShowLabelText = false;
            this.txtdepo.Size = new System.Drawing.Size(234, 27);
            this.txtdepo.SourceApplication = 0;
            this.txtdepo.TabIndex = 20;
            this.txtdepo.OnSelected += new MobileWhouse.OnSelectedObject(this.txtdepo_OnSelected);
            // 
            // IsEmrineMalzemeTalepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtdepo);
            this.Controls.Add(this.txtisemrino);
            this.Controls.Add(this.btnsil);
            this.Controls.Add(this.txtmiktar);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.listisemri);
            this.Controls.Add(this.btnkapat);
            this.Controls.Add(this.btnekle);
            this.Controls.Add(this.label3);
            this.Name = "IsEmrineMalzemeTalepControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkapat;
        private System.Windows.Forms.ListView listisemri;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtmiktar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnekle;
        private MobileWhouse.GUI.ULookupEdit txtisemrino;
        private MobileWhouse.GUI.ULookupEdit txtdepo;

    }
}
