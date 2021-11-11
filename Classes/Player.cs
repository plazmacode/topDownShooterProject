using Microsoft.Xna.Framework;
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

        Vector2 origin= new Vector2(14,20); 
        float rotation;

        private Texture2D bulletSprite;


        public Player()
        {
            health = 100;
            speed = 1000;
            fps = 10;
            position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
            velocity = Vector2.Zero;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("survivor-idle_shotgun_0");

            bulletSprite = content.Load<Texture2D>("bullet");
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Handleinput();
            Look(mouseState);
            Move(gameTime);
        }

        public override void Draw(SpriteBatch spriteBacth)
        {
            spriteBacth.Draw(sprite, position, null, Color.White, rotation + 3.14f, origin , 1F, SpriteEffects.None, 0);
            //spriteBacth.Draw(sprite, position, null, Color.White, rotation, Vector2.Zero, 1.0F, SpriteEffects.None, 0);
        }

        private void Handleinput()
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
                GameWorld.instantiate(new Weapon(bulletSprite, new Vector2(position.X, position.Y)));
            }
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
    }
}
