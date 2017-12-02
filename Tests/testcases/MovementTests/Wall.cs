using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Tests.MovementTests
{
    public class Wall : GameObject
    {
        public Wall(Game othergame) : base(othergame)
        {
            texturename = "texture1";
            color = Color.White;
            position = new Vector2(400, 100);
            solid = true;
        }
    }
}
