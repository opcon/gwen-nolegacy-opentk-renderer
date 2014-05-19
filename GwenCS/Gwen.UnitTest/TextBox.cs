using System;
using System.Drawing;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class TextBox : GUnit
    {
        private readonly Font m_Font1;
        private readonly Font m_Font2;
        private readonly Font m_Font3;

        public TextBox(Base parent)
            : base(parent) {
			int row = 0;

			m_Font1 = new Font(Skin.Renderer, "Consolas", 14); // fixed width font!
			m_Font2 = new Font(Skin.Renderer, "Impact", 50);
			m_Font3 = new Font(Skin.Renderer, "Arial", 14);

			/* Vanilla Textbox */
			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("Type something here");
				textbox.SetPosition(10, 10 + 25 * row);
				textbox.TextChanged += OnEdit;
				textbox.SubmitPressed += OnSubmit;
				row++;
			}

			/* Multiline Textbox */
			{
				Control.MultilineTextBox textbox = new Control.MultilineTextBox(this);
				textbox.Font = m_Font1;
				textbox.AcceptTabs = true;
				textbox.SetText("using System;\npublic class Test {\n\tpublic static void Main(){\n\t\tConsole.WriteLine(\"Hello World\");\n\t}\n}");
				textbox.SetPosition(220, 10);
				textbox.SetSize(500, 150);
			}

			{
				Control.TextBoxPassword textbox = new Control.TextBoxPassword(this);
				//textbox.MaskCharacter = '@';
				textbox.SetText("secret");
				textbox.TextChanged += OnEdit;
				textbox.SetPosition(10, 10 + 25 * row);
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("Select All Text On Focus");
				textbox.SetPosition(10, 10 + 25 * row);
				textbox.SelectAllOnFocus = true;
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("Different Coloured Text, for some reason");
				textbox.TextColor = Color.ForestGreen;
				textbox.SetPosition(10, 10 + 25 * row);
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBoxNumeric(this);
				textbox.SetText("200456698");
				textbox.TextColor = Color.LightCoral;
				textbox.SetPosition(10, 10 + 25 * row);
				row++;
			}

			row++;

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font3;
				textbox.SizeToContents();
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("..............................................................");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font3;
				textbox.SizeToContents();
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("public override void SetText(string str, bool doEvents = true)");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font3;
				textbox.SizeToContents();
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("あおい　うみから　やってきた");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font3;
				textbox.SizeToContents();
				row++;
			}

			row++;

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font1;
				textbox.SizeToContents();
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("..............................................................");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font1;
				textbox.SizeToContents();
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("public override void SetText(string str, bool doEvents = true)");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font1;
				textbox.SizeToContents();
				row++;
			}

			{
				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("あおい　うみから　やってきた");
				textbox.TextColor = Color.Black;
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font1;
				textbox.SizeToContents();
				row++;
			}

			row++;

			{

				Control.TextBox textbox = new Control.TextBox(this);
				textbox.SetText("Different Font (autosized)");
				textbox.SetPosition(10, 10 + 28 * row);
				textbox.Font = m_Font2;
				textbox.SizeToContents();

				row += 2;
			}
		}

        public override void Dispose()
        {
            m_Font1.Dispose();
            m_Font2.Dispose();
            m_Font3.Dispose();
            base.Dispose();
        }

		void OnEdit(Base control, EventArgs args)
        {
            Control.TextBox box = control as Control.TextBox;
            UnitPrint(String.Format("TextBox: OnEdit: {0}", box.Text));
        }

		void OnSubmit(Base control, EventArgs args)
        {
            Control.TextBox box = control as Control.TextBox;
            UnitPrint(String.Format("TextBox: OnSubmit: {0}", box.Text));
        }
    }
}
