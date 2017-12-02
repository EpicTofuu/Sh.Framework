using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;
using Sh.Framework.Physics.Collisions;

namespace Sh.Framework.Graphics.UI
{
    /// <summary>
    /// public Type for generic UI checkboxes
    /// </summary>
    public class Checkbox : ClickableObject
    {
        public Texture2D boxTexture;
        public Texture2D tickTexture;
        public SpriteFont labelFont;

        public string label;

        public Color defaultColor;
        public Color hoverColor;
        public Color disableColor;
        public Color labelColor;
        public Color tickColor;

        public bool focused;

        public bool ticked;

        private MouseState mouse;

        private Color boxColor;

        public override void Update()
        {
            mouse = Mouse.GetState();

            if (focused)
            {
                if (MouseTouching.Rect(mouse, rect))
                {
                    boxColor = hoverColor;
                }
                else
                {
                    boxColor = defaultColor;
                }
            }
            else
            {
                boxColor = disableColor;
            }

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(boxTexture, rect, boxColor);

            if (ticked)
                batch.Draw(tickTexture, rect, tickColor);

            batch.DrawString(labelFont, label, new Vector2(rect.Right + 8, rect.Y + rect.Width / 4), labelColor);
            base.Draw(batch);
        }

        public override void OnClick()
        {
            if (ticked)
                ticked = false;
            else
                ticked = true;

            base.OnClick();
        }
    }
}
