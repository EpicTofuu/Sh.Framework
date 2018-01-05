using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;
using Sh.Framework.Input;
using Sh.Framework.Physics.Collisions;
using System.Collections.Generic;

namespace Sh.Framework.Graphics.UI
{
    public class Textbox : GenericObject
    {
        MouseState m_oldState;
        MouseState m_newState;

        KeyboardState k_oldState;
        KeyboardState k_newState;

        public Pane pane;
        public string dummyText;
        public SpriteFont font;
        public Game game;
        public Texture2D IBeam;
        public Texture2D pixel;
        public float paddingX = 40;
        public bool resetable = false;
        public Color fillColour = Color.White;
        public Color focusColour = Color.Gray;
        public Color dummyTextColour = Color.Black;
        public Color TextColour = Color.Black;
        public Keys returnKey = Keys.Enter;
        public List<Keys> whitelist;
        public bool allowBreak = false;
        public Color BlinkColor = Color.Black;
        public bool allowBlink = true;
        public int blinkRate = 30;

        public string result;
        public string currentText;
        public bool focus;
        public bool submitted;
        public bool isTouching;

        private Color useColor;

        public Textbox()
        {
            focus = false;
            currentText = "";

            m_oldState = Mouse.GetState();
            k_oldState = Keyboard.GetState();

            whitelist = new List<Keys>();
            whitelist.Add(Keys.LeftControl);
            whitelist.Add(Keys.RightControl);
            whitelist.Add(Keys.LeftAlt);
            whitelist.Add(Keys.RightAlt);
            whitelist.Add(Keys.Tab);
            
            if (!allowBreak)
                whitelist.Add(Keys.Enter);
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
                    if (!whitelist.Contains(k))
                    {
                        if (KeyboardStroke.KeyDown(k_oldState, k_newState, k))
                            currentText += utils.ConvertKeyToChar(k, shift);
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
                if (KeyboardStroke.KeyDown(k_oldState, k_newState, returnKey) && !allowBreak)
                {
                    submit();
                }
            }

            k_oldState = k_newState;

            base.Update();
        }

        int blinkTimer = 0;
        bool a = true;

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

                isTouching = true;
            }   
            else                                                            //if not touching
            {
                game.IsMouseVisible = true;
                useColor = fillColour;

                if (m_newState.LeftButton == ButtonState.Pressed && m_oldState.LeftButton == ButtonState.Released)
                {
                    submit();
                }

                isTouching = false;
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
            if (focus)
            {
                Color blinkColour;

                if (allowBlink)
                {
                    if (blinkTimer > blinkRate)
                    {
                        if (a)
                            a = false;
                        else
                            a = true;

                        blinkTimer = 0;
                    }
                    else
                    {
                        blinkTimer++;
                    }
                }
                else
                {
                    a = true;
                }

                if (a) { blinkColour = BlinkColor; } else { blinkColour = BlinkColor * 0; }

                float blinkerPadding = pane.rect.Height / 4;
                batch.Draw(pixel, new Rectangle((int)(pane.rect.X + paddingX + font.MeasureString(currentText).X), pane.rect.Y + (int)blinkerPadding, 1, pane.rect.Height - (int)blinkerPadding * 2), blinkColour);
            }

            m_oldState = m_newState;

            base.Draw(batch);
        }

        public void submit()
        {
            focus = false;
            result = currentText;
            submitted = true;

            if (resetable)
                currentText = "";
        }
    }
}