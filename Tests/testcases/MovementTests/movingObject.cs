using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;

namespace Tests.MovementTests
{
    public class movingObject : PlayerObject
    {
        private SpriteFont font;
        private Game game;

        public movingObject(Game othergame) : base(othergame)
        {
            texturename = "texture0";
            color = Color.White;
            position = new Vector2 (180, 100);
            solid = true;
            moveUp = Keys.W;
            moveDown = Keys.S;
            moveLeft = Keys.A;
            moveRight = Keys.D;
            speed = 10;
            game = othergame;

            solids.Add(MovementTestCase.wall);
        }

        public override void LoadContent()
        {
            font = game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(font, "hsp " + Dhsp.ToString(), new Vector2(1200, 50), Color.White);
            batch.DrawString(font, "vsp " + Dvsp.ToString(), new Vector2(1200, 80), Color.White);
            batch.DrawString(font, "Hcoll " + Hcoll.ToString(), new Vector2(1200, 110), Color.Yellow);
            batch.DrawString(font, "Vcoll " + Vcoll.ToString(), new Vector2(1200, 140), Color.Yellow);
            base.Draw(batch);
        }
    }
}
