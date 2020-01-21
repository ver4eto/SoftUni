using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => throw new NotImplementedException();

        public int DurabilityPoints => throw new NotImplementedException();

        public void Attack(ITarget target)
        {
            throw new NotImplementedException();
        }
    }
}
