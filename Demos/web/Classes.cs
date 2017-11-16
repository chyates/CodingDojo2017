using System;
//using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace WebDemo
{
    [Serializable]
    public class Team
    {
        public string Sport;
        public string Mascot;
        private string _city;

        public int numPassenger { get; set;}

        public string City{get{ return _city;} set{ _city = value;}}

        public string Point;
        public byte Wins;
        public byte Losses;

        // public string Cheer()
        // { return "yay!"; }

        public Team(string sport = "", string mascot = "", string city = "", string point = "point")
        {
            Sport = sport;
            City = city;
            Mascot = mascot;
            Point = point;
        }

        public void PlayBall()
        {
            Console.WriteLine($"The {Mascot}'s play {Sport} in {City}");
        }

        public void Score()
        {
            Console.WriteLine($"The {Mascot} scored a {Point}");
        }
    }

    public class BaseballTeam : Team
    {
        public BaseballTeam(string city, string mascot, byte wins, byte losses) : base("baseball", mascot, city, "Run")
        { 
            Wins = wins;
            Losses = losses;
        }

        public new void Score()
        {
            Console.WriteLine("Using the overridden method.");
            Console.WriteLine($"The {Mascot} scored a {Point}");     
            base.Score();       
        }
    }
}