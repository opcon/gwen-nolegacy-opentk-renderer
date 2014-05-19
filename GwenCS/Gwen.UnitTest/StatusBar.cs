using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class StatusBar : GUnit
    {
        public StatusBar(Base parent)
            : base(parent)
        {
            Control.StatusBar sb = new Control.StatusBar(this);
            Control.Label left = new Control.Label(sb);
            left.Text = "Label added to left";
            sb.AddControl(left, false);

            Control.Label right = new Control.Label(sb);
            right.Text = "Label added to right";
            sb.AddControl(right, true);

            Control.Button bl = new Control.Button(sb);
            bl.Text = "Left button";
            sb.AddControl(bl, false);

            Control.Button br = new Control.Button(sb);
            br.Text = "Right button";
            sb.AddControl(br, true);
        }
    }
}
