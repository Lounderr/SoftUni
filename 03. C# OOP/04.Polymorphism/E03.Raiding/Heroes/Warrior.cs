using System;
using System.Collections.Generic;
using System.Text;

namespace E03.Raiding
{
    internal class Warrior : BaseHero
    {
        public override string Name { get; } = "Warrior";
        public override int Power { get; } = 100;
        public override string CastAbility()
        {
            throw new NotImplementedException();
        }
    }
}
