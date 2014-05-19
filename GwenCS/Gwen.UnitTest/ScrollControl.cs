using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class ScrollControl : GUnit
    {
        public ScrollControl(Base parent)
            : base(parent)
        {
            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(10, 10, 100, 100);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Twice As Big");
                pTestButton.SetBounds(0, 0, 200, 200);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(110, 10, 100, 100);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Same Size");
                pTestButton.SetBounds(0, 0, 100, 100);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(210, 10, 100, 100);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Wide");
                pTestButton.SetBounds(0, 0, 200, 50);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(310, 10, 100, 100);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Tall");
                pTestButton.SetBounds(0, 0, 50, 200);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(410, 10, 100, 100);
                ctrl.EnableScroll(false, true);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Vertical");
                pTestButton.SetBounds(0, 0, 200, 200);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(510, 10, 100, 100);
                ctrl.EnableScroll(true, false);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Horizontal");
                pTestButton.SetBounds(0, 0, 200, 200);
            }

            // Bottom Row

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(10, 110, 100, 100);
                ctrl.AutoHideBars = true;

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Twice As Big");
                pTestButton.SetBounds(0, 0, 200, 200);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(110, 110, 100, 100);
                ctrl.AutoHideBars = true;

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Same Size");
                pTestButton.SetBounds(0, 0, 100, 100);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(210, 110, 100, 100);
                ctrl.AutoHideBars = true;

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Wide");
                pTestButton.SetBounds(0, 0, 200, 50);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(310, 110, 100, 100);
                ctrl.AutoHideBars = true;

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Tall");
                pTestButton.SetBounds(0, 0, 50, 200);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(410, 110, 100, 100);
                ctrl.AutoHideBars = true;
                ctrl.EnableScroll(false, true);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Vertical");
                pTestButton.SetBounds(0, 0, 200, 200);
            }

            {
                Control.ScrollControl ctrl = new Control.ScrollControl(this);
                ctrl.SetBounds(510, 110, 100, 100);
                ctrl.AutoHideBars = true;
                ctrl.EnableScroll(true, false);

                Control.Button pTestButton = new Control.Button(ctrl);
                pTestButton.SetText("Horinzontal");
                pTestButton.SetBounds(0, 0, 200, 200);
            }
        }
    }
}
