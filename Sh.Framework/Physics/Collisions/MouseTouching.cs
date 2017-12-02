using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sh.Framework.Physics.Collisions
{
    public class MouseTouching
    {
        /// <summary>
        /// Finds if the mouse is touching a specified rectangle
        /// </summary>
        /// <param name="mouse">MouseState to read from</param>
        /// <param name="rect">Rectangle to test</param>
        /// <returns></returns>
        public static bool Rect(MouseState mouse, Rectangle rect)
        {
            if (
                mouse.X >= rect.Left &&
                mouse.X <= rect.Right &&
                mouse.Y >= rect.Top &&
                mouse.Y <= rect.Bottom
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
