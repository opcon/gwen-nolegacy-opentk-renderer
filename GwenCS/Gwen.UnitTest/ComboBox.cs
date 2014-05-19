using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class ComboBox : GUnit
    {
        public ComboBox(Base parent)
            : base(parent)
        {
            {
                Control.ComboBox combo = new Control.ComboBox(this);
                combo.SetPosition(50, 50);
                combo.Width = 200;

                combo.AddItem("Option One", "one");
                combo.AddItem("Number Two", "two");
                combo.AddItem("Door Three", "three");
                combo.AddItem("Four Legs", "four");
                combo.AddItem("Five Birds", "five");

                combo.ItemSelected += OnComboSelect;
            }

            {
                // Empty
                Control.ComboBox combo = new Control.ComboBox(this);
                combo.SetPosition(50, 80);
                combo.Width = 200;
            }

            {
                // Lots of things
                Control.ComboBox combo = new Control.ComboBox(this);
                combo.SetPosition(50, 110);
                combo.Width = 200;

                for (int i = 0; i < 500; i++)
                    combo.AddItem(String.Format("Option {0}", i));

                combo.ItemSelected += OnComboSelect;
            }

            {
                // In-Code Item Change
                Control.ComboBox combo = new Control.ComboBox(this);
                combo.SetPosition(50, 140);
                combo.Width = 200;

                MenuItem Triangle = combo.AddItem("Triangle");
                combo.AddItem("Red", "color");
                combo.AddItem("Apple", "fruit");
                combo.AddItem("Blue", "color");
                combo.AddItem("Green", "color", 12);
                combo.ItemSelected += OnComboSelect;

                //Select by Menu Item
                {
                    Control.Button TriangleButton = new Control.Button(this);
                    TriangleButton.SetPosition(255, 140);
                    TriangleButton.Text = "Triangle";
                    TriangleButton.Width = 100;
                    TriangleButton.Clicked += delegate(Base sender, ClickedEventArgs args)
                    {
                        combo.SelectedItem = Triangle;
                    };
                }

                //Select by Text
                {
                    Control.Button TestBtn = new Control.Button(this);
                    TestBtn.SetPosition(360, 140);
                    TestBtn.Text = "Red";
                    TestBtn.Width = 100;
					TestBtn.Clicked += delegate(Base sender, ClickedEventArgs args)
                    {
                        combo.SelectByText("Red");
                    };
                }

                //Select by Name
                {
                    Control.Button TestBtn = new Control.Button(this);
                    TestBtn.SetPosition(465, 140);
                    TestBtn.Text = "Apple";
                    TestBtn.Width = 100;
					TestBtn.Clicked += delegate(Base sender, ClickedEventArgs args)
                    {
                        combo.SelectByName("fruit");
                    };
                }

                //Select by UserData
                {
                    Control.Button TestBtn = new Control.Button(this);
                    TestBtn.SetPosition(570, 140);
                    TestBtn.Text = "Green";
                    TestBtn.Width = 100;
					TestBtn.Clicked += delegate(Base sender, ClickedEventArgs args)
                    {
                        combo.SelectByUserData(12);
                    };
                }
            }
        }

		void OnComboSelect(Base control, EventArgs args)
        {
            Control.ComboBox combo = control as Control.ComboBox;
            UnitPrint(String.Format("ComboBox: OnComboSelect: {0}", combo.SelectedItem.Text));
        }
    }
}
