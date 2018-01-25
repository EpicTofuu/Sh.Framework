using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Objects
{
    public class GameObject : GenericObject
    {
        //to assign
        public string texturename;
        protected Texture2D texture;

        public float textureWidth;
        public float textureHeight;

        public Color color = Color.White;
        public Vector2 position = Vector2.Zero;
        public bool solid = true;

        protected Game game0;
        public Rectangle hitbox;

        public GameObject(Game othergame)
        {
            game0 = othergame;
        }

        public override void LoadContent()
        {
            if (texturename != "")
            {
                try
                {
                    texture = game0.Content.Load<Texture2D>(texturename);
                }
                catch 
                {
                    
                }
            }
        }

        public override void Update()
        {
            if (solid && texture != null)
            {
                hitbox = new Rectangle((int)position.X, (int)position.Y, (int) texture.Width, (int) texture.Height);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (texture != null)
            {
                batch.Draw(texture, position, color);
            }
        }
    }
}
