﻿namespace ThunderFighter.Missiles
{
    using System;
    using System.Collections.Generic;

    internal class SidewinderMissile : Missile
    {
        public SidewinderMissile(Field field, Point2D position) : 
            this(field, position, EntityState.Strong)
        {
        }

        public SidewinderMissile(Field field, Point2D position, EntityState entityState) : 
            this(field, position, SidewinderMissile.BodyStates(), entityState)
        {
        }

        public SidewinderMissile(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) : 
            base(field, position, bodyStates, entityState)
        {
            // defines missile movement direction
            this.DeltaX = 3;
            this.DeltaY = 0;
        }

        public override void Move()
        {
            // change this formula if you want to change how missile moves
            this.Position.X += this.DeltaX;
            this.Position.Y += this.DeltaY;
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(4, -2, '*', ConsoleColor.Black));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(2, 2, '*', ConsoleColor.Red));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(3, 4, '+', ConsoleColor.Red));

            bodyStates.Add(strongBody);        // EntityState.Strong
            bodyStates.Add(halfDestroyedBody); // EntityState.HalfDestroyed
            bodyStates.Add(destroyedBody);     // EntityState.Destroyed

            return bodyStates;
        }
    }
}
