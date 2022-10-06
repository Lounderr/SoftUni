using System;
using System.Collections.Generic;
using System.Text;

namespace E03.Raiding
{
    abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract int Power { get; }

        public abstract string CastAbility();
    }
}
