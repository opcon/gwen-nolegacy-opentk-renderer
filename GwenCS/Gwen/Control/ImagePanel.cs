using System;
using System.Drawing;

namespace Gwen.Control
{
    /// <summary>
    /// Image container.
    /// </summary>
    public class ImagePanel : Base
    {
        private readonly Texture m_Texture;
        private readonly float[] m_uv;
        private Color m_DrawColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagePanel"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public ImagePanel(Base parent)
            : base(parent)
        {
            m_uv = new float[4];
            m_Texture = new Texture(Skin.Renderer);
            SetUV(0, 0, 1, 1);
            MouseInputEnabled = true;
            m_DrawColor = Color.White;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            m_Texture.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// Sets the texture coordinates of the image.
        /// </summary>
        public virtual void SetUV(float u1, float v1, float u2, float v2)
        {
            m_uv[0] = u1;
            m_uv[1] = v1;
            m_uv[2] = u2;
            m_uv[3] = v2;
        }

        /// <summary>
        /// Texture name.
        /// </summary>
        public string ImageName
        {
            get { return m_Texture.Name; }
            set { m_Texture.Load(value); }
        }

        /// <summary>
        /// Renders the control using specified skin.
        /// </summary>
        /// <param name="skin">Skin to use.</param>
        protected override void Render(Skin.Base skin)
        {
            base.Render(skin);
            skin.Renderer.DrawColor = m_DrawColor;
            skin.Renderer.DrawTexturedRect(m_Texture, RenderBounds, m_uv[0], m_uv[1], m_uv[2], m_uv[3]);
        }

        /// <summary>
        /// Sizes the control to its contents.
        /// </summary>
        public virtual void SizeToContents()
        {
            SetSize(m_Texture.Width, m_Texture.Height);
        }

        /// <summary>
        /// Control has been clicked - invoked by input system. Windows use it to propagate activation.
        /// </summary>
        public override void Touch()
        {
            base.Touch();
        }

        /// <summary>
        /// Handler for Space keyboard event.
        /// </summary>
        /// <param name="down">Indicates whether the key was pressed or released.</param>
        /// <returns>
        /// True if handled.
        /// </returns>
        protected override bool OnKeySpace(bool down)
        {
            if (down)
                base.OnMouseClickedLeft(0, 0, true);
            return true;
        }
    }
}
