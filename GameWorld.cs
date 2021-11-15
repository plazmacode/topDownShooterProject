using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace topDownShooterProject.Classes
{
    public class GameWorld : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont text;

        public static List<GameObject> gameObjects = new List<GameObject>();
        private static List<GameObject> newGameObjects = new List<GameObject>();
        private static List<GameObject> removeGameObjects = new List<GameObject>();

        private Texture2D collisionTexture;
        private Texture2D backgroundImage;

        private static Vector2 screenSize;

        public static Player player = new Player();

        private static int enemiesLeft;
        private static int enemiesInLevel;
        private static int enemiesSpawned;
        private static int totalEnemiesKilled;
        private static float difficulty = 1;

        public static Vector2 ScreenSize { get => screenSize; set => screenSize = value; }
        public static int EnemiesLeft { get => enemiesLeft; set => enemiesLeft = value; }
        public static int EnemiesInLevel { get => enemiesInLevel; set => enemiesInLevel = value; }
        public static int EnemiesSpawned { get => enemiesSpawned; set => enemiesSpawned = value; }


        public static int TotalEnemiesKilled { get => totalEnemiesKilled; set => totalEnemiesKilled = value; }
        public static float Difficulty { get => difficulty; set => difficulty = value; }



        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ScreenSize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            player.Position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
        }

        protected override void Initialize()
        {
            gameObjects = new List<GameObject>();
            newGameObjects = new List<GameObject>();
            removeGameObjects = new List<GameObject>();

            gameObjects.Add(player);
            for (int i = 0; i < 10; i++)
            {
                gameObjects.Add(new Enemy());
            }
            //Create backgroundObjects
            for (int i = 0; i < 50; i++)
            {
                gameObjects.Add(new BackgroundObject());
            }


            for (int i = 0; i < 3; i++) //Spawns 5 ammoPickups
            {
                gameObjects.Add(new AmmoPickup());
            }
            for (int i = 0; i < 3; i++) //Spawns 5 ammoPickups
            {
                gameObjects.Add(new HealthPickup());
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            backgroundImage = Content.Load<Texture2D>("backgroundImage");
            text = Content.Load<SpriteFont>("text");

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }
            Level.LoadContent(Content);
            Level.CreateLevel(0);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Level.Update(gameTime);

            AddObjects();
            RemoveObjects();

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
                foreach (GameObject other in gameObjects)
                {
                    gameObject.CheckCollision(other);
                }
            }

            base.Update(gameTime);
        }

        public void AddObjects()
        {
            foreach (GameObject gameObject in newGameObjects)
            {
                gameObjects.Add(gameObject);
            }
            newGameObjects.Clear();
        }

        public void RemoveObjects()
        {
            foreach (GameObject gameObject in removeGameObjects)
            {
                gameObjects.Remove(gameObject);
            }
            removeGameObjects.Clear();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.FrontToBack);

            _spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White);

            //GameObjects
            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(_spriteBatch);
#if DEBUG
                DrawCollisionBox(obj);
#endif
            }

            //UI
            _spriteBatch.DrawString(text, "Heatlh: " + player.Health.ToString(), new Vector2(20, 20), Color.Red, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);
            _spriteBatch.DrawString(text, "Ammo: " + player.Ammo.ToString(), new Vector2(20, 50), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);
            _spriteBatch.DrawString(text, "Enemies Left: " + enemiesLeft.ToString(), new Vector2(20, 80), Color.Black, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);
            _spriteBatch.DrawString(text, "Total Enemies Killed: " + totalEnemiesKilled.ToString(), new Vector2(20, 110), Color.Black, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);
            _spriteBatch.DrawString(text, "Levels Completed: " + Level.LevelsCompleted.ToString(), new Vector2(20, 140), Color.Black, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);

            _spriteBatch.DrawString(
            text, "Current Level: " + Level.LevelArray[Level.CurrentLevel[0], Level.CurrentLevel[1]].ToString(),
            new Vector2(ScreenSize.X/2-100, 20), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1);

            _spriteBatch.End();

            base.Draw(gameTime);

        }
        private void DrawCollisionBox(GameObject gameObject)
        {
            Rectangle collisionBox = gameObject.CollisionBox();
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            _spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            _spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            _spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            _spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public static void Instantiate(GameObject gameObject)
        {
            newGameObjects.Add(gameObject);
        }

        public static void Destroy(GameObject gameobject)
        {
            removeGameObjects.Add(gameobject);
        }
    }
}
