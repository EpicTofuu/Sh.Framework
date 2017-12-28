using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;
using Sh.Framework.Physics.Collisions;

namespace Sh.Framework.Graphics.UI
{
    /// <summary>
    /// clickable panes that can be hovered over for maximum enjoyment
    /// </summary>
    public class Button : ClickableObject
    {
        //fillable variables c
        //--------------------------------------------------------------

        //this button class makes use of chopped up buttons, this allows for buttons that can infinitely stretch
        //horizontally without any weird stretching.
        public Texture2D buttonLeft;
        public Texture2D buttonRight;
        public Texture2D buttonMiddle;

        public SpriteFont labelFont;

        public string label;

        public Color buttonColorDefault = Color.White;
        public Color buttonColorHover = Color.Gray;
        public Color buttonColorPressed = Color.DarkGray;
        public Color labelColor = Color.Black;

        public bool focused;
        //don't forget to set the rect value as this class inherits from clickable object

        //--------------------------------------------------------------

        public bool pressed = false;

        private Color buttonColor;
        private MouseState mouse;

        //i spent a lot of time writing that v
        /// <summary>
        /// public Type for generic UI buttons
        /// Draws a clickable rectangle with customizable left and right
        /// </summary>
        /// <param name = "buttonLeft"> the texture for the left side of button</param>
        /// <param name = "buttonRight"> the texture for the right side of button</param>
        /// <param name = "buttonMiddle"> the middle texture for the button, this texture will be stretched</param>
        /// <param name = "labelFont"> spriteFont used to render button label</name>
        /// <param name = "label"> button's text, will be rendered in the center</param>
        /// <param name = "buttonColorDefault"> button's colour when idle</param>
        /// <param name = "buttonColorHover"> button's colour when touching mouse</param>
        /// <param name = "buttonColorPressed"> button's colour when being pressed or is disabled</param>
        /// <param name = "labelColor"> label's colour</param>
        /// <param name = "focused"> is the button interactable?</param>
        public Button()
        {

        }

        public override void Update()
        {
            mouse = Mouse.GetState();

            if (focused)
            {
                if (MouseTouching.Rect(mouse, rect))
                {
                    buttonColor = buttonColorHover;
                }
                else
                {
                    buttonColor = buttonColorDefault;
                }
            }
            else
            {
                buttonColor = buttonColorPressed;
            }
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            //might take up excess memory (but in all honesty who actually cares, it's a button ffs)
            new Pane
            {
                color = buttonColor,
                rect = this.rect,
                buttonLeft = this.buttonLeft,
                buttonMiddle = this.buttonMiddle,
                buttonRight = this.buttonRight
            }.Draw(batch);

            batch.DrawString(labelFont, label, new Vector2(
                rect.X + rect.Width / 2 - labelFont.MeasureString (label).X / 2,
                rect.Y + rect.Height / 2 - labelFont.MeasureString(label).Y / 2),
                labelColor);
            base.Draw(batch);
        }
        
        public override void OnClick()
        {
            if (focused)
            {
                pressed = true;
                buttonColor = buttonColorPressed;
            }
            base.OnClick();
        }
    }
}
