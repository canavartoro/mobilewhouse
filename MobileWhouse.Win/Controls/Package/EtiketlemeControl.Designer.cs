namespace MobileWhouse.Controls.Package
{
    partial class EtiketlemeControl
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
            this.printetiketleme = new MobileWhouse.GUI.UPrintControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.brnkapat = new MobileWhouse.GUI.UButton();
            this.btnyazdir = new MobileWhouse.GUI.UButton();
            this.comboField = new System.Windows.Forms.ComboBox();
            this.textarama = new System.Windows.Forms.TextBox();
            this.t1 = new MobileWhouse.GUI.UButton();
            this.btnara = new MobileWhouse.GUI.UButton();
            this.SuspendLayout();
            // 
            // printetiketleme
            // 
            this.printetiketleme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printetiketleme.Location = new System.Drawing.Point(0, 1);
            this.printetiketleme.Name = "printetiketleme";
            this.printetiketleme.Size = new System.Drawing.Size(240, 56);
            this.printetiketleme.TabIndex = 0;
            this.printetiketleme.SelectedChanged += new System.EventHandler(this.printetiketleme_SelectedChanged);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 88);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 185);
            this.listView1.TabIndex = 1;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // brnkapat
            // 
            this.brnkapat.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.brnkapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.brnkapat.BackColor = System.Drawing.Color.Empty;
            this.brnkapat.ForeColor = System.Drawing.Color.Empty;
            this.brnkapat.Location = new System.Drawing.Point(3, 279);
            this.brnkapat.Name = "brnkapat";
            this.brnkapat.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.brnkapat.NormalTxtColour = System.Drawing.Color.Blue;
            this.brnkapat.PushedBtnColour = System.Drawing.Color.Blue;
            this.brnkapat.PushedTxtColour = System.Drawing.Color.Yellow;
            this.brnkapat.Size = new System.Drawing.Size(102, 38);
            this.brnkapat.TabIndex = 2;
            this.brnkapat.Text = "Kapat";
            this.brnkapat.Click += new System.EventHandler(this.brnkapat_Click);
            // 
            // btnyazdir
            // 
            this.btnyazdir.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnyazdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnyazdir.BackColor = System.Drawing.Color.Empty;
            this.btnyazdir.ForeColor = System.Drawing.Color.Empty;
            this.btnyazdir.Location = new System.Drawing.Point(126, 279);
            this.btnyazdir.Name = "btnyazdir";
            this.btnyazdir.NormalBtnColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnyazdir.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnyazdir.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnyazdir.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnyazdir.Size = new System.Drawing.Size(111, 38);
            this.btnyazdir.TabIndex = 2;
            this.btnyazdir.Text = "Yazdir";
            this.btnyazdir.Click += new System.EventHandler(this.btnyazdir_Click);
            // 
            // comboField
            // 
            this.comboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.comboField.Location = new System.Drawing.Point(5, 60);
            this.comboField.Name = "comboField";
            this.comboField.Size = new System.Drawing.Size(73, 22);
            this.comboField.TabIndex = 3;
            // 
            // textarama
            // 
            this.textarama.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.textarama.Location = new System.Drawing.Point(79, 60);
            this.textarama.Name = "textarama";
            this.textarama.Size = new System.Drawing.Size(94, 23);
            this.textarama.TabIndex = 4;
            // 
            // t1
            // 
            this.t1.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.t1.BackColor = System.Drawing.Color.Empty;
            this.t1.ForeColor = System.Drawing.Color.Empty;
            this.t1.Location = new System.Drawing.Point(173, 60);
            this.t1.Name = "t1";
            this.t1.NormalBtnColour = System.Drawing.Color.Silver;
            this.t1.NormalTxtColour = System.Drawing.Color.Blue;
            this.t1.PushedBtnColour = System.Drawing.Color.Blue;
            this.t1.PushedTxtColour = System.Drawing.Color.Yellow;
            this.t1.Size = new System.Drawing.Size(29, 23);
            this.t1.TabIndex = 5;
            this.t1.Text = "T";
            this.t1.Click += new System.EventHandler(this.t1_Click);
            // 
            // btnara
            // 
            this.btnara.Alignment = MobileWhouse.GUI.ImageAlignment.Left;
            this.btnara.BackColor = System.Drawing.Color.Empty;
            this.btnara.ForeColor = System.Drawing.Color.Empty;
            this.btnara.Location = new System.Drawing.Point(203, 60);
            this.btnara.Name = "btnara";
            this.btnara.NormalBtnColour = System.Drawing.Color.LightYellow;
            this.btnara.NormalTxtColour = System.Drawing.Color.Blue;
            this.btnara.PushedBtnColour = System.Drawing.Color.Blue;
            this.btnara.PushedTxtColour = System.Drawing.Color.Yellow;
            this.btnara.Size = new System.Drawing.Size(34, 23);
            this.btnara.TabIndex = 6;
            this.btnara.Text = "Ara";
            this.btnara.Click += new System.EventHandler(this.btnara_Click);
            // 
            // EtiketlemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnara);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.textarama);
            this.Controls.Add(this.comboField);
            this.Controls.Add(this.btnyazdir);
            this.Controls.Add(this.brnkapat);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.printetiketleme);
            this.Name = "EtiketlemeControl";
            this.Size = new System.Drawing.Size(240, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileWhouse.GUI.UPrintControl printetiketleme;
        private System.Windows.Forms.ListView listView1;
        private GUI.UButton brnkapat;
        private GUI.UButton btnyazdir;
        private System.Windows.Forms.ComboBox comboField;
        private System.Windows.Forms.TextBox textarama;
        private GUI.UButton t1;
        private GUI.UButton btnara;
    }
}
