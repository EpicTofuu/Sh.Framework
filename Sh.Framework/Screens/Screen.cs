using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Screens
{
    /// <summary>
    /// inheritable type for an Sh.Framework screen
    /// </summary>
    public class Screen
    {
        protected ContentManager content;

        public Screen()
        {
            
        }

        public virtual void Initialize()
        {

        }
        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.content.ServiceProvider, "content");
        }
        public virtual void UnloadContent()
        {

        }
        public virtual void Update(GameTime gametime)
        {
        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
        }
    }
}
