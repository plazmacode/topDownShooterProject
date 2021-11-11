using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace topDownShooterProject.Classes
{
    static class Level
    {
        private static Texture2D obstacleSprite;
        private static Texture2D crateSprite;
        private static int[,] levelArray = new int[3, 3]
        {
            { 0, 3, 0 },
            { 2, 0, 1 },
            { 0, 4, 0 }
        };

        private static int[] currentLevel = new int[2] { 1, 1 };

        public static void LoadContent(ContentManager content)
        {
            obstacleSprite = content.Load<Texture2D>("obstacle");
            crateSprite = content.Load<Texture2D>("crate");
        }

        public static void CreateLevel(int level)
        {
            if (level == 0)
            {
                level0();
            }
            if (level == 1)
            {
                level1();
            }
        }

        private static void UnloadLevel()
        {
            //Remove obstacles from gameObjects to clear the level
            foreach (GameObject gameObject in GameWorld.gameObjects)
            {
                if (gameObject is Obstacle)
                {
                    GameWorld.Destroy(gameObject);
                }
            }
        }

        private static void level0()
        {
            GameWorld.instantiate(new Obstacle(crateSprite, 100, 100, true));
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
        private static void level1()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.instantiate(new Obstacle(obstacleSprite, 800+50*i, 600));
            }

        }


        public static void Update(GameTime gameTime)
        {
            if (GameWorld.player.Position.X > GameWorld.ScreenSize.X && currentLevel[1] < 2) //Right side
            {
                UnloadLevel();
                GameWorld.player.Respawn("left");
                currentLevel[1]++;
                CreateLevel(levelArray[currentLevel[0], currentLevel[1]]);
                Debug.WriteLine(levelArray[currentLevel[0], currentLevel[1]]);
            }
            if (GameWorld.player.Position.X < 0 && currentLevel[1] > 0) //Left side
            {
                UnloadLevel();
                GameWorld.player.Respawn("right");
                currentLevel[1]--;
                CreateLevel(levelArray[currentLevel[0], currentLevel[1]]);
            }
            if (GameWorld.player.Position.Y < 0 && currentLevel[0] > 0) //Top side
            {
                UnloadLevel();
                GameWorld.player.Respawn("bottom");
                currentLevel[0]--;
                CreateLevel(levelArray[currentLevel[0], currentLevel[1]]);
            }
            if (GameWorld.player.Position.Y > GameWorld.ScreenSize.Y && currentLevel[0] < 2) //Bottom side
            {
                UnloadLevel();
                GameWorld.player.Respawn("top");
                currentLevel[0]++;
                CreateLevel(levelArray[currentLevel[0], currentLevel[1]]);
            }
        }

        public static void OnCollision(GameObject other)
        {

        }
    }
}
