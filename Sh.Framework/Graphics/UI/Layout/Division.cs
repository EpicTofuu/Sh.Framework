using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sh.Framework.Graphics.UI.Layout
{
    /// <summary>
    /// offset objects' coordinates and/or group them together
    /// </summary>
    public class Division
    {
        //TODO
        public List<Divider> children = new List<Divider>();
        public Vector2 Position;

        public Division()
        {
            Position = Vector2.Zero;
        }

        public void Update()
        {
            foreach (Divider d in children)
            {
                d.position = new Vector2(d.position.X + Position.X, d.position.Y + Position.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Position.Y--;
            }
        }
    }
}
