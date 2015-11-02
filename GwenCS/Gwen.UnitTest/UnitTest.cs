using System;
using Gwen.Control;
using Gwen.Control.Layout;

namespace Gwen.UnitTest
{
    public class UnitTest : DockBase
    {
        private Control.Base m_LastControl;
        private readonly Control.StatusBar m_StatusBar;
        private readonly Control.ListBox m_TextOutput;
        private Control.TabButton m_Button;
        private readonly Control.CollapsibleList m_List;
        private readonly Center m_Center;
        private readonly Control.LabeledCheckBox m_DebugCheck;

        public double Fps; // set this in your rendering loop
        public string Note; // additional text to display in status bar

        public UnitTest(Base parent) : base(parent)
        {
            Dock = Pos.Fill;
            m_List = new Control.CollapsibleList(this);

            LeftDock.TabControl.AddPage("Unit tests", m_List);
            LeftDock.Width = 150;

            m_TextOutput = new Control.ListBox(BottomDock);
            m_Button = BottomDock.TabControl.AddPage("Output", m_TextOutput);
            BottomDock.Height = 200;

            m_DebugCheck = new Control.LabeledCheckBox(m_List);
            m_DebugCheck.Text = "Debug outlines";
            m_DebugCheck.CheckChanged += DebugCheckChanged;

            m_StatusBar = new Control.StatusBar(this);
            m_StatusBar.Dock = Pos.Bottom;
            m_StatusBar.AddControl(m_DebugCheck, true);

            m_Center = new Center(this);
            m_Center.Dock = Pos.Fill;
            GUnit test;

            {
                CollapsibleCategory cat = m_List.Add("Non-Interactive");
                {
                    test = new Label(m_Center);
                    RegisterUnitTest("Label", cat, test);
                    test = new RichLabel(m_Center);
                    RegisterUnitTest("RichLabel", cat, test);
                    test = new GroupBox(m_Center);
                    RegisterUnitTest("GroupBox", cat, test);
                    test = new ProgressBar(m_Center);
                    RegisterUnitTest("ProgressBar", cat, test);
                    test = new ImagePanel(m_Center);
                    RegisterUnitTest("ImagePanel", cat, test);
                    test = new StatusBar(m_Center);
                    RegisterUnitTest("StatusBar", cat, test);
                }
            }

            {
                CollapsibleCategory cat = m_List.Add("Standard");
                {
                    test = new Button(m_Center);
                    RegisterUnitTest("Button", cat, test);
                    test = new TextBox(m_Center);
                    RegisterUnitTest("TextBox", cat, test);
                    test = new CheckBox(m_Center);
                    RegisterUnitTest("CheckBox", cat, test);
                    test = new RadioButton(m_Center);
                    RegisterUnitTest("RadioButton", cat, test);
                    test = new ComboBox(m_Center);
                    RegisterUnitTest("ComboBox", cat, test);
                    test = new ListBox(m_Center);
                    RegisterUnitTest("ListBox", cat, test);
                    test = new NumericUpDown(m_Center);
                    RegisterUnitTest("NumericUpDown", cat, test);
                    test = new Slider(m_Center);
                    RegisterUnitTest("Slider", cat, test);
                    test = new Menu(m_Center);
                    RegisterUnitTest("Menu", cat, test);
                    test = new CrossSplitter(m_Center);
                    RegisterUnitTest("CrossSplitter", cat, test);
                }
            }
            
            {
                CollapsibleCategory cat = m_List.Add("Containers");
                {
                    test = new Window(m_Center);
                    RegisterUnitTest("Window", cat, test);
                    test = new TreeControl(m_Center);
                    RegisterUnitTest("TreeControl", cat, test);
                    test = new Properties(m_Center);
                    RegisterUnitTest("Properties", cat, test);
                    test = new TabControl(m_Center);
                    RegisterUnitTest("TabControl", cat, test);
                    test = new ScrollControl(m_Center);
                    RegisterUnitTest("ScrollControl", cat, test);
                    test = new Docking(m_Center);
                    RegisterUnitTest("Docking", cat, test);
                }
            }
            
            {
                CollapsibleCategory cat = m_List.Add("Non-standard");
                {
                    test = new CollapsibleList(m_Center);
                    RegisterUnitTest("CollapsibleList", cat, test);
                    //test.Show();
                    test = new ColorPickers(m_Center);
                    RegisterUnitTest("Color pickers", cat, test);
                }
            }

            m_StatusBar.SendToBack();
            PrintText("Unit Test started!");
        }

        public void RegisterUnitTest(string name, CollapsibleCategory cat, GUnit test)
        {
            Control.Button btn = cat.Add(name);
            test.Dock = Pos.Fill;
            test.Hide();
            test.UnitTest = this;
            btn.UserData = test;
            btn.Clicked += OnCategorySelect;
        }

		private void DebugCheckChanged(Base control, EventArgs args)
        {
            if (m_DebugCheck.IsChecked)
                m_Center.DrawDebugOutlines = true;
            else
                m_Center.DrawDebugOutlines = false;
            Invalidate();
        }

		private void OnCategorySelect(Base control, EventArgs args)
        {
            if (m_LastControl != null)
            {
                m_LastControl.Hide();
            }
            Base test = control.UserData as Base;
            test.Show();
            m_LastControl = test;
        }

        public void PrintText(string str)
        {
            m_TextOutput.AddRow(str);
			m_TextOutput.ScrollToBottom();
        }

        protected override void Layout(Skin.Base skin)
        {
            base.Layout(skin);
        }

        protected override void Render(Skin.Base skin)
        {
            m_StatusBar.Text = String.Format("GWEN.Net Unit Test - {0:F0} fps. {1}", Fps, Note);

            base.Render(skin);
        }
    }
}
