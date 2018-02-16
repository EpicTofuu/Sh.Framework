using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;

namespace Tests.testcases.GravPlayerObjectTests
{
    public class moveable : GravPlayerObject
    {
        Vector2 storepos;

        public moveable(Game othergame) : base(othergame)
        {
            texturename = "texture0";
            color = Color.White;
            position = new Vector2(400, 100);
            storepos = position;
            solid = true;
            jump = Keys.Space;
            moveLeft = Keys.A;
            moveRight = Keys.D;
            speed = 10;
            gravity = 5;
            jumpspeed = 20;

            solids.Add(GravPlayerObjectTestCase.wall);
        }

        public override void Update()
        {
            if (position.Y > (int)Sh.Framework.Graphics.ShWindow.getHeight())
                position = storepos;

            base.Update();
        }
    }
}
