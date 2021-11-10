using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    class Enemy : Character
    {
        private Vector2 targetPosition;

        public override void Update(GameTime gameTime)
        {
            targetPosition = GameWorld.PlayerPosition;
        }
    }
}
