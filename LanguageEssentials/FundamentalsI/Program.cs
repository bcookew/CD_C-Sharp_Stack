using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C# Fundamentals I!");

            // for(int i = 1; i <= 255; i++)
            // {
            //     Console.WriteLine(i);
            // }

            // for (int i = 0; i < 100; i++)
            // {
            //     if (i % 3 == 0 && i % 5 == 0)
            //     {
            //         continue;
            //     }
            //     else if (i % 3 == 0 || i % 5 == 0)
            //     {
            //         Console.WriteLine(i);
            //     }

            // }
            // for (int i = 0; i < 100; i++)
            // {
            //     if (i % 3 == 0 && i % 5 == 0)
            //     {
            //         Console.WriteLine("FizzBuzz");
            //     }
            //     else if (i % 3 == 0)
            //     {
            //         Console.WriteLine("Fizz");
            //     }
            //     else if ( i % 5 == 0)
            //     {
            //         Console.WriteLine("Buzz");
            //     }

            // }
            int i = 1;
            while (i <= 100)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if ( i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }

                i++;

            }
        }
    }
}
