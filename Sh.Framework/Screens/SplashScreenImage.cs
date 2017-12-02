using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sh.Framework.Screens
{
    public class SplashScreenImage : Screen
    {
        public Texture2D splash;
        public Rectangle splashrect;
        public Color splashColor;
        public float time;
        public Keys exitkey;

        int i = 0;

        public SplashScreenImage()
        {
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(splash, splashrect, splashColor);
            if (i >= time)
            {
                OnFinish();
            }
            else
            {
                i++;
            }

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(exitkey) || ks.IsKeyDown (Keys.Escape))
                OnFinish();

            base.Draw(spritebatch);
        }

        public virtual void OnFinish()
        {

        }
    }
}
