using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;

namespace MobileWhouse.Forms
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        private char _passwordChar = '\0';
        public char PasswordChar
        {
            get { return _passwordChar; }
            set { _passwordChar = value; }
        }

        private bool _isnumber = false;
        public bool IsNumber
        {
            get { return _isnumber; }
            set { _isnumber = value; }
        }

        private string inputmesaj = "Giriş yapın";
        public string InputMesaj
        {
            get { return inputmesaj; }
            set { inputmesaj = value; }
        }

        private string input = "";
        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            label1.Text = inputmesaj;
            if (IsNumber)
            {
                textNum.Visible = true;
                textBox1.Visible = false;
                textNum.Text = input;
                textNum.SelectAll();
                textNum.Focus();
            }
            else
            {
                textBox1.Visible = true;
                textNum.Visible = false;
                textBox1.Text = input;
                textBox1.SelectAll();
                textBox1.PasswordChar = _passwordChar;
                textBox1.Focus();
            }
            this.Location = new Point(
            Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2,
            Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);
            Application.DoEvents();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Screens.Error("Giriş yapılmadı!");
                textBox1.Focus();
                return;
            }
            input = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnkaydet_Click(btnkaydet, EventArgs.Empty);
        }

        private void t1_Click(object sender, EventArgs e)
        {
            if (IsNumber)
            {
                Screens.Klavye(textNum);
            }
            else
            {
                Screens.Klavye(textBox1);
            }
        }

        private void textNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textNum.Text))
            {
                Screens.Error("Giriş yapılmadı!");
                textNum.Focus();
                return;
            }
            input = textNum.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

       
    }
}