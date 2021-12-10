namespace MobileWhouse.Controls
{
    using MobileWhouse;
    using MobileWhouse.Dilogs;
    using UyumConnector;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class IrsaliyeOlusturControl : BaseControl
    {
        private int _DocNumberDId;
        private NameIdItem _DocTra;
        private SevkiyatInfo _Sevkiyat;
        private Label adres1;
        private Label adres2;
        private Label adres3;
        private Button btnBarkodBas;
        private Button btnCancel;
        private Button btnIrsaliyeTuru;
        private Button btnKaydet;
        private IContainer components;
        private DateTimePicker dtPicker;
        private Label il;
        private Label ilce;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private TextBox txtBelgeNo;
        private TextBox txtIrsaliyeTuru;
        private TextBox txtKoliSayisi;
        private Label ulke;

        public IrsaliyeOlusturControl()
        {
            this.components = null;
            this.InitializeComponent();
        }

        public IrsaliyeOlusturControl(SevkiyatInfo info)
        {
            this.components = null;
            this.InitializeComponent();
            if (!info.IsActive)
            {
                MessageBox.Show("Bu Cariye Sevkiyat Yapılamaz!...");
                this.btnKaydet.Enabled = false;
            }
            else
            {
                try
                {
                    this._Sevkiyat = info;
                    this.txtBelgeNo.Text = this._Sevkiyat.SevkEmriNo;
                    ServiceRequestOfSevkiyatInfo param = new ServiceRequestOfSevkiyatInfo {
                        Token = ClientApplication.Instance.Token,
                        Value = info
                    };
                    ServiceResultOfNameIdItem defaultDocTra = ClientApplication.Instance.Service.GetDefaultDocTra(param);
                    if (!defaultDocTra.Result)
                    {
                        throw new Exception(defaultDocTra.Message);
                    }
                    this._DocTra = defaultDocTra.Value;
                    this.txtIrsaliyeTuru.Text = defaultDocTra.Value.Name;
                    if (defaultDocTra.Value.Name != "")
                    {
                        this.btnIrsaliyeTuru.Enabled = false;
                    }
                    this.adres1.Text = this._Sevkiyat.Address1;
                    this.adres2.Text = this._Sevkiyat.Address2;
                    this.adres3.Text = this._Sevkiyat.Address3;
                    this.ilce.Text = this._Sevkiyat.Town;
                    this.il.Text = this._Sevkiyat.City;
                    this.ulke.Text = this._Sevkiyat.Country;
                    this.txtKoliSayisi.Text = this._Sevkiyat.PackageCount.ToString();
                    this._DocNumberDId = 0;
                }
                catch (Exception exception)
                {
                    ClientApplication.ShowError(exception);
                }
            }
        }

        private void btnBarkodBas_Click(object sender, EventArgs e)
        {
            ServiceRequestOfSaveSevkIrsaliyeParam param = new ServiceRequestOfSaveSevkIrsaliyeParam {
                Token = ClientApplication.Instance.Token,
                Value = new SaveSevkIrsaliyeParam()
            };
            param.Value.BelgeNo = this.txtBelgeNo.Text;
            param.Value.Date = this.dtPicker.Value;
            param.Value.DocTraId = this._DocTra.Id;
            param.Value.MasterId = this._Sevkiyat.Id;
            param.Value.DocNumberDId = this._DocNumberDId;
            ServiceResultOfBoolean flag = ClientApplication.Instance.Service.SaveSevkIrsaliye(param);
            if (!flag.Result)
            {
                throw new Exception(flag.Message);
            }
            MessageBox.Show("Kayit basari ile gerceklestirildi");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowControl(null);
        }

        private void btnIrsaliyeTuru_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormSelectIrsaliyeTur tur = new FormSelectIrsaliyeTur())
                {
                    if ((tur.ShowDialog() == DialogResult.OK) && (tur.Selected != null))
                    {
                        this._DocTra = tur.Selected;
                        this.txtIrsaliyeTuru.Text = tur.Selected.Name;
                        ServiceRequestOfDateTime param = new ServiceRequestOfDateTime {
                            Token = ClientApplication.Instance.Token,
                            Value = this.dtPicker.Value
                        };
                        ServiceResultOfString str = ClientApplication.Instance.Service.GetIrsaliyeBelgeNo(param);
                        if (!str.Result)
                        {
                            throw new Exception(str.Message);
                        }
                        string str2 = str.Value;
                        string text = this.txtBelgeNo.Text;
                        int num = 0;
                        if (!string.IsNullOrEmpty(str2))
                        {
                            string[] strArray = str2.Split(new char[] { '|' });
                            if (strArray.Length > 1)
                            {
                                text = strArray[0];
                                try
                                {
                                    num = Convert.ToInt32(strArray[1]);
                                }
                                catch
                                {
                                    num = 0;
                                }
                            }
                            else
                            {
                                text = str2;
                                num = 0;
                            }
                        }
                        this._DocNumberDId = num;
                        this.txtBelgeNo.Text = text;
                    }
                }
            }
            catch (Exception exception)
            {
                ClientApplication.ShowError(exception);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this._DocTra != null)
                {
                    ServiceRequestOfSaveSevkIrsaliyeParam param = new ServiceRequestOfSaveSevkIrsaliyeParam {
                        Token = ClientApplication.Instance.Token,
                        Value = new SaveSevkIrsaliyeParam()
                    };
                    param.Value.BelgeNo = this.txtBelgeNo.Text;
                    param.Value.Date = this.dtPicker.Value;
                    param.Value.DocTraId = this._DocTra.Id;
                    param.Value.MasterId = this._Sevkiyat.Id;
                    param.Value.DocNumberDId = this._DocNumberDId;
                    param.Value.PackageCount = Convert.ToInt32(this.txtKoliSayisi.Text);
                    ServiceResultOfBoolean flag = ClientApplication.Instance.Service.SaveSevkIrsaliye(param);
                    if (!flag.Result)
                    {
                        throw new Exception(flag.Message);
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Kayit basari ile gerceklestirildi");
                    base.MainForm.ShowControl(null);
                }
            }
            catch (Exception exception)
            {
                Cursor.Current = Cursors.Default;
                ClientApplication.ShowError(exception);
            }
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
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.txtBelgeNo = new TextBox();
            this.txtIrsaliyeTuru = new TextBox();
            this.dtPicker = new DateTimePicker();
            this.btnIrsaliyeTuru = new Button();
            this.btnCancel = new Button();
            this.btnKaydet = new Button();
            this.txtKoliSayisi = new TextBox();
            this.label4 = new Label();
            this.textBox2 = new TextBox();
            this.label5 = new Label();
            this.btnBarkodBas = new Button();
            this.adres1 = new Label();
            this.adres2 = new Label();
            this.ilce = new Label();
            this.il = new Label();
            this.ulke = new Label();
            this.adres3 = new Label();
            base.SuspendLayout();
            this.label1.Location = new Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(80, 15);
            this.label1.Text = "Belge Tarih";
            this.label2.Location = new Point(4, 40);
            this.label2.Name = "label2";
            this.label2.Size = new Size(80, 15);
            this.label2.Text = "İrsaliye T\x00fcr\x00fc";
            this.label3.Location = new Point(4, 0x43);
            this.label3.Name = "label3";
            this.label3.Size = new Size(80, 15);
            this.label3.Text = "Belge No";
            this.txtBelgeNo.Location = new Point(0x66, 0x40);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new Size(100, 0x15);
            this.txtBelgeNo.TabIndex = 5;
            this.txtIrsaliyeTuru.Location = new Point(0x66, 0x25);
            this.txtIrsaliyeTuru.Name = "txtIrsaliyeTuru";
            this.txtIrsaliyeTuru.Size = new Size(100, 0x15);
            this.txtIrsaliyeTuru.TabIndex = 9;
            this.dtPicker.Format = DateTimePickerFormat.Short;
            this.dtPicker.Location = new Point(0x66, 9);
            this.dtPicker.Name = "dtPicker";
            this.dtPicker.Size = new Size(0x76, 0x16);
            this.dtPicker.TabIndex = 10;
            this.btnIrsaliyeTuru.Location = new Point(0xcd, 0x25);
            this.btnIrsaliyeTuru.Name = "btnIrsaliyeTuru";
            this.btnIrsaliyeTuru.Size = new Size(0x1d, 0x15);
            this.btnIrsaliyeTuru.TabIndex = 11;
            this.btnIrsaliyeTuru.Text = "...";
            this.btnIrsaliyeTuru.Click += new EventHandler(this.btnIrsaliyeTuru_Click);
            this.btnCancel.Location = new Point(0xa8, 0xf2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x42, 20);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnKaydet.Location = new Point(0x66, 0xf2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(60, 20);
            this.btnKaydet.TabIndex = 13;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new EventHandler(this.btnKaydet_Click);
            this.txtKoliSayisi.Location = new Point(0x66, 0x5b);
            this.txtKoliSayisi.Name = "txtKoliSayisi";
            this.txtKoliSayisi.Size = new Size(0x36, 0x15);
            this.txtKoliSayisi.TabIndex = 0x12;
            this.label4.Location = new Point(4, 0x5e);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x58, 0x15);
            this.label4.Text = "Koli Sayısı";
            this.label4.ParentChanged += new EventHandler(this.label4_ParentChanged);
            this.textBox2.Location = new Point(0x66, 0x76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0x36, 0x15);
            this.textBox2.TabIndex = 0x15;
            this.label5.Location = new Point(3, 0x7d);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x58, 0x15);
            this.label5.Text = "Koli Baş. Sayısı";
            this.btnBarkodBas.Location = new Point(3, 0xf2);
            this.btnBarkodBas.Name = "btnBarkodBas";
            this.btnBarkodBas.Size = new Size(80, 20);
            this.btnBarkodBas.TabIndex = 0x1a;
            this.btnBarkodBas.Text = "Barkod Bas";
            this.btnBarkodBas.Click += new EventHandler(this.btnBarkodBas_Click);
            this.adres1.Location = new Point(4, 0x93);
            this.adres1.Name = "adres1";
            this.adres1.Size = new Size(230, 0x13);
            this.adres2.Location = new Point(4, 0xad);
            this.adres2.Name = "adres2";
            this.adres2.Size = new Size(230, 20);
            this.ilce.Location = new Point(6, 0xd6);
            this.ilce.Name = "ilce";
            this.ilce.Size = new Size(0x58, 20);
            this.il.Location = new Point(0x6b, 0xd6);
            this.il.Name = "il";
            this.il.Size = new Size(60, 20);
            this.ulke.Location = new Point(0xb0, 0xd6);
            this.ulke.Name = "ulke";
            this.ulke.Size = new Size(60, 20);
            this.adres3.Location = new Point(3, 0xc2);
            this.adres3.Name = "adres3";
            this.adres3.Size = new Size(230, 20);
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.adres3);
            base.Controls.Add(this.ulke);
            base.Controls.Add(this.il);
            base.Controls.Add(this.ilce);
            base.Controls.Add(this.adres2);
            base.Controls.Add(this.adres1);
            base.Controls.Add(this.btnBarkodBas);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.txtKoliSayisi);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.btnKaydet);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnIrsaliyeTuru);
            base.Controls.Add(this.dtPicker);
            base.Controls.Add(this.txtIrsaliyeTuru);
            base.Controls.Add(this.txtBelgeNo);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "IrsaliyeOlusturControl";
            base.ResumeLayout(false);
        }

        private void label4_ParentChanged(object sender, EventArgs e)
        {
        }
    }
}

