using System;
using System.Drawing;
using System.Windows.Forms;
using MobileWhouse.Util;

namespace MobileWhouse.Forms
{
    /// <summary>
    ///     Summary description for Tus.
    /// </summary>
    public class FormTus : Form
    {
        private static FormTus t;
        private int Sira;
        private Button btnTemizle;
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
        private Button button36;
        private Button button37;
        private Button button38;
        private Button button39;
        private Button button4;
        private Button button40;
        private Button button41;
        private Button button42;
        private Button button43;
        private Button button44;
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
        public TextBox textBox1;

        public FormTus()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void Tus_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            Location = new Point(1, 1);
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

            if (button36.Text.Trim().ToUpper() == "KÜÇÜK")
                sx = sx.ToUpper();
            else
                sx = sx.ToLower();

            //textBox1.Text += sx;

            Sira = textBox1.SelectionStart;

            textBox1.Text = textBox1.Text.Insert(Sira, sx);
            textBox1.SelectionStart = Sira + 1;
            textBox1.Focus();
            return;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Sira = 0;
            Sira = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(Sira, " ");
            textBox1.SelectionStart = Sira + 1;
            textBox1.Focus();
            return;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Sira = 0;
            if (textBox1.Text.Length > 1)
            {
                Sira = textBox1.SelectionStart - 1;
                textBox1.Text = textBox1.Text.Remove(Sira, 1);
                textBox1.SelectionStart = Sira;
                textBox1.Focus();
                //textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
                textBox1.Text = "";

            textBox1.SelectionStart = Sira;
            textBox1.Focus();
            //textBox1.SelectionStart = textBox1.Text.Length;
            return;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
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

                if (button36.Text.Trim().ToUpper() == "KÜÇÜK")
                    button36.Text = "BÜYÜK";
                else
                    button36.Text = "KÜÇÜK";
            }
            catch (Exception exc)
            {
                Screens.Error("Genel Hata:" + exc.Message);
            }
        }

        public static void Klavye(TextBox text)
        {
            t = new FormTus();
            t.textBox1.Text = text.Text;
            t.textBox1.PasswordChar = text.PasswordChar;
            if (t.ShowDialog() == DialogResult.OK)
            {
                text.Text = t.textBox1.Text;
            }
            text.Focus();
            text.SelectionStart = text.Text.Length;
            return;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
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
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 21);
            this.textBox1.TabIndex = 52;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 51;
            this.button1.Text = "A";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 24);
            this.button2.TabIndex = 50;
            this.button2.Text = "B";
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(108, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 48;
            this.button3.Text = "Ç";
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(76, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 24);
            this.button4.TabIndex = 49;
            this.button4.Text = "C";
            this.button4.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(172, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 24);
            this.button5.TabIndex = 46;
            this.button5.Text = "E";
            this.button5.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(140, 41);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 24);
            this.button6.TabIndex = 47;
            this.button6.Text = "D";
            this.button6.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(204, 41);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(24, 24);
            this.button7.TabIndex = 45;
            this.button7.Text = "F";
            this.button7.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(204, 72);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(24, 24);
            this.button8.TabIndex = 38;
            this.button8.Text = "K";
            this.button8.Click += new System.EventHandler(this.button1_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(172, 72);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(24, 24);
            this.button9.TabIndex = 39;
            this.button9.Text = "J";
            this.button9.Click += new System.EventHandler(this.button1_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(140, 72);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(24, 24);
            this.button10.TabIndex = 40;
            this.button10.Text = "İ";
            this.button10.Click += new System.EventHandler(this.button1_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(108, 72);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(24, 24);
            this.button11.TabIndex = 41;
            this.button11.Text = "I";
            this.button11.Click += new System.EventHandler(this.button1_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(76, 72);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(24, 24);
            this.button12.TabIndex = 42;
            this.button12.Text = "H";
            this.button12.Click += new System.EventHandler(this.button1_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(44, 72);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(24, 24);
            this.button13.TabIndex = 43;
            this.button13.Text = "Ğ";
            this.button13.Click += new System.EventHandler(this.button1_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(12, 72);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(24, 24);
            this.button14.TabIndex = 44;
            this.button14.Text = "G";
            this.button14.Click += new System.EventHandler(this.button1_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(204, 103);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(24, 24);
            this.button15.TabIndex = 31;
            this.button15.Text = "R";
            this.button15.Click += new System.EventHandler(this.button1_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(172, 103);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(24, 24);
            this.button16.TabIndex = 32;
            this.button16.Text = "P";
            this.button16.Click += new System.EventHandler(this.button1_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(140, 103);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(24, 24);
            this.button17.TabIndex = 33;
            this.button17.Text = "Ö";
            this.button17.Click += new System.EventHandler(this.button1_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(108, 103);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(24, 24);
            this.button18.TabIndex = 34;
            this.button18.Text = "O";
            this.button18.Click += new System.EventHandler(this.button1_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(76, 103);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(24, 24);
            this.button19.TabIndex = 35;
            this.button19.Text = "N";
            this.button19.Click += new System.EventHandler(this.button1_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(44, 103);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(24, 24);
            this.button20.TabIndex = 36;
            this.button20.Text = "M";
            this.button20.Click += new System.EventHandler(this.button1_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(12, 103);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(24, 24);
            this.button21.TabIndex = 37;
            this.button21.Text = "L";
            this.button21.Click += new System.EventHandler(this.button1_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(204, 134);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(24, 24);
            this.button22.TabIndex = 24;
            this.button22.Text = "Y";
            this.button22.Click += new System.EventHandler(this.button1_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(172, 134);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(24, 24);
            this.button23.TabIndex = 25;
            this.button23.Text = "V";
            this.button23.Click += new System.EventHandler(this.button1_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(140, 134);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(24, 24);
            this.button24.TabIndex = 26;
            this.button24.Text = "Ü";
            this.button24.Click += new System.EventHandler(this.button1_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(108, 134);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(24, 24);
            this.button25.TabIndex = 27;
            this.button25.Text = "U";
            this.button25.Click += new System.EventHandler(this.button1_Click);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(76, 134);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(24, 24);
            this.button26.TabIndex = 28;
            this.button26.Text = "T";
            this.button26.Click += new System.EventHandler(this.button1_Click);
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(44, 134);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(24, 24);
            this.button27.TabIndex = 29;
            this.button27.Text = "Ş";
            this.button27.Click += new System.EventHandler(this.button1_Click);
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(12, 134);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(24, 24);
            this.button28.TabIndex = 30;
            this.button28.Text = "S";
            this.button28.Click += new System.EventHandler(this.button1_Click);
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(204, 163);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(24, 24);
            this.button29.TabIndex = 17;
            this.button29.Text = ".";
            this.button29.Click += new System.EventHandler(this.button1_Click);
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(172, 163);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(24, 24);
            this.button30.TabIndex = 18;
            this.button30.Text = ")";
            this.button30.Click += new System.EventHandler(this.button1_Click);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(140, 163);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(24, 24);
            this.button31.TabIndex = 19;
            this.button31.Text = "(";
            this.button31.Click += new System.EventHandler(this.button1_Click);
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(108, 163);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(24, 24);
            this.button32.TabIndex = 20;
            this.button32.Text = "/";
            this.button32.Click += new System.EventHandler(this.button1_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(76, 163);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(24, 24);
            this.button33.TabIndex = 21;
            this.button33.Text = "+";
            this.button33.Click += new System.EventHandler(this.button1_Click);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(44, 163);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(24, 24);
            this.button34.TabIndex = 22;
            this.button34.Text = "-";
            this.button34.Click += new System.EventHandler(this.button1_Click);
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(12, 163);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(24, 24);
            this.button35.TabIndex = 23;
            this.button35.Text = "Z";
            this.button35.Click += new System.EventHandler(this.button1_Click);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(200, 193);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(32, 24);
            this.button38.TabIndex = 12;
            this.button38.Text = "SİL";
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(170, 221);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(62, 24);
            this.button39.TabIndex = 13;
            this.button39.Text = "BOŞLUK";
            this.button39.Click += new System.EventHandler(this.button39_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(76, 192);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(24, 24);
            this.button40.TabIndex = 14;
            this.button40.Text = "Q";
            this.button40.Click += new System.EventHandler(this.button1_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(44, 192);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(24, 24);
            this.button41.TabIndex = 15;
            this.button41.Text = "W";
            this.button41.Click += new System.EventHandler(this.button1_Click);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(12, 192);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(24, 24);
            this.button42.TabIndex = 16;
            this.button42.Text = "X";
            this.button42.Click += new System.EventHandler(this.button1_Click);
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(140, 285);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(92, 24);
            this.button43.TabIndex = 5;
            this.button43.Text = "KAPAT";
            this.button43.Click += new System.EventHandler(this.button43_Click);
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(172, 252);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(60, 24);
            this.button44.TabIndex = 6;
            this.button44.Text = "TAMAM";
            this.button44.Click += new System.EventHandler(this.button44_Click);
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(140, 221);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(24, 24);
            this.button45.TabIndex = 7;
            this.button45.Text = "5";
            this.button45.Click += new System.EventHandler(this.button1_Click);
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(108, 221);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(24, 24);
            this.button46.TabIndex = 8;
            this.button46.Text = "4";
            this.button46.Click += new System.EventHandler(this.button1_Click);
            // 
            // button47
            // 
            this.button47.Location = new System.Drawing.Point(76, 221);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(24, 24);
            this.button47.TabIndex = 9;
            this.button47.Text = "3";
            this.button47.Click += new System.EventHandler(this.button1_Click);
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(44, 221);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(24, 24);
            this.button48.TabIndex = 10;
            this.button48.Text = "2";
            this.button48.Click += new System.EventHandler(this.button1_Click);
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(12, 221);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(24, 24);
            this.button49.TabIndex = 11;
            this.button49.Text = "1";
            this.button49.Click += new System.EventHandler(this.button1_Click);
            // 
            // button52
            // 
            this.button52.Location = new System.Drawing.Point(140, 252);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(24, 24);
            this.button52.TabIndex = 0;
            this.button52.Text = "0";
            this.button52.Click += new System.EventHandler(this.button1_Click);
            // 
            // button53
            // 
            this.button53.Location = new System.Drawing.Point(108, 252);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(24, 24);
            this.button53.TabIndex = 1;
            this.button53.Text = "9";
            this.button53.Click += new System.EventHandler(this.button1_Click);
            // 
            // button54
            // 
            this.button54.Location = new System.Drawing.Point(76, 252);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(24, 24);
            this.button54.TabIndex = 2;
            this.button54.Text = "8";
            this.button54.Click += new System.EventHandler(this.button1_Click);
            // 
            // button55
            // 
            this.button55.Location = new System.Drawing.Point(44, 252);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(24, 24);
            this.button55.TabIndex = 3;
            this.button55.Text = "7";
            this.button55.Click += new System.EventHandler(this.button1_Click);
            // 
            // button56
            // 
            this.button56.Location = new System.Drawing.Point(12, 252);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(24, 24);
            this.button56.TabIndex = 4;
            this.button56.Text = "6";
            this.button56.Click += new System.EventHandler(this.button1_Click);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(12, 285);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(120, 24);
            this.button36.TabIndex = 53;
            this.button36.Text = "KÜÇÜK";
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(108, 192);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(24, 24);
            this.button37.TabIndex = 54;
            this.button37.Text = ":";
            this.button37.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(138, 193);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(58, 24);
            this.btnTemizle.TabIndex = 55;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // FormTus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button52);
            this.Controls.Add(this.button53);
            this.Controls.Add(this.button54);
            this.Controls.Add(this.button55);
            this.Controls.Add(this.button56);
            this.Controls.Add(this.button43);
            this.Controls.Add(this.button44);
            this.Controls.Add(this.button45);
            this.Controls.Add(this.button46);
            this.Controls.Add(this.button47);
            this.Controls.Add(this.button48);
            this.Controls.Add(this.button49);
            this.Controls.Add(this.button38);
            this.Controls.Add(this.button39);
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
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTus";
            this.Text = "Türkçe Klavye";
            this.Load += new System.EventHandler(this.Tus_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}