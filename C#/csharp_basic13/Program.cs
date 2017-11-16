using System;
using System.Collections.Generic;

namespace csharp_basic13
{
    public class Program
    {
        // print integers from 1-255
        public static void print1To255(){
            for (int i=1; i<256; i++){
                Console.WriteLine(i);
                }
            }

        // print odd integers from 1-255
        public static void printOdd1To255(){
            for (int i=1; i<256; i++){
                if (i % 2 != 0){
                    Console.WriteLine(i);
                    }
                }
            }

        // print arr along with their sums, 1-255
        public static void printNumAndSum(){
            int sum=0;
            for (int i=1; i<256; i++){
                sum += i;
                Console.WriteLine("number:"+ i + " sum:"+ sum);
            }
        }

        // loop through array and print all values
        public static void printArray(int[] arr){
            foreach (var num in arr){
                Console.WriteLine(num);
            }
        }

        // find/print max value of an array
        public static void findMax(int[] arr){
            int max = arr[0];
            for (int i=1; i<arr.Length; i++){
                if (arr[i] > max){
                    max = arr[i];
                    }
                }
            Console.WriteLine(max);
            }

        // find/print average value of an array
        public static void findAvg(int[] arr){
            int sum = 0;
            for (int i=0; i<arr.Length; i++){
                sum += arr[i];
            }
            int avg = sum / arr.Length;
            Console.WriteLine(avg);
        }

        // write array that contains all the odd arr from 1-255
        public static int[] createOddArray(){
            List<int> odds = new List<int>();
            for (int i=1; i <=255; i++){
                if (i%2 != 0){
                    odds.Add(i);
                }
            }
            return odds.ToArray();
        }

        // write a function that returns amt of values > Y
        public static void greaterThanY(int[] arr, int y){
            int count = 0;
            foreach (int val in arr){
                if (val > y){
                    count++;
                }
            }
            Console.WriteLine("There are {count} values greater than {y}");
        }
        // write a function that squares the values in an array and returns the array of new values
        public static void squareValsArray(int[] arr){
            for (int i=0; i<arr.Length; i++){
                arr[i] *= arr[i];
            }
        }

        // write a function that eliminates the negative values of an array
        public static void elimNegValsArray(int[] arr){
            for (int i=0; i<arr.Length; i++){
                if (arr[i] < 0){
                    arr[i] = 0;
                }
            }
        }

        // write a function that prints an array of the min, max, and average values of a given array
        public static void minMaxAvg(int[] arr){
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            foreach(int val in arr){
                sum += val;
                if (val < min){
                    min = val;
                }
                if (val > max){
                    max = val;
                }
            }
            int avg = sum / arr.Length;
            Console.WriteLine($"The maximum is {max}, the minimum is {min}, and the average is {avg}");
        }
        // write function that shifts values in an array to the left; add 0 to the end
        public static void shiftLeft(int[] arr){
            for (int i =0; i<arr.Length; i++){
                arr[i] = arr[i+1];
            }
            arr[arr.Length-1] = 0;
        }
        // write function that replaces any negative values with the string 'Dojo'
        public static object replaceString(object[] arr){
            for (int i=0; i<arr.Length; i++){
                if ((int)arr[i] < 0){
                    arr[i] = "Dojo";
                }
            }
            return arr;
        }
        public static void Main(string[] args)
        {
            // print1To255();
            // printOdd1To255();
            // printNumAndSum();
            // int[] myArr = new int[6] {1,3,-6,7,9,10};
            // printArray(myArr);
            // findMax(myArr);
            // findAvg(myArr);
            Console.WriteLine(createOddArray());
            // greaterThanY(myArr, 5);
            // squareValsArray(myArr);
            // elimNegValsArray(myArr);
            // minMaxAvg(myArr);
            // shiftLeft(myArr);
            // object[] myArr2 = new object[] {1,5,-7, 4, -11};
            // replaceString(myArr2);
        }
    }
}
