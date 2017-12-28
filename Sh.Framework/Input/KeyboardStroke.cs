using Microsoft.Xna.Framework.Input;

namespace Sh.Framework.Input
{
    public static class KeyboardStroke
    {
        /// <summary>
        /// Detect if the key has been pressed
        /// </summary>
        /// <param name="oldState">A keyboardstate updated after all other input updates</param>
        /// <param name="newState">A keyboardstate that is updated before all other input updates</param>
        /// <param name="k">Specified key to check</param>
        /// <returns>true if the key is pressed once</returns>
        public static bool KeyDown(KeyboardState oldState, KeyboardState newState, Keys k)
        {
            if (newState.IsKeyDown(k) && oldState.IsKeyUp(k))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Detect if a key has been released
        /// </summary>
        /// <param name="oldState">A keyboardstate updated after all other input updates</param>
        /// <param name="newState">A keyboardstate that is updated before all other input updates</param>
        /// <param name="k">Specified key to check</param>
        /// <returns>true if the key is released once</returns>
        public static bool KeyUp(KeyboardState oldState, KeyboardState newState, Keys k)
        {
            if (newState.IsKeyUp(k) && oldState.IsKeyDown(k))
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
