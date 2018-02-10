using Sh.Framework.Screens;
using Sh.Framework.Graphics;

namespace Tests.testcases.SpookyStuff
{
    public class gamescreen : GameScreen
    {
        Sprite sprite;

        public gamescreen()
        {
            stationary.Add(sprite);
        }

        public override void LoadContent()
        {
            base.LoadContent();

            sprite.texturename = "texture0";
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
