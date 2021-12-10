using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Dilogs;
using MobileWhouse.UyumConnector;
using MobileWhouse.Util;

namespace MobileWhouse.Controls
{
    public partial class IrsaliyeOlusturControl : BaseControl
    {
        private NameIdItem _DocTra;
        private SevkiyatInfo _Sevkiyat;
        private int _DocNumberDId;

        public IrsaliyeOlusturControl()
        {
            InitializeComponent();

        }

        public IrsaliyeOlusturControl(SevkiyatInfo info)
        {
            InitializeComponent();
            if (!info.IsActive)
            {
                MobileWhouse.Util.Screens.Info("Bu Cariye Sevkiyat Yapılamaz!...");
                btnKaydet.Enabled = false;
            }
            else
            {
                try
                {
                    _Sevkiyat = info;
                    txtBelgeNo.Text = _Sevkiyat.SevkEmriNo;

                    ServiceRequestOfSevkiyatInfo _info = new ServiceRequestOfSevkiyatInfo();
                    _info.Token = ClientApplication.Instance.Token;
                    _info.Value = info;

                    ServiceResultOfNameIdItem ids = ClientApplication.Instance.Service.GetDefaultDocTra(_info);
                    if (!ids.Result)
                        throw new Exception(ids.Message);
                    _DocTra = ids.Value;
                    txtIrsaliyeTuru.Text = ids.Value.Name;
                    if (ids.Value.Name != "")
                    {
                        btnIrsaliyeTuru.Enabled = false;
                    }
                    adres1.Text = _Sevkiyat.Address1;
                    adres2.Text = _Sevkiyat.Address2;
                    adres3.Text = _Sevkiyat.Address3;
                    ilce.Text = _Sevkiyat.Town;
                    il.Text = _Sevkiyat.City;
                    ulke.Text = _Sevkiyat.Country;
                    txtKoliSayisi.Text = _Sevkiyat.PackageCount.ToString(Statics.DECIMAL_STRING_FORMAT);
                    _DocNumberDId = 0;
                }
                catch (Exception ex)
                {
                    MobileWhouse.Util.Screens.Error(ex);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(null);
        }

        private void btnIrsaliyeTuru_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormSelectIrsaliyeTur form = new FormSelectIrsaliyeTur())
                {
                    if (form.ShowDialog() == DialogResult.OK
                        && form.Selected != null)
                    {
                        _DocTra = form.Selected;
                        txtIrsaliyeTuru.Text = form.Selected.Name;

                        ServiceRequestOfDateTime param = new ServiceRequestOfDateTime();
                        param.Token = ClientApplication.Instance.Token;
                        param.Value = dtPicker.Value;
                        ServiceResultOfString ret = ClientApplication.Instance.Service.GetIrsaliyeBelgeNo(param);
                        if (!ret.Result)
                            throw new Exception(ret.Message);

                        string retValue = ret.Value;
                        string belgNo = txtBelgeNo.Text;
                        int docId = 0;
                        if (!string.IsNullOrEmpty(retValue))
                        {
                            string[] parts = retValue.Split('|');
                            if (parts.Length > 1)
                            {
                                belgNo = parts[0];

                                try
                                {
                                    docId = StringUtil.ToInteger(parts[1]);
                                }
                                catch
                                {
                                    docId = 0;
                                }
                            }
                            else
                            {
                                belgNo = retValue;
                                docId = 0;
                            }
                        }
                        _DocNumberDId = docId;
                        txtBelgeNo.Text = belgNo;
                    }
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_DocTra == null)
                {
                    return;
                }
                ServiceRequestOfSaveSevkIrsaliyeParam param = new ServiceRequestOfSaveSevkIrsaliyeParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new SaveSevkIrsaliyeParam();
                param.Value.BelgeNo = txtBelgeNo.Text;
                param.Value.Date = dtPicker.Value;
                param.Value.DocTraId = _DocTra.Id;
                param.Value.MasterId = _Sevkiyat.Id;
                param.Value.DocNumberDId = _DocNumberDId;
                param.Value.PackageCount = StringUtil.ToInteger(txtKoliSayisi.Text);

                ServiceResultOfBoolean ret = ClientApplication.Instance.Service.SaveSevkIrsaliye(param);
                if (!ret.Result)
                    throw new Exception(ret.Message);
                Cursor.Current = Cursors.Default;
                MobileWhouse.Util.Screens.Info("Kayit basari ile gerceklestirildi");
                MainForm.ShowControl(null);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MobileWhouse.Util.Screens.Error(ex);
            }
        }

        private void label4_ParentChanged(object sender, EventArgs e)
        {

        }

        private void btnBarkodBas_Click(object sender, EventArgs e)
        {
            ServiceRequestOfSaveSevkIrsaliyeParam param = new ServiceRequestOfSaveSevkIrsaliyeParam();
            param.Token = ClientApplication.Instance.Token;
            param.Value = new SaveSevkIrsaliyeParam();
            param.Value.BelgeNo = txtBelgeNo.Text;
            param.Value.Date = dtPicker.Value;
            param.Value.DocTraId = _DocTra.Id;
            param.Value.MasterId = _Sevkiyat.Id;
            param.Value.DocNumberDId = _DocNumberDId;


            ServiceResultOfBoolean ret = ClientApplication.Instance.Service.SaveSevkIrsaliye(param);
            if (!ret.Result)
                throw new Exception(ret.Message);

            MobileWhouse.Util.Screens.Info("Kayit basari ile gerceklestirildi");
        }
    }
}
