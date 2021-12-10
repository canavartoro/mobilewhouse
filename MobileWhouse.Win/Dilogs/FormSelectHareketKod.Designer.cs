namespace MobileWhouse.Dilogs
{
    partial class FormSelectHareketKod
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
            this.txtDocTraCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lswDocTra = new System.Windows.Forms.ListView();
            this.Id = new System.Windows.Forms.ColumnHeader();
            this.DocTraCode = new System.Windows.Forms.ColumnHeader();
            this.DocTraDesc = new System.Windows.Forms.ColumnHeader();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDocTraCode
            // 
            this.txtDocTraCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocTraCode.Location = new System.Drawing.Point(0, 3);
            this.txtDocTraCode.Name = "txtDocTraCode";
            this.txtDocTraCode.Size = new System.Drawing.Size(162, 21);
            this.txtDocTraCode.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(168, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 20);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Ara";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lswDocTra
            // 
            this.lswDocTra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lswDocTra.Columns.Add(this.Id);
            this.lswDocTra.Columns.Add(this.DocTraCode);
            this.lswDocTra.Columns.Add(this.DocTraDesc);
            this.lswDocTra.FullRowSelect = true;
            this.lswDocTra.Location = new System.Drawing.Point(3, 30);
            this.lswDocTra.Name = "lswDocTra";
            this.lswDocTra.Size = new System.Drawing.Size(235, 264);
            this.lswDocTra.TabIndex = 2;
            this.lswDocTra.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 27;
            // 
            // DocTraCode
            // 
            this.DocTraCode.Text = "Hareket Kod";
            this.DocTraCode.Width = 90;
            // 
            // DocTraDesc
            // 
            this.DocTraDesc.Text = "Hareket Ad";
            this.DocTraDesc.Width = 105;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(166, 297);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(72, 20);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "Seç";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(3, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Kapat";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormSelectHareketKod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.lswDocTra);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDocTraCode);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormSelectHareketKod";
            this.Text = "Hareket Kodu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocTraCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lswDocTra;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader DocTraCode;
        private System.Windows.Forms.ColumnHeader DocTraDesc;
        private System.Windows.Forms.Button btnClose;
    }
}