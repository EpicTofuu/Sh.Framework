using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Drawing
{
    public static class draw
    {
        public static SpriteBatch s;

        public static Color color;

        /// <summary>
        /// Draws a polygon with 4 sides
        /// </summary>
        /// <param name="rect"></param>
        public static void Rectangle(Rectangle rect)
        {
            s.Draw(Pixel.generate(), rect, color);
        }
    }
}
