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
        public string dismissal = "cancel";
        public string agreement = "yes";
        public string decline = "no";

        public bool visible;

        KeyboardState oldState;
        KeyboardState newState;

        Button noButton;
        Button yesButton;

        public DialogueBox()
        {
            //to create custom keys or remove conflicting ones:
            //simplay call DismissKeys.Clear()

            DismissKeys.Add(Keys.Escape);
            DismissKeys.Add(Keys.Space);
            DismissKeys.Add(Keys.Enter);

            visible = true;
            
            oldState = Keyboard.GetState();
        }

        public override void LoadContent()
        {
            yesButton = new Button()
            {
                buttonLeft = selectionButton.buttonLeft,
                buttonRight = selectionButton.buttonRight,
                buttonMiddle = selectionButton.buttonMiddle,
                labelFont = selectionButton.labelFont,
                rect = selectionButton.rect
            };

            noButton = new Button()
            {
                buttonLeft = selectionButton.buttonLeft,
                buttonRight = selectionButton.buttonRight,
                buttonMiddle = selectionButton.buttonMiddle,
                labelFont = selectionButton.labelFont,
                rect = selectionButton.rect
            };
            base.LoadContent();
        }

        public override void Update()
        {
            if (Type == type.yesno)
            {
                yesButton.rect = new Rectangle(window.rect.X + (window.rect.Width / 2), window.rect.Y + window.rect.Height - selectionButton.rect.Height - buttonYoffset, selectionButton.rect.Width, yesButton.rect.Height);
                noButton.rect = new Rectangle(window.rect.X + (window.rect.Width / 2) - selectionButton.rect.Width, window.rect.Y + window.rect.Height - selectionButton.rect.Height - buttonYoffset, noButton.rect.Width, noButton.rect.Height);

                yesButton.label = agreement;
                noButton.label = decline;

                yesButton.Update();
                noButton.Update();

                if (yesButton.pressed)
                {
                    outcome = true;
                    yesButton.pressed = false;
                    visible = false;
                }

                if (noButton.pressed)
                {
                    outcome = false;
                    noButton.pressed = false;
                    visible = false;
                }
            }

            base.Update();
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
                    Button cancelButton = selectionButton;

                    cancelButton.rect = new Rectangle(window.rect.X + (window.rect.Width / 2) - (cancelButton.rect.Width / 2), window.rect.Y + window.rect.Height - cancelButton.rect.Height - buttonYoffset, cancelButton.rect.Width, cancelButton.rect.Height);
                    cancelButton.label = dismissal;
                    cancelButton.Update();
                    cancelButton.Draw(batch);

                    if (cancelButton.pressed)
                    {
                        visible = false;
                        cancelButton.pressed = false;
                    }
                }
                else if (Type == type.yesno)
                {
                    yesButton.Draw(batch);
                    noButton.Draw(batch);
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
                    if (KeyboardStroke.KeyDown(oldState, newState, k))
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
