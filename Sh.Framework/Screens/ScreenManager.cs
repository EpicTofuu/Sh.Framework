using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sh.Framework.Screens
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager content { private set; get; }
        public Game game1;

        public Screen currentscreen;

        private ScreenManager()
        {
            Dimensions = new Vector2(1366, 768);
        }

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();

                return instance;
            }
        }

        public void reloadscreen()
        {
            //yeah, I'm just going to wait for people to get OutOfMemory exceptions
            currentscreen.UnloadContent();

            currentscreen.LoadContent();
        }

        public void Initialize()
        {
        }
        public void LoadContent(ContentManager Content)
        {
            this.content = new ContentManager(Content.ServiceProvider, "Content");
            currentscreen.LoadContent();
        }
        public void UnloadContent()
        {
            currentscreen.UnloadContent();
        }
        public void Update(GameTime gametime)
        {
            currentscreen.Update(gametime);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            currentscreen.Draw(spritebatch);
        }
    }
}
