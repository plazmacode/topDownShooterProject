using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace topDownShooterProject.Classes
{
    public abstract class Pickup : GameObject
    {
        protected Random random;

        protected abstract void Respawn();

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.9f);
        }
    }
}
