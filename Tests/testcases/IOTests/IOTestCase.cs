using Tests.Head;
using Microsoft.Xna.Framework;
using Sh.Framework.Graphics.UI;
using Sh.Framework.Debug;
using Microsoft.Xna.Framework.Graphics;

namespace Tests.testcases.IOTests
{
    public class IOTestCase : testcase
    {
        private Game game;

        DebugConsole console;

        Button txtWrite;
        Button txtRead;

        Button xmlWrite;
        Button xmlRead;

        txtManager txt;
        xmlManager xml;

        public IOTestCase(Game other) : base(other)
        {
            testcasename = "IOTests";
            game = other;

            Texture2D pixel = game.Content.Load<Texture2D>(@"pixel");
            SpriteFont font = game.Content.Load<SpriteFont>(@"font");

            console = new DebugConsole(pixel, font, new Rectangle((int)Sh.Framework.Graphics.Window.getWidth() - 200, 750, 200, 400), game);

            txt = new txtManager(console);
            xml = new xmlManager(console);
        }

        public override void LoadContent()
        {
            font = game.Content.Load<SpriteFont>("font");

            Texture2D left = game.Content.Load<Texture2D>("button/left");
            Texture2D right = game.Content.Load<Texture2D>("button/right");
            Texture2D middle = game.Content.Load<Texture2D>("button/middle");

            txtWrite = new Button()
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                label = "write Text file",
                labelColor = Color.Black,
                rect = new Rectangle(180, 80, 300, 50),
                labelFont = font,
                focused = true,
            }; txtWrite.LoadContent();

            txtRead = new Button()
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                label = "read Text file",
                labelColor = Color.Black,
                rect = new Rectangle(180, 180, 300, 50),
                labelFont = font,
                focused = true,
            }; txtWrite.LoadContent();

            xmlWrite = new Button()
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                label = "write XML file",
                labelColor = Color.Black,
                rect = new Rectangle(480, 80, 300, 50),
                labelFont = font,
                focused = true,
            }; xmlWrite.LoadContent();

            xmlRead = new Button()
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                label = "read XML file",
                labelColor = Color.Black,
                rect = new Rectangle(480, 180, 300, 50),
                labelFont = font,
                focused = true,
            }; xmlRead.LoadContent();
            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            txtWrite.Update();
            txtRead.Update();
            xmlWrite.Update();
            xmlRead.Update();

            if (txtWrite.pressed)
            {
                txt.writeFile();
                txtWrite.pressed = false;
            }

            if (txtRead.pressed)
            {
                txt.readFile();
                txtRead.pressed = false;
            }

            if (xmlWrite.pressed)
            {
                xml.writeFile();
                xmlWrite.pressed = false;
            }

            if (console.log.Count > 5)
            {
                console.wipe();
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            txtWrite.Draw(spritebatch);
            txtRead.Draw(spritebatch);
            xmlWrite.Draw(spritebatch);
            xmlRead.Draw(spritebatch);

            console.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
