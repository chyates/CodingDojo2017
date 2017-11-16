using System;
using System.Collections.Generic;

namespace csharp_human{

// Create a base Human class with five attributes: name, strength, intelligence, dexterity, and health.
    public class Human{
        public string Name;
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Health { get; set; }

        public Human(string name=""){
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }

        public Human(string name = "", int strength = 0, int intelligence = 0, int dexterity = 0, int health = 0){
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        public void Attack(Human attacked){
            attacked.Strength -= 5;
            Console.WriteLine($"{attacked.Name} has been attacked by {this.Name}! Their strength is now {attacked.Strength}");
        }
    }
}