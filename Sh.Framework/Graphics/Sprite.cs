using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects.Interfaces;

namespace Sh.Framework.Graphics
{
    public class Sprite : IStationary
    {
        public string texturename;

        public Color color;

        public Rectangle rect;

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

            rect = new Rectangle((int)position.X, (int)position.Y, (int)texture?.Width, (int)texture?.Height);
            spritebatch.Draw(texture, rect, color);
        }

        public void UnloadContent()
        {
            throw new System.NotImplementedException();
        }
    }
}
