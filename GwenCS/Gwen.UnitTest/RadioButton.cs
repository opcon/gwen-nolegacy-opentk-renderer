using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class RadioButton : GUnit
    {
        enum Choices
        {
            OptionA,
            DoorB,
            HallC
        }

        public RadioButton(Base parent)
            : base(parent)
        {
            Control.RadioButtonGroup rbg = new Control.RadioButtonGroup(this);
            rbg.Text = "Sample radio group";
            rbg.SetPosition(10, 10);

            rbg.AddOption("Option 1");
            rbg.AddOption("Option 2");
            rbg.AddOption("Option 3");
            rbg.AddOption("\u0627\u0644\u0622\u0646 \u0644\u062D\u0636\u0648\u0631");
            //rbg.SizeToContents(); // it's auto

            rbg.SelectionChanged += OnChange;

            Control.LabeledRadioButton rb1 = new LabeledRadioButton(this);
            rb1.Text = "Option 1";
            rb1.SetPosition(300, 10);

            Control.LabeledRadioButton rb2 = new LabeledRadioButton(this);
            rb2.Text = "Option 2222222222222222222222222222222222";
            rb2.SetPosition(300, 30);

            Control.LabeledRadioButton rb3 = new LabeledRadioButton(this);
            rb3.Text = "\u0627\u0644\u0622\u0646 \u0644\u062D\u0636\u0648\u0631";
            rb3.SetPosition(300, 50);

            {
                EnumRadioButtonGroup<Choices> erbg = new EnumRadioButtonGroup<Choices>(this);
                erbg.SetPosition(10, 100);
                erbg.SelectedValue = Choices.HallC;
            }


            //this.DrawDebugOutlines = true;

        }

        void OnChange(Base control, EventArgs args)
        {
            RadioButtonGroup rbc = control as RadioButtonGroup;
            LabeledRadioButton rb = rbc.Selected;
            UnitPrint(String.Format("RadioButton: SelectionChanged: {0}", rb.Text));
        }
    }
}
