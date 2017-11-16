using System;
using System.Collections.Generic;

namespace csharp_human
{
    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Health = 50;
            Intelligence = 25;
        }

        public void Heal()
        {
            Health += 10 * Intelligence;
            Console.WriteLine($"{this.Name} has been healed! Their health is now {this.Health}.");
        }

        public void Fireball(object target)
        {
            Human attacked = target as Human;
            Random rand = new Random();
            attacked.Health -= rand.Next(20,51);
            Console.WriteLine($"{this.Name} threw a fireball at {attacked.Name} and decreased their health! Their health is now {attacked.Health}");
        }
    }
}