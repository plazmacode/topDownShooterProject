using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class Character : GameObject, IMoveable
    {
        public override void LoadContent(ContentManager content)
        {

        }

        public override void OnCollision(GameObject other)
        {
            if (other is Obstacle)
            {
                position -= velocity * speed * (float)0.05;
            }
        }

        public override void Update(GameTime gameTime)
        {

        }

        public void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            position += ((velocity * speed) * deltaTime);
        }
    }
}
