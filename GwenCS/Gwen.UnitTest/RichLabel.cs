using System;
using System.Drawing;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class RichLabel : GUnit
    {
        private Font f1, f2, f3;

        public RichLabel(Base parent) : base(parent)
        {
            Control.RichLabel label = new Control.RichLabel(this);
            label.SetBounds(10, 10, 400, 200);

            f1 = new Font(Skin.Renderer, "Arial", 15);
            label.AddText("This test uses Arial 15, Red. Padding. ", Color.Red, f1);
            
            f2 = new Font(Skin.Renderer, "Times New Roman Bold", 20);
            label.AddText("This text uses Times New Roman Bold 20, Green. Padding. ", Color.Green, f2);

            f3 = new Font(Skin.Renderer, "Courier New Italic", 15);
            label.AddText("This text uses Courier New Italic 15, Blue. Padding. ", Color.Blue, f3);

            label.AddLineBreak();

            label.AddText("This test uses Arial 15, Magenta. Padding. ", Color.Magenta, f1);
        }

        public override void Dispose()
        {
            f1.Dispose();
            f2.Dispose();
            f3.Dispose();
            base.Dispose();
        }
    }
}
