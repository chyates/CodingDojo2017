using System;
using System.Collections.Generic;

namespace csharp_human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Steven = new Human("Steven", 20, 25, 50, 125);
            Human Jasper = new Human("Jasper");
            Console.WriteLine(Steven.Strength);
            Jasper.Attack(Steven);
        }
    }
}
