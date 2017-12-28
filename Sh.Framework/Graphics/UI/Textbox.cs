using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;
using Sh.Framework.Input;
using Sh.Framework.Physics.Collisions;

namespace Sh.Framework.Graphics.UI
{
    public class Textbox : GenericObject
    {
        MouseState m_oldState;
        MouseState m_newState;

        KeyboardState k_oldState;
        KeyboardState k_newState;

        public enum CharacterRange
        {
            ASCII,
            UTF8,
            FilenameAcceptable
        }
        public Pane pane;
        public string dummyText;
        public float paddingX = 40;
        public CharacterRange characterRange;
        public SpriteFont font;
        public Color fillColour = Color.White;
        public Color focusColour = Color.Gray;
        public Color dummyTextColour = Color.Black;
        public Color TextColour = Color.Black;
        public Keys returnKey = Keys.Enter;
        public Game game;
        public Texture2D IBeam;
        public Texture2D pixel;

        public string result;
        public string currentText;
        public bool focus;
        public bool submitted;

        private Color useColor;

        public Textbox()
        {
            focus = false;
            currentText = "";

            m_oldState = Mouse.GetState();
            k_oldState = Keyboard.GetState();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        int timer = 0;
        public override void Update()
        {
            k_newState = Keyboard.GetState();

            bool shift;

            if (focus)
            {
                //check for s hift
                if (k_newState.IsKeyDown(Keys.LeftShift) || k_newState.IsKeyDown(Keys.RightShift))
                    shift = true;
                else
                    shift = false;

                //get input
                foreach (Keys k in k_newState.GetPressedKeys())
                {
                    if (k_newState.IsKeyUp(Keys.Enter))   //list of banned keys
                    {
                        if (k_newState.IsKeyUp(Keys.Tab))
                        {
                            if (KeyboardStroke.KeyDown(k_oldState, k_newState, k))
                                currentText += utils.ConvertKeyToChar(k, shift);
                        }
                    }
                }

                //get backspace
                if (k_newState.IsKeyDown(Keys.Back) && currentText != "")
                {
                    if (k_oldState.IsKeyUp(Keys.Back))
                        currentText = currentText.TrimEnd(currentText[currentText.Length - 1]);

                    if (timer > 40)
                    {
                        currentText = currentText.TrimEnd(currentText[currentText.Length - 1]);
                    }
                    else timer++;
                }
                else
                {
                    timer = 0;
                }

                if (k_newState.IsKeyDown(Keys.Tab)) focus = false;

                //submit
                if (KeyboardStroke.KeyDown(k_oldState, k_newState, returnKey))
                {
                    submit();
                }
            }

            k_oldState = k_newState;


            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            pane.color = useColor;
            pane.Draw(batch);

            m_newState = Mouse.GetState();

            if (MouseTouching.RectWithIn(pane.rect))                        //if touching
            {
                game.IsMouseVisible = false;

                MouseState mouse = Mouse.GetState();
                batch.Draw(IBeam, new Vector2(mouse.X, mouse.Y), Color.White);
                useColor = focusColour;

                if (m_newState.LeftButton == ButtonState.Pressed && m_oldState.LeftButton == ButtonState.Released)
                {
                    focus = true;
                }
            }   
            else                                                            //if not touching
            {
                game.IsMouseVisible = true;
                useColor = fillColour;

                if (m_newState.LeftButton == ButtonState.Pressed && m_oldState.LeftButton == ButtonState.Released)
                {
                    submit();
                }
            }

            //managing dummyText
            if (currentText == "")
            {
                batch.DrawString(font, dummyText, new Vector2(pane.rect.X + paddingX, (pane.rect.Y + pane.rect.Height) - (pane.rect.Height / 2) - (font.MeasureString(dummyText).Y / 2)), dummyTextColour);
            }
            else
            {
                batch.DrawString(font, currentText, new Vector2(pane.rect.X + paddingX, (pane.rect.Y + pane.rect.Height) - (pane.rect.Height / 2) - (font.MeasureString(currentText).Y / 2)), TextColour);
            }

            //blinker
            //TODO use proportional values for width and height
            if (focus)
            {
                batch.Draw(pixel, new Rectangle((int)(pane.rect.X + paddingX + font.MeasureString(currentText).X), pane.rect.Y + 15, 1, pane.rect.Height - 30), Color.Black);
            }

            m_oldState = m_newState;

            base.Draw(batch);
        }

        public void submit()
        {
            focus = false;
            result = currentText;
            submitted = true;
        }
    }
}