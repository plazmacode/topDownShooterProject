using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace topDownShooterProject.Classes
{
    public class Player : Character
    {

        private Vector2 origin= new Vector2(14,20); 
        private float rotation;

        private Texture2D bulletSprite;
        private SoundEffect rifleSound;
        private SoundEffectInstance deathSound;

        private int fireCooldown;
        private bool canFire;

        public float Rotation { get => rotation; set => rotation = value; }

        public Player()
        {
            health = 100;
            speed = 450;
            fps = 10;
            position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
            velocity = Vector2.Zero;
            canFire = true;
            fireCooldown = 0;
            ammo = 50;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("survivor-idle_shotgun_0");

            bulletSprite = content.Load<Texture2D>("bullet");

            rifleSound = content.Load<SoundEffect>("rifle1");
            //deathSound = content.Load<SoundEffect>("death").CreateInstance();

        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Handleinput(mouseState);
            ScreenLimits();
            Look(mouseState);
            Move(gameTime);
            if (health <= 0)
            {
                Die();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation + 3.14f, origin , 1F, SpriteEffects.None, 0.2f);
            //spriteBacth.Draw(sprite, position, null, Color.White, rotation, Vector2.Zero, 1.0F, SpriteEffects.None, 0);
        }

        private void Handleinput(MouseState mouseState)
        {
            velocity = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            if (keyState.IsKeyDown(Keys.Space))
            {
                Shoot();
            }
            if (mouseState.LeftButton == ButtonState.Pressed
                && mouseState.X > 0 && mouseState.X < GameWorld.ScreenSize.X
                && mouseState.Y > 0 && mouseState.Y < GameWorld.ScreenSize.Y)
            {
                Shoot();
            }

            if (!canFire && fireCooldown < 5)
            {
                fireCooldown++;
            }
            else
            {
                canFire = true;
                fireCooldown = 0;
            }
        }

        private void Shoot()
        {
            if (canFire == true && GameWorld.player.ammo > 0)
            {
                canFire = false;
                GameWorld.Instantiate(new Weapon(bulletSprite, new Vector2(position.X, position.Y)));
                GameWorld.player.ammo--;
                rifleSound.Play(0.3f, 0f, 0f);
            }
        }

        private void Die()
        {
            //deathSound.Play();
        }

        /// <summary>
        /// Finder mussen og pejer player spriten imod den
        /// </summary>
        /// <param name="mouseState"></param>
        private void Look(MouseState mouseState)
        {

            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
            Vector2 Dpos = position - mousePosition;

            rotation = (float)Math.Atan2(Dpos.Y, Dpos.X);

        }

        public void ScreenLimits()
        {
            if (GameWorld.EnemiesLeft > 0)
            {
                if (position.X < 0)
                {
                    position.X = 0;
                }
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
                if (position.X > GameWorld.ScreenSize.X)
                {
                    position.X = GameWorld.ScreenSize.X;
                }
                if (position.Y > GameWorld.ScreenSize.Y)
                {
                    position.Y = GameWorld.ScreenSize.Y;
                }
            }
        }

        public void Respawn(string place)
        {
            if (place == "center")
            {
                position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);

            }
            if (place == "left")
            {
                position = new Vector2(0, GameWorld.ScreenSize.Y / 2);

            }
            if (place == "right")
            {
                position = new Vector2(GameWorld.ScreenSize.X, GameWorld.ScreenSize.Y / 2);

            }
            if (place == "top")
            {
                position = new Vector2(GameWorld.ScreenSize.X / 2, 0);

            }
            if (place == "bottom")
            {
                position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y);

            }
        }
    }
}
