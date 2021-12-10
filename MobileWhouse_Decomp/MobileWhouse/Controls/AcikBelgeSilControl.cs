namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using UyumConnector;

    public class AcikBelgeSilControl : BaseControl
    {
        private Button btnAcikDepo;
        private Button btnKapat;
        private IContainer components = null;

        public AcikBelgeSilControl()
        {
            this.InitializeComponent();
        }

        private void btnAcikDepo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("A\x00e7ık Depoi\x00e7i Raf Hareketleri silinsin mi ?", "Kayıt sil", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                MessageBox.Show("İşlem iptal edildi...");
            }
            else
            {
                try
                {
                    ServiceRequestOfInt32 param = new ServiceRequestOfInt32 {
                        Token = ClientApplication.Instance.Token,
                        Value = ClientApplication.Instance.ClientToken.UserId
                    };
                    ServiceResultOfBoolean flag = ClientApplication.Instance.Service.AcikDepoRafSil(param);
                    if (!flag.Result)
                    {
                        throw new Exception(flag.Message);
                    }
                    MessageBox.Show("İşlem başarıyla tamamlandı...");
                }
                catch (Exception exception)
                {
                    ClientApplication.ShowError(exception);
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(null);
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
            this.btnAcikDepo = new Button();
            this.btnKapat = new Button();
            base.SuspendLayout();
            this.btnAcikDepo.Location = new Point(0x17, 0x1c);
            this.btnAcikDepo.Name = "btnAcikDepo";
            this.btnAcikDepo.Size = new Size(200, 0x19);
            this.btnAcikDepo.TabIndex = 0;
            this.btnAcikDepo.Text = "A\x00e7ık Depoi\x00e7i Raf Hareketi Sil";
            this.btnAcikDepo.Click += new EventHandler(this.btnAcikDepo_Click);
            this.btnKapat.Location = new Point(0x17, 0xd1);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(200, 0x25);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new EventHandler(this.btnKapat_Click);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.btnKapat);
            base.Controls.Add(this.btnAcikDepo);
            base.Name = "AcikBelgeSilControl";
            base.ResumeLayout(false);
        }
    }
}

