using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics;
using Sh.Framework.Graphics.UI;
using Sh.Framework.vnTools;
using Tests.Head;

namespace Tests.testcases.RenderTextTests
{
    public class RenderTextTestCase : testcase
    {
        Game game;

        Text renderText;

        Button start;

        TextManager Tmanager;

        public RenderTextTestCase(Game othergame) : base (othergame)
        {
            testcasename = "Render Text";
            game = othergame;
        }

        public override void LoadContent()
        {
            Texture2D left = game.Content.Load<Texture2D>("button/left");
            Texture2D right = game.Content.Load<Texture2D>("button/right");
            Texture2D middle = game.Content.Load<Texture2D>("button/middle");
            font = game.Content.Load<SpriteFont>("font");

            Tmanager = new TextManager(game);

            renderText = new Text
            {
                text = "",
                position = new Vector2(400),
                color = Color.Black,
                font = @"font",
                game = this.game
            }; renderText.LoadContent();

            start = new Button
            {
                buttonLeft = left,
                buttonMiddle = middle,
                buttonRight = right,
                buttonColorDefault = Color.White,
                buttonColorHover = Color.LightGray,
                buttonColorPressed = Color.DarkGray,
                focused = true,
                label = "start rendering text",
                labelColor = Color.Black,
                labelFont = font,
                rect = new Rectangle (200, 200, 250, 50)
            }; start.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            start.Update();

            if (start.pressed)
            {
                renderText.text = "not finished yet :)";
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            start.Draw(spritebatch);
            renderText.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
