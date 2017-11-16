using System;
using System.Collections.Generic;

namespace csharp_boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> Data = new List<object>();
            Data.Add(7);
            Data.Add(28);
            Data.Add(-1);
            Data.Add(true);
            Data.Add("chair");

            int sum = 0;

            foreach (var value in Data){
                if (value is int){
                    Console.WriteLine("This is a number. The value is " + value);
                    sum += (int)value;
                }
                if (value is string){
                    Console.WriteLine("This is a string. It reads: " + value);
                }
                if (value is bool){
                    Console.WriteLine("This is a boolean value. It is " + value);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
