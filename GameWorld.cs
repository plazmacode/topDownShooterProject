using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace topDownShooterProject.Classes
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont text;

        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> obstacles = new List<GameObject>(); //Level design
        private static List<GameObject> newGameObjects = new List<GameObject>();
        private static List<GameObject> removeGameObjects = new List<GameObject>();

        private Texture2D collisionTexture;

        private static Vector2 screenSize;

        private static Vector2 playerPosition;

        public static Vector2 ScreenSize { get => screenSize; set => screenSize = value; }
        public static Vector2 PlayerPosition { get => playerPosition; set => playerPosition = value; }

        public static Player player = new Player();
        
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
            obstacles = new List<GameObject>();

            gameObjects.Add(player);
            gameObjects.Add(new Obstacle());
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

            text = Content.Load<SpriteFont>("text");

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerPosition = player.Position;

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
        }

        public void RemoveObjects()
        {
            foreach (GameObject gameObject in removeGameObjects)
            {
                gameObjects.Remove(gameObject);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //UI
            _spriteBatch.DrawString(text, "Heatlh: " + player.Health.ToString(), new Vector2(0, 50), Color.Red);
            _spriteBatch.DrawString(text, "Ammo: " + player.Ammo.ToString(), new Vector2(0, 80), Color.White);


            //GameObjects
            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(_spriteBatch);
#if DEBUG
                DrawCollisionBox(obj);
#endif
            }

            _spriteBatch.End();

            base.Draw(gameTime);

        }
        private void DrawCollisionBox(GameObject gameObject)
        {
            Rectangle collisionBox = gameObject.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            _spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            _spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            _spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            _spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public static void instantiate(GameObject gameObject)
        {
            newGameObjects.Add(gameObject);
        }

        public static void Destroy(GameObject gameobject)
        {
            removeGameObjects.Add(gameobject);
        }
    }
}
