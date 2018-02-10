using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Screens.experimental
{
    public class ScreenManager
    {
        public ContentManager content { private set; get; }

        GameScreen currentscreen;

        public void LoadContent(ContentManager Content)
        {
            this.content = new ContentManager(Content.ServiceProvider, "Content");
            currentscreen.LoadContent();
        }
        public void UnloadContent()
        {
            currentscreen.UnloadContent();
        }
        public void Update()
        {
            currentscreen.Update();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            currentscreen.Draw(spritebatch);
        }
    }
}
