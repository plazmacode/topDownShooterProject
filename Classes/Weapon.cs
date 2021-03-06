using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace topDownShooterProject.Classes
{
    public class Weapon : GameObject
    {
        float rotation;
        MouseState mouseState = Mouse.GetState();


        public Weapon(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
            this.speed = 3000;
            this.velocity = -Vector2.Subtract(GameWorld.player.Position, new Vector2(mouseState.X, mouseState.Y));
            velocity.Normalize();
            this.rotation = GameWorld.player.Rotation;
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);
            if (position.Y < 0)
            {
                GameWorld.Destroy(this);
            }
            if (position.Y > GameWorld.ScreenSize.Y)
            {
                GameWorld.Destroy(this);
            }
            if (position.X < 0)
            {
                GameWorld.Destroy(this);
            }
            if (position.X > GameWorld.ScreenSize.X)
            {
                GameWorld.Destroy(this);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation - 1.57f, new Vector2(2,2), 1F, SpriteEffects.None, 0.2f);
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
            {
                GameWorld.Destroy(this);

                //When the amount of enemies spawned in the level is below the enemies required to beat the level
                //The enemy will respawn and several values used in the UI will be updated.
                if (GameWorld.EnemiesSpawned < GameWorld.EnemiesInLevel)
                {
                    //You cannot directly call subclass methods from the superclass.
                    //Instead you have to use System.Reflection
                    GameWorld.EnemiesSpawned++;
                    other.GetType().InvokeMember("Respawn", System.Reflection.BindingFlags.InvokeMethod, null, other, null);
                }
                else
                {
                    other.Position = new Vector2(-500, -500);
                }

                GameWorld.EnemiesLeft--;
                GameWorld.TotalEnemiesKilled++;

                if (GameWorld.EnemiesLeft <= 0)
                {
                    GameWorld.Difficulty = GameWorld.Difficulty * 1.25f;
                    Level.LevelsCompleted++;
                }
            }
        }

        public void Move(GameTime gameTime)
        {

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
    }
}
