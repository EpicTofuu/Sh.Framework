using Tests.Head;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics;
using Sh.Framework.Input;

namespace Tests.testcases.KeyStrokeTests
{
    public class KeyStrokeTestCase : testcase
    {
        private Game game;

        int keypressed;
        int keyreleased;

        KeyboardState oldState;
        KeyboardState newState;

        SpriteFont fnt;

        public Text message;
        public Text keypressedDisp;

        public Text message2;
        public Text keyreleasedDisp;

        public KeyStrokeTestCase(Game Game) : base (Game)
        {
            game = Game;
            oldState = Keyboard.GetState();
            keypressed = 0;
            testcasename = "KeyStrokes";
        }

        public override void LoadContent()
        {
            fnt = game.Content.Load<SpriteFont>("font");

            message = new Text
            {
                text = "Key pressed (space)",
                position = new Vector2(300, 280),
                color = Color.Black,
                game = game,
                font = "font"
            }; message.LoadContent();

            message2 = new Text
            {
                text = "Key released (enter)",
                position = new Vector2(600, 280),
                color = Color.Black,
                game = game,
                font = "font"
            }; message2.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            newState = Keyboard.GetState();

            if (KeyboardStroke.KeyDown(oldState, newState, Keys.Space))
            {
                keypressed++;
            }

            if (KeyboardStroke.KeyUp(oldState, newState, Keys.Enter))
            {
                keyreleased++;
            }

            oldState = newState;

            keypressedDisp = new Text
            {
                text = keypressed.ToString(),
                position = new Vector2(300),
                font = "font",
                color = Color.Black,
                game = this.game
            }; keypressedDisp.LoadContent();
            base.Update(gametime);

            keyreleasedDisp = new Text
            {
                text = keyreleased.ToString(),
                position = new Vector2(600, 300),
                font = "font",
                color = Color.Black,
                game = this.game
            }; keyreleasedDisp.LoadContent();
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            keypressedDisp.Draw(spritebatch);
            message.Draw(spritebatch);

            keyreleasedDisp.Draw(spritebatch);
            message2.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
