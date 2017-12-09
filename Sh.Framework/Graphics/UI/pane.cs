using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Graphics.UI
{
    public class pane
    {   
        public Texture2D buttonLeft;
        public Texture2D buttonRight;
        public Texture2D buttonMiddle;

        public Color color;
        public Rectangle rect;

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(buttonMiddle, new Rectangle(rect.Left + buttonLeft.Width, rect.Y, rect.Width - (buttonRight.Width + buttonLeft.Width), rect.Height), color);
            batch.Draw(buttonLeft, new Rectangle(rect.Left, rect.Y, buttonLeft.Width, rect.Height), color);
            batch.Draw(buttonRight, new Rectangle(rect.Right - buttonRight.Width, rect.Y, buttonLeft.Width, rect.Height), color);
        }
    }
}
