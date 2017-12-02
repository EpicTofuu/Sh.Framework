using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics.UI;
using Sh.Framework.Screens;
using Tests.Head;

namespace Tests.testcases.SplashScreenTests
{
    public class SplashScreenTestCase : testcase
    {
        private Button image;
        private Button video;

        private Game game;

        public SplashScreenTestCase(Game othergame) : base(othergame)
        {
            game = othergame;
            testcasename = "Splash screens";
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("pixel");
            font = game.Content.Load<SpriteFont>("font");

            Texture2D left = game.Content.Load<Texture2D>("button/left");
            Texture2D right = game.Content.Load<Texture2D>("button/right");
            Texture2D middle = game.Content.Load<Texture2D>("button/middle");

            image = new Button
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                labelFont = font,
                label = "image",
                buttonColorDefault = Color.White,
                buttonColorHover = Color.LightGray,
                buttonColorPressed = Color.Gray,
                labelColor = Color.Black,
                rect = new Rectangle(180, 100, 200, 50),
                focused = true
            };

            video = new Button
            {
                buttonLeft = left,
                buttonRight = right,
                buttonMiddle = middle,
                labelFont = font,
                label = "video",
                buttonColorDefault = Color.White,
                buttonColorHover = Color.LightGray,
                buttonColorPressed = Color.Gray,
                labelColor = Color.Black,
                rect = new Rectangle(500, 100, 200, 50),
                focused = true
            };

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            image.Update();
            video.Update();

            if (image.pressed)
            {
                ScreenManager.Instance.currentscreen = new imageSplash(game);
                ScreenManager.Instance.reloadscreen();
            }

            if (video.pressed)
            {
                ScreenManager.Instance.currentscreen = new videoSplash(game);
                ScreenManager.Instance.reloadscreen();
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            image.Draw(spritebatch);
            video.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
