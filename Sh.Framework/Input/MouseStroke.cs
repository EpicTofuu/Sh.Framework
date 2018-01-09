using Microsoft.Xna.Framework.Input;

namespace Sh.Framework.Input
{
    public class MouseStroke
    {
        /// <summary>
        /// Detect if the left button was pressed
        /// </summary>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        public static bool LeftButtonDown(MouseState oldState, MouseState newState)
        {
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Detect if the right button was pressed
        /// </summary>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        public static bool RightButtonPressed(MouseState oldState, MouseState newState)
        {
            if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Detect if the left button was pressed
        /// </summary>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        public static bool LeftButtonReleased(MouseState oldState, MouseState newState)
        {
            if (newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Detect if the right button was released
        /// </summary>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        public static bool RightButtonReleased(MouseState oldState, MouseState newState)
        {
            if (newState.RightButton == ButtonState.Released && oldState.RightButton == ButtonState.Pressed)
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
