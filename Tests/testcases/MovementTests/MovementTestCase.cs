/*
This testcase tests the player type object. A class is able to inherit this player class and assign all the controls.
Additionally, collision is already included and is fully functional
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tests.Head;

namespace Tests.MovementTests
{
    public class MovementTestCase : testcase
    {
        private Game game;

        public static Wall wall;

        private movingObject moving;

        public MovementTestCase(Game othergame) : base (othergame)
        {
            testcasename = "Movement";
            game = othergame;
        }

        public override void LoadContent()
        {
            wall = new Wall(game);
            wall.LoadContent();

            moving = new movingObject(game);
            moving.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            wall.Update();
            moving.Update();

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            wall.Draw(spritebatch);
            moving.Draw(spritebatch);

            base.Draw(spritebatch);
        }
    }
}
