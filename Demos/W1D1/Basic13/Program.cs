using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = {5,5,5,5,5,5,5};
            GetAverage(numArr);
        }
        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            System.Console.WriteLine($"The average is {sum/numbers.Length}");
        }
    }
}
