using System;
using System.Drawing;

namespace Gwen.Control
{
    /// <summary>
    /// Horizontal slider.
    /// </summary>
    public class HorizontalSlider : Slider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HorizontalSlider"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public HorizontalSlider(Base parent)
            : base(parent)
        {
            m_SliderBar.IsHorizontal = true;
        }

        protected override float CalculateValue()
        {
            return (float)m_SliderBar.X / (Width - m_SliderBar.Width);
        }

        protected override void UpdateBarFromValue()
        {
            m_SliderBar.MoveTo((int)((Width - m_SliderBar.Width) * (m_Value)), m_SliderBar.Y);
        }

        /// <summary>
        /// Handler invoked on mouse click (left) event.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="down">If set to <c>true</c> mouse button is down.</param>
        protected override void OnMouseClickedLeft(int x, int y, bool down)
        {
			base.OnMouseClickedLeft(x, y, down);
            m_SliderBar.MoveTo((int)(CanvasPosToLocal(new Point(x, y)).X - m_SliderBar.Width*0.5), m_SliderBar.Y);
            m_SliderBar.InputMouseClickedLeft(x, y, down);
            OnMoved(m_SliderBar, EventArgs.Empty);
        }

        /// <summary>
        /// Lays out the control's interior according to alignment, padding, dock etc.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void Layout(Skin.Base skin)
        {
            m_SliderBar.SetSize(15, Height);
            UpdateBarFromValue();
        }

        /// <summary>
        /// Renders the control using specified skin.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void Render(Skin.Base skin)
        {
            skin.DrawSlider(this, true, m_SnapToNotches ? m_NotchCount : 0, m_SliderBar.Width);
        }
    }
}
