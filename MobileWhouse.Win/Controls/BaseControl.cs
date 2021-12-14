using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;
using MobileWhouse.Util;
using MobileWhouse.Controls.PRD;

namespace MobileWhouse.Controls
{
    public partial class BaseControl : UserControl
    {
        private FormMain _MainForm;

        public FormMain MainForm
        {
            get
            {
                return _MainForm;
            }
            set
            {
                _MainForm = value;
            }
        }

        public BaseControl()
        {
            InitializeComponent();
            //if (Utility.IsWindowsCE)
            //{
            //    this.KeyUp += new KeyEventHandler(this.BaseControl_KeyUp);
            //    foreach (Control c in this.Controls)
            //    {
            //        if (!c.GetType().ToString().Equals("System.Windows.Forms.TextBox"))
            //        {
            //            c.KeyUp += new KeyEventHandler(this.BaseControl_KeyUp);
            //        }
            //    }
            //}
        }

        public event EventHandler OnLoad;

        public virtual void OnRafBarkod(NameIdItem raf)
        {

        }

        public virtual void OnItemBarkod(ItemInfo item)
        { }

        private void timerLoader_Tick(object sender, EventArgs e)
        {
            timerLoader.Enabled = false;
            //if (!Utility.IsDesignMode)
            {
                //if (!onload)
                {
                    BackColor = Color.White;
                    if (OnLoad != null) OnLoad(this, e);
                }
            }
        }

        protected void ProcessKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 && e.Shift == false)
            {
                MainForm.ShowControl(new IsEmrineMalzemeTalepControl());
            }
            else if (e.KeyCode == Keys.D2 && e.Shift == false)
            {
                MainForm.ShowControl(new MalzemeTalepSevkControl());
            }
            else if (e.KeyCode == Keys.D3 && e.Shift == false)
            {
                MainForm.ShowControl(new IsEmriBaslatControl());
            }
            else if (e.KeyCode == Keys.D4 && e.Shift == false)
            {
                MainForm.ShowControl(new EtiketlemeControl());
            }
            else if (e.KeyCode == Keys.D5 && e.Shift == false)
            {
                MainForm.ShowControl(new UretimGirisControl());
            }
            else if (e.KeyCode == Keys.D6 && e.Shift == false)
            {
                MainForm.ShowControl(new DurusControl());
            }
            else if (e.KeyCode == Keys.D7 && e.Shift == false)
            {
                MainForm.ShowControl(new HurdaEtiketlemeControl());
            }
            else if (e.KeyCode == Keys.D8 && e.Shift == false)
            {
                MainForm.ShowControl(new HurdaTartimControl());
            }
            else if (e.KeyCode == Keys.D9 && e.Shift == false)
            {
                MainForm.ShowControl(new KarisimUretimControl());
            }
            else if (e.KeyCode == Keys.D0 && e.Shift == true)
            {
                MainForm.ShowControl(null);
            }
            else
            {
                //btnStokHareketi.Text = string.Concat("KeyCode:", e.KeyCode, ",KeyData:", e.KeyData, ",KeyValue:", e.KeyValue);
                //btnRafHareketi.Text = string.Concat("Alt:", e.Alt, ",Control:", e.Control, ",Shift:", e.Shift);
            }
        }

        public void BaseControl_KeyUp(object sender, KeyEventArgs e)
        {
            ProcessKey(e);
            //if (e.KeyCode == Keys.D1 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new IsEmrineMalzemeTalepControl());
            //}
            //else if (e.KeyCode == Keys.D2 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new MalzemeTalepSevkControl());
            //}
            //else if (e.KeyCode == Keys.D3 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new IsEmriBaslatControl());
            //}
            //else if (e.KeyCode == Keys.D4 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new EtiketlemeControl());
            //}
            //else if (e.KeyCode == Keys.D5 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new UretimGirisControl());
            //}
            //else if (e.KeyCode == Keys.D6 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new DurusControl());
            //}
            //else if (e.KeyCode == Keys.D7 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new HurdaEtiketlemeControl());
            //}
            //else if (e.KeyCode == Keys.D8 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new HurdaTartimControl());
            //}
            //else if (e.KeyCode == Keys.D9 && e.Shift == false)
            //{
            //    MainForm.ShowControl(new KarisimUretimControl());
            //}
            //else if (e.KeyCode == Keys.D0 && e.Shift == true)
            //{
            //    MainForm.ShowControl(null);
            //}
            //else
            //{
            //    //btnStokHareketi.Text = string.Concat("KeyCode:", e.KeyCode, ",KeyData:", e.KeyData, ",KeyValue:", e.KeyValue);
            //    //btnRafHareketi.Text = string.Concat("Alt:", e.Alt, ",Control:", e.Control, ",Shift:", e.Shift);
            //}

        }
    }
}
