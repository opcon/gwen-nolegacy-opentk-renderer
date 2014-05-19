using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class Button : GUnit
    {
        private readonly Control.Button buttonA, buttonB, buttonC, buttonD, buttonE, buttonF, buttonG, buttonH;

        public Button(Base parent)
            : base(parent)
        {
            buttonA = new Control.Button(this);
            buttonA.Text = "Event tester";
            buttonA.SetBounds(200, 30, 300, 200);
            buttonA.Pressed += onButtonAp;
            buttonA.Clicked += onButtonAc;
            buttonA.Released += onButtonAr;

            buttonB = new Control.Button(this);
            buttonB.Text = "\u0417\u0430\u043C\u0435\u0436\u043D\u0430\u044F \u043C\u043E\u0432\u0430";
            buttonB.SetPosition(0, 20);

            buttonC = new Control.Button(this);
            buttonC.Text = "Image button";
            buttonC.SetImage("test16.png");
            Align.PlaceDownLeft(buttonC, buttonB, 10);

            buttonD = new Control.Button(this);
            buttonD.SetImage("test16.png");
            buttonD.SetSize(20, 20);
            Align.PlaceDownLeft(buttonD, buttonC, 10);

            buttonE = new Control.Button(this);
            buttonE.Text = "Toggle me";
            buttonE.IsToggle = true;
            buttonE.Toggled += onToggle;
            buttonE.ToggledOn += onToggleOn;
            buttonE.ToggledOff += onToggleOff;
            Align.PlaceDownLeft(buttonE, buttonD, 10);

            buttonF = new Control.Button(this);
            buttonF.Text = "Disabled :D";
            buttonF.IsDisabled = true;
            Align.PlaceDownLeft(buttonF, buttonE, 10);

            buttonG = new Control.Button(this);
            buttonG.Text = "With Tooltip";
            buttonG.SetToolTipText("This is tooltip");
            Align.PlaceDownLeft(buttonG, buttonF, 10);

            buttonH = new Control.Button(this);
            buttonH.Text = "I'm autosized";
            buttonH.SizeToContents();
            Align.PlaceDownLeft(buttonH, buttonG, 10);
        }

		private void onButtonAc(Base control, EventArgs args)
        {
            UnitPrint("Button: Clicked");
        }

		private void onButtonAp(Base control, EventArgs args)
        {
            UnitPrint("Button: Pressed");
        }

		private void onButtonAr(Base control, EventArgs args)
        {
            UnitPrint("Button: Released");
        }

		private void onToggle(Base control, EventArgs args)
        {
            UnitPrint("Button: Toggled");
        }

		private void onToggleOn(Base control, EventArgs args)
        {
            UnitPrint("Button: OnToggleOn");
        }

		private void onToggleOff(Base control, EventArgs args)
        {
            UnitPrint("Button: ToggledOff");
        }
    }
}
