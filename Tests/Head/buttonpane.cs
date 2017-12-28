using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Screens;
using Sh.Framework.Objects;
using Sh.Framework.Physics.Collisions;
using Sh.Framework.Graphics.UI.Scrolling;

namespace Tests.Head
{
    public class buttonpane : GenericObject
    {
        Texture2D pixel;

        private Rectangle buttonsize;
        private SpriteFont font;

        private Game game;

        List<testcase> testcases = new List<testcase>();

        ScrollManager scrollmanager;

        public buttonpane(Texture2D otherpixel, SpriteFont otherfont, Game othergame)
        {
            scrollmanager = new ScrollManager();
            scrollmanager.container = new Rectangle(0, 0, 160, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);

            font = otherfont;
            pixel = otherpixel;
            game = othergame;

            testcases.Add(new testcases.about.aboutTestCase(game));
            testcases.Add(new testcases.ButtonTests.ButtonTestCase(game));
            testcases.Add(new testcases.CheckboxTests.CheckboxTestCase(game));
            testcases.Add(new testcases.ConsoleTests.ConsoleTestCase(game));
            testcases.Add(new testcases.DragableObjectTests.DragableObjectTestCase(game));
            testcases.Add(new testcases.GravPlayerObjectTests.GravPlayerObjectTestCase(game));
            testcases.Add(new testcases.IOTests.IOTestCase(game));
            testcases.Add(new testcases.KeyStrokeTests.KeyStrokeTestCase(game));
            testcases.Add(new MovementTests.MovementTestCase(game));
            testcases.Add(new testcases.RenderTextTests.RenderTextTestCase(game));
            testcases.Add(new testcases.SplashScreenTests.SplashScreenTestCase(game));
            testcases.Add(new testcases.TooltipsTests.TooltipsTestCase(game));
            testcases.Add(new testcases.TextboxTests.TextboxTestCase(game));
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(pixel, new Rectangle(0, 0, 160, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), Color.DarkGray);

            int i = 0;

            foreach (testcase t in testcases)
            {
                Vector2 position = new Vector2(4, 55 * i + 45 + scrollmanager.offset.Y);
                buttonsize = new Rectangle((int)position.X, (int)position.Y, 150, 50);
                batch.Draw(pixel, buttonsize, Color.DarkSlateGray);

                batch.DrawString(font, t.testcasename, new Vector2(buttonsize.X, buttonsize.Y), Color.White);

                if (MouseTouching.RectWithIn(buttonsize) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    ScreenManager.Instance.currentscreen = t;
                    ScreenManager.Instance.reloadscreen();
                }

                i++;
            }

            scrollmanager.Update();

            base.Draw(batch);
        }
    }
}
