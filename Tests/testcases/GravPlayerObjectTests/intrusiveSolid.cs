using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Tests.testcases.GravPlayerObjectTests
{
    public class intrusiveSolid : GameObject
    {
        public intrusiveSolid(Game othergame) : base(othergame)
        {
            texturename = "texture1";
            color = Color.White;
            position = new Vector2(400, 400);
            solid = true;
        }
    }
}
