using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class Docking : GUnit
    {
        private readonly Font font;
        private Control.Label outer;

        public Docking(Base parent)
            : base(parent)
        {
            font = Skin.DefaultFont.Copy();
            font.Size = 20;

            outer = new Control.Label(this);
            outer.SetBounds(10, 10, 400, 400);

            Control.Label inner1 = new Control.Label(outer);
            inner1.Text = "1";
            inner1.Font = font;
            inner1.SetSize(100, 100);
            inner1.Dock = Pos.Left;
            Control.Label inner2 = new Control.Label(outer);
            inner2.Text = "2";
            inner2.Font = font;
            inner2.SetSize(100, 100); 
            inner2.Dock = Pos.Top;
            Control.Label inner3 = new Control.Label(outer);
            inner3.Text = "3";
            inner3.Font = font;
            inner3.SetSize(100, 100); 
            inner3.Dock = Pos.Right;
            Control.Label inner4 = new Control.Label(outer);
            inner4.Text = "4";
            inner4.Font = font;
            inner4.SetSize(100, 100); 
            inner4.Dock = Pos.Bottom;
            Control.Label inner5 = new Control.Label(outer);
            inner5.Text = "5";
            inner5.Font = font;
            inner5.SetSize(100, 100); 
            inner5.Dock = Pos.Fill;

            outer.DrawDebugOutlines = true;

            inner1.UserData = CreateControls(inner1, 0, "Control 1", 440, 10);
            inner2.UserData = CreateControls(inner2, 1, "Control 2", 650, 10);
            inner3.UserData = CreateControls(inner3, 2, "Control 3", 440, 170);
            inner4.UserData = CreateControls(inner4, 3, "Control 4", 650, 170);
            inner5.UserData = CreateControls(inner5, 4, "Control 5", 440, 330);

            Control.Label l_padding = new Control.Label(this);
            l_padding.Text = "Padding:";
            l_padding.SetSize(50, 15);
            Align.PlaceDownLeft(l_padding, outer, 20);

            Control.HorizontalSlider padding = new Control.HorizontalSlider(this);
            padding.Min = 0;
            padding.Max = 200;
            padding.Value = 10;
            padding.SetSize(100, 20);
            padding.ValueChanged += PaddingChanged;
            Align.PlaceRightBottom(padding, l_padding);

            //DrawDebugOutlines = true;
        }

        Base CreateControls(Control.Base subject, int dock_idx, string name, int x, int y)
        {
            Control.GroupBox gb = new Control.GroupBox(this);
            gb.SetBounds(x, y, 200, 150);
            gb.Text = name;

            Control.Label l_width = new Control.Label(gb);
            l_width.SetSize(35, 15);
            l_width.Text = "Width:";
         
            Control.HorizontalSlider width = new HorizontalSlider(gb);
            width.Name = "Width";
            width.UserData = subject;
            width.Min = 50;
            width.Max = 350;
            width.Value = 100;
            width.SetSize(55, 15);
            width.ValueChanged += WidthChanged;
            Align.PlaceRightBottom(width, l_width);

            Control.Label l_height = new Control.Label(gb);
            l_height.SetSize(35, 15);
            l_height.Text = "Height:";
            Align.PlaceRightBottom(l_height, width, 10);

            Control.HorizontalSlider height = new Control.HorizontalSlider(gb);
            height.Name = "Height";
            height.UserData = subject;
            height.Min = 50;
            height.Max = 350;
            height.Value = 100;
            height.SetSize(55, 15);
            height.ValueChanged += HeightChanged;
            Align.PlaceRightBottom(height, l_height);

            Control.RadioButtonGroup dock = new RadioButtonGroup(gb);
            dock.Text = "Dock";
            dock.UserData = subject; // store control that we are controlling
            dock.AddOption("Left");
            dock.AddOption("Top");
            dock.AddOption("Right");
            dock.AddOption("Bottom");
            dock.AddOption("Fill");
            dock.SetSelection(dock_idx);
            Align.PlaceDownLeft(dock, l_width, 5);
            //dock.DrawDebugOutlines = true;
            dock.Invalidate();

            Control.Label l_margin = new Control.Label(gb);
            l_margin.Text = "Margin:";
            l_margin.SetBounds(75, 20, 35, 15);
            //Align.PlaceRightBottom(l_margin, dock);
            // can't use Align to anchor with 'dock' because radio group is resized only after layout ~_~
            // this is become really cumbersome
            //l_margin.DrawDebugOutlines = true;

            Control.HorizontalSlider margin = new HorizontalSlider(gb);
            margin.Name = "Margin";
            margin.UserData = subject;
            margin.Min = 0;
            margin.Max = 50;
            margin.Value = 10;
            margin.SetSize(55, 15);
            margin.ValueChanged += MarginChanged;
            Align.PlaceRightBottom(margin, l_margin);

            dock.SelectionChanged += DockChanged;

            return gb;
        }

        void PaddingChanged(Base control, EventArgs args)
        {
            Control.Slider val = control as Control.Slider;
            int i = (int)val.Value;
            outer.Padding = new Padding(i, i, i, i);
            outer.Invalidate();
        }

        void MarginChanged(Base control, EventArgs args)
        {
            Base inner = control.UserData as Base;
            Control.Slider val = control as Control.Slider;
            int i = (int)val.Value;
            inner.Margin = new Margin(i, i, i, i);
            outer.Invalidate();
        }

        void WidthChanged(Base control, EventArgs args)
        {
            Base inner = control.UserData as Base;
            Control.Slider val = control as Control.Slider;
            inner.Width = (int)val.Value;
            outer.Invalidate();
        }

        void HeightChanged(Base control, EventArgs args)
        {
            Base inner = control.UserData as Base;
            Control.Slider val = control as Control.Slider;
            inner.Height = (int)val.Value;
            outer.Invalidate();
        }

        void DockChanged(Base control, EventArgs args)
        {
            Base inner = (Base) control.UserData;
            RadioButtonGroup rbg = (RadioButtonGroup) control;
            Base gb = inner.UserData as Base;
            Control.Slider w = gb.FindChildByName("Width", true) as Control.Slider;
            Control.Slider h = gb.FindChildByName("Height", true) as Control.Slider;

            switch (rbg.SelectedIndex)
            {
                case 0:
                    inner.Dock = Pos.Left; 
                    break;
                case 1:
                    inner.Dock = Pos.Top;
                    break;
                case 2:
                    inner.Dock = Pos.Right;
                    break;
                case 3:
                    inner.Dock = Pos.Bottom;
                    break;
                case 4:
                    inner.Dock = Pos.Fill;
                    break;
            }
            inner.SetSize((int)w.Value, (int)h.Value);
            //inner.Invalidate();
            outer.Invalidate();
        }

        public override void Dispose()
        {
            font.Dispose();
            base.Dispose();
        }
    }
}
