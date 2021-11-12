using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class BackgroundObject : GameObject
    {
        public BackgroundObject(Texture2D sprite, int X, int Y)
        {
            this.sprite = sprite;
            position.X = X;
            position.Y = Y;
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[4];

            sprites[0] = content.Load<Texture2D>("");

            sprite = sprites[0];

        }

        public override void OnCollision(GameObject other)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, 1F, SpriteEffects.None, 0.1f);
        }
    }
}
