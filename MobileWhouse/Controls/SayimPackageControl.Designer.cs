namespace MobileWhouse.Controls
{
    partial class SayimPackageControl
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
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Tx_DocNo = new System.Windows.Forms.TextBox();
            this.Lbl_DockNo = new System.Windows.Forms.Label();
            this.Lbl_Date = new System.Windows.Forms.Label();
            this.Dt_DocDate = new System.Windows.Forms.DateTimePicker();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tx_LocationCode = new System.Windows.Forms.TextBox();
            this.Tx_Barcode = new System.Windows.Forms.TextBox();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.Chk_Delete = new System.Windows.Forms.CheckBox();
            this.tx_Location_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Save
            // 
            this.Btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Save.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.Btn_Save.Location = new System.Drawing.Point(179, 4);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(58, 18);
            this.Btn_Save.TabIndex = 27;
            this.Btn_Save.Text = "Kaydet";
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Tx_DocNo
            // 
            this.Tx_DocNo.Location = new System.Drawing.Point(63, 26);
            this.Tx_DocNo.Name = "Tx_DocNo";
            this.Tx_DocNo.Size = new System.Drawing.Size(110, 21);
            this.Tx_DocNo.TabIndex = 26;
            // 
            // Lbl_DockNo
            // 
            this.Lbl_DockNo.ForeColor = System.Drawing.Color.Black;
            this.Lbl_DockNo.Location = new System.Drawing.Point(3, 26);
            this.Lbl_DockNo.Name = "Lbl_DockNo";
            this.Lbl_DockNo.Size = new System.Drawing.Size(54, 21);
            this.Lbl_DockNo.Text = "Belge No";
            this.Lbl_DockNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_Date
            // 
            this.Lbl_Date.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Date.Location = new System.Drawing.Point(5, 7);
            this.Lbl_Date.Name = "Lbl_Date";
            this.Lbl_Date.Size = new System.Drawing.Size(52, 15);
            this.Lbl_Date.Text = "Tarih";
            this.Lbl_Date.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Dt_DocDate
            // 
            this.Dt_DocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dt_DocDate.Location = new System.Drawing.Point(63, 3);
            this.Dt_DocDate.Name = "Dt_DocDate";
            this.Dt_DocDate.Size = new System.Drawing.Size(110, 22);
            this.Dt_DocDate.TabIndex = 25;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 51);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 203);
            this.dataGrid1.TabIndex = 30;
            // 
            // tx_LocationCode
            // 
            this.tx_LocationCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tx_LocationCode.Location = new System.Drawing.Point(53, 256);
            this.tx_LocationCode.Name = "tx_LocationCode";
            this.tx_LocationCode.Size = new System.Drawing.Size(131, 21);
            this.tx_LocationCode.TabIndex = 48;
            // 
            // Tx_Barcode
            // 
            this.Tx_Barcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Tx_Barcode.BackColor = System.Drawing.Color.Yellow;
            this.Tx_Barcode.Location = new System.Drawing.Point(53, 283);
            this.Tx_Barcode.Name = "Tx_Barcode";
            this.Tx_Barcode.Size = new System.Drawing.Size(131, 21);
            this.Tx_Barcode.TabIndex = 45;
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Exit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.Btn_Exit.Location = new System.Drawing.Point(179, 26);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(58, 21);
            this.Btn_Exit.TabIndex = 47;
            this.Btn_Exit.Text = "Çıkış";
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Chk_Delete
            // 
            this.Chk_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Chk_Delete.Location = new System.Drawing.Point(190, 283);
            this.Chk_Delete.Name = "Chk_Delete";
            this.Chk_Delete.Size = new System.Drawing.Size(50, 20);
            this.Chk_Delete.TabIndex = 46;
            this.Chk_Delete.Text = "Sil";
            // 
            // tx_Location_Label
            // 
            this.tx_Location_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tx_Location_Label.Location = new System.Drawing.Point(3, 257);
            this.tx_Location_Label.Name = "tx_Location_Label";
            this.tx_Location_Label.Size = new System.Drawing.Size(40, 20);
            this.tx_Location_Label.Text = "Raf";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(3, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.Text = "Barkod";
            // 
            // SayimPackageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tx_LocationCode);
            this.Controls.Add(this.Tx_Barcode);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Chk_Delete);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Tx_DocNo);
            this.Controls.Add(this.Lbl_DockNo);
            this.Controls.Add(this.Lbl_Date);
            this.Controls.Add(this.Dt_DocDate);
            this.Controls.Add(this.tx_Location_Label);
            this.Controls.Add(this.label1);
            this.Name = "SayimPackageControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.OnLoad += new System.EventHandler(this.SayimPackageControl_OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.TextBox Tx_DocNo;
        private System.Windows.Forms.Label Lbl_DockNo;
        private System.Windows.Forms.Label Lbl_Date;
        private System.Windows.Forms.DateTimePicker Dt_DocDate;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox tx_LocationCode;
        private System.Windows.Forms.TextBox Tx_Barcode;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.CheckBox Chk_Delete;
        private System.Windows.Forms.Label tx_Location_Label;
        private System.Windows.Forms.Label label1;
    }
}
