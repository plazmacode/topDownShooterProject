using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace topDownShooterProject.Classes
{
    static class Level
    {
        private static Texture2D obstacleSprite;
        public static void LoadContent(ContentManager content)
        {
            obstacleSprite = content.Load<Texture2D>("obstacle");
        }

        public static void CreateLevel(int level)
        {
            if (level == 0)
            {
                level0();
            }
        }
        private static void level0()
        {
            //GameWorld.instantiate(new BackgroundObject());
            for (int i = 0; i < 18; i++)
            {
                GameWorld.instantiate(new Obstacle(obstacleSprite, 0, 50*i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.instantiate(new Obstacle(obstacleSprite, 700, (int)GameWorld.ScreenSize.Y/2 + 50 * i));
            }
            for (int i = 0; i < 8; i++)
            {
                GameWorld.instantiate(new Obstacle(obstacleSprite, 1400, 50 * i));
            }

        }

        public static void Update(GameTime gameTime)
        {

        }

        public static void OnCollision(GameObject other)
        {

        }
    }
}
