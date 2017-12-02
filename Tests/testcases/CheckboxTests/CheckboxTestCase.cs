using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics.UI;
using Tests.Head;

namespace Tests.testcases.CheckboxTests
{
    public class CheckboxTestCase : testcase
    {
        private Game game;

        private Checkbox a;

        public CheckboxTestCase(Game othergame) : base(othergame)
        {
            game = othergame;
            testcasename = "Checkbox";
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            font = game.Content.Load<SpriteFont>("font");

            Texture2D tick = game.Content.Load<Texture2D>("texture1");

            a = new Checkbox
            {
                boxTexture = pixel,
                tickTexture = tick,
                labelFont = font,
                label = "checkbox a",
                defaultColor = Color.White,
                disableColor = Color.DarkGray,
                hoverColor = Color.LightGray,
                labelColor = Color.White,
                tickColor = Color.White,
                rect = new Rectangle(180, 100, 30, 30),
                focused = true
            }; a.LoadContent();
            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            a.Update();
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            a.Draw(spritebatch);
            spritebatch.DrawString(font, "a.ticked: " + a.ticked.ToString(), new Vector2(180, 170), Color.White);
            base.Draw(spritebatch);
        }
    }
}
