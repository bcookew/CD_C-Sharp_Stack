using System;
using System.Collections.Generic;
namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RandomArray();
            string result = CoinFlip();
            System.Console.WriteLine("\n\n", result);
            double ratio = TossMultipleCoins(5);
            System.Console.WriteLine("\n\n", ratio, "\n\n");
            List<string> names = Names();
            foreach (string name in names)
            {
                System.Console.WriteLine(name);
            }
        }
        public static void RandomArray()
        {
            int[] arr = new int[10];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(5,25);
            }
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            foreach (int num in arr)
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
            System.Console.WriteLine($"Min: {min}\nMax: {max}\nSum: {sum}");
        }
        public static string CoinFlip()
        {
            System.Console.WriteLine("Tossing a coin!");
            Random rand = new Random();
            int num = rand.Next(0,1);
            string result;
            if (num == 1)
            {
                result = "Heads!";
            }
            else
            {
                result = "Tails!";
            }
            System.Console.WriteLine(result);
            return result;
        }
        public static double TossMultipleCoins(int num)
        {
            int heads = 0;
            int tails = 0;
            for (int i = 0; i < num; i++)
            {
                string result = CoinFlip();
                if (result == "heads")
                {
                    heads++;
                }
                else
                {
                    tails++;
                }
            }
            return heads/num;
        }

        public static List<string> Names()
        {
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            Random rand = new Random();
            for (int i = 0; i < names.Count; i++)
            {
                string temp = names[i];
                int num = rand.Next(0, names.Count);
                names[i] = names[num];
                names[num] = temp;
            }
            foreach (string name in names)
            {
                System.Console.WriteLine(name);
            }
            for (int j = 0; j < names.Count; j++)
            {
                if (names[j].Length <= 5)
                {
                    names[j] = "";
                }
            }
            return names;
        }
    }
}
