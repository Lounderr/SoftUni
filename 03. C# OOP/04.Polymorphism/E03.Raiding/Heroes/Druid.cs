using System;
using System.Collections.Generic;
using System.Text;

namespace E03.Raiding
{
    internal class Druid : BaseHero
    {
        public override string Name { get; }
        public override int Power { get; } = 80;
        public override string CastAbility()
        {
            throw new NotImplementedException();
        }
    }
}
