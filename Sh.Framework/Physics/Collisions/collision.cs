using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Sh.Framework.Physics.Collisions
{
    public class collision
    {
        /// <summary>
        /// Detect collisions between rectangles and gameobjects
        /// </summary>
        /// <param name="pos">The base rectangle, does not need to be part of an object</param>
        /// <param name="obj">The object being compared, needs to be an object</param>
        /// <returns></returns>
        public static bool withGameObject(Rectangle pos, GameObject obj)
        {
            if (
                pos.Right >= obj.hitbox.Left && pos.Left <= obj.hitbox.Right &&
                pos.Bottom >= obj.hitbox.Top && pos.Top <= obj.hitbox.Bottom ||
                pos.Bottom >= obj.hitbox.Top && pos.Top <= obj.hitbox.Bottom &&
                pos.Right >= obj.hitbox.Left && pos.Left <= obj.hitbox.Right
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
