using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    public class Character : GameObject
    {
        protected Vector2 initialPosition; //Get position of character, before it has moved
        protected int health;
        protected int ammo;
        protected Weapon weapon;

        public int Ammo { get => ammo; set => ammo = value; }
        public int Health { get => health; set => health = value; }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void OnCollision(GameObject other)
        {
            if (other is Obstacle) //collision code 2.0
            {
                this.position = initialPosition;
            }
            //if (other is Obstacle) //Collision code 1.0
            //{
            //    position -= velocity * speed * (float)0.05;
            //}
        }

        public override void Update(GameTime gameTime)
        {

        }

        public void Move(GameTime gameTime)
        {
            initialPosition = this.position; //saves initial position before the player has moved.
            //TODO check future position if it colllides with an obstacle. Then stop the player from moving into that position.

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            position += ((velocity * speed) * deltaTime);
        }
    }
}
