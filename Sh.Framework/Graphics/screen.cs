using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Graphics
{
    public static class screen
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

        //TODO

        public static float getWidth()
        {
            return 1366.0f;
        }

        public static float getHeight()
        {
            return 768.0f;
        }

        public static Vector2 dim;
    }
}
