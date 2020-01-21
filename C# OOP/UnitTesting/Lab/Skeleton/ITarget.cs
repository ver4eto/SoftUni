using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public interface ITarget
    {
        bool IsDead();
        int Health { get; }
        void TakeAttack(int attackPoints);
        int GiveExperience();
    }
}
