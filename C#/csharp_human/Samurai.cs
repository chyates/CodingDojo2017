using System;
using System.Collections.Generic;

namespace csharp_human{
    public class Samurai : Human 
    {
        public Samurai (string name) : base(name)
        {
            Health = 200;
        }

        public void death_blow(object target)
        {
            Human killed = target as Human;
            Attack(killed);
            if (killed.Health < 50){
                killed.Health = 0;
            }
        }

        public void Meditate()
        {
            if (Health < 200)
            {
                Health = 200;
            }
        }
    }
}