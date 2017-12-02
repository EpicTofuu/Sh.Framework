using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Graphics
{
    public static class utils
    {
        //TODO
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

        /*
        public static Vector2 Anchor(anchor a)
        {
            /*
            switch (a)
            {
                case anchor.TopLeft:
                    return Vector2.Zero;
                    break;

                case anchor.TopCentre:
                    return new Vector2(getScreenWidth() / 2, 0);
                    break;

                case anchor.TopRight:
                    return new Vector2(getScreenWidth(), 0);
                    break;

                case anchor.CentreLeft:
                    return new Vector2(0, getScreenHeight() / 2);
                    break;

                case anchor.Centre:
                    return new Vector2(getScreenWidth() / 2, getScreenHeight() / 2);
                    break;

                case anchor.CentreRight:
                    return new Vector2(getScreenWidth(), getScreenHeight() / 2);
                    break;

                case anchor.BottomLeft:
                    return new Vector2 (getScreenWidth(), )
            }
        }*/

        #region screensize

        /// <summary>
        /// Gets Width of window
        /// </summary>
        /// <returns>Current screen width</returns>
        public static float getScreenWidth()
        {
            return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        }

        /// <summary>
        /// Gets Height of window
        /// </summary>
        /// <returns>Current screen height</returns>
        public static float getScreenHeight()
        {
            return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        #endregion
    }
}