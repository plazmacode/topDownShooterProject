using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class Enemy : Character
    {
     
        private Vector2 targetPosition;

        public Enemy()
            {
            speed = 1;
            fps = 10;
            position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);

            }
     
        public override void Update(GameTime gameTime)
        {
            targetPosition = GameWorld.PlayerPosition;

            if (targetPosition.X > Position.X )
            {
                position.X += speed;
            }
            else
            {
                position.X -= speed ;
            }

            if (targetPosition.Y > Position.Y)
            {
                position.Y += speed;
            }
            else
            {
                position.Y -= speed;
            }
        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Skeleton");
        }


    

    }
}
