namespace MobileWhouse.Dilogs
{
    partial class FormSelectAlisIrsaliye
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtdocno = new System.Windows.Forms.TextBox();
            this.t1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtentity = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.Button();
            this.datedoc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.Text = "Belge No";
            // 
            // txtdocno
            // 
            this.txtdocno.Location = new System.Drawing.Point(79, 4);
            this.txtdocno.Name = "txtdocno";
            this.txtdocno.Size = new System.Drawing.Size(131, 21);
            this.txtdocno.TabIndex = 1;
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(211, 4);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(22, 21);
            this.t1.TabIndex = 3;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.Text = "Cari Kodu";
            // 
            // txtentity
            // 
            this.txtentity.Location = new System.Drawing.Point(79, 31);
            this.txtentity.Name = "txtentity";
            this.txtentity.Size = new System.Drawing.Size(131, 21);
            this.txtentity.TabIndex = 1;
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(211, 31);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(22, 21);
            this.t2.TabIndex = 3;
            this.t2.Text = "T";
            this.t2.Click += new System.EventHandler(this.t2_Click);
            // 
            // datedoc
            // 
            this.datedoc.CustomFormat = "dd.MM.yyyy";
            this.datedoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datedoc.Location = new System.Drawing.Point(79, 58);
            this.datedoc.Name = "datedoc";
            this.datedoc.Size = new System.Drawing.Size(91, 22);
            this.datedoc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.Text = "Belge Tarihi";
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(171, 58);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(62, 22);
            this.btnrefresh.TabIndex = 7;
            this.btnrefresh.Text = "Sorgula";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Columns.Add(this.columnHeader5);
            this.listView1.Columns.Add(this.columnHeader6);
            this.listView1.Columns.Add(this.columnHeader7);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 231);
            this.listView1.TabIndex = 8;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "B. Tarih";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Belge No";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "H. Kod";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Açıklama";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cari Kod";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Cari Adı";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Detay Satır";
            this.columnHeader7.Width = 60;
            // 
            // FormSelectAlisIrsaliye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.datedoc);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.txtentity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdocno);
            this.Controls.Add(this.label1);
            this.Name = "FormSelectAlisIrsaliye";
            this.Text = "İrsaliyeler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdocno;
        private System.Windows.Forms.Button t1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtentity;
        private System.Windows.Forms.Button t2;
        private System.Windows.Forms.DateTimePicker datedoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}