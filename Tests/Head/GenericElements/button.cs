using Sh.Framework.Graphics.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tests.Head.GenericElements
{
    public class button : Button
    {
        private Game game;

        public button(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            buttonLeft = game.Content.Load<Texture2D>("button/left");
            buttonMiddle = game.Content.Load<Texture2D>("button/middle");
            buttonRight = game.Content.Load<Texture2D>("button/right");
            labelFont = game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }
    }
}
