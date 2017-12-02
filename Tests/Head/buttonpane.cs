using Sh.Framework.Screens;
using Sh.Framework.Objects;
using Sh.Framework.Physics.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tests.testcases.about;

namespace Tests.Head
{
    public class buttonpane : GenericObject
    {
        Texture2D pixel;

        private Rectangle buttonsize;
        private SpriteFont font;

        private Game game;

        public buttonpane(Texture2D otherpixel, SpriteFont otherfont, Game othergame)
        {
            font = otherfont;
            pixel = otherpixel;
            game = othergame;
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            MouseState mouse = Mouse.GetState();
            batch.Draw(pixel, new Rectangle(0, 0, 160, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), Color.DarkGray);

            for (int i = 0; i < 9; i++)                                 //should be equal to count of all testcases
            {
                buttonsize = new Rectangle(4, 55 * i + 45, 150, 50);
                batch.Draw(pixel, buttonsize, Color.DarkSlateGray);

                //efficiency!
                switch (i)                                              //for each of the buttons, run the testcase
                {
                    //about
                    case 0:
                        batch.DrawString(font, "about", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new aboutTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //movement
                    case 1:
                        batch.DrawString(font, "movement", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new MovementTests.MovementTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //splash screens
                    case 2:
                        batch.DrawString(font, "Splash screen", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new testcases.SplashScreenTests.SplashScreenTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //buttons
                    case 3:
                        batch.DrawString(font, "buttons", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new testcases.ButtonTests.ButtonTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //checkboxes
                    case 4:
                        batch.DrawString(font, "checkboxes", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new testcases.CheckboxTests.CheckboxTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //GravPlayerObject
                    case 5:
                        batch.DrawString(font, "GravPlayerObject", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new testcases.GravPlayerObjectTests.GravPlayerObjectTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //DragableObject
                    case 6:
                        batch.DrawString(font, "DragableObject", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new testcases.DragableObjectTests.DragableObjectTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //DebugConsole
                    case 7:
                        batch.DrawString(font, "DebugConsole", new Vector2(buttonsize.X, buttonsize.Y), Color.White);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new testcases.ConsoleTests.ConsoleTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;

                    //RenderText
                    case 8:
                        batch.DrawString(font, "RenderText", new Vector2(buttonsize.X, buttonsize.Y), Color.Yellow);
                        if (MouseTouching.Rect(mouse, buttonsize) && mouse.LeftButton == ButtonState.Pressed)
                        {
                            ScreenManager.Instance.currentscreen = new testcases.RenderTextTests.RenderTextTestCase(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                        break;
                }
            }

            base.Draw(batch);
        }
    }
}
