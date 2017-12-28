using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Physics.Collisions;

namespace Sh.Framework.Graphics.UI.Scrolling
{
    public class ScrollManager
    {
        public Vector2 offset;
        public Rectangle container;

        int mouseOffset;

        MouseState mouse;

        public ScrollManager()
        {
            offset = Vector2.Zero;
        }

        public void Update()
        {
            if (MouseTouching.RectWithIn(container))
            {
                mouse = Mouse.GetState();
                offset.Y = mouse.ScrollWheelValue - mouseOffset;

                //I'm very good at writing code
                if (offset.Y > 0)
                {
                    offset.Y = 0;
                    mouseOffset = mouse.ScrollWheelValue;
                }
            }
            else
            {
                mouseOffset = mouse.ScrollWheelValue;
            }
        }
    }
}
