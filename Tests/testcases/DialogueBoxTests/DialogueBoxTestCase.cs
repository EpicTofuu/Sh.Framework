using Tests.Head;
using Tests.Head.GenericElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics.UI;

namespace Tests.testcases.DialogueBoxTests
{
    public class DialogueBoxTestCase : testcase
    {
        Game game;

        button button_messagebox;
        DialogueBox messagebox;

        button button_yesno;
        DialogueBox yesno;

        public DialogueBoxTestCase(Game Game) : base (Game)
        {
            testcasename = "DialogueBoxes";
            game = Game;
        }

        public override void LoadContent()
        {
            button_messagebox = new button(game)
            {
                label = "button_messagebox",
                rect = new Rectangle(300, 300, 200, 50)
            };
            button_messagebox.LoadContent();

            button_yesno = new button(game)
            {
                label = "button_yesno",
                rect = new Rectangle(500, 300, 200, 50)
            };
            button_yesno.LoadContent();

            messagebox = new DialogueBox()
            {
                Type = DialogueBox.type.message,
                message = "this is a dialoguebox",
                title = "facts",
                font = game.Content.Load<SpriteFont>("font"),
                TitleAlign = DialogueBox.Align.Middle,
                MessageAlign = DialogueBox.Align.Left,
                window = new Pane()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    rect = new Rectangle((int)Sh.Framework.Graphics.Window.getWidth() / 2 - 400 / 2, (int)Sh.Framework.Graphics.Window.getHeight() / 2 - 100 / 2, 400, 100),
                    color = Color.White
                },
                selectionButton = new Button()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    labelFont = game.Content.Load<SpriteFont>("font"),
                    rect = new Rectangle(0, 0, 120, 20)
                },
            };
            messagebox.visible = false;

            yesno = new DialogueBox()
            {
                Type = DialogueBox.type.yesno,
                message = "would you like to throw an exception?",
                title = "yes no",
                font = game.Content.Load<SpriteFont>("font"),
                TitleAlign = DialogueBox.Align.Middle,
                MessageAlign = DialogueBox.Align.Left,
                window = new Pane()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    rect = new Rectangle((int)Sh.Framework.Graphics.Window.getWidth() / 2 - 400 / 2, (int)Sh.Framework.Graphics.Window.getHeight() / 2 - 100 / 2, 400, 100),
                    color = Color.White
                },
                selectionButton = new Button()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    labelFont = game.Content.Load<SpriteFont>("font"),
                    rect = new Rectangle(0, 0, 120, 20)
                },
            };
            yesno.visible = false;

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            button_messagebox.Update();
            messagebox.Update();

            button_yesno.Update();
            yesno.Update();

            if (button_messagebox.pressed)
            {
                messagebox.visible = true;
                button_messagebox.pressed = false;
            }

            if (button_yesno.pressed)
            {
                yesno.visible = true;
                button_yesno.pressed = false;
            }

            if (yesno.outcome)
            {
                throw new System.Exception("hi there");
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            button_messagebox.Draw(spritebatch);
            messagebox.Draw(spritebatch);

            button_yesno.Draw(spritebatch);
            yesno.Draw(spritebatch);

            base.Draw(spritebatch);
        }
    }
}
