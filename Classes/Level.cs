using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class Level
    {
        private Texture2D obstacleSprite;
        public void LoadContent(ContentManager content)
        {
            obstacleSprite = content.Load<Texture2D>("obstacle");
        }

        public void CreateLevel(int level)
        {
            if (level == 0)
            {
                level0();
            }
        }
        private void level0()
        {
            GameWorld.instantiate(new Obstacle(obstacleSprite, 10, 20));
        }
    }
}
