using System;
using System.Collections.Generic;

namespace csharp_coll
{
    class Program
    {
        static void Main(string[] args)
        {
            // simple arrays
            int[] numbers = {0,1,2,3,4,5,6,7,8,9};
            foreach (var num in numbers){
                Console.WriteLine(num);
            }
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            foreach (var name in names){
                Console.WriteLine(name);
            }

            // multiplication table
            int[,] multTable = new int[10,10];
            for (int i=0; i<10; i++){
                for (int x=0; x<10; x++)
                {
                    multTable[i,x] = (i+1)*(x+1);
                    Console.Write(multTable[i,x]+"\t");
                }
            Console.WriteLine();
            }

            // list: ice cream flavors
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Mint Chocolate Chip");
            flavors.Add("Moose Tracks");
            flavors.Add("Cookies and Cream");
            flavors.Add("Chocolate Peanut Butter");
            Console.WriteLine(flavors.Count);

            Console.WriteLine("Third flavor: "+ flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            // user info dictionary
            Dictionary<string, string> userInfo = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in names){
                userInfo[name] = flavors[rand.Next(flavors.Count)];
            }

            Console.WriteLine("Names and flavors:");
            foreach (KeyValuePair<string, string> info in userInfo){
                Console.WriteLine(info.Key + ":" + info.Value);
            }
        }
    }
}
