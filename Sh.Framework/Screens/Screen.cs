using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sh.Framework.Screens
{
    /// <summary>
    /// inheritable type for an Sh.Framework screen
    /// </summary>
    public class Screen : IDisposable
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

        public void Dispose()
        {
            UnloadContent();
            GC.SuppressFinalize(this);
        }
    }
}
