using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Screens;

namespace Tests.Head
{
    public class testcase : Screen
    {
        private header header;
        private buttonpane buttonpane;

        protected string testcasename;

        public Texture2D pixel;
        public SpriteFont font;

        private Game game;

        public testcase(Game othergame)
        {
            game = othergame;
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            font = game.Content.Load<SpriteFont>("font");

            header = new header(game, pixel, font, testcasename);
            buttonpane = new buttonpane(pixel, font, game);

            base.LoadContent();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            buttonpane.Draw(spritebatch);
            header.Draw(spritebatch);

            base.Draw(spritebatch);
        }
    }
}
