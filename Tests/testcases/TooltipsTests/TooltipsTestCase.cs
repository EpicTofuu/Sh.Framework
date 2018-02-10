using Microsoft.Xna.Framework;
using Tests.Head;
using Sh.Framework.Graphics.UI;
using Sh.Framework.Physics.Collisions;
using Microsoft.Xna.Framework.Graphics;

namespace Tests.testcases.TooltipsTests
{
    public class TooltipsTestCase : testcase
    {
        private Game game;

        Tooltip tt;

        public TooltipsTestCase(Game game) : base (game)
        {
            this.game = game;
            testcasename = "tooltips";
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            tt = new Tooltip(game)
            {
                pLeft = "button/left",
                pMid = "button/middle",
                pRight = "button/right",
                font = "font",
                label = "this is a tooltip \nit supports line breaks" +
                "\naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
            };tt.LoadContent();

            base.LoadContent();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(pixel, new Rectangle((int)Sh.Framework.Graphics.Window.getWidth() - 1000, 0, 1000, (int)Sh.Framework.Graphics.Window.getHeight()), Color.Black * 0.75f);

            if (MouseTouching.RectWithIn (new Rectangle ((int)Sh.Framework.Graphics.Window.getWidth() - 1000, 0, 1000, (int)Sh.Framework.Graphics.Window.getHeight())))
                tt.Draw(spritebatch);

            base.Draw(spritebatch);
        }
    }
}
