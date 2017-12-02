using Sh.Framework.Objects;
using Sh.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Tests.Head
{
    public class header : GenericObject
    {
        private Texture2D pixel;
        private SpriteFont font;
        private string testcase;

        private Game game;

        public header(Game othergame, Texture2D otherpixel, SpriteFont otherfont, string othertestcase)
        {
            game = othergame;
            pixel = otherpixel;
            font = otherfont;
            testcase = othertestcase;
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(pixel, new Rectangle(0, 0, (int) utils.getScreenWidth(), 40), Color.Gray);
            batch.DrawString(font, "testcase: " + testcase, new Vector2(10, 10), Color.White);

            batch.DrawString(font, DateTime.Now.ToString(), new Vector2(1200, 10), Color.White);
            base.Draw(batch);
        }
    }
}
