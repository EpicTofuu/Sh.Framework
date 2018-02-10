using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Sh.Framework.Screens;

namespace Tests.testcases.SplashScreenTests
{
    public class videoSplash : SplashScreenVideo
    {
        private Game game;

        public videoSplash(Game othergame)
        {
            game = othergame;
        }

        public override void LoadContent()
        {
            splash = game.Content.Load<Video>("splashscreens/splashvideo");
            player = new VideoPlayer();
            splashrect = new Rectangle(0, 0, (int)Sh.Framework.Graphics.Window.getWidth(), (int)Sh.Framework.Graphics.Window.getHeight());
            splashColor = Color.White;
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
