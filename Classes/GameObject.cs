using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    public abstract class GameObject
    {
        protected Vector2 position;
        protected Texture2D sprite;
        protected Texture2D[] sprites;
        protected float fps;
        protected Vector2 velocity;
        protected float speed;
        private float timeElapsed;
        private int currentIndex;

        public Vector2 Position { get => position; set => position = value; }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Position, Color.White);
        }

        public abstract void OnCollision(GameObject other);

        public void CheckCollision(GameObject other)
        {
            if (CollisionBox().Intersects(other.CollisionBox()))
            {
                OnCollision(other);
            }
        }
        public virtual Rectangle CollisionBox()
        {
            if(this is Player)
            {
                return new Rectangle((int)position.X-25, (int)position.Y-25, 50, 50);
            }
            else
            { 
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
        }


        protected void Animate(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentIndex = (int)(timeElapsed * fps);

            sprite = sprites[currentIndex];

            if (currentIndex >= sprites.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
            }
        }
    }

}
