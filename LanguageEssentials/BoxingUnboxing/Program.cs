using System;
using System.Collections.Generic;
namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<object> box = new List<object>();
            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");
            int sum = 0;
            foreach (var item in box)
            {
                System.Console.WriteLine(item);
                if (item is int)
                {
                    sum += (int)item;
                }
            }
            System.Console.WriteLine(sum);

        }
    }
}
