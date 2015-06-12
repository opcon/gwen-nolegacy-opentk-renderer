using System;
using System.Net;
using Gwen.Control;
using OpenTK.Input;
using OpenTK;
using OpenTKKey = OpenTK.Input.Key;

namespace Gwen.Input
{
    public class OpenTKAlternative
    {

        #region Properties

        private Canvas m_Canvas = null;

        private int m_MouseX = 0;
        private int m_MouseY = 0;

        bool m_AltGr = false;

        #endregion

        #region Constructors
        public OpenTKAlternative(Canvas c)
        {
            m_Canvas = c;
        }

        #endregion

        #region Methods
        public void Initialize(Canvas c)
        {
            m_Canvas = c;
        }

        /// <summary>
        /// Translates control key's OpenTK key code to GWEN's code.
        /// </summary>
        /// <param name="key">OpenTK key code.</param>
        /// <returns>GWEN key code.</returns>
        private Key TranslateKeyCode(OpenTKKey key)
        {
            switch (key)
            {
                case OpenTKKey.BackSpace: return Key.Backspace;
                case OpenTKKey.Enter: return Key.Return;
                case OpenTKKey.Escape: return Key.Escape;
                case OpenTKKey.Tab: return Key.Tab;
                case OpenTKKey.Space: return Key.Space;
                case OpenTKKey.Up: return Key.Up;
                case OpenTKKey.Down: return Key.Down;
                case OpenTKKey.Left: return Key.Left;
                case OpenTKKey.Right: return Key.Right;
                case OpenTKKey.Home: return Key.Home;
                case OpenTKKey.End: return Key.End;
                case OpenTKKey.Delete: return Key.Delete;
                case OpenTKKey.LControl:
                    this.m_AltGr = true;
                    return Key.Control;
                case OpenTKKey.LAlt: return Key.Alt;
                case OpenTKKey.LShift: return Key.Shift;
                case OpenTKKey.RControl: return Key.Control;
                case OpenTKKey.RAlt:
                    if (this.m_AltGr)
                    {
                        this.m_Canvas.Input_Key(Key.Control, false);
                    }
                    return Key.Alt;
                case OpenTKKey.RShift: return Key.Shift;

            }
            return Key.Invalid;
        }

        /// <summary>
        /// Translates alphanumeric OpenTK key code to character value.
        /// </summary>
        /// <param name="key">OpenTK key code.</param>
        /// <returns>Translated character.</returns>
        private static char TranslateChar(OpenTKKey key)
        {
            if (key >= OpenTKKey.A && key <= OpenTKKey.Z)
                return (char)('a' + ((int)key - (int)OpenTKKey.A));
            return ' ';
        }

        public bool ProcessMouseMove(int x, int y)
        {
            int dx = x - m_MouseX;
            int dy = y - m_MouseY;

            m_MouseX = x;
            m_MouseY = y;

            return m_Canvas.Input_MouseMoved(m_MouseX, m_MouseY, dx, dy);
        }

        public bool ProcessMouseButton(MouseButton button, bool isPressed)
        {
            /* We can not simply cast ev.Button to an int, as 1 is middle click, not right click. */
            int ButtonID = -1; //Do not trigger event.

            if (button == MouseButton.Left)
                ButtonID = 0;
            else if (button == MouseButton.Right)
                ButtonID = 1;

            if (ButtonID != -1) //We only care about left and right click for now
                return m_Canvas.Input_MouseButton(ButtonID, isPressed);
            else return false;
        }

        public bool ProcessMouseWheel(int delta)
        {
            return m_Canvas.Input_MouseWheel(delta * 60);
        }

        public bool ProcessKeyDown(OpenTKKey key)
        {
            char ch = TranslateChar(key);

            if (InputHandler.DoSpecialKeys(m_Canvas, ch))
                return false;
            /*
            if (ch != ' ')
            {
                m_Canvas.Input_Character(ch);
            }
            */
            Key iKey = TranslateKeyCode(key);

            return m_Canvas.Input_Key(iKey, true); 
        }

        //public bool ProcessKeyUp(EventArgs args)
        public bool ProcessKeyUp(OpenTKKey key)
        {
            char ch = TranslateChar(key);

            Key iKey = TranslateKeyCode(key);

            return m_Canvas.Input_Key(iKey, false);
        }

        //public void KeyPress(object sender, KeyPressEventArgs e)
        public void KeyPress(char keyChar)
        {
            m_Canvas.Input_Character(keyChar);
        }

        #endregion
    }
}
