using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class TabControl : GUnit
    {
        private readonly Control.TabControl m_DockControl;

        public TabControl(Base parent)
            : base(parent)
        {
            {
                m_DockControl = new Control.TabControl(this);
                m_DockControl.SetBounds(10, 10, 200, 200);

                {
                    Control.TabButton button = m_DockControl.AddPage("Controls");
                    Base page = button.Page;

                    {
                        Control.RadioButtonGroup radio = new Control.RadioButtonGroup(page);
                        radio.Text = "Tab position";
                        radio.SetPosition(10, 10);

                        radio.AddOption("Top").Select();
                        radio.AddOption("Bottom");
                        radio.AddOption("Left");
                        radio.AddOption("Right");

                        radio.SelectionChanged += OnDockChange;

                    }
                }

                m_DockControl.AddPage("Red");
                m_DockControl.AddPage("Green");
                m_DockControl.AddPage("Blue");
            }

            {
                Control.TabControl dragMe = new Control.TabControl(this);
                dragMe.SetBounds(220, 10, 200, 200);

                dragMe.AddPage("You");
                dragMe.AddPage("Can");
                dragMe.AddPage("Reorder").SetImage("test16.png");
                dragMe.AddPage("These");
                dragMe.AddPage("Tabs");

                dragMe.AllowReorder = true;
            }
        }

		void OnDockChange(Base control, EventArgs args)
        {
            RadioButtonGroup rc = (RadioButtonGroup)control;

            if (rc.SelectedLabel == "Top") m_DockControl.TabStripPosition = Pos.Top;
            if (rc.SelectedLabel == "Bottom") m_DockControl.TabStripPosition = Pos.Bottom;
            if (rc.SelectedLabel == "Left") m_DockControl.TabStripPosition = Pos.Left;
            if (rc.SelectedLabel == "Right") m_DockControl.TabStripPosition = Pos.Right;
        }
    }
}
