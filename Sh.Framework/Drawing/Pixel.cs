using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;

namespace Sh.Framework.Drawing
{
    public static class Pixel
    {
        /// <summary>
        /// Procedurally generates a 1 x 1 pixel
        /// </summary>
        /// <returns>a pixel</returns>
        public static Texture2D generate()
        {
            return new Texture2D(Setup.GD, 1, 1);
        }
    }
}
