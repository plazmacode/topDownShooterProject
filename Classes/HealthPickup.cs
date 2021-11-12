using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class HealthPickup : Pickup
    {
        private int healAmount;

        public HealthPickup()
        {
            random = new Random();
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("health");
            Respawn();
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Player)
            {
                GameWorld.player.Health += healAmount;
                Respawn();
            }

            if (other is Obstacle)
            {
                Respawn();
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        public void Respawn()
        {
            healAmount = random.Next(10, 50);

            int positionX = random.Next(0, (int)GameWorld.ScreenSize.X - sprite.Width);
            int positionY = random.Next(0, (int)GameWorld.ScreenSize.Y - sprite.Width);

            position = new Vector2(positionX, positionY);
        }
    }
}
