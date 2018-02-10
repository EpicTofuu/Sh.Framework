using Microsoft.Xna.Framework.Graphics;
using OpenTK;

namespace Sh.Framework.Graphics
{
    public static class Window
    {
        public static GraphicsDevice GD;

        public enum anchor
        {
            TopLeft,
            TopRight,
            TopCentre,
            CentreLeft,
            CentreRight,
            Centre,
            BottomLeft,
            BottomRight,
            BottomCentre
        }
        
        /// <summary>
        /// Get width of active window
        /// </summary>
        /// <returns></returns>
        public static float getWidth()
        {
            return GD.Viewport.Bounds.Width;
        }

        /// <summary>
        /// Get Height of active window
        /// </summary>
        /// <returns></returns>
        public static float getHeight()
        {
            return GD.Viewport.Bounds.Height;
        }

        /// <summary>
        /// Get Width of active monitor
        /// </summary>
        /// <returns></returns>
        public static float getMonitorWidth()
        {
            return DisplayDevice.Default.Width;
        }

        /// <summary>
        /// Get Height of active monitor
        /// </summary>
        /// <returns></returns>
        public static float getMonitorHeight()
        {
            return DisplayDevice.Default.Height;
        }
    }
}
