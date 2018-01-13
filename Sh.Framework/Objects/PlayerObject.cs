using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Physics.Collisions;

namespace Sh.Framework.Objects
{
    public class PlayerObject : GameObject
    {
        //to assign
        protected Keys moveUp;
        protected Keys moveDown;
        protected Keys moveLeft;
        protected Keys moveRight;
        protected float speed;

        protected List<GameObject> solids = new List<GameObject>();
        private Game game;

        //debug variables

        public float Dhsp;
        public float Dvsp;

        public bool Hcoll;
        public bool Vcoll;

        public PlayerObject(Game othergame) : base(othergame)
        {
            solid = true;
            game = othergame;
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            float hsp, vsp;
            int isUp, isDown, isLeft, isRight;
            int xdir, ydir;

            if (ks.IsKeyDown(moveDown))
                isDown = 1;
            else
                isDown = 0;

            if (ks.IsKeyDown(moveUp))
                isUp = 1;
            else
                isUp = 0;

            if (ks.IsKeyDown(moveLeft))
                isLeft = 1;
            else
                isLeft = 0;

            if (ks.IsKeyDown(moveRight))
                isRight = 1;
            else
                isRight = 0;


            xdir = -isLeft + isRight;
            hsp = xdir * speed;

            ydir = isDown + -isUp;
            vsp = ydir * speed;

            foreach (GameObject other in solids)
            {
                Rectangle horCol = new Rectangle((int)(position.X + hsp), (int)position.Y, (int)texture.Width, (int)texture.Height);
                Rectangle verCol = new Rectangle((int)position.X, (int)(position.Y + vsp), (int)texture.Width, (int)texture.Height);

                if (collision.withGameObject(horCol, other))
                {
                    Hcoll = true;

                    while (!collision.withGameObject(new Rectangle((int)(position.X + Math.Sign(hsp)), (int)position.Y, (int)texture.Width, (int)texture.Height), other))
                        position.X += Math.Sign(hsp);

                    hsp = 0;
                }
                else
                {
                    Hcoll = false;
                }

                if (collision.withGameObject(verCol, other))
                {
                    Hcoll = true;

                    while (!collision.withGameObject(new Rectangle((int)position.X, (int)(position.Y + Math.Sign(vsp)), (int)texture.Width, (int)texture.Height), other))
                        position.Y += Math.Sign(vsp);

                    vsp = 0;
                }
                else
                {
                    Hcoll = false;
                }
            }

            position = new Vector2(position.X + hsp, position.Y + vsp);

            Dhsp = hsp;
            Dvsp = vsp;
        }
    }
}