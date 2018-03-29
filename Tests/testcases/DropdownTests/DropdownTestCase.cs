using Tests.Head;
using Microsoft.Xna.Framework;
using Sh.Framework.Graphics.UI;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tests.testcases.DropdownTests
{
    public class DropdownTestCase : testcase
    {
        Game game;

        Dropdown ImageDropdownDown;
        Dropdown NoImageDropdownUp;

        public DropdownTestCase(Game Game) : base(Game)
        {
            game = Game;
            testcasename = "Dropdowns";

        }

        public override void LoadContent()
        {
            ImageDropdownDown = new Dropdown(game)
            {
                Options = new List<string>(),
                EntryButton = new Button()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    labelFont = game.Content.Load<SpriteFont>("font")
                },
                rect = new Rectangle(200, 300, 180, 40),
                direction = Dropdown.Direction.down,
            };

            ImageDropdownDown.Options = new List<string>();
            ImageDropdownDown.Options.Add("as you can see");
            ImageDropdownDown.Options.Add("this");
            ImageDropdownDown.Options.Add("one");
            ImageDropdownDown.Options.Add("drops");
            ImageDropdownDown.Options.Add("down");
            ImageDropdownDown.LoadContent();


            NoImageDropdownUp = new Dropdown(game)
            {
                Options = new List<string>(),
                EntryButton = new Button()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    labelFont = game.Content.Load<SpriteFont>("font")
                },
                rect = new Rectangle(500, 300, 180, 40),
                direction = Dropdown.Direction.up,

            };

            NoImageDropdownUp.Options = new List<string>();
            NoImageDropdownUp.Options.Add("this one however");
            NoImageDropdownUp.Options.Add("works");
            NoImageDropdownUp.Options.Add("its");
            NoImageDropdownUp.Options.Add("way");
            NoImageDropdownUp.Options.Add("upwards");
            NoImageDropdownUp.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            ImageDropdownDown.Update();
            NoImageDropdownUp.Update();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);

            NoImageDropdownUp.Draw(spritebatch);
            ImageDropdownDown.Draw(spritebatch);
        }
    }
}
