using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace topDownShooterProject.Classes
{
    interface IMoveable
    {
        void Move(GameTime gameTime);
    }
}
