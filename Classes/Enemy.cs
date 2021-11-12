using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    public class Enemy : Character
    {
     
        private Vector2 targetPosition;
        private Random random;
        private float rotation;

        public Enemy()
            {
            speed = 150;
            fps = 10;
            position = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y / 2);
            }
     
        public override void Update(GameTime gameTime)
        {
            this.velocity = -Vector2.Subtract(this.position, GameWorld.player.Position);
            this.velocity.Normalize();
            initialPosition = this.position;
            targetPosition = GameWorld.PlayerPosition;
            if (this.position.X > -100)
            {
                Move(gameTime);
                Look();
            }
        }

        public void Look() {
            Vector2 Dpos = GameWorld.player.Position - position;

            rotation = (float)Math.Atan2(Dpos.Y, Dpos.X);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("survivor-idle_shotgun_0");
            Respawn();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(14,20), 1F, SpriteEffects.None, 0.2f);
        }

        public void Respawn()
        {
            random = new Random();

            //Create an array of the 4 sides of the screen
            Vector2[] spawns = new Vector2[4];
            spawns[1] = new Vector2(0, GameWorld.ScreenSize.Y / 2); //Left
            spawns[0] = new Vector2(GameWorld.ScreenSize.X, GameWorld.ScreenSize.Y / 2); //Right
            spawns[2] = new Vector2(GameWorld.ScreenSize.X / 2, 0); //Top
            spawns[3] = new Vector2(GameWorld.ScreenSize.X / 2, GameWorld.ScreenSize.Y); //Bottom
            
            //Sets the enemy position to a random side of the screen
            position = spawns[random.Next(0,4)];
            //Randomize the position so the enemies are not directly on top of eachother
            position += new Vector2(random.Next(-25,25), random.Next(-25, 25));
        }
    }
}
