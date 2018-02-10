using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Objects.Interfaces
{
    /// <summary>
    /// Stationary objects dont move unless told to
    /// </summary>
    public interface IStationary
    {
        /// <summary>
        /// Load all assets
        /// </summary>
        void LoadContent();

        /// <summary>
        /// Unlaods all assets
        /// </summary>
        void UnloadContent();

        /// <summary>
        /// Also called once per frame
        /// renders graphics on the screen
        /// </summary>
        /// <param name="batch"></param>
        void Draw(SpriteBatch batch);
    }
}
