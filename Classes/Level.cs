using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace topDownShooterProject.Classes
{
    public static class Level
    {
        private static Texture2D obstacleSprite;
        private static Texture2D crateSprite;
        private static int levelsCompleted; 
        private static int[,] levelArray = new int[3, 3]
        {
            { 7, 3, 6 },
            { 2, 0, 1 },
            { 8, 4, 5 }
        };
        

        private static int[] currentLevel = new int[2] { 1, 1 };

        public static int[] CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public static int[,] LevelArray { get => levelArray; set => levelArray = value; }

        public static int LevelsCompleted { get => levelsCompleted; set => levelsCompleted = value; }

        public static void LoadContent(ContentManager content)
        {
            obstacleSprite = content.Load<Texture2D>("obstacle");
            crateSprite = content.Load<Texture2D>("crate");
        }

        public static void CreateLevel(int level)
        {
            SpawnEnemies();
            switch (level)
            {
                case 0:
                    Level0();
                    break;
                case 1:
                    Level1();
                    break;
                case 2:
                    Level2();
                    break;
                case 3:
                    Level3();
                    break;
                case 4:
                    Level4();
                    break;
                case 5:
                    Level5();
                    break;
                case 6:
                    Level6();
                    break;
                case 7:
                    Level7();
                    break;
                case 8:
                    Level8();
                    break;
                case 9:
                    Level9();
                    break;
            }
        }
        /// <summary>
        /// Spawns enemies and updates related variables: EnemiesLeft, EnemiesInLevel, EnemiesSpawned
        /// </summary>
        private static void SpawnEnemies()
        {
            GameWorld.EnemiesLeft = (int)(10f * GameWorld.Difficulty);
            GameWorld.EnemiesInLevel = GameWorld.EnemiesLeft;
            GameWorld.EnemiesSpawned = 10;
            foreach (GameObject gameObject in GameWorld.gameObjects)
            {
                if (gameObject is Enemy)
                {
                    gameObject.GetType().InvokeMember("Respawn", System.Reflection.BindingFlags.InvokeMethod, null, gameObject, null);
                }
            }
        }
        /// <summary>
        /// Removes some gameObjects from the gameObject list
        /// </summary>
        private static void UnloadLevel()
        {
            //Remove obstacles from gameObjects to clear the level
            foreach (GameObject gameObject in GameWorld.gameObjects)
            {
                if (gameObject is Obstacle)
                {
                    GameWorld.Destroy(gameObject);
                }
                if (gameObject is Weapon)
                {
                    GameWorld.Destroy(gameObject);
                }

                //Respawn backgroundobjects(change their positions)
                if (gameObject is BackgroundObject)
                {
                    gameObject.GetType().InvokeMember("Respawn", System.Reflection.BindingFlags.InvokeMethod, null, gameObject, null);
                }
            }
        }

        private static void Level0()
        {
            for (int i = 0; i < 11; i++)
            {
                GameWorld.Instantiate(new Obstacle(crateSprite, 350+50*i, 300, true));
            }
            for (int i = 0; i < 14; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 300, 50*i));
            }
            for (int i = 0; i < 12; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 350 + 50*i, 650));
            }
            for (int i = 0; i < 8; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 900, 250+50 * i));
            }
        }
        private static void Level1()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800+50*i, 600));
            }
        }
        private static void Level2()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800 + 50 * i, 600));
            }
        }
        private static void Level3()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800 + 50 * i, 600));
            }
        }
        private static void Level4()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GameWorld.Instantiate(new Obstacle(crateSprite, 200 + 50 * j, 200 + 50 * i, true));
                }
            }
        }
        private static void Level5()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800 + 50 * i, 600));
            }
        }
        private static void Level6()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800 + 50 * i, 600));
            }
        }
        private static void Level7()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800 + 50 * i, 600));
            }
        }
        private static void Level8()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800 + 50 * i, 600));
            }
        }
        private static void Level9()
        {
            for (int i = 0; i < 10; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 200, 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 700, 200 + 50 * i));
            }
            for (int i = 0; i < 5; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 1200, 50 * i));
            }
            for (int i = 0; i < 7; i++)
            {
                GameWorld.Instantiate(new Obstacle(obstacleSprite, 800 + 50 * i, 600));
            }
        }

        public static void Update(GameTime gameTime)
        {
            PlayerLevelChange();
        }

        /// <summary>
        /// Check if all enemies are killed
        /// Afterwards, check if the player is moving to another level in the levelArray
        /// </summary>
        private static void PlayerLevelChange()
        {
            if (GameWorld.EnemiesLeft <= 0)
            {
                if (GameWorld.player.Position.X > GameWorld.ScreenSize.X && currentLevel[1] < 2) //Right side
                {
                    UnloadLevel();
                    GameWorld.player.Respawn("left");
                    currentLevel[1]++;
                    CreateLevel(levelArray[currentLevel[0], currentLevel[1]]);
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
        }
    }
}
