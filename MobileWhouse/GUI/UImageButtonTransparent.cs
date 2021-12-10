using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MobileWhouse.Enums;

namespace MobileWhouse.GUI
{
    public partial class UImageButtonTransparent : Control
    {
        public UImageButtonTransparent()
        {
            if (_image == null)
            {
                _image = Properties.Resources.ok;
                this.Size = new Size(32, 32);
                this.Text = string.Empty;
                this.TextUzaklik = 25;
            }
        }

        private bool pressed = false;
        private int _TextUzaklik = 25;
        private Image _image;
        private UButtonType _ButtonType;
        private UButtonSize _ButtonSize = UButtonSize.Medium;

        public int TextUzaklik
        {
            get { return _TextUzaklik; }
            set
            {
                _TextUzaklik = value;
            }
        }

        public Image Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
            }
        }

        public UButtonType ButtonType
        {
            get { return _ButtonType; }
            set
            {
                _ButtonType = value;

                switch (_ButtonType)
                {
                    case UButtonType.Ok:
                        _image = Properties.Resources.ok;
                        break;
                    case UButtonType.Cancel:
                        _image = Properties.Resources.err;
                        break;
                    default:
                        break;
                }

                this.Invalidate();
            }
        }

        public UButtonSize ButtonSize
        {
            get { return _ButtonSize; }
            set
            {
                _ButtonSize = value;

                //if (_ButtonSize == MikrobarButtonSize.Small)
                //    this.Size = new Size(24, 24);
                //else if (_ButtonSize == MikrobarButtonSize.Medium)
                //    this.Size = new Size(32, 32);
                //else
                //    this.Size = new Size(64, 64);

                this.Refresh();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.pressed = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.pressed = false;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this._image, 0, 0, new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);

            if (this.Text.Length > 0)
            {
                SizeF size = e.Graphics.MeasureString(this.Text, this.Font);

                Color foreColor = this.Enabled != true ? Color.Gray : Color.Black;

                e.Graphics.DrawString(this.Text,
                    this.Font,

                    new SolidBrush(foreColor),
                    ((this.ClientSize.Width + TextUzaklik) - size.Width) / 2,
                    (this.ClientSize.Height - size.Height) / 2);
            }

            if (!pressed)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0,
                   this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Blue), i, i,
                          this.ClientSize.Width - 2, this.ClientSize.Height - 2);
                }
            }

            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ((Control)this).Invalidate();
        }
    }
}
