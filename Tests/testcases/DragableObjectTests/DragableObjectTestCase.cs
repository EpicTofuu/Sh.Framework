using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tests.Head;
using Sh.Framework.Objects.Instances;

namespace Tests.testcases.DragableObjectTests
{
    public class DragableObjectTestCase : testcase
    {
        private Game game;

        private Dragging dragobject;

        private Dragging xdrag;
        private Dragging ydrag;

        public DragableObjectTestCase(Game othergame) : base(othergame)
        {
            game = othergame;
            testcasename = "Dragable Objects";
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            font = game.Content.Load<SpriteFont>("font");

            dragobject = new Dragging(game);
            dragobject.LoadContent();

            xdrag = new Dragging(game)
            {
                position = new Vector2(400, 300),
                texturename = "texture2",
                color = Color.White,
                lockOn = Sh.Framework.Objects.DragableObject.AxisLockOn.X
            }; xdrag.LoadContent();


            ydrag = new Dragging(game)
            {
                position = new Vector2(500, 300),
                texturename = "texture2",
                color = Color.White,
                lockOn = Sh.Framework.Objects.DragableObject.AxisLockOn.Y
            }; ydrag.LoadContent();

            base.LoadContent();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            dragobject.Update();
            dragobject.Draw(spritebatch);

            xdrag.Update();
            xdrag.Draw(spritebatch);

            ydrag.Update();
            ydrag.Draw(spritebatch);

            spritebatch.DrawString(font, "being hovered over: " + dragobject.hovering.ToString(), new Vector2(1000, 50), Color.White);
            spritebatch.DrawString(font, "being dragged: " + dragobject.dragging.ToString(), new Vector2(1000, 80), Color.White);

            base.Draw(spritebatch);
        }
    }
}
