using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Graphics.UI;
using Tests.Head;

namespace Tests.testcases.ButtonTests
{
    public class ButtonTestCase : testcase
    {
        private Game game;

        private Button a;
        private Button b;
        private Button c;

        private string message;

        public ButtonTestCase(Game othergame) : base(othergame)
        {
            game = othergame;
            testcasename = "buttons";
            message = "no button has been pressed";
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            font = game.Content.Load<SpriteFont>("font");

            Texture2D left = game.Content.Load<Texture2D>("button/left");
            Texture2D right = game.Content.Load<Texture2D>("button/right");
            Texture2D middle = game.Content.Load<Texture2D>("button/middle");
            

            a = new Button
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                labelFont = font,
                label = "a",
                buttonColorDefault = Color.White,
                buttonColorHover = Color.LightGray,
                buttonColorPressed = Color.DarkGray,
                labelColor = Color.Black,
                focused = true,
                rect = new Rectangle(180, 100, 200, 50)
            };
            a.LoadContent();

            b = new Button
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                labelFont = font,
                label = "b",
                buttonColorDefault = Color.White,
                buttonColorHover = Color.LightGray,
                buttonColorPressed = Color.DarkGray,
                labelColor = Color.Black,
                focused = true,
                rect = new Rectangle(400, 100, 200, 50)
            };
            b.LoadContent();

            c = new Button
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                labelFont = font,
                label = "c",
                buttonColorDefault = Color.White,
                buttonColorHover = Color.LightGray,
                buttonColorPressed = Color.DarkGray,
                labelColor = Color.Black,
                focused = false,
                rect = new Rectangle(620, 100, 200, 50)
            };
            c.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            a.Update();
            b.Update();
            c.Update();

            if (a.pressed)
                message = "button a has been pressed press space to reset";

            if (b.pressed)
                message = "button b has been pressed press space to reset";

            if (c.pressed)
                message = "this isn't supposed to happen";

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                a.pressed = false;
                b.pressed = false;
                c.pressed = false;
                message = "all buttons have been reset";
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            a.Draw(spritebatch);
            b.Draw(spritebatch);
            c.Draw(spritebatch);

            spritebatch.DrawString(font, message, new Vector2(180, 200), Color.White);

            base.Draw(spritebatch);
        }
    }
}
