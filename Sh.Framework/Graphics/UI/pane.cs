using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Graphics.UI
{
    /// <summary>
    /// creates a stretchable box using three textures
    /// fully strechable along width but not on height
    /// </summary>
    public class Pane
    {   
        public Texture2D buttonLeft;
        public Texture2D buttonRight;
        public Texture2D buttonMiddle;

        public Color color = Color.White;
        public Rectangle rect;
        public float alpha = 1;

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(buttonMiddle, new Rectangle(rect.Left + buttonLeft.Width, rect.Y, rect.Width - (buttonRight.Width + buttonLeft.Width), rect.Height), color * alpha);
            batch.Draw(buttonLeft, new Rectangle(rect.Left, rect.Y, buttonLeft.Width, rect.Height), color * alpha);
            batch.Draw(buttonRight, new Rectangle(rect.Right - buttonRight.Width, rect.Y, buttonLeft.Width, rect.Height), color * alpha);
        }
    }
}
