using System;

namespace Hello.NETCore_
{
    class Program
    {
        static void Main(string[] args)
        {
            // string place = "Coding Dojo - Cleveland, TN";
            Console.WriteLine("My name is {0}, I am " + 28 + " years old", "Tim");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }
            // loop from 1 to 5 excluding 5
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine(i);
            }
            int start = 0;
            int end = 5;
            // loop from start to end including end
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
            // loop from start to end excluding end
            for (int i = start; i < end; i++)
            {
                Console.WriteLine(i);
            }
            Random rand = new Random();
            System.Console.WriteLine(rand.Next());
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine(rand.Next(2,8));
            }
        }
    }
}
