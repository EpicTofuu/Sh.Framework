//TODO

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;

namespace Sh.Framework.Graphics.UI
{
    /// <summary>
    /// a pane that eases into the screen's view with some message
    /// </summary>
    public class Popup
    {
        public Game game;

        public string paneLeftDest;
        public string paneMiddleDest;
        public string paneRightDest;

        public int enterspeed = 5;

        public Rectangle rect;
        public Color color = Color.Black;

        public string message;
        public string fontDest;
        public Color messageColor = Color.White;

        public Popup(Game Game)
        {
            game = Game;
            rect.Y = -rect.Width;
        }

        Texture2D paneLeft;
        Texture2D paneMiddle;
        Texture2D paneRight;
        SpriteFont font;

        public void LoadContent()
        {
            paneLeft = game.Content.Load<Texture2D>(paneLeftDest);
            paneRight = game.Content.Load<Texture2D>(paneRightDest);
            paneMiddle = game.Content.Load<Texture2D>(paneMiddleDest);
            font = game.Content.Load<SpriteFont>(fontDest);
        }

        /// <summary>
        /// Toggles popup
        /// </summary>
        /// <param name="autoExit">should the popup exit automatically?</param>
        public void Enter(bool autoExit)
        {
            //primitive easing xd
            if (rect.Y < rect.Width)
            {
                rect.Y -= enterspeed;
            }

            if (autoExit)
                Exit();
        }

        /// <summary>
        /// Hides popup
        /// </summary>
        public void Exit()
        {
            if (rect.Y > 0)
            {
                rect.Y += enterspeed;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            new Pane
            {
                buttonLeft = paneLeft,
                buttonRight = paneRight,
                buttonMiddle = paneMiddle,
                color = this.color,
                rect = this.rect
            }.Draw(batch);

            batch.DrawString(font, message, new Vector2 (rect.X, rect.Y), color);
        }
    }
}