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
    public class Weapon : GameObject
    {

        MouseState mouseState = Mouse.GetState();


        public Weapon(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
            this.speed = 800;
            this.velocity = new Vector2(mouseState.X - GameWorld.ScreenSize.X, mouseState.Y - GameWorld.ScreenSize.Y);
            velocity.Normalize();
        }



        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            if (position.Y < 0)
            {
                GameWorld.Destroy(this);
            }
        }


        public override void OnCollision(GameObject other)
        {
        }

        public void Move(GameTime gameTime)
        {

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
    }
}
