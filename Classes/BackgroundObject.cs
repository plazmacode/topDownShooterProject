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
        public BackgroundObject()
        {

        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[4];

            sprites[0] = content.Load<Texture2D>("crate");

            sprite = sprites[0];

        }

        public override void OnCollision(GameObject other)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
