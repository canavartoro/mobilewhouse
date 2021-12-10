namespace MobileWhouse
{
    using MobileWhouse.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormAyarlar : Form
    {
        private Button btnCancel;
        private Button btnKaydet;
        private IContainer components = null;
        private Label label1;
        private TextBox txtURL;

        public FormAyarlar()
        {
            this.InitializeComponent();
            this.txtURL.Text = Settings.Default.WebServiceUrl;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Settings.Default.WebServiceUrl = this.txtURL.Text;
            Settings.Default.Save();
            base.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtURL = new TextBox();
            this.label1 = new Label();
            this.btnKaydet = new Button();
            this.btnCancel = new Button();
            base.SuspendLayout();
            this.txtURL.Location = new Point(3, 0x1d);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new Size(0xe9, 0x15);
            this.txtURL.TabIndex = 8;
            this.label1.Location = new Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new Size(100, 20);
            this.label1.Text = "Service URL";
            this.btnKaydet.Location = new Point(0x51, 0x67);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(0x48, 20);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new EventHandler(this.btnKaydet_Click);
            this.btnCancel.Location = new Point(3, 0x67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x48, 20);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Iptal";
            this.btnCancel.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            base.ClientSize = new Size(240, 320);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.txtURL);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.btnKaydet);
            base.Location = new Point(0, 0);
            base.Name = "FormAyarlar";
            this.Text = "Ayarlar";
            base.WindowState = FormWindowState.Maximized;
            base.ResumeLayout(false);
        }
    }
}

