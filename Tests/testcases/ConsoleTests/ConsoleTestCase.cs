using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics.UI;
using Sh.Framework.Debug;
using Tests.Head;

namespace Tests.testcases.ConsoleTests
{
    public class ConsoleTestCase : testcase
    {
        private Game game;

        Button commentConsole;
        Button warningConsole;
        Button errorConsole;
        Button fatalConsole;
        Button wipeConsole;
        Button writeConsole;

        DebugConsole dbconsole;

        public ConsoleTestCase(Game othergame) : base (othergame)
        {
            game = othergame;
            testcasename = "DebugConsole";
        }

        public override void LoadContent()
        {
            Texture2D CbuttonLeft = game.Content.Load<Texture2D>(@"button/left");
            Texture2D CbuttonRight = game.Content.Load<Texture2D>(@"button/right");
            Texture2D CbuttonMiddle = game.Content.Load<Texture2D>(@"button/middle");

            SpriteFont useFont = game.Content.Load<SpriteFont>(@"font");

            Texture2D pixel = game.Content.Load<Texture2D>(@"pixel");

            dbconsole = new DebugConsole(pixel, useFont, new Rectangle ((int)Sh.Framework.Graphics.Window.getWidth() - 800, 750, 800, 400), game);

            commentConsole = new Button
            {
                buttonLeft = CbuttonLeft,
                buttonRight = CbuttonRight,
                buttonMiddle = CbuttonMiddle,
                buttonColorDefault = Color.White,
                buttonColorHover = Color.Gray,
                buttonColorPressed = Color.DarkGray,
                labelFont = useFont,
                label = "Create comment in Console",
                labelColor = Color.White,
                rect = new Rectangle(180, 80, 300, 50),
                focused = true
            }; commentConsole.LoadContent();

            warningConsole = new Button
            {
                buttonLeft = CbuttonLeft,
                buttonRight = CbuttonRight,
                buttonMiddle = CbuttonMiddle,
                buttonColorDefault = Color.White,
                buttonColorHover = Color.Gray,
                buttonColorPressed = Color.DarkGray,
                labelFont = useFont,
                label = "Create warning in Console",
                labelColor = Color.Yellow,
                rect = new Rectangle(180, 180, 300, 50),
                focused = true
            }; warningConsole.LoadContent();

            errorConsole = new Button
            {
                buttonLeft = CbuttonLeft,
                buttonRight = CbuttonRight,
                buttonMiddle = CbuttonMiddle,
                buttonColorDefault = Color.White,
                buttonColorHover = Color.Gray,
                buttonColorPressed = Color.DarkGray,
                labelFont = useFont,
                label = "Create error in Console",
                labelColor = Color.Red,
                rect = new Rectangle(180, 280, 300, 50),
                focused = true
            }; errorConsole.LoadContent();

            fatalConsole = new Button
            {
                buttonLeft = CbuttonLeft,
                buttonRight = CbuttonRight,
                buttonMiddle = CbuttonMiddle,
                buttonColorDefault = Color.White,
                buttonColorHover = Color.Gray,
                buttonColorPressed = Color.DarkGray,
                labelFont = useFont,
                label = "Create fatal in Console and throw exception",
                labelColor = Color.DarkRed,
                rect = new Rectangle(180, 380, 300, 50),
                focused = true
            }; fatalConsole.LoadContent();

            wipeConsole = new Button
            {
                buttonLeft = CbuttonLeft,
                buttonRight = CbuttonRight,
                buttonMiddle = CbuttonMiddle,
                buttonColorDefault = Color.White,
                buttonColorHover = Color.Gray,
                buttonColorPressed = Color.DarkGray,
                labelFont = useFont,
                label = "wipe all messages in console",
                labelColor = Color.Yellow,
                rect = new Rectangle(500, 80, 300, 50),
                focused = true
            }; wipeConsole.LoadContent();

            writeConsole = new Button
            {
                buttonLeft = CbuttonLeft,
                buttonRight = CbuttonRight,
                buttonMiddle = CbuttonMiddle,
                buttonColorDefault = Color.White,
                buttonColorHover = Color.Gray,
                buttonColorPressed = Color.DarkGray,
                labelFont = useFont,
                label = "Write console to documents folder",
                labelColor = Color.White,
                rect = new Rectangle(180, 480, 300, 50),
                focused = true
            }; commentConsole.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            commentConsole.Update();
            warningConsole.Update();
            errorConsole.Update();
            fatalConsole.Update();
            wipeConsole.Update();
            writeConsole.Update();

            if (commentConsole.pressed)
            {
                dbconsole.write("this is a comment", urgency.comment);
                commentConsole.pressed = false;
            }

            if (warningConsole.pressed)
            {
                dbconsole.write("warning! warning!", urgency.warning);
                warningConsole.pressed = false;
            }

            if (errorConsole.pressed)
            {
                dbconsole.write("oh no", urgency.error);
                errorConsole.pressed = false;
            }

            if (fatalConsole.pressed)
            {
                dbconsole.write("something fatal happened", urgency.fatal);
                fatalConsole.pressed = false;
            }

            if (wipeConsole.pressed)
            {
                dbconsole.wipe();
                wipeConsole.pressed = false;
            }

            if (writeConsole.pressed)
            {
                dbconsole.ToFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ShFramework console.txt");
                writeConsole.pressed = false;
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            commentConsole.Draw(spritebatch);
            warningConsole.Draw(spritebatch);
            errorConsole.Draw(spritebatch);
            fatalConsole.Draw(spritebatch);
            wipeConsole.Draw(spritebatch);
            writeConsole.Draw(spritebatch);

            dbconsole.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
