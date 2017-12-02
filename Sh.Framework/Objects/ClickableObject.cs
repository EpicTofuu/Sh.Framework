using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Physics.Collisions;

namespace Sh.Framework.Objects
{
    public class ClickableObject : GenericObject
    {
        public Rectangle rect;

        private MouseState oldstate;
        private MouseState newstate;

        public bool hovering;

        public ClickableObject()
        {
            hovering = false;
        }

        public override void LoadContent()
        {
            oldstate = Mouse.GetState();
            base.LoadContent();
        }

        public override void Update()
        {
            newstate = Mouse.GetState();

            if (MouseTouching.Rect(newstate, rect))
            {
                if (newstate.LeftButton == ButtonState.Pressed && oldstate.LeftButton != ButtonState.Pressed)
                    OnClick();

                hovering = true;
            }
            else
            {
                hovering = false;
            }

            oldstate = newstate;
            base.Update();
        }

        public virtual void OnClick()
        {

        }
    }
}
