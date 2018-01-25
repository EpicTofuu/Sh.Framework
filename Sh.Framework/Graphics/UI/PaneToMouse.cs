using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;

namespace Sh.Framework.Graphics.UI
{
    /// <summary>
    /// creates a pane that follows the mouse position whilst staying fully visible on screen
    /// </summary>
    public class PaneToMouse : GenericObject
    {
        Game game;
        Pane pane;
        MouseState mState;

        public string pLeft;
        public string pMid;
        public string pRight;
        public Color color = Color.White;
        public float alpha = 1;
        public Rectangle rectangle;     //x and y are useless, just set to 0
        public Vector2 offset = new Vector2 (5, 5);

        public enum cutType
        {
            block,
            jump
        }

        public cutType cornerCutting = cutType.block;

        public PaneToMouse(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            pane = new Pane()
            {
                buttonLeft = game.Content.Load<Texture2D>(pLeft),
                buttonMiddle = game.Content.Load<Texture2D>(pMid),
                buttonRight = game.Content.Load<Texture2D>(pRight),
                color = this.color,
                rect = rectangle,
                alpha = this.alpha
            };

            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            mState = Mouse.GetState();

            int mX, mY;

            if (mState.Position.X + pane.rect.Width + offset.X + 1 > 1366)     //get screen width
            {
                if (cornerCutting == cutType.block)
                    mX = (int)1366 - pane.rect.Width;
                else
                    mX = mState.Position.X - (int)offset.X - pane.rect.Width;
            }
            else
            {
                mX = mState.Position.X + (int)offset.X;
            }

            if (mState.Position.Y + pane.rect.Height + offset.Y + 1 > 768)     //get screen height
            {
                if (cornerCutting == cutType.block)
                    mY = (int)768 - pane.rect.Height;
                else
                    mY = mState.Position.Y - (int)offset.Y - pane.rect.Height;
            }
            else
            {
                mY = mState.Position.Y + (int)offset.Y;
            }

            pane.rect = new Rectangle(mX, mY, rectangle.Width, rectangle.Height);
            rectangle = pane.rect;

            pane.Draw(batch);

            base.Draw(batch);
        }
    }
}
