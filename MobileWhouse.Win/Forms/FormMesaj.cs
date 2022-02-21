using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MobileWhouse.Log;
using MobileWhouse.Util;
using MobileWhouse.Models;

namespace MobileWhouse.Forms
{
    public partial class FormMesaj : Form
    {
        public FormMesaj()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return textdetail.Text; }
            set { textdetail.Text = value; }
        }

        public string Caption
        {
            get { return textCaption.Text; }
            set { textCaption.Text = value; }
        }

        private MessageBoxButtons boxButtons = MessageBoxButtons.OK;
        public MessageBoxButtons BoxButtons
        {
            get { return boxButtons; }
            set
            {
                boxButtons = value;
                if (value == MessageBoxButtons.OK)
                {
                    btncancel.Visible = false;
                }
                else if (value == MessageBoxButtons.OKCancel)
                {
                    btnok.Text = "TAMAM";
                    btncancel.Text = "VAZGEÇ";
                    btncancel.Visible = true;
                    btnsend.Visible = false;
                }
                else if (value == MessageBoxButtons.YesNo)
                {
                    btnok.Text = "EVET";
                    btncancel.Text = "HAYIR";
                    btncancel.Visible = true;
                    btnsend.Visible = false;
                }
            }
        }

        private MessageBoxIcon icon = MessageBoxIcon.None;
        public MessageBoxIcon Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                switch (value)
                {
                    case MessageBoxIcon.Asterisk:
                        pictureIcon.Image = Properties.Resources.err;
                        break;
                    case MessageBoxIcon.Exclamation:
                        pictureIcon.Image = Properties.Resources.info;
                        break;
                    case MessageBoxIcon.Hand:
                        pictureIcon.Image = Properties.Resources.err;
                        break;
                    case MessageBoxIcon.None:
                        pictureIcon.Image = Properties.Resources.info;
                        break;
                    case MessageBoxIcon.Question:
                        pictureIcon.Image = Properties.Resources.quest;
                        break;
                }
            }
        }

        public static DialogResult ShowMsj(string mesaj, string baslik, MessageBoxButtons button, MessageBoxIcon icon)
        {
            FormMesaj msj = new FormMesaj();
            msj.Text = baslik;
            msj.Message = mesaj;
            msj.Caption = baslik;
            msj.BoxButtons = button;
            msj.Icon = icon;
            return msj.ShowDialog();
        }

        public static DialogResult ShowMsj(string detay, string mesaj, string baslik, MessageBoxButtons button, MessageBoxIcon icon)
        {
            FormMesaj msj = new FormMesaj();
            msj.Text = baslik;
            msj.Message = detay;
            msj.Caption = mesaj;
            msj.BoxButtons = button;
            msj.Icon = icon;
            return msj.ShowDialog();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (boxButtons == MessageBoxButtons.OK || boxButtons == MessageBoxButtons.OKCancel) this.DialogResult = DialogResult.OK;
            else this.DialogResult = DialogResult.Yes;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (boxButtons == MessageBoxButtons.OK || boxButtons == MessageBoxButtons.OKCancel) this.DialogResult = DialogResult.Cancel;
            else this.DialogResult = DialogResult.No;
            Close();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            ClientApplication.Instance.SendTrace();
        }

        private void FormMesaj_Load(object sender, EventArgs e)
        {
            //AutoScaleMode = AutoScaleMode.Dpi;
            //WindowState = FormWindowState.Normal;
            //Location = new Point(0, 0);

            //if (Screens.BuyukEkran)
            //    Size = new Size(800, 480);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }

}


