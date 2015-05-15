﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Controller;

namespace Shooter.Model
{
    public class Projectile
    {
        // Image representing the Projectile
        public Texture2D Texture;

        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;

        // State of the Projectile
        public bool Active;

        // The amount of damage the projectile can inflict to an enemy
        public int Damage;

        // Represents the viewable boundary of the game
        Viewport viewport;
        public float dropMove;
        public bool sinUp;

        // Get the width of the projectile ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the projectile ship
        public int Height
        {
            get { return Texture.Height; }
        }

        // Determines how fast the projectile moves
        float projectileMoveSpeed;
        float projectileSkew;


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;

            dropMove = 0.0f;

            sinUp = true;

            Active = true;

            Damage = 2;

            projectileMoveSpeed = 20f;
            projectileSkew = 0.0f;
        }
        public void Update()
        {
            // Projectiles always move to the right
            Position.X += projectileMoveSpeed;
            if (Shooter.Controller.ShooterGame.currentStyle == "Drop")
            {
                 if(dropMove > -5.0f && dropMove < 5.0f && sinUp)
                 {
                     Position.Y += (Position.Y * 0.1f);
                 }
                 if (dropMove >= 5.0f )
                 {
                     Position.Y += (Position.Y * -0.1f);
                     sinUp = false;
                 }
                 if (dropMove > -5.0f && dropMove < 5.0f && !sinUp)
                 {
                     Position.Y += (Position.Y * 0.1f);
                 }
                 if (dropMove <= -5.0f)
                 {
                     Position.Y += (Position.Y * -0.1f);
                     sinUp = true;
                 }
            }
            if (ShooterGame.currentStyle == "Sin-ish")
            {
                if (dropMove > -10.0f && dropMove < 10.0f && sinUp)
                {
                    dropMove = (dropMove + 1f);
                    Position.Y += (dropMove);
                }
                if (dropMove >= 10.0f)
                {
                    dropMove = (dropMove - 1f);
                    Position.Y += (dropMove);
                    sinUp = false;
                }
                if (dropMove > -10.0f && dropMove < 10.0f && !sinUp)
                {
                    dropMove = (dropMove - 1f);
                    Position.Y += (dropMove);
                }
                if (dropMove <= -10.0f)
                {
                    dropMove = (dropMove + 1f);
                    Position.Y += (dropMove);
                    sinUp = true;
                }
            }
            /// projectileSkew = Shooter.Controller.ShooterGame.PlayerMoveSpeedY;
            /// Position.Y = (Position.Y + projectileSkew);
            // Deactivate the bullet if it goes out of screen
            if (Position.X + Texture.Width / 2 > viewport.Width)
                Active = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }

        
    }
}
