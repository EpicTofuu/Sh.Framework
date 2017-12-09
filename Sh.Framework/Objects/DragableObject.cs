using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Physics.Collisions;

namespace Sh.Framework.Objects
{
    /// <summary>
    /// Create objects that can be clicked and dragged to a certian point
    /// useful for UI or gameplay
    /// </summary>
    public class DragableObject : GenericObject
    {
        public enum AxisLockOn
        {
            none,
            X,
            Y
        }

        //to assign
        public string texturename;
        public Color color;
        public Vector2 position;

        public bool hovering;
        public bool dragging;

        public AxisLockOn lockOn;

        protected Game game0;
        public Rectangle hitbox;
        public Texture2D texture;

        public DragableObject(Game othergame)
        {
            game0 = othergame;
        }

        public override void LoadContent()
        {
            if (texturename != "")
            {
                texture = game0.Content.Load<Texture2D>(texturename);
            }
        }

        public override void Update()
        {
            MouseState mouse = Mouse.GetState();

            hitbox = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);

            if (MouseTouching.Rect(mouse, hitbox))
            {
                hovering = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    switch (lockOn)
                    {
                        case AxisLockOn.X:
                            position.X = mouse.Position.X - texture.Width / 2;
                            break;

                        case AxisLockOn.Y:
                            position.Y = mouse.Position.Y - texture.Height / 2;
                            break;

                        case AxisLockOn.none:
                            position = new Vector2(mouse.Position.X - texture.Width / 2, mouse.Position.Y - texture.Height / 2);
                            break;

                        default:
                            position = new Vector2(mouse.Position.X - texture.Width / 2, mouse.Position.Y - texture.Height / 2);
                            break;

                     //nice codebase ;)
                    }
                    dragging = true;
                }
            }
            else
            {
                hovering = false;
                dragging = false;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (texture != null)
            {
                batch.Draw(texture, position, color);
            }
        }
    }
}
