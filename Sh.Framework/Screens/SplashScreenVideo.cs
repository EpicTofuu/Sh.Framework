using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sh.Framework.Screens;

namespace Sh.Framework.Screens
{
    public class SplashScreenVideo : Screen
    {
        public Video splash;
        public VideoPlayer player;
        public Rectangle splashrect;
        public Color splashColor;
        public Keys exitkey;

        public SplashScreenVideo()
        {

        }

        public override void LoadContent()
        {
            exitkey = Keys.Space;

            /*
            I am fully aware that you can't play the video twice in the same run however
            you need to keep in mind splash screens only play once throughout the whole game anyway
            though I could work on a patch, this is something that doesn't really need fixing, not now anyway
            */
                player.Play(splash);
        }

        public override void Update(GameTime gametime)
        {

            if (player.State == MediaState.Stopped || Keyboard.GetState().IsKeyDown (exitkey))
            {
                player.Stop();
                OnFinish();
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D videoTexture = null;

            if (player.State != MediaState.Stopped)
                videoTexture = player.GetTexture();

            if (videoTexture != null)
            {
                spriteBatch.Draw(videoTexture, splashrect, splashColor);
            }

            base.Draw(spriteBatch);
        }

        public virtual void OnFinish()
        {

        }
    }
}
