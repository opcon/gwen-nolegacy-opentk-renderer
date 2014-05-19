using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class Properties : GUnit
    {
        public Properties(Base parent)
            : base(parent)
        {
            {
                Control.Properties props = new Control.Properties(this);
                props.ValueChanged += OnChanged;

                props.SetBounds(10, 10, 150, 300);

                {
                    {
                        Control.PropertyRow pRow = props.Add("First Name");
                    }

                    props.Add("Middle Name");
                    props.Add("Last Name");
                }
            }

            {
                Control.PropertyTree ptree = new Control.PropertyTree(this);
                ptree.SetBounds(200, 10, 200, 200);

                {
                    Control.Properties props = ptree.Add("Item One");
                    props.ValueChanged += OnChanged;

                    props.Add("Middle Name");
                    props.Add("Last Name");
                    props.Add("Four");
                }

                {
                    Control.Properties props = ptree.Add("Item Two");
                    props.ValueChanged += OnChanged;
                    
                    props.Add("More Items");
                    props.Add("Bacon", new Control.Property.Check(props), "1");
                    props.Add("To Fill");
                    props.Add("Color", new Control.Property.Color(props), "255 0 0");
                    props.Add("Out Here");
                }

                ptree.ExpandAll();
            }
        }

        void OnChanged(Base control, EventArgs args)
        {
            PropertyRow row = control as PropertyRow;
            UnitPrint(String.Format("Property changed: {0}", row.Value));
        }
    }
}
