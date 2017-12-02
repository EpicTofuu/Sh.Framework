using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Graphics
{
    public class Sprite
    {
        public string texturename;

        public Color color;

        public Vector2 position;

        public Game game;

        private Texture2D texture;

        public Sprite()
        {

        }

        public virtual void LoadContent()
        {
            if (texturename != null)
                texture = game.Content.Load <Texture2D> (texturename);
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position, color);
        }
    }
}
