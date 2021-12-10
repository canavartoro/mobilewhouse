using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace MobileWhouse.GUI
{
    public partial class UButton : Control
    {
        private bool bPushed = false;
        private System.Drawing.Image image;
        private Bitmap m_bmpOffscreen;

        public UButton()
        {
            base.Size = new Size(0x15, 0x15);
        }

        private Color BackgroundImageColor(System.Drawing.Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            return bitmap.GetPixel(0, 0);
        }

        public void close_image()
        {
            this.Dispose(true);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.bPushed = true;
            base.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.bPushed = false;
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brush;
            if (this.m_bmpOffscreen == null)
            {
                this.m_bmpOffscreen = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
            }
            Graphics graphics = Graphics.FromImage(this.m_bmpOffscreen);
            graphics.Clear(this.BackColor);
            if (!this.bPushed)
            {
                brush = new SolidBrush(base.Parent.BackColor);
            }
            else
            {
                brush = new SolidBrush(Color.WhiteSmoke);
            }
            graphics.FillRectangle(brush, base.ClientRectangle);
            if (this.image != null)
            {
                Rectangle rectangle;
                //int x = (base.Width - this.image.Width) / 2;
                //int y = (base.Height - this.image.Height) / 2;
                int x = 2, y = 2;
                if (!this.bPushed)
                {
                    rectangle = new Rectangle(x, y, this.image.Width, this.image.Height);
                }
                else
                {
                    rectangle = new Rectangle(x, y, this.image.Width, this.image.Height);
                }
                ImageAttributes imageAttr = new ImageAttributes();
                imageAttr.SetColorKey(this.BackgroundImageColor(this.image), this.BackgroundImageColor(this.image));
                graphics.DrawImage(this.image, rectangle, 0, 0, this.image.Width, this.image.Height, GraphicsUnit.Pixel, imageAttr);
            }
            if (this.bPushed)
            {
                Rectangle clientRectangle = base.ClientRectangle;
                clientRectangle.Width--;
                clientRectangle.Height--;
                graphics.DrawRectangle(new Pen(Color.Red), clientRectangle);
            }
            e.Graphics.DrawImage(this.m_bmpOffscreen, 0, 0);

            if (!string.IsNullOrEmpty(Text))
            {
                SizeF size = e.Graphics.MeasureString(Text, Font);
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor),
                    (this.ClientSize.Width - size.Width) / 2,
                    (this.ClientSize.Height - size.Height) / 2);
            }

            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        public System.Drawing.Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        /*
        public UButton()
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
        private UButtonType _ButtonType = UButtonType.Ok;
        private Image _image;

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
            if (this._image != null)
                e.Graphics.DrawImage(this._image, 0, 0);

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

        */
    }
}
