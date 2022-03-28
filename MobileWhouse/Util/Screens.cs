using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MobileWhouse.Log;
using MobileWhouse.Forms;

namespace MobileWhouse.Util
{
    public sealed class Screens
    {
        public static void ShowWait()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public static void HideWait()
        {
            Cursor.Current = Cursors.Default;
        }

        public static void Error(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        public static void Error(Exception exc)
        {
            StringBuilder err = new StringBuilder();
            err.Append("Genel hata:").Append(exc.Message).Append(",Detay:").Append(exc.StackTrace);
            Error(err.ToString());
        }

        public static void Error(string err)
        {
            Cursor.Current = Cursors.Default;
            Logger.E(err);

            FormMesaj.ShowMsj(err, Properties.Resources.Err_Error, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            //MessageBox.Show(err, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        public static void Warning(string warn)
        {
            Cursor.Current = Cursors.Default;
            Logger.W(warn);

            FormMesaj.ShowMsj(warn, "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            //MessageBox.Show(warn, "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        public static void Info(string inf)
        {
            Cursor.Current = Cursors.Default;
            Logger.I(inf);

            FormMesaj.ShowMsj(inf, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //MessageBox.Show(inf, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public static bool Question(string question)
        {
            return FormMesaj.ShowMsj(question, "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            //return MessageBox.Show(question, "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
        }

        [DllImport("coredll.dll")]
        static extern bool SipShowIM(int dwFlag);

        private const int BS_MULTILINE = 0x00002000;
        private const int GWL_STYLE = -16;

        [DllImport("coredll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("coredll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// MakeButtonMultiline(button1);
        /// </summary>
        /// <param name="b"></param>
        public static void MakeButtonMultiline(Button b)
        {
            IntPtr hwnd = b.Handle;
            int currentStyle = GetWindowLong(hwnd, GWL_STYLE);
            int newStyle = SetWindowLong(hwnd, GWL_STYLE, currentStyle | BS_MULTILINE);
        }

        public static void ShowKeyboard(bool open)
        {
            try
            {
                SipShowIM(open ? 1 : 0);
            }
            catch
            {
                ;
            }

        }

        public static void ShowKeyboard(TextBox txtbox)
        {
            if (Screen.PrimaryScreen.WorkingArea.Width > 480)
            {
                FormKlavye klvform = new FormKlavye();
                klvform.textBoxMetin.Text = txtbox.Text;
                klvform.textBoxMetin.PasswordChar = txtbox.PasswordChar;
                if (klvform.ShowDialog() == DialogResult.OK)
                {
                    txtbox.Text = klvform.textBoxMetin.Text;
                }
                txtbox.Focus();
                txtbox.SelectionStart = txtbox.Text.Length;
                return;
            }
            else
            {
                FormTus tusform = new FormTus();
                tusform.textBox1.Text = txtbox.Text;
                tusform.textBox1.PasswordChar = txtbox.PasswordChar;
                if (tusform.ShowDialog() == DialogResult.OK)
                {
                    txtbox.Text = tusform.textBox1.Text;
                }
                txtbox.Focus();
                txtbox.SelectionStart = txtbox.Text.Length;
                return;
            }

        }

        //764x480
        private static int _intScreenHeight = 320;
        private static int _intScreenWidth = 240;
        public static int ScreenHeight
        {
            get
            {
                if (_intScreenHeight == -1)
                {
                    _intScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;
                }
                return _intScreenHeight;
            }
            set
            {
                _intScreenHeight = value;
            }
        }
        public static int ScreenWidth
        {
            get
            {
                if (_intScreenWidth == -1)
                {
                    _intScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                }
                return _intScreenWidth;
            }
            set
            {
                _intScreenWidth = value;
            }
        }

        private static int _LookupEditHeigh = -1;
        public static int LookupEditHeigh
        {
            get
            {
                if (_LookupEditHeigh == -1)
                {
                    if (Screen.PrimaryScreen.WorkingArea.Height == 764)
                    {
                        _LookupEditHeigh = 20;
                    }
                    else
                    {
                        _LookupEditHeigh = 0;
                    }
                }
                return _LookupEditHeigh;
            }
            set
            {
                _LookupEditHeigh = value;
            }
        }

        private static bool buyukekran = false;
        public static bool BuyukEkran
        {
            get { return buyukekran; }
            set { buyukekran = value; }
        }

        public static void Klavye(TextBox Kontrol)
        {
            if (buyukekran)
            {
                FormKlavye.KlavyeIslem(Kontrol);
            }
            else
            {
                FormTus.Klavye(Kontrol);
            }
        }

        public static decimal ShowInputBox(string caption, decimal qty)
        {
            FormInput frm = new FormInput();
            frm.Text = "Giriş";
            frm.Input = qty.ToString(Statics.DECIMAL_STRING_FORMAT);
            frm.InputMesaj = caption;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return StringUtil.ToDecimal(frm.Input);
            }
            return 0M;
        }

        public static string ShowInputBox(string caption, string msg, char pswchar)
        {
            FormInput frm = new FormInput();
            frm.Text = caption;
            frm.InputMesaj = msg;
            frm.PasswordChar = pswchar;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return frm.Input;
            }
            return string.Empty;
        }

        public static string ShowInputBox(string caption, string msg)
        {
            return ShowInputBox(caption, msg, '\0');
        }

        public static string ShowInputBox(string caption)
        {
            return ShowInputBox(caption, "Giriş yapılmalı", '\0');
        }

        public static string ShowInputBox()
        {
            return ShowInputBox("Giriş", "Giriş yapılmalı", '\0');
        }
    }
}
