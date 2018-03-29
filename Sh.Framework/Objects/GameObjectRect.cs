using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Objects
{
    /// <summary>
    /// Basically just <see cref="GameObject"/> but you can use a <see cref="Rectangle"/> instead of a <see cref="Vector2"/>.
    /// Will deprecate <see cref="GameObject"/> <see cref="Vector2"/> with this one soon.
    /// </summary>
    public class GameObjectRect : GenericObject
    {
        //to assign
        public string texturename;
        public Texture2D texture;
        public Rectangle rect = new Rectangle();

        public Color color = Color.White;

        protected Game game;

        public GameObjectRect(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            if (texturename != "")
            {
                texture = game.Content.Load<Texture2D>(texturename);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (texture != null)
            {
                batch.Draw(texture, rect, color);
            }
        }
    }
}
