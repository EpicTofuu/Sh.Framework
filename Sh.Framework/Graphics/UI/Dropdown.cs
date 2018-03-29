using Sh.Framework.Objects;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Input;

namespace Sh.Framework.Graphics.UI
{
    public class Dropdown : GenericObject
    {
        Game game;

        /// <summary>
        /// Exactly what it sounds like
        /// </summary>
        public enum Direction
        {
            up = -1,
            down = 1
        }

        /// <summary>
        /// The generic button to use for the entries in the dropdown, this includes the head button
        /// Do not fill in the rect
        /// </summary>
        public Button EntryButton;

        /// <summary>
        /// The placement for the head button
        /// </summary>
        public Rectangle rect;

        /// <summary>
        /// If the entries travel upwards or downwards
        /// </summary>
        public Direction direction;

        /// <summary>
        /// All the options the user can choose from
        /// </summary>
        public List<string> Options;

        /// <summary>
        /// Final selection made by the user
        /// Assigned to the first entry in <see cref="Options"/> by default
        /// </summary>
        public string Selection;

        /// <summary>
        /// True only if the dropdown menu is present
        /// </summary>
        public bool focused;

        private List<Button> entries;

        private Button Head;

        MouseState oldState;
        MouseState newState;

        public Dropdown(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            oldState = Mouse.GetState();
            
            AfterLoad();
        }

        /// <summary>
        /// A method thats guarenteed to run after <see cref="LoadContent()"/>
        /// </summary>
        void AfterLoad()
        {
            Head = EntryButton;
            Head.LoadContent();

            entries = new List<Button>();

            foreach (string entry in Options)
            {
                entries.Add(new Button
                {
                    buttonLeft = EntryButton.buttonLeft,
                    buttonRight = EntryButton.buttonRight,
                    buttonMiddle = EntryButton.buttonMiddle,
                    labelFont = EntryButton.labelFont,
                    label = ""
                });
            }

            for (int i = 0; i < entries.Count; i++)
            {
                entries[i].label = Options[i];
            }

            foreach (Button b in entries)
                b.LoadContent();
        }

        public override void Update()
        {
            base.Update();

            Head.Update();
            
            newState = Mouse.GetState();

            focused = Head.pressed;

            if (!Head.hovering)
            {
                if (MouseStroke.LeftButtonDown(oldState, newState))
                {
                    foreach (Button b in entries)
                    {
                        if (b.pressed)
                        {
                            Selection = b.label;
                            b.pressed = false;
                        }
                    }
                    Head.pressed = false;
                }
            }

            oldState = newState;

            foreach (Button b in entries)
            {
                b.Update();

                if (b.pressed)
                {
                    Selection = b.label;
                    b.pressed = false;
                }
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            
            Head.rect = rect;

            Head.label = Selection ?? Options[0] ?? "";
            Head.Draw(batch);

            if (focused)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    entries[i].rect = new Rectangle(rect.X, rect.Y + (i + 1) * rect.Height * (int)direction, rect.Width, rect.Height);
                    entries[i].Draw(batch);
                }
            }
        }
    }
}
