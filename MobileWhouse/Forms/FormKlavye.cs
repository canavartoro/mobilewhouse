using System;
using System.Drawing;
using System.Windows.Forms;
using MobileWhouse.Util;

namespace MobileWhouse.Forms
{
    /// <summary>
    ///     Summary description for Tus.
    /// </summary>
    public class FormKlavye : Form
    {
        #region Kontroller

        private static FormKlavye Klv;
        private Button button1;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button2;
        private Button button20;
        private Button button21;
        private Button button22;
        private Button button23;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button28;
        private Button button29;
        private Button button3;
        private Button button30;
        private Button button31;
        private Button button32;
        private Button button33;
        private Button button34;
        private Button button35;
        private Button btnKucuk;
        private Button button37;
        private Button btnSil;
        private Button btnBosluk;
        private Button button4;
        private Button button40;
        private Button button41;
        private Button button42;
        private Button btnIptal;
        private Button btnTamam;
        private Button button45;
        private Button button46;
        private Button button47;
        private Button button48;
        private Button button49;
        private Button button5;
        private Button button52;
        private Button button53;
        private Button button54;
        private Button button55;
        private Button button56;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button36;
        public TextBox textBoxMetin;

        #endregion

        public FormKlavye()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMetin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnBosluk = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnTamam = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.button52 = new System.Windows.Forms.Button();
            this.button53 = new System.Windows.Forms.Button();
            this.button54 = new System.Windows.Forms.Button();
            this.button55 = new System.Windows.Forms.Button();
            this.button56 = new System.Windows.Forms.Button();
            this.btnKucuk = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMetin
            // 
            this.textBoxMetin.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular);
            this.textBoxMetin.Location = new System.Drawing.Point(12, 6);
            this.textBoxMetin.Name = "textBoxMetin";
            this.textBoxMetin.Size = new System.Drawing.Size(776, 55);
            this.textBoxMetin.TabIndex = 52;
            this.textBoxMetin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(73, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 55);
            this.button1.TabIndex = 51;
            this.button1.Text = "A";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(373, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 55);
            this.button2.TabIndex = 50;
            this.button2.Text = "B";
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(613, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 55);
            this.button3.TabIndex = 48;
            this.button3.Text = "Ç";
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button4.Location = new System.Drawing.Point(253, 263);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 55);
            this.button4.TabIndex = 49;
            this.button4.Text = "C";
            this.button4.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button5.Location = new System.Drawing.Point(163, 142);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 55);
            this.button5.TabIndex = 46;
            this.button5.Text = "E";
            this.button5.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button6.Location = new System.Drawing.Point(193, 203);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 55);
            this.button6.TabIndex = 47;
            this.button6.Text = "D";
            this.button6.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button7.Location = new System.Drawing.Point(253, 202);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(54, 55);
            this.button7.TabIndex = 45;
            this.button7.Text = "F";
            this.button7.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button8.Location = new System.Drawing.Point(493, 202);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(54, 55);
            this.button8.TabIndex = 38;
            this.button8.Text = "K";
            this.button8.Click += new System.EventHandler(this.button1_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button9.Location = new System.Drawing.Point(433, 202);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(54, 55);
            this.button9.TabIndex = 39;
            this.button9.Text = "J";
            this.button9.Click += new System.EventHandler(this.button1_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button10.Location = new System.Drawing.Point(673, 203);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(54, 55);
            this.button10.TabIndex = 40;
            this.button10.Text = "İ";
            this.button10.Click += new System.EventHandler(this.button1_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button11.Location = new System.Drawing.Point(463, 142);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(54, 55);
            this.button11.TabIndex = 41;
            this.button11.Text = "I";
            this.button11.Click += new System.EventHandler(this.button1_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button12.Location = new System.Drawing.Point(373, 202);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(54, 55);
            this.button12.TabIndex = 42;
            this.button12.Text = "H";
            this.button12.Click += new System.EventHandler(this.button1_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button13.Location = new System.Drawing.Point(643, 142);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(54, 55);
            this.button13.TabIndex = 43;
            this.button13.Text = "Ğ";
            this.button13.Click += new System.EventHandler(this.button1_Click);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button14.Location = new System.Drawing.Point(313, 202);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(54, 55);
            this.button14.TabIndex = 44;
            this.button14.Text = "G";
            this.button14.Click += new System.EventHandler(this.button1_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button15.Location = new System.Drawing.Point(223, 142);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(54, 55);
            this.button15.TabIndex = 31;
            this.button15.Text = "R";
            this.button15.Click += new System.EventHandler(this.button1_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button16.Location = new System.Drawing.Point(583, 142);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(54, 55);
            this.button16.TabIndex = 32;
            this.button16.Text = "P";
            this.button16.Click += new System.EventHandler(this.button1_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button17.Location = new System.Drawing.Point(553, 263);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(54, 55);
            this.button17.TabIndex = 33;
            this.button17.Text = "Ö";
            this.button17.Click += new System.EventHandler(this.button1_Click);
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button18.Location = new System.Drawing.Point(523, 142);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(54, 55);
            this.button18.TabIndex = 34;
            this.button18.Text = "O";
            this.button18.Click += new System.EventHandler(this.button1_Click);
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button19.Location = new System.Drawing.Point(433, 263);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(54, 55);
            this.button19.TabIndex = 35;
            this.button19.Text = "N";
            this.button19.Click += new System.EventHandler(this.button1_Click);
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button20.Location = new System.Drawing.Point(493, 263);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(54, 55);
            this.button20.TabIndex = 36;
            this.button20.Text = "M";
            this.button20.Click += new System.EventHandler(this.button1_Click);
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button21.Location = new System.Drawing.Point(553, 203);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(54, 55);
            this.button21.TabIndex = 37;
            this.button21.Text = "L";
            this.button21.Click += new System.EventHandler(this.button1_Click);
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button22.Location = new System.Drawing.Point(343, 142);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(54, 55);
            this.button22.TabIndex = 24;
            this.button22.Text = "Y";
            this.button22.Click += new System.EventHandler(this.button1_Click);
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button23.Location = new System.Drawing.Point(313, 263);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(54, 55);
            this.button23.TabIndex = 25;
            this.button23.Text = "V";
            this.button23.Click += new System.EventHandler(this.button1_Click);
            // 
            // button24
            // 
            this.button24.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button24.Location = new System.Drawing.Point(703, 142);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(54, 55);
            this.button24.TabIndex = 26;
            this.button24.Text = "Ü";
            this.button24.Click += new System.EventHandler(this.button1_Click);
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button25.Location = new System.Drawing.Point(403, 142);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(54, 55);
            this.button25.TabIndex = 27;
            this.button25.Text = "U";
            this.button25.Click += new System.EventHandler(this.button1_Click);
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button26.Location = new System.Drawing.Point(283, 142);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(54, 55);
            this.button26.TabIndex = 28;
            this.button26.Text = "T";
            this.button26.Click += new System.EventHandler(this.button1_Click);
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button27.Location = new System.Drawing.Point(613, 202);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(54, 55);
            this.button27.TabIndex = 29;
            this.button27.Text = "Ş";
            this.button27.Click += new System.EventHandler(this.button1_Click);
            // 
            // button28
            // 
            this.button28.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button28.Location = new System.Drawing.Point(133, 202);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(54, 55);
            this.button28.TabIndex = 30;
            this.button28.Text = "S";
            this.button28.Click += new System.EventHandler(this.button1_Click);
            // 
            // button29
            // 
            this.button29.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button29.Location = new System.Drawing.Point(333, 385);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(52, 83);
            this.button29.TabIndex = 17;
            this.button29.Text = ".";
            this.button29.Click += new System.EventHandler(this.button1_Click);
            // 
            // button30
            // 
            this.button30.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button30.Location = new System.Drawing.Point(101, 385);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(52, 83);
            this.button30.TabIndex = 18;
            this.button30.Text = ")";
            this.button30.Click += new System.EventHandler(this.button1_Click);
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button31.Location = new System.Drawing.Point(43, 385);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(52, 83);
            this.button31.TabIndex = 19;
            this.button31.Text = "(";
            this.button31.Click += new System.EventHandler(this.button1_Click);
            // 
            // button32
            // 
            this.button32.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button32.Location = new System.Drawing.Point(159, 385);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(52, 83);
            this.button32.TabIndex = 20;
            this.button32.Text = "/";
            this.button32.Click += new System.EventHandler(this.button1_Click);
            // 
            // button33
            // 
            this.button33.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button33.Location = new System.Drawing.Point(391, 385);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(52, 83);
            this.button33.TabIndex = 21;
            this.button33.Text = "+";
            this.button33.Click += new System.EventHandler(this.button1_Click);
            // 
            // button34
            // 
            this.button34.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button34.Location = new System.Drawing.Point(449, 385);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(52, 83);
            this.button34.TabIndex = 22;
            this.button34.Text = "-";
            this.button34.Click += new System.EventHandler(this.button1_Click);
            // 
            // button35
            // 
            this.button35.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button35.Location = new System.Drawing.Point(133, 263);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(54, 55);
            this.button35.TabIndex = 23;
            this.button35.Text = "Z";
            this.button35.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btnSil.Location = new System.Drawing.Point(643, 81);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(114, 55);
            this.btnSil.TabIndex = 12;
            this.btnSil.Text = "SİL";
            this.btnSil.Click += new System.EventHandler(this.button38_Click);
            // 
            // btnBosluk
            // 
            this.btnBosluk.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btnBosluk.Location = new System.Drawing.Point(223, 324);
            this.btnBosluk.Name = "btnBosluk";
            this.btnBosluk.Size = new System.Drawing.Size(413, 55);
            this.btnBosluk.TabIndex = 13;
            this.btnBosluk.Text = "BOŞLUK";
            this.btnBosluk.Click += new System.EventHandler(this.button39_Click);
            // 
            // button40
            // 
            this.button40.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button40.Location = new System.Drawing.Point(43, 142);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(54, 55);
            this.button40.TabIndex = 14;
            this.button40.Text = "Q";
            this.button40.Click += new System.EventHandler(this.button1_Click);
            // 
            // button41
            // 
            this.button41.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button41.Location = new System.Drawing.Point(103, 142);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(54, 55);
            this.button41.TabIndex = 15;
            this.button41.Text = "W";
            this.button41.Click += new System.EventHandler(this.button1_Click);
            // 
            // button42
            // 
            this.button42.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button42.Location = new System.Drawing.Point(193, 263);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(54, 55);
            this.button42.TabIndex = 16;
            this.button42.Text = "X";
            this.button42.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btnIptal.Location = new System.Drawing.Point(507, 385);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(109, 83);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Tag = "Çıkış";
            this.btnIptal.Text = "IPTAL";
            this.btnIptal.Click += new System.EventHandler(this.button43_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btnTamam.Location = new System.Drawing.Point(622, 385);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(135, 83);
            this.btnTamam.TabIndex = 6;
            this.btnTamam.Text = "TAMAM";
            this.btnTamam.Click += new System.EventHandler(this.button44_Click);
            // 
            // button45
            // 
            this.button45.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button45.Location = new System.Drawing.Point(283, 81);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(54, 55);
            this.button45.TabIndex = 7;
            this.button45.Text = "5";
            this.button45.Click += new System.EventHandler(this.button1_Click);
            // 
            // button46
            // 
            this.button46.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button46.Location = new System.Drawing.Point(223, 81);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(54, 55);
            this.button46.TabIndex = 8;
            this.button46.Text = "4";
            this.button46.Click += new System.EventHandler(this.button1_Click);
            // 
            // button47
            // 
            this.button47.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button47.Location = new System.Drawing.Point(163, 81);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(54, 55);
            this.button47.TabIndex = 9;
            this.button47.Text = "3";
            this.button47.Click += new System.EventHandler(this.button1_Click);
            // 
            // button48
            // 
            this.button48.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button48.Location = new System.Drawing.Point(103, 81);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(54, 55);
            this.button48.TabIndex = 10;
            this.button48.Text = "2";
            this.button48.Click += new System.EventHandler(this.button1_Click);
            // 
            // button49
            // 
            this.button49.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button49.Location = new System.Drawing.Point(43, 81);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(54, 55);
            this.button49.TabIndex = 11;
            this.button49.Text = "1";
            this.button49.Click += new System.EventHandler(this.button1_Click);
            // 
            // button52
            // 
            this.button52.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button52.Location = new System.Drawing.Point(583, 81);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(54, 55);
            this.button52.TabIndex = 0;
            this.button52.Text = "0";
            this.button52.Click += new System.EventHandler(this.button1_Click);
            // 
            // button53
            // 
            this.button53.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button53.Location = new System.Drawing.Point(523, 81);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(54, 55);
            this.button53.TabIndex = 1;
            this.button53.Text = "9";
            this.button53.Click += new System.EventHandler(this.button1_Click);
            // 
            // button54
            // 
            this.button54.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button54.Location = new System.Drawing.Point(463, 81);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(54, 55);
            this.button54.TabIndex = 2;
            this.button54.Text = "8";
            this.button54.Click += new System.EventHandler(this.button1_Click);
            // 
            // button55
            // 
            this.button55.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button55.Location = new System.Drawing.Point(403, 81);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(54, 55);
            this.button55.TabIndex = 3;
            this.button55.Text = "7";
            this.button55.Click += new System.EventHandler(this.button1_Click);
            // 
            // button56
            // 
            this.button56.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button56.Location = new System.Drawing.Point(343, 81);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(54, 55);
            this.button56.TabIndex = 4;
            this.button56.Text = "6";
            this.button56.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKucuk
            // 
            this.btnKucuk.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.btnKucuk.Location = new System.Drawing.Point(43, 324);
            this.btnKucuk.Name = "btnKucuk";
            this.btnKucuk.Size = new System.Drawing.Size(155, 55);
            this.btnKucuk.TabIndex = 53;
            this.btnKucuk.Text = "KÜÇÜK";
            this.btnKucuk.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button37.Location = new System.Drawing.Point(275, 385);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(52, 83);
            this.button37.TabIndex = 54;
            this.button37.Text = ":";
            this.button37.Click += new System.EventHandler(this.button1_Click);
            // 
            // button36
            // 
            this.button36.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.button36.Location = new System.Drawing.Point(217, 385);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(52, 83);
            this.button36.TabIndex = 55;
            this.button36.Text = "\\";
            this.button36.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormKlavye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.btnKucuk);
            this.Controls.Add(this.button52);
            this.Controls.Add(this.button53);
            this.Controls.Add(this.button54);
            this.Controls.Add(this.button55);
            this.Controls.Add(this.button56);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.button45);
            this.Controls.Add(this.button46);
            this.Controls.Add(this.button47);
            this.Controls.Add(this.button48);
            this.Controls.Add(this.button49);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnBosluk);
            this.Controls.Add(this.button40);
            this.Controls.Add(this.button41);
            this.Controls.Add(this.button42);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxMetin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKlavye";
            this.Text = "Türkçe Klavye";
            this.Load += new System.EventHandler(this.Tus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        #region İşlemler

        private int Sira;

        private void Tus_Load(object sender, EventArgs e)
        {
            textBoxMetin.Focus();
            textBoxMetin.SelectionStart = textBoxMetin.Text.Length;
            Location = new Point(1, 1);

            FontAyar();
        }

        private void FontAyar()
        {
            textBoxMetin.Font = new Font("Tohama", 30F, FontStyle.Regular);

            foreach (Control Kontrol in Controls)
            {
                if (Kontrol is Button)
                {
                    Kontrol.Font = new Font("Tohama", 20F, FontStyle.Regular);
                }
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bb = (Button) sender;
            string sx = bb.Text;

            if (btnKucuk.Text.Trim().ToUpper() == "KÜÇÜK")
                sx = sx.ToUpper();
            else
                sx = sx.ToLower();

            Sira = textBoxMetin.SelectionStart;

            textBoxMetin.Text = textBoxMetin.Text.Insert(Sira, sx);
            textBoxMetin.SelectionStart = Sira + 1;
            textBoxMetin.Focus();
            return;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Sira = 0;
            Sira = textBoxMetin.SelectionStart;
            textBoxMetin.Text = textBoxMetin.Text.Insert(Sira, " ");
            textBoxMetin.SelectionStart = Sira + 1;
            textBoxMetin.Focus();
            return;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Sira = 0;
            if (textBoxMetin.Text.Length > 1)
            {
                Sira = textBoxMetin.SelectionStart - 1;
                textBoxMetin.Text = textBoxMetin.Text.Remove(Sira, 1);
                textBoxMetin.SelectionStart = Sira;
                textBoxMetin.Focus();
                //textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
                textBoxMetin.Text = "";

            textBoxMetin.SelectionStart = Sira;
            textBoxMetin.Focus();
            //textBox1.SelectionStart = textBox1.Text.Length;
            return;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            button44_Click(null, null);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control b in Controls)
                {
                    if (b.GetType().ToString().Equals("System.Windows.Forms.Button"))
                    {
                        if (Convert.ToChar(b.Text[0]) > 'Z')
                        {
                            (b).Text = (b).Text.ToUpper();
                        }
                        else
                        {
                            (b).Text = (b).Text.ToLower();
                        }
                    }
                }

                if (btnKucuk.Text.Trim().ToUpper() == "KÜÇÜK")
                    btnKucuk.Text = "BÜYÜK";
                else
                    btnKucuk.Text = "KÜÇÜK";
            }
            catch (Exception exc)
            {
                Screens.Error("Genel Hata:" + exc.Message);
            }
        }

        public static void KlavyeIslem(TextBox text)
        {
            Klv = new FormKlavye();
            Klv.textBoxMetin.Text = text.Text;
            Klv.textBoxMetin.PasswordChar = text.PasswordChar;
            if (Klv.ShowDialog() == DialogResult.OK)
            {
                text.Text = Klv.textBoxMetin.Text;
            }
            text.Focus();
            text.SelectionStart = text.Text.Length;
            return;
        }

        #endregion
    }
}