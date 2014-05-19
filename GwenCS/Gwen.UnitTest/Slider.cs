using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class Slider : GUnit
    {
        public Slider(Base parent)
            : base(parent)
        {
            {
                Control.HorizontalSlider slider = new Control.HorizontalSlider(this);
                slider.SetPosition(10, 10);
                slider.SetSize(150, 20);
                slider.SetRange(0, 100);
                slider.Value = 25;
                slider.ValueChanged += SliderMoved;
            }

            {
                Control.HorizontalSlider slider = new Control.HorizontalSlider(this);
                slider.SetPosition(10, 40);
                slider.SetSize(150, 20);
                slider.SetRange(0, 100);
                slider.Value = 20;
                slider.NotchCount = 10;
                slider.SnapToNotches = true;
                slider.ValueChanged += SliderMoved;
            }

            {
                Control.VerticalSlider slider = new Control.VerticalSlider(this);
                slider.SetPosition(160, 10);
                slider.SetSize(20, 200);
                slider.SetRange(0, 100);
                slider.Value = 25;
                slider.ValueChanged += SliderMoved;
            }

            {
                Control.VerticalSlider slider = new Control.VerticalSlider(this);
                slider.SetPosition(190, 10);
                slider.SetSize(20, 200);
                slider.SetRange(0, 100);
                slider.Value = 20;
                slider.NotchCount = 10;
                slider.SnapToNotches = true;
                slider.ValueChanged += SliderMoved;
            }
        }

		void SliderMoved(Base control, EventArgs args)
        {
            Control.Slider slider = control as Control.Slider;
            UnitPrint(String.Format("Slider moved: ValueChanged: {0}", slider.Value));
        }
    }
}
