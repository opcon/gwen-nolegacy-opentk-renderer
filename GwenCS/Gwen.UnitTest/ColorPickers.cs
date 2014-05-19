using System;
using System.Drawing;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class ColorPickers : GUnit
    {
        public ColorPickers(Base parent)
            : base(parent)
        {
            /* RGB Picker */
            {
                ColorPicker rgbPicker = new ColorPicker(this);
                rgbPicker.SetPosition(10, 10);
                rgbPicker.ColorChanged += ColorChanged;
            }

            /* HSVColorPicker */
            {
                HSVColorPicker hsvPicker = new HSVColorPicker(this);
                hsvPicker.SetPosition(300, 10);
                hsvPicker.ColorChanged += ColorChanged;
            }

            /* HSVColorPicker in Window */
            {
                Control.WindowControl Window = new WindowControl(this);
                Window.SetSize(300, 300);
                Window.Hide();

                HSVColorPicker hsvPicker = new HSVColorPicker(Window);
                hsvPicker.SetPosition(10, 10);
                hsvPicker.ColorChanged += ColorChanged;

                Control.Button OpenWindow = new Control.Button(this);
                OpenWindow.SetPosition(10, 200);
                OpenWindow.SetSize(200, 20);
                OpenWindow.Text = "Open Window";
				OpenWindow.Clicked += delegate(Base sender, ClickedEventArgs args)
                {
                    Window.Show();
                };
            }
        }

		void ColorChanged(Base control, EventArgs args)
        {
            IColorPicker picker = control as IColorPicker;
            Color c = picker.SelectedColor;
            HSV hsv = c.ToHSV();
            String text = String.Format("Color changed: RGB: {0:X2}{1:X2}{2:X2} HSV: {3:F1} {4:F2} {5:F2}",
                                        c.R, c.G, c.B, hsv.h, hsv.s, hsv.v);
            UnitPrint(text);
        }
    }
}
