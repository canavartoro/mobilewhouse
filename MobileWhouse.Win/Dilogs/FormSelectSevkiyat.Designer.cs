namespace MobileWhouse.Dilogs
{
    partial class FormSelectSevkiyat
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
            this.lvwItems = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnIrsaliye = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.eName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItems.Columns.Add(this.columnHeader2);
            this.lvwItems.Columns.Add(this.columnHeader3);
            this.lvwItems.Columns.Add(this.columnHeader1);
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.Location = new System.Drawing.Point(4, 26);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(233, 269);
            this.lvwItems.TabIndex = 0;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.ItemActivate += new System.EventHandler(this.lvwItems_ItemActivate);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SevkE.No";
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Müşteri";
            this.columnHeader3.Width = 89;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "İş. Gör.";
            this.columnHeader1.Width = 60;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(165, 297);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(72, 20);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Seç";
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnIrsaliye
            // 
            this.btnIrsaliye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIrsaliye.Location = new System.Drawing.Point(165, 297);
            this.btnIrsaliye.Name = "btnIrsaliye";
            this.btnIrsaliye.Size = new System.Drawing.Size(72, 20);
            this.btnIrsaliye.TabIndex = 2;
            this.btnIrsaliye.Text = "İrsaliye";
            this.btnIrsaliye.Visible = false;
            this.btnIrsaliye.Click += new System.EventHandler(this.btnIrsaliye_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(4, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.Text = "Cari Ad";
            // 
            // eName
            // 
            this.eName.Location = new System.Drawing.Point(54, 3);
            this.eName.Name = "eName";
            this.eName.Size = new System.Drawing.Size(183, 21);
            this.eName.TabIndex = 5;
            this.eName.TextChanged += new System.EventHandler(this.eName_TextChanged);
            // 
            // FormSelectSevkiyat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.eName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIrsaliye);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lvwItems);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormSelectSevkiyat";
            this.Text = "Sevkiyat Seç";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnIrsaliye;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox eName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}