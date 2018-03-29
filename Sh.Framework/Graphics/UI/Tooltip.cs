using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;

namespace Sh.Framework.Graphics.UI
{
    /// <summary>
    /// creates a PaneToMouse object with centered text
    /// </summary>
    public class Tooltip : GenericObject
    {
        Game game;

        public string pLeft;
        public string pMid;
        public string pRight;
        public Color paneColor = Color.White;
        public Color labelColor = Color.Black;
        public Vector2 offset = new Vector2(5, 10);
        public Vector2 padding = new Vector2(30, 50);
        public string label = "this is a tooltip";
        public string font;
        public float alpha = 1f; 

        PaneToMouse ptm;
        SpriteFont Font;

        public PaneToMouse.cutType CornerCutting;

        public Tooltip(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            Font = game.Content.Load<SpriteFont>(font);

            ptm = new PaneToMouse(game)
            {
                pLeft = this.pLeft,
                pMid = this.pMid,
                pRight = this.pRight,
                color = paneColor,
                rectangle = new Rectangle(0, 0, (int)Font.MeasureString(label).X + (int)padding.X, (int)Font.MeasureString(label).Y + (int)padding.Y),
                offset = this.offset,
                alpha = this.alpha,
                cornerCutting = CornerCutting
            };
            ptm.LoadContent();

            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            ptm.Draw(batch);
            
            batch.DrawString(Font, label, new Vector2(
                ptm.rectangle.X + ptm.rectangle.Width / 2 - Font.MeasureString(label).X / 2,
                ptm.rectangle.Y + ptm.rectangle.Height / 2 - Font.MeasureString(label).Y / 2
                ), labelColor * alpha);
            base.Draw(batch);
        }
    }
}
