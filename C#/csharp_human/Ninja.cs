using System;
using System.Collections.Generic;

namespace csharp_human{
    public class Ninja : Human
    {
        public Ninja(string Name) : base(Name)
        {
            Dexterity = 175;
        }

        public void Steal(object target)
        {
            Human robbed = target as Human;
            Attack(robbed);
            Health += 10;
        }

        public void get_away()
        {
            Health -= 15;
        }
    }
}