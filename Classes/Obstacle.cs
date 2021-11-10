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
        public Obstacle(Texture2D sprite, int X, int Y)
        {
            this.sprite = sprite;
            this.position.X = X;
            this.position.Y = Y;
        }

        public Obstacle(int X, int Y)
        {
            this.position.X = X;
            this.position.Y = Y;
        }

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
