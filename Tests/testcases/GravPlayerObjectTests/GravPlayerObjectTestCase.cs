using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using Tests.Head;

namespace Tests.testcases.GravPlayerObjectTests
{
    public class GravPlayerObjectTestCase : testcase
    {
        private Game game;

        public static intrusiveSolid wall;

        private moveable player;

        public GravPlayerObjectTestCase(Game othergame) : base(othergame)
        {
            game = othergame;
            testcasename = "GravPlayerObject";
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            font = game.Content.Load<SpriteFont>("font");

            wall = new intrusiveSolid(game);
            player = new moveable(game);

            wall.LoadContent();
            player.LoadContent();
            
            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            player.Update();
            wall.Update();
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            player.Draw(spritebatch);
            wall.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
