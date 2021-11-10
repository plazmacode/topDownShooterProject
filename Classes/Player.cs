using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class Player : Character
    {
        public Player()
        {
            speed = 1000;
            fps = 10;
            position = new Vector2(GameWorld.ScreenSize.X/2, GameWorld.ScreenSize.Y/2);
            velocity = Vector2.Zero;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("survivor-idle_shotgun_0");
        }

        public override void Update(GameTime gameTime)
        {
            Handleinput();
            Move(gameTime);
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
        }
    }
}
