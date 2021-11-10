using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class AmmoPickup : Pickup
    {
        private int ammoAmount;

        public AmmoPickup()
        {
            random = new Random();
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("ammo");
            Respawn();
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Player)
            {
                Player.Ammo += ammoAmount;
                Respawn();
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public void Respawn()
        {
            ammoAmount = random.Next(10, 50);

            int positionX = random.Next(0, (int)GameWorld.ScreenSize.X - sprite.Width);
            int positionY = random.Next(0, (int)GameWorld.ScreenSize.Y - sprite.Width);

            position = new Vector2(positionX, positionY);
        }

    }
}
