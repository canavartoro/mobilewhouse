using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
#if NETCFDESIGNTIME
	using System.ComponentModel;
#endif

namespace MobileWhouse.GUI
{
    public class UButton : Control
    {
        /// <summary>
        /// Button that behaves the same as the standard button,
        /// but has properties for button colour and text colour
        /// for both normal state and pushed state.
        /// </summary>
        #region Control Attributes
        //Remove two unwanted properties: BackColor and ForeColor
#if NETCFDESIGNTIME
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
#endif
        public override Color BackColor
        {
            set
            { ;}
            get
            { return new Color(); }
        }
#if NETCFDESIGNTIME
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
#endif
        public override Color ForeColor
        {
            set
            { ;}
            get
            { return new Color(); }
        }

        //Now add the properties for the four colours we do want:
        //	NormalBtnColour
        //	NormalTxtColour
        //	PushedBtnColour
        //	PushedTxtColour
#if NETCFDESIGNTIME
			[Category("Appearance")]
			[DefaultValue(3)]
			[Description("The normal colour of the button.")]
#endif
        public Color NormalBtnColour
        {
            set
            {
                m_NormalBtnColour = value;
                Invalidate();
            }
            get
            {
                return m_NormalBtnColour;
            }
        }
#if NETCFDESIGNTIME
			[Category("Appearance")]
			[DefaultValue(3)]
			[Description("The normal colour of the button text.")]
#endif
        public Color NormalTxtColour
        {
            set
            {
                m_NormalTxtColour = value;
                Invalidate();
            }
            get
            {
                return m_NormalTxtColour;
            }
        }
#if NETCFDESIGNTIME
			[Category("Appearance")]
			[DefaultValue(3)]
			[Description("The colour of the button when clicked.")]
#endif
        public Color PushedBtnColour
        {
            set
            {
                m_PushedBtnColour = value;
                Invalidate();
            }
            get
            {
                return m_PushedBtnColour;
            }
        }
#if NETCFDESIGNTIME
			[Category("Appearance")]
			[DefaultValue(3)]
			[Description("The colour of the button text when clicked.")]
#endif
        public Color PushedTxtColour
        {
            set
            {
                m_PushedTxtColour = value;
                Invalidate();
            }
            get
            {
                return m_PushedTxtColour;
            }
        }
        #endregion

        #region Attributes
        Color m_NormalBtnColour = Color.LightYellow;
        Color m_NormalTxtColour = Color.Blue;
        Color m_PushedBtnColour = Color.Blue;
        Color m_PushedTxtColour = Color.Yellow;
        private ImageAlignment imageAlignment = ImageAlignment.Left;
        private System.Drawing.Image image;

        public enum States
        {
            Normal,
            Pushed
        }

        States m_state;
        #endregion

//#if NETCFDESIGNTIME
//            [Browsable(false)]
//            [EditorBrowsable(EditorBrowsableState.Never)]
//#endif
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

        public ImageAlignment Alignment
        {
            get
            {
                return this.imageAlignment;
            }
            set
            {
                this.imageAlignment = value;
            }
        }

        #region Public Services
        public UButton()
        {
            m_state = States.Normal;
        }
        #endregion

        #region Protected/Private Services
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            m_state = States.Pushed;
            // button receives input focus
            Focus();
            base.OnMouseDown(e);
            Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            m_state = States.Normal;
            base.OnMouseUp(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Pen pen;
            SolidBrush brush;
            SolidBrush textBrush;

            //Work out the colours that we should be using for the text and background
            if (m_state == States.Normal)
            {
                brush = new SolidBrush(m_NormalBtnColour);
                textBrush = new SolidBrush(m_NormalTxtColour);
                pen = new Pen(m_NormalTxtColour);
            }
            else
            {
                brush = new SolidBrush(m_PushedBtnColour);
                textBrush = new SolidBrush(m_PushedTxtColour);
                pen = new Pen(m_PushedTxtColour);
            }

            //Draw a rectangle and fill the inside
            graphics.FillRectangle(brush, 0, 0, Width, Height);
            graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);

            try
            {
                if (this.image != null)
                {
                    Rectangle rectangle;
                    int _x = 0, _y = 0;
                    if (imageAlignment == ImageAlignment.Center)
                    {
                        _x = (base.Width - this.image.Width) / 2;
                        _y = (base.Height - this.image.Height) / 2;
                    }
                    else if (imageAlignment == ImageAlignment.Left)
                    {
                        _y = (base.Height - this.image.Height) / 2;
                        _x = 2;
                    }
                    else if (imageAlignment == ImageAlignment.TopCenter)
                    {
                        _y = 2;
                        _x = (base.Width - this.image.Width) / 2;
                    }
                    else if (imageAlignment == ImageAlignment.BottomCenter)
                    {
                        _y = (base.Height - this.image.Height + 2);
                        _x = (base.Width - this.image.Width) / 2;
                    }
                    else
                    {
                        _x = (base.Width - (this.image.Width + 2));
                        _y = (base.Height - this.image.Height) / 2;
                    }
                    if (m_state != States.Pushed)
                    {
                        rectangle = new Rectangle(_x, _y, this.image.Width, this.image.Height);
                    }
                    else
                    {
                        rectangle = new Rectangle(_x, _y, this.image.Width, this.image.Height);
                    }
                    ImageAttributes imageAttr = new ImageAttributes();
                    imageAttr.SetColorKey(this.BackgroundImageColor(this.image), this.BackgroundImageColor(this.image));
                    graphics.DrawImage(this.image, rectangle, 0, 0, this.image.Width, this.image.Height, GraphicsUnit.Pixel, imageAttr);
                }
            }
            catch { ;}

            //Create a font based on the default font
            int fontHeight = 10;
            Font font = new Font(FontFamily.GenericSerif, fontHeight, FontStyle.Bold);

            //Find out the size of the text
            SizeF textSize = new SizeF();
            textSize = e.Graphics.MeasureString(Text, font);

            //Work out how to position the text centrally
            float x = 0, y = 0;
            if (textSize.Width < Width)
                x = (Width - textSize.Width) / 2;
            if (textSize.Height < Height)
                y = (Height - textSize.Height) / 2;

            //Draw the text in the centre of the button using the default font
            graphics.DrawString(Text, font, textBrush, x, y);
        }

        #endregion

        private Color BackgroundImageColor(System.Drawing.Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            return bitmap.GetPixel(0, 0);
        }
    }

    public enum ImageAlignment
    {
        Left,
        Center,
        Right,
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

}
