using m2Mobile_c_v4.WebReference;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System;
using System.Drawing;
namespace m2Mobile_c_v4
{
    partial class Frm_Isemri_Raf_Cikis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;
        private int _SourceDepo;
        private Button btn_vazgec;
        private Button button1;
        private CheckBox checkBox1;
        private DataGrid dataGrid1;
        private DS_Is_Emri dS_Is_Emri;
        private BindingSource dtOnaylıIsEmriBindingSource;
        private Label Lbl_StockMovements;
        private Panel panel1;
        public DataRow row;
        private TextBox txt_arama;

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
            this.components = new Container();
            this.mainMenu1 = new MainMenu();
            this.dtOnaylıIsEmriBindingSource = new BindingSource(this.components);
            this.dS_Is_Emri = new DS_Is_Emri();
            this.dataGrid1 = new DataGrid();
            this.btn_vazgec = new Button();
            this.panel1 = new Panel();
            this.checkBox1 = new CheckBox();
            this.txt_arama = new TextBox();
            this.button1 = new Button();
            this.Lbl_StockMovements = new Label();
            ((ISupportInitialize)this.dtOnaylıIsEmriBindingSource).BeginInit();
            this.dS_Is_Emri.BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dtOnaylıIsEmriBindingSource.DataMember = "Dt_Onaylı_Is_Emri";
            this.dtOnaylıIsEmriBindingSource.DataSource = this.dS_Is_Emri;
            this.dS_Is_Emri.DataSetName = "DS_Is_Emri";
            this.dS_Is_Emri.Prefix = "";
            this.dS_Is_Emri.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.dataGrid1.BackgroundColor = Color.FromArgb(128, 128, 128);
            this.dataGrid1.DataSource = this.dtOnaylıIsEmriBindingSource;
            this.dataGrid1.Location = new Point(0, 55);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new Size(240, 217);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.DoubleClick += new EventHandler(this.dataGrid1_DoubleClick);
            this.btn_vazgec.Font = new Font("Tahoma", 7f, FontStyle.Bold);
            this.btn_vazgec.Location = new Point(25, 278);
            this.btn_vazgec.Name = "btn_vazgec";
            this.btn_vazgec.Size = new Size(193, 32);
            this.btn_vazgec.TabIndex = 1;
            this.btn_vazgec.Text = "Vazge\x00e7";
            this.btn_vazgec.Click += new EventHandler(this.btn_vazgec_Click);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txt_arama);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Lbl_StockMovements);
            this.panel1.Controls.Add(this.btn_vazgec);
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(240, 317);
            this.checkBox1.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.checkBox1.Location = new Point(156, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(80, 16);
            this.checkBox1.TabIndex = 50;
            this.checkBox1.Text = "Geniş Sutun ";
            this.checkBox1.CheckStateChanged += new EventHandler(this.checkBox1_CheckStateChanged);
            this.txt_arama.Location = new Point(19, 17);
            this.txt_arama.Name = "txt_arama";
            this.txt_arama.Size = new Size(126, 21);
            this.txt_arama.TabIndex = 3;
            this.button1.Location = new Point(160, 18);
            this.button1.Name = "button1";
            this.button1.Size = new Size(72, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "ARA";
            this.button1.Click += new EventHandler(this.button1_Click);
            this.Lbl_StockMovements.Font = new Font("Tahoma", 7f, FontStyle.Regular);
            this.Lbl_StockMovements.Location = new Point(0, 5);
            this.Lbl_StockMovements.Name = "Lbl_StockMovements";
            this.Lbl_StockMovements.Size = new Size(232, 12);
            this.Lbl_StockMovements.Text = "İşemrine Bağlı Malz. Raflı \x00c7ıkış";
            this.Lbl_StockMovements.TextAlign = ContentAlignment.TopCenter;
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 320);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Name = "Frm_Isemri_Raf_Cikis";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.Frm_Isemri_Raf_Cikis_Load);
            ((ISupportInitialize)this.dtOnaylıIsEmriBindingSource).EndInit();
            this.dS_Is_Emri.EndInit();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);


        }

        #endregion

       
        
    }
}