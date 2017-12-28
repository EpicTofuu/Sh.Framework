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
        /// <returns>true if the mouse is touching specified rectangle</returns>
        [System.Obsolete("still completely functional but to not waste any time, use RectWithIn")]
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

        /// <summary>
        /// Finds if the mouse is touching a specified rectangle 
        /// removes the need for adding a mousestate
        /// </summary>
        /// <param name="rect">specified rectangle</param>
        /// <returns>rue if the mouse is touching specified rectangle</returns>
        public static bool RectWithIn(Rectangle rect)
        {
            MouseState mouse = Mouse.GetState();

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
