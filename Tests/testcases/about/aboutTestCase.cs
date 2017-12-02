using Tests.Head;
using Sh.Framework.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tests.testcases.about
{
    public class aboutTestCase : Screen
    {
        private buttonpane buttonpane;

        private header header;

        private Texture2D pixel;
        private SpriteFont font;

        private Game game;

        public aboutTestCase(Game othergame)
        {
            game = othergame;
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            font = game.Content.Load<SpriteFont>("font");

            buttonpane = new buttonpane(pixel, font, game);
            header = new header(game, pixel, font, "about");

            base.LoadContent();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(pixel, new Rectangle(0, 0, 1366, 768), Color.DarkSlateGray);

            spritebatch.DrawString(font, "About \n\n" +
                "Welcome to the Sh.Framework testing interface, here you can test all the features Sh.Framework has to offer \n" +
                "Use the left bar to navigate, the top bar tells you which testcase is currently active. \n" +
                "Grey text indicate stable features that are fully functional, Yellow text indicate incomplete features that will be properly functioning in the near future, \n" +
                "also, good luck with the background in the other testcases xd", new Vector2(180, 60), Color.White);

            buttonpane.Draw(spritebatch);
            header.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
