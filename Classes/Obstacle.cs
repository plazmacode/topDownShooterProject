using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    public class Obstacle : GameObject
    {
        private bool isDestroyable;

        public Obstacle(Texture2D sprite, int X, int Y)
        {
            this.sprite = sprite;
            this.position.X = X;
            this.position.Y = Y;
            this.isDestroyable = false;
        }

        public Obstacle(Texture2D sprite, int X, int Y, bool isDestroyable)
        {
            this.sprite = sprite;
            this.position.X = X;
            this.position.Y = Y;
            this.isDestroyable = isDestroyable;
        }

        public Obstacle(int X, int Y, bool isDestroyable)
        {
            this.position.X = X;
            this.position.Y = Y;
            this.isDestroyable = isDestroyable;
        }
        public Obstacle(int X, int Y)
        {
            this.position.X = X;
            this.position.Y = Y;
            this.isDestroyable = false;
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("obstacle");
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Weapon)
            {
                if (this.isDestroyable == true)
                {
                    GameWorld.Destroy(this);
                }
                GameWorld.Destroy(other);
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, 1F, SpriteEffects.None, 0.2f);
        }
    }
}
