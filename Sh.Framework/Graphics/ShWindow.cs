using Microsoft.Xna.Framework.Graphics;
using OpenTK;

namespace Sh.Framework.Graphics
{
    public static class ShWindow
    {
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
            return Setup.GD.Viewport.Bounds.Width;
        }

        /// <summary>
        /// Get Height of active window
        /// </summary>
        /// <returns></returns>
        public static float getHeight()
        {
            return Setup.GD.Viewport.Bounds.Height;
        }

        /// <summary>
        /// Get Width of active monitor
        /// </summary>
        /// <returns></returns>
        public static float getMonitorWidth()
        {
            try
            {
                return DisplayDevice.Default.Width;
            }
            catch
            {
                throw new System.Exception("method could not be called, check if you have OpenTK.dll referenced");
            }
        }

        /// <summary>
        /// Get Height of active monitor
        /// </summary>
        /// <returns></returns>
        public static float getMonitorHeight()
        {
            try
            {
                return DisplayDevice.Default.Height;
            }
            catch
            {
                throw new System.Exception("method could not be called, check if you have OpenTK.dll referenced");
            }
        }
    }
}
