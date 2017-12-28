using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Graphics
{
    public class Text
    {
        public string text;
        public Vector2 position = Vector2.Zero;
        public Color color = Color.White;
        public string font;
        public Game game;

        public SpriteFont useFont;

        /// <summary>
        /// render text with a quick to use type
        /// </summary>
        public Text()
        {
            /*
            if (fontDest != null)
            else
                useFont = font;*/

        }

        public virtual void LoadContent()
        {
            useFont = game?.Content.Load<SpriteFont>(font);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.DrawString(useFont, text, position, color);
        }
    }
}
