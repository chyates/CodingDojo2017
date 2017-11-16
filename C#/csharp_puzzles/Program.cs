using System;
using System.Collections.Generic;

namespace csharp_puzzles
{
    public class Program
    {
        // public static void RandomArray(){
        //     List<int> numbers = new List<int>();
        //     Random randNum = new Random();
        //     string output = "[";
        //     for (int i=0; i<10; i++){
        //         numbers.Add(randNum.Next(5,26));
        //         output += numbers[i] + ",";
        //     }
        //     output += "]";
        //     int max = numbers[0];
        //     int min = numbers[0];
        //     int sum = 0;
        //     foreach (int val in numbers){
        //         sum += val;
        //         if (max < val){
        //             max = val;
        //         }
        //         if (min > val){
        //             min = val;
        //         }
        //     }
        //     Console.WriteLine(output);
        //     Console.WriteLine($"Max equals: {max}");
        //     Console.WriteLine($"Min equals: {min}");
        //     Console.WriteLine($"Sum equals: {sum}");
        // }

        // public static string CoinToss(){
        //     int headsCount = 0;
        //     int tailsCount = 0;
        //     string result = "";

        //     Console.WriteLine("Tossing a coin!");
        //     Random flip = new Random();
        //     int attempt = flip.Next(0,5);
        //     if (attempt >= 0 && attempt <= 2){
        //         attempt += 1;
        //         headsCount += 1;
        //         result += "You got heads!";
        //         Console.WriteLine(result);
        //     }
        //     else if (attempt > 2 && attempt <= 5){
        //         tailsCount += 1;
        //         result += "You got tails!";
        //         Console.WriteLine(result);
        //     }
        //     return result;
        //     }

        // public static string multCoinToss(int num){
        //     for (var i=1; i<=num; i++){
        //         CoinToss();
        //     }
        //     if (headsCount > 0){
        //         double HeadsToTotal = headsCount / num;
        //         }
        //     return HeadsToTotal;
        // }

        public static string[] namesArray(string[] arr){
            Random randName = new Random();
            for (int i=0; i<arr.Length; i++){
                int randIndex = randName.Next(i+1, arr.Length-1);
                string temp = arr[i];
                arr[i] = arr[randIndex];
                arr[randIndex] = temp;
                Console.WriteLine(arr[randIndex]);
            }
            Console.WriteLine(arr[arr.Length-1]);
            List<string> namesList = new List<string>();
            foreach (var val in arr){
                namesList.Add(val);
            }
            return namesList.ToArray();
        }

        public static void Main(string[] args)
        {
            // RandomArray();
            // CoinToss();
            // int myNum = 5;
            // multCoinToss(myNum);
            string[] names = new string[5] {"Todd", "Tiffany", "Geneva", "Charlie", "Sydney"};
            namesArray(names);
        }

        }
    }
