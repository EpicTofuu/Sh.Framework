using Tests.Head;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics.UI;

namespace Tests.testcases.TextboxTests
{
    public class TextboxTestCase : testcase
    {
        Game game;
        Textbox name;

        public TextboxTestCase(Game Game) : base(Game)
        {
            testcasename = "Textboxes";
            game = Game;
        }

        public override void LoadContent()
        {
            name = new Textbox()
            {
                pane = new Pane()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    rect = new Rectangle(200, 200, 500, 50)
                },
                dummyText = "Enter...",
                characterRange = Textbox.CharacterRange.ASCII,
                font = game.Content.Load<SpriteFont>("font"),
                paddingX = 10,
                game = game,
                IBeam = game.Content.Load<Texture2D>("IBeam"),
                pixel = game.Content.Load<Texture2D>("pixel")
            }; name.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            name.Update();
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            name.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
