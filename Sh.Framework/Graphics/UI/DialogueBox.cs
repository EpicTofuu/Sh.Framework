using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;
using Sh.Framework.Input;
using System.Collections.Generic;

namespace Sh.Framework.Graphics.UI
{
    public class DialogueBox : GenericObject
    {
        public enum type
        {
            message,
            yesno,
            yesnocancel,
            input,
            inputyesno
        }

        public enum Align
        {
            Left,
            Middle,
            Right
        }

        public type Type;
        public string message;
        public string title;
        public SpriteFont font;
        public Vector2 TitlePadding = new Vector2(8, 10);
        public Vector2 MessagePadding = new Vector2(8, 20);
        public Align TitleAlign;
        public Align MessageAlign;
        public Pane window;
        public Button selectionButton;
        public Color titleColor = Color.Black;
        public Color messageColor = Color.Black;
        public bool outcome;
        public string answer;
        public int buttonYoffset = 5;

        public List<Keys> DismissKeys = new List<Keys>();
        public string dismissal = "Okay";

        public bool visible;

        KeyboardState oldState;
        KeyboardState newState;

        public DialogueBox()
        {
            //to create custom keys or remove conflicting ones:
            //simplay call DismissKeys.Clear()

            DismissKeys.Add(Keys.Escape);
            DismissKeys.Add(Keys.Space);
            DismissKeys.Add(Keys.Enter);

            oldState = Keyboard.GetState();
        }

        public override void Draw(SpriteBatch batch)
        {
            if (visible)
            {
                window.Draw(batch);

                Vector2 titlePosition;
                Vector2 messagePosition;

                titlePosition = new Vector2(window.rect.X + TitlePadding.X, window.rect.Y + TitlePadding.Y);
                messagePosition = new Vector2(window.rect.X + MessagePadding.X, window.rect.Y + font.MeasureString(title).Y + MessagePadding.Y);

                switch (TitleAlign)
                {
                    case Align.Left:
                        titlePosition = new Vector2(window.rect.X + TitlePadding.X, window.rect.Y + TitlePadding.Y);
                        break;

                    case Align.Middle:
                        titlePosition = new Vector2(window.rect.X + (window.rect.Width / 2) - (font.MeasureString(title).X / 2) + TitlePadding.X, window.rect.Y + TitlePadding.Y);
                        break;

                    case Align.Right:
                        titlePosition = new Vector2(window.rect.X + window.rect.Width - font.MeasureString(title).X - TitlePadding.X, window.rect.Y + TitlePadding.Y);
                        break;
                }

                switch (MessageAlign)
                {
                    case Align.Left:
                        messagePosition = new Vector2(window.rect.X + MessagePadding.X, window.rect.Y + font.MeasureString(title).Y + MessagePadding.Y);
                        break;

                    case Align.Middle:;
                        messagePosition = new Vector2(window.rect.X + (window.rect.Width / 2) - (font.MeasureString(message).X / 2) + TitlePadding.X, window.rect.Y + font.MeasureString(title).Y + MessagePadding.Y);
                        break;

                    case Align.Right:
                        messagePosition = new Vector2(window.rect.X + window.rect.Width - font.MeasureString(message).X - TitlePadding.X, window.rect.Y + font.MeasureString(title).Y + MessagePadding.Y);
                        break;
                }

                //title
                batch.DrawString(font, title, titlePosition, titleColor);

                //message
                batch.DrawString(font, message, messagePosition, messageColor);

                //external forms
                if (Type == type.message)
                {
                    selectionButton.rect = new Rectangle(window.rect.X + (window.rect.Width / 2) - (selectionButton.rect.Width / 2), window.rect.Y + window.rect.Height - selectionButton.rect.Height - buttonYoffset, selectionButton.rect.Width, selectionButton.rect.Height);
                    selectionButton.label = dismissal;
                    selectionButton.Update();
                    selectionButton.Draw(batch);

                    if (selectionButton.pressed)
                    {
                        visible = false;
                        selectionButton.pressed = false;
                    }
                }
                else
                {
                    //TODO make other dialoguebox types
                    throw new System.Exception("Other dialoguebox types are not yet available. Try them out at a later date");
                }

                newState = Keyboard.GetState();

                //dismissal keys
                foreach (Keys k in DismissKeys)
                {
                    if (KeyboardStroke.KeyUp(oldState, newState, k))
                    {
                        visible = false;
                    }
                }

                oldState = newState;
            }

            base.Draw(batch);
        }
    }
}
