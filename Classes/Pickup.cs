using System;
using System.Collections.Generic;
using System.Text;

namespace topDownShooterProject.Classes
{
    public abstract class Pickup : GameObject
    {
        protected Random random;

        protected abstract void Respawn();
    }
}
