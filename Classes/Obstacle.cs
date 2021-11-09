using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class Obstacle : GameObject
    {
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("obstacle");
        }

        public override void OnCollision(GameObject other)
        {

        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
