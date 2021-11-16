using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    public class BackgroundObject : GameObject
    {
        private Random random;

        public BackgroundObject()
        {
            random = new Random();
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[4];

            for (int i = 0; i < 4; i++)
            {
                sprites[i] = content.Load<Texture2D>("background" + i);
            }


            sprite = sprites[0];

            Respawn();
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Obstacle)
            {
                Respawn();
            }
            if (other is BackgroundObject)
            {
                Respawn();
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, 0.5F, SpriteEffects.None, 0.1f);
        }

        public void Respawn()
        {
            sprite = sprites[random.Next(0, 4)];

            int positionX = random.Next(0, (int)GameWorld.ScreenSize.X - sprite.Width);
            int positionY = random.Next(0, (int)GameWorld.ScreenSize.Y - sprite.Width);

            position = new Vector2(positionX, positionY);
        }
    }
}
