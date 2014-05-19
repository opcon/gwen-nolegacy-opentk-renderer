using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class GroupBox : GUnit
    {
        public GroupBox(Base parent) : base(parent)
        {
            {
                Control.GroupBox gb = new Control.GroupBox(this);
                gb.Text = "Group Box (centered)";
                gb.SetBounds(10, 10, 200, 100);
                //Align.Center(gb);
            }

            {
                Control.GroupBox gb = new Control.GroupBox(this);
                gb.AutoSizeToContents = true;
                gb.Text = "With Label (autosized)";
                gb.SetPosition(250, 10);
                Control.Label label = new Control.Label(gb);
                label.Text = "I'm a label";
            }

            {
                Control.GroupBox gb = new Control.GroupBox(this);
                gb.AutoSizeToContents = true;
                gb.Text = "With Label (autosized)";
                gb.SetPosition(250, 50);
                Control.Label label = new Control.Label(gb);
                label.Text = "I'm a label. I'm a really long label!";
            }

            {
                Control.GroupBox gb = new Control.GroupBox(this);
                gb.AutoSizeToContents = true;
                gb.Text = "Two docked Labels (autosized)";
                gb.SetPosition(250, 100);
                Control.Label label1 = new Control.Label(gb);
                label1.Text = "I'm a label";
                label1.Dock = Pos.Top;
                Control.Label label2 = new Control.Label(gb);
                label2.Text = "I'm a label. I'm a really long label!";
                label2.Dock = Pos.Top;
            }

            {
                Control.GroupBox gb = new Control.GroupBox(this);
                gb.AutoSizeToContents = true;
                gb.Text = "Empty (autosized)";
                gb.SetPosition(10, 150);
            }

            {
                Control.GroupBox gb1 = new Control.GroupBox(this);
                //Control.Label gb1 = new Control.Label(this);
                gb1.Padding = Padding.Five;
                gb1.Text = "Yo dawg,";
                gb1.SetPosition(10, 200);
                gb1.SetSize(350, 200);
                //gb1.AutoSizeToContents = true;
                
                Control.GroupBox gb2 = new Control.GroupBox(gb1);
                gb2.Text = "I herd";
                gb2.Dock = Pos.Left;
                gb2.Margin = Margin.Three;
                gb2.Padding = Padding.Five;
                //gb2.AutoSizeToContents = true;
                
                Control.GroupBox gb3 = new Control.GroupBox(gb1);
                gb3.Text = "You like";
                gb3.Dock = Pos.Fill;
                
                Control.GroupBox gb4 = new Control.GroupBox(gb3);
                gb4.Text = "Group Boxes,";
                gb4.Dock = Pos.Top;
                gb4.AutoSizeToContents = true;

                Control.GroupBox gb5 = new Control.GroupBox(gb3);
                gb5.Text = "So I put Group";
                gb5.Dock = Pos.Fill;
                //gb5.AutoSizeToContents = true;

                Control.GroupBox gb6 = new Control.GroupBox(gb5);
                gb6.Text = "Boxes in yo";
                gb6.Dock = Pos.Left;
                gb6.AutoSizeToContents = true;

                Control.GroupBox gb7 = new Control.GroupBox(gb5);
                gb7.Text = "Boxes so you can";
                gb7.Dock = Pos.Top;
                gb7.SetSize(100, 100);

                Control.GroupBox gb8 = new Control.GroupBox(gb7);
                gb8.Text = "Group Box while";
                gb8.Dock = Pos.Top;
                gb8.Margin = Gwen.Margin.Five;
                gb8.AutoSizeToContents = true;

                Control.GroupBox gb9 = new Control.GroupBox(gb7);
                gb9.Text = "u Group Box";
                gb9.Dock = Pos.Bottom;
                gb9.Padding = Gwen.Padding.Five;
                gb9.AutoSizeToContents = true;

				
            }
		
            
            // at the end to apply to all children
            DrawDebugOutlines = true;
        }
    }
}
