using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Physics.Collisions;
using System;
using System.Collections.Generic;

namespace Sh.Framework.Objects
{
    public class GravPlayerObject : GameObject
    {
        //to assign
        protected Keys jump;
        protected Keys moveLeft;
        protected Keys moveRight;
        protected float speed = 10;
        protected float jumpspeed = 20;
        protected float gravity = 2;

        protected List<GameObject> solids = new List<GameObject>();
        private Game game;

        //debug variables

        public float Dhsp;
        public float Dvsp;

        public bool Hcoll;
        public bool Vcoll;
        
        float hsp, vsp;

        public GravPlayerObject(Game othergame) : base(othergame)
        {
            solid = true;
            game = othergame;
            vsp = 0;
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        protected int i = 0;

        public override void Update()
        {

            KeyboardState ks = Keyboard.GetState();
            int isJump, isLeft, isRight;
            int xdir;

            if (ks.IsKeyDown(jump))
                isJump = 1;
            else
                isJump = 0;

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

            if (vsp < 10)
            {
                vsp += gravity;
            }

            foreach (GameObject other in solids)
            {
                if (collision.withGameObject(new Rectangle((int)position.X, (int)position.Y + 1, (int)texture.Width, (int)texture.Height), other))
                {
                    vsp = isJump * (-jumpspeed * 2);
                }

                Rectangle horCol = new Rectangle((int)(position.X + hsp), (int)position.Y, (int)texture.Width, (int)texture.Height);
                Rectangle verCol = new Rectangle((int)position.X, (int)(position.Y + vsp), (int)texture.Width, (int)texture.Height);

                //horizontal collision
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

                //vertical collision
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

            //i = solids;
            position = new Vector2(position.X += hsp, position.Y += vsp);
            Dhsp = hsp;
            Dvsp = vsp;
        }
    }
}
