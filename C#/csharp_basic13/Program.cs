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

        public static string findStateName(string zipCode)
        {
            int numZip = Int32.Parse(zipCode);
            string fullName = "";
            if (numZip >= 35004 && numZip <= 36925)
            {
                fullName = "Alabama";
            }
            else if (numZip >= 99501 && numZip <= 99950)
            {
                fullName = "Alaska";
            }
            else if ((numZip >= 71601 && numZip <= 75929) || numZip == 75502)
            {
                fullName = "Arkansas";
            }
            else if (numZip >= 85001 && numZip <= 86556)
            {
                fullName = "Arizona";
            }
            else if (numZip >= 90001 && numZip <= 96162)
            {
                fullName = "California";
            }
            else if (numZip >= 80001 && numZip <= 81658)
            {
                fullName = "Colorado";
            }
            else if (numZip >= 6001 && numZip <= 6389)
            {
                fullName = "Connecticut";
            }
            else if (numZip >= 20001 && numZip <= 20799)
            {
                fullName = "Washington, D.C.";
            }
            else if (numZip >= 19701 && numZip <= 19980)
            {
                fullName = "Delaware";
            }
            else if (numZip >= 32004 && numZip <= 34997)
            {
                fullName = "Florida";
            }
            else if ((numZip >= 30001 && numZip <= 31999) || numZip == 39901)
            {
                fullName = "Georgia";
            }
            else if (numZip >= 96701 && numZip <= 96898)
            {
                fullName = "Hawaii";
            }
            else if ((numZip >= 50001 && numZip <= 52809) || (numZip >= 68119 && numZip <= 68120))
            {
                fullName = "Iowa";
            }
            else if (numZip >= 83201 && numZip <= 83876)
            {
                fullName = "Idaho";
            }
            else if (numZip >= 60001 && numZip <= 62999)
            {
                fullName = "Illinois";
            }
            else if (numZip >= 46001 && numZip <= 47997)
            {
                fullName = "Indiana";
            }
            else if (numZip >= 66002 && numZip <= 67954)
            {
                fullName = "Kansas";
            }
            else if (numZip >= 40003 && numZip <= 42788)
            {
                fullName = "Kentucky";
            }
            else if ((numZip >= 70001 && numZip <= 71232) || (numZip >= 71234 && numZip <= 71497))
            {
                fullName = "Louisiana";
            }
            else if ((numZip >= 1001 && numZip <= 2791) || (numZip >= 5501 && numZip <= 5544))
            {
                fullName = "Massachusetts";
            }
            else if (numZip == 20331 || (numZip >= 20335 && numZip <= 20797) || (numZip >= 20812 && numZip <= 21930))
            {
                fullName = "Maryland";
            }
            else if (numZip >= 3901 && numZip <= 4992)
            {
                fullName = "Maine";
            }
            else if (numZip >= 48001 && numZip <= 49971)
            {
                fullName = "Michigan";
            }
            else if (numZip >= 55001 && numZip <= 56763)
            {
                fullName = "Minnesota";
            }
            else if (numZip >= 63001 && numZip <= 65899)
            {
                fullName = "Missouri";
            }
            else if ((numZip >= 38601 && numZip <= 39776) || numZip == 71233)
            {
                fullName = "Mississippi";
            }
            else if (numZip >= 59001 && numZip <= 59937)
            {
                fullName = "Montana";
            }
            else if (numZip >= 27006 && numZip <= 28909)
            {
                fullName = "North Carolina";
            }
            else if (numZip >= 58001 && numZip <= 58856)
            {
                fullName = "North Dakota";
            }
            else if ((numZip >= 68001 && numZip <= 68118) || (numZip >= 68122 && numZip <= 69367))
            {
                fullName = "Nebraska";
            }
            else if (numZip >= 3031 && numZip <= 3897)
            {
                fullName = "New Hampshire";
            }
            else if (numZip >= 7001 && numZip <= 8989)
            {
                fullName = "New Jersey";
            }
            else if (numZip >= 87001 && numZip <= 88441)
            {
                fullName = "New Mexico";
            }
            else if (numZip >= 88901 && numZip <= 89883)
            {
                fullName = "Nevada";
            }
            else if (numZip == 6390 || (numZip >= 10001 && numZip <= 14975))
            {
                fullName = "New York";
            }
            else if (numZip >= 43001 && numZip <= 45999)
            {
                fullName = "Ohio";
            }
            else if ((numZip >= 73001 && numZip <= 73199) || (numZip >= 73401 && numZip <= 74966))
            {
                fullName = "Oklahoma";
            }
            else if (numZip >= 97001 && numZip <= 97920)
            {
                fullName = "Oregon";
            }
            else if (numZip >= 15001 && numZip <= 19640)
            {
                fullName = "Pennsylvania";
            }
            else if (numZip >= 2801 && numZip <= 2940)
            {
                fullName = "Rhode Island";
            }
            else if (numZip >= 29001 && numZip <= 29948)
            {
                fullName = "South Carolina";
            }
            else if (numZip >= 57001 && numZip <= 57799)
            {
                fullName = "South Dakota";
            }
            else if (numZip >= 37010 && numZip <= 38589)
            {
                fullName = "Tennessee";
            }
            else if (numZip == 73301 || (numZip >= 75001 && numZip <= 75501) || (numZip >= 75503 && numZip <= 79999) || (numZip >= 88510 && numZip <= 88589))
            {
                fullName = "Texas";
            }
            else if (numZip >= 84001 && numZip <= 84784)
            {
                fullName = "Utah";
            }
            else if (numZip >= 20040 && numZip <= 24658)
            {
                fullName = "Virginia";
            }
            else if ((numZip >= 5001 && numZip <= 5495) || (numZip >= 5601 && numZip <= 5907))
            {
                fullName = "Vermont";
            }
            else if (numZip >= 98001 && numZip <= 99403)
            {
                fullName = "Washington";
            }
            else if (numZip >= 53001 && numZip <= 54990)
            {
                fullName = "Wisconsin";
            }
            else if (numZip >= 24701 && numZip <= 26886)
            {
                fullName = "West Virginia";
            }
            else if (numZip >= 82001 && numZip <= 83128)
            {
                fullName = "Wyoming";
            }
            return fullName;
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
            // Console.WriteLine(createOddArray());
            // greaterThanY(myArr, 5);
            // squareValsArray(myArr);
            // elimNegValsArray(myArr);
            // minMaxAvg(myArr);
            // shiftLeft(myArr);
            // object[] myArr2 = new object[] {1,5,-7, 4, -11};
            // replaceString(myArr2);
            Console.WriteLine(findStateName("03901"));
        }
    }
}
