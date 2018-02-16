using Tests.Head;
using Microsoft.Xna.Framework;
using Sh.Framework.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace Tests.testcases.DrawingTests
{
    public class DrawingTestCase : testcase
    {
        Game game;

        public DrawingTestCase(Game Game) 
            : base(Game)
        {
            game = Game;
            testcasename = "Drawing tests";
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            draw.s = spritebatch;
            draw.color = Color.Black;
            draw.Rectangle(new Rectangle(40, 40, 80, 80));
            base.Draw(spritebatch);
        }
    }
}
