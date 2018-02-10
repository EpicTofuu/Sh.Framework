﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Physics.Collisions;
using System;
using System.Collections.Generic;

namespace Sh.Framework.Objects.Behaviours
{
    /// <summary>
    /// no
    /// </summary>
    public class BGravPlayerObject_2 : GenericObject
    {
        public Vector2 position;
        public Texture2D texture;

        //to assign
        public Keys jump;
        public Keys moveLeft;
        public Keys moveRight;
        public float speed = 10;
        public float jumpspeed = 15;
        public float gravity = 2;

        public List<GameObject> solids = new List<GameObject>();
        public Game game;

        public bool moving;
        public float hsp, vsp;
        bool canjump;

        float rGravity;

        public BGravPlayerObject_2()
        {
            vsp = 0;
            rGravity = gravity;
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
            {
                //jumpspeed += 0.2f;
                isJump = 1;
            }
            else
            {
                isJump = 0;
                //jumpspeed = 10;
            }

            if (hsp < 14)
            {
                if (ks.IsKeyDown(moveLeft))
                    hsp -= 2;

                if (ks.IsKeyDown(moveRight))
                    hsp += 2;
                
                if (vsp < 10)
                {
                    vsp += gravity;
                }
            }

            hsp *= 0.9f;

            foreach (GameObject other in solids)
            {
                if (collision.withGameObject(new Rectangle((int)position.X, (int)position.Y + 1, (int)texture.Width, (int)texture.Height), other))
                {
                    vsp = isJump * (-jumpspeed * 2);
                }

                Rectangle horCol = new Rectangle((int)(position.X + hsp), (int)position.Y, texture.Width, texture.Height);
                Rectangle verCol = new Rectangle((int)position.X, (int)(position.Y + vsp), texture.Width, texture.Height);

                if (collision.withGameObject(horCol, other))        //horizontal collision
                {
                    while (!collision.withGameObject(new Rectangle((int)(position.X + Math.Sign(hsp)), (int)position.Y, texture.Width, texture.Height), other))
                    {
                        position.X += Math.Sign(hsp);
                    }

                    hsp = 0;
                }

                if (collision.withGameObject(verCol, other))   //vertical collision
                {
                    //differentiating between two different engines
                    if (collision.withGameObject(new Rectangle((int)position.X, (int)position.Y - 64, (int)texture.Width, (int)texture.Height + 64), other))
                    {
                        //Close-case engine. Aims to move player object out of a block constantly
                        //Less accurate but handles collisions with smaller heights
                        isJump = 0;
                        int i;

                        if (Math.Sign(vsp) == -1)
                        {
                            i = -1;
                        }
                        else
                        {
                            i = 1;
                        }

                        position.Y += 1 * i;
                    }
                    else
                    {
                        //General-case engine. Aims to move player object out of a block systematically
                        //More accurate but can only correctly handle taller heights
                        while (!collision.withGameObject(new Rectangle((int)position.X, (int)(position.Y + Math.Sign(vsp)), (int)texture.Width, (int)texture.Height), other))
                        {
                            position.Y += Math.Sign(vsp);
                        }
                    }

                    vsp = 0;
                    canjump = true;
                }
            }

            position = new Vector2(position.X + hsp, position.Y + vsp);
        }
    }
}
