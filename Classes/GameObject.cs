using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
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

        public virtual void LoadContent(ContentManager content)
        {

        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBacth)
        {
            spriteBacth.Draw(sprite, position, Color.White);
        }
    }
}
