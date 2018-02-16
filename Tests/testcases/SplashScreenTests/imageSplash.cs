using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Screens;

namespace Tests.testcases.SplashScreenTests
{
    public class imageSplash : SplashScreenImage
    {
        private Game game;

        public imageSplash(Game othergame)
        {
            exitkey = Keys.Space;
            game = othergame;
        }

        public override void LoadContent()
        {
            splash = game.Content.Load<Texture2D>("splashscreens/splash");
            splashrect = new Rectangle(0, 0, (int)Sh.Framework.Graphics.ShWindow.getWidth(), (int)Sh.Framework.Graphics.ShWindow.getHeight());
            splashColor = Color.White;
            time = 3 * 60;
            base.LoadContent();
        }

        public override void OnFinish()
        {
            ScreenManager.Instance.currentscreen = new SplashScreenTestCase(game);
            ScreenManager.Instance.reloadscreen();
            base.OnFinish();
        }
    }
}
