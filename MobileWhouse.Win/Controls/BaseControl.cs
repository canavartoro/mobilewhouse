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
        }

        public event EventHandler OnLoad;

        public virtual void OnRafBarkod(NameIdItem raf)
        { 
            
        }

        public virtual void OnItemBarkod(ItemInfo item)
        { }

        private bool onload = false;
        private void BaseControl_Paint(object sender, PaintEventArgs e)
        {
            if (!Utility.IsDesignMode)
            {
                if (!onload)
                {
                    onload = true;
                    if (OnLoad != null) OnLoad(this, e);
                }
            }
        }
    }
}
