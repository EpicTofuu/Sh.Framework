using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Tests.testcases.DragableObjectTests
{
    public class Dragging : DragableObject
    {

        public Dragging(Game othergame) : base(othergame)
        {
            texturename = "texture2";
            color = Color.White;
            position = new Vector2(300, 300);
        }
    }
}
