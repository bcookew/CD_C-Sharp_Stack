using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static void PrintNums()
        {
            for(int i = 1; i <= 255; i += 1)
            {
                System.Console.WriteLine(i);
            }
        }
        public static void PrintOdds()
        {
            for(int i = 1; i <= 255; i += 2)
            {
                System.Console.WriteLine(i);
            }
        }
        public static void PrintSum()
        {
            int sum = 0;
            for(int i = 0; i <= 255; i += 1)
            {
                sum += i;
                System.Console.WriteLine($"New number: {i} Sum {sum}");
            }
        }

        public static void LoopArray(int[] numbers)
        {
            foreach (int num in numbers)
            {
                System.Console.WriteLine(num);
            }
        }

        public static int FindMax(int[] numbers)
        {
            int current_biggest = 0;
            foreach (int num in numbers)
            {
                if (num > current_biggest)
                {
                    current_biggest = num;
                }
            }
            System.Console.WriteLine(current_biggest);
            return current_biggest;
        }

        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            float avg = sum / numbers.GetLength(0);
            System.Console.WriteLine($"The average value of the input array is {avg}");
        }

        public static int[] OddArray()
        {
            int counter = 0;
            for (int i = 0; i < 256; i++)
            {
                if (i % 2 == 1)
                {
                    counter ++;
                }
            }
            int[] odds = new int[counter];
            
            int cur_num = 1;
            for (int j = 0; j < odds.Length; j++)
            {
                odds[j] = cur_num;
                cur_num += 2;
            }
            return odds;
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            int counter = 0;
            foreach (int num in numbers)
            {
                if(num > y)
                {
                    counter++;
                }
            }
            return counter;
        }

        public static void SquareArrayValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }

        }

        public static void EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        public static void MinMaxAverage(int[] numbers)
        {
            int min = numbers[0];
            int max = numbers[0];
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
                if (num < min)
                {
                    min = num;
                }
                else if (num > max)
                {
                    max = num;
                }
            }
            float avg = sum / numbers.Length;
            System.Console.WriteLine($"Min: {min}\nMax: {max}\nAvg: {avg}");
        }

        public static void ShiftValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length-1)
                {
                    numbers[i] = 0;
                }
                numbers[i] = numbers[i+1];
            }
        }
        public static object[] NumToString(int[] numbers)
        {
            object[] mixedArr = new object[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    mixedArr[i] = "Dojo";
                }
                else
                {
                    mixedArr[i] = numbers[i];
                }
            }
            return mixedArr;
        }
    }
}
