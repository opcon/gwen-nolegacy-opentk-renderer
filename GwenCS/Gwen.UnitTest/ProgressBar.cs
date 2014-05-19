using System;
using System.Drawing;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class ProgressBar : GUnit
    {
        public ProgressBar(Base parent) : base(parent)
        {
            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(110, 20, 200, 20));
                pb.Value = 0.27f;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(110, 50, 200, 20));
                pb.Value = 0.66f;
                pb.Alignment = Pos.Right | Pos.CenterV;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(110, 80, 200, 20));
                pb.Value = 0.88f;
                pb.Alignment = Pos.Left | Pos.CenterV;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(110, 110, 200, 20));
                pb.AutoLabel = false;
                pb.Value = 0.20f;
                pb.Alignment = Pos.Right | Pos.CenterV;
                pb.SetText("40,245 MB");
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(110, 140, 200, 20));
                pb.AutoLabel = false;
                pb.Value = 1.00f;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(110, 170, 200, 20));
                pb.AutoLabel = false;
                pb.Value = 0.00f;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(110, 200, 200, 20));
                pb.AutoLabel = false;
                pb.Value = 0.50f;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(20, 20, 25, 200));
                pb.IsHorizontal = false;
                pb.Value = 0.25f;
                pb.Alignment = Pos.Top | Pos.CenterH;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(50, 20, 25, 200));
                pb.IsHorizontal = false;
                pb.Value = 0.40f;
            }

            {
                Control.ProgressBar pb = new Control.ProgressBar(this);
                pb.SetBounds(new Rectangle(80, 20, 25, 200));
                pb.IsHorizontal = false;
                pb.Alignment = Pos.Bottom | Pos.CenterH;
                pb.Value = 0.65f;
            }
        }
    }
}
